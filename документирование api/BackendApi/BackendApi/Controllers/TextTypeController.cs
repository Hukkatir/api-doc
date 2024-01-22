using BackendApi.Contracts.TextType;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextTypeController : ControllerBase
    {
        public dbapiContext Context { get; }

        public TextTypeController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей текста 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<TextType> textTypes = Context.TextTypes.ToList();
            return Ok(textTypes);
        }

        /// <summary>
        /// ПОлучение записи текста по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            TextType textTypes = Context.TextTypes.Where(x => x.TextTypeId == id).FirstOrDefault();
            if (textTypes == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(textTypes);
        }


        /// <summary>
        /// Слоздание записи текста 
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {   "blockId": 1,
        ///         "content": "Этот текст написан курсивом",
        ///         "bold": false,
        ///         "italic": true,
        ///         "strikethrough": false,
        ///         "underline": false,
        ///         "code": false,
        ///         "color": "green"
        ///     }
        /// 
        /// </remarks>
        /// <param name="textTypes"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateTextTypeRequest request) //добавление записей 
        {
            var textTyprDto = request.Adapt<TextType>();
            Context.TextTypes.Add(textTyprDto);
            Context.SaveChanges();
            return Ok(textTyprDto);
        }

        /// <summary>
        /// Обновление данных текста
        /// </summary>
        /// <param name="textTypes"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateTextTypeRequest request) //Обновление данных (Изменение существующей записи)
        {
            var textTyprDto = request.Adapt<TextType>();
            Context.TextTypes.Update(textTyprDto);
            Context.SaveChanges();
            return Ok(textTyprDto);
        }

        /// <summary>
        /// Удаление записи типа текста
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            TextType? textTypes = Context.TextTypes.Where(x => x.TextTypeId == id).FirstOrDefault();
            if (textTypes == null)
            {
                return BadRequest("Не найдено");

            }
            Context.TextTypes.Remove(textTypes);
            Context.SaveChanges();
            return Ok(textTypes);
        }
    }
}
