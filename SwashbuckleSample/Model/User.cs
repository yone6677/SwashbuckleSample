using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SwashbuckleSample.Model
{
    public class User
    {
        [Required]
        public int UserId { set; get; }
        public string UserName { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public bool Sex { set; get; }
    }
}
