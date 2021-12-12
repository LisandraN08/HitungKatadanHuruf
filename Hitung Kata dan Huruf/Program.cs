using System;
using System.Linq;
using System.Text.RegularExpressions;
namespace Hitung_Kata_dan_Huruf
{
    class Program
    {
        public static void totalKata(string inputKata, string inputKalimat)
        {
            int jumlahKata = 0;
            foreach (Match katasama in Regex.Matches(inputKalimat, inputKata))
            {
                jumlahKata = jumlahKata+1;
            }
            Console.WriteLine($"{inputKata}: {jumlahKata} KATA");
        }
        static void Main(string[] args)
        {
            Console.Write("INPUT KALIMAT: ");
            string inputKalimat = Console.ReadLine().ToUpper();
            string[] Spasi = inputKalimat.Split(" ");
            while (Spasi.Length <= 2)
            {
                Console.Write("KATA PADA KALIMAT KURANG PANJANG\nINPUT KALIMAT: ");
                string inputKalimat2 = Console.ReadLine().ToUpper();
                inputKalimat = inputKalimat2;
                Spasi = inputKalimat.Split(" ");
            }
            Console.Write("INPUT KATA: ");
            string inputKata = Console.ReadLine().ToUpper();
            while (inputKata.Length < 2)
            {
                Console.Write("HURUF PADA KATA KURANG PANJANG\nINPUT KATA: ");
                string inputKata2 = Console.ReadLine().ToUpper();
                inputKata = inputKata2;
            }
            char[] urutanKalimat = inputKalimat.ToCharArray();
            Array.Sort(urutanKalimat);
            string[] pembagianKalimat = inputKalimat.Split(' ');
            int jumlahHuruf = 0;
            Console.WriteLine("STATISTIK HURUF:");
            foreach (var kalimat in pembagianKalimat)
            {
                var groupingValue = urutanKalimat.GroupBy(v => v);
                foreach (var group in groupingValue)
                {
                    if (group.Key != ' ')
                    {
                        Console.WriteLine($"{group.Key}: {group.Count()} HURUF");
                        jumlahHuruf = jumlahHuruf + group.Count();
                    }
                }
                break;
            }
            Console.WriteLine();
            Console.WriteLine("STATISTIK KATA:");
            totalKata(inputKata, inputKalimat);
            Console.WriteLine();
            Console.Write($"JUMLAH HURUF: {jumlahHuruf}");

        }
    }
}
