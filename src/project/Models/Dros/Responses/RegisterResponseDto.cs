using Core.Security.Entities;
using Core.Security.JWT;

namespace Models.Dros.Responses;

public sealed record RegisterResponseDto(AccessToken AccessToken, RefreshToken? RefreshToken);