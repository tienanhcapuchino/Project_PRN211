using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211.Models
{
    public partial class Bill
    {
        public short InvoiceNo { get; set; }
        public short GuestId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public string PaymentMode { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }

        public virtual Guest Guest { get; set; }
    }
}
