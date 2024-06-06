using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class Request
    {
        [Key]
        public int RequestNumber { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; } = System.DateTime.Now;
        public DateTime? ClosedDate { get; set; } = null;
        public string RequestStatus { get; set; }


        public int RequestRaisedBy { get; set; }
        [ForeignKey("RequestRaisedBy")]
        public Employee RaisedByEmployee { get; set; }

        public int? RequestClosedBy { get; set; } = null;
        public Employee RequestClosedByEmployee { get; set; }

        public ICollection<RequestSolution> RequestSolutions { get; set; }

        public override string ToString()
        {
            return $"Request Number: {RequestNumber}\nRequest Message: {RequestMessage}\nRequest Date: {RequestDate}\nClosed Date: {ClosedDate}\nRequest Status: {RequestStatus}\nRaised By Employee Id: {RequestRaisedBy}\nClosed By Employee Id: {RequestClosedBy}";
        }
    }
}
