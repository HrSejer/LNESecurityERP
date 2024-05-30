using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys.ERP_UI
{
    public class EditSalgsordrehoved(Salgsordrehoved salgsordrehoved) : Screen 
    {
        Database database = Database.Instance;
        public override string Title { get; set; } = "Salgsordre Edit";
        protected override void Draw()
        {
            Clear(this);

            ExitOnEscape();

            Form<Salgsordrehoved> editor = new();

            editor.TextBox("Ordrenummer", nameof(salgsordrehoved.Ordrenummer));
            editor.TextBox("Kundenummer", nameof(salgsordrehoved.Kundenummer));
            editor.TextBox("Dato", nameof(salgsordrehoved.Dato));
            editor.TextBox("Kundenavn", nameof(salgsordrehoved.Kundenavn));
            editor.TextBox("Ordrebeløb", nameof(salgsordrehoved.Ordrebeløb));
            editor.SelectBox("Tilstand", nameof(salgsordrehoved.Tilstand));
            editor.AddOption("Tilstand", "Ingen", Tilstand.Ingen);
            editor.AddOption("Tilstand", "Oprettet", Tilstand.Oprettet);
            editor.AddOption("Tilstand", "Bekræftet", Tilstand.Bekræftet);
            editor.AddOption("Tilstand", "Pakket", Tilstand.Pakket);
            editor.AddOption("Tilstand", "Færdig", Tilstand.Færdig);
            editor.TextBox("Oprettelsestidspunkt", nameof(salgsordrehoved.Oprettelsestidspunkt));
            editor.TextBox("Gennemførelsestidspunkt", nameof(salgsordrehoved.Gennemførelsestidspunkt));

            if (editor.Edit(salgsordrehoved))
            {
                if (salgsordrehoved.Ordrenummer != 0)
                {
                    Database.Instance.OpdaterSalgsordre(salgsordrehoved);
                }
                else if (salgsordrehoved.Ordrenummer == 0)
                {
                    Database.Instance.IndsaetSalgsordre(salgsordrehoved);
                }

            }
            else
            {

            }
        }
    }
}
