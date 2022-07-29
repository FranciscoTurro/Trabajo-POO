using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public partial class Perfil //partial significa que se pueden definir otras partes de la clase en el namespace. Para poder usar el this.Nombre (me parece???)
    {
        public override string ToString() //cada vez que se usa la funcion ToString con un Perfil se devuelve el nombre del perfil
        {
            return this.Nombre;
        }
    }

    public partial class Formulario 
    {
        public override string ToString() 
        {
            return this.Nombre;
        }
    }

}
