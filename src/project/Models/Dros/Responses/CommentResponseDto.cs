using Core.Security.Entities;
using Core.Security.JWT;
using Models.Entities;

namespace Models.Dros.Responses;
public record CommentsResponseDto(Guid Id, Guid PostId, String Description)
{
    public static implicit operator CommentsResponseDto(Comments comments)
    {
        return new CommentsResponseDto(comments.Id, comments.PostId, comments.Description?? string.Empty);
    }
}