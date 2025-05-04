using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAssignment
{
    internal class Visit
    {
        public int Id { get; set; }
        public int VisitorId { get; set; }
        public DateTime VisitDate { get; set; }
        public bool TicketPaid { get; set; }

    }
}
