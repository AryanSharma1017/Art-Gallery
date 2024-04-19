using System;
using Microsoft.AspNetCore.Mvc;
using art_gallery.Models;
using art_gallery.Services;
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

    [HttpGet]
    public async Task<List<Exhibition>> Get() {
        return await _exhibitionOptions.GetExhibitions();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Exhibition newExhibition) {
        await _exhibitionOptions.AddExhibition(newExhibition);
        return CreatedAtAction(nameof(Get), new {id = newExhibition.Id}, newExhibition);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Exhibition updatedExhibition) 
    {
        await _exhibitionOptions.UpdateExhibition(id,updatedExhibition);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
        await _exhibitionOptions.DeleteExhibition(id);
        return NoContent();
    }
}