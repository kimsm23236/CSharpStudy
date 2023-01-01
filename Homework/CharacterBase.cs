using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class CharacterBase
    {
        protected string name;
        protected int hp;
        protected int attack;
        protected int deffense;

        protected double AtkMdf;
        protected double DefMdf;


        protected string[] behaviorDescs;
        public string GetBhvDescs(int num)
        {
            return behaviorDescs[num];
        }
        public string Name
        { 
            get { return name; } 
        }

        protected virtual void SetupBhvDescs()
        {
            behaviorDescs = new string[4];
            behaviorDescs[0] = "{0}은(는) 들고있는 무기를 사용하여 공격했다!";
            behaviorDescs[1] = "{0}은(는) 방어 태세를 취했다!";
            behaviorDescs[2] = "{0}은(는) 힘을 모으고 있다!";
            behaviorDescs[3] = "{0}은(는) 도망치기 위해 기회를 엿보고 있다!";
        }

        public CharacterBase()
        {
            name = string.Empty;
            hp = 0;
            attack = 0;
            deffense = 0;
            AtkMdf = 1.0f;
            DefMdf = 1.0f;
        }

        public void Attack(CharacterBase target)
        {
            DefMdf = 1.0f;
            int FinalAtk = (int)(attack * AtkMdf);
            target.TakeDamage(FinalAtk);
            AtkMdf = 1.0f;
        }

        public void Deffense()
        {
            DefMdf = 2.0f;
        }

        public void Charge()
        {
            AtkMdf += 1.0f;
        }

        public bool Escape()
        {
            bool bIsSuccessESC = false;
            Random rd = new Random();
            int rdNum = rd.Next(1, 100 + 1);
            Thread.Sleep(1000);
            if (rdNum <= 20)
            {
                Console.WriteLine("{0}은(는) 도망쳤다!", name);
                bIsSuccessESC = true;
            }
            else
            {
                Console.WriteLine("{0}은(는) 도망치는데 실패했다!", name);
            }
            return bIsSuccessESC;
        }

        public void TakeDamage(int damage)
        {

            int FinalDamage = (int)Math.Clamp(damage - (int)(deffense * DefMdf), 0, 1e9);
            this.hp -= FinalDamage;
            Console.WriteLine("{0} 은(는) {1}의 데미지를 받았다.", this.name, FinalDamage);
        }
        public virtual bool IsDead()
        {
            bool bIsDead = false;
            if (hp <= 0)
            {
                Console.WriteLine("{0}은(는) 사망했다.", name);
                bIsDead = true;
            }
            return bIsDead;
        }
    }

    class Player : CharacterBase
    {
        private string[] inventory;

        public Player()
        {
            name = "용사";
            hp = 100;
            deffense = 5;
            attack= 30;
            inventory = new string[10];
            SetupBhvDescs();
        }
        public Player(string name, int hp, int atk, int def)
        {
            this.name = name;
            this.hp = hp;
            this.deffense = def;
            this.attack = atk;
            inventory = new string[10];
            SetupBhvDescs();
        }
        public void Encount(CharacterBase enemy)
        {
            Console.WriteLine("{0}이(가) 나타났다!", enemy.Name);
        }

        public void AddItem(string newItem)
        {
            inventory.Append(newItem);
        }
    }

    class Monster : CharacterBase
    {
        protected string Item;
        private int DropPercentage = 30;

        public Monster()
        {
            SetupBhvDescs();
        }
        public Monster(string name, int hp, int atk, int def, string item)
        {
            this.name = name;
            this.hp = hp;
            this.deffense = def;
            this.attack = atk;
            Item = item;
            SetupBhvDescs();
        }

        public override bool IsDead()
        {
            bool bIsDead = false;
            if (hp <= 0)
            {
                Console.WriteLine("{0}은(는) 사망했다.", name);
                bIsDead = true;
            }
            return bIsDead;
        }

        public bool IsDropItem()
        {
            if (!IsDead())
                return false;

            Random rd = new Random();
            int rdNum = rd.Next(1, 100 + 1);

            if (rdNum <= DropPercentage)
            {
                Console.WriteLine("{0}은(는) {1}을(를) 드랍했다.", name, Item);
                return true;
            }
            else
                return false;
        }
        public string GetItemName()
        {
            return Item;
        }

    }

    class Knight : Monster
    {
        private string Weapon;

        public Knight()
        {
            this.name = "검 기사";
            this.hp = 100;
            this.attack = 20;
            this.deffense = 20;
            this.Item = "검";
            this.Weapon = "검";
        }
        public Knight(string name, int hp, int dmg, int def, string item, string wp)
        {
            this.name = name;
            this.hp = hp;
            this.attack = dmg;
            this.deffense = def;
            this.Item = item;
            this.Weapon = wp;
        }
    }

    class Wolf : Monster
    {
        protected override void SetupBhvDescs()
        {
            base.SetupBhvDescs();
            behaviorDescs[0] = "{0}은(는) 이빨과 발톱으로 공격했다!";
            behaviorDescs[1] = "{0}은(는) 방어 태세를 취했다!";
            behaviorDescs[2] = "{0}은(는) 힘을 모으고 있다!";
            behaviorDescs[3] = "{0}은(는) 도망치기 위해 기회를 엿보고 있다!";
        }
        public Wolf()
        {
            this.name = "하얀 늑대";
            this.hp = 200;
            this.attack = 20;
            this.deffense = 10;
            SetupBhvDescs();
        }
    }

    enum BATTLEPHASE
    {
        NONE = 0,
        ENCOUNT,
        PLAYERTURN,
        ENEMYTURN,
        GETREWARD,
    }
    class BattleManager
    {
        private BATTLEPHASE CurrentPhase = BATTLEPHASE.NONE;

        private Player player;
        private Monster enemy;

        private bool isBattleEnd;

        public BattleManager()
        {
            player = new Player();
            enemy = new Monster();
            isBattleEnd = false;
        }

        public void ExecuteBattle()
        {
            while (!isBattleEnd)
            {
                Console.Clear();
                switch (CurrentPhase)
                {
                    case BATTLEPHASE.ENCOUNT:
                        prc_Encount();
                        break;
                    case BATTLEPHASE.PLAYERTURN:
                        prc_PlayerTurn();
                        break;
                    case BATTLEPHASE.ENEMYTURN:
                        prc_EnemyTurn();
                        break;
                    case BATTLEPHASE.GETREWARD:
                        prc_GetReward();
                        break;
                }
                Thread.Sleep(2000);
            }

        }

        public void BattleStart(Player p, Monster m)
        {
            BattleSetup(p, m);
        }
        private void BattleSetup(Player p, Monster m)
        {
            player = p;
            enemy = m;
            CurrentPhase = BATTLEPHASE.ENCOUNT;
            isBattleEnd = false;
        }

        private void prc_Encount()
        {
            Console.WriteLine("{0}와(과) 조우했다!", enemy.Name);
            CurrentPhase = BATTLEPHASE.PLAYERTURN;
        }

        private void prc_PlayerTurn()
        {
            int SelectNumber = 0;

            Console.WriteLine("플레이어의 턴");
            while (true)
            {
                Console.WriteLine("플레이어의 행동을 선택하세요.");
                Console.Write("1.공격, 2.방어, 3.모으기, 4.도망 : ");
                int.TryParse(Console.ReadLine(), out SelectNumber);
                if (SelectNumber >= 1 && SelectNumber <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("[System Error] 잘 못 입력하였습니다.");
                }
            }

            switch (SelectNumber)
            {
                case 1:
                    Console.WriteLine(player.GetBhvDescs(0), player.Name);
                    player.Attack(enemy);
                    break;
                case 2:
                    Console.WriteLine(player.GetBhvDescs(1), player.Name);
                    player.Deffense();
                    break;
                case 3:
                    Console.WriteLine(player.GetBhvDescs(2), player.Name);
                    player.Charge();
                    break;
                case 4:
                    Console.WriteLine(player.GetBhvDescs(3), player.Name);
                    if (player.Escape())
                    {
                        isBattleEnd = true;
                        CurrentPhase = BATTLEPHASE.GETREWARD;
                    }
                    break;
                default:
                    break;
            }

            CurrentPhase = BATTLEPHASE.ENEMYTURN;
            if (enemy.IsDead())
            {
                CurrentPhase = BATTLEPHASE.GETREWARD;
            }
        }

        private void prc_EnemyTurn()
        {


            Console.Write("{0} 가(이) 행동을 결정하고 있습니다", enemy.Name);

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(800);
                Console.Write(".");
            }
            Console.WriteLine();

            Random rd = new Random();
            int randNum = rd.Next(1, 4 + 1);
            switch (randNum)
            {
                case 1:
                    Console.WriteLine(enemy.GetBhvDescs(0), enemy.Name);
                    enemy.Attack(player);
                    break;
                case 2:
                    Console.WriteLine(enemy.GetBhvDescs(1), enemy.Name);
                    enemy.Deffense();
                    break;
                case 3:
                    enemy.Charge();
                    Console.WriteLine(enemy.GetBhvDescs(2), enemy.Name);
                    break;
                case 4:
                    Console.WriteLine(enemy.GetBhvDescs(3), enemy.Name);
                    if (enemy.Escape())
                    {
                        isBattleEnd = true;
                    }
                    break;
                default:
                    break;
            }

            CurrentPhase = BATTLEPHASE.PLAYERTURN;
            if (player.IsDead())
            {
                CurrentPhase = BATTLEPHASE.GETREWARD;
            }
        }

        private void prc_GetReward()
        {
            if (enemy.IsDropItem())
            {
                player.AddItem(enemy.GetItemName());
            }
            Console.WriteLine("전투를 종료합니다.");
            isBattleEnd = true;
        }
    }
}
