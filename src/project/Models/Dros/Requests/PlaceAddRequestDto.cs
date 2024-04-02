namespace Models.Dros.Requests;

public sealed record PlaceAddRequestDto
    (
    string? Name,
    string? Description,
     string? Address,
     string? Latitude,
     string? Longitude,
     double? Rating
    )
{

}
