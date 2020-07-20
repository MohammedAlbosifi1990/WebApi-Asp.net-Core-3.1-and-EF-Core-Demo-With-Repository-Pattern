using Microsoft.AspNetCore.Mvc;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.Repository;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPController : BaseController<UserInfo, UserRepo>
    {
        public RPController(UserRepo repository) : base(repository)
        {

        }

    }
}
