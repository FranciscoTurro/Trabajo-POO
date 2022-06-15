using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class SingletonContexto 
    {
        private static SingletonContexto instancia;
        private static ContextoContainer contexto;

        private SingletonContexto() { } //Instancio un objeto de la clase, ese objeto puede acceder a la base de datos (contexto)

        public static SingletonContexto obtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new SingletonContexto();
                contexto = new ContextoContainer();
            }
            return instancia;
        }
        public ContextoContainer Contexto
        {
            get { return contexto; }
        }
    }
}
