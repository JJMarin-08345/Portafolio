/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

/**
 *
 * @author USUARIO
 */
public class Ventas_Productos {
    //Clase relacion muchos a muchos
    //Atributos
    private int id_venta;
    private int id_producto;
    private int cantidad;
    //Constructor por defecto
    public Ventas_Productos(){
    }
    
    //Este constructor es para manejar arreglos
    public Ventas_Productos(int id_producto, int cantidad){    
        this.id_producto = id_producto;
        this.cantidad = cantidad;
    }
    // Metodos getter & setter

    public int getId_venta() {
        return id_venta;
    }

    public void setId_venta(int id_venta) {
        this.id_venta = id_venta;
    }

    public int getId_producto() {
        return id_producto;
    }

    public void setId_producto(int id_producto) {
        this.id_producto = id_producto;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }    
}
