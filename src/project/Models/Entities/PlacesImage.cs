using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class PlacesImage : Entity<Guid>
    {

        public string? Path{ get; set; }

        public Guid PlaceId{ get; set; }

        public Place Place { get; set; }


        public PlacesImage() : base()
        {
            Path = string.Empty;

            Place = new Place();
        }
    }
}
