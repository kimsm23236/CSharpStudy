using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum AnimType
    {
        None = 0,
        Movement = 1,
    }

    class Position
    {
        public int x = 0;
        public int y = 0;
        public int dx = 0;
        public int dy = 0;
        public int vx = 0;
        public int vy = 0;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setDestPos(int x, int y)
        {
            dx = x;
            dy = y;
        }
        public void setVelocity(int x, int y)
        {
            vx = x;
            vy = y;
        }

        public void MovementUpdate()
        {
            x += vx;
            y += vy;
        }
    };

    class CText
    {
        private string _text = string.Empty;
        private AnimType _animType = AnimType.None;

        public Position _position { get; set; }

        public CText(string text)
        {
            _text = text;
            _position = new Position(0, 0);
        }

        public void SetAnimType (AnimType animType, Position sPos)
        { 
            switch(animType)
            { 
                case AnimType.Movement:
                    _animType = AnimType.Movement;
                    _position = sPos;
                    break;
                default: 
                    break;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(_position.x, _position.y);
            Console.WriteLine(_text);
        }
        public void Update()
        {
            _position.MovementUpdate();
        }
    }
}
