using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Metrics_Track.Data.Models
{
    public class ProcessMap
    {
        public int IdCountry { get; set; }
        public string Country { get; set; }
        public int IdProcess { get; set; }
        public string FunctionName { get; set; }
        public string _ProcessMap { get; set; }
        public int IdLogin { get; set; }
        public string DisplayName { get; set; }
        public int IdActivity { get; set; }
        public string Activity { get; set; }
        public int IdLob { get; set; }
        public string Lob { get; set; }
        public int IdStatus { get; set; }
        public string Status { get; set; }
        public int IdDivision { get; set; }
        public string Division { get; set; }
        public int IdTower { get; set; }
        public string Tower { get; set; }
        public int IdTowerCategory { get; set; }
        public string TowerCategory { get; set; }

        //public HashSet<SelectListItem> MyItems(IEnumerable<KeyValuePair<int, string>> tempArray)
        //{
        //    var myList = new HashSet<SelectListItem>();

        //    foreach (KeyValuePair<int, string> kvp in tempArray)
        //    {
        //        myList.Add(new SelectListItem { Value = kvp.Key.ToString(), Text = kvp.Value });
        //    }
        //    return myList;
        //}
        

    }
}
