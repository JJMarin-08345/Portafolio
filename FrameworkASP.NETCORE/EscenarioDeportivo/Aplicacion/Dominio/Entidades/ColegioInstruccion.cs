using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio{
    public class ColegioInstruccion{
        public int Id {get;set;}
        //Requerimientos campo Nit
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15)]
        [MinLength(7,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        [RegularExpression("([0-9]+)",ErrorMessage="Ingrese un  valor numérico")]
        public string Nit {get;set;}

        //Requerimientos campo RazonSocial
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(4,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string RazonSocial {get;set;}

        //Requerimientos campo Direccion
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(60)]
        [MinLength(5,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Direccion {get;set;}

        //Requerimientos campo telefono
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20)]
        [MinLength(6,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        [RegularExpression("([0-9]+)",ErrorMessage="Ingrese un  valor numérico")]
        [Range(3000000000,3509999999, ErrorMessage="Digite un número de teléfono válido")]
        public string Telefono {get;set;}

        //Requerimientos campo Deporte
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(40)]
        [MinLength(3,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Deporte {get;set;}

        //Requerimientos campo Licencia
        [Required(ErrorMessage="Este campo es obligatotio")]
        [MaxLength(60)]
        [MinLength(4,ErrorMessage="El campo {0} debe tener mínimo de {1} caracteres")]
        public string Licencia {get;set;}

        //Relaciones
        public List<Arbitro> Arbitros {get;set;}=new List<Arbitro>();
    }
}