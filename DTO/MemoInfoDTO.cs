using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily.WPF.DTO
{
    /// <summary>
    /// 备忘录DTO
    /// </summary>
    public class MemoInfoDTO
    {
        /// <summary>
        /// 备忘录事项ID
        /// </summary>
        public int MemoId { get; set; }

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
        /// 0-待办,1-已完成
        /// </summary>
        public int Status { get; set; }

        public MemoInfoDTO()
        {

        }

        public MemoInfoDTO(int memoId, string title, string content, int status)
        {
            MemoId = memoId;
            Title = title;
            Content = content;
            Status = status;
        }
    }
}
