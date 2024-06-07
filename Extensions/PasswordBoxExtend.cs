using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Daily.WPF.Extensions
{
    public class PasswordBoxExtend : Behavior<PasswordBox>
    {
        public static string GetPwdText(DependencyObject obj)
        {
            return (string)obj.GetValue(PwdTextProperty);
        }

        public static void SetPwdText(DependencyObject obj, string value)
        {
            obj.SetValue(PwdTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for PwdText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PwdTextProperty =
            DependencyProperty.RegisterAttached("PwdText", typeof(string), typeof(PasswordBoxExtend),
                new PropertyMetadata("", PropertyChanged));


        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is  PasswordBoxExtend pwd)
            {
                if(pwd.AssociatedObject != null)
                    pwd.AssociatedObject.Password = (string)e.NewValue;
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.PasswordChanged += AssociatedObject_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.PasswordChanged -= AssociatedObject_PasswordChanged;
        }

        private void AssociatedObject_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //AssociatedObject.SetValue(PwdTextProperty, AssociatedObject.Password);
            if(sender is PasswordBox box)
            {
                SetPwdText(box,box.Password);
            }
        }
    }
}
