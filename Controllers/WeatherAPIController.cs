using LR5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics.Metrics;
using System.Net;
using System.Text.Json;

namespace LR5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherAPIController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q=,&appid=a28598d19e603a2c376487760c42e48b&units=metric";
            var client = new HttpClient();
            var response = await client.GetAsync(url);


            try
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.status = (int)response.StatusCode;
                responseModel.response = await response.Content.ReadAsStringAsync();
                responseModel.headers = response.Headers.ToString();
                Console.WriteLine(responseModel.ToString());
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500);
            }

            return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
        }

        [HttpPost] //Yes, doing "Post" to Get...
        public async Task<IActionResult> Post(string city, string country)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city},{country}&appid=a28598d19e603a2c376487760c42e48b&units=metric";
            var client = new HttpClient();
            var response= await client.GetAsync(url);

            try
            {
                ResponseModel responseModel = new ResponseModel();
                responseModel.status = (int)response.StatusCode;
                responseModel.response = await response.Content.ReadAsStringAsync();
                responseModel.headers = response.Headers.ToString();
                Console.WriteLine(responseModel.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());  
                return StatusCode(500);
            }

            return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync());
        }
    }
}