/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;
import Modelo.Conexion;
import Modelo.Mercancia;
import javax.swing.JOptionPane;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 *
 * @author USUARIO
 */
public class ControladorMercancia extends Conexion {

    // Atributos
    private final Conexion cn;

    // Constructor por defecto
    public ControladorMercancia() {
        this.cn = new Conexion();
    }

    // METODO CREATE
    // AgregarMercancia
    public boolean AgregarMercancia(Mercancia mr) {
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("INSERT INTO Mercancia (Categoria, Descripcion, Cantidad) VALUES (?,?,?)");
            ps.setString(1, mr.getCategoria());
            ps.setString(2, mr.getDescripcion());
            ps.setInt(3, mr.getCantidad());
            
            int isInsert = ps.executeUpdate();
            if (isInsert > 0) {//Se insertó el registro
                JOptionPane.showMessageDialog(null, "Mercancia agregada");
                return true;
            } else {
                JOptionPane.showMessageDialog(null, "No fue posible agregar la mercancia");
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }

    // METODOs GET
    // Obtener toda la mercancia
    public ArrayList<Mercancia> obtenerMercancia() {
        ArrayList<Mercancia> lstMercancia = new ArrayList<>();
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT * FROM Mercancia");
            rs = ps.executeQuery();
            while (rs.next()) { //Mientras hayan datos
                int id = rs.getInt("Id");
                String categoria = rs.getString("Categoria");
                String descripcion = rs.getString("Descripcion");
                int cantidad = rs.getInt("Cantidad");

                Mercancia mercancia = new Mercancia(id, categoria, descripcion, cantidad);
                lstMercancia.add(mercancia);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return lstMercancia;
    }

    //Obtener mercancia por id
    public Mercancia obtenerMercanciaId(int id) {
        Mercancia mercancia = null;
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT * FROM Mercancia WHERE Id = ?");
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                int mercancia_id = rs.getInt("Id");
                String categoria = rs.getString("Categoria");
                String descripcion = rs.getString("Descripcion");
                int cantidad = rs.getInt("Cantidad");
                mercancia = new Mercancia(id, categoria, descripcion, cantidad);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return mercancia;
    }
    
    //METODO UPDATE
    public boolean actualizarMercancia(Mercancia mr){
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("UPDATE Mercancia SET Categoria = COALESCE(?,Categoria), "
                    + "Descripcion = COALESCE(?,Descripcion), Cantidad = COALESCE(?,Cantidad) WHERE Id = ?");
            ps.setString(1, mr.getCategoria());
            ps.setString(2, mr.getDescripcion());
            ps.setInt(3, mr.getCantidad());
            ps.setInt(4, mr.getId());
            int isUpdate = ps.executeUpdate();
            if(isUpdate > 0){// Se actualizo la mercancia
                JOptionPane.showMessageDialog(null, "El registro se actualizo con exito");
                return true;
            }else{
                JOptionPane.showMessageDialog(null, "No fue posible actualizar el registro");
            }

        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }

    //METODO DELETE
    public boolean eliminarMercancia(int id) {
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("DELETE FROM Mercancia WHERE Id = ?");
            ps.setInt(1, id);
            int isDelete = ps.executeUpdate();
            if(isDelete > 0){
                JOptionPane.showMessageDialog(null, "Registro eliminado");
                return true;
            }else{
                JOptionPane.showMessageDialog(null, "No fue posible eliminar el registro");
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }
}
