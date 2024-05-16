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
            editor.TextBox("Dato", nameof(salgsordrehoved.Dato));
            editor.TextBox("Kundenummer", nameof(salgsordrehoved.Kundenummer));
            editor.TextBox("Kundenavn", nameof(salgsordrehoved.Kundenavn));
            editor.TextBox("Ordrebeløb", nameof(salgsordrehoved.Ordrebeløb));

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
