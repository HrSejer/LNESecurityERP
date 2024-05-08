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
        public override string Title { get; set; } = "Produkt List";
        protected override void Draw()
        {
            do
            {
                ListPage<Produkt> produktList = new();
                produktList.Add(new Produkt(1, "Computer", "Kan spille", 2500, 9999, "asd2", 2, "styk" ,2500, 2000));
                produktList.Add(new Produkt(2, "Computer", "Kan spille", 2500, 9999, "asd2", 2, "styk", 2500, 2000));
                produktList.Add(new Produkt(3, "Computer", "Kan spille", 2500, 9999, "asd2", 2, "styk", 2500, 2000));

                //used to tell it what data from the class it should use
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
        }
    }
}
