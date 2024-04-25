using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
using Microsoft.AspNetCore.Authorization;
using MongoDB.Driver;

namespace art_gallery.Controllers;

[Controller]
[Route("api/Exhibition")]
public class ExhibitionController: ControllerBase {
    private readonly ExhibitionService _exhibitionOptions;
    public ExhibitionController(ExhibitionService exhibitionOptions)
    {
        _exhibitionOptions = exhibitionOptions;
    }

    [HttpGet(), Authorize(Policy = "AdminOnly") ]
    public async Task<List<Exhibition>> Get() {
        return await _exhibitionOptions.GetAllExhibitions();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var exhibition = await _exhibitionOptions.GetExhibition(id);
        if (exhibition == null)
        {
            return NotFound();
        }
        return Ok(exhibition);
    }

    [HttpPost()]
    public async Task<IActionResult> Post([FromBody] Exhibition newExhibition) {
        await _exhibitionOptions.AddExhibition(newExhibition);
        return CreatedAtAction(nameof(Get), new {id = newExhibition.Id}, newExhibition);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Exhibition updatedExhibition) 
    {
        if(await _exhibitionOptions.UpdateExhibition(id,updatedExhibition))
            return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        if(await _exhibitionOptions.DeleteExhibition(id))
            return NoContent();
        return NotFound();
    }
}