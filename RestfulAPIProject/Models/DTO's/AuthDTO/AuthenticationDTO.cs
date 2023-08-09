using System.ComponentModel.DataAnnotations;

namespace RestfulAPIProject.Models.DTO_s.AuthDTO
{
    public class AuthenticationDTO
    {
        [Required(ErrorMessage = "Bu alan zorunludur!!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alacan zorunludur!!")]
        public string Password { get; set; }
    }
}
