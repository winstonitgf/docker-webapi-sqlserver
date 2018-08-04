using System.ComponentModel.DataAnnotations;

namespace myapi.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public string address { get; set; }
    }
}