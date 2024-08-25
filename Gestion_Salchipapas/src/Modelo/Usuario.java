/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

/**
 *
 * @author USUARIO
 */
public class Usuario {
    private String Usuario;
    private String contrasena;
    
    
    // Constructor que recibe el nombre de usuario y la contraseña para inicializar el objeto Usuario
    public Usuario(String Usuario, String contrasena) {
        this.Usuario = Usuario;
        this.contrasena = contrasena;
    }

    public String getUsuario() {
        return Usuario;
    }

    public void setUsuario(String Usuario) {
        this.Usuario = Usuario;
    }

    public String getContrasena() {
        return contrasena;
    }

    public void setContrasena(String contrasena) {
        this.contrasena = contrasena;
    }    
}
