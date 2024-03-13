namespace Core.Security.Dtos;

public sealed record UserForLoginDto(string Email, string Password, string? AuthenticatorCode);

