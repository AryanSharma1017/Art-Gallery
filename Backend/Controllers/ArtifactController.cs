using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace art_gallery.Controllers;

[Controller]
[Route("api/Artifact")]
public class ArtifactsController : ControllerBase
{
    private readonly ArtifactService _artifactOptions;

    public ArtifactsController(ArtifactService artifactOptions)
    {
        _artifactOptions = artifactOptions;
    }

    [HttpGet(), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<List<Artifacts>>> Get()
    {
        var artifacts = await _artifactOptions.GetAllArtifacts();
        return Ok(artifacts);
    }

    [HttpGet("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult<Artifacts>> Get(int id)
    {
        var artifact = await _artifactOptions.GetArtifact(id);
        if (artifact == null)
        {
            return NotFound();
        }
        return Ok(artifact);
    }

    [HttpPost(), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Post([FromBody] Artifacts artifact)
    {
        await _artifactOptions.CreateArtifact(artifact);
        return CreatedAtAction(nameof(Get), new { id = artifact.Id }, artifact);
    }

    [HttpPut("{id}"), Authorize(Policy = "AdminOnly")]
    public async Task<IActionResult> Update(int id, [FromBody] Artifacts artifactToUpdate)
    {
        if (await _artifactOptions.UpdateArtifact(id, artifactToUpdate))
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (await _artifactOptions.DeleteArtifact(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}
