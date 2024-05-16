using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class EditProdukt(Produkt produkt) : Screen
    {
        public override string Title { get; set; } = "Produkt Edit";

        protected override void Draw()
        {
            Clear(this);

            ExitOnEscape();

            Form<Produkt> editor = new();

            editor.TextBox("Varenummer", nameof(produkt.Varenummer));
            editor.TextBox("Produkt Navn", nameof(produkt.Navn));
            editor.TextBox("Beskrivelse", nameof(produkt.Beskrivelse));
            editor.TextBox("Salgspris", nameof(produkt.Salgspris));
            editor.TextBox("Indkøbspris", nameof(produkt.Indkoebspris));
            editor.TextBox("Lokation", nameof(produkt.Lokation));
            editor.TextBox("Antal På Lager", nameof(produkt.Antalpaalager));
            editor.SelectBox("Enhed", nameof(produkt.Enhed));
            editor.AddOption("Enhed", "Styk", Enhed.Styk);
            editor.AddOption("Enhed", "Timer", Enhed.Timer);
            editor.AddOption("Enhed", "Meter", Enhed.Meter);
            editor.TextBox("Avance %", nameof(produkt.Avance));
            editor.TextBox("Avance Kr", nameof(produkt.Fortjeneste));



            if (editor.Edit(produkt))
            {
                if (produkt.ProduktId != 0)
                {
                    Database.Instance.UpdateProdukt(produkt);
                }
                else if (produkt.ProduktId == 0)
                {
                    Database.Instance.InsertProdukt(produkt);
                }

            }
            else
            {

            }
        }
    }
}
