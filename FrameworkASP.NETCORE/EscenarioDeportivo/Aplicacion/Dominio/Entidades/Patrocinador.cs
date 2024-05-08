using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio
{
    public class Patrocinador
    {
        public int Id {get;set;}

        //Requerimientos para el campo Documento
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15)]//No le pondré mensaje porque permite en la 
                        //página web no deja escribir más de estos caracteres 
        [MinLength(7,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        [RegularExpression("([0-9]*)", ErrorMessage="El campo {0} solo acepta valores numericos")]
        public string Documento {get;set;}

        //Requerimientos para el campo Nombres
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(3,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombres {get;set;}

        //Requerimientos para el campo Deporte
        [MaxLength(30)]
        [MinLength(3,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        public string? Deporte {get;set;}//Puede ser nulo

        //Requerimientos para campo Direccion
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(5,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        public string Direccion {get;set;}

        //Requerimientos campo telefono
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(16)]//Por si lo escribe con espacios y con el sufijo "+57"
        [MinLength(10,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        [RegularExpression("([0-9]+)",ErrorMessage="El campo {0} solo acepta valores numericos")]
        [Range(3000000000,3509999999, ErrorMessage="Digite un número de teléfono válido")]
        public string Telefono {get;set;}

        //Requerimientos para campo Ciudad
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15)]
        [MinLength(3,ErrorMessage="El campo {0} debe ser mínimo de {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Ciudad {get;set;}

        //Requerimientos para campo Personeria
        [Required(ErrorMessage="Este campo es obligatorio")]
        public bool Personeria {get;set;}

        //Para las relaciones
        public List<Equipo> Equipos {get;set;}=new List<Equipo>();
        public List<Torneo> Torneos {get;set;}=new List<Torneo>();
    }
}