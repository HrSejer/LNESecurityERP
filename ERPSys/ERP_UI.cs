using ERPSys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;

namespace ERPSys
{
    public class ERP_UI : Screen
    {
        public override string Title { get; set; } = "Menu";
        protected override void Draw()
        {
            Clear(this);
            Menu menu = new Menu();
            menu.Add(new Companylists());
            
            menu.Start(this);
        }
    }
    public class Companylists : Screen
    {
        public override string Title { get; set; } = "Company List";
        protected override void Draw()
        {

        }
    }
}
