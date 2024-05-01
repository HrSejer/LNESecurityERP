using ERPSys;
using TECHCOOL.UI;

namespace ERPSys
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
        
            ERP_UI firstScreen = new ERP_UI();
            Screen.Display(new ERP_UI());
        }
    }
}