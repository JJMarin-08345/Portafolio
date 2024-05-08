using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;

namespace Dominio{
    public class Deportista{
        public int Id {get;set;}

        //Requerimientos para campo Documento
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15)]
        [MinLength(7,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([0-9]+)",ErrorMessage="Digite solo numeros en este campo")]
        public string Documento {get;set;}

        //Requerimientos para campo Nombres
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombres {get;set;}

        //Requerimientos para campo Apellidos
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Apellidos {get;set;}

        //Requerimientos para campo Genero
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(10)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Genero {get;set;}

        //Requerimientos para campo Deporte
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20)]
        [MinLength(4,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Deporte {get;set;}

        //Requerimientos para campo FechaNacimiento
        [Required(ErrorMessage="Este campo es obligatorio")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento {get;set;}

        //Requerimientos para campo RH
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(3)]
        [MinLength(1,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Rh {get;set;}

        //Requerimientos campo Eps
        [MaxLength(30)]
        [MinLength(5,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Eps {get;set;}

        //Requerimientos campo Celular
        [Required(ErrorMessage="Este campo es obligatio")]
        [MaxLength(15)]
        [MinLength(10,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        [RegularExpression("([0-9]+)",ErrorMessage="Por favor digite solo números")]
        [Range(3000000000,3509999999, ErrorMessage="Ingrese un número de celular válido")]
        public string Celular {get;set;}

        //Requerimientos campo Correo
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(10,ErrorMessage="El campo {0} debe tener mínimo {1} caracteres")]
        public string Correo {get;set;}

        //LLAVES FORANEAS
        [Required(ErrorMessage="Un deportista debe esta en un equipo")]
        public int EquipoId {get;set;}//Relacion con tabla Equipo
        public Equipo equipo {get;set;}//Propiedad navigacional

    }
}