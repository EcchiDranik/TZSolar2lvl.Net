using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Net
{
    public class User
    {
        public Guid Id { get; set; }

        public string FIO { get; set; }

        public DateTime Birthdate { get; set; }

    }
}
