using BackendApi.Contracts.Image;
using BackendApi.Contracts.Video;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        public dbapiContext Context { get; }

        public ImagesController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей фотографий 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Image> images = Context.Images.ToList();
            return Ok(images);
        }

        /// <summary>
        /// Получение записи фото по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Image images = Context.Images.Where(x => x.ImageId == id).FirstOrDefault();
            if (images == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(images);
        }

        /// <summary>
        /// Создание новой записи фото 
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        /// 
        ///     {
        ///         "blockId": 1,
        ///         "imageUrl": "https://www.nme.com/wp-content/uploads/2023/04/Pedro-Pascal@2000x1270.jpg",
        ///         "note": "Педро Паскаль на золотом глобусе 2024"
        ///     }
        ///     
        /// </remarks>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateImageRequest request) //добавление записей 
        {

            var imageDto = request.Adapt<Image>();
            Context.Images.Add(imageDto);
            Context.SaveChanges();
            return Ok(imageDto);
        }

        /// <summary>
        /// Обновление данных записей 
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateImageRequest request) //Обновление данных (Изменение существующей записи)
        {
            var imageDto = request.Adapt<Image>();
            Context.Images.Update(imageDto);
            Context.SaveChanges();
            return Ok(imageDto);
        }

        /// <summary>
        /// Удаление записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Image? images = Context.Images.Where(x => x.ImageId == id).FirstOrDefault();
            if (images == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Images.Remove(images);
            Context.SaveChanges();
            return Ok(images);
        }
    }
}
