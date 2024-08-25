/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;

import Modelo.Conexion;
import Modelo.Usuario;
import Modelo.Venta_View;
import Modelo.Ventas_Productos;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import javax.swing.JOptionPane;
import java.sql.Statement;

/**
 *
 * @author USUARIO
 */
public class ControladorVenta extends Conexion {

    //Atributos
    private final Conexion cn;
    private Usuario userLog;

    //Contructor por defecto
    public ControladorVenta() {
        this.cn = new Conexion();
    }

    //Constructor con parametro un usuario, para metodos create y update
    public ControladorVenta(ControladorLogin user) {
        this.cn = new Conexion();
        this.userLog = user.getUserLog();
    }

    //METODOS CRUD
    //METODO CREATE
    public boolean nuevaVenta(ArrayList<Ventas_Productos> lst_VentasProductos) {

        try {
            con = this.cn.getConnection();
            con.setAutoCommit(false);
            //Esto es para que me retorne el id que se genera de una vez para luego usarlo en el insert de ventas_productos
            ps = con.prepareStatement("INSERT INTO Ventas (id_usuario) VALUES (?)", Statement.RETURN_GENERATED_KEYS);
            ps.setString(1, this.userLog.getUsuario());
            ps.executeUpdate();
            rs = ps.getGeneratedKeys();
            int id_Venta = -1;
            if (rs.next()) {
                id_Venta = rs.getInt(1);
            }
            rs.close();
            //INSERCION EN LA TABLA Ventas_Productos
            ps = con.prepareStatement("INSERT INTO Ventas_Productos (id_venta, id_producto, cantidad) VALUES (?,?,?)");
            for (Ventas_Productos vp : lst_VentasProductos) {
                ps.setInt(1, id_Venta);
                ps.setInt(2, vp.getId_producto());
                ps.setInt(3, vp.getCantidad());
                ps.addBatch();
            }
            ps.executeBatch();
            con.commit();
            con.setAutoCommit(true);
            JOptionPane.showMessageDialog(null, "Venta registrada");
            return true;

        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }

    //METODOS GET
    public Venta_View ObtenerVentaId(int id_venta) {
        Venta_View venta = null;
        ArrayList<Integer> lst_IdsProductos = new ArrayList<>();
        ArrayList<Integer> lst_CantidadProductos = new ArrayList<>();

        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT * FROM Ventas_Productos WHERE id_venta = ?");
            ps.setInt(1, id_venta);
            rs = ps.executeQuery();
            while (rs.next()) {
                lst_IdsProductos.add(rs.getInt("id_producto"));
                lst_CantidadProductos.add(rs.getInt("Cantidad"));
                venta = new Venta_View(id_venta, lst_IdsProductos, lst_CantidadProductos);
            }

        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return venta;
    }

    public ArrayList<ArrayList<String>> obtenerNombresProductosXVentaPorId(int id_venta) {
        ArrayList<ArrayList<String>> lstNombresProductos = new ArrayList<>();
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT p.Nombre, vp.cantidad FROM ventas_productos vp\n"
                    + "INNER JOIN productos p ON p.Id = vp.id_producto WHERE vp.id_venta = ?");
            ps.setInt(1, id_venta);
            rs = ps.executeQuery();
            while (rs.next()) {
                lstNombresProductos.add(new ArrayList<>(List.of(rs.getString("Nombre"), rs.getString("cantidad"))));
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return lstNombresProductos;
    }

    public ArrayList<Venta_View> obtenerTodasLasVentas() {
        ArrayList<Venta_View> lstVentas = new ArrayList<>();
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT v.Id, v.fecha_venta, SUM(p.Precio * vp.cantidad) PrecioTotal FROM ventas_productos vp\n"
                    + "INNER JOIN ventas v ON v.Id = vp.id_venta\n"
                    + "INNER JOIN productos p ON p.Id = vp.id_producto\n"
                    + "GROUP BY v.Id");
            rs = ps.executeQuery();
            while (rs.next()) {
                int id_venta = rs.getInt("Id");
                Date fecha_venta = rs.getDate("fecha_venta");
                double precioTotal = rs.getDouble("PrecioTotal");
//                ArrayList<String> nombresProductos = obtenerNombresProductosXVentaPorId(id_venta);
                Venta_View venta = new Venta_View(id_venta, fecha_venta, precioTotal);
                lstVentas.add(venta);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return lstVentas;
    }

    //METODO DELETE
    public boolean deleteVenta(int id_venta){
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("DELETE FROM Ventas_Productos WHERE id_venta = ?");
            ps.setInt(1, id_venta);
            int isDelete = ps.executeUpdate();
            if(isDelete > 0){
                JOptionPane.showMessageDialog(null, "Venta Eliminada");
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
