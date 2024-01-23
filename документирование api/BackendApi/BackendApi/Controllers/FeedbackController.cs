using BackendApi.Contracts.Feedback;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        public dbapiContext Context { get; }

        public FeedbackController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получений всех записей реакций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Feedback> feedbacks = Context.Feedbacks.ToList();
            return Ok(feedbacks);
        }

        /// <summary>
        /// Получение записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Feedback feedbacks = Context.Feedbacks.Where(x => x.FeedbackId == id).FirstOrDefault();
            if (feedbacks == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(feedbacks);
        }

        /// <summary>
        /// Создание записи реакции
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "userId": 1,
        ///         "blockId": 1,
        ///         "likes": true,
        ///         "likesCount": 25
        ///     }
        ///     
        /// </remarks>
        /// <param name="feedbacks"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Add(CreateFeedbackRequest request) //добавление записей 
        {
            var feedbackDto = request.Adapt<Feedback>();
            Context.Feedbacks.Add(feedbackDto);
            Context.SaveChanges();
            return Ok(feedbackDto);
        }

        /// <summary>
        /// Обновление данных 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateFeedbackRequest request) //Обновление данных (Изменение существующей записи)
        {
            var feedbackDto = request.Adapt<Feedback>();
            Context.Feedbacks.Update(feedbackDto);
            Context.SaveChanges();
            return Ok(feedbackDto);
        }

        /// <summary>
        /// Удаление данных по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Feedback? feedbacks = Context.Feedbacks.Where(x => x.FeedbackId == id).FirstOrDefault();
            if (feedbacks == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Feedbacks.Remove(feedbacks);
            Context.SaveChanges();
            return Ok(feedbacks);
        }
    }
}

