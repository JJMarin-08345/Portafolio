/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

/**
 *
 * @author USUARIO
 */
public class Producto {
    private int id;
    private String nombre;
    private String descripcion;
    private double precio;
    
    
    // Método para representar el objeto en forma de texto
    @Override
    public String toString() {
        return "Nombre: " + nombre + ", Descripción: " + descripcion + ", Precio: " + precio;
    }
    
    // Constructor base
    public Producto(){
    }
    
    // Constructor de la clase Producto 
    public Producto(int id, String nombre, String descripcion, double precio) {
        this.id = id;
        this.nombre = nombre;
        this.descripcion = descripcion;
        this.precio = precio;
    }

    // Getters y setters para acceder y establecer los atributos
    
    // Método para obtener el id del producto
    public int getId() {
        return id;
    }
    
    // Método para obtener el nombre del producto
    public String getNombre() {
        return nombre;
    }
    // Método para establecer el nombre del producto
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    // Método para obtener la descripción del producto
    public String getDescripcion() {
        return descripcion;
    }
    // Método para establecer la descripción del producto
    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }
    // Método para obtener el precio del producto
    public double getPrecio() {
        return precio;
    }
    // Método para establecer el precio del producto
    public void setPrecio(double precio) {
        this.precio = precio;
    }
    
}
