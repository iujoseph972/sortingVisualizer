using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingVisualizer
{
    internal interface IPongEngine
    {

        void DoWork( Panel panel1, int MaxWidth_In, int MaxHeight_In);

        public delegate void KeyEventHandler(object? sender, KeyEventArgs e);


    }
}
