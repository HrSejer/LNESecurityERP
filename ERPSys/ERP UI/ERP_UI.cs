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
        //er main menu til vores UI
        public override string Title { get; set; } = "Menu";
        protected override void Draw()
        {
            
            Clear(this);
            Menu menu = new Menu();
            //=====UI referencer====//
            menu.Add(new Companylists());

            //=====UI referencer====//
            menu.Start(this);
        }
    }
}
