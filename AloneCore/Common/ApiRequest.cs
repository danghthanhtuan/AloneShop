using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace AloneCoreApp.Utilities.Common
{
    public static class ApiRequest
    {
        /// <summary>
        /// Phương thức POST
        /// </summary>
        /// <param name="url">URL</param>
        /// <param name="param">Param api</param>
        /// <param name="data">Data Post</param>
        /// <param name="mediaType">Type</param>
        /// <returns></returns>
        public static HttpResponseMessage Post(string url, string param, object data, string mediaType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(mediaType));

            return client.PostAsync(param, new StringContent(ConvertToString(data), Encoding.UTF8, mediaType)).Result;
        }

        /// <summary>
        /// Phương thức GET
        /// </summary>
        /// <param name="url"></param>
        /// <param name="urlParameters"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static HttpResponseMessage Get(string url, string urlParameters, string mediaType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(mediaType));

            return client.GetAsync(urlParameters).Result;
        }

        /// <summary>
        /// Phương thức PUT
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static HttpResponseMessage Put(string url, string param, object data, string mediaType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(mediaType));

            return client.PutAsync(param, new StringContent(ConvertToString(data), Encoding.UTF8, mediaType)).Result;
        }

        /// <summary>
        /// Phương thức Delete
        /// </summary>
        /// <param name="url"></param>
        /// <param name="urlParameters"></param>
        /// <param name="mediaType"></param>
        /// <returns></returns>
        public static HttpResponseMessage Delete(string url, string urlParameters, string mediaType)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue(mediaType));

            return client.DeleteAsync(urlParameters).Result;
        }

        /// <summary>
        /// Nếu truyền vào dạng đối tượng -> thành json
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ConvertToString(object data)
        {
            switch (data.GetType().Name)
            {
                case "String":
                    return data.ToString();

                default:
                    return JsonConvert.SerializeObject(data);
            }
        }
    }
}
