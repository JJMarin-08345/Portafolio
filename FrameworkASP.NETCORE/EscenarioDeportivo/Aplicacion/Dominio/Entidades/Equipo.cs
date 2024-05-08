using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio{
    public class Equipo{
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int Id {get;set;}

        //Requerimientos campo Nombre
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(25)]
        [MinLength(5, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombre {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(25)]
        [MinLength(3, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        public string Deporte {get;set;}

        public Entrenador? Tecnico {get;set;} 
        //Este no aparece en la base de datos mega F

        //Requerimientos campo Jugadores
        [Required(ErrorMessage="Este campo es obligatorio")]
        [RegularExpression("([0-9])", ErrorMessage="Ingrese números mayores a 0")]
        [Range(1, 30,ErrorMessage="Demasiados jugadores para un equipo")]
        public int Jugadores {get;set;}
        
        //Requerimientos campo PatrocinadorId
        [Required(ErrorMessage="Un equipo debe estar patrocinado por al menos una marca")]
        public int PatrocinadorId {get;set;}
        public Patrocinador patrocinador {get;set;}//Propiedad navigacional
        
        //Llave foranea
        public List<TorneoEquipo> TorneosEquipo {get;set;}=new List<TorneoEquipo>();//Para relacion muchos a muchos
        public List<Deportista> Deportistas {get;set;} = new List<Deportista>();
    }
}