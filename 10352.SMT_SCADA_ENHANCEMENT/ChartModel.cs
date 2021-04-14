using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FORM
{
    public class ChartModel
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string ChartType { get; set; }
        public int NumberOfSeries { get; set; }
        public string AxisLabelColumnName { get; set; }
        public string ValueColumnName { get; set; }
        public string formCall { get; set; }
        public string AxisYTitle { get; set; }
        public string axisXTitle { get; set; }
        public string valuePatten { get; set; }
    }
}
