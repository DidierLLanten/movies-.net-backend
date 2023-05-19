using System.ComponentModel.DataAnnotations;

namespace back_end.Entidades
{
    public class Genero
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El campo {0} es requerido")]
        [StringLength(maximumLength:8, ErrorMessage ="El campo {0} acepta maximo 10 caracteres")]
        public String? Nombre { get; set; }
    }
}
