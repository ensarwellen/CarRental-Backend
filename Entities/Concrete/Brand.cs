using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
    }
}
