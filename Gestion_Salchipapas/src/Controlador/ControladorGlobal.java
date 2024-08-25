/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;
import Vista.main.Vista;
import java.awt.event.KeyEvent;
import javax.swing.JDesktopPane;
import javax.swing.JFrame;
import javax.swing.JInternalFrame;
/**
 *
 * @author USUARIO
 */
public class ControladorGlobal {
    /*Este controlador contrendra funciones que se reusaran en las diferentes vistas
    como la funcion de cerrar sesion, ir a otro JFrame*/
    
    public ControladorGlobal(){
    }
    
    public void CerrarSesion(JFrame fr){
        Vista vistaAnterior = new Vista();
        vistaAnterior.setVisible(true);
        fr.dispose();
    }
    
    //Funcion para navegar entre JFrames
    public void GoToOtherJFrame(JFrame OtherJFr, JFrame Jfr){ 
        int width = Jfr.getWidth(), height = Jfr.getHeight(); 
        OtherJFr.setLocation(Jfr.getLocation());
        OtherJFr.setSize(width, height);
        OtherJFr.setVisible(true);
        Jfr.dispose();
        
    }
    
    //Funcion para abrir un JInternalFrame
    public void OpenJInternalFrame(JInternalFrame JIfr, JDesktopPane JDkPane ){
        JIfr.setVisible(true);
        JDkPane.add(JIfr);
    }
    
    //Funcion para consumir el teclado en caso de ingresar numeros
    public void prohibirIngresoNumeros(KeyEvent evt){
        char c = evt.getKeyChar();
        if (!(Character.isDigit(c) || c == KeyEvent.VK_BACK_SPACE || c == KeyEvent.VK_DELETE)) {
            /*Entonces, la condición con ! al principio y || como operador lógico significa:
            "Si el carácter ingresado no es un dígito, ni una tecla de retroceso ni una tecla de suprimir, 
            consumir el evento para evitar que se agregue al campo de texto".*/
            evt.consume();
        }
    }
    
}
