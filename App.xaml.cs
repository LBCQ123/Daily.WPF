using Daily.WPF.ViewModels;
using Daily.WPF.Views;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Services.Dialogs;
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
            });
            base.OnInitialized();
        }
    }
}
