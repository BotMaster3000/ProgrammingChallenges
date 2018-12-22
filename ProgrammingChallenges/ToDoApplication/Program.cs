using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApplication.Logic;

namespace ToDoApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UserHandler handler = new UserHandler();
            while (true)
            {
                handler.HandleUser();
            }
        }
    }
}
