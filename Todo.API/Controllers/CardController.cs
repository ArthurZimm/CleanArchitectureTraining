using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;

namespace Todo.API.Controllers;
[ApiController]
[Route("api/v1/card")]
public class CardController : Controller
{
    private readonly ICardService _cardService;
    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCards()
    {
        var result = await _cardService.GetCards();
        return Ok(result);
    }

    [HttpGet("/{id}")]
    public async Task<IActionResult> GetCardsById([FromRoute] int id)
    {
        var result = await _cardService.GetCardById(id);
        return Ok(result);
    }

    //[HttpGet("/{name}")]
    //public async Task<IActionResult> GetCardsByName([FromRoute] string name)
    //{
    //    var result = await _cardService.GetCardByName(name);
    //    return Ok(result);
    //}

    [HttpPost]
    public IActionResult CreateCard([FromBody] CardDTO card)
    {
        var result = _cardService.Add(card);
        return Ok(result);
    }
    [HttpPut]
    public IActionResult UpdateCard([FromBody] CardDTO card)
    {
        var result = _cardService.Update(card);
        return Ok(result);
    }
    [HttpDelete("/{id}")]
    public IActionResult DeleteCard([FromRoute] int id)
    {
        var result = _cardService.Delete(id);
        return Ok(result);
    }
}
