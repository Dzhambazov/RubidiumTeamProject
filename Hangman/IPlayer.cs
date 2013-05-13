using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangMan
{
    public interface IPlayer
    {
         string Name { get; set; }
         int Mistakes { get; set; }
    }
}
