using ERPSys.ERP_UI;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SalgsordreLists : Screen
    {
        public override string Title { get; set; } = "Salgsordre list";
        protected override void Draw()
        {
            do
            {
                ListPage<Salgsordrehoved> salgsordreList = new();
                salgsordreList.Add(new Salgsordrehoved(1, DateTime.Now, 1, "Bo Niller", 100, Tilstand.Oprettet));
                salgsordreList.Add(new Salgsordrehoved(2, DateTime.Now, 2, "Kaj Haj", 300, Tilstand.Færdig));

                salgsordreList.AddKey(ConsoleKey.F2, editSalgsordre);
                Console.WriteLine("Tryk F2 for at redigere virksomhed");

                salgsordreList.AddColumn("Ordrenummer", "Ordrenummer");
                salgsordreList.AddColumn("Dato", "Dato");
                salgsordreList.AddColumn("Kundenummer", "Kundenummer");
                salgsordreList.AddColumn("Kundenavn", "Kundenavn");
                salgsordreList.AddColumn("Ordrebeløb", "Ordrebeløb");

                ExitOnEscape();
                Salgsordrehoved selected = salgsordreList.Select();
                if (selected != null)
                {
                    Screen.Display(new SelectedSalgsordre(selected));
                }
                else
                {
                    Quit();
                    return;
                }
            }
            while (Show);
        }
        void editSalgsordre(Salgsordrehoved salgsordrehoved)
        {
            Screen.Display(new EditSalgsordrehoved(salgsordrehoved));
        }
        void NewCompany(Company _)
        {
            Company newcompany = new();
            Screen.Display(new EditCompany(newcompany));
        }
    }
}
