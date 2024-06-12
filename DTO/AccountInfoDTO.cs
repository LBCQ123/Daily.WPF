namespace DailyApp.API.DTO
{
    /// <summary>
    /// 账号DTO(用来接收注册信息)
    /// </summary>
    public class AccountInfoDTO
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        public string Account { get; set; }

        public string Pwd { get; set; }

    }
}
