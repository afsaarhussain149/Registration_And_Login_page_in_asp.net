using Humanizer;
using System.ComponentModel.DataAnnotations;

namespace DBFirst.Models
{
    public class Teacher
    {
     
        public int id { get; set; } 
       
        public string name { get; set; } = null;
       
        public string subject { get; set; } = null;
        
        public string email { get; set; } = null;
       
        public string password { get; set; } = null;
    }
}
