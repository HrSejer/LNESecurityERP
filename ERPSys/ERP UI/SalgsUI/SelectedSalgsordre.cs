using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class SelectedSalgsordre(Salgsordrehoved salgsordrehoved) : Screen
    {
        public override string Title { get; set; } = "Selected Salgsordre";
        protected override void Draw()
        {
            Clear(this);

            ListPage<Salgsordrehoved> selectedSalgsordre = new ListPage<Salgsordrehoved>();
            selectedSalgsordre.Add(salgsordrehoved);
            selectedSalgsordre.AddColumn("OrdreId", "OrdreId");
            selectedSalgsordre.AddColumn("Ordrenummer", "Ordrenummer");
            selectedSalgsordre.AddColumn("Dato", "Dato");
            selectedSalgsordre.AddColumn("Kundenummer", "Kundenummer");
            selectedSalgsordre.AddColumn("Kundenavn", "Kundenavn");
            selectedSalgsordre.AddColumn("Ordrebeløb", "Ordrebeløb");
            selectedSalgsordre.AddColumn("Tilstand", "Tilstand");
            selectedSalgsordre.AddColumn("Oprettelsestidspunkt", "Oprettelsestidspunkt");
            selectedSalgsordre.AddColumn("Gennemførelsestidspunkt", "Gennemførelsestidspunkt");

            selectedSalgsordre.Draw();

            ExitOnEscape();
        }
    }
}
