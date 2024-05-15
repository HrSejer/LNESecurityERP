using ERPSys;
using ERPSys.Data;
using TECHCOOL.UI;

namespace ERPSys
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
        
            Opening_UI firstScreen = new Opening_UI();
            Screen.Display(new Opening_UI());
        }
    }
}