using back_end.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Genero : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, ErrorMessage = "El campo {0} acepta maximo 8 caracteres")]
        //[PrimeraLetraMayuscula]
        public string? Nombre { get; set; }

        // Validacion para la primera letra debe ser mayuscuala 2 forma de hacerlo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var primeraLetra = Nombre[0].ToString();
                if (primeraLetra != primeraLetra.ToUpper())
                {
                    yield return new ValidationResult("The first letter must be Capital Letter", new String[] { nameof(Nombre) });
                }
            }
        }
    }
}
