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

            editor.TextBox("Company Name", nameof(salgsordrehoved.Ordrenummer));
            editor.TextBox("Country", nameof(salgsordrehoved.Dato));
            editor.TextBox("By", nameof(salgsordrehoved.Kundenummer));
            editor.TextBox("Husnummer", nameof(salgsordrehoved.Kundenavn));
            editor.TextBox("Vej", nameof(salgsordrehoved.Ordrebeløb));

            if (editor.Edit(salgsordrehoved))
            {
                if (salgsordrehoved.Ordrenummer != 0)
                {
                    Database.Instance.UpdateSalgsordrehoved(salgsordrehoved);
                }
                else if (salgsordrehoved.Ordrenummer == 0)
                {
                    Database.Instance.InsertSalgsordrehoved(salgsordrehoved);
                }

            }
            else
            {

            }
        }
    }
}
