using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Models.Dros.Responses;
using Services.Abstracts;

namespace Services.Concretes;

public class IdentityManager : IIdentityService
{
    private readonly AuthBusinessRules _businessRules;
    private readonly IAuthService _authService;
    private readonly IUserService _userService;

    public IdentityManager(AuthBusinessRules businessRules, IAuthService authService, IUserService userService)
    {
        _businessRules = businessRules;
        _authService = authService;
        _userService = userService;
    }


    public async Task<LoginResponseDto> LoginAsync(UserForLoginDto userForLoginDto, string ipAdress,CancellationToken cancellationToken)
    {
        User? user = await _userService.GetByEmailAsync(userForLoginDto.Email,cancellationToken);
        await _businessRules.UserShouldBeExistsWhenSelected(user);
        await _businessRules.UserPasswordShouldBeMatch(user!.Id, userForLoginDto.Password);

        AccessToken accessToken = await _authService.CreateAccessToken(user);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, ipAdress);

        await _authService.DeleteOldRefreshTokens(user.Id);

        LoginResponseDto loginResponseDto = new(
            AccessToken: accessToken,
            RefreshToken: createdRefreshToken
        );

        return loginResponseDto;
    }

    public async Task<RegisterResponseDto> RegisterAsync(UserForRegisterDto userForRegisterDto, string ipAdress)
    {
        await _businessRules.UserEmailShouldBeNotExists(userForRegisterDto.Email);
        
        HashingHelper.CreatePasswordHash(
            password: userForRegisterDto.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
            );

        User user = new User
        {
            Email = userForRegisterDto.Email,
            FirstName = userForRegisterDto.FirstName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            LastName = userForRegisterDto.LastName,
            Status = true 
        };

        User createdUser = await _userService.AddAsync(user);
        
        AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);
        RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser,ipAdress);
        RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);


        RegisterResponseDto registerResponseDto = new(
            AccessToken: createdAccessToken,
            RefreshToken: addedRefreshToken
            );

        return registerResponseDto;

    }
}