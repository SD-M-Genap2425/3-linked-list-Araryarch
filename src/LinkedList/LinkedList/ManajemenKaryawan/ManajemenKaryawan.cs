namespace LinkedList.ManajemenKaryawan
{
    public class Karyawan
    {
        public string NomorKaryawan { get; set; }
        public string Nama { get; set; }
        public string Posisi { get; set; }

        public Karyawan(string nomorKaryawan, string nama, string posisi)
        {
            NomorKaryawan = nomorKaryawan;
            Nama = nama;
            Posisi = posisi;
        }
    }

    public class KaryawanNode
    {
        public Karyawan Karyawan { get; set; }
        public KaryawanNode Next { get; set; }
        public KaryawanNode Prev { get; set; }

        public KaryawanNode(Karyawan karyawan)
        {
            Karyawan = karyawan;
            Next = null!;
            Prev = null!;
        }
    }

    public class DaftarKaryawan
    {
        private KaryawanNode head;
        private KaryawanNode tail;

        public DaftarKaryawan()
        {
            head = null!;
            tail = null!;
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            KaryawanNode newNode = new KaryawanNode(karyawan);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Prev = newNode;
                head = newNode;
            }
        }

        public bool HapusKaryawan(string nomorKaryawan)
        {
            if (head == null)
                return false;

            KaryawanNode current = head;

            while (current != null)
            {
                if (current.Karyawan.NomorKaryawan == nomorKaryawan)
                {
                    if (current == head)
                    {
                        head = current.Next;
                        if (head != null)
                            head.Prev = null!;
                        else
                            tail = null!;
                    }
                    else if (current == tail)
                    {
                        tail = current.Prev;
                        tail.Next = null!;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }

                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public Karyawan[] CariKaryawan(string katakunci)
        {
            if (head == null)
                return new Karyawan[0];

            List<Karyawan> hasilCari = new List<Karyawan>();
            KaryawanNode current = head;

            while (current != null)
            {
                if (current.Karyawan.Nama.ToLower().Contains(katakunci.ToLower()) ||
                    current.Karyawan.NomorKaryawan.ToLower().Contains(katakunci.ToLower()) ||
                    current.Karyawan.Posisi.ToLower().Contains(katakunci.ToLower()))
                {
                    hasilCari.Add(current.Karyawan);
                }

                current = current.Next;
            }

            return hasilCari.ToArray();
        }

        public string TampilkanDaftar()
        {
            if (head == null)
                return string.Empty;

            string result = "";
            KaryawanNode current = head;

            while (current != null)
            {
                result += current.Karyawan.NomorKaryawan + "; " +
                         current.Karyawan.Nama + "; " +
                         current.Karyawan.Posisi;

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