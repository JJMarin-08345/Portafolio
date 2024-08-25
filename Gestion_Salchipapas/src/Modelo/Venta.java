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
public class Venta {
    //Atributos
    private int Id;
    private String id_usuario;
    private Date fecha_venta;
    
    //Contructor por defecto 
    public Venta(){
    }

    public Venta(int Id, String id_usuario, Date fecha_venta) {
        this.Id = Id;
        this.id_usuario = id_usuario;
        this.fecha_venta = fecha_venta;
    }
    
    //Metodos getter & setter
    public int getId() {
        return Id;
    }

    public void setId(int Id) {
        this.Id = Id;
    }

    public String getId_usuario() {
        return id_usuario;
    }

    public void setId_usuario(String id_usuario) {
        this.id_usuario = id_usuario;
    }

    public Date getFecha_venta() {
        return fecha_venta;
    }

    public void setFecha_venta(Date fecha_venta) {
        this.fecha_venta = fecha_venta;
    }
}
