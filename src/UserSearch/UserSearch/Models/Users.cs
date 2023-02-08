using System.Collections.Generic;
using System.Xml.Serialization;

namespace UserSearch.Models
{
    [XmlRoot(ElementName = "Users")]
    public class Users
    {
        [XmlElement(ElementName = "User")]
        public List<User> Context { get; set; } = null!;
    }
}
