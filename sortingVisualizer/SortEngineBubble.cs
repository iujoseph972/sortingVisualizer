using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingVisualizer
{
    internal class SortEngineBubble : ISortEngine
    {

        private bool _sorted = false;
        private int[] TheArray;
        private Graphics g;
        private int MaxValue;
        Brush WhiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush BlackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public void DoWork(int[] TheArray_In, Graphics g_In, int MaxVal_In)
        {
            TheArray = TheArray_In;
            g = g_In;
            MaxValue = MaxVal_In;   


            while(!_sorted)
            {
                for(int i = 0; i < TheArray.Length - 1; i++)
                {
                    if(TheArray[i] > TheArray[i+1])
                    {
                        Swap(i, i + 1);
                    }
                }
                _sorted = _IsSorted();
            }
        }

        private void Swap(int i, int p)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];
            TheArray[i + 1] = temp;

            g.FillRectangle(BlackBrush,i,0,1,MaxValue);
            g.FillRectangle(BlackBrush, p, 0, 1, MaxValue);

            g.FillRectangle(WhiteBrush, i, MaxValue - TheArray[i], 1, MaxValue);
            g.FillRectangle(WhiteBrush, p, MaxValue - TheArray[p], 1, MaxValue);

        }

        private bool _IsSorted()
        {
            for(int i = 0;i < TheArray.Count() -1;i++)
            {
                if(TheArray[i] > TheArray[i + 1]) { return false; }
            }
            return true;
        }
    }
}
