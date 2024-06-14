using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.Models
{
    public class LeftMenuInfo
    {
        /// <summary>
        /// 图片(用MD素材)
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }

        /// <summary>
        /// 视图名称:要去的视图
        /// </summary>
        public string ViewName { get; set; }

        public LeftMenuInfo(string icon,string menuName,string viewName)
        {
            Icon = icon;
            MenuName = menuName;
            ViewName = viewName;
        }

    }
}
