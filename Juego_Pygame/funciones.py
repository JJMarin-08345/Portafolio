import random
def movimiento_cuadrado(cord_x, cord_y, speed_x, speed_y):
    cord_x += speed_x
    cord_y += speed_y
    if cord_x > 770 or cord_x < 0:
        speed_x *= -1
    if cord_y > 470 or cord_y < 0:
        speed_y *= -1
    return cord_x, cord_y, speed_x, speed_y

def x_y_aleatorios():
    return set([random.randint(-50, 850), random.randint(-200, 10)])

def generarListaCoordenadas(rango):
    colores = [
        (255, 204, 204),  # Rosa claro
        (204, 255, 204),  # Verde claro
        (204, 204, 255),  # Azul claro
        (255, 255, 204),  # Amarillo claro
        (255, 204, 255),  # Violeta claro
        (204, 255, 255),  # Celeste claro
        (255, 230, 204),  # Melocotón claro
        (204, 255, 230),  # Verde menta claro
        (255, 204, 230),  # Rosa suave
        (230, 204, 255)   # Lavanda claro
    ]

    lst_coordenadas = []
    for i in range(rango):
        print(rango)
        x, y = x_y_aleatorios()
        color = colores[random.randint(0, 9)]
        alto = random.randint(13, 25)
        ancho = random.randint(15, 35)
        lst_coordenadas.append([x, y, color, alto, ancho])
    return lst_coordenadas

