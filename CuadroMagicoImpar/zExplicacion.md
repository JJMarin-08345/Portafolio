Este algoritmo tiene pensado darle solución a los cuadrados mágicos impares, es decir 3x3, 5x5, 7x7, 9x9 etc.. 

Antes de explicar su solución es necesario entender lo siguiente:
1. Todas las matrices seran cuadradas, es decir (_n_*_n_)
2. Las matrices serán impares, es decir (_n_%_2_!=_0_)
3. La variable _n_ debe ser mayor o igual a _3_
4. Es primordial entender que no todos los cuadros mágicos tienen solución si no se tiene un orden específico 
   o un patrón en los números que estarán dentro del cuadro, es decir, estos deben tener un patrón, como de 2 en 2
   o de 3 en 3
   - Ejemplo: (numero inicial 2, con una diferencia de 2 numeros entre cada uno y una cantidad total de 9 numeros ) 
     obtendriamos lo siguiente: 
        [2, 4, 6, 8, 10, 12, 14, 16, 18]
    - Otro ejemplo: (Numero inicial 1, con una diferencia de 5 numeros entre cada uno y una cantidad total de 9 numeros):
        [1, 6, 11, 16, 21, 26, 31, 36, 41]

Con eso en cuenta, se explica la idea principal para su solucion:
1. Incrementar el tamaño de la matriz original segun el siguiente calculo:
    - int(_n_ / _2_) --> Esto nos dará la parte entera de la división y ese resultado es en cuanto mas debemos aumentar 
      la matriz, es decir, vamos a crear una matriz tomando en cuenta (_n_ + (int(_n_/_2_) * 2 )). Exacto el numero de
      _n_ sumado a la multiplicación por _2_ de la division entera entre _n_/_2_

2. Organizar los numeros de tal manera que dibujen un diamante en toda la matriz

3. Lo últimmo sería acomodar los numeros que están fuera de la matriz, adentro de la matriz pero esto aún no he logrado 
   realizarlo ya que no encuentro la formula o la manera para que sirva en todas las matrices
