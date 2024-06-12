using DailyApp.API.DTO;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Daily.WPF.HttpClients
{
    /// <summary>
    /// 调用APi 工具类
    /// </summary>
    public class HttpRestClient
    {
        private readonly RestClient _client;//客户端

        private readonly string baseUrl = "http://localhost:42957/api/";

        public HttpRestClient()
        {
            _client = new RestClient();
        }

        /// <summary>
        /// Http请求
        /// </summary>
        /// <param name="apiRequest">请求的数据</param>
        /// <returns>返回的数据</returns>
        public ApiResponse? Execute(ApiRequest apiRequest)
        {
            ApiResponse response = new ApiResponse();

            var request = new RestRequest(apiRequest.Method);
            request.AddHeader("Content-Type", apiRequest.ContentType);

            if(apiRequest.Parameters != null)
            {
                //添加参数
                string jsonContent = JsonConvert.SerializeObject(apiRequest.Parameters);
                request.AddParameter("param", jsonContent,ParameterType.RequestBody);
            }

            try
            {
                request.Resource = apiRequest.Route;
                _client.BaseUrl = new Uri(baseUrl);
                var restResponse = _client.Execute(request);
                if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<ApiResponse>(restResponse.Content);
                }
                else
                {
                    response.ResultCode = -99;
                    response.Msg = restResponse.ErrorMessage;
                }
            }
            catch(Exception ex)
            {
                response.ResultCode = -98;
                response.Msg = ex.Message;
            }
             
            return response;
        }




    }
}
