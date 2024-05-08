using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Dominio{
    public class Entrenador{
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int Id {get;set;}

        //Requerimientos para el campo Documento
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20)]
        [MinLength(7,ErrorMessage="El campo {0} debe tener mínimo {1} caractéres")]
        [RegularExpression("([0-9]+)", ErrorMessage="El campo {0} solo acepta valores numericos")]
        public string Documento {get;set;}

        //Requerimientos para el campo Nombres
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(3, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombres {get;set;}

        //Requerimientos para campo apellido
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30, ErrorMessage="El campo {0} debe ser máximo de {1} caracteres")]
        [MinLength(3, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Apellidos {get;set;}

        //Requerimientos para campo Deporte
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30)]
        [MinLength(4,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Deporte {get;set;}

        //Requerimientos campo Celular
        [Required(ErrorMessage="Este campo es obligario")]
        [MaxLength(15)]
        [MinLength(10,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([0-9]+)", ErrorMessage="Por favor digite solo números")]
        [Range(3000000000,3509999999, ErrorMessage="Ingrese un número de celular válido")]
        public string Celular {get;set;}

        //Requerimientos campo correo
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(50)]
        [MinLength(10,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Correo {get;set;}

        //Llaves foraneas
        [Required(ErrorMessage="Un entrenador debe tener asignado un equipo")]
        public int EquipoId {get;set;}
        public Equipo equipo {get;set;}//Propiedad navigacional
    }
}