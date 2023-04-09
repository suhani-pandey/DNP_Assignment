using Application.LogicInterfaces;
using Domain;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpGet]//GET requests to this controller ends here
    //FromQuery to indicate that this argument should be extracted from the query parameters of the URI.
    public async Task<ActionResult<IEnumerable<Forum>>> GetAsync([FromQuery] string? title,string? description)
    {
        try
        {
            Forum forum = new(title,description);
            IEnumerable<Forum> forums = await forumLogic.GetAllForumAsync(forum);
            return Ok(forums);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("{forumId:int}")]
    public async Task<ActionResult<Forum>> GetForumById([FromRoute] int forumId)
    {
        try
        {
            Forum dto = await forumLogic.GetByIdAsync(forumId);
            return Ok(dto);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}