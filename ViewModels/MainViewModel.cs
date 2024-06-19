using Daily.WPF.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;

namespace Daily.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
        

        public MainViewModel(IRegionManager regionManager)
        {
            _RegionManger = regionManager;
            OnNavigationCommand = new DelegateCommand<object>(OnNavigation);
            GoBackCommand = new DelegateCommand(GoBack);
            GoForwordCommand = new DelegateCommand(GoForword);

            LeftMenuInfos = new List<LeftMenuInfo>()
            {
                new LeftMenuInfo("Home","首页","HomeUC"),
                new LeftMenuInfo("NotebookOutline","待办事项","WaitUC"),
                new LeftMenuInfo("NotebookPlus","备忘录","MemoUC"),
                new LeftMenuInfo("Cog","设置","SetUC")
            };
        }

        #region 基础信息
        /// <summary>
        /// 标题名
        /// </summary>
        private string _Title = "This is Prism program";
        public string Title
        {
            get { return _Title; }
            set => SetProperty(ref _Title, value);
        }

        #endregion


        /// <summary>
        /// 左侧菜单的集合
        /// </summary>
        public List<LeftMenuInfo> LeftMenuInfos { get; set; }


        #region 导航服务
        private readonly IRegionManager _RegionManger;
        private IRegionNavigationJournal? _Journal;
        public DelegateCommand<object> OnNavigationCommand { get; }
        private void OnNavigation(object UcName)
        {//导航服务
            if (UcName is LeftMenuInfo info)
            {
                _RegionManger.Regions["MainViewRegion"].RequestNavigate(info.ViewName, Callback =>
                {
                    _Journal = Callback.Context.NavigationService.Journal;
                });
            }
        }

        public DelegateCommand GoBackCommand { get; }
        private void GoBack()
        {
            if(_Journal != null && _Journal.CanGoBack)
            {
                _Journal.GoBack();
            }
        }
        public DelegateCommand GoForwordCommand { get; }
        private void GoForword()
        {
            if(_Journal!= null&& _Journal.CanGoForward)
            {
                _Journal.GoForward();
            }
        }

        #endregion


        #region 默认初始化，设置默认导航

        public void SetDefaultUC(string loginUserName)
        {
            NavigationParameters keyValuePairs = new NavigationParameters();
            keyValuePairs.Add("LoginUserName", loginUserName);
            _RegionManger.Regions["MainViewRegion"].RequestNavigate("HomeUC", Callback =>
            {
                _Journal = Callback.Context.NavigationService.Journal;
            }, keyValuePairs);
        }


        #endregion

    }



}
