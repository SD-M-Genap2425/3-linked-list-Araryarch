using LinkedList.Inventori;
using LinkedList.ManajemenKaryawan;
using LinkedList.Perpustakaan;

namespace LinkedList;

class Program
{
    static void Main(string[] args)
    {
        // Soal Perpustakaan
        var perpustakaan = new KoleksiPerpustakaan();
        string result = perpustakaan.TampilkanKoleksi();

        // Soal ManajemenKaryawan
        var daftar = new DaftarKaryawan();
        daftar.TambahKaryawan(new Karyawan("001", "John Doe", "Manager"));
        var hasilCari = daftar.CariKaryawan("Jane");

        // Soal Inventori
        var manajemen = new ManajemenInventori();
        manajemen.TambahItem(new Item("Apple", 50));
        bool penghapusanBerhasil = manajemen.HapusItem("Orange");
    }
}
