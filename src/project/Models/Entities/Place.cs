using Core.Persistence.Repositories;

namespace Models.Entities;

public class Place : Entity<Guid>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    
}