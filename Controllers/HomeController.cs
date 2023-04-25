using Microsoft.AspNetCore.Mvc;

namespace webapi;
[Route("[controller]/{action}")]
[ApiController]
public class HomeController : ControllerBase
{
    public ActionResult<string> Get()
    {
        return "ActionResult<string>";
    }

    public ActionResult<Note> GetNote()
    {
        Note note = new Note
        {
            NoteId = 1,
            Title = "Title",
            Description = "Description",
            CreatedAt = DateTime.Now
        };
        return note;
    }
}
