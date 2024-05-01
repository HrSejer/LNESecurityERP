using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECHCOOL.UI;
public class MyFirstScreen : Screen
{
    public override string Title { get; set; } = "My first screen";
    protected override void Draw()
    {
        Clear(this);
        Console.WriteLine("My first screen!");
    }
}
namespace ERPSys
{
    internal class MyFirstScreen
    {
    }
}
