using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Homework
{
    enum DIRECTION  // 플레이어 방향 열거형 변수
    {
        NONE = 0,
        RIGHT, DOWN, LEFT, UP
    }

    public delegate void CollideDelegate(gameObject collider);
    public delegate void ShiftMapDelegate(Portal portal);

    public class gameObject // 플레이어, 코인과 같은 게임오브젝트들의 상위 클래스
    {
        // 위치값 표현할 문자 등을 멤버로 가지고 있음
        protected int id; // 플레이어 1, 벽 2, 코인 3
        protected int posX;
        protected int posY;
        protected char graphic;

        public CollideDelegate collideDelegate;

        // 출력을 할지 하지 않을지 결정할 bool
        protected bool bIsEnabled;

        public int ID
        { 
            get { return id; } 
        }

        public bool Enabled
        {
            get { return bIsEnabled; }
            set { bIsEnabled = value; }
        }

        // 변수 이름 일일히 수정하기 싫어서 만든 프로퍼티
        public int curX // 현재 위치 x좌표
        {
            get { return posX; }
            set { posX = value; }
        }
        public int curY // 현재 위치 y좌표
        {
            get { return posY; }
            set { posY = value; }
        }

        public char Graphic
        {
            get { return graphic; }
        }

        public bool IsRender(int x, int y) // 맵 그리는 범위 검사중 게임오브젝트를 만난다면 
        {
            return (Enabled && (x == curX && y == curY));
        }

        public bool IsCollide(gameObject col)
        {
            return (Enabled && (curX == col.curX && curY == col.curY));
        }

        public virtual void Update()
        {
            // 부모 업데이트 함수
            // 최상위 갱신 내용이 있어야한다면 내용 작성
        }

        protected virtual void Collide(gameObject Collider)
        {
            // 부모 충돌함수
            // 최상위 충돌 내용이 있어야한다면 내용 작성
        }

    }

    public class Coin : gameObject  // 코인 객체
    {
        public Coin()   // 생성자로 초기값 설정
        {
            id = 3;
            Enabled = false;
            graphic = '☆';
            collideDelegate = Collide;
        }
        public char coin
        {
            get { return graphic; }
            set { graphic = value; }
        }

        // 코인의 위치를 새로 설정하는 함수
        public void SetNewLocation(int x, int y)
        {
            curX = x;
            curY = y;
        }

        // 충돌 검사 함수
        public bool IsGot(gameObject col)
        {
            bool bIsOnTrigger = false;

            bIsOnTrigger = (col.curX == curX) && (col.curY == curY);

            return bIsOnTrigger;
        }

        protected override void Collide(gameObject Collider)
        {
            base.Collide(Collider);
            // 충돌체를 플레이어로 캐스트
            Player player = Collider as Player;
            // null이라면 충돌체가 플레이어가 아님
            if (player == null)
                return;
            // 충돌체가 플레이어일 경우 아래 실행
            Game game = Game.Instance;
            game.GetCoin();
            Console.Write("Log : 플레이어 코인 겟!");
            Enabled = false;
        }
    }

    

    public class Player : gameObject    // 플레이어 객체
    {
        private Controller controller;
        public ShiftMapDelegate shiftMapDelegate;

        private int prevX;
        private int prevY;
        public char arrow // 상속 관계로 바뀌고 난 후 변수였던 arrow를 상속받은 값을 겟, 셋하는 프로퍼티로 변경
        {
            get { return graphic; }
            set { graphic = value; }
        }
        private DIRECTION curDirection { get; set; }    // 방향을 알기위한 열거형 변수

        public Player()  // 생성자 객체 생성 시 초기화
        {
            controller = Controller.Instance;
            Enabled = true;
            id = 1;
            curX = 2;
            curY = 2;
            prevX = 1;
            prevY = 1;
            curDirection = DIRECTION.RIGHT;
            collideDelegate = Collide;
            shiftMapDelegate = PRC_ShiftMap;
            arrow = '▶';
        }

        public void move()
        {
            // 다음 위치 변수
            int nextX = 0, nextY = 0;
            prevX = curX; prevY = curY;
            // 현재 방향에 따라 다음 위치 값을 다르게 해줌
            switch (curDirection)
            {
                case DIRECTION.LEFT:
                    nextX = curX - 1;
                    nextY = curY;
                    break;
                case DIRECTION.RIGHT:
                    nextX = curX + 1;
                    nextY = curY;
                    break;
                case DIRECTION.DOWN:
                    nextX = curX;
                    nextY = curY + 1;
                    break;
                case DIRECTION.UP:
                    nextX = curX;
                    nextY = curY - 1;
                    break;
                default:
                    break;
            }
            curX = nextX;
            curY = nextY;
        }

        public void PRC_ShiftMap(Portal portal)
        {
            switch(curDirection)
            {
                case DIRECTION.LEFT:
                    curX = portal.curX - 1;
                    curY = portal.curY;
                    break;
                case DIRECTION.RIGHT:
                    curX = portal.curX + 1;
                    curY = portal.curY;
                    break;
                case DIRECTION.DOWN:
                    curX = portal.curX;
                    curY = portal.curY + 1;
                    break;
                case DIRECTION.UP:
                    curX = portal.curX;
                    curY = portal.curY - 1;
                    break;
                default:
                    break;
            }
        }

        public void Undo()
        {
            curX = prevX;
            curY = prevY;
        }

        public override void Update()
        {
            // 부모 클래스 업데이트
            base.Update();
            // 기본 업데이트 처리
            
            if (!controller.KbHit())    // 아래 코드는 키 입력이 있을때만 실행
                return;
            // 입력받은 키에 따라서 플레이어가 바라보는 방향을 다르게 한다.
            switch (controller.CKI.Key)
            {
                case ConsoleKey.UpArrow:
                    curDirection = DIRECTION.UP;
                    arrow = '▲';
                    break;
                case ConsoleKey.LeftArrow:
                    curDirection = DIRECTION.LEFT;
                    arrow = '◀';
                    break;
                case ConsoleKey.DownArrow:
                    curDirection = DIRECTION.DOWN;
                    arrow = '▼';
                    break;
                case ConsoleKey.RightArrow:
                    curDirection = DIRECTION.RIGHT;
                    arrow = '▶';
                    break;
                default:
                    return;
            }
            move();
        }
    }

    public class Wall : gameObject
    {
        public Wall(int x, int y) 
        {
            id = 2;
            curX = x;
            curY = y;
            graphic = '■';
            Enabled = true;
            collideDelegate = Collide;
        }

        protected override void Collide(gameObject Collider)
        {
            base.Collide(Collider);

            // 활성화된 게임오브젝트가 아니라면 충돌 무시
            if (!Enabled)
                return;

            // 충돌체를 플레이어로 캐스트
            Player player = Collider as Player;
            // Player? player = (Player)Collider;
            // null이라면 충돌체가 플레이어가 아님
            if (player != null)
            {
                // 충돌체가 플레이어일 경우 아래 실행
                player.Undo();
                Console.Write("Log : 플레이어 벽 충돌!");
            }


            Portal portal = Collider as Portal;
            if (portal != null)
            {
                // 충돌체가 포탈일 경우
                Enabled = false;
                Console.Write("Log : 벽 Enable false");
            }
            
        }
    }
    public class Portal : gameObject
    {
        // 맵 이동을 위해 무엇이 필요한가
        // 게임이 끝날때까지 계속 존재해야 함
        // 맵 별로 있으니께 객체가 상주?하는 맵 Index도 객체 자신이 알고있어야 할듯
        // 누구랑 연결될지? 링크? 전이처?
        // 랜덤 생성? 알고리즘 짜야됨
        // 맵 생성시 같이 생성해야하나
        // 그래프? 맵에서 알고있어야할듯
        
        private int portalid;
        private int linkedportalid;
        private int mapid;
        public GameMap linkedMap;
        public Portal linkedPortal;

        public int PortalID
        {
            get { return portalid; }
            set { portalid = value; }
        }
        public int LinkedPortal
        {
            get { return linkedportalid; }
            set { linkedportalid = value; }
        }
        public int MapID
        {
            get { return mapid; }
            set { mapid = value; }
        }



        public Portal(GameMap m, int id, int linkid, int x, int y) 
        {
            this.id = 4;
            portalid = id;
            linkedportalid = linkid;
            linkedMap = m;
            curX = x;
            curY = y;
            graphic = '○';
            Enabled = true;
            collideDelegate = Collide;
        }

        public void LinkPortal(Portal link)
        {
            linkedPortal = link;
        }
        protected override void Collide(gameObject Collider)
        {
            base.Collide(Collider);

            if (!Enabled)
                return;

            Player player = Collider as Player;
            if(player != null)  // 충돌체가 플레이어 일 경우
            {
                Game gameInstance = Game.Instance;
                gameInstance.mapShiftDelegate.Invoke(linkedMap);
                player.shiftMapDelegate.Invoke(linkedPortal);
                Console.WriteLine("플레이어 포탈 충돌!");
            }

        }
    }
}
