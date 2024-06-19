using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF.ViewModels.UCs
{
    public class SysSetUCViewModel : BindableBase
    {
        public SysSetUCViewModel()
        {
            BtnShowCommand = new DelegateCommand(BtnShow);
        }

        public DelegateCommand BtnShowCommand { get; }

        private void BtnShow()
        {
            
        }


    }
}
