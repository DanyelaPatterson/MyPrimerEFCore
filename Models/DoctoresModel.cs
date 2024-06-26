using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Students_POO2.Models
{
    public class DoctoresModel
    {   
        public DoctoresModel()
        {

        }
        
        public Guid Id {get; set;}
        
        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [StringLength(maximumLength: 40, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe ser entre mínimo {2} y máximo de {1}")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El {0} es un campo requerido")]
        [StringLength(maximumLength: 40, MinimumLength = 3, ErrorMessage = "La longitud del campo {0} debe ser entre mínimo {2} y máximo de {1}")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "La {0} es un campo requerido")]
        [Range(23, 75, ErrorMessage = "La edad debe estar entre {1} y {2}")]
        public int Age { get; set; }

        [Required(ErrorMessage = "La {0} es un campo requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe ser entre mínimo {2} y máximo de {1}")]
        public string? specialism { get; set; }

        public int Tel { get; set; }

        public long Cel { get; set; }

        [Required(ErrorMessage = "La {0} es un campo requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 5, ErrorMessage = "La longitud del campo {0} debe ser entre mínimo {2} y máximo de {1}")]
        public string? address { get; set; }
    }
}