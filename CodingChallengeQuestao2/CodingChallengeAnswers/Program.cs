using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Digite um número: ");
        string typedNumer = Console.ReadLine();
        int number = 0;
        try
        {
            number = int.Parse(typedNumer);
        }
        catch
        {
            Console.WriteLine($"Digite um número por favor.");
        }
        if (FibonacciValidator(number))
        {
            Console.WriteLine($"{number} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"{number} não pertence à sequência de Fibonacci.");
        }
    }
    public static bool FibonacciValidator(int numero)
    {
        int a = 0, b = 1;
        if (numero == 0 || numero == 1)
        {
            return true;
        }
        while (b < numero)
        {
            int temp = b;
            b = a + b;
            a = temp;
        }
        return b == numero;
    }
}