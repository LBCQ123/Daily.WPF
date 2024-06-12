using Daily.WPF.Extensions;
using DryIoc;
using ImTools;
using MaterialDesignThemes.Wpf;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

//使用时两个类都要使用，一个是依赖属性，另一个是行为
//绑定依赖属性一定要设置触发方式和方向为双向

//示例:md: HintAssist.Hint是显示未输入时提示
//xmlns:pwdEx="clr-namespace:Daily.WPF.Extensions"
//xmlns:md="http://materialdesigninxaml.net/winfx/xaml/themes"
//< PasswordBox md: HintAssist.Hint = "请输入密码" pwdEx: PasswordBoxExtend.Pwd = "{Binding Pwd
//                    ,UpdateSourceTrigger = PropertyChanged,Mode = TwoWay}"  DockPanel.Dock="Top">
//    <i:Interaction.Behaviors >
//        < pwdEx:PasswordBoxBehavior />
//    </ i:Interaction.Behaviors >
//</ PasswordBox >




namespace Daily.WPF.Extensions
{
    /// <summary>
    /// PasswordBox扩展属性
    /// 当依赖属性修改时通知密码框修改内容
    /// </summary>
    public class PasswordBoxExtend
    {
        public static string GetPwd(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdProperty);
        }

        public static void SetPwd(DependencyObject obj, string value)
        {
            obj.SetValue(PwdProperty, value);
        }

        // Using a DependencyProperty as the backing store for Pwd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdProperty =
            DependencyProperty.RegisterAttached("Pwd", 
                typeof(string), 
                typeof(PasswordBoxExtend), 
                new PropertyMetadata("",OnPwdChanged));

        private static void OnPwdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {//自定义属性发生变化，改变Password属性
            if(d is PasswordBox pwBox)
            {
                string pwd = (string)e.NewValue;
                string oldPwd = pwBox.Password;
                if(pwd != oldPwd)
                {
                    pwBox.Password = pwd;
                }
            }
        }
       
    }

    /// <summary>
    /// 该类负责 当输入框的值发生改变时通知绑定对象
    /// </summary>
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        /// <summary>
        /// 附加 注入事件
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PasswordChanged += OnPwdChanged;
        }

        private void OnPwdChanged(object sender, RoutedEventArgs e)
        {
            if(sender is PasswordBox pwBox)
            {
                string pwd = PasswordBoxExtend.GetPwd(pwBox);
                if(pwd != pwBox.Password)
                {
                    //通知依赖事件修改内容
                    PasswordBoxExtend.SetPwd(pwBox, pwBox.Password);
                }
            }
        }


        /// <summary>
        /// 销毁 移除事件
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PasswordChanged -= OnPwdChanged;
        }

    }
}
