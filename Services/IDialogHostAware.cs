using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.Services
{
    /// <summary>
    /// 传输过程中的传递参数
    /// </summary>
    internal interface IDialogHostAware
    {
        /// <summary>
        /// 打开过程中执行
        /// </summary>
        /// <param name="parameters"></param>
        void OnDialogOpening(IDialogParameters parameters);

        /// <summary>
        /// 确定命令
        /// </summary>
        DelegateCommand SaveCommand { get; set; }

        /// <summary>
        /// 取消命令
        /// </summary>
        DelegateCommand CancelCommand { get; set; }

        /// <summary>
        /// 要被注入的主机名
        /// </summary>
        string DailogHostName { get;set; }
    }
}
