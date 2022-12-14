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
            Cau1e(doThi);
            Cau1f(doThi);
            Cau1g(doThi);
            Cau1h(doThi);
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
                if (doThi.KiemTraMaTranDoiXung())
                {
                    for (var j = 0; j < doThi.soDinh; j++)
                    {
                        if (doThi.maTran[i, j] > 1 && doThi.maTran[j, i] > 1)
                        {
                            soCapDinhXuatHienCanhBoi++;
                        }
                    }
                }
                else
                {
                    for (var j = 0; j < doThi.soDinh; j++)
                    {
                        if (doThi.maTran[i, j] > 0 && j != i && doThi.maTran[j, i] == doThi.maTran[i, j])
                        {
                            soCapDinhXuatHienCanhBoi++;
                        }
                    }
                }
                
            }
            Console.WriteLine("So cap dinh xuat hien canh boi: {0}", soCapDinhXuatHienCanhBoi > 0 ? soCapDinhXuatHienCanhBoi / 2 : 0);
            Console.WriteLine("So canh khuyen: {0}", soCanhKhuyen);
        }
        static void Cau1f(DoThi doThi)
        {
            int soDinhCoLap = 0;
            int soDinhTreo = 0;
            if (doThi.KiemTraMaTranDoiXung())
            {
                foreach(var item in doThi.TinhBacCacDinhVoHuong())
                {
                    if (item == 1)
                        soDinhTreo++;
                    if (item == 0)
                        soDinhCoLap++;
                }                
            }
            else
            {
                var bacCuaCacDinh = doThi.TinhBacCacDinhCoHuong();
               
                for(var i = 0; i< doThi.soDinh; i++)
                {
                    if (bacCuaCacDinh[i, 0] == 0 && bacCuaCacDinh[i, 1] == 0)
                        soDinhCoLap++;
                    if ((bacCuaCacDinh[i, 0] == 1 && bacCuaCacDinh[i, 1] == 0) || (bacCuaCacDinh[i, 0] == 0 && bacCuaCacDinh[i, 1] == 1))
                        soDinhTreo++;
                }
            }
            Console.WriteLine("So dinh treo: {0}", soDinhTreo);
            Console.WriteLine("So dinh co lap: {0}", soDinhCoLap);
        }
        static void Cau1g(DoThi doThi)
        {
            
            if (doThi.KiemTraMaTranDoiXung())
            {
                var result = "Bac cua tung dinh: ";
                var danhSachBacCuaCacDinh = doThi.TinhBacCacDinhVoHuong();
                for (var i = 0; i < danhSachBacCuaCacDinh.Length; i++)
                {
                    result += $"{i}({danhSachBacCuaCacDinh[i]}) ";
                }
                result.Remove(result.Length - 1);
                Console.WriteLine(result);
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
            if (doThi.KiemTraMaTranDoiXung())
            {
                if (doThi.KiemTraCoChuaCanhKhuyen())
                {
                    Console.WriteLine("Gia do thi");
                    return;
                }
                int soCapDinhXuatHienCanhBoi = 0;
                for (var i = 0; i < doThi.soDinh; i++)
                {
                    for (var j = 0; j < doThi.soDinh; j++)
                    {
                        if (doThi.maTran[i, j] > 1 && doThi.maTran[j, i] > 1)
                        {
                            soCapDinhXuatHienCanhBoi++;
                        }
                    }
                }
                if (soCapDinhXuatHienCanhBoi > 0)
                {
                    Console.WriteLine("Da do thi");
                    return;
                }
                Console.WriteLine("Don do thi");
            }
            else
            {
                int soCapDinhXuatHienCanhBoi = 0;              
                for (var i = 0; i < doThi.soDinh; i++)
                {
                    for (var j = i; j < doThi.soDinh; j++)
                    {
                        if (doThi.maTran[i, j] > 0 && j != i && doThi.maTran[j, i] == doThi.maTran[i, j])
                        {
                            soCapDinhXuatHienCanhBoi++;
                        }
                    }
                }
                if (soCapDinhXuatHienCanhBoi > 0)
                {
                    Console.WriteLine("Da do thi co huong");
                    return;
                }
                Console.WriteLine("Do thi co huong");
            }
        }        
    }
}
