using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public delegate void FOnMapShiftDelegate();

    public class MapCreater
    {
        private int mapId;
        private int cntMap;
        private static MapCreater _instance;
        public static MapCreater Instance
        {
            get 
            {
                if (_instance == null)
                    _instance = new MapCreater();
                return _instance;
            }
        }

        private MapCreater() 
        {
            mapId = 1;
            cntMap = 0;
        }

        public GameMap CreateMap()
        {
            int width = 15;
            int height = 15;
            GameMap newMap = new GameMap(mapId++, width, height);
            newMap.CreateWall();
            return newMap;
        }

        public GameMap CreateRandomMap()
        {
            Random random = new Random();
            int width = random.Next(5, 20+1);
            int height = random.Next(5, 20+1);
            GameMap newMap = new GameMap(mapId++, width, height);
            newMap.CreateWall();
            return newMap;
        }

    }

    public class GameMap
    {
        // 맵 고유번호
        private int id;
        // 가로 세로 크기
        private int width;
        private int height;
        private int cntWall;

        public List<GameMap> linkedMap;
        public List<Portal> portalList;
        public List<Wall> wallList;
        public FOnMapShiftDelegate onmapshiftdelegate;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }   // ID

        public GameMap(int id)
        {
            this.id = id;
            width = 15;
            height = 15;
            cntWall = ((width * 2) + (height - 2) * 2);
            linkedMap = new List<GameMap>();
            portalList = new List<Portal>();
            wallList = new List<Wall>();
        }   // GameMap()
        public GameMap(int id, int w, int h)
        {
            this.id = id;
            width = w;
            height = h;
            cntWall = ((width * 2) + (height - 2) * 2);
            linkedMap = new List<GameMap>();
            portalList = new List<Portal>();
            wallList = new List<Wall>();
        }   // GameMap()

        public void LinkMap(GameMap linkMap, int dir)
        {
            linkedMap.Add(linkMap);
            linkMap.linkedMap.Add(this);
            Random random = new Random();
            int rpos = random.Next(1, 14);
            // int hpos = random.Next(1, 15);
            Portal p1;
            Portal p2;
            switch (dir)
            {
                case 0: // 왼쪽 방향
                    p1 = new Portal(linkMap, 1, 2, 0, rpos);
                    p2 = new Portal(this, 2, 1, width-1, rpos);
                    p1.LinkPortal(p2);
                    p2.LinkPortal(p1);
                    portalList.Add(p1);
                    linkMap.portalList.Add(p2);
                    break;
                case 1: // 위쪽 방향
                    p1 = new Portal(linkMap, 3, 4, rpos, 0);
                    p2 = new Portal(this, 4, 3, rpos, height-1);
                    p1.LinkPortal(p2);
                    p2.LinkPortal(p1);
                    portalList.Add(p1);
                    linkMap.portalList.Add(p2);
                    break;
                case 2: // 오른쪽 방향
                    p1 = new Portal(linkMap, 5, 6, width-1, rpos);
                    p2 = new Portal(this, 6, 5, 0, rpos);
                    p1.LinkPortal(p2);
                    p2.LinkPortal(p1);
                    portalList.Add(p1);
                    linkMap.portalList.Add(p2);
                    break;
                case 3: // 아래쪽 방향
                    p1 = new Portal(linkMap, 7, 8, rpos, height - 1);
                    p2 = new Portal(this, 8, 7, rpos, 0);
                    p1.LinkPortal(p2);
                    p2.LinkPortal(p1);
                    portalList.Add(p1);
                    linkMap.portalList.Add(p2);
                    break;
                default: 
                    break;
            }
        }

        public void ClearMap()
        {
            InitWall(false);
            InitPortal(false);
        }
        public void InitMap()
        {
            InitWall(true);
            InitPortal(true);
        }

        public void InitPortal(bool enable)
        {
            foreach (Portal portal in portalList)
            {
                portal.Enabled = enable;
            }
        }

        public void InitWall(bool enable)
        {
            foreach(Wall wall in wallList)
            {
                wall.Enabled = enable;
            }
        }

        public void CreateWall()
        {
            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    if(i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    {
                        Wall wall = new Wall(j, i);
                        wallList.Add(wall);
                    }
                }
            }
        }

        public void InputSB(StringBuilder SB, List<gameObject> Objects)
        {
            string str = string.Empty;
            for(int i = 0; i <= height; i++)
            {
                for(int j = 0; j <= width; j++)
                {
                    // 우선도에 따라 덮어 씌워주는 방식
                    // 공백을 일단 넣고
                    str = " ".PadLeft(2);
                    // 게임오브젝트 검사 후
                    foreach (gameObject obj in Objects)
                    {
                        if(obj.IsRender(j, i)) //현재 커서 위치와 게임오브젝트 위치가 같다면
                        {
                            // 게임오브젝트 그래픽으로 덮어쓰기
                            str = obj.Graphic.ToString();
                        }
                    }
                    // StringBuilder에 넣어준다.
                    SB.Append(str);
                }
                // SB에 줄바꿈 넣어주기
                SB.Append('\n');
            }
        }   // InputSB()

    }
}
