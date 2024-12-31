using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Models
{
    public class UnitedStatesSummary
    {       
        public int date { get; set; }  // 20210307,
        public int? states { get; set; }  // 56,
        public int? positive { get; set; }  // 28756489,
        public int? negative { get; set; }  // 74582825,
        public int? pending { get; set; }  // 11808,
        public int? hospitalizedCurrently { get; set; }  // 40199,
        public int? hospitalizedCumulative { get; set; }  // 776361,
        public int? inIcuCurrently { get; set; }  // 8134,
        public int? inIcuCumulative { get; set; }  // 45475,
        public int? onVentilatorCurrently { get; set; }  // 2802,
        public int? onVentilatorCumulative { get; set; }  // 4281,
        public string dateChecked { get; set; }  // "2021-03-07T24:00:00Z",
        public int? death { get; set; }  // 515151,
        public int? hospitalized { get; set; }  // 776361,
        public int? totalTestResults { get; set; }  // 363825123,
        public string lastModified { get; set; }  // "2021-03-07T24:00:00Z",
        public int? recovered { get; set; }  // null,
        public int? total { get; set; }  // 0,
        public int? posNeg { get; set; }  // 0,
        public int? deathIncrease { get; set; }  // 842,
        public int? hospitalizedIncrease { get; set; }  // 726,
        public int? negativeIncrease { get; set; }  // 131835,
        public int? positiveIncrease { get; set; }  // 41835,
        public int? totalTestResultsIncrease { get; set; }  // 1170059,
        public string hash { get; set; }  // "a80d0063822e251249fd9a44730c49cb23defd83"
    }
}
