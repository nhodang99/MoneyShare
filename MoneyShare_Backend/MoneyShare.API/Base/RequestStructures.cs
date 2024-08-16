namespace MoneyShare.API.Base
{
    public class GroupUserRequestBody
    {
        public int groupId { get; set; }
        public int[] UserIds { get; set; }
    }
}
