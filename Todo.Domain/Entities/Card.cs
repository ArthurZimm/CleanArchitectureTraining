using Todo.Domain.Entities.Base;

namespace Todo.Domain.Entities;

public class Card : Entity
{
    public Card(string name, string description, string createdDate, string finalDate)
    {
        Name = name;
        Description = description;
        CreatedDate = createdDate;
        FinalDate = finalDate;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public string CreatedDate { get; private set; }
    public string FinalDate{ get; private set;}

}
