using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianApp.Models
{
    public class ColorItem
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public override string ToString() => Name;
    }
}
