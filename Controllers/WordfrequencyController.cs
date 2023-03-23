using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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

            //Read text from input request body
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.Default))
            {
                text = await reader.ReadToEndAsync();
            }
            WordFrequency wf = new WordFrequency();

            Dictionary<string, int> dictionary = wf.CalculateWords(text);        

            return new JsonResult(dictionary);
        }
    }
}
