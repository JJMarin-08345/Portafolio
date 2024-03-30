import pygame
import random
from funciones import *



#Variables para el color
WHITE = (255, 255, 255)
DARK_GREY = (35,35,35)

#Inicializamos pygame
pygame.init()

#Sonido colision
sonido_colision = pygame.mixer.Sound('explosion.mp3')
sonido_falla = pygame.mixer.Sound('fail.mp3')

#Fuente de texto
fuente = pygame.font.SysFont('Arial', 25)

#Dimension de la pantalla
screen_size = (800, 500)
#Reloj para manejar los fps
clock = pygame.time.Clock()
#Variables para las cordenadas en la pantalla
cord_x = 0
cord_y = 0
#Velocidad de movimiento en cada eje
speed_x = 5
speed_y = 5
#Variables para posicion del mouse
mouse_x = 0
mouse_y = 0

screen = pygame.display.set_mode(screen_size)
pygame.display.set_caption('Prueba')

#Creamos una lista de coordenadas
lst_coordenadas = generarListaCoordenadas(30)
contador = 0

#Variable para manejar la velocidad de la lluvia
velocidadLluvia = 3

while True :
        
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            pygame.quit()
            quit()
        elif event.type == pygame.MOUSEBUTTONDOWN:
            mouse = pygame.mouse.get_pos()
            mouse_x = mouse[0]
            figura_atrapada = None
            for coor in lst_coordenadas:
                figura = pygame.Rect(coor[0], coor[1], 15, 30)
                if(figura.collidepoint(mouse)):
                    figura_atrapada = coor
                    x,y = x_y_aleatorios()
                    lst_coordenadas.append([x,-10, figura_atrapada[2], figura_atrapada[3], figura_atrapada[4]])
                    break
            if(figura_atrapada):
                lst_coordenadas.remove(figura_atrapada)
                sonido_colision.play()
                sonido_colision.set_volume(0.15)
                contador += 1
                print(contador)
            elif(contador % 20 != 1):
                sonido_falla.play()
                sonido_falla.set_volume(0.3)
                print("No atrapaste nada")
                contador-=1
            else:
                sonido_falla.play()
                sonido_falla.set_volume(0.3)
                print("No atrapaste nada")
                
                    
    
    #Le ponemos un color de fondo a la ventana
    screen.fill(DARK_GREY)
    if(contador >= 20 and contador % 20 == 0):
        print(f"Contador Nuevo Nivel {contador}")
        contador += 1
        velocidadLluvia += 1
        
    #Dibujo en el programa
    mouse = pygame.mouse.get_pos()
    
    pygame.draw.rect(screen, (0,0,0), (mouse[0]-5, mouse[1]-5, 10, 10))
    
    
    for coordenada in lst_coordenadas:
        
        x = coordenada[0] #Posicion x figura
        y = coordenada[1] #POsicion y figura
        color = coordenada[2] #Color figura
        alto = coordenada[3] #Alto figura
        ancho = coordenada[4] #Ancho figura
        
        lluvia_rectangulo = pygame.draw.rect(screen, color, (x, y, alto, ancho))#Dibujamos la figura
        
        coordenada[1] += velocidadLluvia #Movemos la figura hacia abajo

        if(coordenada[1] > 499): #Cuando llegue abajo del todo, hay que volverla a subir
            coordenada[0] = random.randint(-50, 850) #Para que aparezca a los lados del todo
            coordenada[1] = random.randint(-200, 10) #Para que aparezca arriba del todo
      
            
    
    texto = fuente.render(f"Puntos: {contador}", True, WHITE)
    screen.blit(texto, (10, 10))
    #Fin dibujos
    # NuevoNivel = False
    #Actualizamos la ventana para que cargue el color aplicado
    pygame.display.flip()
    clock.tick(30)
    
