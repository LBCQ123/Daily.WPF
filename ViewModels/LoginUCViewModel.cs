using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Daily.WPF.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        public LoginUCViewModel()
        {
            TransitionPageCommand = new DelegateCommand<string>(TransitionPage);
        }


        #region 按钮事件
        private int _PageIndex = 0;

        public int PageIndex
        {
            get { return _PageIndex; }
            set => SetProperty(ref _PageIndex, value);
        }


        public DelegateCommand<string> TransitionPageCommand { get; }
        private void TransitionPage(string page)
        {
            switch(page)
            {
                case "A":
                    PageIndex = 0;
                    break; 
                case "B":
                    PageIndex = 1;
                    break;
            }
        }

        #endregion




        #region IDialogAware
        private string _Title = "Login";

        public string Title
        {
            get { return _Title; }
            set => SetProperty(ref _Title, value);
        }


        public event Action<IDialogResult>? RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.None));
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }
        #endregion
    }
}
