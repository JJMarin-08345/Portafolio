/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package Modelo;

/**
 *
 * @author USUARIO
 */
public class Mercancia {
   // Atributos 
    private int id;
    private String Categoria;
    private String Descripcion;
    private int Cantidad;
    
    // Metodos de la clase
    // Constructor por defecto
    public Mercancia(){
    }
    
    // Constructor con todos sus parametros
    public Mercancia(int id, String Categoria, String Descripcion, int Cantidad) {
        this.id = id;
        this.Categoria = Categoria;
        this.Descripcion = Descripcion;
        this.Cantidad = Cantidad;
    }

    // Metodos getter & setter
    
    public int getId() {
        return id;
    }
    
    public void setId(int id) {
        this.id = id;
    }
    
    public String getCategoria(){
        return this.Categoria;
    }
    
    public void setCategoria(String Categoria){
        this.Categoria = Categoria;
    }

    public String getDescripcion() {
        return Descripcion;
    }

    public void setDescripcion(String Descripcion) {
        this.Descripcion = Descripcion;
    }

    public int getCantidad() {
        return Cantidad;
    }

    public void setCantidad(int Cantidad) {
        this.Cantidad = Cantidad;
    }    
}
