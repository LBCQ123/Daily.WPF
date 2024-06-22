using Daily.WPF.DTO;
using Daily.WPF.HttpClients;
using Daily.WPF.Views.UCs;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF.ViewModels.UCs
{
    public class MemoUCViewModel : BindableBase , INavigationAware
    {
        private readonly HttpRestClient _Client;

        public MemoUCViewModel(HttpRestClient client)
        {
            _Client = client;

            QueryMemoCommand = new DelegateCommand(FreshMemoList);//查询
            RemoveMemoInfoCommand = new DelegateCommand<MemoInfoDTO>(RemoveMemoInfo);//删除指定的Memo

            _MemoInfos = new List<MemoInfoDTO>()
            {
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0),
                
            };
        }


        private List<MemoInfoDTO> _MemoInfos;

        public List<MemoInfoDTO> MemoInfos
        {
            get { return _MemoInfos; }
            set => SetProperty(ref _MemoInfos, value);
        }

        /// <summary>
        /// 待搜索的文本
        /// </summary>
        private string _SearchTitle = string.Empty;

        public string SearchTitle
        {
            get { return _SearchTitle; }
            set => SetProperty(ref _SearchTitle, value);
        }

        /// <summary>
        /// 搜索命令
        /// </summary>
        public DelegateCommand QueryMemoCommand { get; }

        /// <summary>
        /// 刷新MemoList
        /// </summary>
        private void FreshMemoList()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Route = $"Memo/GetMemoList?rule={SearchTitle}&status=";
            apiRequest.Method = RestSharp.Method.GET;
            var response = _Client.Execute(apiRequest);
            if (response != null)
            {
                if (response.ResultCode == 1 && response.ResultData != null)
                {
                    var list = JsonConvert.DeserializeObject<List<MemoInfoDTO>>(response.ResultData.ToString()!);
                    if (list != null)
                    {
                        MemoInfos = list;
                    }
                }
                else
                {
                    MessageBox.Show($"FreshMemoList Error[{response.ResultCode}]:" + response.Msg);
                }

            }
            else
            {
                MessageBox.Show("服务器繁忙，请稍后再试");
            }
        }


        #region MemoInfo删除

        public DelegateCommand<MemoInfoDTO> RemoveMemoInfoCommand { get; }
        private void RemoveMemoInfo(MemoInfoDTO memo)
        {
            int memoId = memo.MemoId;
            ApiRequest request = new ApiRequest();
            request.Route = $"Memo/RemoveMemo?memoId={memoId}";
            request.Method = RestSharp.Method.DELETE;
            var response = _Client.Execute(request);
            if (response != null)
            {
                if (response.ResultCode == 1)
                {
                    //刷新数据
                    FreshMemoList();
                }
                else
                {
                    MessageBox.Show($"RemoveMemoInfo Error[{response.ResultCode}]:" + response.Msg);
                }

            }
            else
            {
                MessageBox.Show("服务器繁忙，请稍后再试");
            }

        }

        #endregion



        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //刷新MemoList
            FreshMemoList();
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
