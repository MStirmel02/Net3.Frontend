using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Frontend.DataObjects.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
