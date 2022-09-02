namespace ComplantSystem.Data.ViewModels
{
    public class AddCommunicationVM
    {
        public string Id { get; set; }

        public int BenfId { get; set; }
        public string BenfName { get; set; }
        public string BenfPhoneNumber { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }
        public string TypeCommuncationId { get; set; }

        public string Titile { get; set; }
        public string reason { get; set; }
    }
}
