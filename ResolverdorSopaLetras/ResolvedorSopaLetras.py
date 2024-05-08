from ast import Eq
import FunFuncionamiento as Sopa

contador=0

#FUNCION ENCARGADA DE ENCONTRAR LAS PALABRAS QUE SE LE ENCOMIENDEN (POR FILAS)
def EncontrarPalabra(matrizSL, palabras):
    global contador

    LetrasEncontradas=[] 
    posicionesLetras=[]
    isEncontrada=False
    cnaSeparada=Sopa.SepararUnaFilaDeString(palabras)
    cnaInversa=Sopa.SepararUnaFilaDeString(palabras[::-1])#Para invertir la cadena

    for f in range(len(matrizSL)):
        
        for c in range(len(matrizSL[0])):
            print(contador)
            if(matrizSL[f][c]==cnaSeparada[contador]):
                '''Preguntamos si la matriz en la fila y columna que esta, es igual a la cadena a buscar
                    en la posicion del contador'''
                LetrasEncontradas.append(matrizSL[f][c])#Agg las letras halladas a la lista
                posicionesLetras.append([f,c])#Agg la posicion en la que se encontró
                contador+=1#Sumamos 1 posicion al contador

                # print(f"Entre a la linea 25 {contador} ")
                if(c<(len(matrizSL[0])-1)):
                    if(matrizSL[f][c+1]==cnaSeparada[0] and contador==1):
                        '''Preguntamos si la siguiente letra es la misma a la primera posicion, además 
                            el contador debe ser igual a 1, para saber si ha encontrado ya la primera letra
                            de la cadena. Si es cierto procede a limpiar lo que habia antes y lo agregará en
                            la siguiente iteración, puesto que se empezara a buscar desde la primera letra nuevamente'''
                        LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)

            # elif(matrizSL[f][c]==cnaInversa[contador]):
            #     #Sigue pendiente aun no se como integrarlo bien
            #     LetrasEncontradas.append(matrizSL[f][c])
            #     posicionesLetras.append([f,c])
            #     contador+=1

            #     if(c<(len(matrizSL[0])-1)):

            #         if(matrizSL[f][c+1]==cnaInversa[0] and contador==1):
            #             LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)
            
            else:
                LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)
            

            if(contador==len(cnaSeparada)):
                print("El contador es igual a la cadena separada")
                isEncontrada=True
                break
        if(isEncontrada==True):
            contador=0
            break
        else:
            LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)

        if(len(matrizSL)-1==f):
            #Es decir, ya recorrio todas las filas
            contador=0
            BuscarPorColumna(matrizSL,palabras)
            break
    
    ImprimirSopaDeLetrasResuelta(matrizSL,posicionesLetras)


#FUNCION PARA ENCONTRAR LA(S) PALABRA(S) QUE SE LE ENCOMIENDEN (POR COLUMNAS)
def BuscarPorColumna(matrizSL, cadena):
    print("BUSQUEDA POR COLUMNAS")
    global contador
    cdnaSeparada=Sopa.SepararUnaFilaDeString(cadena)
    cdnaInversa=Sopa.SepararUnaFilaDeString(cadena[::-1])#Para obtener la cadena invertida
    LetrasEncontradas=[]
    posicionesLetras=[]
    isEncontrada=False

    # print(f"\n\n Cadena Invertida por columnas {cdnaInversa}")

    for f in range(len(matrizSL)):
        for c in range(len(matrizSL[0])):
            
            if(matrizSL[c][f]==cdnaSeparada[contador]):
                
                LetrasEncontradas.append(matrizSL[c][f])
                posicionesLetras.append([c,f])
                contador+=1
                
                if(f<len(matrizSL)-1):
                    #Necesitamos saber si no está en la ultima fila para poder sumarle uno a f que es la fila
                    if(matrizSL[c][f+1]==cdnaSeparada[0] and contador==1):
                        print("Entre")
                        #Esta es la 
                        LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)
                        # print()

            # elif(matrizSL[c][f]==cdnaInversa[contador]):
            #     LetrasEncontradas.append(matrizSL[c][f])
            #     posicionesLetras.append([c,f])
            #     contador+=1

            #     if(f<len(matrizSL)-1):
            #         #Preguntamos si f es menor a a la Matriz ya que, si es igual y le sumamos uno, el sistema se rompe
            #         # print("Aun puede entrar, f no es menor que la matriz")
            #         # print(f"Esta es la matriz una fila mas abajo {matrizSL[c][f+1]} ")
            #         if(matrizSL[c][f+1]==cdnaInversa[0] and contador==1):
            #             LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)

            else:
                LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)

            if(len(LetrasEncontradas)==len(cdnaSeparada)):
                contador=0
                isEncontrada=True
                print("Ya se encontro por columnas")
                break
        if(isEncontrada):
            ImprimirSopaDeLetrasResuelta(matrizSL,posicionesLetras)
            break
        else:
            LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)
        if(f==len(matrizSL)-1):
            contador=0
            BuscarPorDiagonal(matrizSL,cadena)
            break

    # ImprimirSopaDeLetrasResuelta(matrizSL,posicionesLetras)
        
