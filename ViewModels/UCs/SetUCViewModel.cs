using Daily.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.ViewModels.UCs
{
    public class SetUCViewModel : BindableBase
    {
        public SetUCViewModel(IRegionManager regionManager)
        {
            //设置导航服务
            _RegionManager = regionManager;
            OnNavigationCommand = new DelegateCommand<object?>(OnNavigation);

            LeftMenuInfos = new List<LeftMenuInfo>()
            {
                new LeftMenuInfo("palette","个性化","PersonalUC"),
                new LeftMenuInfo("cog","系统设置","SysSetUC"),
                new LeftMenuInfo("informationoutline","关于更多","AboutUsUC"),
            };
        }

        /// <summary>
        /// 左侧菜单
        /// </summary>
        public List<LeftMenuInfo> LeftMenuInfos { get; set; }


        #region 区域导航
        private readonly IRegionManager _RegionManager;

        public DelegateCommand<object?> OnNavigationCommand { get; }
        
        private void OnNavigation(object? MenuInfo)
        {
            if(MenuInfo != null && MenuInfo is LeftMenuInfo menu)
            {
                _RegionManager.Regions["SettingRegion"].RequestNavigate(menu.ViewName);
            }
        }

        #endregion


    }
}
