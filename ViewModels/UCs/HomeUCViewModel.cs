using Daily.WPF.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



	}
}
