using BackendApi.Contracts.Blocks;
using BackendApi.Contracts.Role;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class BlocksController : ControllerBase
    {
        public dbapiContext Context { get; }

        public BlocksController(dbapiContext context)
        {
            Context = context;
        }
        
        /// <summary>
        /// Получение всех записей блоков
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Block> blocks = Context.Blocks.ToList();
            return Ok(blocks);
        }


        /// <summary>
        /// Получение записи блока по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Block blocks = Context.Blocks.Where(x => x.BlockId == id).FirstOrDefault();
            if (blocks == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(blocks);
        }


        /// <summary>
        /// Создание записи блока
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "authorId": 1,
        ///         "categoryId": 1,
        ///         "blockName": "новость",
        ///         "title": "супер заголовок",
        ///         "textBlock": "супер текст",
        ///         "indexBlock": 1,
        ///         "blockTypeId": 1,
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T15:35:24.093"
        ///     }
        ///
        /// </remarks>
        /// <param name="blocks"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Add(CreateBlockRequest request) //добавление записей 
        {
            var blockDto = request.Adapt<Block>();
            Context.Blocks.Add(blockDto);
            Context.SaveChanges();
            return Ok(blockDto);
        }

        /// <summary>
        /// Обновление данных блока 
        /// </summary>
        /// <param name="blocks"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateBlockRequest request) //Обновление данных (Изменение существующей записи)
        {
            var blockDto = request.Adapt<Block>();
            Context.Blocks.Update(blockDto);
            Context.SaveChanges();
            return Ok(blockDto);
        }

        /// <summary>
        /// Удаление записи блока по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Block? blocks = Context.Blocks.Where(x => x.BlockId == id).FirstOrDefault();
            if (blocks == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Blocks.Remove(blocks);
            Context.SaveChanges();
            return Ok(blocks);
        }
    }
}
 
