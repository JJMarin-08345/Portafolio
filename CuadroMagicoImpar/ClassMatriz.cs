namespace PruebasCSharp.CuadroMagicoImpar;
public class ClassMatriz
{
    public static List<int> RellenarListaNumerosUnicos(int cantidadNumeros)
    {
        List<int> numeros = [];
        Random rdn = new();

        for (int n = 0; n < cantidadNumeros; n++)
        {
            int numero = rdn.Next(1, 20);

            if (numeros.Contains(numero))
            {
                n--;
                continue;
            }

            numeros.Add(numero);
        }

        Console.WriteLine("Numeros generados: " + string.Join(", ", numeros));
        return numeros;
    }

    public static int[,] GenerarMatrizCuadrada(int filas_col)
    {
        int[,] matriz = new int[filas_col, filas_col];

        List<int> numerosRandom = RellenarListaNumerosUnicos(filas_col * filas_col);

        int indexLstNumRandom = 0;

        for (int f = 0; f < filas_col; f++)
        {
            for (int c = 0; c < filas_col; c++)
            {
                    matriz[f, c] = numerosRandom[indexLstNumRandom];
                indexLstNumRandom++;
            }

        }
        return matriz;
    }

    public static int[,] GenerarMatrizCuadrada(int filas_col, List<int> numeros)
    {
        int[,] matriz = new int[filas_col, filas_col];

        int indexLstNumRandom = 0;

        for (int f = 0; f < filas_col; f++)
        {
            for (int c = 0; c < filas_col; c++)
            {
                matriz[f, c] =  numeros[indexLstNumRandom];
                indexLstNumRandom++;
            }

        }
        return matriz;
    }

    public static void ImprimirMatriz(int[,] matriz)
    {
        Console.WriteLine("\n\n");
        for (int f = 0; f < matriz.GetLength(0); f++)
        {
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                Console.Write("|");
                Console.Write(" " + matriz[f, c] + " ");
            }
            Console.Write("|");
            Console.WriteLine("\n");
        }
    }

    public static int[,] SumaFilasYColumnas(int[,] matriz)
    {
        int[,] suma = new int[2, 3];

        for (int f = 0; f < matriz.GetLength(0); f++)
        {
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                suma[0, f] += matriz[f, c];
                suma[1, f] += matriz[c, f];
            }
        }
        Console.WriteLine("Suma de las filas: ".ToUpper() + "\nFila 1: " + suma[0, 0] + "\nFila 2: " + suma[0, 1] + "\nFila 3: " + suma[0, 2]);
        Console.WriteLine("\nSuma de las columnas: ".ToUpper() + "\nColumna 1: " + suma[1, 0] + "\nColumna 2: " + suma[1, 1] + "\nColumna 3: " + suma[1, 2]);
        return suma;
    }

    public static int[] SumaDiagonales(int[,] matriz)
    {
        int[] suma = new int[2];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            suma[0] += matriz[i, i];
            suma[1] += matriz[i, matriz.GetLength(0) - (i + 1)];
        }
        Console.WriteLine("Suma de la diagonal principal: ".ToUpper() + suma[0]);
        Console.WriteLine("Suma de la diagonal secundaria: ".ToUpper() + suma[1]);
        return suma;
    }

    protected static List<int> ObtenerNumerosDeLaMatrizYOrdenarlos(int[,] matriz)
    {
        List<int> numeros = [];

        for (int f = 0; f < matriz.GetLength(0); f++)
        {
            for (int c = 0; c < matriz.GetLength(1); c++)
            {
                numeros.Add(matriz[f, c]);
            }
        }
        numeros.Sort();
        Console.WriteLine("Numeros de la matriz ordenados: " + string.Join(", ", numeros));
        return numeros;
    }
}