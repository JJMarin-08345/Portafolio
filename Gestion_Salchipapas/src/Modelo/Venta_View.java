/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

import java.util.ArrayList;
import java.util.Date;

/**
 *
 * @author USUARIO
 */
//Esta clase es para las diferentes consultas que se hacen y almacenar diferentes datos
public class Venta_View {

    //Atributos
    private int Id_Venta;
    private Date Fecha_venta;
    private int Id_Producto;
    private String NombreProducto;
    private double PrecioProducto;
    private double PrecioTotal;
    private ArrayList<String> lstNombreProductos = new ArrayList<>();
    private ArrayList<Integer> lst_IdsProductos = new ArrayList<>();
    private ArrayList<Integer> lst_CantidadProductos = new ArrayList<>();

    //Constructor por defecto
    public Venta_View() {
    }

    public Venta_View(int id_venta, ArrayList<Integer> lstIdsProductos, ArrayList<Integer> lstCantidadProductos) {
        this.Id_Venta = id_venta;
        this.lst_IdsProductos = lstIdsProductos;
        this.lst_CantidadProductos = lstCantidadProductos;
    }

    //Por si solo necesitamos obtener el id de la venta y el Nombre del producto
    public Venta_View(int Id_Venta, String NombreProducto) {
        this.Id_Venta = Id_Venta;
        this.NombreProducto = NombreProducto;
    }

    //Por si solo necesitamos obtener el id de la venta, el precio total y la fecha
    public Venta_View(int Id_Venta, Date fecha_venta, double PrecioTotal) {
        this.Id_Venta = Id_Venta;
        this.Fecha_venta = fecha_venta;
        this.PrecioTotal = PrecioTotal;
    }

    //Por si solo necesitamos obtener el id de la venta, el precio total y la fecha
    public Venta_View(int Id_Venta, ArrayList<String> lstProductos, Date fecha_venta, double PrecioTotal) {
        this.Id_Venta = Id_Venta;
        this.Fecha_venta = fecha_venta;
        this.lstNombreProductos = lstProductos;
        this.PrecioTotal = PrecioTotal;
    }

    //Metodos getter & setter
    public int getId_Venta() {
        return Id_Venta;
    }

    public Date getFecha_venta() {
        return Fecha_venta;
    }

    public int getId_Producto() {
        return Id_Producto;
    }

    public String getNombreProducto() {
        return NombreProducto;
    }

    public double getPrecioProducto() {
        return PrecioProducto;
    }

    public double getPrecioTotal() {
        return PrecioTotal;
    }

    public ArrayList<String> getLstNombreProductos() {
        return lstNombreProductos;
    }

    public void setLstNombreProductos(ArrayList<String> lstNombreProductos) {
        this.lstNombreProductos = lstNombreProductos;
    }
}
