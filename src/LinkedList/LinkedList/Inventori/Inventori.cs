namespace LinkedList.Inventori
{
    public class Item
    {
        public string Nama { get; set; }
        public int Kuantitas { get; set; }

        public Item(string nama, int kuantitas)
        {
            Nama = nama;
            Kuantitas = kuantitas;
        }
    }

    public class ManajemenInventori
    {
        private LinkedList<Item> inventori;

        public ManajemenInventori()
        {
            inventori = new LinkedList<Item>();
        }

        public void TambahItem(Item item)
        {
            inventori.AddLast(item);
        }

        public bool HapusItem(string nama)
        {
            var currentNode = inventori.First;
            while (currentNode != null)
            {
                if (currentNode.Value.Nama.Equals(nama, StringComparison.OrdinalIgnoreCase))
                {
                    inventori.Remove(currentNode);
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public string TampilkanInventori()
        {
            string result = "";
            var currentNode = inventori.First;
            while (currentNode != null)
            {
                result += currentNode.Value.Nama + "; " + currentNode.Value.Kuantitas + "\n";
                currentNode = currentNode.Next;
            }
            return result.TrimEnd();
        }
    }
}
