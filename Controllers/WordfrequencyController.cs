using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WordFrequency.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WordfrequencyController : ControllerBase
    {
        [HttpPost]
        public async Task<JsonResult> Post()
        {
            string text;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                text = await reader.ReadToEndAsync();
            }
            WordFrequency wf = new WordFrequency();

            Console.WriteLine(text);

            Dictionary<string, int> dictionary = wf.CalculateWords(text);

            return new JsonResult(dictionary);
        }
    }
}
