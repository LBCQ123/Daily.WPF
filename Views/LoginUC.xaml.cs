using Daily.WPF.MsgEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Daily.WPF.Views
{
    /// <summary>
    /// LoginUC.xaml 的交互逻辑
    /// </summary>
    public partial class LoginUC : UserControl
    {
        /// <summary>
        /// 订阅消息组件
        /// </summary>
        private readonly IEventAggregator _Aggregator;
        public LoginUC(IEventAggregator eventAggregator)
        {
            _Aggregator = eventAggregator;
            InitializeComponent();
            _Aggregator.GetEvent<MsgEvent>().Subscribe(Sub);
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="obj">要显示的内容</param>
        private void Sub(string obj)
        {
            RegLoginBar?.MessageQueue?.Enqueue(obj);
        }

    }
}
