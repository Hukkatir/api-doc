using BackendApi.Contracts.Category;
using BackendApi.Contracts.User;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        public dbapiContext Context { get; }

        public CategoryController(dbapiContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Получение всех записей категорий
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Category> categories = Context.Categories.ToList();
            return Ok(categories);
        }

        /// <summary>
        /// Получение записи категориии по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Category categories = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (categories == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(categories);
        }


        /// <summary>
        /// Создание новой записи категории
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "categoryName": "Новость",
        ///         "descrip": "Новости из мира кино",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="categories"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateCategoryRequest request) //добавление записей 
        {
            var categoryDto = request.Adapt<Category>();
            Context.Categories.Add(categoryDto);
            Context.SaveChanges();
            return Ok(categoryDto);
        }

        /// <summary>
        /// Обновление данных категорий
        /// </summary>
        /// <param name="categories"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateCategoryRequest request) //Обновление данных (Изменение существующей записи)
        {
            var categoryDto = request.Adapt<Category>();
            Context.Categories.Update(categoryDto);
            Context.SaveChanges();
            return Ok(categoryDto);
        }

        /// <summary>
        /// Удаление записи категории по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Category? categories = Context.Categories.Where(x => x.CategoryId == id).FirstOrDefault();
            if (categories == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Categories.Remove(categories);
            Context.SaveChanges();
            return Ok(categories);
        }
    }
}
