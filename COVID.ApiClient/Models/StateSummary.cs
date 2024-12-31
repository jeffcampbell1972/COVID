using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID.ApiClient.Models
{
    public class StateSummary
    {
        public int date { get; set; } //  20210307,
        public string state { get; set; } //  "AK",
        public int? positive { get; set; } //  56886,
        public int? probableCases { get; set; } //  null,
        public int? negative { get; set; } //  null,
        public int? pending { get; set; } //  null,
        public string totalTestResultsSource { get; set; } //  "totalTestsViral",
        public int? totalTestResults { get; set; } //  1731628,
        public int? hospitalizedCurrently { get; set; } //  33,
        public int? hospitalizedCumulative { get; set; } //  1293,
        public int? inIcuCurrently { get; set; } //  null,
        public int? inIcuCumulative { get; set; } //  null,
        public int? onVentilatorCurrently { get; set; } //  2,
        public int? onVentilatorCumulative { get; set; } //  null,
        public int? recovered { get; set; } //  null,
        public string lastUpdateEt { get; set; } //  "3/5/2021 03:59",
        public string dateModified { get; set; } //  "2021-03-05T03:59:00Z",
        public string checkTimeEt { get; set; } //  "03/04 22:59",
        public int? death { get; set; } //  305,
        public int? hospitalized { get; set; } //  1293,
        public int? hospitalizedDischarged { get; set; } //  null,
        public string dateChecked { get; set; } //  "2021-03-05T03:59:00Z",
        public int? totalTestsViral { get; set; } //  1731628,
        public int? positiveTestsViral { get; set; } //  68693,
        public int? negativeTestsViral { get; set; } //  1660758,
        public int? positiveCasesViral { get; set; } //  null,
        public int? deathConfirmed { get; set; } //  null,
        public int? deathProbable { get; set; } //  null,
        public int? totalTestEncountersViral { get; set; } //  null,
        public int? totalTestsPeopleViral { get; set; } //  null,
        public int? totalTestsAntibody { get; set; } //  null,
        public int? positiveTestsAntibody { get; set; } //  null,
        public int? negativeTestsAntibody { get; set; } //  null,
        public int? totalTestsPeopleAntibody { get; set; } //  null,
       public int? positiveTestsPeopleAntibody { get; set; } //  null,
        public int? negativeTestsPeopleAntibody { get; set; } //  null,
        public int? totalTestsPeopleAntigen { get; set; } //  null,
        public int? positiveTestsPeopleAntigen { get; set; } //  null,
        public int? totalTestsAntigen { get; set; } //  null,
        public int? positiveTestsAntigen { get; set; } //  null,
        public string fips { get; set; } //  "02",
        public int? positiveIncrease { get; set; } //  0,
        public int? negativeIncrease { get; set; } //  0,
        public int? total { get; set; } //  56886,
        public int? totalTestResultsIncrease { get; set; } //  0,
        public int? posNeg { get; set; } //  56886,
        public int? dataQualityGrade { get; set; } //  null,
        public int? deathIncrease { get; set; } //  0,
        public int? hospitalizedIncrease { get; set; } //  0,
        public string hash { get; set; } //  "dc4bccd4bb885349d7e94d6fed058e285d4be164",
        public int? commercialScore { get; set; } //  0,
        public int? negativeRegularScore { get; set; } //  0,
        public int? negativeScore { get; set; } //  0,
        public int? positiveScore { get; set; } //  0,
        public int? score { get; set; } //  0,
        public string grade { get; set; } //  ""
    } 
} 
