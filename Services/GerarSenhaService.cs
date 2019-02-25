using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCommerce.Services
{
    public class GerarSenhaService
    {

        public static string SenhaHash()
        {            
            string caracteresPermitidos = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            char[] chars = new char[8];
            Random rd = new Random();
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = caracteresPermitidos[rd.Next(0, caracteresPermitidos.Length)];
            }
            string senha = new string(chars);
            return senha;
        }
    }
}
