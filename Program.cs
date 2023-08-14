using System;
using System.Collections.Generic;
using System.Text;

namespace ClaveGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generador de Claves en escritura leet");
            Console.WriteLine("-------------------------------------");

            Console.Write("Ingrese un texto o frase: ");
            string inputText = Console.ReadLine();

            int desiredLength = inputText.Length;
            string clave = GenerateClave(inputText, desiredLength);

            Console.WriteLine("\nClave generada en escritura leet: " + clave);

            Console.WriteLine("\nPresione cualquier tecla para salir.");
            Console.ReadKey();
        }

        static string GenerateClave(string inputText, int desiredLength)
        {
            Dictionary<char, char> leetMap = new()
            {
                {'A', '4'},
                {'B', '8'},
                {'C', 'C'},
                {'D', 'D'},
                {'E', '3'},
                {'F', 'F'},
                {'G', '6'},
                {'H', 'H'},
                {'I', '1'},
                {'J', 'J'},
                {'K', 'K'},
                {'L', 'L'},
                {'M', 'M'},
                {'N', 'N'},
                {'O', '0'},
                {'P', 'P'},
                {'Q', 'Q'},
                {'R', 'R'},
                {'S', '$'},
                {'T', '7'},
                {'U', 'U'},
                {'V', 'V'},
                {'W', 'W'},
                {'X', 'X'},
                {'Y', 'Y'},
                {'Z', 'Z'}
            };

            StringBuilder sb = new StringBuilder();

            Random random = new Random();

            // Convertir el texto de entrada a escritura "leet" (solo vocales)
            foreach (char c in inputText)
            {
                char leetChar = char.ToUpper(c);
                if (leetMap.ContainsKey(leetChar))
                {
                    sb.Append(leetMap[leetChar]);
                }
                else
                {
                    sb.Append(c);
                }
            }

            // Completar el texto de salida con caracteres aleatorios si es necesario
            while (sb.Length < desiredLength)
            {
                switch (random.Next(3))
                {
                    case 0:
                        sb.Append(leetMap[leetMap.Keys.ElementAt(random.Next(leetMap.Count))]);
                        break;
                    case 1:
                        sb.Append(random.Next(10));
                        break;
                    case 2:
                        sb.Append("!@#$%^&*()_+-=[]{}|;:'\",.<>?/");
                        break;
                }
            }

            // Asegurarnos de que la longitud sea la deseada
            if (sb.Length > desiredLength)
            {
                sb.Length = desiredLength;
            }

            return sb.ToString();
        }
    }
}
