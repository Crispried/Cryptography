using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology.Historical
{
    public static class Caesar
    {
        private const int CharOffset = 3;
        private const int UpperLetterMin = 65;
        private const int UpperLetterMax = 90;
        private const int LowerLetterMin = 97;
        private const int LowerLetterMax = 122;

        public static string Encrypt(string message)
        {
            string encryptedMessage = string.Empty;
            char tmp;
            foreach (char c in message)
            {
                tmp = c;
                if (!IsSpecial(c))
                {
                    if (char.IsUpper(c))
                    {
                        tmp = MakeEncryptOffsetForUpperLetter(c);
                    }
                    else
                    {
                        tmp = MakeEncryptOffsetForLowerLetter(c);
                    }
                }
                encryptedMessage += tmp;
            }
            return encryptedMessage;
        }

        public static string Decrypt(string message)
        {
            string encryptedMessage = string.Empty;
            char tmp;
            foreach (char c in message)
            {
                tmp = c;
                if (!IsSpecial(c))
                {
                    if (char.IsUpper(c))
                    {
                        tmp = MakeDecryptOffsetForUpperLetter(c);
                    }
                    else
                    {
                        tmp = MakeDecryptOffsetForLowerLetter(c);
                    }
                }
                encryptedMessage += tmp;
            }
            return encryptedMessage;
        }

        private static char MakeEncryptOffsetForUpperLetter(char letter)
        {
            if(letter + CharOffset > UpperLetterMax)
            {
                return (char)(UpperLetterMin + (letter + CharOffset - UpperLetterMax) - 1);
            }
            else
            {
                return (char)(letter + CharOffset);
            }
        }

        private static char MakeEncryptOffsetForLowerLetter(char letter)
        {
            if (letter + CharOffset > LowerLetterMax)
            {
                return (char)(LowerLetterMin + (letter + CharOffset - LowerLetterMax) - 1);
            }
            else
            {
                return (char)(letter + CharOffset);
            }
        }

        private static char MakeDecryptOffsetForUpperLetter(char letter)
        {
            if (letter - CharOffset < UpperLetterMin)
            {
                return (char)(UpperLetterMax - (UpperLetterMin - (letter - CharOffset)) + 1);
            }
            else
            {
                return (char)(letter - CharOffset);
            }
        }

        private static char MakeDecryptOffsetForLowerLetter(char letter)
        {
            if (letter - CharOffset < LowerLetterMin)
            {
                return (char)(LowerLetterMax - (LowerLetterMin - (letter - CharOffset)) + 1);
            }
            else
            {
                return (char)(letter - CharOffset);
            }
        }

        public static bool IsSpecial(char c)
        {
            char[] splitChars = { ' ', ',', '\'', '"', '.', ':', ';', '?', '!', '-', '\n', '\r', '\t', '\v' };
            return splitChars.Contains(c);
        }
    }
}
