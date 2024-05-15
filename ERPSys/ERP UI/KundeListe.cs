using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class KundeListe : Screen
    {
        public override string Title { get; set; } = "Kunde List";
        protected override void Draw()
        {
            do
            {
                ListPage<Kunde> kundeList = new();
                kundeList.Add(new Kunde("Test", "a", "a", null, 1, "a", 1, DateTime.Now));
                kundeList.Add(new Kunde("a", "a", "a", null, 1, "a", 1, DateTime.Now));
                kundeList.Add(new Kunde("a", "a", "a", null, 1, "a", 1, DateTime.Now));

                //used to tell it what data from the class it should use
                kundeList.AddColumn("Kundenummer", "KundeNummer");
                kundeList.AddColumn("Navn", "Navn");
                kundeList.AddColumn("Tlfnummer", "Tlfnummer");
                kundeList.AddColumn("Email", "Mail");


                ExitOnEscape();
                Kunde selected = kundeList.Select();
                if (selected != null)
                {
                    Screen.Display(new SelectedKunde(selected));
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
