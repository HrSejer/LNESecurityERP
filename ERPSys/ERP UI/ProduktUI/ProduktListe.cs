using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class ProduktListe : Screen
    {
        Database database = Database.Instance;
        public override string Title { get; set; } = "Produkt List";
        protected override void Draw()
        {
            do
            {
                ListPage<Produkt> produktList = new();

                var produkts = database.GetAllProdukter();
                foreach (Produkt produkt in produkts)
                {
                    produktList.Add(produkt);
                }
                produktList.AddKey(ConsoleKey.F3, NewProdukt);
                Console.WriteLine("Tryk F3 for at lave et nyt produkt");

                produktList.AddKey(ConsoleKey.F2, editProdukt);
                Console.WriteLine("Tryk F2 for at redigere produkt");

                produktList.AddKey(ConsoleKey.F5, DeleteProdukt);
                Console.WriteLine("Tryk F5 for at fjerne produkt");

                //used to tell it what data from the class it should use
                produktList.AddColumn("ProduktId", "ProduktId");
                produktList.AddColumn("Varenummer", "Varenummer");
                produktList.AddColumn("Navn", "Navn");
                produktList.AddColumn("Lagerantal", "Antalpaalager");
                produktList.AddColumn("Indkoebspris", "Indkoebspris");
                produktList.AddColumn("Salgspris", "Salgspris");
                produktList.AddColumn("Avance", "Avance");


                ExitOnEscape();
                Produkt selected = produktList.Select();
                if (selected != null)
                {
                    Screen.Display(new SelectedProdukt(selected));
                }
                else
                {
                    Quit();
                    return;
                }
            } while (Show);

            void editProdukt(Produkt produkt)
            {
                Screen.Display(new EditProdukt(produkt));
            }

            void NewProdukt(Produkt _)
            {
                Produkt newprodukt = new();
                Screen.Display(new EditProdukt(newprodukt));
            }

            void DeleteProdukt(Produkt produkt)
            {
                Database.Instance.DeleteProdukt(produkt);
                Screen.Clear(this);
                Draw();
            }
        }
    }
}
