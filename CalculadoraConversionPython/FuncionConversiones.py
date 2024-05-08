# import replit

def menu():
  opcion=""
  print("BIENVENIDO AL SISTEMA GENERAL DE CONVERSIONES")
  print("")
  print("*** MENU DE OPCIONES ***\n")
  print("A- Convertir decimal a binario")
  print("B- Convertir binario a decimal")
  print("C- Convertir decimal a octal")
  print("D- Convertir octal a decimal")
  print("E- Convertir decimal a hexadecimal")
  print("F- Convertir hexadecimal a decimal")
  print("G- Salir")
  print("")
  opcion=input("Escriba la letra la cual se relacione a su opcion: \n")
  opcion=opcion.upper()
  if opcion=="A" or opcion=="1": 
    # replit.clear()
    print("*** DECIMAL A BINARIO ***")
    print()
    decimal_binario()
    print("")
 
  elif opcion=="B" or opcion=="2":
    # replit.clear()
    print("*** BINARIO A DECIMAL ***")
    print()
    binario_decimal()
    print("")
  
  elif opcion=="C" or opcion=="3":
    # replit.clear()
    print("*** DECIMAL A OCTAL ***")
    print()
    decimal_octal()
    print("")
   
  elif opcion=="D" or opcion=="4":
    # replit.clear()
    print("*** OCTAL A DECIMAL ***")
    print()
    octal_decimal()
    print("")
   
  elif opcion=="E" or opcion=="5":
    # replit.clear()
    print("*** DECIMAL A HEXADECIMAL ***")
    print()
    decimal_hexadecimal()
    print("")
   
  elif opcion=="F" or opcion=="6":
    # replit.clear()
    print("*** HEXADECIMAL A DECIMAL ***")
    print()
    hexadecimal_decimal()
    print("")

  elif opcion=="G" or opcion=="7":
    # replit.clear()
    print()
    print("HASTA LA PRÓXIMA CAMARADA, VUELVE PRONTO")
  else:
    # replit.clear()
    print("Sólo puedes escoger entre la A y la G o su respectiva numeración")
    print("")
    print("-Por favor escoga alguna de las opciones-")
    print("")
    reset()
   
#DECIMAL A BINARIO
def decimal_binario():
  #Esta es la opción A
  binario=[]
  N_decimalb=input("Número decimal a converir en binario: \n")
  if esnum_o_no(N_decimalb):
    N_decimalb=int(N_decimalb)
  else:
    while esnum_o_no(N_decimalb)!=True:
      print("")
      print("error","\nse ha detectado una letra, por favor digite un número ")
      print("")
      N_decimalb=input("Número decimal a convertir en binario: \n") 
    N_decimalb=int(N_decimalb)
  a=N_decimalb
  while N_decimalb!=0:
    residuo = N_decimalb%2
    N_decimalb =N_decimalb//2
    binario.append(residuo)
  '''
  Este [::-1] sirve para alterar la lista e invertirla
  '''
  print()
  binario=binario[::-1]
  print("El número",a,"en binario es:")
  cdna_binario="".join([str(i) for i in binario])
  print(cdna_binario)
  reset()
  
#BINARIO A DECIMAL
def binario_decimal():
  #Esta es la opcion B
  binario=input("Número binario a convertir en decimal: \n")
  for a in binario:
    if a!='0' and a!='1':
      while a in binario!='0' and a in binario!='1':
          print("")
          print("///Por favor escriba un número binario 0-1\\\\\\")
          print("")
          binario=input("Número binario a convertir en decimal: \n")
  bin1=binario
  binario=binario[::-1]
  binreal=0
  for i in range(len(binario)):
    binreal+=(pow(2,i) * int(binario[i]))
    #print(pow(2,i),binreal,binario)
    #es para ver cómo funciona la función
  print("")
  print("El número binario",bin1)
  print("En decimal es:",binreal)
  reset()

#DECIMAL A OCTAL
def decimal_octal():
  resoctal=[]
  deci_octal=input("Número decimal a convertir a octal: \n")
  if esnum_o_no(deci_octal):
    deci_octal=int(deci_octal)
  else:
    while esnum_o_no(deci_octal)!=True:
      print("")
      print("error","\nse ha detectado una letra, por favor digite un número ")
      print("")
      deci_octal=input("Número decimal a convertir a octal: \n")
    deci_octal=int(deci_octal)
      
  octal1=deci_octal
  while deci_octal!=0:
    resoctal.append(deci_octal%8)
    deci_octal=deci_octal//8
  resoctal=resoctal[::-1]
  print("")
  print("El número ",octal1, "en formato octal es:")
  cdnaoctal="".join([str(i) for i in resoctal])
  print(cdnaoctal)
  reset()
  
