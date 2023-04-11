using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;


namespace modul8_1302210055
{
    public class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public string[] methods { get; set; }
        public Confirmation confirmation { get; set; }
    }

    public class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    public class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Load the default values from the JSON file
            string json = @"{
            ""lang"": ""id"",
            ""transfer"": {
                ""threshold"": 25000000,
                ""low_fee"": 6500,
                ""high_fee"": 15000
            },
            ""methods"": [
                ""RTO (real-time)"",
                ""SKN"",
                ""RTGS"",
                ""BI FAST""
            ],
            ""confirmation"": {
                ""en"": ""yes"",
                ""id"": ""ya""
            }
        }";

            BankTransferConfig config = JsonConvert.DeserializeObject<BankTransferConfig>(json);


            if (config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
            }

            int amount = Convert.ToInt32(Console.ReadLine());


            int transferFee = amount <= config.transfer.threshold ? config.transfer.low_fee : config.transfer.high_fee;
            int totalAmount = amount + transferFee;


            if (config.lang == "en")
            {
                Console.WriteLine("Transfer fee = " + transferFee);
                Console.WriteLine("Total amount = " + totalAmount);
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Biaya transfer = " + transferFee);
                Console.WriteLine("Total biaya = " + totalAmount);
            }


            for (int i = 0; i < config.methods.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + config.methods[i]);
            }


            if (config.lang == "en")
            {
                Console.WriteLine("Please type \"" + config.confirmation.en + "\" to confirm the transaction:");
            }
            else if (config.lang == "id")
            {
                Console.WriteLine("Ketik \"" + config.confirmation.id + "\" untuk mengkonfirmasi transaksi:");
            }

            string confirmationInput = Console.ReadLine();


            if (confirmationInput == config.confirmation.en || confirmationInput == config.confirmation.id)
            {

                if (config.lang == "en")
                {
                    Console.WriteLine("The transfer is completed");
                }
                else if (config.lang == "id")
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
            }
            else
            {

                if (config.lang == "en")
                {
                    Console.WriteLine("Invalid confirmation input. The transfer is not completed.");
                }
                else if (config.lang == "id")
                {
                    Console.WriteLine("Input konfirmasi tidak valid. Proses transfer tidak berhasil.");
                }
            }


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}