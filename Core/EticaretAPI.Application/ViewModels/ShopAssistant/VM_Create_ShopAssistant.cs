using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EticaretAPI.Application.ViewModels.ShopAssistant
{
    public class VM_Create_ShopAssistant
    {
        public string UserMail { get; set; }
        public string Password { get; set; }
    }
}
