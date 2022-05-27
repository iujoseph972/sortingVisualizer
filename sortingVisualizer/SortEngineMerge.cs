using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sortingVisualizer
{
    internal class SortEngineMerge : ISortEngine
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

 
            while (!_sorted)
            {
                //for (int i = 0; i < TheArray.Length - 1; i++)
                //{
                //    if (TheArray[i] > TheArray[i + 1])
                //    {
                        sort(TheArray,0, TheArray.Length-1);

        

                //    }
                //}
                _sorted = _IsSorted();
            }
        }


        void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
             //   System.Threading.Thread.Sleep(1);
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    g.FillRectangle(BlackBrush, i, 0, 1, MaxValue);
                    g.FillRectangle(WhiteBrush, i, MaxValue - arr[i], 1, MaxValue);
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    g.FillRectangle(BlackBrush, j + n1 - 1, 0, 1, MaxValue);
                    g.FillRectangle(WhiteBrush, j + n1 - 1, MaxValue - arr[j], 1, MaxValue);

                    j++;
                }
               
                k++;
            }
   

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                
                g.FillRectangle(BlackBrush, i, 0, 1, MaxValue);
                g.FillRectangle(WhiteBrush, i, MaxValue - arr[i], 1, MaxValue);
      
                i++;
                k++;
            }
            System.Threading.Thread.Sleep(1);

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];

                g.FillRectangle(BlackBrush, j+n1-1, 0, 1, MaxValue);
                g.FillRectangle(WhiteBrush, j+n1-1, MaxValue - arr[j], 1, MaxValue);

                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
        void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

      

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        private void Merge(int i, int p)
        {
            int temp = TheArray[i];
            TheArray[i] = TheArray[i + 1];
            TheArray[i + 1] = temp;

            g.FillRectangle(BlackBrush, i, 0, 1, MaxValue);
            g.FillRectangle(BlackBrush, p, 0, 1, MaxValue);

            g.FillRectangle(WhiteBrush, i, MaxValue - TheArray[i], 1, MaxValue);
            g.FillRectangle(WhiteBrush, p, MaxValue - TheArray[p], 1, MaxValue);

        }

        private bool _IsSorted()
        {
            for (int i = 0; i < TheArray.Length; ++i)
            {
                g.FillRectangle(BlackBrush, i, 0, 1, MaxValue);
                g.FillRectangle(WhiteBrush, i, MaxValue - TheArray[i], 1, MaxValue);
            }
            //for (int i = 0; i < TheArray.Count() - 1; i++)
            //{
            //    if (TheArray[i] > TheArray[i + 1]) { return false; }
            //}
            return true;
        }



        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code
      

    }
}
