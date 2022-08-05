using System.Security.Cryptography;
using System.Text;

namespace ProjetoEntrevista.helper
{
    public static class Criptografia //static o mesmo que dizer, não precisa ser instânciada para ser usada
    {
        public static string GerarHash(this string text)  //this define o método GerarHash se torne um método evocado a partir de agora do atributo nativo 'string'
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(text);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach(var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}
