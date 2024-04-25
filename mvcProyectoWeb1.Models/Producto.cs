using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        // Relación con Categoría
        public Categoria Categoria { get; set; }

        // Relación con Transacciones
        public ICollection<Transaccion> Transacciones { get; set; }
    }
}
