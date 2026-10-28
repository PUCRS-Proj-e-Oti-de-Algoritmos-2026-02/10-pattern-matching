using System;
using System.Diagnostics;



namespace PatternMatching;

public class Program
{
    public static long R = 256;
    public static long Q = 2147483647L;

    public static void Main(string[] args)
    {
        string str1 = args.Length > 0 ? args[0] : throw new ArgumentException("deu ruim no primeiro argumento.");
        string str2 = args.Length > 1 ? args[1] : throw new ArgumentException("deu ruim no segundo argumento.");

        var pos = Exercicio1(str1, str2, out long iteracoes);

        Console.WriteLine($"str1: {str1}, str2: {str2}, Posição: {pos}, Iterações: {iteracoes}");

        string texto = new string('a', 599999) + "b";
        string padrao = new string('a', 999) + "b";

        Stopwatch tempo = Stopwatch.StartNew();

        int resultado = Search(padrao, texto, out iteracoes);

        tempo.Stop();

        Console.WriteLine("Rabin-Karp com Horner:");
        Console.WriteLine($"Posição encontrada: {resultado}");
        Console.WriteLine($"Tempo: {tempo.Elapsed.TotalSeconds} ms | Iterações: {iteracoes}");

        // tempo.Restart();

        // resultado = RabinKarpRollingHash(padrao, texto);

        // tempo.Stop();

        // Console.WriteLine("\nRabin-Karp com Rolling Hash:");
        // Console.WriteLine($"Posição encontrada: {resultado}");
        // Console.WriteLine($"Tempo: {tempo.ElapsedMilliseconds} ms");
    }

    /// <summary>
    ///   Faça um algortimo que resolva o problema acima.
    ///   teste-o para strings de diversos tamanhos, até strings grandes (ambas as strings >500.000 caracteres). Conte o número de iterações e de instruções.
    ///   qual a complexidade, no pior caso?
    /// </summary>
    /// <param name="str1">parametro a ser iterado</param>
    /// <param name="str2">substring a ser encontrada no str1</param>
    /// <param name="iteracoes">número de comparações de caracteres realizadas</param>
    /// <returns>posição do inicio da primeira ocorrência, caso não haja retorna -1</returns>
    private static int Exercicio1(string str1, string str2, out long iteracoes)
    {
        iteracoes = 0;
        int posição = -1;

        for (int i = 0; i < str1.Length; i++)
        {
            bool achou = true;

            for (int j = 0; j < str2.Length; j++)
            {
                iteracoes++; // conta cada comparação de caractere
                if (i + j >= str1.Length || str1[i + j] != str2[j])
                {
                    achou = false;
                    break;
                }
            }

            if (achou)
            {
                posição = i;
                break;
            }
        }

        return posição;
    }

    private static int Exercicio2(string str1, string str2)
    {
        return -1;
    }

    private static int Search(string pat, string txt, out long iteracoes)
    {
        iteracoes = 0;
        int M = pat.Length;
        int N = txt.Length;
        long patHash = Hash(pat, M);

        for (int i = 0; i <= N - M; i++)
        {
            iteracoes++; // conta cada posição testada no texto
            long txtHash = Hash(txt.Substring(i, M), M);
            if (patHash == txtHash)
                return i; // ocorrência? colisão?
        }
        return N; // nenhuma ocorrência
    }

    private static long Hash(string s, int M)
    {
        long h = 0;
        for (int j = 0; j < M; j++)
            h = (h * R + s[j]) % Q;
        return h;
    }
}