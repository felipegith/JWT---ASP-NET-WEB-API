using System.ComponentModel.DataAnnotations;

namespace Jesstw.Model
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "A sua senha deve ter no mínimo 8 caracteres pelo menos uma letra e um número")]
        public string Password { get; set; }
    }
}
