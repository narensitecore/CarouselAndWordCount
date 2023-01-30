using CarouselAndWordCount.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace CarouselAndWordCount.Services
{
    using static CarouselAndWordCount.Helpers.APIHelpers;
    using static CarouselAndWordCount.Constants;
    public class TestApiService : ITestApiService
    {
        public PageModel GetPageModel(string pageUrl)
        {
            var pageModel = new PageModel();
            try
            {
                using (var client = new HttpClient())
                {
                    var apiUrl = GetHostName() + APIURL;

                    if (pageUrl != apiUrl)
                    {
                        pageModel.FailureMessage = "Invalid API URL";
                    }
                    else
                    {
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

                            if (_context != null && _context.PageItems != null && _context.PageItems.Any())
                            {
                                var pageItem = _context.PageItems.FirstOrDefault();
                                pageModel.Page = pageItem;

                                var text = string.Join(",", pageItem.CarouselItems.Select(x => x.Description).Concat(pageItem.CarouselItems.Select(x => x.Title)).ToArray());

                                Dictionary<string, int> stats = new Dictionary<string, int>();
                                char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };

                                string[] words = text.Split(chars);
                                int minWordLength = 2; // Consider a word having more than 2 characters


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

                                pageModel.Words = orderedStats.Take(10).Select(m => new Word() { Name = m.Key, Count = m.Value }).ToList();
                                pageModel.WordsCount = words.Count();
                                pageModel.Success = true;
                                return pageModel;

                            }
                            else
                            {
                                pageModel.FailureMessage = "No Details Found!";
                            }
                        }
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