using ERPSys.ERP_UI;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SalgsordreLists : Screen
    {
        Database database = Database.Instance;
        public override string Title { get; set; } = "Salgsordre list";
        protected override void Draw()
        {
            do
            {
                ListPage<Salgsordrehoved> salgsordreList = new();

                var salgsordres = database.GetSalgsordre();
                foreach (Salgsordrehoved salgsordrehoved in salgsordres)
                {
                    salgsordreList.Add(salgsordrehoved);
                }

                salgsordreList.AddKey(ConsoleKey.F1, NewSalgsordre);
                Console.WriteLine("Tryk F1 for at lave en ny Salgsordre");

                salgsordreList.AddKey(ConsoleKey.F2, editSalgsordre);
                Console.WriteLine("Tryk F2 for at redigere Salgsordre");

                salgsordreList.AddKey(ConsoleKey.F5, DeleteSalgsordre);
                Console.WriteLine("Tryk F5 for at fjerne Salgsordre");

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
        void DeleteSalgsordre(Salgsordrehoved salgsordrehoved)
        {
            Database.Instance.DeleteSalgsordre(salgsordrehoved);
            Screen.Clear(this);
            Draw();
        }
        void editSalgsordre(Salgsordrehoved salgsordrehoved)
        {
            Screen.Display(new EditSalgsordrehoved(salgsordrehoved));
        }
        void NewSalgsordre(Salgsordrehoved salgsordrehoved)
        {
            Salgsordrehoved newcsalgsordre = new();
            Screen.Display(new EditSalgsordrehoved(newcsalgsordre));
        }
    }
}
