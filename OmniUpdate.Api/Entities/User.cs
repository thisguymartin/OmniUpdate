using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmniUpdate.Api.Entities;

public class User
{
    public required string Name { get; set; }
    public bool Archived { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime lastUpdate { get; set; }

}