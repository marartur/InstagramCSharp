﻿using System.Collections.Generic;

namespace InstagramCSharp.Models
{
    public class MediaFeed
    {
        public Pagination Pagination { get; set; }
        public Meta Meta { get; set; }
        public List<Media> Data { get; set; }
    }
}
