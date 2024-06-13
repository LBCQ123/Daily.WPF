using Daily.WPF.HttpClients;
using Daily.WPF.MsgEvents;
using DailyApp.API.DTO;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Events;
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

        private readonly IEventAggregator _Aggregator;

        public LoginUCViewModel(HttpRestClient client,IEventAggregator aggregator)
        {
            _client = client;
            _Aggregator = aggregator;
            TransitionPageCommand = new DelegateCommand<string>(TransitionPage);
            RegCommand = new DelegateCommand(Reg);
            UserLoginCommand = new DelegateCommand(UserLogin);
        }

        private string _Account;

        public string Account
        {
            get { return _Account; }
            set => SetProperty(ref _Account, value);
        }



        private string _Pwd = string.Empty;

        public string Pwd
        {
            get { return _Pwd; }
            set => SetProperty(ref _Pwd, value);
        }

        /// <summary>
        /// 注册信息
        /// </summary>
        private AccountInfoDTO _RegAccount = new AccountInfoDTO();
        public AccountInfoDTO RegAccount
        {
            get { return _RegAccount; }
            set { SetProperty(ref _RegAccount, value); }
        }

        /// <summary>
        /// 注册时确认密码
        /// </summary>
        private string _ConfirmPwd = string.Empty;

        public string ConfirmPwd
        {
            get { return _ConfirmPwd; }
            set => SetProperty(ref _ConfirmPwd, value);
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

        public DelegateCommand RegCommand { get; }
        private void Reg()
        {
            if(ConfirmPwd != RegAccount.Pwd)
            {
                SendMsg("密码不一致");
                return;
            }

            if (string.IsNullOrEmpty(RegAccount.Pwd) == true || string.IsNullOrEmpty(RegAccount.Account) == true || string.IsNullOrEmpty(RegAccount.Name) == true)
            {
                SendMsg("账号、名称或密码为空");
                return;
            }

            ApiRequest apiRequest = new ApiRequest();
            apiRequest.Method = RestSharp.Method.POST;
            apiRequest.Route = "Account/Reg";
            apiRequest.Parameters = RegAccount;
            var rest = _client.Execute(apiRequest);

            if(rest!= null &&rest.ResultCode == 1)
            {
                SendMsg("注册成功");
                PageIndex = 0;
            }
            else
            {
                SendMsg($"注册失败:{rest?.Msg}");
            }
            return;
        }


        public DelegateCommand UserLoginCommand { get; }
        private async void UserLogin()
        {
            if (string.IsNullOrEmpty(Pwd) == true || string.IsNullOrEmpty(Account) == true)
            {
                SendMsg("账号或密码为空");
                return;
            }

            ApiRequest apiRequest= new ApiRequest();
            apiRequest.Method= RestSharp.Method.GET;
            apiRequest.Route = $"Account/Login?account={Account}&password={Pwd}";

            var result = _client.Execute(apiRequest);
            if(result != null && result.ResultCode == 1)
            {
                
                if(result.ResultData!= null && result.ResultData is JObject jobj)
                {
                    //获取返回信息的内容
                    var name = jobj.GetValue("name").ToString();
                    SendMsg($"{name}:登陆成功");
                }
                await Task.Delay(1000);
                //关闭界面
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                SendMsg(result.Msg);
            }

        }


        private void SendMsg(string msg)
        {
            _Aggregator.GetEvent<MsgEvent>().Publish(msg);
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
