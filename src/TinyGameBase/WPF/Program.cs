using System;
using System.Windows;

namespace TinyGameBase
{
    public static class Program
    {
        [STAThread]
        public static int Main()
            => new Application().Run(new GameWindow());
    }
}
