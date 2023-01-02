using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Controller
    {
        private bool bIsKeyDown;
        public bool IsKeyDown
        {
            get { return bIsKeyDown; }
        }
        private ConsoleKeyInfo cki;
        public ConsoleKeyInfo CKI 
        { 
            get { return cki; } 
        }

        private static Controller _instance;
        public static Controller Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new Controller();
                return _instance;
            }
        }

        private Controller()
        {

        }

        public void KbHit()
        {
            if(Console.KeyAvailable) 
            {
                cki = Console.ReadKey();
                bIsKeyDown = true;
            }
            else
            {
                bIsKeyDown = false;
                cki = new ConsoleKeyInfo();
            }
        }


    }
}
