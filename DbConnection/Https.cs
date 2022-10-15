using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace BlogBlazorServer.DbConnection
{
    /// <summary>
    /// HttpClient
    /// </summary>
    public class HttpClientHelper
    {
        /// <summary>
        /// 当响应状态码不正确时执行事件
        /// 返回true抛异常
        /// </summary>
        /// <remarks>
        /// 假如该事件不存在 则抛异常
        /// </remarks>
        public event Func<HttpResponseMessage, bool> SendErrorCode;

        /// <summary>
        /// Get请求(普通请求)
        /// </summary>
        /// <param name="url">地址</param>
        ///  <param name="action">可以用来设置请求头</param>
        ///  <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns>返回字符串</returns>
        public ApiResult<T> Get<T>(string url, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            var str = Send(client => client.GetAsync(url), Response => Response.Content.ReadAsStringAsync(), action, httpClientHandler);
            return JsonConvert.DeserializeObject<ApiResult<T>>(str);
        }

        /// <summary>
        /// Get请求(下载文件)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="path">路径（如果没有路径会自动创建）</param>
        /// <param name="FileName">文件名(不带后缀)</param>
        /// <param name="Suffix">文件后缀，为空自动检索</param>
        /// <param name="action">可以用来设置请求头</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns>返回字符串</returns>
        public void Get(string url, string path, string FileName, string Suffix = null, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            Stream stream = Send(client => client.GetAsync(url), Response => Response.Content.ReadAsStreamAsync(), action, httpClientHandler);

            byte[] file = new byte[stream.Length];
            stream.Read(file, 0, file.Length);
            //设置当前流的位置为流的开始 ,这个流已经不用了，就不管了
            //stream.Seek(0, SeekOrigin.Begin);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (!path.EndsWith("\\"))
            {
                path += "\\";
            }
            //获取文件后缀
            if (string.IsNullOrEmpty(Suffix))
                Suffix = url.Substring(url.LastIndexOf('.'));
            File.WriteAllBytes(path + FileName + Suffix, file);
            stream.Dispose();
        }

        /// <summary>
        /// Post请求(普通请求)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数</param>
        /// <param name="ContentType">设置ContentType</param>
        /// <param name="action">可以用来设置请求头</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns>返回字符串</returns>
        public string PostForm(string url, Dictionary<string, object> parameters = null, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            string param = "";
            if (parameters != null)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var item in parameters)
                {
                    if (sb.Length == 0)
                        sb.AppendFormat("{0}={1}", item.Key, item.Value);
                    else
                        sb.AppendFormat("&{0}={1}", item.Key, item.Value);
                }
                param = sb.ToString();
            }

            HttpContent content = new StringContent(param);

            //设置ContentType
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

            return Send(client => client.PostAsync(url, content), Response => Response.Content.ReadAsStringAsync(), action, httpClientHandler);
        }

        /// <summary>
        /// Post请求(Stream方式请求)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="parameters">参数</param>
        /// <param name="ContentType">设置ContentType</param>
        /// <param name="action">可以用来设置请求头</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns>返回字符串</returns>
        public string PostJson(string url, Encoding encoding, string JsonData = null, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            if (string.IsNullOrEmpty(JsonData))
            {
                JsonData = "{}";
            }
            byte[] buffer = encoding.GetBytes(JsonData);
            MemoryStream stream = new MemoryStream(buffer);
            StreamContent content = new StreamContent(stream);

            //ByteArrayContent content = new ByteArrayContent(buffer);

            //设置ContentType
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            return Send(client => client.PostAsync(url, content), Response => Response.Content.ReadAsStringAsync(), action, httpClientHandler);
        }

        /// <summary>
        /// Post请求(Stream方式请求)
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="Xml">参数</param>
        /// <param name="RequestAction">设置请求头</param>
        /// <param name="ContentAction">设置请求上下文</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns>返回字符串</returns>
        public string PostXmlSOAP(string url, string Xml, Action<HttpRequestMessage> RequestAction = null, Action<HttpContent> ContentAction = null, HttpClientHandler httpClientHandler = null)
        {
            //var client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Method = new HttpMethod("POST");
            request.RequestUri = new Uri(url);
            HttpContent content = new StringContent(Xml);
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
            request.Content = content;
            //content.Headers.Add("charset", "utf-8");
            //content.Headers.Add("SOAPAction", "SOAPAction 的 url");
            //var Result = client.SendAsync(request).Result;
            //var returnResult = Result.Content.ReadAsStringAsync().Result;
            //return returnResult;
            if (RequestAction != null)
            {
                RequestAction(request);
            }
            if (ContentAction != null)
            {
                ContentAction(content);
            }
            return SendAsync(request, Response => Response.Content.ReadAsStringAsync(), httpClientHandler);
        }

        /// <summary>
        /// Post请求(带文件,假如是文件集合，则把PostHelper的参数名定义为同一个)
        /// </summary>
        /// <param name="url">链接</param>
        /// <param name="Parameters">参数</param>
        /// <param name="action">可以用来设置请求头</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns></returns>
        public string PostMultipartForm(string url, List<PostHelper> Parameters, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            //                                                   HttpContent  PostHelper    默认参数
            Action<HttpContent, PostHelper, string> httpAction = (httpContent, postHelper, ContentType) =>
            {
                if (string.IsNullOrEmpty(postHelper.ContentType))
                {
                    postHelper.ContentType = ContentType;
                }
                if (!string.IsNullOrEmpty(postHelper.ContentType))
                {
                    httpContent.Headers.Add("Content-Type", postHelper.ContentType);
                }
            };
            //定义content
            MultipartFormDataContent content = new MultipartFormDataContent();
            foreach (var param in Parameters)
            {
                switch (param.type)
                {
                    case ParameterType.Path:
                        {
                            string path = param.Value.ToString();
                            string fName = Path.GetFileName(path);
                            FileStream fs = File.OpenRead(path);
                            StreamContent streamContent = new StreamContent(fs);
                            httpAction(streamContent, param, "application/octet-stream");
                            content.Add(streamContent, param.Name, fName);
                        }
                        break;
                    case ParameterType.Stream:
                        {
                            StreamContent streamContent = new StreamContent((Stream)param.Value);
                            httpAction(streamContent, param, "application/octet-stream");
                            content.Add(streamContent, param.Name, param.FileName);
                        }
                        break;
                    case ParameterType.Default:
                    default:
                        {
                            content.Add(new StringContent(param.Value.ToString()), param.Name);
                        }
                        break;
                }
            }
            return Send(client => client.PostAsync(url, content), Response => Response.Content.ReadAsStringAsync(), action, httpClientHandler);
        }

        #region 私有操作
        /// <summary>
        /// 公共操作（私有 -- .net封装的Http常见请求）
        /// </summary>
        /// <param name="func">具体操作</param>
        /// <param name="FuncResult">如何操作  对方返回的结果集</param>
        /// <param name="action">可以用来设置请求头</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns></returns>
        private T Send<T>(Func<HttpClient, System.Threading.Tasks.Task<HttpResponseMessage>> func, Func<HttpResponseMessage, System.Threading.Tasks.Task<T>> FuncResult, Action<System.Net.Http.Headers.HttpRequestHeaders> action = null, HttpClientHandler httpClientHandler = null)
        {
            //没加这段代码，有的请求会报'AggregateException'错误
            //ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            if (httpClientHandler == null)
                httpClientHandler = new HttpClientHandler();
            T strResult;
            using (var client = new HttpClient(httpClientHandler))
            {
                try
                {
                    if (action != null)
                    {
                        action(client.DefaultRequestHeaders);
                    }
                    //一分钟超时
                    client.Timeout = new TimeSpan(0, 1, 0);
                    HttpResponseMessage response = func(client).Result;

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        if (SendErrorCode == null)
                        {
                            response.EnsureSuccessStatusCode();//用来抛异常的
                        }
                        foreach (Func<HttpResponseMessage, bool> item in SendErrorCode.GetInvocationList())
                        {
                            if (item(response))
                            {
                                response.EnsureSuccessStatusCode();//用来抛异常的
                            }
                        }
                    }

                    strResult = FuncResult(response).Result;
                }
                catch (AggregateException e)
                {
                    //foreach (var item in e.InnerExceptions)
                    //{

                    //}
                    throw e;
                    //strResult = default(T);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    //strResult = default(T);
                    throw e;
                    //strResult = e.Message;
                }
            }
            return strResult;
        }

        /// <summary>
        /// 公共操作（私有 -- 使用SendAsync方式请求）
        /// </summary>
        /// <param name="request">具体操作</param>
        /// <param name="FuncResult">如何操作  对方返回的结果集</param>
        /// <param name="httpClientHandler">可以设置cookie之类的</param>
        /// <returns></returns>
        private T SendAsync<T>(HttpRequestMessage request, Func<HttpResponseMessage, System.Threading.Tasks.Task<T>> FuncResult, HttpClientHandler httpClientHandler = null)
        {
            //没加这段代码，有的请求会报'AggregateException'错误
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls;
            if (httpClientHandler == null)
                httpClientHandler = new HttpClientHandler();
            T strResult;
            using (var client = new HttpClient(httpClientHandler))
            {
                try
                {
                    //一分钟超时
                    client.Timeout = new TimeSpan(0, 10, 0);
                    HttpResponseMessage response = client.SendAsync(request).Result;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        if (SendErrorCode == null)
                        {
                            response.EnsureSuccessStatusCode();//用来抛异常的
                        }
                        foreach (Func<HttpResponseMessage, bool> item in SendErrorCode.GetInvocationList())
                        {
                            if (item(response))
                            {
                                response.EnsureSuccessStatusCode();//用来抛异常的
                            }
                        }
                    }
                    strResult = FuncResult(response).Result;
                }
                catch (AggregateException e)
                {
                    //foreach (var item in e.InnerExceptions)
                    //{

                    //}
                    throw e;
                    //strResult = default(T);
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                    //strResult = default(T);
                    throw e;
                    //strResult = e.Message;
                }
            }
            return strResult;
        }
        #endregion
    }

    public class PostHelper
    {
        public PostHelper() { }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <param name="type">参数类型</param>
        /// <param name="ContentType">ContentType为空时取默认值，否则取当前赋值</param>
        /// <param name="FileName">文件名(传文件流时必传)</param>
        public PostHelper(string name, object value, ParameterType type = ParameterType.Default, string ContentType = null, string FileName = null)
        {
            Name = name;
            this.Value = value;
            this.type = type;
            this.FileName = FileName;
            this.ContentType = ContentType;
        }

        /// <summary>
        /// 参数名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 参数值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 参数类型
        /// </summary>
        public ParameterType type { get; set; }
        /// <summary>
        /// 文件名(传文件流时必传)
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// ContentType
        /// </summary>
        /// <remarks>
        /// 为空时取默认值，否则取当前赋值
        /// </remarks>
        public string ContentType { get; set; }
    }

    public enum ParameterType
    {
        /// <summary>
        /// 默认参数
        /// </summary>
        Default = 0,
        /// <summary>
        /// 路径
        /// </summary>
        Path = 1,
        /// <summary>
        /// 文件流
        /// </summary>
        Stream = 2,
    }

    public class ApiResult<T>
    {
        public int code { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }

}
