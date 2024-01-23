using BackendApi.Contracts.Role;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        public dbapiContext Context { get; }

        public RoleController(dbapiContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех записей ролей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll() //получение всех записей 
        {
            List<Role> roles = Context.Roles.ToList();
            return Ok(roles);
        }

        /// <summary>
        /// Получениие записи по id роли
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            Role roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(roles);
        }
        /// <summary>
        /// Добавление новой роли 
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        /// 
        ///     {
        ///         "roleName": "Администратор",
        ///         "descrip": "Следит за контентом на сайте",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T20:44:29.278Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPost]

        public IActionResult Add(CreateRoleRequest request) //добавление записей 
        {
            var roleDto = request.Adapt<Role>();
            Context.Roles.Add(roleDto);
            Context.SaveChanges();
            return Ok(roleDto);
        }

        /// <summary>
        /// Обновление данных роли 
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateRoleRequest request) //Обновление данных (Изменение существующей записи)
        {
            var roleDto = request.Adapt<Role>();
            Context.Roles.Update(roleDto);
            Context.SaveChanges();
            return Ok(roleDto);
        }
        /// <summary>
        /// Удаление роли по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Role? roles = Context.Roles.Where(x => x.RoleId == id).FirstOrDefault();
            if (roles == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Roles.Remove(roles);
            Context.SaveChanges();
            return Ok(roles);
        }
    }
}
