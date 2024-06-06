using System;
using System.Collections.Generic;

namespace RequestTrackerDALLibrary.Model
{
    public partial class Request
    {
        public int Id { get; set; }
        public string? RequestText { get; set; }
        public int? RaisedBy { get; set; }
        public string? Status { get; set; }
        public int? ClosedBy { get; set; }
        public DateTime? RaisedDate { get; set; }
        public DateTime? ClosedDate { get; set; }
    }
}
