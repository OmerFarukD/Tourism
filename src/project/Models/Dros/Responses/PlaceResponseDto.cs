using Models.Entities;
namespace Models.Dros.Responses;

public sealed record PlaceResponseDto
    (
    string? Name,
    string? Description,
    string? Address,
    ICollection<PlacesImage> Images,
    string? Latitude,
    string? Longitude,
    double? Rating,
    ICollection<Post>? Posts
    )
{
    public static implicit operator PlaceResponseDto(Place place)
    {
        return new PlaceResponseDto(
            Posts:place.Posts,
            Name:place.Name,
            Description:place.Description,
            Address:place.Address,
            Latitude:place.Latitude,
            Longitude:place.Longitude,
            Rating:place.Rating,
            Images: place.Images
            );
    }
}
