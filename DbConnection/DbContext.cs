using DataModels;
using LinqToDB;

namespace BlogBlazorServer.DbConnection
{
    public class DbContext
    {
        const string http = "http://thankful.top:4396";
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
            var url = http + $"/api/article/GetArticlesToPage?user=cxk&category={category}&startIndex={start}&length={length}";
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
                var url = http + $"/api/article/GetArticlesToPage?user=cxk&category={category}&startIndex={start}&length={length}";
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
            var url = http + "/api/Article/GetArticleCategory";
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
                var url = http + $"/api/article/GetArticleContent?id={id}";
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
            var url = http + $"/api/article/GetArticleContent?id={id}";
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

        public Task<List<dynamic>> SearchAsync(string parameter)
        {
            return Task.Run(() =>
            {
                var url = http + $"/api/article/search?parameter={parameter}";
                HttpClientHelper helper = new HttpClientHelper();
                var rtl = helper.Get<List<dynamic>>(url);
                if (rtl.success)
                {
                    return rtl.data;
                }
                else
                {
                    return new List<dynamic>();
                }
            });
           
        }

    }

    public class ARTICLE_RESULT
    {
        public List<dynamic> data { get; set; }
        public int totalCount { get; set; }
    }
}
