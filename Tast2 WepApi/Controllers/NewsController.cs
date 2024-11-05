using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Tast2_WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        static List<News> News = new List<News>() {
            new News { id = 1, title = "paper", description = "paper", author = "Ali" },
            new News { id = 2, title = "AA", description = "AA", author = "Ali" },
            new News { id = 3, title = "Shcool", description = "Shcool", author = "Mohamed" },
            new News { id = 4, title = "paper4", description = "paper4", author = "Ali" },
            new News { id = 5, title = "paper5", description = "paper5", author = "Mona" },
            new News { id = 6, title = "paper6 A", description = "paper6", author = "Ali" },

        };
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(News);
        }
        [HttpGet("{title:alpha}")]
        public IActionResult GetbyTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                return BadRequest();
            var n = News.Where(x=>x.title==title).FirstOrDefault();
            if (n == null)
                return NotFound();
            return Ok(n);
        }
        [HttpGet("Author/{author:alpha}")]
        
        public IActionResult Getbyauther(string author)
        {
            if (string.IsNullOrEmpty(author))
                return BadRequest();
            var n = News.Where(x => x.author == author).ToList();
            if (n == null)
                return NotFound();
            return Ok(n);
        }
        [HttpPost]
        public IActionResult AddNew(News n)
        {
            if (n == null)
                return BadRequest();
            News.Add(n);
            return Created();
        }
        [HttpPut("{id:int}")]
        public IActionResult edit (int id,News n)
        {
            if (n == null) return BadRequest();
            News @new=News.Where(x=>x.id==id).FirstOrDefault();
            if (@new == null) return NotFound();
            @new.id = n.id;
            @new.title = n.title;
            @new.description = n.description;
            @new.author = n.author;
            return NoContent();
            
        }
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            News @new = News.Where(x => x.id == id).FirstOrDefault();
            if (@new == null) return NotFound();
            News.Remove(@new);
            return Ok("New is Deleded");
        }
    }
}