def BuscarPorDiagonal(matrizSL,cadena):
    print("BUSQUEDA POR DIAGONAL")
    global contador
    print(f"Por diagonal el contador es: {contador} ")
    cnaSeparada=Sopa.SepararUnaFilaDeString(cadena)
    LetrasEncontradas=[]
    posicionesLetras=[]
    isEncontrada=False
    entradaConcedida=False
    c=0
    for f in range(len(matrizSL)):
        # print(cnaSeparada[contador])
        print(contador)
        if(matrizSL[f][c]==cnaSeparada[contador] or entradaConcedida==True):
            
            if(entradaConcedida==False):
                LetrasEncontradas.append(matrizSL[f][c])
                posicionesLetras.append([f,c])
                contador+=1
            try:
                if(matrizSL[f+1][c+1]==cnaSeparada[contador]):
                    LetrasEncontradas.append(matrizSL[f][c])
                    posicionesLetras.append([f,c])
                    contador+=1
                    entradaConcedida=True
            except:
                None
                
        else:
            LimpiarListaDePalabrasYContador(LetrasEncontradas,posicionesLetras)
        if(len(cnaSeparada)==contador):
            print("Encontrada por diagonal")
            break
        c+=1

    ImprimirSopaDeLetrasResuelta(matrizSL,posicionesLetras)


#FUNCION PARA IMPRIMIR LA SOPA DE LETRAS YA RESUELTA
def ImprimirSopaDeLetrasResuelta(matrizSL,posicionesLetras):
    '''La lista de posicionesPalabras, nos servira para ubicar en qué posiciones están las 
    letras encontradas'''
    posi=0
    posj=0
    for i in range(len(posicionesLetras)):
            for j in range(len(posicionesLetras[0])):
                try:
                    posi=posicionesLetras[i][j]
                    posj=posicionesLetras[i][j+1]
                    matrizSL[posi][posj]="*"
                    #print("posicion i con j= "+str(posi))
                    # print()
                except:
                    break
    print("-----------------------------------------")
    Sopa.ImprimirSopaDeLetras(matrizSL)


#FUNCION PARA PEDIR LAS PALABRAS Y LUEGO MANDARLAS A BUSCAR
def pedirPalabras(canCaracteres):
    palabras=list()
    while(True):
        print("\nPara cancelar escriba 'SALIR'\n")
        palabra=input(f"Digite la palabra a buscar sin excederse de los {canCaracteres} caracteres:\n ").upper()
        
        if(palabra!="SALIR"):
            if(len(palabra)<=canCaracteres):
                palabras.append(palabra)
            else:
                print("\n--¡ALERTA!--\n"+
                    "La palabra excede las dimensiones de la Sopa de Letras\n")
                continue
        else:
            break   
    print("\n\n")
    return palabras
        
def LimpiarListaDePalabrasYContador(LetrasEncontradas, PosicionesLetras ):
    global contador
    LetrasEncontradas.clear()
    PosicionesLetras.clear()
    contador=0