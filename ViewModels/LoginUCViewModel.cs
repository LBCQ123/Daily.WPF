using Daily.WPF.HttpClients;
using DailyApp.API.DTO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Daily.WPF.ViewModels
{
    public class LoginUCViewModel : BindableBase, IDialogAware
    {
        private readonly HttpRestClient _client;

        public LoginUCViewModel(HttpRestClient client)
        {
            _client = client;
            TransitionPageCommand = new DelegateCommand<string>(TransitionPage);
            RegCommand = new DelegateCommand(Reg);
        }

        private string _Pwd = "A";

        public string Pwd
        {
            get { return _Pwd; }
            set => SetProperty(ref _Pwd, value);
        }


        private AccountInfoDTO _RegAccount = new AccountInfoDTO();
        public AccountInfoDTO RegAccount
        {
            get { return _RegAccount; }
            set { SetProperty(ref _RegAccount, value); }
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
            Pwd = Pwd + "A";
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

        public DelegateCommand RegCommand { get; }
        private void Reg()
        {
            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.POST;
            apiRequest.Route = "Account/Reg";
            apiRequest.Parameters = RegAccount;
            var rest = _client.Execute(apiRequest);

            if(rest!= null &&rest.ResultCode == 1)
            {
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show($"注册失败:{rest?.Msg}");
            }
            return;
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
