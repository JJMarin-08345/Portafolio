package Modelo;

/**
 *
 * @author USUARIO
 */
import java.awt.HeadlessException;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import javax.swing.JOptionPane;

public class Conexion {

    //Atributos
    protected Connection con; //Almacenar una cadena de conexion
    protected PreparedStatement ps;//Almacenar sentencia sql
    protected ResultSet rs;//Almacenar retornos desde la base de datos
    private final String url="jdbc:mysql://localhost:3306/gestionsalchipapas";
    private final String user="root";
    private final String password="";

    //Metodos
    //Constructor x defecto
    public Conexion() {
    }

    public Connection getConnection() {
    	try {
    		Class.forName ("com.mysql.cj.jdbc.Driver");
            this.con = DriverManager.getConnection(url,user,password);
        	//JOptionPane.showMessageDialog(null,"Conectado con exito");
        } catch (HeadlessException  | ClassNotFoundException | SQLException e) {
            System.out.println("ERROR: " + e.getLocalizedMessage() + "\n" + e.getMessage());
            JOptionPane.showMessageDialog(null, "Error de conexion con el servidor o servidor desconectado\n" + e.getMessage());
            this.con = null;
        }
    	return this.con;    
    }

}
