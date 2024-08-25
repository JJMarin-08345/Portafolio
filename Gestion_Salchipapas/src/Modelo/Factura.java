/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

/**
 *
 * @author USUARIO
 */
import java.util.Date;

/**
 *
 * @author USUARIO
 */
public class Factura {

    //Clase para ver la factura
    private int id_venta;
    private Date FechaVenta;
    private String Vendedor;
    private String id_usuario;
    private String NombreProducto;
    private int CantidadProductos;
    private double PrecioUnitario;
    private double SubTotalSinIva;
    private double SubTotalConIva;

    public Factura(int id_venta, Date FechaVenta, String Vendedor, String id_usuario, String NombreProducto, int CantidadProductos, double PrecioUnitario, double SubTotalSinIva, double SubTotalConIva) {
        this.id_venta = id_venta;
        this.FechaVenta = FechaVenta;
        this.Vendedor = Vendedor;
        this.id_usuario = id_usuario;
        this.NombreProducto = NombreProducto;
        this.CantidadProductos = CantidadProductos;
        this.PrecioUnitario = PrecioUnitario;
        this.SubTotalSinIva = SubTotalSinIva;
        this.SubTotalConIva = SubTotalConIva;
    }

    public int getId_venta() {
        return id_venta;
    }

    public void setId_venta(int id_venta) {
        this.id_venta = id_venta;
    }

    public Date getFechaVenta() {
        return FechaVenta;
    }

    public void setFechaVenta(Date FechaVenta) {
        this.FechaVenta = FechaVenta;
    }

    public String getVendedor() {
        return Vendedor;
    }

    public void setVendedor(String Vendedor) {
        this.Vendedor = Vendedor;
    }

    public String getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(String id_usuario) {
        this.id_usuario = id_usuario;
    }

    public String getNombreProducto() {
        return NombreProducto;
    }

    public void setNombreProducto(String NombreProducto) {
        this.NombreProducto = NombreProducto;
    }

    public int getCantidadProductos() {
        return CantidadProductos;
    }

    public void setCantidadProductos(int CantidadProductos) {
        this.CantidadProductos = CantidadProductos;
    }

    public double getPrecioUnitario() {
        return PrecioUnitario;
    }

    public void setPrecioUnitario(double PrecioUnitario) {
        this.PrecioUnitario = PrecioUnitario;
    }

    public double getSubTotalSinIva() {
        return SubTotalSinIva;
    }

    public void setSubTotalSinIva(double SubTotalSinIva) {
        this.SubTotalSinIva = SubTotalSinIva;
    }

    public double getSubTotalConIva() {
        return SubTotalConIva;
    }

    public void setSubTotalConIva(double SubTotalConIva) {
        this.SubTotalConIva = SubTotalConIva;
    }
}
