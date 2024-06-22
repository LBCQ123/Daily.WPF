using Daily.WPF.DTO;
using Daily.WPF.HttpClients;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows;

namespace Daily.WPF.ViewModels.UCs
{
    public class WaitUCViewModel : BindableBase,INavigationAware
    {
        private readonly HttpRestClient _Client;

        public WaitUCViewModel(HttpRestClient client)
        {
            _Client = client;
            _WaitInfos = new List<WaitInfoDTO>()
            {
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1),
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0)
            };
            //查询待办事项
            QueryListCommand = new DelegateCommand(QueryList); 
        }

        #region 界面显示
        /// <summary>
        /// 显示待办事项
        /// </summary>
        private List<WaitInfoDTO> _WaitInfos;

        public List<WaitInfoDTO> WaitInfos
        {
            get { return _WaitInfos; }
            set => SetProperty(ref _WaitInfos, value);
        }
        /// <summary>
        /// 待办事项的筛选条件
        /// 0:全部
        /// 1:待办
        /// 2:已完成
        /// </summary>
        private int _StatusSelected;
        public int StatusSelected
        {
            get { return _StatusSelected; }
            set => SetProperty(ref _StatusSelected, value);
        }

        /// <summary>
        /// 查询规则
        /// </summary>
        private string _QueryRule = string.Empty;
        public string QueryRule
        {
            get { return _QueryRule; }
            set => SetProperty(ref _QueryRule, value);
        }


        #endregion

        #region 查询待办事项数据


        public DelegateCommand QueryListCommand { get; }

        /// <summary>
        /// 查询待办事项数据
        /// </summary>
        private void QueryList()
        {
            string? rule = QueryRule;
            int? status = null;
            if (StatusSelected == 1)
                status = 0;
            else if (StatusSelected == 2)
                status = 1;
            ApiRequest request = new ApiRequest();
            request.Route = $"Wait/QueryWait?rule={rule}&status={status}";
            request.Method = RestSharp.Method.GET;
            
            var response = _Client.Execute(request);
            if(response != null)
            {
                if(response.ResultCode == 1 && response.ResultData != null)
                {
                    var list = JsonConvert.DeserializeObject<List<WaitInfoDTO>>(response.ResultData.ToString()!);
                    if(list != null)
                    {
                        WaitInfos = list;
                    }
                }
                else
                {
                    MessageBox.Show($"获取失败{response.ResultCode},Msg={response.Msg}");
                }
            }
            else
            {
                MessageBox.Show("服务器繁忙，请稍后再试");
            }

        }



        #endregion

        #region

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if(navigationContext.Parameters.TryGetValue<int>("StatusIndex", out int index))
            {
                StatusSelected = index;
            }
            else
            {
                StatusSelected = 0;
            }
            //查询待办事项数据
            QueryList();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        #endregion


    }
}
