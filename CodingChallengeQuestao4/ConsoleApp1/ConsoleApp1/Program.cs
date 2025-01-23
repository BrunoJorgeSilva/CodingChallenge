using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };
        double totalFaturamento = faturamentoPorEstado.Values.Sum();

        Console.WriteLine("Percentual de Representação por Estado:");
        foreach (var estado in faturamentoPorEstado)
        {
            ExibirPercentual(estado.Key, estado.Value, totalFaturamento);
        }

        static void ExibirPercentual(string estado, double faturamento, double totalFaturamento)
        {
            double percentual = (faturamento / totalFaturamento) * 100;
            Console.WriteLine($"{estado}: {percentual:F2}%");
        }
    }
}
