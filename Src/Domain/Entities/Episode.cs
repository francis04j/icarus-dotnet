using System;
using Domain.Common;

namespace Domain.Entities
{
    public class Episode : AuditableEntity
    {
        public Guid EpisodeId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
