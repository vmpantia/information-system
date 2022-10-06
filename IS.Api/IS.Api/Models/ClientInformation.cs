namespace IS.Web.Models
{
    public class ClientInformation
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; set; }
        public bool isManager { get; set; }
    }
}