#OCTAL A DECIMAL
def octal_decimal():
  n_octal=input("Octal a convertir en decimal: \n")
  for a in range(len(n_octal)):
    n_octal=([int(i) for i in n_octal])
  while n_octal[a]>7:
    n_octal.pop(a)
    print("")
    print("Error, digite número formato octal")
    print("")
    n_octal=input("Octal a convertir en decimal: \n")
    for a in range(len(n_octal)):
      n_octal=([int(i) for i in n_octal])
    
    
  noctal1="".join([str(pos) for pos in n_octal])
  n_octal=n_octal[::-1]
  resideci=0
  for contoctal in range(len(n_octal)):
    resideci+=(pow(8,contoctal)*int(n_octal[contoctal]))
  print("")
  print("El número octal",noctal1, "en decimal es:")
  print(resideci)
  reset()

#DECIMAL A HEXADECIMAL
def decimal_hexadecimal():
  n_decimalH=input("Número decimal a convertir en hexadecimal: \n")
  #para detectar si es un numero lo digitado o no
  if esnum_o_no(n_decimalH):
    n_decimalH=int(n_decimalH)
  else:
    while esnum_o_no(n_decimalH)!=True:
      print("")
      print("error","\nse ha detectado una letra, por favor digite un número ")
      print("")
      n_decimalH=input("Número decimal a convertir en hexadecimal: \n") 
    n_decimalH=int(n_decimalH)
  ndH=n_decimalH
  residuoh=[]
  while n_decimalH>15:
    residuoh.append(n_decimalH%16)
    n_decimalH=n_decimalH//16
    
  residuoh.append(n_decimalH)
  
  for cont in range(len(residuoh)):
    if residuoh[cont]==10:
      residuoh[cont]="A"
    if residuoh[cont]==11:
      residuoh[cont]="B"
    if residuoh[cont]==12:
      residuoh[cont]="C"
    if residuoh[cont]==13:
      residuoh[cont]="D"
    if residuoh[cont]==14:
      residuoh[cont]="E"
    if residuoh[cont]==15:
      residuoh[cont]="F"
      
  residuoh=residuoh[::-1]
  print("")
  print("El número", ndH, "en hexadecimal es:")
  cdna_residuoh="".join([str(i) for i in residuoh])
  print(cdna_residuoh)
  reset()
   
#HEXADECIMAL A DECIMAL
def hexadecimal_decimal():
  n_hexa=input("Hexadecimal a convertir en decimal: \n")
  n_hexa=n_hexa.upper()
  hexagdo=n_hexa
  n_hexa=list(n_hexa)
  for i in range(len(n_hexa)):
    while n_hexa[i]!="A" and n_hexa[i]!="B" and n_hexa[i]!="C" and n_hexa[i]!="D" and n_hexa[i]!="E" and n_hexa[i]!="F":
      
      if n_hexa[i]=="0" or n_hexa[i]=="1" or n_hexa[i]=="2" or n_hexa[i]=="3" or n_hexa[i]=="4" or n_hexa[i]=="5" or n_hexa[i]=="6" or n_hexa[i]=="7" or n_hexa[i]=="8" or n_hexa[i]=="9":
        break
        pass
      print("")
      print("error, se ha detectado una letra no correspondiente a un hexadecimal")
      print("")
      n_hexa=input("Hexadecimal a convertir en decimal: \n")
      n_hexa=n_hexa.upper()
      hexagdo=n_hexa
      n_hexa=list(n_hexa)
      
    if n_hexa[i]=="A":
      n_hexa.pop(i)
      n_hexa.insert(i,10)
    if n_hexa[i]=="B":
      n_hexa.pop(i)
      n_hexa.insert(i,11)
    if n_hexa[i]=="C":
      n_hexa.pop(i)
      n_hexa.insert(i,12)
    if n_hexa[i]=="D":
      n_hexa.pop(i)
      n_hexa.insert(i,13)
    if n_hexa[i]=="E":
      n_hexa.pop(i)
      n_hexa.insert(i,14)
    if n_hexa[i]=="F":
      n_hexa.pop(i)
      n_hexa.insert(i,15) 
      
  n_hexa=n_hexa[::-1]
  rdohexa=0
  for residuo in range(len(n_hexa)):
    rdohexa+=(pow(16,residuo)*int(n_hexa[residuo]))
  print("")
  print("El hexadecimal ",hexagdo, "en decimal es:")
  print(rdohexa)
  reset()
    
    
def esnum_o_no(nume):
  try:
    int(nume)
    return True
  except ValueError:
    return False

def reset():
  print()
  input("Presione una tecla para regresar al menú")
  # replit.clear()
  menu()
