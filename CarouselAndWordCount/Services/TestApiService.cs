using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;

using CarouselAndWordCount.Models;

using Newtonsoft.Json;

namespace CarouselAndWordCount.Services
{
    public class TestApiService : ITestApiService
    {
        public PageModel GetPageModel(string pageUrl)
        {
            var pageModel = new PageModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var apiUrl = $"{ConfigurationManager.AppSettings.Get("TestApiUrl")}/api/page/loadurl";
                    var body = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("PageUrl", pageUrl)
                    };
                    var content = new FormUrlEncodedContent(body);

                    ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls11;
                    var response = client.PostAsync(apiUrl, content).Result;
                    if (response != null && response.IsSuccessStatusCode)
                    {
                        var jsonString = response.Content.ReadAsStringAsync().Result;
                        pageModel = JsonConvert.DeserializeObject<PageModel>(jsonString);
                        if (pageModel != null)
                        {
                            pageModel.Success = true;
                        }
                    }

                    else
                    {
                        pageModel.FailureMessage = "Page Not Found";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pageModel;
        }
    }
}