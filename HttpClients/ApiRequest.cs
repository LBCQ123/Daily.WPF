using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Daily.WPF.HttpClients
{
    /// <summary>
    /// 请求模型
    /// </summary>
    public class ApiRequest
    {
        /// <summary>
        /// 请求地址/api路由地址
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// 请求方式(get/post/delete/put)
        /// </summary>
        public Method Method { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public Object? Parameters { get; set; }

        /// <summary>
        /// 发送的数据类型
        /// </summary>
        public string ContentType { get; set; } = "application/json";
    }
}
