using APIGest.Data;
using APIGest.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIGest.Controllers
{
    [ApiController]
    //Versão da api
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    //Para afetar o link da api 
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class ProdutosController : Controller
    {
        private readonly ApiContext _context;

        public ProdutosController(ApiContext context)
        {
            //Definir Coneccao para a base de dados
            _context = context;
        }

        //2  formar de pegar a in formação
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return _context.Produtos.ToList();
        }

        //MapToApiVersion() define para qual das versões esta funcao funciona e funciona para multiplas verções
        [HttpGet, MapToApiVersion("2.0"), MapToApiVersion("1.0")]
        public JsonResult GetAll()
        {
            var products = _context.Produtos.ToList();

            return new JsonResult(products);
        }


        //Pegar todos os elementos com o estado de venda dinamica
        [HttpGet("{estado}")]
        public JsonResult GetByEstadoDeVenda(int estado)
        {
            var products = _context.Produtos.Where(p => p.Mine == estado && p.State == 1).ToList();
            return new JsonResult(products);
        }

        

        [HttpPost]
        public JsonResult CreateEdit(Product produto)
        {
            if(produto.Id == 0)
            {   
                _context.Produtos.Add(produto);
            }
            else
            {
                var produtoID = _context.Produtos.Find(produto.Id);

                if(produtoID == null)
                {
                    return new JsonResult(NotFound());
                }
                produtoID = produto;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(produto));
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(produto));
        }

        //Posso costumizar os dados passados e algumas informacoes usando o sumari
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var product = _context.Produtos.Find(id);
            if(product == null)
                return new JsonResult(NotFound());

            _context.Produtos.Remove(product);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }


    }
}
