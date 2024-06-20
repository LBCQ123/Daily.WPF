namespace DailyApp.API.DTO
{
    /// <summary>
    /// 接收API待办事项统计的数据模型
    /// </summary>
    public class StatWaitDTO
    {
        /// <summary>
        /// 统计待办事项总数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 已完成数量
        /// </summary>
        public int FinishCount { get; set; }

        /// <summary>
        /// 完成比例
        /// </summary>
        public string FinishPercent { get; set; } = string.Empty;

    }
}
