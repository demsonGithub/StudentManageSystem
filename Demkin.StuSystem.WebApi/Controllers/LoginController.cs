using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demkin.StuSystem.WebApi.Controllers
{
    /// <summary>
    /// 登录模块
    /// </summary>
    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class LoginController : Controller
    {
        public LoginController()
        {
        }

        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<string> Test()
        {
            return await Task.Run(() =>
            {
                return "asdad";
            });
        }
    }
}