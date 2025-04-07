using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugify.Domain.Entity
{
    public class DebugStepDetails
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public string IssueDescription { get; set; }
        public string Steps { get; set; }
        public string ApiName { get; set; } 
        public string ApiDescription { get; set; } = string.Empty;
        public string SPName { get; set; }
        public string TableName { get; set; }
        public string Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public string AddedBY { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
