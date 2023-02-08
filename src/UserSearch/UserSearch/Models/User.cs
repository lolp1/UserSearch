using System.Xml.Serialization;

namespace UserSearch.Models
{
    [XmlRoot(ElementName = "User")]
    public class User
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsBusinessContact { get; set; }
        public bool IsAccountingContact { get; set; }
        public bool IsTechnicalContact { get; set; }
        public bool HasApiAccess { get; set; }
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
        [XmlText]
        public string Text { get; set; } = null!;
    }
}
