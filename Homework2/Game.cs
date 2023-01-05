using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public delegate void MapShiftDelegate(GameMap nextMap);
    public class Game
    {
        // Char 형 2차원 배열로 맵을 표현
        char[,] map = new char[100, 100];

        // 맵 제작 객체
        private MapCreater mapCreater;
        // 맵 객체
        private GameMap currentMap;
        public List<GameMap> mapList;
        private int currentMapId;

        public MapShiftDelegate mapShiftDelegate;

        // 모든 게임오브젝트
        private List<gameObject> AllObject;
        // 플레이어 객체를 생성
        public Player player = new Player();
        // 코인 객체를 생성
        public Coin[] coins = new Coin[10];

        // 출력용 StringBuilder
        private StringBuilder renderSB;

        // 얻은 코인 갯수
        private int cntGetCoin;
        // 스폰 코인 갯수
        private int cntSpawnCoin;
        // 현재 맵 코인 갯수
        private int curInMapCoin;
        // 코인이 맵에 생성되는 주기
        private int respawnTime;
        private bool bIsSpawn = false;

        // 게임 종료 변수
        private bool IsGameEnd;

        private static Game _instance;

        public static Game Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Game();
                return _instance;
            }
        }

        private Game()
        {
            IsGameEnd = false;
            cntGetCoin = 0;
            cntSpawnCoin = 0;
            curInMapCoin = 0;
            respawnTime = 100;
            currentMapId = 1;
            renderSB = new StringBuilder();
            mapList = new List<GameMap>();
            AllObject = new List<gameObject>();
            // 맵 제작 객체
            mapCreater = MapCreater.Instance;
            mapShiftDelegate = ShiftMap;
            
            for (int i = 0; i < 10; i++)
            {
                coins[i] = new Coin();
            }

        }

        public void Init()
        {
            CreateMap();
            currentMap = mapList[0];

            InitMap();
        }
        public void InitMap()
        {
            AllObject = new List<gameObject>();
            AllObject.Add(player);
            foreach (var obj in currentMap.portalList)
            {
                AllObject.Add(obj);
            }
            foreach (var obj in currentMap.wallList)
            {
                AllObject.Add(obj);
                obj.Enabled = true;
            }
        }
        public void CreateMap()
        {
            for (int i = 0; i < 5; i++)
            {
                GameMap nm = mapCreater.CreateMap();
                mapList.Add(nm);
            }
            mapList[1].LinkMap(mapList[0], 0);
            mapList[1].LinkMap(mapList[2], 1);
            mapList[1].LinkMap(mapList[3], 2);
            mapList[1].LinkMap(mapList[4], 3);
            // 심화버전 랜덤맵 나중에 기회되면
            /*
            for(int i = 0; i < 5; i++)
            {
                GameMap nm = new GameMap(0);
                nm = mapCreater.CreateRandomMap();
                mapList.Add(nm);
            }
            */
        }

        public void ShiftMap(int mapid)
        {
            currentMap = mapList[mapid - 1];
            InitMap();
        }
        public void ShiftMap(GameMap nextMap)
        {
            currentMap.ClearMap();
            currentMap = nextMap;
            currentMap.InitMap();
            InitMap();
        }
        public async void OnSpawnTimer()
        {
            // 코인이 생성되는 시간이 점점 늦춰지게끔
            await Task.Delay(respawnTime);
            respawnTime += 50;
            // 참일때 코인 생성
            bIsSpawn = true;
        }

        public void GetCoin()
        {
            cntGetCoin++;
        }

        
        /*public void SpawnCoin()
        {
            if (bIsSpawn)
            {
                while (!RespawnCheck())
                {
                    /* Do Nothing 
                }

                bIsSpawn = false;
                OnSpawnTimer();
            }
        }
        */

        /*
        private bool RespawnCheck()
        {
            bool bIsSuccessRespawn = true;
            Random rd = new Random();
            int newX = rd.Next(1, width);
            int newY = rd.Next(1, height);
            if (player.curX == newX && player.curY == newY)
            {
                bIsSuccessRespawn = false;
            }
            if (bIsSuccessRespawn)
                for (int i = 0; i < AllCoin; i++)
                {
                    if (!coins[i].Enabled)
                    {
                        // 이미 있는 객체의 위치와 boolean만 바꿔주는 오브젝트 풀링 방식?
                        Console.SetCursorPosition(width, height + 2);
                        Console.WriteLine("{0} 번째 코인 생성!", ++cntSpawnCoin);
                        coins[i].SetNewLocation(newX, newY);
                        coins[i].Enabled = true;
                        curInMapCoin++;
                        break;
                    }
                }
            return bIsSuccessRespawn;
        }
        */

        public void Render()    // 맵과 플레이어를 그려주는 함수
        {
            // 계속해서 커서 위치를 초기 위치로 갱신하여 콘솔창이 지저분해지는 것을 방지 
            Console.SetCursorPosition(0, 0);
            // StringBuilder에 값 입력
            currentMap.InputSB(renderSB, AllObject);
            // 출력
            Console.Write(renderSB.ToString());
            renderSB.Clear();
            //배열의 크기 만큼이 아니라 미리 설정한 맵 크기 상수만큼 그린다.
            //for (int i = 0; i <= height; i++)
            //{
            //    for (int j = 0; j <= width; j++)
            //    {
            //        bool isCoinDraw = false;
            //        for (int k = 0; k < AllCoin; k++)
            //        {

            //            if (coins[k].Enabled)
            //            {
            //                if (i == coins[k].curY && j == coins[k].curX)
            //                {
            //                    Console.Write("{0}", coins[k].coin);
            //                    isCoinDraw = true;
            //                }
            //            }
            //        }
            //        // 플레이어 위치일 경우
            //        if (i == player.curY && j == player.curX)
            //        {
            //            // 플레이어의 현재 방향에 따라 달리 그린다.
            //            Console.Write("{0}", player.arrow);
            //        }
            //        else if (isCoinDraw)
            //            continue;
            //        else if (map[i, j] != '■')   // ■은 ' '두칸과 길이가 같기에 ' '은 두 자리를 사용하여 표기
            //            Console.Write("{0,2}", map[i, j]);
            //        else
            //            Console.Write("{0}", map[i, j]);
            //    }
            //    Console.WriteLine();
            //}

            //Console.SetCursorPosition(width, height + 1);
            // Console.WriteLine("얻은 코인 갯수 {0}", cntGetCoin);

        }

        public void Update()  // 입력 받은 키로 플레이어 객체를 갱신
        {
            foreach(var Obj in AllObject)
            {
                Obj.Update();
            }
            
            foreach(var Obj in AllObject)
            {
                for(int i = 0; i < AllObject.Count; i++)
                {
                    if (Obj.Equals(AllObject[i]))
                        continue;
                    if (Obj.IsCollide(AllObject[i]))
                    {
                        AllObject[i].collideDelegate.Invoke(Obj);
                    }
                }
            }
        }

        public bool IsEndGame()
        {
            bool bIsEnd = false;
            int cnt = 0;
            if (cntGetCoin >= 5)
                for (int i = 0; i < 10; i++)
                {
                    if (!coins[i].Enabled)
                    {
                        cnt++;
                    }
                }
            if (cnt >= 10)
                bIsEnd = true;
            return bIsEnd;
        }
        public void Start()
        {
            GameLoop();
        }
        private void GameLoop()
        {
            while(!IsGameEnd) 
            {
                Update();
                Render();
                Thread.Sleep(50);
            }
        }

    }
}
