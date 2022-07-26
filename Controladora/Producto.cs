using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Producto
    {
        private static Producto instancia;

        private Producto() { }

        public static Producto obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Producto();
            }
            return instancia;
        }

        public void AgregarProducto(Modelo.Producto producto)
        {
            Modelo.SingletonContexto.obtenerInstancia().Contexto.Productos.Add(producto);
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
        }

        public void EliminarProducto(Modelo.Producto producto)
        {
            Modelo.SingletonContexto.obtenerInstancia().Contexto.Productos.Remove(producto);
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
        }

        public List<Modelo.Producto> ListaProductos()
        {
            return Modelo.SingletonContexto.obtenerInstancia().Contexto.Productos.ToList();
        }
    }
}
