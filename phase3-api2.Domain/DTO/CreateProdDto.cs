using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phase3_api2.Domain.DTO
{
    public class CreateProdDto
    {
        public string Name { get; set; }

        public DateTime TimeExpire { get; set; }
    }
}
