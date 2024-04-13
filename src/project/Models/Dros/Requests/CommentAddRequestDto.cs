using Core.Security.Entities;
using Core.Security.JWT;


public record CommentsAddDto(Guid Id,Guid PostId , String Description);