namespace WEB_UI.Models
{
    public class SendedMessagesViewModel
    {
        public int ID { get; set; }
        public string? ReceviverName { get; set; }
        public string? ReceviverMail { get; set; }
        public string? SenderName { get; set; }
        public string? SenderMail { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
