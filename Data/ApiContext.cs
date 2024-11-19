using APIGest.Models;
using Microsoft.EntityFrameworkCore;

namespace APIGest.Data
{
    public class ApiContext : DbContext
    {
        //Utilizar para conectar uma base de dados a api para consumir e manipular
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) {}

        //Criar as tabelas consuantos os dados dos models
        public DbSet<Product> Produtos { get; set; }
        public DbSet<Despezas> Despezas { get; set; }
    }
}
