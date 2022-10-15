using BlogBlazorServer.Data;
using DataModels;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.Extensions.Caching.Memory;

namespace BlogBlazorServer.DbConnection
{
    public class DbContext
    {
        public DbContext(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }

        public DbContext()
        {
        }

        public List<SysUser> Init()
        {
            using(var db = new DbDB())
            {
                var result = from c in db.SysUsers where c.STATE == 'A' select c;
                return result.ToList();
            }
        }


        public Task GetArticles2()
        {
            return Task.Delay(2000);
        }


        public dynamic GetArticles(string category,int start, int length)
        {
            var url = $"http://42.194.131.197:4396/api/article/GetArticlesToPage?user=cxk&category={category}&startIndex={start}&length={length}";
            HttpClientHelper helper = new HttpClientHelper();
            var rtl = helper.Get<ARTICLE_RESULT>(url);
            if (rtl.success)
            {
                return rtl.data;
            }
            else
            {
                return new
                {
                    data = new List<dynamic>(),
                    totalCount = 0
                };
            }
            
        }

        public Task<dynamic> GetArticlesAsync(string category, int start, int length)
        {
            return Task.Run(() =>
            {
                var url = $"http://42.194.131.197:4396/api/article/GetArticlesToPage?user=cxk&category={category}&startIndex={start}&length={length}";
                HttpClientHelper helper = new HttpClientHelper();
                var rtl = helper.Get<ARTICLE_RESULT>(url);
                if (rtl.success)
                {
                    return rtl.data;
                }
                else
                {
                    dynamic d = new
                    {
                        data = new List<dynamic>(),
                        totalCount = 0
                    };
                    return d;
                }
            });
        }

        public List<string> GetCategories()
        {
            var url = "http://thankful.top:4396/api/Article/GetArticleCategory";
            HttpClientHelper helper = new HttpClientHelper();
            var rtl = helper.Get<List<string>>(url);
            if (rtl.success)
            {
                return rtl.data;
            }
            else
            {
                return new List<string>();
            }
        }

        public Task<dynamic> GetContent(string id)
        {
            return Task.Run(() =>
            {
                var url = $"http://thankful.top:4396/api/article/GetArticleContent?id={id}";
                HttpClientHelper helper = new HttpClientHelper();
                var rtl = helper.Get<dynamic>(url);
                if (rtl.success)
                {
                    return rtl.data;
                }
                else
                {
                    return "";
                }
            });
           
        }

        public dynamic GetContent2(string id)
        {
            var url = $"http://thankful.top:4396/api/article/GetArticleContent?id={id}";
            HttpClientHelper helper = new HttpClientHelper();
            var rtl = helper.Get<dynamic>(url);
            if (rtl.success)
            {
                return rtl.data;
            }
            else
            {
                return "";
            }
        }

        public IMemoryCache MemoryCache { get; }
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return MemoryCache.GetOrCreateAsync(startDate, async e =>
            {
                e.SetOptions(new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow =
                        TimeSpan.FromSeconds(30)
                });

                var rng = new Random();

                await Task.Delay(TimeSpan.FromSeconds(10));

                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55)
                }).ToArray();
            });
        }

    }

    public class ARTICLE_RESULT
    {
        public List<dynamic> data { get; set; }
        public int totalCount { get; set; }
    }
}
