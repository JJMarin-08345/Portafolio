using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Dominio{
    public class Escenario{
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int Id {get;set;}
        //Requerimientos campo Nombre
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(30)]
        [MinLength(5, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombre {get;set;}

        //Requerimientos campo espectadores
        [Required(ErrorMessage="Este campo es obligatorio")]
        [Range(0, 1000000000,ErrorMessage="Ingrese un valor correcto")]
        public int Espectadores {get;set;}

        //Requerimientos campo Tipo
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20)]
        [MinLength(5, ErrorMessage="El campo {0} debe tener minimo {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Tipo {get;set;}
        
        [Required(ErrorMessage="El escenario debe pertenecer a una Unidad Deportiva")]
        public int UnidadDeportivaId {get;set;} 
        public UnidadDeportiva UniDepor {get;set;}
    }
}