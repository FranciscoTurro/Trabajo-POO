using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class Perfiles
    {
        private static Perfiles instancia;

        private Perfiles() { }

        public static Perfiles obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new Perfiles();
            }
            return instancia;
        }

        public List<Modelo.Perfil> ListarPerfiles()
        {
            return Modelo.SingletonContexto.obtenerInstancia().Contexto.Perfiles.ToList();
        }

        public void LlenarLista(List<Modelo.Perfil> perfiles)
        {
            Modelo.SingletonContexto.obtenerInstancia().Contexto.Perfiles.AddRange(perfiles); //addrange agrega una coleccion de elementos (en este caso la lista de perfiles)
            Modelo.SingletonContexto.obtenerInstancia().Contexto.SaveChanges();
        }
    }
}
