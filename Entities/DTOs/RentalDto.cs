using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDto:IDto
    {
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; } = null;
    }
}
