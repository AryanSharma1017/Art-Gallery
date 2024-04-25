using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace art_gallery.Controllers;

[Controller]
[Route("api/User")]
public class UserController: ControllerBase {
    private readonly UserService _userOptions;
    public UserController(UserService userOptions)
    {
        _userOptions = userOptions;
    }

    [HttpGet(), Authorize(Policy = "AdminOnly")]
    public async Task<List<User>> Get() {
        return await _userOptions.GetAllUsers();
    }

    [HttpGet("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var user = await _userOptions.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] User user) {
        await _userOptions.CreateUser(user);
        return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User UserToUpdate) 
    {
        if(await _userOptions.UpdateUser(id,UserToUpdate))
            return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        if(await _userOptions.DeleteUser(id))
            return NoContent();
        return NotFound();
    }
}