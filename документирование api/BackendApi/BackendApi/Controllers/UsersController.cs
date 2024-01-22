using BackendApi.Contracts.User;
using BackendApi.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public dbapiContext Context { get; }

        public UsersController(dbapiContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Плучение всех записей пользователей 
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll() //получение всех записей 
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }


        /// <summary>
        /// Получение записи пользователя по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         Id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")] // получение одной записи по id
        public IActionResult GetById(int id)
        {
            User user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Не найдено");
            }
            return Ok(user);
        }



        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         "roleId": 1,
        ///         "username": "Hukkatir",
        ///         "userPassword": "12345",
        ///         "email": "Hukkatir@gmail.com",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>


        [HttpPost]
        public IActionResult Add(CreateUserRequest request) //добавление записей 
        {
            var userDto = request.Adapt<User>();

            Context.Users.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }





        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     {
        ///         "roleId": 1,
        ///         "username": "Hukkatir",
        ///         "userPassword": "12345",
        ///         "email": "Hukkatir@gmail.com",
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-21T18:57:41.342Z"
        ///     }
        ///
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(CreateUserRequest request) //Обновление данных (Изменение существующей записи)
        {
            var userDto = request.Adapt<User>();
            Context.Users.Update(userDto);
            Context.SaveChanges();
            return Ok(userDto);
        }



        /// <summary>
        /// Удаление данных пользователя по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     {
        ///         Id": 6
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            User? user = Context.Users.Where(x => x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Не найдено");

            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
