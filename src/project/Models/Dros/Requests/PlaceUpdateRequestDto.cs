using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dros.Requests
{
    public sealed record PlaceUpdateRequestDto
        (
     Guid Id,
     string? Name,
     string? Description,
     string? Address,
     string? Latitude,
     string? Longitude,
     double? Rating
        )
    {
    }
}
