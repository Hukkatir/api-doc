using BackendApi.Contracts.Comments;
using BackendApi.Contracts.TextType;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public dbapiContext Context { get; }

        public CommentsController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей комментариев
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Comment> comments = Context.Comments.ToList();
            return Ok(comments);
        }

        /// <summary>
        /// Получение комментария по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Comment comments = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comments == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(comments);
        }

        /// <summary>
        /// Создание нового комментария
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     { 
        ///         "userId": 1,
        ///         "blockId": 1,
        ///         "textComment": "Крутая новость!",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-22T10:05:04.324Z
        ///     }
        /// 
        /// </remarks>
        /// <param name="comments"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateCommentsRequest request) //добавление записей 
        {
            var commentDto = request.Adapt<Comment>();
            Context.Comments.Add(commentDto);
            Context.SaveChanges();
            return Ok(commentDto);
        }


        /// <summary>
        /// Обновление данных комментариев
        /// </summary>
        /// <param name="comments"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateCommentsRequest request) //Обновление данных (Изменение существующей записи)
        {
            var commentDto = request.Adapt<Comment>();
            Context.Comments.Update(commentDto);
            Context.SaveChanges();
            return Ok(commentDto);
        }

        /// <summary>
        /// Удаление комментария по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Comment? comments = Context.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            if (comments == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Comments.Remove(comments);
            Context.SaveChanges();
            return Ok(comments);
        }
    }
}
