using System.ComponentModel.DataAnnotations;

namespace RestfulAPIProject.Models.DTO_s.CategoryDTO_s
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur!!")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakter olmak zorunda!!")]
        [RegularExpression(@"^[a-zA-Z- ]+$", ErrorMessage = "Sadece harf girebilirsiniz!!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori açıklaması zorunludur!!")]
        [MinLength(3, ErrorMessage = "Minimum 3 karakter olmak zorunda!!")]
        public string Description { get; set; }
    }
}
