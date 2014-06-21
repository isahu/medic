using Google.Apis.Customsearch.v1.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicMvc.Models
{
    
    public class ResultModel
    {
        public string Title { get; set; }

        public string Url { get; set; }

        public ResultModel(Result r)
        {
            Title = r.Title;
            Url = r.HtmlFormattedUrl;
        }
    }
}