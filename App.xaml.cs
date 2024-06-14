using Daily.WPF.HttpClients;
using Daily.WPF.ViewModels;
using Daily.WPF.ViewModels.UCs;
using Daily.WPF.Views;
using Daily.WPF.Views.UCs;
using DryIoc;
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
            containerRegistry.RegisterForNavigation<HomeUC,HomeUCViewModel>();
            containerRegistry.RegisterForNavigation<MemoUC,MemoUCViewModel>();
            containerRegistry.RegisterForNavigation<SetUC,SetUCViewModel>();
            containerRegistry.RegisterForNavigation<WaitUC,WaitUCViewModel>();

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
            //var dialog = Container.Resolve<IDialogService>();
            //dialog.ShowDialog("LoginUC", callback =>
            //{
            //    if (callback.Result != ButtonResult.OK /*&& callback.Result != ButtonResult.None*/)
            //    {
            //        Environment.Exit(0);
            //        return;
            //    }
            //});
            base.OnInitialized();
        }
    }
}
