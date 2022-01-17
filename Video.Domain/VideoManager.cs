using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video.Domain
{
    public class VideoManager
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Format { get; set; }
        public string Size { get; set; }
        public string Resolution { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool BelongDocument { get; set; }
    }
}
