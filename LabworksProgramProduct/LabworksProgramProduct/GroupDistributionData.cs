using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabworksProgramProduct
{
    public class GroupDistributionData
    {
        public string GroupName;
        public SortedDictionary<double, double> Distribution;
        public GroupDistributionData(string groupName, SortedDictionary<double, double> dict)
        {
            GroupName = groupName;
            Distribution = dict;
        }
    }
}
