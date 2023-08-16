using back_end.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace back_end.DTOs
{
    public class GeneroCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, ErrorMessage = "El campo {0} acepta maximo 8 caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
    }
}
