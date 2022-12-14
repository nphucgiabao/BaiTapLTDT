using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap1
{
    public class DoThi
    {
        public int soDinh { get; set; }
        public int[,] maTran { get; set; }
        public async Task DocFileAsync(string duongDan)
        {
            if (File.Exists(duongDan))
            {
                using (var stream = new StreamReader(duongDan))
                {
                    var content = await stream.ReadToEndAsync();
                    var lines = content.Split("\n");
                    soDinh = int.Parse(lines[0]);
                    maTran = new int[soDinh, soDinh];
                    for (var i = 0; i < soDinh; ++i)
                    {
                        var values = lines[i + 1].Split(" ");
                        for (var j = 0; j < values.Length; ++j)
                        {
                            if (values != null)
                                maTran[i, j] = int.Parse(values[j]);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found!!!");
            }
        }
        public bool KiemTraMaTranDoiXung()
        {
            var result = true;
            int i, j;
            for (i = 0; i < soDinh && result; i++)
            {
                for (j = i + 1; (j < soDinh) && (maTran[i, j] == maTran[j, i]); j++) ;
                if (j < soDinh)
                    result = false;
            }
            return result;
        }
        public bool KiemTraCoChuaCanhKhuyen()
        {
            for (var i = 0; i < soDinh && maTran[i, i] == 0; i++)
                if (i < soDinh)
                    return false;
            return true;
        }
        public int[] TinhBacCacDinhVoHuong()
        {
            int[] bacCuaCacDinh = new int[soDinh];
            for (var i = 0; i < soDinh; i++)
            {
                int dem = 0;
                for (var j = 0; j < soDinh; j++)
                {
                    if (maTran[i, j] != 0)
                    {
                        dem += maTran[i, j];
                        if (i == j)
                            dem += maTran[i, j];
                    }

                }
                bacCuaCacDinh[i] = dem;
            }
            return bacCuaCacDinh;
        }
        public int[,] TinhBacCacDinhCoHuong()
        {
            var bacCuaCacDinh = new int[soDinh, 2];
            for (var i = 0; i < soDinh; i++)
            {
                int bacRa = 0;
                int bacVao = 0;
                for (var j = 0; j < soDinh; j++)
                {
                    if (maTran[i, j] > 0)
                        bacRa++;
                    if (maTran[j, i] > 0)
                        bacVao++;
                }
                bacCuaCacDinh[i, 1] = bacRa;
                bacCuaCacDinh[i, 0] = bacVao;
            }
            return bacCuaCacDinh;
        }
        public int DemSoLuongDinhCoLapDoThiVoHuong()
        {
            var danhSachBacCacDinh = TinhBacCacDinhVoHuong();
            var dem = 0;
            foreach (var item in danhSachBacCacDinh)
            {
                if (item == 0)
                    dem++;
            }
            return dem;
        }
        public void InMaTran()
        {
            for (var i = 0; i < soDinh; i++)
            {
                for (var j = 0; j < soDinh; j++)
                {
                    Console.Write("{0} ", maTran[i, j]);
                }
                Console.Write("\n");
            }
        }

        // Kay
        public int DemSoLuongDinhTreo()
        {
            var danhSachBacCacDinh = TinhBacCacDinhVoHuong();
            var dem = 0;
            foreach (var item in danhSachBacCacDinh)
            {
                if (item == 1)
                    dem++;
            }
            return dem;
        }

        public int DemSoLuongDinhCoLapDoThiCoHuong()
        {
            var bacCuaCacDinh = TinhBacCacDinhCoHuong();
            var dem = 0;
            for (var i = 0; i < soDinh; i++)
            {
                //sConsole.WriteLine(bacCuaCacDinh[i, 0] + bacCuaCacDinh[i, 1]);
                if (bacCuaCacDinh[i, 0] + bacCuaCacDinh[i, 1] == 1)
                {
                    dem++;
                }
            }
            return dem;
        }

        public int DemSoLuongCanhKhuyen()
        {
            var soCanhKhuyen = 0;
            for (var i = 0; i < soDinh; i++)
            {
                if (maTran[i, i] == 1)
                    soCanhKhuyen++;
            }
            return soCanhKhuyen;

        }


        public int DemSoLuongCanhBoi() // do thi vo huong
        {
            var soCanhBoi = 0;
            for (var i = 0; i < soDinh; i++)
            {
                for (var j = 0; j < soDinh; j++)
                {
                    if ((maTran[i, j] > 1) && (i != j) && (maTran[i, j] == maTran[j, i]))
                        soCanhBoi++;
                }

            }
            return soCanhBoi;

        }

        public int DemSoLuongCanhLienThuoc() // do thi vo huong
        {
            var soCanhLienThuoc = 0;
            var tongCanh = 0;
            var canhTrung = 0;
            for (var i = 0; i < soDinh; i++)
            {
                for (var j = 0; j < soDinh; j++)
                {
                    if (maTran[i, j] != 0)
                    {
                        tongCanh++;
                    }
                    if (maTran[i, j] ==1 && maTran[i, j] == maTran[j, i] && i != j)
                    {
                        canhTrung++;
                    }
                }


                soCanhLienThuoc = tongCanh - canhTrung/2 - DemSoLuongCanhBoi() - DemSoLuongCanhKhuyen();
            }
            return soCanhLienThuoc;
        }

        public String KiemTraDoThiDayDu()
        {
            int i, j;
            var canhKhuyen = 0;
            var dem = 0;
            for (i = 0; i < soDinh; i++)
            {
                if (maTran[i,i]==0)
                {
                    canhKhuyen++;
                }
            }
            for (i = 0; i < soDinh; i++)
            {
                for (j = 0; j < soDinh; j++)
                {
                    if (maTran[i, j] == maTran[j, i] && maTran[i, j] == 1)
                        dem++;
                }
            }
            if ((soDinh * soDinh - canhKhuyen) == dem)
            {
                return "Day la Do Thi Day Du: K"+ canhKhuyen;
            }
            return "Day khong phai la do thi day du";
        }
    }
}
