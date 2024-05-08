#FUNCION PARA CREAR LA MATRIZ INGRESANDO DIRECTAMENTE TODA UNA FILA
def CrearSopaDeLetras(filas):
    matriz=[0]*filas

    for i in range(filas):
        cadena=SepararUnaFilaDeString(input(f"Ingrese la fila {(i+1)} completa sin excederse de los {filas} caracteres" +":\n").upper())
        while(len(cadena)>filas or len(cadena)<filas):                                
            if(len(cadena)>filas):
                print("\nLO INGRESADO SUPERA EL TAMAÑO DE LA FILA\n")

            if(len(cadena)<filas):
                print("\nLO INGRESADO ES MENOR AL TAMAÑO DE LA FILA\n")
                
            cadena=SepararUnaFilaDeString(input("Ingrese la fila completa sin "+
                                f"excederse de los {filas} caracteres" +":\n").upper())
        matriz[i]=cadena
    return matriz


#FUNCION PARA IMPRIMIR LA SOPA DE LETRAS
def ImprimirSopaDeLetras(MatrizSopaDeLetras):
    print()
    for i in range(len(MatrizSopaDeLetras)):
        for j in range(len(MatrizSopaDeLetras[0])):
            print(" "+MatrizSopaDeLetras[i][j],end="   ")
        print("\n")
        

#FUNCION PARA SEPARAR UNA CADENA Y CONVERTIRLA A UNA LISTA
def SepararUnaFilaDeString(cadena):
    ListaCadena=list(cadena)
    return ListaCadena
    
