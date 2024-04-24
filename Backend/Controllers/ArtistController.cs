using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace art_gallery.Controllers;

[Controller]
[Route("api/Artist"), Authorize(Policy = "AdminOnly")]
public class ArtistController: ControllerBase {
    private readonly ArtistService _artistOptions;
    public ArtistController(ArtistService artistOptions)
    {
        _artistOptions = artistOptions;
    }

    [HttpGet]
    public async Task<List<Artist>> Get() {
        return await _artistOptions.GetAllArtists();
    }

    [HttpGet("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Artist>> Get(int id)
    {
        var artist = await _artistOptions.GetArtist(id);
        if (artist == null)
        {
            return NotFound();
        }
        return Ok(artist);
    }

    [HttpPost(), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Post([FromBody] Artist artist) {
        await _artistOptions.CreateArtist(artist);
        return CreatedAtAction(nameof(Get), new {id = artist.Id}, artist);
    }

    [HttpPut("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(int id, [FromBody] Artist ArtistToUpdate) 
    {
        if(await _artistOptions.UpdateArtist(id,ArtistToUpdate))
            return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        if(await _artistOptions.DeleteArtist(id))
            return NoContent();
        return NotFound();
    }
}