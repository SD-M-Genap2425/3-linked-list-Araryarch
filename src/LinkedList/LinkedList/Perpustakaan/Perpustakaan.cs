namespace LinkedList.Perpustakaan
{
    public class Buku
    {

        public string Judul { get; set; }
        public string Penulis { get; set; }
        public int Tahun { get; set; }

        public Buku(string judul, string penulis, int tahun)
        {
            Judul = judul;
            Penulis = penulis;
            Tahun = tahun;
        }
    }

    public class BukuNode
    {
        public Buku Data { get; set; }
        public BukuNode Next { get; set; }

        public BukuNode(Buku buku)
        {
            Data = buku;
            Next = null!;
        }
    }

    public class KoleksiPerpustakaan
    {
        private BukuNode head;

        public KoleksiPerpustakaan()
        {
            head = null!;
        }

        public void TambahBuku(Buku buku)
        {
            BukuNode newNode = new BukuNode(buku);

            if (head == null)
            {
                head = newNode;
                return;
            }

            BukuNode temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }

        public Buku[] CariBuku(string judulBuku)
        {
            if (head == null)
                return new Buku[0];

            List<Buku> hasilPencarian = new List<Buku>();
            BukuNode current = head;

            while (current != null)
            {
                if (current.Data.Judul.Contains(judulBuku))
                {
                    hasilPencarian.Add(current.Data);
                }
                current = current.Next;
            }

            return hasilPencarian.ToArray();
        }

        public bool HapusBuku(string judulBuku)
        {
            if (head == null)
                return false;

            if (head.Data.Judul == judulBuku)
            {
                head = head.Next;
                return true;
            }

            BukuNode current = head;
            BukuNode previous = null!;

            while (current != null && current.Data.Judul != judulBuku)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)
                return false;

            previous!.Next = current.Next;
            return true;
        }

        public string TampilkanKoleksi()
        {
            if (head == null)
                return string.Empty;

            string result = "";
            BukuNode current = head;

            while (current != null)
            {
                result += "\"" + current.Data.Judul + "\"; " +
                          current.Data.Penulis + "; " +
                          current.Data.Tahun;

                if (current.Next != null)
                {
                    result += "\r\n";
                }

                current = current.Next!;
            }

            return result;
        }
    }
}