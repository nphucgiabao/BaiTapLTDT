using System;
using System.Threading.Tasks;

namespace BaiTap1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Cau1a(doThi);
            Cau1e(doThi);
            Cau1g(doThi);
            Console.ReadKey();
        }
        
        static void Cau1a(DoThi doThi)
        {
            //code
            //doThi.InMaTran();
        }
        static void Cau1b(DoThi doThi)
        {
            //Code
        }
        static void Cau1c(DoThi doThi)
        {
            //Code
        }
        static void Cau1d(DoThi doThi)
        {
            //Code
        }
        static void Cau1e(DoThi doThi)
        {
            int soCapDinhXuatHienCanhBoi = 0;
            int soCanhKhuyen = 0;
            for(var i = 0; i < doThi.soDinh; i++)
            {
                if (doThi.maTran[i, i] > 0)
                    soCanhKhuyen++;
                for(var j = i + 1; j < doThi.soDinh; j++)
                {
                    if (doThi.maTran[i, j] == doThi.maTran[j, j])
                        soCapDinhXuatHienCanhBoi++;
                }
            }
            Console.WriteLine("So cap dinh xuat hien canh boi: {0}", soCapDinhXuatHienCanhBoi > 0 ? soCapDinhXuatHienCanhBoi / 2 : 0);
            Console.WriteLine("So canh khuyen: {0}", soCanhKhuyen);
        }
        static void Cau1f(DoThi doThi)
        {
            //Code
        }
        static void Cau1g(DoThi doThi)
        {
            
            if (doThi.KiemTraMaTranDoiXung())
            {

            }
            else
            {
                var result = "(Bac vao - Bac ra) cua tung dinh: ";
                var bacCuaCacDinh = doThi.TinhBacCacDinhCoHuong();
                for(var i = 0; i < doThi.soDinh; i++)
                {
                    result += $"{i}({bacCuaCacDinh[i, 0]} - {bacCuaCacDinh[i, 1]}) ";
                }
                result.Remove(result.Length - 1);
                Console.WriteLine(result);
            }
        }
        static void Cau1h(DoThi doThi)
        {
            //Code
        }
        static void Cau2a(DoThi doThi)
        {
            //Code
        }
        static void Cau2b(DoThi doThi)
        {
            //Code
        }
        static void Cau2c(DoThi doThi)
        {
            //Code
        }
    }
}
