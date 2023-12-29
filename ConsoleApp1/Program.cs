using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NguyenHoangLam
{
    public class ViecCanLam
    {
        public string vieccanlam { get; set; }
        public int thutuuutien { get; set; }
        public string motacongviec { get; set; }
        public string trangthai { get; set; }
        public ViecCanLam() { }
        public ViecCanLam(string vieccl, int thutu, string mota, string status)
        {
            vieccanlam = vieccl;
            thutuuutien = thutu;
            motacongviec = mota;
            trangthai = status;
        }

    }

    internal class Program
    {  
        static List<ViecCanLam> listvieccanlam = new List<ViecCanLam>();
        static void Main(string[] args)
        {   Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                HienThiThongBao();
                Console.Write("Chọn chức năng thực hiện: ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        Khaibao();
                        break;
                    case 2:
                        XoaDanhSach();
                        break;
                    case 4:
                        timkiemvieccanlam();
                        break;
                    case 5:
                        SapXepTangDan();
                        break;
                    case 6:
                        XemDanhXach();
                        break;
                    default:
                        Console.WriteLine("Chức năng không tồn tại");
                        break;
                }

                Console.WriteLine("Nhấn Y để thoát!");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                {
                    break;
                }
                Console.Clear();
            }

        }
        public static void HienThiThongBao()
        {
            Console.WriteLine("1.Khai báo thông tin việc cần làm");
            Console.WriteLine("2.Xóa thông tin việc cần làm dựa vào vị trí");
            Console.WriteLine("3.Cập nhật vị trí");
            Console.WriteLine("4.Tìm kiếm theo tên việc cần làm");
            Console.WriteLine("5.Hiện thị danh sách việc cần làm theo độ ưu tiên giảm dần");
            Console.WriteLine("6.Hiện thị toàn bộ danh sách");
        }
        public static void Khaibao()
        {
            try
            {
                Console.WriteLine("Nhập việc cần làm");
                string vieccl = Console.ReadLine();
                Console.WriteLine("Độ ưu tiên công việc");
                int uutien = int.Parse(Console.ReadLine());
                Console.WriteLine("Mô tả công việc");
                string mota = Console.ReadLine();
                Console.WriteLine("Trạng Thái Công Việc");
                string trangthai = Console.ReadLine();

                ViecCanLam vl = new ViecCanLam(vieccl, uutien, mota, trangthai);
                listvieccanlam.Add(vl);
            }
            catch (Exception)
            {
                Console.WriteLine("ĐỘ ƯU TIÊN PHẢI NHẬP SỐ");
            }
        }
        public static void XoaDanhSach()
        {try
            {
                Console.WriteLine("xóa thông tin việc làm dựa vào vị trí nhập");
                int n = int.Parse(Console.ReadLine());
                listvieccanlam.RemoveAt(n);
            }
            catch (Exception)
            {
                Console.WriteLine("Lỗi ! PHẢI NHẬP SỐ");
            }

        }

    
        public static void timkiemvieccanlam()
        {
            Console.WriteLine("Nhập Tên việc cần làm");
            string vieccanlam = Console.ReadLine();
            var item = listvieccanlam.FirstOrDefault(c => c.vieccanlam.ToLower().Contains(vieccanlam.ToLower()));
            if (item == null)
            {
                Console.WriteLine("Không có trong danh sách");
            }
            else
            {
                Console.WriteLine("Việc Cần Làm : {0}", item.vieccanlam);
                Console.WriteLine("Độ Ưu Tiên : {0}", item.thutuuutien);
                Console.WriteLine("Mô Tả Công Việc: {0}", item.motacongviec);
                Console.WriteLine("Trạng Thái Công Việc : {0}\n", item.trangthai);
            }

        }
        public static void SapXepTangDan()
        {
            var temp = listvieccanlam.OrderByDescending(c => c.thutuuutien).ToList();
            foreach (var item in temp)
            {
                Console.WriteLine("Việc Cần Làm : {0}", item.vieccanlam);
                Console.WriteLine("Độ Ưu Tiên : {0}", item.thutuuutien);
                Console.WriteLine("Mô Tả Công Việc: {0}", item.motacongviec);
                Console.WriteLine("Trạng Thái Công Việc : {0}\n", item.trangthai);
            }
        }
        public static void XemDanhXach() //in danh sach
        {
            Console.WriteLine("Danh Sách Việc Làm");
            foreach (var item in listvieccanlam)
            {
                Console.WriteLine("Việc Cần Làm : {0}", item.vieccanlam);
                Console.WriteLine("Độ Ưu Tiên : {0}", item.thutuuutien);
                Console.WriteLine("Mô Tả Công Việc: {0}", item.motacongviec);
                Console.WriteLine("Trạng Thái Công Việc : {0}\n", item.trangthai);
            }
        }
    }

    
}