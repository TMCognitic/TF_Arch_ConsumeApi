using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeApi.Models
{
#nullable disable
    public class ToDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Done { get; set; }
    }
#nullable enable
}
