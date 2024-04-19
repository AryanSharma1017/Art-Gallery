using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using MongoDB.Driver;

namespace art_gallery.Controllers;

[Controller]
[Route("api/Artist")]
public class ArtistController: ControllerBase {
    private readonly ArtistService _artistOptions;
    public ArtistController(ArtistService artistOptions)
    {
        _artistOptions = artistOptions;
    }

    [HttpGet]
    public async Task<List<Artist>> Get() {
        return await _artistOptions.GetArtist();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Artist artist) {
        await _artistOptions.CreateArtist(artist);
        return CreatedAtAction(nameof(Get), new {id = artist.Id}, artist);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Artist ArtistToUpdate) 
    {
        await _artistOptions.UpdateArtist(id,ArtistToUpdate);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _artistOptions.DeleteArtist(id);
        return NoContent();
    }
}