using BackendApi.Contracts.BlockType;
using BackendApi.Contracts.User;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockTypeController : ControllerBase
    {
        public dbapiContext Context { get; }

        public BlockTypeController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<BlockType> blockTypes = Context.BlockTypes.ToList();
            return Ok(blockTypes);
        }
        /// <summary>
        /// Получение записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            BlockType blockTypes = Context.BlockTypes.Where(x => x.BlockTypeId == id).FirstOrDefault();
            if (blockTypes == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(blockTypes);
        }

        /// <summary>
        /// Создание новой записи типа блока
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "blockId": 4,
        ///         "textTypeId": 4,
        ///         "videoId": 3,
        ///         "imageId": 4
        ///     }
        /// 
        /// </remarks>
        /// <param name="blockTypes"></param>
        /// <returns></returns>
    [HttpPost]
        public IActionResult Add(CreateBlockTypeRequest request) //добавление записей 
        {
            var blockTyprDto = request.Adapt<BlockType>();
            Context.BlockTypes.Add(blockTyprDto);
            Context.SaveChanges();
            return Ok(blockTyprDto);
        }

        /// <summary>
        /// Обновление дынных записи 
        /// </summary>
        /// <param name="blockTypes"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateBlockTypeRequest request) //Обновление данных (Изменение существующей записи)
        {
            var blockTyprDto = request.Adapt<BlockType>();
            Context.BlockTypes.Update(blockTyprDto);
            Context.SaveChanges();
            return Ok(blockTyprDto);
        }

        /// <summary>
        /// Удаление записи типа блока по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BlockType? blockTypes = Context.BlockTypes.Where(x => x.BlockTypeId == id).FirstOrDefault();
            if (blockTypes == null)
            {
                return BadRequest("Не найдено");

            }
            Context.BlockTypes.Remove(blockTypes);
            Context.SaveChanges();
            return Ok(blockTypes);
        }
    }
}
