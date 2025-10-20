using System;
using System.Collections.Generic;

namespace OnlineStore.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? StatusId { get; set; }

    public DateTime? Date { get; set; }

    public virtual ICollection<Basket> Baskets { get; set; } = new List<Basket>();

    public virtual Status? Status { get; set; }
}
