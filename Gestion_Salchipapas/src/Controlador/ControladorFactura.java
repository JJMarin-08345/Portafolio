/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Controlador;
import Modelo.Factura;
import Modelo.Conexion;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Date;
import javax.swing.JOptionPane;

/**
 *
 * @author USUARIO
 */
public class ControladorFactura extends Conexion {

    //atributos
    Conexion cn;

    public ControladorFactura() {
        this.cn = new Conexion();
    }

    private double[] obtenerSubYTotalConIVA(int id_venta) {
        try {
            con = this.cn.getConnection();
            ps = con.prepareStatement("SELECT v.Id, SUM(p.Precio * vp.cantidad) AS subtotal_sin_iva, SUM((p.Precio * vp.cantidad)*1.19) AS subtotal_con_iva FROM ventas_productos vp\n"
                    + "INNER JOIN ventas v ON v.Id = vp.id_venta\n"
                    + "INNER JOIN productos p ON p.Id = vp.id_producto\n"
                    + "WHERE v.Id = ?");
            ps.setInt(1, id_venta);
            rs = ps.executeQuery();
            if (rs.next()) {
                double subTotalSinIva = rs.getDouble("subtotal_sin_iva");
                double subTotalConIva = rs.getDouble("subtotal_con_iva");

                //En la posicion 0, va el sin iva, y en la posicion 1 va con iva
                return new double[]{subTotalSinIva, subTotalConIva};
            }
        } catch (SQLException e) {
            JOptionPane.showMessageDialog(null, e.getMessage());
        }
        return new double[]{-1, -8};
    }

    public ArrayList<Factura> generarFactura(int id_venta) {
        ArrayList<Factura> lstFactura = new ArrayList<>();
        double[] lstSubTotales = obtenerSubYTotalConIVA(id_venta);
        System.out.println(lstSubTotales[0] + "  " + lstSubTotales[1]);
        if (lstSubTotales[0] != -1 && lstSubTotales[1] != -8) {
            // Obtener datos de la factura desde la base de datos
            try {
                con = this.cn.getConnection();

                ps = con.prepareStatement("SELECT 'Factura de Venta' as denominacion, 'Salchipaperia' as razon_social, "
                        + "'12345789-2' as nit, 'Salchipapas' as vendedor, v.Id as numeracion_consecutivo, "
                        + "v.fecha_venta as fecha_emision, vp.id_producto, p.nombre, p.descripcion, "
                        + "vp.cantidad, p.precio as precio_unitario, v.id_usuario "
                        + "FROM ventas v "
                        + "JOIN ventas_productos vp ON v.Id = vp.id_venta "
                        + "JOIN productos p ON vp.id_producto = p.Id "
                        + "WHERE vp.id_venta = ?");
                ps.setInt(1, id_venta);
                rs = ps.executeQuery();

                // Mostrar la información de la factura en el formulario
                while (rs.next()) {
                    Date FechaVenta = rs.getDate("fecha_emision");
                    String Vendedor = rs.getString("vendedor");
                    String id_usuario = rs.getString("id_usuario");
                    String nombreProducto = rs.getString("nombre");
                    int cantidadProductos = rs.getInt("cantidad");
                    double precioUnitario = rs.getDouble("precio_unitario");

                    double subTotalSinIva = lstSubTotales[0];
                    double subTotalConIva = lstSubTotales[1];

                    Factura factura = new Factura(id_venta, FechaVenta, Vendedor, id_usuario, nombreProducto, cantidadProductos,
                            precioUnitario, subTotalSinIva, subTotalConIva);
                    lstFactura.add(factura);
                }
            } catch (SQLException e) {
                JOptionPane.showMessageDialog(null, e.getMessage());
            }
        } else {
            JOptionPane.showMessageDialog(null, "No se encontraron registros de ventas con el id de venta proporcionado");
        }
        return lstFactura;
    }
}
