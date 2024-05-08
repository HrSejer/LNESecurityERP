using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SelectedProdukt(Produkt produkt) : Screen
    {
        public override string Title { get; set; } = "Selected Produkt";
        protected override void Draw()
        {
            Clear(this);

            ListPage<Produkt> selectedProdukt = new ListPage<Produkt>();
            selectedProdukt.Add(produkt);
            selectedProdukt.AddColumn("Varenummer", "Varenummer");
            selectedProdukt.AddColumn("Navn", "Navn");
            selectedProdukt.AddColumn("Beskrivelse", "Beskrivelse");
            selectedProdukt.AddColumn("Salgspris", "Salgspris");
            selectedProdukt.AddColumn("Indkoebspris", "Indkoebspris");
            selectedProdukt.AddColumn("Lokation", "Lokation");
            selectedProdukt.AddColumn("Lagerantal", "Antalpaalager");
            selectedProdukt.AddColumn("Enhed", "Enhed");
            selectedProdukt.AddColumn("Avance", "Avance");

            selectedProdukt.Draw();

            ExitOnEscape();
        }
    }
}
