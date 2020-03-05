using Resources.BaseResource;

namespace Resources.Request
{
    public class InsertCheckInResource : BaseResourceShare
    {
        public string user_id { get; set; }

        public string ip { get; set; }
    }
}