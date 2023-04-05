using Application.LogicInterfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ForumController:ControllerBase
{
    private readonly IForumLogic forumLogic;

    public ForumController(IForumLogic forumLogic)
    {
        this.forumLogic = forumLogic;
    }
    
    [HttpPost]
    public async Task<ActionResult<Forum>> CreateAsync([FromBody] Forum dto)
    {
        try
        {
            Forum created = await forumLogic.CreateForumAsync(dto);
            return Created($"/Forum/{created.Id}", created);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}