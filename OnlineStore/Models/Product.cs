using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? CategoryId { get; set; }

    public byte[]? Image { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual CategoryProduct? Category { get; set; }

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();
}
