using System.ComponentModel.DataAnnotations.Schema;

namespace APIGest.Models
{
    [Table("Product")]
    public class Product
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Mine")]
        public Int16? Mine {  get; set; }

        [Column("MineDes")]
        public string? MineDes {  get; set; }

        [Column("ProductLink")]
        public string? ProductLink { get;set; } 
        
        [Column("Image")]
        public string? Image {  get; set; }

        [Column("State")]
        public Int16? State {  get; set; }

        [Column("BuingPrice")]
        public double? BuingPrice { get; set; }
        
        [Column("SellingPrice")]
        public double? SellingPrice { get; set;}

        [Column("Quantity")]
        public int Quantity { get; set; }

    }
}
