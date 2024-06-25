using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF.Services
{

    /// <summary>
    /// 自定义的窗口显示服务
    /// 无边框，颜色好看
    /// </summary>
    public class DialogHostService:DialogService
    {
        private readonly IContainerExtension containerExtension;

        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this.containerExtension = containerExtension;
        }

        /// <summary>
        /// 弹窗调用<可等待>
        /// </summary>
        /// <param name="name">待弹出的窗口名</param>
        /// <param name="parameters">传递的参数</param>
        /// <param name="dialogHostName">Prism里DialogHost的Identifier名字</param>
        /// <returns>返回窗口的结果</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters parameters, string dialogHostName = "RootDialog")
        {
            if (parameters == null)
                parameters = new DialogParameters();

            //从容器当中去除弹出窗口的实例
            var content = containerExtension.Resolve<object>(name);

            //验证实例的有效性 
            if (!(content is FrameworkElement dialogContent))
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");

            if (dialogContent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
                ViewModelLocator.SetAutoWireViewModel(view, true);

            if (dialogContent.DataContext is IDialogHostAware viewModel)
            {
                //传入主机名
                viewModel.DialogHostName = dialogHostName;
            }
            else
            {
                throw new NullReferenceException("A dialog's ViewModel must implement the IDialogAware interface");
            }
                


            DialogOpenedEventHandler eventHandler = (sender, eventArgs) =>
            {
                if (viewModel is IDialogHostAware aware)
                {
                    aware.OnDialogOpening(parameters);
                }
                eventArgs.Session.UpdateContent(content);
            };

            return (IDialogResult)await DialogHost.Show(dialogContent, dialogHostName, eventHandler);
        }
    }
}
