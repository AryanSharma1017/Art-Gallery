using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using MongoDB.Driver;

namespace art_gallery.Controllers;

[Controller]
[Route("api/User")]
public class UserController: ControllerBase {
    private readonly MongoDBService _mongoDBservice;
    public UserController(MongoDBService mongoDBService)
    {
        _mongoDBservice = mongoDBService;
    }

    [HttpGet]
    public async Task<List<User>> Get() {
        return await _mongoDBservice.GetUsers();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user) {
        await _mongoDBservice.CreateUser(user);
        return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] User UserToUpdate) 
    {
        await _mongoDBservice.UpdateUser(id,UserToUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _mongoDBservice.DeleteAsync(id);
        return NoContent();
    }
}