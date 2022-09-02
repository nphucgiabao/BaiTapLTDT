using BaiTap1;
using System;
using System.Threading.Tasks;

namespace BaiTap2
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var doThi = new DoThi();
            await doThi.DocFileAsync("../../../input.txt");
            Cau2a(doThi);
            Cau2b(doThi);
            Cau2c(doThi);
            Console.ReadKey();
        }
        static void Cau2a(DoThi doThi)
        {
            Console.WriteLine(doThi.KiemTraDoThiDayDu());
        }
        static void Cau2b(DoThi doThi)
        {
            var danhSachBacCuaCacDinh = doThi.TinhBacCacDinhVoHuong();
            var bacDinhDauTien = danhSachBacCuaCacDinh[0];
            for (var i = 1; i < danhSachBacCuaCacDinh.Length; i++)
            {
                if (bacDinhDauTien != danhSachBacCuaCacDinh[i])
                {
                    Console.WriteLine("Day khong phai la do thi chinh quy.");
                    return;
                }
            }
            Console.WriteLine("Day la do thi {0}-chinh quy", bacDinhDauTien);
        }
        static void Cau2c(DoThi doThi)
        {
            for (var i = 0; i < doThi.soDinh; i++)
            {
                for (var j = 0; j < doThi.soDinh; j++)
                {
                    if (doThi.maTran[i, j] > 0)
                    {
                        for (var k = 0; k < doThi.soDinh; k++)
                        {
                            if (k != i && doThi.maTran[j, k] > 0 && doThi.maTran[k, i] > 0)
                            {
                                Console.WriteLine("Day khong phai la do thi vong");
                                return;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"Day la do thi vong C{doThi.soDinh}");
        }
    }
}
