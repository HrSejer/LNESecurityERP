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
                salgsordreList.Add(new Salgsordrehoved(1, 1, "Oprettet", 100));
            }
            while (Show);
        }
    }
}
