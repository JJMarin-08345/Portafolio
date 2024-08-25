/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;

import Modelo.Conexion;
import Modelo.Producto;
import java.sql.SQLException;
import javax.swing.JOptionPane;
import java.util.ArrayList;

/**
 *
 * @author USUARIO
 */

public class ControladorProducto extends Conexion {

    //Atributos
    private final Conexion cn;

    // Constructor por defecto
    public ControladorProducto() {
        this.cn = new Conexion();
    }

    //Funciones CRUD
    //Create 
    public boolean createProducto(Producto pd) {

        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("INSERT INTO Productos (Nombre, Descripcion, Precio)"
                    + " VALUES (?,?,?)"); // Pasamos sentencia SQL
            ps.setString(1, pd.getNombre()); // Parametro 1
            ps.setString(2, pd.getDescripcion()); // Parametro 2
            ps.setDouble(3, pd.getPrecio()); // Parametro 3

            ps.executeUpdate(); // Ejecutamos sentencia SQL
            JOptionPane.showMessageDialog(null, "Se ha insertado");
            return true;
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }

    // METODOS GET
    // Obtener todos los productos
    public ArrayList<Producto> obtenerProductos() {
        ArrayList<Producto> lstProductos = new ArrayList<>(); // ArrayList para almacenar los productos obtenidos
        try {
            con = this.getConnection(); // Obtener la conexión a la base de datos
            ps = con.prepareStatement("SELECT * FROM Productos"); // Preparar la consulta SQL
            rs = ps.executeQuery(); // Ejecutar la consulta y obtener los resultados

            // Iterar sobre cada fila en los resultados
            while (rs.next()) {
                // Obtener los datos de la fila actual
                int id = rs.getInt("Id");
                String nombre = rs.getString("Nombre");
                String descripcion = rs.getString("Descripcion");
                double precio = rs.getDouble("Precio");

                // Crear un objeto Producto con los datos obtenidos
                Producto producto = new Producto(id, nombre, descripcion, precio);
//                System.out.println(producto);

                // Agregar el producto a la lista de productos
                lstProductos.add(producto);
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage()); // Manejo de excepciones
        }
        return lstProductos; // Devolver la lista de productos obtenidos
    }

    // Obtener producto por id
    public Producto obtenerProductoId(int id) {
        Producto pd = null;
        try {
            con = this.getConnection();
            ps = con.prepareStatement("SELECT * FROM Productos WHERE Id = ?");
            ps.setInt(1, id);
            rs = ps.executeQuery();
            if (rs.next()) {
                String Nombre = rs.getString("Nombre"); //Obtenemos el nombre
                String Descripcion = rs.getString("Descripcion"); //Obtenemos la descripcion
                double Precio = rs.getDouble("Precio"); //Obtenemos el precio

                pd = new Producto(id, Nombre, Descripcion, Precio);
            } else {
                JOptionPane.showMessageDialog(null, "No se encontró ningún producto con ese id");
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return pd;
    }

    // METODO UPDATE
    // Actualizar producto
    public boolean actualizarProducto(Producto pd) {
        try {
            con = this.getConnection();
            ps = con.prepareStatement("UPDATE Productos SET Nombre = COALESCE(?,Nombre), "
                    + "Descripcion = COALESCE(?,Descripcion), Precio = COALESCE(?,Precio) WHERE Id = ?");
            // Estos son los parametros
            ps.setString(1, pd.getNombre());
            ps.setString(2, pd.getDescripcion());
            ps.setDouble(3, pd.getPrecio());
            ps.setInt(4, pd.getId());

            int isUpdate = ps.executeUpdate();
            if (isUpdate > 0) { // Preguntamos si las filas afectadas son mayor a 0
                JOptionPane.showMessageDialog(null, "Producto actualizado con exito");
                return true;
            } else {
                JOptionPane.showMessageDialog(null, "No fue posible editar el producto");
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }

    // METODO DELETE
    // Eliminar producto
    public boolean eliminarProducto(int id) {
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("DELETE FROM Productos WHERE Id = ?");
            ps.setInt(1, id);
            int isDelete = ps.executeUpdate();
            if (isDelete > 0) {
                JOptionPane.showMessageDialog(null, "Producto eliminado");
                return true; //Borro el producto
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return false;
    }
}
