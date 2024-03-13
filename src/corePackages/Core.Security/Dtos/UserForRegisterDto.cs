namespace Core.Security.Dtos;

public sealed record UserForRegisterDto(string FirstName,string LastName,string Email, string Password);