namespace PruebasCSharp.CuadroMagicoImpar;
public class CuadradoMagico : ClassMatriz
{

    public static List<int> RellenarListaPatronNumeros(int numeroInicial, int diferenciaNumeros, int cantidadNumeros)
    {
        List<int> lstNumeros = [];
        lstNumeros.Add(numeroInicial);

        for (int n = 1; n < cantidadNumeros; n++)
        {
            numeroInicial += diferenciaNumeros;
            lstNumeros.Add(numeroInicial);
        }

        // Console.WriteLine("Numeros generados: " + string.Join(", ", lstNumeros));

        return lstNumeros;
    }

    public static int[,] SolucionCuadradoMagico(int filas_col, int numeroInicial, int diferenciaNumeros)
    {
        /*YA CREA LA MATRIZ NUEVA PARA ORGANIZAR LOS VALORES INICIALES EN CADA POSICION
        FALTARIA SIMPLEMENTE ES ORGANIZAR LOS NUMEROS QUE SE SALEN DE LA MATRIZ ORIGINAL*/
        List<int> lstNumerosMatriz = RellenarListaPatronNumeros(numeroInicial: numeroInicial, diferenciaNumeros: diferenciaNumeros, cantidadNumeros: filas_col*filas_col);

        Console.WriteLine("Numeros generados: " + string.Join(", ", lstNumerosMatriz) + "\n");

        //Vamos a generar una nueva matriz
        int lenNuevaMatriz = filas_col + (filas_col / 2) * 2;

        int iterableLstNumeros = 0, iterableFilas = 0, accesoColumnas = (lenNuevaMatriz / 2), iterableColumnas = lenNuevaMatriz;
        //accesoColumnas inicia siendo la parte central de la matriz
        //iterableColumnas inicia siendo la ultima columna de la matriz

        bool isAccesoColZero = false;

        int[,] matrizSolucion = new int[lenNuevaMatriz, lenNuevaMatriz];

        for (int f = 0; f < matrizSolucion.GetLength(0); f++)
        {
            iterableFilas = f;
            for (int c = accesoColumnas; c < iterableColumnas; c++)
            {
                if (iterableFilas != matrizSolucion.GetLength(0) - 1)
                {
                    if (c == iterableColumnas - 1)
                    {
                        iterableColumnas -= 1;
                        // Console.WriteLine("columnas = " + iterableColumnas);
                    }

                    // Console.WriteLine("Fila iteracion: " + iterableFilas + " Columna: " + c);
                    // Console.WriteLine(lstNumerosMatriz[iterableLstNumeros]);
                    matrizSolucion[iterableFilas, c] = lstNumerosMatriz[iterableLstNumeros];
                    iterableFilas++;
                    Console.WriteLine("Posicion iterable numeros: " + iterableLstNumeros);
                    iterableLstNumeros++;
                }
            }

            Console.WriteLine("\n");
            if(lstNumerosMatriz.Count -1 == iterableLstNumeros){
                matrizSolucion[matrizSolucion.GetLength(0)-1, lenNuevaMatriz / 2] = lstNumerosMatriz[lstNumerosMatriz.Count - 1];
                break;
            }

            if (accesoColumnas != 0 && !isAccesoColZero)
            {
                accesoColumnas--;
            }
            else if (accesoColumnas == 0 || isAccesoColZero)
            {
                Console.WriteLine("acceso columnas es 0");
                accesoColumnas++;
                isAccesoColZero = true;
            }

        }

        ImprimirMatriz(matrizSolucion);

        return matrizSolucion;
    }
}