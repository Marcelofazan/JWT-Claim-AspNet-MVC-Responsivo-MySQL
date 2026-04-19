using System.ComponentModel.DataAnnotations;

namespace ERPSimplesLTE.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Senha { get; set; }

    }
}
