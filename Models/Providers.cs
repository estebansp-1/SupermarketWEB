namespace SupermarketWEB.Models
{
    public class Providers
    {
        public int Id { get; set; } // Será la llave primaria
        public int Idetificacion { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Direccion { get; set; }

        public string? cumpleanos { get; set; }

        public int Celular { get; set; }

        public string? Email { get; set; }
    }
}
