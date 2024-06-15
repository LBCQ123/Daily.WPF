using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.Models
{
    /// <summary>
    /// 首页统计面板
    /// </summary>
    public class StatePanelInfo
    {
        /// <summary>
        /// 统计项的图标
        /// </summary>
        public string Icon { get; set; } = string.Empty;

        /// <summary>
        /// 统计项的名称
        /// </summary>
        public string ItemName { get; set; } = string.Empty;

        /// <summary>
        /// 统计结果
        /// </summary>
        public string Result { get; set; } = string.Empty;

        /// <summary>
        /// 统计颜色
        /// </summary>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// 点击 跳转界面名称
        /// </summary>
        public string ViewName { get; set; } = string.Empty;


        public StatePanelInfo(string icon,string itemName,string result,string color,string viewName)
        {
            Icon = icon;
            ItemName = itemName;
            Result = result;
            Color = color;
            ViewName = viewName;
        }

        public StatePanelInfo()
        {
            
        }

    }
}
