using System;
using System.ComponentModel.DataAnnotations;

namespace OXG.ServiceCenterReceipts
{
    public class MasterPassword
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public double Percent { get; set; }
        public MasterPassword()
        {

        }

        public MasterPassword(string name, string password, double percent)
        {
            Name = name;
            Password = password;
            Percent = percent * 0.01;
        }
        
    }
}
