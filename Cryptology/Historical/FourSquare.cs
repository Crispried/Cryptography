using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology.Historical
{
    public class FourSquare
    {
        private static char[,] leftTopSquare =
        {
            { 'K', 'I', 'N', 'G', 'D', '\'' },
            { 'O', 'M', 'A', 'B', 'C', '"' },
            { 'E', 'F', 'H', 'L', 'P', ' ' },
            { 'Q', 'R', 'S', 'T', 'U', '-' },
            { 'V', 'W', 'X', 'Y', 'Z', '!' },
            { 'J', ':', ';', '.', ',', '?' }
        };

        private static char[,] rightLowerSquare =
        {
            { 'D', 'C', 'P', 'U', 'Z', '"' },
            { 'G', 'B', 'L', 'T', 'Y', '\'' },
            { 'N', 'A', 'H', 'S', 'X', '-' },
            { 'I', 'M', 'F', 'R', 'W', '!' },
            { 'K', 'O', 'E', 'Q', 'V', 'J' },
            { ',', '.', '?', ' ', ':', ';' }
        };

        private static char[,] rightTopSquare =
        {
            { 'V', 'Q', 'E', 'O', 'K', 'J' },
            { 'W', 'R', 'F', 'M', 'I', '.' },
            { 'X', 'S', 'H', 'A', 'N', ',' },
            { 'Y', 'T', 'L', 'B', 'G', ';' },
            { 'Z', 'U', 'P', 'C', 'D', '?' },
            { ':', '!', '-', '"', '\'', ' '  }
        };

        private static char[,] leftLowerSquare =
        {
            { 'Z', 'Y', 'X', 'W', 'V', '?' },
            { 'U', 'T', 'S', 'R', 'Q', 'J' },
            { 'P', 'L', 'H', 'F', 'E', ';' },
            { 'C', 'B', 'A', 'M', 'O', ':' },
            { 'D', 'G', 'N', 'I', 'K', ',' },
            { '.', '"', '\'', '-', ' ', '!' }
        };

        // cr yp to gr ap hy
        public static string Encrypt(string message)
        {
            string encryptedMessage = string.Empty;
            var cleanMessage = ReplaceSpecialChars(message);
            cleanMessage = cleanMessage.ToUpper();
            var bigraphs = SplitOnBigraphs(cleanMessage);
            for (int i = 0; i < bigraphs.Count; i++)
            {
                if(bigraphs[i].Length == 2)
                {
                    encryptedMessage += EncryptBigraph(bigraphs[i][0], bigraphs[i][1]);
                }
                else
                {
                    encryptedMessage += bigraphs[i][0];
                }
            }
            return encryptedMessage;
        }

        public static string Decrypt(string message)
        {
            string decryptedMessage = string.Empty;
            var cleanMessage = ReplaceSpecialChars(message);
            cleanMessage = cleanMessage.ToUpper();
            var bigraphs = SplitOnBigraphs(cleanMessage);
            for (int i = 0; i < bigraphs.Count; i++)
            {
                if (bigraphs[i].Length == 2)
                {
                    decryptedMessage += DecryptBigraph(bigraphs[i][0], bigraphs[i][1]);
                }
                else
                {
                    decryptedMessage += bigraphs[i][0];
                }
            }
            return decryptedMessage;
        }

        private static List<string> SplitOnBigraphs(string message)
        {
            var bigraphs = new List<string>();
            for (int i = 0; i < message.Length; i += 2)
            {
                if(i < message.Length - 1)
                {
                    bigraphs.Add(message.Substring(i, 2));
                }
                else
                {
                    bigraphs.Add(message.Substring(i, 1));
                }
            }
            return bigraphs;
        }

        private static string EncryptBigraph(char firstLetter, char secondLetter)
        {
            int firstLetterHorizontalPosition = 0;
            int firstLetterVerticalPosition = 0;
            int secondLetterHorizontalPosition = 0;
            int secondLetterVerticalPosition = 0;
            for (int i = 0; i < leftTopSquare.GetLength(0); i++)
            {
                for (int j = 0; j < leftTopSquare.GetLength(1); j++)
                {
                    if (leftTopSquare[i, j] == firstLetter)
                    {
                        firstLetterHorizontalPosition = j;
                        firstLetterVerticalPosition = i;
                        goto exitLoop1;
                    }
                }
            }
            exitLoop1:
            for (int i = 0; i < rightLowerSquare.GetLength(0); i++)
            {
                for (int j = 0; j < rightLowerSquare.GetLength(1); j++)
                {
                    if(rightLowerSquare[i, j] == secondLetter)
                    {
                        secondLetterHorizontalPosition = j;
                        secondLetterVerticalPosition = i;
                        goto exitLoop2;
                    }
                }
            }
        exitLoop2:
            char firstLetterEncrypted = rightTopSquare[firstLetterVerticalPosition, secondLetterHorizontalPosition];
            char secondLetterEncrypted = leftLowerSquare[secondLetterVerticalPosition, firstLetterHorizontalPosition];
            return firstLetterEncrypted.ToString() + secondLetterEncrypted.ToString();

        }

        private static string DecryptBigraph(char firstLetter, char secondLetter)
        {
            int firstLetterHorizontalPosition = 0;
            int firstLetterVerticalPosition = 0;
            int secondLetterHorizontalPosition = 0;
            int secondLetterVerticalPosition = 0;
            for (int i = 0; i < rightTopSquare.GetLength(0); i++)
            {
                for (int j = 0; j < rightTopSquare.GetLength(1); j++)
                {
                    if (rightTopSquare[i, j] == firstLetter)
                    {
                        firstLetterHorizontalPosition = j;
                        firstLetterVerticalPosition = i;
                        goto exitLoop1;
                    }
                }
            }
        exitLoop1:
            for (int i = 0; i < leftLowerSquare.GetLength(0); i++)
            {
                for (int j = 0; j < leftLowerSquare.GetLength(1); j++)
                {
                    if (leftLowerSquare[i, j] == secondLetter)
                    {
                        secondLetterHorizontalPosition = j;
                        secondLetterVerticalPosition = i;
                        goto exitLoop2;
                    }
                }
            }
        exitLoop2:
            char firstLetterDecrypted = leftTopSquare[firstLetterVerticalPosition, secondLetterHorizontalPosition];
            char secondLetterDecrypted = rightLowerSquare[secondLetterVerticalPosition, firstLetterHorizontalPosition];
            return firstLetterDecrypted.ToString() + secondLetterDecrypted.ToString();

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
