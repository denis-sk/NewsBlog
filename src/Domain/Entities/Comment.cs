using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public Guid NewsItemId { get; set; }
        public string Autor { get; set; }
    }
}
