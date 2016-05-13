using NFX;
using NFX.DataAccess.CRUD;
using NFX.Environment;
using NFX.Wave;
using System.Collections.Generic;
using Wave.UrlShortener.Models;

namespace Wave.UrlShortener.Filters
{
    public class ShortUlrRedirectFilter : WorkFilter
    {
        #region .ctor

        public ShortUlrRedirectFilter(WorkDispatcher dispatcher, string name, int order) : base(dispatcher, name, order)
        {
        }

        public ShortUlrRedirectFilter(WorkHandler handler, string name, int order) : base(handler, name, order)
        {
        }
        public ShortUlrRedirectFilter(WorkDispatcher dispatcher, IConfigSectionNode confNode) : base(dispatcher, confNode)
        {
        }

        public ShortUlrRedirectFilter(WorkHandler handler, IConfigSectionNode confNode) : base(handler, confNode)
        {
        }

        #endregion
        protected override void DoFilterWork(WorkContext work, IList<WorkFilter> filters, int thisFilterIndex)
        {
            var shortUrl = work.Request.Url.AbsoluteUri;
            var __baseUrl = "http://localhost:8080/$";
            if (shortUrl.StartsWith(__baseUrl))
            {
                var query = new Query("Data.Scripts.GetUrlByShort", typeof(UrlRecord))
            {
                 new Query.Param("shorturl", shortUrl)
            };
                var url = ((ICRUDOperations)App.DataStore)
                                        .LoadOneRow(query) as UrlRecord;

                if (url != null)
                {
                    work.Response.RedirectAndAbort(url.OriginalUrl);
                }
            }
            this.InvokeNextWorker(work, filters, thisFilterIndex);
        }
    }
}
