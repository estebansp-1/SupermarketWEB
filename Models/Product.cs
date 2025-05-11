using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class Product
    {
        public int Id { get; set; } // Clave primaria
        public string Name { get; set; } // Nombre del producto

        [Column(TypeName = "decimal(16,2)")]
        public decimal Price { get; set; } // Precio con precisión decimal

        public int Stock { get; set; } // Cantidad en stock

        public int CategoryId { get; set; } // Clave foránea a Category

        public Category? Category { get; set; } // Propiedad de navegación
    }

}
