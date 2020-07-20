using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IGenericRepository<TEntity>
    {
        protected readonly TRepository repository;

        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }


        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await repository.GetAll();
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var model = await repository.Get(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }
            await repository.Update(model);
            return NoContent();
        }

        // POST: api/[controller]
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity model)
        {
            await repository.Add(model);
            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var model = await repository.Delete(id);
            if (model == null)
            {
                return NotFound();
            }
            return model;
        }

    }
}
