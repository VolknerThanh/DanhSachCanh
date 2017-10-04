using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DanhSachCanh
{
    class Program
    {
        public static int n_mt;
        public static int n_ds;
        public static int[,] matranke;
        public static LinkedList<int>[] dske;
        public static LinkedList<int>[] dscanh;

        #region Input Output matranke va danhsachke
        public static void InputMaTranKe()
        {
            StreamReader sr = new StreamReader("Graph.inp");
            n_mt = int.Parse(sr.ReadLine());
            matranke = new int[n_mt, n_mt];
            for(int i = 0; i < n_mt; i++)
            {
                string[] s = sr.ReadLine().Trim().Split(' ');
                for (int j = 0; j < s.Length; j++)
                    matranke[i, j] = int.Parse(s[j]);
            }
            sr.Close();
        }
        public static void OutputMaTranKe()
        {
            Console.WriteLine("Ma Tran Ke : ");
            for (int i = 0; i < n_mt; i++)
            {
                for(int j =0; j< n_mt; j++)
                {
                    Console.Write(matranke[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        public static void InputDanhSachKe()
        {
            StreamReader sr = new StreamReader("graph_2.inp");
            n_ds = int.Parse(sr.ReadLine());
            dske = new LinkedList<int>[n_ds];
            for(int i = 0; i < n_ds; i++)
            {
                string[] s = sr.ReadLine().Trim().Split(' ');
                dske[i] = new LinkedList<int>();
                for (int j = 0; j < s.Count(); j++)
                    dske[i].AddLast(int.Parse(s[j]));
            }
            sr.Close();
        }
        public static void OutputDanhSachKe()
        {
            Console.WriteLine("Danh Sach Ke : ");
            for (int i = 0; i < n_ds; i++)
            {
                foreach (var x in dske[i])
                    Console.Write(x + " ");
                Console.WriteLine();
            }
        }
        #endregion
        public static int CountLevel_matranke()
        {
            int Count = 0;
            for(int i =0; i < n_mt; i++)
            {
                for(int j = 0; j < n_mt;j++)
                {
                    if (matranke[i, j] != 0)
                        Count++;
                }
            }
            return Count;
        }

        public static void Transfer_from_danhsachke__to_danhsachcanh()
        {
            int n = CountLevel_matranke();
            dscanh = new LinkedList<int>[n];
            int dem = 0;
            for (int i = 0; i < n_ds; i++)
            {
                foreach(int x in dske[i])
                {
                    dscanh[dem] = new LinkedList<int>();
                    dscanh[dem].AddLast(i + 1);
                    dscanh[dem].AddLast(x);
                    dem ++;
                }
            }
            Console.WriteLine("Danh Sach ke -> Danh Sach Canh : ");
            for (int i = 0; i < n; i++)
            {
                foreach (var items in dscanh[i])
                    Console.Write(items + " ");
                Console.WriteLine();
            }
        }
        public static void Transfer_from_matranke_to_danhsachcanh()
        {
            int n = CountLevel_matranke();
            dscanh = new LinkedList<int>[n];
            int dem = 0;
            for(int i = 0; i < n_mt; i++)
            {
                for(int j = 0; j < n_mt; j++)
                {
                    if(matranke[i,j] != 0)
                    {
                        dscanh[dem] = new LinkedList<int>();
                        dscanh[dem].AddLast(i + 1);
                        dscanh[dem].AddLast(j + 1);
                        dem++;
                    }
                }
            }
            Console.WriteLine("Ma Tran ke -> Danh Sach Canh : ");
            for (int i = 0; i < n; i++)
            {
                foreach (var items in dscanh[i])
                    Console.Write(items + " ");
                Console.WriteLine();
            }
        }
        public static void Transfer_from_danhsachcanh_to_danhsachke()
        {
            Console.WriteLine("Danh sach canh -> danh sach ke : ");
            int n = CountLevel_matranke();
            //LinkedList<int>[] ds = new LinkedList<int>[n_ds];
            int dem = 0;
            for (int i = 0; i < n; i++)
            {
                if (dscanh[i].First() > dem + 1)
                {
                    dem++;
                    Console.WriteLine();
                }
                //ds[dem] = new LinkedList<int>();
                foreach (int items in dscanh[i])
                {
                    if (items == dscanh[i].First())
                        continue;
                    Console.Write(items + " ");
                    //ds[dem].AddLast(items);
                }
            }
            Console.WriteLine();
            
        }
        static void Main(string[] args)
        {
            InputMaTranKe();
            OutputMaTranKe();
            InputDanhSachKe();
            OutputDanhSachKe();
            Console.WriteLine();
            Transfer_from_danhsachke__to_danhsachcanh();
            Transfer_from_matranke_to_danhsachcanh();
            Transfer_from_danhsachcanh_to_danhsachke();
        }
    }
}
