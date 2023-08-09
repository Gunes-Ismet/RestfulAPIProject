using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulAPIProject.Infrastructure.Repositories.Interfaces;
using RestfulAPIProject.Models.DTO_s.CategoryDTO_s;
using RestfulAPIProject.Models.Entities.Concrete;

namespace RestfulAPIProject.Controllers
{
    /*
        ProducesResponseType => Bir action methodu içerisinde bir çok dçnüş türü ve yolu bulunma ihtimali yüksektir. "ProducesResponseType" özniteliği kullanılarak farklı dönüş tiplerini Swagger gibi araçlara tarafında dökümantasyonlarında istemciler için daha açıklayıcı yanıt ayrıntıları üretir. 
     */
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // Swager UI aracılığı ile API üzerinde bazı testler yapmak isteyen geliştiriciler için bazı özet bilgiler ekliyoruzki ilgili geliştirici API'yi rahatlıkla test etsin. Yani API'nin yetenekleri hakkında açıklama yapıyoruz. İlgili Action methodun ne parametre aldığı ne iş yaptığı vb.

        /// <summary>
        /// Get list of categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GetCategoryDTO>))]
        public IActionResult GetCategory() 
        {
            var categories = _categoryRepository.GetCategories();
            var model = new List<GetCategoryDTO>();
            foreach (var category in categories) 
            {
                var categoryModel = _mapper.Map<GetCategoryDTO>(category);
                model.Add(categoryModel);
            }
            return Ok(model);
        }


        /// <summary>
        /// Get Category By Id
        /// </summary>
        /// <param name="id">The Id of Category</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get Category")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                var model = _mapper.Map<GetCategoryDTO>(category);
                return Ok(model);
            }
        }

        /*
         *  Action Methodlar
         *  
         *  1) From Body
         *  HTTP Request'inin body'si içerisinde gönderilen parametleri okumak için kullanılır.
         *  
         *  2) FromQuery
         *  Url içerisinde gömülen parametreleri okumak için kullanılan attribute'dür.
         *  
         *  3) FromRoute
         *  Endpoint url'i içerisinde gönderilen parametleri kumak için kullanılır. Yaygın olarak resource'a ait id bilgisi okunurken kullanılır.
         *  
         */


        /// <summary>
        /// Add The New Category
        /// </summary>
        /// <param name="model">In this process, CategoryName and Description does requiert fields!!</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateCategory([FromBody]CreateCategoryDTO model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }
            if (_categoryRepository.CategoryExists(model.Name))
            {
                ModelState.AddModelError("", "Bu kategori ismi zaten kullanılıyor!");
                return StatusCode(404, ModelState);
            }
            
            var category = _mapper.Map<Category>(model);
            var result = _categoryRepository.CategoryCreate(category);

            if (!result)
            {
                ModelState.AddModelError("", $"Bir şeyler ters gitti!\nKategori adı => {category.Name}\nAçıklaması=>{category.Description}");
                return StatusCode(500, ModelState);
            }
            return Ok(result);
        }

        /// <summary>
        /// Update Category
        /// </summary>
        /// <param name="model">In this process; Id, Name and Description does requiert fields</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDTO model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(model);
            var result = _categoryRepository.CategoryUpdate(category);

            if (!result)
            {
                ModelState.AddModelError("", "Bir şeyler ters gitti!");
                return StatusCode(500, ModelState);
            }

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            if (category == null)
            {
                return NotFound(ModelState);
            }

            var result = _categoryRepository.CategoryDelete(id);

            if (!result)
            {
                ModelState.AddModelError("", "Bir şeyler ters gitti");
            }

            return Ok("Kategori Silindi");

        }


    }
}
