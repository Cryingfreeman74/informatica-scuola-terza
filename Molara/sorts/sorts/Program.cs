using System;
namespace sorts
{
    public class BinaryHeap<T>
    {
        private IComparer<T> comparer;

        private List<T> heap = new();

        public BinaryHeap(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public BinaryHeap()
        {
            if (!typeof(IComparable).IsAssignableFrom(typeof(T)))
                throw new ArgumentException("No default comparator is available for the given type.");
            this.comparer = Comparer<T>.Default;
        }

        public int Count { get { return heap.Count; } }

        public T Top()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Cannot get top of empty heap");
            return heap[0];
        }

        public void Insert(T item)
        {
            heap.Add(item);
            for (int i = heap.Count - 1; i > 0 && comparer.Compare(heap[(i - 1) / 2], heap[i]) < 0; i = (i - 1) / 2)
                (heap[(i - 1) / 2], heap[i]) = (heap[i], heap[(i - 1) / 2]);
        }

        public void Remove()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Cannot remove from empty heap");
            (heap[0], heap[heap.Count - 1]) = (heap[heap.Count - 1], heap[0]);
            heap.RemoveAt(heap.Count - 1);
            int i = 0;
            while (i < heap.Count)
            {
                int max = i;
                if (2 * i + 1 < heap.Count && comparer.Compare(heap[max], heap[2 * i + 1]) < 0)
                    max = 2 * i + 1;
                if (2 * i + 2 < heap.Count && comparer.Compare(heap[max], heap[2 * i + 2]) < 0)
                    max = 2 * i + 2;
                if (max == i)
                    break;
                (heap[i], heap[max]) = (heap[max], heap[i]);
                i = max;
            }
        }
    }
    internal class Program
    {
        static void swap(int[] vett, int swapped, int new_pos)
        {
            int temp = vett[new_pos];
            vett[new_pos] = vett[swapped];
            vett[swapped] = temp;
        }
        static void bubble_sort(int[] vett)
        {
            bool sostituzioni = true;
            while (sostituzioni)
            {
                sostituzioni = false;
                for (int i = 0; i < vett.Length-1; i++)
                    if (vett[i] > vett[i + 1]) { swap(vett, i, i + 1); sostituzioni = true; }
            }
        }

        static void Op_bubble_sort(int[] vett)
        {
            bool sostituzioni = true;
            int limite = vett.Length - 1;
            
            while (sostituzioni)
            {
                sostituzioni = false;
                int new_limite = 0;
                for (int i = 0; i < limite; i++)
                    if (vett[i] > vett[i + 1]) { swap(vett, i, i + 1); sostituzioni = true; new_limite = i; }
               
                limite = new_limite;
            }
        }
        static void Op_bubble_sort2(int[] vett)
        {
            bool sostituzioni = true;
            int limite = vett.Length - 1;

            while (sostituzioni)
            {
                sostituzioni = false;
                for (int i = 0; i < limite; i++)
                    if (vett[i] > vett[i + 1]) { swap(vett, i, i + 1); sostituzioni = true; }

                limite -= 1;
            }
        }

        static void MergeSortAlgorithm(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSortAlgorithm(arr, left, mid);
                MergeSortAlgorithm(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }

        static void selection_sort(int[] vett)
        {
            for(int i = 0; i<vett.Length; i++)
            {
                int min = i;
                for(int j = i; j < vett.Length; j++)
                {
                    if (vett[j] < vett[min]) min = j;
                }
                if(min != i) swap(vett, i, min);
            }
        }

        static void heapSort(int[] vett)
        {
            BinaryHeap<int> heap = new BinaryHeap<int>();
            foreach (int i in vett) heap.Insert(i);

            for(int i = vett.Length-1; i >= 0; i--)
            {
                vett[i] = heap.Top();
                heap.Remove();
            }

        }

        public static void QuickSort(int[] array, int init, int end)
        {
            if (init < end)
            {
                int pivot = Partition(array, init, end);
                QuickSort(array, init, pivot - 1);
                QuickSort(array, pivot + 1, end);
            }
        }

        //O(n)
        private static int Partition(int[] array, int init, int end)
        {
            int last = array[end];
            int i = init - 1;
            for (int j = init; j < end; j++)
            {
                if (array[j] <= last)
                {
                    i++;
                    Exchange(array, i, j);
                }
            }
            Exchange(array, i + 1, end);
            return i + 1;
        }

        private static void Exchange(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }


        static void quicksort(int[] input, int low, int high)
        {
            int pivot_loc = 0;

            if (low < high)
            {
                pivot_loc = partition(input, low, high);
                quicksort(input, low, pivot_loc - 1);
                quicksort(input, pivot_loc + 1, high);
            }
        }

        static int partition(int[] input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high - 1; j++)
            {
                if (input[j] <= pivot)
                {
                    i++;
                    swap(input, i, j);
                }
            }
            swap(input, i + 1, high);
            return i + 1;
        }
        static void Main(string[] args)
        {
            int[] vett1 = new int[10000];
            int[] vett2 = new int[10000];
            int[] vett3 = new int[10000];
            int[] vett4 = new int[10000];
            int[] vett5 = new int[10000];
            int[] vett6 = new int[10000];
            int[] vett7 = new int[10000];
            int[] vett8 = new int[10000];
            Random random = new Random();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();

            for(int i = 0; i < vett1.Length;i++) vett1[i] = random.Next(0, 1000000);
            for (int i = 0; i < vett1.Length; i++) vett2[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett3[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett4[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett5[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett6[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett7[i] = vett1[i];
            for (int i = 0; i < vett1.Length; i++) vett8[i] = vett1[i];

            stopwatch.Start();
            bubble_sort(vett1);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            selection_sort(vett2);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            Op_bubble_sort(vett3);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            Op_bubble_sort2(vett4);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            MergeSortAlgorithm(vett5, 0, vett5.Length-1);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            heapSort(vett6);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            quicksort(vett7, 0, vett7.Length-1);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);

            Console.WriteLine("\n------------------------------------------------------");

            stopwatch.Restart();
            quicksort(vett8, 0, vett8.Length - 1);
            stopwatch.Stop();
            Console.Write(">" + stopwatch.ElapsedMilliseconds);
        }
    }
}