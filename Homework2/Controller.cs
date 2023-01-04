using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
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

        public bool KbHit()
        {
            bool bIsKeyboardHit = Console.KeyAvailable;

            if(bIsKeyboardHit) 
            {
                cki = Console.ReadKey();
                bIsKeyDown = true;
            }
            else
            {
                bIsKeyDown = false;
                cki = new ConsoleKeyInfo();
            }
            return bIsKeyboardHit;
        }


    }
}
