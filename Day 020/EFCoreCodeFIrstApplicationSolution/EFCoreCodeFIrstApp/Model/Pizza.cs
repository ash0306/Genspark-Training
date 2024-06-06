using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFIrstApp.Model
{
    public class Pizza
    {
        //[Key] if the id isnt named id
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
    }
}
