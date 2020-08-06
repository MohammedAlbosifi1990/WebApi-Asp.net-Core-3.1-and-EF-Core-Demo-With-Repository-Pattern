using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.Repository;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RPController : BaseController<UserInfo, UserRepo>
    {
        private readonly UserRepo _repository;
        public RPController(UserRepo repository) : base(repository)
        {
            _repository = repository;
        }


        [HttpGet("withInclude")]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetWithInclude()
        {
            return Ok(await repository.Get2(includes: (x => x.Messages)));
        }
    }
}
