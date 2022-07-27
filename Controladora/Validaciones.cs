using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography;


namespace Controladora
{
    public class Validaciones
    {

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public static bool NombreUnicoUser(string name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                Modelo.Usuario x = Usuario.obtenerInstancia().ListaUsuarios().Find(usuario => usuario.Nombre == name);
                if (x != null)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        public static bool NombreUnicoProd(string name)
        {
            if (String.IsNullOrEmpty(name) == false)
            {
                Modelo.Producto x = Producto.obtenerInstancia().ListaProductos().Find(producto => producto.Nombre == name);
                if (x != null)
                    return false;
                else
                    return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckEmail(string emailAdd)
        {
            string email = emailAdd;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        public static bool LongitudDNI(int number)
        {
            if (number != 8)
                return false;
            else
                return true;
        }
    }
}
