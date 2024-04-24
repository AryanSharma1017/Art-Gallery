using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authorization;

namespace art_gallery.Controllers;

[Controller]
[Route("api/ArtType")]
public class ArtTypesController : ControllerBase
{
    private readonly ArtTypeService _artTypeOptions;

    public ArtTypesController(ArtTypeService artTypeOptions)
    {
        _artTypeOptions = artTypeOptions;
    }

    [HttpGet(), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<List<ArtTypes>>> Get()
    {
        var artTypes = await _artTypeOptions.GetAllArtTypes();
        return Ok(artTypes);
    }

    [HttpGet("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<ArtTypes>> Get(int id)
    {
        var artType = await _artTypeOptions.GetArtType(id);
        if (artType == null)
        {
            return NotFound();
        }
        return Ok(artType);
    }

    [HttpPost(), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Post([FromBody] ArtTypes artType)
    {
        await _artTypeOptions.CreateArtType(artType);
        return CreatedAtAction(nameof(Get), new { id = artType.Id }, artType);
    }

    [HttpPut("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(int id, [FromBody] ArtTypes artTypeToUpdate)
    {
        if (await _artTypeOptions.UpdateArtType(id, artTypeToUpdate))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _artTypeOptions.DeleteArtType(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
