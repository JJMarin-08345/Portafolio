# import replit

def menu():
    opcion = ""
    print("BIENVENIDO AL SISTEMA GENERAL DE CONVERSIONES PARTE 2")
    print()
    print("*** MENU DE OPCIONES ***\n")
    print()
    print("A- Convertir número hexadecimal a decimal")
    print()
    print("B- Convertir número romano a decimal")
    print()
    print("C- Convertir número decimal a romano")
    print()
    print("D- Tabla de conversión de hexadecimal a decimal")
    print()
    print("E- Tabla de conversión de hexadecimal a binario")
    print()
    print("F- Tabla de conversion de romano a decimal")
    print()
    print("G- Tabla de multiplicar del sistema octal")
    print()
    print("H- Tabla de multiplicar para número que desee")
    print()
    print("I- Tablas de multiplicar")
    print()
    print("J- Salir")
    print()
    opcion = input("Escriba la letra la cual se relacione a su opcion: \n")
    opcion = opcion.upper()
    if opcion == "A" or opcion == "1":
        # replit.clear()
        print("*** HEXADECIMAL A DECIMAL ***")
        print()
        hexadecimal_decimal()
        print()

    elif opcion == "B" or opcion == "2":
        # replit.clear()
        print("*** ROMANO A DECIMAL ***")
        print()
        roman_deci()
        print("")

    elif opcion == "C" or opcion == "3":
        # replit.clear()
        print("*** DECIMAL A ROMANO ***")
        print()
        decimal_romano()
        print("")

    elif opcion == "D" or opcion == "4":
        # replit.clear()
        print("*** TABLA CONVERSIÓN HEXADECIMAL A DECIMAL ***")
        print()
        tablaHexa()
        print("")

    elif opcion == "E" or opcion == "5":
        # replit.clear()
        print("*** TABLA CONVERSIÓN HEXADECIMAL A BINARIO ***")
        print()
        tablaHexaBin()
        print("")

    elif opcion == "F" or opcion == "6":
        # replit.clear()
        print("*** TABLA DE CONVERSIÓN ROMANO A DECIMAL ***")
        tablaRomano()
        print("")

    elif opcion == "G" or opcion == "7":
        # replit.clear()
        print("*** TABLAS MULTIPLICAR SISTEMA OCTAL ***\n")
        tablamulOctal()
        print()

    elif opcion == "H" or opcion == "8":
        # replit.clear()
        print("*** TABLA DE MULTIPLICAR ***")
        print()
        t_multi()
        print()

    elif opcion == "I" or opcion == "9":
        # replit.clear()
        print()
        print("*** TABLAS DE MULTIPLICAR DEL 1 AL 10  ***")
        tablas1_10()
        print()

    elif opcion == "J" or opcion == "10":
        # replit.clear()
        print()
        print("HASTA LA PRÓXIMA CAMARADA, VUELVE PRONTO")

    else:
        # replit.clear()
        print(
            "Sólo puedes escoger entre la A y la G o su respectiva numeración")
        print("")
        print("-Por favor escoga alguna de las opciones-")
        print("")
        reset()


'''LAS FUNCIONES PARA EL MENÚ'''


#HEXADECIMAL A DECIMAL
def hexadecimal_decimal():
    hexa = set("0123456789ABCDEF")
    dec_error = False
    while dec_error != True:
        dec_error = True
        n_hexa = input("Hexadecimal a convertir en decimal: \n").upper()
        hexagdo = n_hexa
        n_hexa = list(n_hexa)
        for a in n_hexa:
            if a not in hexa:
                dec_error = False
                print()
                print(
                    "Error, se ha detectado una letra no correspondiente al formato hexadecimal"
                )
                print()
                print(
                    "Si no sabe cuales son las letras del formato hexadecimal puede verla en la opción D"
                )
                print()
                reset()
                break
    reemplaceandop(n_hexa)
    rdohexa = 0
    n_hexa = n_hexa[::-1]
    for residuo in range(len(n_hexa)):
        rdohexa += (pow(16, residuo) * int(n_hexa[residuo]))
    print("")
    print("El hexadecimal ", hexagdo, "en decimal es:")
    print(rdohexa)
    reset()

