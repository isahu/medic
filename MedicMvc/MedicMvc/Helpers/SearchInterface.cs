using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MedicMvc.Helpers
{
    public static class SearchInterface
    {

        public static Google.Apis.Customsearch.v1.Data.Search Querry(string q)
        {
            // Create the service.
            var service = new CustomsearchService(new BaseClientService.Initializer
            {
                ApplicationName = "MedicMVC",
                ApiKey = Properties.Settings.Default.APIKey,
            });

            // Run the request.
            Debug.WriteLine("Executing a list request...");
            CseResource.ListRequest request = service.Cse.List(q);
            request.Cx = Properties.Settings.Default.SearchID;

            var results = request.Execute();
            Debug.WriteLine(results.Items.Count);

            return results;
        }
    }
}