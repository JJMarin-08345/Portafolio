#441023
#Resolvedor de sopa de letras

import IngresoDatos as Validaciones
import FunFuncionamiento as FuncionesSopaDeLetras
import ResolvedorSopaLetras

print()

EntradaUnoAlWhile = False
print("\n\n---RECUERDE QUE LA CANTIDAD DE FILAS SERA LAS MISMAS DE COLUMNAS---\n\n")
while EntradaUnoAlWhile!=True :
    filas = (input("Ingrese la cantidad de filas que tendrá la sopa de letras:\n"))

    NumerosCasteados = Validaciones.Casteo_Int([filas])

    if(NumerosCasteados):
        filas=int(filas)
        columnas= filas
        EntradaUnoAlWhile=True
    else:
        print("\nIngrese solo numeros \n")

SopaDeLetras = FuncionesSopaDeLetras.CrearSopaDeLetras(filas)

FuncionesSopaDeLetras.ImprimirSopaDeLetras(SopaDeLetras)

# Estas son las palabras para encontrar en la sopa de letras
# Las digita el usuario
palabrasABuscar = ResolvedorSopaLetras.pedirPalabras(filas)

for palabra in palabrasABuscar:
    ResolvedorSopaLetras.EncontrarPalabra(SopaDeLetras, palabra)
