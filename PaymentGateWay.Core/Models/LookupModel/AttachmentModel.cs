namespace PaymentGateWay.Core.Models
{
    public class AttachmentModel : BaseModel
    {
        public string FileType { get; set; }
        public string Path { get; set; }
        public string OriginalFileName { get; set; }
        public string PhysicalFileName { get; set; }
      
    }
}