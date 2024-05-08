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
                salgsordreList.Add(new Salgsordrehoved(1, DateTime.Now, 1, "Bo Niller", 100));

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
    }
}
