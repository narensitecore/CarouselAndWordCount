using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;

using CarouselAndWordCount.Models;

using Newtonsoft.Json;
using TestAPI.Models;

namespace CarouselAndWordCount.Services
{
    public class TestApiService : ITestApiService
    {
        public PageModel GetPageModel(string pageUrl)
        {
            var pageModel = new PageModel();
            pageUrl = "/page1";
            try
            {
                using (var client = new HttpClient())
                {
                    var apiUrl = System.Web.HttpContext.Current.Request.Url + "/api/carouselcontent";
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
                        var _context = JsonConvert.DeserializeObject<JsonContext>(jsonString);

                        if (_context != null)
                        {
                            pageModel.Success = true;


                            var pageItem = _context.PageItems.FirstOrDefault<PageItem>(m => m.PageUrl.ToLower() == pageUrl);

                            if (pageItem == null)
                            {
                                //return NotFound();
                            }
                            if (pageItem.CarouselItems == null)
                            {
                                pageItem.CarouselItems = _context.CarouselItems.Where<CarouselItem>(x => x.PageRefId == pageItem.Id).ToList();
                            }

                            var pageItemModel = new PageModel();
                            pageItemModel.Page = pageItem;


                            var text = string.Join(",", pageItem.CarouselItems.Select(x => x.Description).Concat(pageItem.CarouselItems.Select(x => x.Title)).ToArray());

                            Dictionary<string, int> stats = new Dictionary<string, int>();
                            char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };
                            // split words
                            string[] words = text.Split(chars);
                            int minWordLength = 2; // Consider a word having more than 2 characters

                            // iterate over the words collection to count occurrences
                            foreach (string word in words)
                            {
                                string w = word.Trim().ToLower();
                                if (w.Length > minWordLength)
                                {
                                    if (!stats.ContainsKey(w))
                                    {
                                        stats.Add(w, 1); // add new word to collection
                                    }
                                    else
                                    {
                                        stats[w] += 1; // update word occurrence count
                                    }
                                }
                            }
                            // order the collection by word count
                            var orderedStats = stats.OrderByDescending(x => x.Value);

                            // Print word count Results
                            Console.WriteLine("Total word count: {0}", stats.Count);

                            foreach (var pair in orderedStats)
                            {
                                Console.WriteLine("Total occurrences of {0}: {1}", pair.Key, pair.Value);
                            }

                            pageItemModel.Words = orderedStats.Take(10).Select(m => new Word() { Name = m.Key , Count = m.Value }).ToList();
                            pageItemModel.WordsCount = words.Count();
                            pageItemModel.Success = true;
                            return pageItemModel;

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