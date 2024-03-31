using Core.Security.Dtos;
using Models.Dros.Responses;

namespace Services.Abstracts;

public interface IIdentityService
{
    Task<LoginResponseDto> LoginAsync(UserForLoginDto userForLoginDto, string ipAdress,
        CancellationToken cancellationToken);
    Task<RegisterResponseDto> RegisterAsync(UserForRegisterDto userForRegisterDto, string ipAdress);
    
}