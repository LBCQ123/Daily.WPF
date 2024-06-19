using Daily.WPF.DTO;
using Daily.WPF.Models;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;

namespace Daily.WPF.ViewModels.UCs
{
    public class HomeUCViewModel : BindableBase , INavigationAware
    {
        public HomeUCViewModel()
        {
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
            if(navigationContext.Parameters.ContainsKey("LoginUserName") == true)
            {
                LoginUserName = navigationContext.Parameters.GetValue<string>("LoginUserName");
            }
            CurrentTime = DateTime.Now;
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
