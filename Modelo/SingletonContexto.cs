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

        private SingletonContexto() { }

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
