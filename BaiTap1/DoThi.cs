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
                for (j = i + 1; (j < soDinh) && (maTran[i, j] == maTran[j, i]); j++);
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
        public int[] TinhBacCacDinh()
        {
            int[] bacCuaCacDinh = new int[soDinh];
            for(var i = 0; i < soDinh; i++)
            {
                int dem = 0;
                for(var j = 0; j < soDinh; j++)
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
        public int DemSoLuongDinhCoLap()
        {
            var danhSachBacCacDinh = TinhBacCacDinh();
            var dem = 0;
            foreach(var item in danhSachBacCacDinh)
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
    }
}
