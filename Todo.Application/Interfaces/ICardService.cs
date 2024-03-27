using Todo.Application.DTOs;

namespace Todo.Application.Interfaces;

public interface ICardService
{
    Task<IEnumerable<CardDTO>> GetCards();
    Task<CardDTO> GetCardById(int id);
    Task<CardDTO> GetCardByName(string name);
    Task Add(CardDTO card);
    Task Update(CardDTO card);
    Task Delete(int id);
}
