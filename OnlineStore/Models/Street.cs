using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Street
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
