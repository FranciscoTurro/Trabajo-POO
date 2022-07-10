using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Permisos
    {
        private static Permisos instancia;

        private Permisos() { }

        public static Permisos obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Permisos();
            }
            return instancia;
        }

        public List<Modelo.Permiso> ListarPermisos(Modelo.Formulario formulario)
        {
            return formulario.Permiso.ToList();
        }
    }
}
