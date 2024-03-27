using Todo.Domain.Entities;

namespace Todo.Domain.Interfaces;

public interface ICardRepository
{
    Task<IEnumerable<Card>> GetCardsAsync();
    Task<Card> GetCardByIdAsync(int id);
    Task<Card> GetCardByNameAsync(string name);
    Task<Card> CreateCardAsync(Card card);
    Task<Card> UpdateCardAsync(Card card);
    Task<Card> DeleteCardAsync(Card card);
}
