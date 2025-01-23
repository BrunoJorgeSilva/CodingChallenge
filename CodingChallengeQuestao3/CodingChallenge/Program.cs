using CodingChallenge;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        
        string json = Json();
        string xml = Xml();

        List<DiaValor> jsonDiaValor = JsonToList(json);
        List<DiaValor> xmlDiaValor = XmlToList(xml);
        MenorValorComFaturamento(jsonDiaValor, true);
        MenorValorComFaturamento(xmlDiaValor, false);
    }

    private static void MenorValorComFaturamento(List<DiaValor> jsonDiaValor, bool isJson)
    {
        string resultado = isJson ? "Com base no Json enviado:" : "De acordo com o XML enviado:";
        double menorValor = jsonDiaValor.Where(x => x.Valor != 0).FirstOrDefault().Valor;
        int dia = 0;

        foreach (var item in jsonDiaValor)
        {
            if (item.Valor < menorValor && item.Valor != 0)
            {
                menorValor = item.Valor;
                dia = item.Dia;
            }
        }
        Console.WriteLine($"{resultado} O menor valor com faturamento acima de 0 é: {dia} com faturamento de: {menorValor}"); 
    }

    public static List<DiaValor> JsonToList(string json)
    {
        List<DiaValor> list = JsonConvert.DeserializeObject<List<DiaValor>>(json) ?? new List<DiaValor>();
        return list;
    }

    public static List<DiaValor> XmlToList(string xml)
    {
        var cultureInfo = new CultureInfo("en-US");
        string wrappedXml = $"<root>{xml}</root>";
        XDocument xDoc = XDocument.Parse(wrappedXml);
        return xDoc
            .Descendants("row")
            .Select(row => new DiaValor
            {
                Dia = int.Parse(row.Element("dia")?.Value ?? "0"),
                Valor = double.Parse(row.Element("valor")?.Value ?? "0.0", cultureInfo)
            })
            .ToList();
    }

    public static string Json()
    {
        return @"[
                {""dia"": 1, ""valor"": 22174.1664},
                {""dia"": 2, ""valor"": 24537.6698},
                {""dia"": 3, ""valor"": 26139.6134},
                {""dia"": 4, ""valor"": 0.0},
                {""dia"": 5, ""valor"": 0.0},
                {""dia"": 6, ""valor"": 26742.6612},
                {""dia"": 7, ""valor"": 0.0},
                {""dia"": 8, ""valor"": 42889.2258},
                {""dia"": 9, ""valor"": 46251.174},
                {""dia"": 10, ""valor"": 11191.4722},
                {""dia"": 11, ""valor"": 0.0},
                {""dia"": 12, ""valor"": 0.0},
                {""dia"": 13, ""valor"": 3847.4823},
                {""dia"": 14, ""valor"": 373.7838},
                {""dia"": 15, ""valor"": 2659.7563},
                {""dia"": 16, ""valor"": 48924.2448},
                {""dia"": 17, ""valor"": 18419.2614},
                {""dia"": 18, ""valor"": 0.0},
                {""dia"": 19, ""valor"": 0.0},
                {""dia"": 20, ""valor"": 35240.1826},
                {""dia"": 21, ""valor"": 43829.1667},
                {""dia"": 22, ""valor"": 18235.6852},
                {""dia"": 23, ""valor"": 4355.0662},
                {""dia"": 24, ""valor"": 13327.1025},
                {""dia"": 25, ""valor"": 0.0},
                {""dia"": 26, ""valor"": 0.0},
                {""dia"": 27, ""valor"": 25681.8318},
                {""dia"": 28, ""valor"": 1718.1221},
                {""dia"": 29, ""valor"": 13220.495},
                {""dia"": 30, ""valor"": 8414.61}
            ]";
    }

    public static string Xml()
    {
        return @"
         <row>
          <dia>1</dia>
          <valor>31490.7866</valor>
        </row>
        <row>
          <dia>2</dia>
          <valor>37277.9400</valor>
        </row>
        <row>
          <dia>3</dia>
          <valor>37708.4303</valor>
        </row>
        <row>
          <dia>4</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>5</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>6</dia>
          <valor>17934.2269</valor>
        </row>
        <row>
          <dia>7</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>8</dia>
          <valor>6965.1262</valor>
        </row>
        <row>
          <dia>9</dia>
          <valor>24390.9374</valor>
        </row>
        <row>
          <dia>10</dia>
          <valor>14279.6481</valor>
        </row>
        <row>
          <dia>11</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>12</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>13</dia>
          <valor>39807.6622</valor>
        </row>
        <row>
          <dia>14</dia>
          <valor>27261.6304</valor>
        </row>
        <row>
          <dia>15</dia>
          <valor>39775.6434</valor>
        </row>
        <row>
          <dia>16</dia>
          <valor>29797.6232</valor>
        </row>
        <row>
          <dia>17</dia>
          <valor>17216.5017</valor>
        </row>
        <row>
          <dia>18</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>19</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>20</dia>
          <valor>12974.2000</valor>
        </row>
        <row>
          <dia>21</dia>
          <valor>28490.9861</valor>
        </row>
        <row>
          <dia>22</dia>
          <valor>8748.0937</valor>
        </row>
        <row>
          <dia>23</dia>
          <valor>8889.0023</valor>
        </row>
        <row>
          <dia>24</dia>
          <valor>17767.5583</valor>
        </row>
        <row>
          <dia>25</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>26</dia>
          <valor>0.0000</valor>
        </row>
        <row>
          <dia>27</dia>
          <valor>3071.3283</valor>
        </row>
        <row>
          <dia>28</dia>
          <valor>48275.2994</valor>
        </row>
        <row>
          <dia>29</dia>
          <valor>10299.6761</valor>
        </row>
        <row>
          <dia>30</dia>
          <valor>39874.1073</valor>
        </row>";
    }
}
