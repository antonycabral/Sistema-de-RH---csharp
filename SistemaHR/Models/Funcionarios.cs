using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SistemaHR.Models
{
    public class Funcionarios
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public string Cargo { get; set; } = string.Empty;
        [Required(ErrorMessage = "O salario não pode ser nulo")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero.")]
        [Precision(18, 2)]
        public decimal Salario { get; set; }
        [Required(ErrorMessage = "CPF não pode estar em branco")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF em formato inválido")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Data de nascimento não pode ser nula")] // @NotNull
        [DataType(DataType.Date)]
        public DateOnly DataNascimento { get; set; }

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail deve ser válido")]
        public string Email { get; set; }
        
    }
}
