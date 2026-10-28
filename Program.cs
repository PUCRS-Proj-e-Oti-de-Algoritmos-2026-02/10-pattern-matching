using System;

namespace PatternMatching;

public class Program
{
	public static void Main(string[] args)
    {
        string str1 = args.Length > 0 ? args[0] : throw new ArgumentException("deu ruim no primeiro argumento.");
        string str2 = args.Length > 1 ? args[1] : throw new ArgumentException("deu ruim no segundo argumento.");

        var pos = Exercicio1(str1, str2);

        Console.WriteLine($"str1: {str1}, str2: {str2}, Posição: {pos}");
    }

    private static int Exercicio1(string str1, string str2)
    {
                

        return -1;
    }
}
