using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Daily.WPF.ViewModels
{
    public class MainViewModel : BindableBase
    {
		//方式1
		private string _Title = "This is Prism program";
		public string Title
		{
			get { return _Title; }
			set => SetProperty(ref _Title, value);
		}


        public MainViewModel()
        {
            MakeSureCommand = new DelegateCommand(MakeSure);
        }

        public DelegateCommand MakeSureCommand { get; }
        private void MakeSure()
        {
        }



    }
}
