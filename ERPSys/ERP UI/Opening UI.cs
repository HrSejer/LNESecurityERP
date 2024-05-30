using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class Opening_UI:Screen
    {
        public override string Title { get; set; } = "LNE SECURITY A/S";
        protected override void Draw()
        {
            Console.CursorVisible = false;
            Clear(this);
            Menu menu = new Menu();
            menu.Add(new ERP_Menu());
            menu.Start(this);
        }
    }
}
