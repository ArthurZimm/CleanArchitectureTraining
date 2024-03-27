using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;
using Todo.Infra.Data.Context;

namespace Todo.Infra.Data.Repositories;

public class CardRepository : ICardRepository
{
    private readonly ApplicationDbContext _context;
    public CardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Card>> GetCardsAsync()
    {
        return await _context.Cards.ToListAsync();
    }
    public async Task<Card> GetCardByIdAsync(int id)
    {
        return await _context.Cards.FindAsync(id)??throw new Exception("Error! GetCardByIdAsync");
    }

    public async Task<Card> GetCardByNameAsync(string name)
    {
       return await _context.Cards.FirstOrDefaultAsync(x=>x.Name.Equals(name))??throw new Exception("error! get card by name async");
    }

    public async Task<Card> CreateCardAsync(Card card)
    {
        await _context.Cards.AddAsync(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task<Card> UpdateCardAsync(Card card)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
        return card;
    }
    public async Task<Card> DeleteCardAsync(Card card)
    {
        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();
        return card;
    }
}