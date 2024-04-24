using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using Microsoft.AspNetCore.Authorization;

namespace art_gallery.Controllers;

[ApiController]
[Route("api/ArtGallery")]
public class ArtGalleryController : ControllerBase
{
    private readonly ArtGalleryService _galleryOptions;

    public ArtGalleryController(ArtGalleryService galleryOptions)
    {
        _galleryOptions = galleryOptions;
    }

    [HttpGet(), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<List<ArtGallery>>> GetAll()
    {
        var galleries = await _galleryOptions.GetAllGalleries();
        return Ok(galleries);
    }

    [HttpGet("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<ArtGallery>> Get(int id)
    {
        var gallery = await _galleryOptions.GetGallery(id);
        if (gallery == null)
        {
            return NotFound();
        }
        return Ok(gallery);
    }

    [HttpPost(), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Post([FromBody] ArtGallery gallery)
    {
        await _galleryOptions.CreateGallery(gallery);
        return CreatedAtAction(nameof(Get), new { id = gallery.Id }, gallery);
    }

    [HttpPut("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(int id, [FromBody] ArtGallery galleryToUpdate)
    {
        if (await _galleryOptions.UpdateGallery(id, galleryToUpdate))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _galleryOptions.DeleteGallery(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
