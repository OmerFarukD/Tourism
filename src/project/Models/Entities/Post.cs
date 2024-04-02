using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Post :Entity<Guid>
    {

        public int?  UserId{ get; set; }

        public ICollection<PostImages>? Images { get; set; }

        public string? Description { get; set; }

        public int? likeCount { get; set; }

        public int?  DisslikeCount{ get; set; }

        public double?  Rating{ get; set; }

        public Guid PlaceId{ get; set; }

        public Place Place { get; set; }


        public Post()
        {
            Images = new HashSet<PostImages>();
            Description = string.Empty;
            Place =new Place();
        }


    }
}
