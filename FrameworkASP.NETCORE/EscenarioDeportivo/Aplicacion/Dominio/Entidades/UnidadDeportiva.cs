using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Dominio{
    public class UnidadDeportiva{
        [Required(ErrorMessage="Este campo es obligatorio")]
        public int Id {get;set;}
        //Requerimientos campo Nombre
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(5,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Nombre {get;set;}

        //Requerminentos campo Direccion
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(60)]
        [MinLength(5,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Direccion {get;set;}

        //Requerimientos campo Ciudad
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(25)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        [RegularExpression("([A-Za-z ]*)", ErrorMessage="El campo {0} no acepta valores numericos")]
        public string Ciudad {get;set;}

        //Llaves foraneas
        public int? TorneoId {get;set;}//Puede ser nulo
        public Torneo torneo {get;set;}
        //Llave foranea
        public List<Escenario> Escenarios {get;set;}

    }
}
