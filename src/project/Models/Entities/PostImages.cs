using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class PostImages : Entity<Guid>
    {
        public string? Path{ get; set; }


        public Guid PostId{ get; set; }
        public Post Post { get; set; }


        public PostImages()
        {
            Path = string.Empty;
            Post =new Post();

        }
    }
}
