using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escreva qualquer palavra");
        string palavraDigitada = Console.ReadLine();
        string palavraInvertida = InverteAPalavra(palavraDigitada);
        Console.WriteLine($"Aqui está sua palavra invertida: {palavraInvertida}");
    }

    private static string InverteAPalavra(string? palavraDigitada)
    {
        char[] arrayDeCaracteres = palavraDigitada.ToCharArray();
        string palavraInvertida = string.Empty;

        for (int i = arrayDeCaracteres.Length - 1; i >= 0; i--)
        {
            palavraInvertida += arrayDeCaracteres[i];
        }

        return palavraInvertida;
    }
}
