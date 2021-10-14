namespace PaymentGateWay.Core.Entities
{
    public class Attachment : BaseEntity
    {
      
        public string FileType { get; set; }
        public string Path { get; set; }
        public string OriginalFileName { get; set; }
        public string PhysicalFileName { get; set; }




    }
}