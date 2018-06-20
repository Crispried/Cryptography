using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology.Historical
{
    public static class PolybiusSquare
    {
        private static char[,] alfphabet =
        {
            { 'A', 'B', 'C', 'D', 'E', 'F' },
            { 'G', 'H', 'I', 'J', 'K', 'L' },
            { 'M', 'N', 'O', 'P', 'Q', 'R' },
            { 'S', 'T', 'U', 'V', 'W', 'X' },
            { 'Y', 'Z', ' ', ',', '.', ':' },
            { ';', '?', '!', '-', '"', '\'' }
        };
        public static string Encrypt(string message)
        {
            var cleanMessage = ReplaceSpecialChars(message);
            string encryptedMessage = string.Empty;
            string tmp;
            foreach (char c in cleanMessage)
            {
                tmp = EncryptChar(c);
                encryptedMessage += tmp;
            }
            return encryptedMessage;
        }

        public static string Decrypt(string message)
        {
            string decryptedMessage = string.Empty;
            string tmp;
            for (int i = 0; i < message.Length; i += 2)
            {
                tmp = message.Substring(i, 2);
                tmp = DecryptChar(tmp);
                decryptedMessage += tmp;
            }
            return decryptedMessage;
        }

        private static string EncryptChar(char c)
        {
            char upperChar = char.ToUpper(c);
            string position = string.Empty;
            for (int i = 0; i < alfphabet.GetLength(0); i++)
            {
                for (int j = 0; j < alfphabet.GetLength(1); j++)
                {
                    if(alfphabet[i,j] == upperChar)
                    {
                        position = string.Concat(i.ToString(), j.ToString());
                        goto Exit;
                    }
                }
            }
            Exit:
            return position;
        }

        private static string DecryptChar(string position)
        {
            int positionI = Convert.ToInt32(position[0].ToString());
            int positionJ = Convert.ToInt32(position[1].ToString());
            return alfphabet[positionI, positionJ].ToString();
        }

        private static string ReplaceSpecialChars(string message)
        {
            return message.Replace("\n", "")
                          .Replace("\r", "")
                          .Replace("\t", "")
                          .Replace("\v", "");                           
        }
    }
}
