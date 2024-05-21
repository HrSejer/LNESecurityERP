using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class KundeListe : Screen
    {
        Database database = Database.Instance;
        public override string Title { get; set; } = "Kunde List";
        protected override void Draw()
        {
            do
            {
                ExitOnEscape();

                ListPage<Kunde> kundeList = new();
                
                var Kunder = database.GetKunde();
                foreach (Kunde kunde in Kunder)
                {
                    kundeList.Add(kunde);
                }

                kundeList.AddKey(ConsoleKey.F1, NewCompany);
                Console.WriteLine("Tryk F1 for at lave en ny virksomhed");

                kundeList.AddKey(ConsoleKey.F2, editKunde);
                Console.WriteLine("Tryk F2 for at redigere virksomhed");

                kundeList.AddKey(ConsoleKey.F5, DeleteCompany);
                Console.WriteLine("Tryk F5 for at Fjerne virksomheder");

                //used to tell it what data from the class it should use
                kundeList.AddColumn("Kundenummer", "KundeNummer");
                kundeList.AddColumn("Navn", "Navn");
                kundeList.AddColumn("Tlfnummer", "Tlfnummer");
                kundeList.AddColumn("Email", "Mail");

                
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

            void editKunde(Kunde kunde)
            {
                Screen.Display(new KundeEdit(kunde));
            }

            void NewCompany(Kunde _)
            {
                Kunde newkunde = new();
                Screen.Display(new KundeEdit(newkunde));
            }
            void DeleteCompany(Kunde kunde)
            {
                Database.Instance.DeleteKunde(kunde);
                Screen.Clear(this);
                Draw();
            }
        }
    }
}
