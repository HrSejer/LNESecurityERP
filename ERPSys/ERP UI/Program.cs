using TECHCOOL.UI;

namespace ERPSys
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
        
            Opening_UI firstScreen = new();
            Screen.Display(new Opening_UI());
        }
    }
}