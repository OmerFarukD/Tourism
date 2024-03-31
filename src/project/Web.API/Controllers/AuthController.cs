using Core.Security.Dtos;
using Core.Security.Entities;
using Microsoft.AspNetCore.Mvc;
using Models.Dros.Responses;
using Services.Abstracts;

namespace Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IIdentityService _service;

    public AuthController(IIdentityService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserForRegisterDto userForRegisterDto)
    {
        var response = await _service.RegisterAsync(userForRegisterDto, GetIpAddress());
       SetRefreshTokenToCookie(response.RefreshToken!);

        return Ok(response.AccessToken);

    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] UserForLoginDto userForLoginDto,CancellationToken cancellationToken)
    {
        var response = await _service.LoginAsync(userForLoginDto, GetIpAddress(),cancellationToken);
        if (response.RefreshToken is not null)
        {
            SetRefreshTokenToCookie(response.RefreshToken);
        }

        return Ok(response.AccessToken);

    }
        
    private string GetRefreshTokenFromCookies() =>
        Request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");

    private void SetRefreshTokenToCookie(RefreshToken refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
    }
}