using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using backend.Model;
using backend.Services;
using System.Drawing;
namespace backend;

[ApiController]
[Route("User/")]
public class UserController : ControllerBase
{
    [HttpGet("{user}")]
    public async Task<IActionResult> RegisterUser(int user)   
    {
        try
        {
            var context = new PongGameDbContext();
            await context.AddAsync(user);
            await context.SaveChangesAsync();

            return Ok();
        }
        catch   
        {
            return BadRequest();
        }
    }
    [HttpGet("aaa")]
    public async Task<IActionResult> Login(Usuario user, [FromServices]UserService service)
    {
        return Ok();
    }
    [HttpGet("test")]
    public IActionResult Test()
    {
        PongGameDbContext context = new PongGameDbContext();
        Color[] clr = { Color.FromArgb(24, 34, 45), Color.FromArgb(224, 124, 145), Color.FromArgb(24, 34, 225) };
        byte[] byteClr = new byte[clr.Length];
        byte[] clrByteTest = new byte[2];
        clrByteTest[0] = clr[0].R;
        for(int i = 0; i < clr.Length; i+=3)
        {
            byteClr[i] = clr[i].R;
            byteClr[i + 1] = clr[i].G;
            byteClr[i + 2] = clr[i].B; 
        }
        var usr = new Usuario()
        {
            Nickname = "Pepe",
            FaceData = byteClr
        };
        int[] var = new int[byteClr.Length];
        string a = "";
        for(int i = 0; i < byteClr.Length; i++)
        {
            
        }
        return Ok(clrByteTest[0].ToString());
    }
}
