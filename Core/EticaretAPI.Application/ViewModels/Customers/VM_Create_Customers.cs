using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Application.ViewModels.Customers
{
    public class VM_Create_Customers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Tc { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
