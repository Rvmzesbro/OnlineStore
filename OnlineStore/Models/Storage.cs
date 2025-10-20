using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Storage
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public decimal? Count { get; set; }

    public virtual Product? Product { get; set; }
}
