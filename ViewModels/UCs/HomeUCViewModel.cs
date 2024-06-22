using Daily.WPF.DTO;
using Daily.WPF.HttpClients;
using Daily.WPF.Models;
using Daily.WPF.Services;
using DailyApp.API.DTO;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace Daily.WPF.ViewModels.UCs
{
    public class HomeUCViewModel : BindableBase, INavigationAware
    {
        public HomeUCViewModel(HttpRestClient httpRestClient,
                                DialogHostService dialogService,
                                IRegionManager regionManager)
        {
            _Client = httpRestClient;
            _DialogService = dialogService;
            _RegionManager = regionManager;

            AddWaitInfoCommand = new DelegateCommand(AddWaitInfo);//添加待办信息
            ChangeWaitStatusCommand = new DelegateCommand<WaitInfoDTO>(ChangeWaitStatus);//更改待办信息状态
            ChangeWaitCommand = new DelegateCommand<WaitInfoDTO>(ChangeWait);//更改待办信息
            NavigationPageCommand = new DelegateCommand<StatePanelInfo>(NavigationPage);//导航服务
            AddMemoCommand = new DelegateCommand(AddMemo);//添加备忘录信息
            ChangeMemoCommand = new DelegateCommand<MemoInfoDTO> (ChangeMemo);//编辑备忘录信息

            _StatePanels = new List<StatePanelInfo>()
            {
                new StatePanelInfo("ClockFast","汇总","9","#FF0CA0FF","WaitUC"),
                new StatePanelInfo("ClockCheckOutline","已完成","9","#FF1ECA3A","WaitUC"),
                new StatePanelInfo("ChartLineVariant","完成比例","90%","#FF02C6DC",""),
                new StatePanelInfo("PlaylistStar","备忘录","20","#FFFFA000","MemoUC"),
            };

            _WaitInfos = new List<DTO.WaitInfoDTO>()
            {
                new DTO.WaitInfoDTO(0,"测试录屏","仔细给客户演示测试",0),
                new DTO.WaitInfoDTO(1,"上传录屏","上传录屏，上传时，仔细检查是否有效果录屏等",1)
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
        private List<DTO.WaitInfoDTO> _WaitInfos;

        public List<DTO.WaitInfoDTO> WaitInfos
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
            FreshWaitList();
            FreshMemoCounts();
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


        /// <summary>
        /// 调用API从服务器获取所有未完成的待办事项
        /// </summary>
        private void FreshWaitList()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.GET;
            apiRequest.Route = "Wait/GetWattings";
            var response = _Client.Execute(apiRequest);
            if (response != null)
            {
                if (response.ResultCode == 1 && response.ResultData != null)
                {
                    List<DTO.WaitInfoDTO>? list = JsonConvert.DeserializeObject<List<DTO.WaitInfoDTO>>(response.ResultData.ToString()!);
                    if (list != null)
                    {
                        WaitInfos = list;
                    }
                }
            }

        }


        #endregion


        #region 添加待办事项
        /// <summary>
        /// 自定义对话服务
        /// </summary>
        private readonly DialogHostService _DialogService;

        public DelegateCommand AddWaitInfoCommand { get; }
        private async void AddWaitInfo()
        {
            DialogParameters keyValuePairs = new DialogParameters();
            IDialogResult result = await _DialogService.ShowDialog("AddWaitUC", keyValuePairs);
            if (result.Result == ButtonResult.OK)
            {
                if (result.Parameters.TryGetValue<DTO.WaitInfoDTO>("WaitInfoDTO", out DTO.WaitInfoDTO value) == true)
                {
                    ApiRequest apiRequest = new ApiRequest();
                    apiRequest.Method = RestSharp.Method.POST;
                    apiRequest.Route = "Wait/AddWait";
                    apiRequest.Parameters = new WaitInfoDTO()
                    {
                        Title = value.Title,
                        Content = value.Content,
                        Status = value.Status
                    };
                    var response = _Client.Execute(apiRequest);
                    if (response != null)
                    {
                        if (response.ResultCode == 1)
                        {
                            //刷新待办事项统计
                            CallStatWait();
                            FreshWaitList();
                        }
                        else
                        {
                            MessageBox.Show($"添加失败：{response.Msg}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("添加失败：网络繁忙");
                    }
                }
            }
        }

        #endregion

        #region 修改待办状态
        public DelegateCommand<WaitInfoDTO> ChangeWaitStatusCommand { get; }
        private void ChangeWaitStatus(WaitInfoDTO waitInfoDTO)
        {
            ApiRequest request = new ApiRequest();
            request.Method = RestSharp.Method.PUT;
            request.Route = "Wait/UpdateStatus";
            request.Parameters = waitInfoDTO;

            var response = _Client.Execute(request);
            if (response != null)
            {
                if (response.ResultCode == 1)
                {
                    //刷新待办事项统计
                    CallStatWait();
                    FreshWaitList();
                }
                else
                {
                    MessageBox.Show($"操作失败：{response.Msg}");
                }
            }
            else
            {
                MessageBox.Show("修改失败：网络繁忙");
            }
        }

        public DelegateCommand<WaitInfoDTO> ChangeWaitCommand { get; }
        public async void ChangeWait(WaitInfoDTO waitInfoDTO)
        {
            if (waitInfoDTO == null)
                return;
            DialogParameters keyValuePairs = new DialogParameters();
            keyValuePairs.Add("WaitInfoDTO", waitInfoDTO);
            IDialogResult result = await _DialogService.ShowDialog("EditWaitUC", keyValuePairs);
            if (result.Result == ButtonResult.OK
                && result.Parameters.TryGetValue<WaitInfoDTO>("WaitInfoDTO", out WaitInfoDTO updatedWaitInfo)
                && updatedWaitInfo != null)
            {
                ChangeWaitStatus(updatedWaitInfo);
            }
        }


        #endregion


        #region 页面导航
        /// <summary>
        /// 导航服务
        /// </summary>
        private readonly IRegionManager _RegionManager;

        public DelegateCommand<StatePanelInfo> NavigationPageCommand { get; }
        private void NavigationPage(StatePanelInfo statePanelInfo)
        {
            NavigationParameters parameters = new NavigationParameters();
            if (statePanelInfo.ItemName == "已完成")
            {
                //传递已完成参数
                parameters.Add("StatusIndex", 2);
            }

            if (string.IsNullOrEmpty(statePanelInfo.ViewName) == false)
            {
                _RegionManager.Regions["MainViewRegion"].RequestNavigate(statePanelInfo.ViewName, parameters);
            }
        }


        #endregion



        #region 刷新备忘录信息

        private void FreshMemoCounts()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Route = "Memo/GetMemoInfo";
            apiRequest.Method = RestSharp.Method.GET;
            var response = _Client.Execute(apiRequest);
            if (response != null)
            {
                if (response.ResultCode == 1 && response.ResultData != null)
                {
                    StatePanels[3].Result = response.ResultData.ToString()!;
                }
                else
                {
                    MessageBox.Show($"FreshMemoCounts Error[{response.ResultCode}]:" + response.Msg);
                }

            } else
            {
                MessageBox.Show("服务器繁忙，请稍后再试");
            }
        }

        /// <summary>
        /// 刷新MemoList
        /// </summary>
        private void FreshMemoList()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Route = "Memo/GetMemoList?rule=&status=0";
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

        #endregion

        #region 添加一条备忘录信息
        public DelegateCommand AddMemoCommand { get; }
        private async void AddMemo()
        {
            IDialogResult result = await _DialogService.ShowDialog("AddMemoUC",new DialogParameters());
            if(result.Result == ButtonResult.OK && result.Parameters.TryGetValue<MemoInfoDTO>
                        ("MemoInfoDTO",out MemoInfoDTO memoInfo))
            {
                ApiRequest request = new ApiRequest();
                request.Route = "Memo/AddMemo";
                request.Method= RestSharp.Method.POST;
                request.Parameters = memoInfo;
                var response = _Client.Execute(request);
                if (response != null)
                {
                    if (response.ResultCode == 1 )
                    {
                        FreshMemoCounts();
                        FreshMemoList();
                    }
                    else
                    {
                        MessageBox.Show($"AddMemo Error[{response.ResultCode}]:" + response.Msg);
                    }

                }
                else
                {
                    MessageBox.Show("服务器繁忙，请稍后再试");
                }
            }
        }
        #endregion

        #region 修改待办事项

        public DelegateCommand<MemoInfoDTO> ChangeMemoCommand { get; }
        private async void ChangeMemo(MemoInfoDTO memoInfo) 
        {
            if (memoInfo == null)
                return;
            DialogParameters paramers = new DialogParameters();
            paramers.Add("MemoInfoDTO", memoInfo);
            var result = await _DialogService.ShowDialog("EditMemoUC", paramers);
            if(result.Result == ButtonResult.OK && result.Parameters.TryGetValue<MemoInfoDTO>("MemoInfoDTO",out MemoInfoDTO changeMemo))
            {
                ApiRequest request = new ApiRequest();
                request.Route = "Memo/ChangeMemo";
                request.Method = RestSharp.Method.PUT;
                request.Parameters = changeMemo;
                var response = _Client.Execute(request);
                if (response != null)
                {
                    if (response.ResultCode == 1)
                    {
                        FreshMemoCounts();
                        FreshMemoList();
                    }
                    else
                    {
                        MessageBox.Show($"ChangeMemo Error[{response.ResultCode}]:" + response.Msg);
                    }

                }
                else
                {
                    MessageBox.Show("服务器繁忙，请稍后再试");
                }
            }
        
        }
        #endregion

    }
}
