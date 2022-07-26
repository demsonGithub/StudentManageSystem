using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;

namespace Demkin.StuSystem.Util.Helper
{
    /// <summary>
    /// Csv 常用操作
    /// </summary>
    public class CsvHelper
    {
        public static DataTable CsvToTable(string filePath)
        {
            try
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DataTable dt = new DataTable();

                using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8")))
                {
                    // 记录每次读取的一行记录
                    string strLine = "";
                    // 记录每行记录中的各字段内容
                    string[] tableHead = null;
                    string[] arrayLine = null;

                    // 标识列数
                    int columnCount = 0;
                    // 标识是否读取的第一行
                    bool isFirstColumn = true;
                    // 逐行读取csv中的数据
                    while ((strLine = sr.ReadLine()) != null)
                    {
                        if (isFirstColumn)
                        {
                            tableHead = strLine.Split(',');
                            isFirstColumn = false;
                            columnCount = tableHead.Length;
                            // 创建列
                            for (int i = 0; i < columnCount; i++)
                            {
                                DataColumn dc = new DataColumn(tableHead[i]);
                                dt.Columns.Add(dc);
                            }
                        }
                        else
                        {
                            arrayLine = strLine.Split(',');
                            DataRow dr = dt.NewRow();
                            for (int j = 0; j < columnCount; j++)
                            {
                                dr[j] = arrayLine[j];
                            }
                            dt.Rows.Add(dr);
                        }
                    }
                    sr.Close();
                    fs.Close();
                    return dt;
                }
            }
            catch (Exception)
            {
                // todo
                return null;
            }
        }

        /// <summary>
        /// csv文件内容转换List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<T> CsvToList<T>(string filePath) where T : class
        {
            DataTable dt = CsvToTable(filePath);
            if (dt == null)
                return null;

            // 获得T的类型
            List<T> tlist = Activator.CreateInstance<List<T>>();
            var dType = typeof(T);
            foreach (DataRow dr in dt.Rows)
            {
                T t = Activator.CreateInstance<T>();
                foreach (PropertyInfo pInfo in dType.GetProperties())
                {
                    string columnName = pInfo.Name;
                    //Csv中是否包含此列名
                    if (dt.Columns.Contains(columnName))
                    {
                        var val = dr[columnName];

                        if (pInfo.PropertyType.FullName.Contains("String"))
                        {
                            pInfo.SetValue(t, val.ObjToString());
                        }
                        else if (pInfo.PropertyType.FullName.Contains("Int32"))
                        {
                            pInfo.SetValue(t, val.ObjToInt());
                        }
                        else if (pInfo.PropertyType.FullName.Contains("DateTime"))
                        {
                            pInfo.SetValue(t, val.ObjToDate());
                        }
                        else if (pInfo.PropertyType.FullName.Contains("Boolean"))
                        {
                            pInfo.SetValue(t, val.ObjToBool());
                        }
                        else
                        {
                            pInfo.SetValue(t, val);
                        }
                    }
                }
                tlist.Add(t);
            }
            return tlist;
        }
    }
}