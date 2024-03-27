using System.ComponentModel.DataAnnotations;

namespace Todo.Domain.Entities.Base;

public abstract class Entity
{
    [Key]
    public int Id { get; protected set; }
}
