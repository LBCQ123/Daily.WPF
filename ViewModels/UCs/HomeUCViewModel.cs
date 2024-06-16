using Daily.WPF.DTO;
using Daily.WPF.Models;
using Prism.Mvvm;
using System.Collections.Generic;

namespace Daily.WPF.ViewModels.UCs
{
    public class HomeUCViewModel : BindableBase
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
                new WaitInfoDTO(0,"会议一","会议内容，讨论并确立项目需求",0),
                new WaitInfoDTO(1,"会议二","所有项目干系人都要参与，会议内容，讨论并确立项目目标",1)
            };

        }

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




    }
}
