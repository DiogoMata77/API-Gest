using System.ComponentModel.DataAnnotations.Schema;

namespace APIGest.Models
{
    [Table("Despezas")]
    public class Despezas
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Desc")]
        public string? Desc {  get; set; }
        [Column("Valor")]
        public decimal? Valor { get; set; }
        [Column("Finalidade")]
        public int? Finalidade { get; set; }
        [Column("Finalidade_desc")]
        public string? Finalidade_desc { get; set; }
        [Column("Data")]
        public DateTime? Data { get; set; } 
    }
}
