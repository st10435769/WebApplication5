using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Microsoft.AspNetCore.Http;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;

namespace WebApplication5
{
    public class HttpRequestHelper
    {
        public static HttpRequestMessage ConvertHttpRequestToHttpRequestMessage(HttpRequest req)
        {
            var requestMessage = new HttpRequestMessage();
            var streamContent = new StreamContent(req.Body);
            requestMessage.Content = streamContent;

            foreach (var header in req.Headers)
            {
                if (!requestMessage.Headers.TryAddWithoutValidation(header.Key, (IEnumerable<string>)header.Value))
                {
                    requestMessage.Content?.Headers.TryAddWithoutValidation(header.Key, (IEnumerable<string>)header.Value);
                }
            }

            requestMessage.Method = new HttpMethod(req.Method);
            requestMessage.RequestUri = new Uri(req.Scheme + "://" + req.Host + req.Path + req.QueryString);

            return requestMessage;
        }
    }
}