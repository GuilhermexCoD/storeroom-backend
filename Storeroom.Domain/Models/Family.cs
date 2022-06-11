using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storeroom.Domain.Models
{
    public class Family : EntityBase
    {
        public string Name { get; set; }
        public Guid ManagerId { get; set; }
        
        [ForeignKey("ManagerId")]
        public User Manager { get; set; }
        public IEnumerable<User> Users { get; set; }
        public string ImageURL { get; set; }
    }
}