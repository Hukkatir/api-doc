using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace BackendApi.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }

        public string Location { get; set; }

    }



    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData() { Id = 1, Date = "21.01.2022", Degree = 10, Location = "Мурманск" },
            new WeatherData() { Id = 23, Date = "10.08.2019", Degree = 20, Location = "Пермь" },
            new WeatherData() { Id = 24, Date = "05.11.2020", Degree = 15, Location = "Омск" },
            new WeatherData() { Id = 25, Date = "07.02.2021", Degree = 0, Location = "Томск" },
            new WeatherData() { Id = 30, Date = "30.05.2022", Degree = 3, Location = "Калининград" },
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherData> Get()
        {
            return weatherDatas; //возвращение всех записей слов
        }


        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id не может быть меньше 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id) //в случае если индентификаторы одинаковые - выполни следующее
                {
                    return BadRequest("Запись с таким id уже есть");
                }
            }

            weatherDatas.Add(data);
            return Ok();
        }


        [HttpPut]

        public IActionResult Update(WeatherData data)
        {
            if (data.Id < 0)
            {
                return BadRequest("Id не может быть меньше 0");
            }

            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id) //в случае если индентификаторы одинаковые - выполни следующее
                {
                    weatherDatas[i] = data; // заменяем знаечние для данной ячейки массива
                    return Ok();
                }
            }

            return BadRequest("Такая запись не обнаружена");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i); //удаляем элемент из массива по его индексу (i)
                    return Ok();
                }
            }

            return BadRequest("Такая запись не обнаружена");

        }


        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Такая запись не обнаружена");
        }


        [HttpGet("check/{location}")]
        public IActionResult CheckLocation(string location)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Location == location)
                {
                    return Ok("Запись с указанным городом имеется в нашем списке");
                }
            }

            return Ok("Запись с указанным городом не обнаружено");
        }



    }

}