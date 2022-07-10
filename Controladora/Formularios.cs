using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Formularios
    {
        private static Formularios instancia;

        private Formularios() { }

        public static Formularios obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Formularios();
            }
            return instancia;
        }

        public List<Modelo.Formulario> ListaFormularios(Modelo.Usuario usuario)
        {
            return usuario.Perfil.Formulario.ToList();
        }

        public List<Modelo.Formulario> ListarFormularios()
        {
            return Modelo.SingletonContexto.obtenerInstancia().Contexto.Formularios.ToList();
        }
    }
}
