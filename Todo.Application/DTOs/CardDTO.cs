namespace Todo.Application.DTOs;

public class CardDTO
{
    public CardDTO(string name, string description, string createdDate, string finalDate, int userId)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
        FinalDate = finalDate;
        UserId = userId;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedDate { get; set; }
    public string FinalDate { get; set; }
    public int UserId { get; set; }
}
