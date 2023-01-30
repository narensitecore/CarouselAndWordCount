using System;

namespace CarouselAndWordCount.Helpers
{
    public static class APIHelpers
    {
        public static string GetHostName()
        {
            Uri myuri = new Uri(System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            string pathQuery = myuri.PathAndQuery;
            if (pathQuery == "/")
                return myuri.ToString().TrimEnd('/');
            return myuri.ToString().Replace(pathQuery, "");
        }
    }
}