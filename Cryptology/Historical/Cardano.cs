using System;
using System.Collections.Generic;

namespace Cryptology.Historical
{
    public class Cardano
    {
        private static int _sideLength;
        private static List<Point> _mask;

        public static string Encrypt(string message)
        {
            string encryptedMessage = string.Empty;
            var cleanMessage = ReplaceSpecialChars(message);
            cleanMessage = cleanMessage.ToUpper();
            _sideLength = DetermineMinimalSideLength(cleanMessage);
            GenerateRandomMask(defaultSideLength);


        }

        public static string Decrypt(string message)
        {
            return "";
        }

        private static int DetermineMinimalSideLength(string message)
        {
            return (int)Math.Sqrt(message.Length) + 1;
        }

        private static char[,] GetEncryptedTable(string message)
        {
            char[,] encryptedTable = new char[_sideLength, _sideLength];
            int maskIndex = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (maskIndex != message.Length)
                {
                    encryptedTable.SetValue(message[i], _mask[maskIndex].X, _mask[maskIndex].Y);
                    maskIndex++;
                }
                else
                {
                    maskIndex = 0;
                    TurnTable()
                }
            }
        }

        private static void GenerateRandomMask(int sideLength)
        {
            Random r = new Random();
            for (int i = 0; i < sideLength; i++)
            {
                _mask.Add(new Point() {
                    X = r.Next(0, sideLength - 1),
                    Y = r.Next(0, sideLength - 1)
                });
            }
        }

        private static string ReplaceSpecialChars(string message)
        {
            return message.Replace("\n", "")
                          .Replace("\r", "")
                          .Replace("\t", "")
                          .Replace("\v", "");
        }

        private class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}