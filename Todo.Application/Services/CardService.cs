using AutoMapper;
using Todo.Application.DTOs;
using Todo.Application.Interfaces;
using Todo.Domain.Entities;
using Todo.Domain.Interfaces;

namespace Todo.Application.Services;

public class CardService : ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IMapper _mapper;
    public CardService(ICardRepository cardRepository, IMapper mapper)
    {
        _cardRepository = cardRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CardDTO>> GetCards()
    {
        return _mapper.Map<IEnumerable<CardDTO>>(await _cardRepository.GetCardsAsync());
    }
    public async Task<CardDTO> GetCardById(int id)
    {
        return _mapper.Map<CardDTO>(await _cardRepository.GetCardByIdAsync(id));
    }

    public async Task<CardDTO> GetCardByName(string name)
    {
        return _mapper.Map<CardDTO>(await _cardRepository.GetCardByNameAsync(name));
    }
    public async Task Add(CardDTO card)
    {
        await _cardRepository.CreateCardAsync(_mapper.Map<Card>(card));
    }

    public async Task Update(CardDTO card)
    {
        await _cardRepository.UpdateCardAsync(_mapper.Map<Card>(card));
    }
    public async Task Delete(int id)
    {
        await _cardRepository.DeleteCardAsync(_cardRepository.GetCardByIdAsync(id).Result);
    }
}
