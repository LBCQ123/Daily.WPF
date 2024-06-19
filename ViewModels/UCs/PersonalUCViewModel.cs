using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Daily.WPF.ViewModels.UCs
{
    public class PersonalUCViewModel : BindableBase
    {

        public PersonalUCViewModel()
        {
            ChangeHueCommand = new DelegateCommand<object>(ChangeHue);
        }

        #region 更改主题背景颜色
        private bool _IsDarkTheme = true;

		public bool IsDarkTheme
		{
			get { return _IsDarkTheme; }
			set
			{
				if(value != _IsDarkTheme)
				{
                    //设置主题样式
                    ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                }
				_IsDarkTheme = value;
				this.RaisePropertyChanged("IsDarkTheme");
			}
		}

        /// <summary>
        /// 设置主题样式
        /// </summary>
        /// <param name="modificationAction"></param>
        private static void ModifyTheme(Action<Theme> modificationAction)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();
            modificationAction?.Invoke(theme);
            paletteHelper.SetTheme(theme);
        }
        #endregion


        #region 顶部背景颜色

        private readonly PaletteHelper paletteHelper = new PaletteHelper();

        public DelegateCommand<object> ChangeHueCommand { get; }

        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;

        private void ChangeHue(object? obj)
        {
            Theme theme = paletteHelper.GetTheme();

            if(obj != null && obj is Color color)
            {
                theme.PrimaryLight = new ColorPair(color.Lighten());
                theme.PrimaryMid = new ColorPair(color);
                theme.PrimaryDark = new ColorPair(color.Darken());

                paletteHelper.SetTheme(theme);
            }
            
        }
        #endregion

    }
}
