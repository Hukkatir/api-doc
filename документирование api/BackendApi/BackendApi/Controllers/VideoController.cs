using BackendApi.Contracts.Category;
using BackendApi.Contracts.Video;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        public dbapiContext Context { get; }

        public VideoController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех видео записей 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Video> videos = Context.Videos.ToList();
            return Ok(videos);
        }

        /// <summary>
        /// Получени езаписи видео по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Video videos = Context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if (videos == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(videos);
        }


        /// <summary>
        /// Создание записи видео 
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        /// 
        ///     {
        ///         "blockId": 1,
        ///         "videoUrl": "https://youtu.be/cxr3b_Gzmls?si=9HN4fiOKZ0IVqRi_",
        ///          "note": "Почему «Оппенгеймер», кажется, главный фильм года"
        ///     }
        ///     
        /// </remarks>
        /// <param name="videos"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Add(CreateVideoRequest request) //добавление записей 
        {

            var videoDto = request.Adapt<Video>();
            Context.Videos.Add(videoDto);
            Context.SaveChanges();
            return Ok(videoDto);
        }

        /// <summary>
        /// Обновление данных 
        /// </summary>
        /// <param name="videos"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateVideoRequest request) //Обновление данных (Изменение существующей записи)
        {
            var videoDto = request.Adapt<Video>();
            Context.Videos.Update(videoDto);
            Context.SaveChanges();
            return Ok(videoDto);
        }

        /// <summary>
        /// Удаление записи видео по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Video? videos = Context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if (videos == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Videos.Remove(videos);
            Context.SaveChanges();
            return Ok(videos);
        }
    }
}
