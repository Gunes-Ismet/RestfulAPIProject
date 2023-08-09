using RestfulAPIProject.Models.Entities.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestfulAPIProject.Models.Entities.Concrete
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        [NotMapped] // DB'de bununla alakalı bir sütun açma.
        public string Token { get; set; }
    }
}
