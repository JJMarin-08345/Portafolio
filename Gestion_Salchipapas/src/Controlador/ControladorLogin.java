/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;

import Modelo.Conexion;
import Modelo.Usuario;
import java.sql.SQLException;
import javax.swing.JOptionPane;

public class ControladorLogin extends Conexion {

    // Atributos
    public Conexion cn;
    private Usuario userLog;

    // Constructor por defecto
    public ControladorLogin() {
        this.cn = new Conexion();
    }

    public boolean autenticar(Usuario user) {
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT * FROM Usuario WHERE id_usuario = ? AND Password = ? ");
            ps.setString(1, user.getUsuario());
            ps.setString(2, user.getContrasena());
            rs = ps.executeQuery();
            if (rs.next()) {
                //El usuario y clave son correctas
                
                // Le pasamos el usuario para usarla en toda la app
                userLog = new Usuario(user.getUsuario(), user.getContrasena());
                return true;
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }
    
    public Usuario getUserLog(){
        return userLog;
    }
}
