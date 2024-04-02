using Core.Persistence.Repositories;
using Models.Dros.Requests;

namespace Models.Entities;

public class Place : Entity<Guid>
{

    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }

    public ICollection<PlacesImage> Images { get; set; }

    public string? Latitude { get; set; }

    public string? Longitude { get; set; }

    public double? Rating { get; set; }

    public ICollection<Post>? Posts { get; set; }

    public Place() : base()
    {
        Name = string.Empty;
        Description = string.Empty;
        Images = new HashSet<PlacesImage>();
        Latitude = string.Empty;
        Longitude = string.Empty;
        Posts= new HashSet<Post>();
    }

    public static implicit operator Place(PlaceAddRequestDto placeAddRequestDto)
    {
        return new Place()
        {
            Name = placeAddRequestDto.Name,
            Description = placeAddRequestDto.Description,
            Address = placeAddRequestDto.Address,
            Latitude = placeAddRequestDto.Latitude,
            Longitude = placeAddRequestDto.Longitude,
            Rating = placeAddRequestDto.Rating,
        };
    }


    public static implicit operator Place(PlaceUpdateRequestDto placeUpdateRequest)
    {
        return new Place()
        {
            Id = placeUpdateRequest.Id,
            Name = placeUpdateRequest.Name,
            Description = placeUpdateRequest.Description,
            Address = placeUpdateRequest.Address,
            Latitude = placeUpdateRequest.Latitude,
            Longitude = placeUpdateRequest.Longitude,
            Rating = placeUpdateRequest.Rating,
        };
    }


    //public Place(Guid id,string name, string description,string latitude, string logitude, double? rating) : base(id)
    //{
    //    Name = name;
    //    Description = description;
    //    Latitude = latitude;
    //    Longitude = logitude;
    //    Rating= rating;
    //}



}