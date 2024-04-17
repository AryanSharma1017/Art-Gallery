using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMongoCollection<User> _users;

    public UserController(IMongoClient client)
    {
        var database = client.GetDatabase("UserDatabase");
        _users = database.GetCollection<User>("Users");
    }

    // GET: api/User
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _users.Find(user => true).ToListAsync();
        return Ok(users);
    }

    // GET: api/User/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(string id)
    {
        var user = await _users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // POST: api/User
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        await _users.InsertOneAsync(user);
        return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // PUT: api/User/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(string id, [FromBody] User userIn)
    {
        var user = await _users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();
        if (user == null)
        {
            return NotFound();
        }

        await _users.ReplaceOneAsync(user => user.Id == id, userIn);
        return NoContent();
    }

    // DELETE: api/User/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var result = await _users.DeleteOneAsync(user => user.Id == id);
        if (result.DeletedCount == 0)
        {
            return NotFound();
        }
        return NoContent();
    }
}
