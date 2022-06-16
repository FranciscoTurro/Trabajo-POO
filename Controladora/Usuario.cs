using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Usuario
    {
        private static Usuario instancia;

        private Usuario() { }

        public static Usuario obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Usuario();
            }
            return instancia;
        }

        public void AgregarUsuario(Modelo.Usuario usuario)
        {
            Modelo.SingletonContexto.obtenerInstancia().Contexto.Usuarios.Add(usuario);
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
        }

        public void BorrarUsuario(Modelo.Usuario usuario)
        {
            Modelo.SingletonContexto.obtenerInstancia().Contexto.Usuarios.Remove(usuario);
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
        }

        public Modelo.Usuario ObtenerUsuario(int codigo)
        {
            return Modelo.SingletonContexto.obtenerInstancia().Contexto.Usuarios.Find(codigo);
        }

        public List<Modelo.Usuario> ListaUsuarios()
        {
            return Modelo.SingletonContexto.obtenerInstancia().Contexto.Usuarios.ToList();
        }
    }
}
