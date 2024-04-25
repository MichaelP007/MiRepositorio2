using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        IAlmacenRepository Almacen { get; }
        IProductoRepository Producto { get; }
        ICategoriaRepository Categoria { get; }
        IProveedorRepository Proveedor { get; }
        ITransaccionRepository Transaccion { get; }
        ICompraRepository Compra { get; }
        IUsuarioRepository Usuario { get; }
        ISliderRepository Slider { get; }
        void Save();
    }
}
