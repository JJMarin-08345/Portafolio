def Casteo_Int(numeros):
    for i in range(len(numeros)):
        if numeros[i].isnumeric():
            return True
    return False

