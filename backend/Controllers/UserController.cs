using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using backend.Model;
using backend.Services;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace backend;

[ApiController]
[Route("User/")]
public class UserController : ControllerBase
{
    [HttpGet("{user}")]
    public async Task<IActionResult> RegisterUser(Usuario user)   
    {
        var context = new PongGameDbContext();
        var NicknameVerify = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == user.Id);
        try
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch   
        {
            return BadRequest();
        }
    }
    [HttpGet("login/{id}")]
    public async Task<IActionResult> Login(int Id, [FromServices]UserService service)
    {
        var context = new PongGameDbContext();
        var NicknameVerify = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == Id);
        if(NicknameVerify == null)
            return NotFound("Usuario Inexistente");

        Color[] clr1 = new Color[100];
        Color[] clr2 = new Color[5];
        for(int i = 1; i <= 5; i ++)
        {
            clr1[i] = Color.FromArgb(NicknameVerify.Value"{i}"R, NicknameVerify.Value{i}G, NicknameVerify.Value{i}B);
        }
        
        return Ok(clr1[0]);
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("poggers");
    }
}