#FUNCIÓN PARA PASAR DE ROMANO A DECIMAL
def roman_deci():
    #romano = input("Número romano a convertir: ").upper()
    error_rom()
    Rom = (' ', 'I', 'V', 'X', 'L', 'C', 'D', 'M')
    valor = (0, 1, 5, 10, 50, 100, 500, 1000)
    suma = 0
    ant = 0
    letra = ''
    for i in range(len(romano_dec)):
        letra = romano_dec[i]
        for j in range(len(Rom)):
            if letra == Rom[j]:
                suma += valor[j]
                if ant < valor[j]:
                    suma = suma - ant * 2
                    ant = valor[j]
                else:
                    ant = valor[j]
    print()
    return print("El número romano", gdorom, "en decimal es: \n",
                 suma), reset()


#FUNCIÓN DECIMAL A ROMANO
def decimal_romano():
    n_decimal = input("Número a convertir en romano: \n")
    #pruebaerror=False
    while True:
        try:
            n_decimal = int(n_decimal)
            break
        except:
            n_decimal = str(n_decimal)
            print("Por favor, escriba sólo números")
            print()
            n_decimal = input("Número a convertir en romano: \n")
            n_decigdo = n_decimal

    n_decigdo = n_decimal
    decimales = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1]
    romanos = [
        "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"
    ]
    romano_obtener = ""
    i = 0
    while n_decimal > 0:
        for _ in range(n_decimal // decimales[i]):
            romano_obtener += romanos[i]
            n_decimal -= decimales[i]
        i += 1
    print()
    print("El número decimal", n_decigdo, "en romano es: \n", romano_obtener)
    reset()


#TABLA DE CONVERSION HEXADECIMAL A DECIMAL
def tablaHexa():
    hexa = ('A', 'B', 'C', 'D', 'E', 'F')
    tabla = {}
    for i in range(16):
        if i < 10:
            tabla[i] = i
        else:
            tabla[hexa[i - 10]] = i
    for c, v in tabla.items():
        print("---------- --------")
        print("|", "Hexa:", c, "|", "Dec:", v, "|")
    reset()

    #TABLA DE CONVERSION HEXADECIMAL A BINARIO


#funcion para pasar de decimal a binario
#posteriormente se usará en la función de la tabla
def decimal_bin(num):
    residuos = []
    while num > 1:
        residuos.append(num % 2)
        num = num // 2
    residuos.append(num)
    residuos = residuos[::-1]

    return residuos


def tablaHexaBin():
    hexa = ('A', 'B', 'C', 'D', 'E', 'F')
    tabla = {}
    for i in range(16):
        if i < 10:
            bins = decimal_bin(i)
            tabla[i] = completar(bins)
        else:
            bins = decimal_bin(i)
            tabla[hexa[i - 10]] = bins
    for hxa, bno in tabla.items():
        bno = "".join([str(cdna) for cdna in bno])
        #este print es para que se vea bacano
        print("---------- ------------")
        print("|", "HEX: ", hxa, "|", "BIT: ", bno, "|")
    reset()


#TABLA DE CONVERSIÓN ROMANO A DECIMAL
def tablaRomano():
    n_romano = ("I", "V", "X", "L", "C", "M", "D")
    n_decimal = (1, 5, 10, 50, 100, 500, 1000)
    tablaRo = {}
    for i in range(7):
        tablaRo[n_romano[i]] = n_decimal[i]
    for k, v in tablaRo.items():
        print(" ---------------------")
        print("|", "  ", k, "  |  ", "  ", v, "  |")
    reset()


#FUNCIÓN TABLAS DE MULTIPLICAR DEL 1 AL 10
def tablas1_10():
    for multiplicando in range(1, 13):
        for multiplicador in range(1, 13):
            print(multiplicando, "*", multiplicador, "=",
                  multiplicando * multiplicador)
        print()
    reset()


#FUNCION PARA TABLA DE MULTIPLICAR
def t_multi():
    tabla_multi = {}
    n_multi = int(input("Número para conocer las tablas: \n"))
    print()
    for a in range(
            1, 11
    ):  #este range(1,11) es para que haga la tabla desde el 1 hasta el 10
        tabla_multi[
            n_multi] = a  #Este lo que hace es que al diccionario, le agg el valor ingresado en el n_multi, y el valor será igual a la variable (a), que sera desde 1 a 10
        """(multiplicar=a*n_multi)#este también sirve para multiplicación, y lo que hace es que va a multiplicar a la variable (a) por el n_multi es decir, el ingresado, recordemos que la variable a del for, empieza valiendo 1, y cada vez que entra al for va aumentando y el 12 se va multiplicando por esta misma que va en una creciente"""
        for c, v in tabla_multi.items():
            print(c, "*", v, "=", c * v)
    reset()


#FUNCION PARA TABLA DE MULTIPLICAR SISTEMA OCTAL
#mulndo=multiplicando
def tablamulOctal():
    for mulndo1 in range(1, 8):
        for multidor in range(1, 8):
            numDec = mulndo1 * multidor
            numOct = oct(numDec)[2:]
            print("{:5}".format(numOct), end="")
        print()
    reset()


"""FUNCIONES PARA USO DENTRO DE OTRAS FUNCIONES"""


#FUNCIÓN PARA COMPLETAR LOS BINARIOS EN LA TABLA HEXADECIMAL
#esta es para completar los binarios faltantes en la lista
def completar(bin_lista):
    n = 4 - len(bin_lista)
    for i in range(n):
        bin_lista.insert(i, 0)

    return bin_lista


#FUNCIÓN PARA DETECTAR LETRAS HEXADECIMALES
def reemplaceandop(numhex):
    for i in range(len(numhex)):
        if numhex[i] == "A":
            numhex.pop(i)
            numhex.insert(i, 10)
        if numhex[i] == "B":
            numhex.pop(i)
            numhex.insert(i, 11)
        if numhex[i] == "C":
            numhex.pop(i)
            numhex.insert(i, 12)
        if numhex[i] == "D":
            numhex.pop(i)
            numhex.insert(i, 13)
        if numhex[i] == "E":
            numhex.pop(i)
            numhex.insert(i, 14)
        if numhex[i] == "F":
            numhex.pop(i)
            numhex.insert(i, 15)


#FUNCIÓN PARA DETECTAR ERRORES EN CONVERSOR DE ROMANOS A DECIMALES
def error_rom():
    romanos = set("IVXLCDM")
    global romano_dec
    global gdorom
    romano_dec = input("Número romano a convertir: ").upper()
    gdorom = romano_dec
    for i in romano_dec:
        if i not in romanos:
            print()
            print("Ingrese un número romano válido")
            print()
            print(
                "Si no conoce los números romanos, puede verlos en la oción F",
                "\n",
                "Si desea verlos, escriba I y luego pulse enter hasta que se muestre el menú y digite F"
            )
            valid = False
            break
        else:
            valid = True
    while not valid:
        valid = True
        print()
        romano_dec = input("Número romano a convertir: ").upper()
        gdorom = romano_dec
        for c in romano_dec:
            if c not in romanos:
                valid = False
                print()
                print("Ingrese un número romano válido")
                print()
                print(
                    "Si no conoce los números romanos, puede verlos en la oción F",
                    "\n",
                    "Si desea verlos, escriba I y luego pulse enter hasta que se muestre el menú y digite F"
                )
                break


#FUNCIÓN PARA LIMPIAR PANTALLA DEL COMPILADOR
def reset():
    print()
    input("Presione una tecla para regresar al menú")
    # replit.clear()
    menu()

  
