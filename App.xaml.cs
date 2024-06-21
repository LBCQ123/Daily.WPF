using Daily.WPF.HttpClients;
using Daily.WPF.Services;
using Daily.WPF.ViewModels;
using Daily.WPF.ViewModels.Dialogs;
using Daily.WPF.ViewModels.UCs;
using Daily.WPF.Views;
using Daily.WPF.Views.Dialogs;
using Daily.WPF.Views.UCs;
using DryIoc;
using Prism.Commands;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //手动程序绑定
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterDialog<LoginUC, LoginUCViewModel>();
            //请求
            //containerRegistry.GetContainer().Register<RestClient>();
            containerRegistry.GetContainer().Register<HttpRestClient>();

            //导航页
            containerRegistry.RegisterForNavigation<HomeUC,HomeUCViewModel>();//首页
            containerRegistry.RegisterForNavigation<MemoUC,MemoUCViewModel>();//备忘录
            containerRegistry.RegisterForNavigation<SetUC,SetUCViewModel>();//设置
            containerRegistry.RegisterForNavigation<WaitUC,WaitUCViewModel>();//待办事项
            containerRegistry.RegisterForNavigation<PersonalUC, PersonalUCViewModel>();//个性化页面
            containerRegistry.RegisterForNavigation<SysSetUC, SysSetUCViewModel>();//系统设置页面
            containerRegistry.RegisterForNavigation<AboutUsUC, AboutUsUCViewModel>();//关于更多页

            //Dialog
            containerRegistry.RegisterForNavigation<AddWaitUC, AddWaitUCViewModel>();
            containerRegistry.RegisterForNavigation<EditWaitUC, EditWaitUCViewModel>();

            //添加自定义的窗口注入服务
            containerRegistry.Register<DialogHostService>();

        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginUC", callback =>
            {
                if (callback.Result != ButtonResult.OK /*&& callback.Result != ButtonResult.None*/)
                {
                    Environment.Exit(0);
                    return;
                }
                if (App.Current.MainWindow.DataContext is MainViewModel viewModel)
                {
                    string Name = callback.Parameters.GetValue<string>("LoginUserName");
                    viewModel.SetDefaultUC(Name);
                }
            });
            base.OnInitialized();
        }
    }
}
