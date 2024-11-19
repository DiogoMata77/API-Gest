using APIGest.Data;
using APIGest.Models;
using Microsoft.AspNetCore.Mvc;
namespace APIGest.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/[controller]/[action]")]
    public class DespezasController : ControllerBase
    {
        private readonly ApiContext _context;
        public DespezasController(ApiContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var products = _context.Despezas.ToList();
            return new JsonResult(Ok(products));
        }

        [HttpPost]
        public JsonResult Create(Despezas despaza)
        {
            _context.Despezas.Add(despaza);
            _context.SaveChanges();
            return new JsonResult(Ok(despaza));
        }

        [HttpPut("{id}")]
        public JsonResult Update(int id, Despezas despezas)
        {
            var despezaID = _context.Despezas.Find(id);
            if (despezaID == null)
                return new JsonResult(NotFound());
            else
            {
                despezas.Id = despezaID.Id;
                //_context.Despezas.Update(despezas);
                _context.SaveChanges();
            }
            return new JsonResult(Ok(despezas));
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var despeza = _context.Despezas.Find(id);
            if(despeza == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(despeza));
        }
        
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var despeza = _context.Despezas.Find(id);
            if(despeza == null)
                return new JsonResult(NotFound());
            _context.Despezas.Remove(despeza);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

    }
}
