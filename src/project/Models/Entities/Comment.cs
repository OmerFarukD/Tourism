using Core.Persistence.Repositories;

namespace Models.Entities;

public class Comments : Entity<Guid>
{
    
public string? Description { get; set; }
public Guid PostId { get; set; }
public Post Post { get; set; }

public Comments()
{
    Description = string.Empty;
    PostId= Guid.Empty;
    Post= new Post();
}

public Comments(Guid id, Guid postId, string description, Post post ) : base(id)
{
    Id = id;
    PostId = postId;
    Description = description;
    Post = post;
}
}