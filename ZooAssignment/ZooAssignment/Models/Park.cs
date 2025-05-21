using System;
using System.Collections.Generic;

namespace ZooAssignment.Models;

public partial class Park
{
    public int Id { get; set; }

    public decimal TicketPrize { get; set; }

    public int MaxVisitors { get; set; }
}
