using RestfulAPIProject.Models.Entities.Abstract;

namespace RestfulAPIProject.Models.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
