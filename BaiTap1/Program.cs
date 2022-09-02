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
            Cau1b(doThi);
            Cau1c(doThi);
            Cau1d(doThi);
            //Cau2a(doThi);
            //Cau1g(doThi);
            Console.ReadKey();
        }
        
        static void Cau1a(DoThi doThi)
        {
            doThi.InMaTran();
        }
        static void Cau1b(DoThi doThi)
        {
            if(doThi.KiemTraMaTranDoiXung() == true)
                Console.WriteLine("Do Thi Vo Huong");
            else
                 Console.WriteLine("Do Thi Co Huong");
        }
        static void Cau1c(DoThi doThi)
        {
            //int soDinhCuaDoThi = doThi.soDinh + doThi.DemSoLuongDinhCoLapDoThiCoHuong() + doThi.DemSoLuongDinhTreo();
            //Console.WriteLine("So luong dinh co lap: {0}", doThi.DemSoLuongDinhCoLapDoThiCoHuong());
            //Console.WriteLine("So luong dinh treo: {0}", doThi.DemSoLuongDinhTreo());

            Console.WriteLine("So dinh cua do thi ke ca dinh dac biet: {0}",doThi.soDinh);
        }
        static void Cau1d(DoThi doThi)
        {
            //Console.WriteLine("So luong canh boi: {0}", doThi.DemSoLuongCanhBoi());
            //Console.WriteLine("So luong canh khuyen : {0}", doThi.DemSoLuongCanhKhuyen());
            //Console.WriteLine("So luong canh lien thuoc : {0}", doThi.DemSoLuongCanhLienThuoc());
            int soCanhCuaDoThi = doThi.DemSoLuongCanhBoi() + doThi.DemSoLuongCanhKhuyen() + doThi.DemSoLuongCanhLienThuoc();
            Console.WriteLine("So canh cua do thi ke ca canh dac biet: {0}", soCanhCuaDoThi);
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
                Console.WriteLine(doThi.KiemTraDoThiDayDu());
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
