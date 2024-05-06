namespace PruebasCSharp.CuadroMagicoImpar;
using System;

class ClassMain
{
    static void Main(string[] args)
    {

        // int[,] matrizprueba = ClassMatriz.GenerarMatrizCuadrada(3);
        // ClassMatriz.ImprimirMatriz(matrizprueba);
        // ClassMatriz.SumaDiagonales(matrizprueba);
        // Console.WriteLine("\n");
        // ClassMatriz.SumaFilasYColumnas(matrizprueba);
        // Console.WriteLine("\n\n");

        // ClassMatriz.ImprimirMatriz(cuadroMagico);
        int filas_col = 5, numeroInicial = 2, diferenciaNumeros = 2;
        CuadradoMagico.SolucionCuadradoMagico(filas_col, numeroInicial, diferenciaNumeros);

        Console.WriteLine("\n\n");
    }
}
