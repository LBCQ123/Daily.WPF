using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.DTO
{
    /// <summary>
    /// 待办事项DTO
    /// </summary>
    public class WaitInfoDTO
    {
        /// <summary>
        /// 待办事项ID
        /// </summary>
        public int WaitId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        public WaitInfoDTO()
        {
            
        }

        public WaitInfoDTO(int waitId,string title,string content,int status)
        {
            WaitId = waitId;
            Title = title;
            Content = content;
            Status = status;
        }

    }
}
