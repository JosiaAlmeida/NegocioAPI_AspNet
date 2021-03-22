using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestApiNegocio
{
    public class Criptografia
    {
        public string ComputerHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashByte = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashByte);
        }
    }
}
