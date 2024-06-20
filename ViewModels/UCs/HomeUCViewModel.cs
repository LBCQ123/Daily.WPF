using Daily.WPF.DTO;
using Daily.WPF.HttpClients;
using Daily.WPF.Models;
using DailyApp.API.DTO;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Daily.WPF.ViewModels.UCs
{
    public class HomeUCViewModel : BindableBase, INavigationAware
    {
        public HomeUCViewModel(HttpRestClient httpRestClient, IDialogService dialogService)
        {
            this._Client = httpRestClient;
            this._DialogService = dialogService;

            AddWaitInfoCommand = new DelegateCommand(AddWaitInfo);

            _StatePanels = new List<StatePanelInfo>()
            {
                new StatePanelInfo("ClockFast","汇总","9","#FF0CA0FF","WaitUC"),
                new StatePanelInfo("ClockCheckOutline","已完成","9","#FF1ECA3A","WaitUC"),
                new StatePanelInfo("ChartLineVariant","完成比例","90%","#FF02C6DC",""),
                new StatePanelInfo("PlaylistStar","备忘录","20","#FFFFA000","MemoUC"),
            };

            _WaitInfos = new List<WaitInfoDTO>()
            {
                new WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1)
            };

            _MemoInfos = new List<MemoInfoDTO>()
            {
                new MemoInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",1),
                new MemoInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",0)
            };

            

        }

        #region 面板显示数据
        /// <summary>
        /// 登录用户名
        /// </summary>
        private string _LoginUserName = "未登录";

        public string LoginUserName
        {
            get { return _LoginUserName; }
            set => SetProperty(ref _LoginUserName, value);
        }

        private DateTime _CurrentTime = DateTime.Now;

        public DateTime CurrentTime
        {
            get { return _CurrentTime; }
            set => SetProperty(ref _CurrentTime, value);
        }





        #endregion



        /// <summary>
        /// 统计面板数据
        /// </summary>
        private List<StatePanelInfo> _StatePanels;

        public List<StatePanelInfo> StatePanels
        {
            get { return _StatePanels; }
            set => SetProperty(ref _StatePanels, value);
        }
        /// <summary>
        /// 设置统计面板数据
        /// </summary>
        private void FreshStatePanelData()
        {
            StatePanels[0].Result = StatWaitDTO.TotalCount.ToString();
            StatePanels[1].Result = StatWaitDTO.FinishCount.ToString();
            StatePanels[2].Result = StatWaitDTO.FinishPercent;
        }



        /// <summary>
        /// 待办事项列表
        /// </summary>
        private List<WaitInfoDTO> _WaitInfos;

        public List<WaitInfoDTO> WaitInfos
        {
            get { return _WaitInfos; }
            set => SetProperty(ref _WaitInfos, value);
        }

        /// <summary>
        /// 备忘录列表
        /// </summary>
        private List<MemoInfoDTO> _MemoInfos;

        public List<MemoInfoDTO> MemoInfos
        {
            get { return _MemoInfos; }
            set => SetProperty(ref _MemoInfos, value);
        }

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //设置登录名
            if (navigationContext.Parameters.ContainsKey("LoginUserName") == true)
            {
                LoginUserName = navigationContext.Parameters.GetValue<string>("LoginUserName");
            }
            CurrentTime = DateTime.Now;

            //获得统计数据
            CallStatWait();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion

        #region 待办事项统计
        /// <summary>
        /// 请求客户端
        /// </summary>
        private readonly HttpRestClient _Client;
        private StatWaitDTO StatWaitDTO { get; set; } = new StatWaitDTO();
        /// <summary>
        /// 调用API获取统计待办实现数据
        /// </summary>
        private void CallStatWait()
        {
            try
            {
                ApiRequest apiRequest = new ApiRequest();
                apiRequest.Method = RestSharp.Method.GET;
                apiRequest.Route = "Wait/StatWait";
                var response = _Client.Execute(apiRequest);
                if (response != null)
                {
                    if (response.ResultCode == 1 && response.ResultData != null)
                    {
                        var dto = JsonConvert.DeserializeObject<StatWaitDTO>(response.ResultData.ToString()!);
                        if (dto != null)
                        {
                            StatWaitDTO = dto;
                            //刷新数据
                            FreshStatePanelData();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


        #region 添加待办事项
        private readonly IDialogService _DialogService;

        public DelegateCommand AddWaitInfoCommand { get; }
        private void AddWaitInfo()
        {
            _DialogService.ShowDialog("AddWaitUC");
        }
        
        #endregion

    }
}
