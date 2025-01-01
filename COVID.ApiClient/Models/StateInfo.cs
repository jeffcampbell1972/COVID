using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Models
{
    public class StateInfo
    {
        public string state { get; set; } 
        public string notes { get; set; } 
        public string covid19Site { get; set; } 
        public string covid19SiteSecondary { get; set; } 
        public string covid19SiteTertiary { get; set; } 
        public string covid19SiteQuaternary { get; set; } 
        public string covid19SiteQuinary { get; set; } 
        public string twitter { get; set; } 
        public string covid19SiteOld { get; set; } 
        public string covidTrackingProjectPreferredTotalTestUnits { get; set; } 
        public string covidTrackingProjectPreferredTotalTestField { get; set; } 
        public string totalTestResultsField { get; set; } 
        public string pui { get; set; } 
        public bool pum { get; set; } 
        public string name { get; set; } 
        public string fips { get; set; } 
    }
}
