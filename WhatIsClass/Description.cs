using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace WhatIsClass
{
    public class Description
    {
        private string stringField = "이것은 어디에서 접근이 가능할까?";  // 필드

        public Description()
        {
            Console.WriteLine("생성자");
        }

        public void ValueTypeAndRefferenceType()
        {
            /*
             * 값 형식과 참조 형식
             * 클래스나 구조체 같은 데이터 형식을 말할 때 값 형식(Value Type)과 참조 형식(Refference Type)으로 구분 짓기도 한다.
             * 
             * 값 형식 
             * 개체에 값 자체를 담고 있는 구조이다. 지금까지 다룬 int, double 등은 내부적으로 구조체로 된 전형적인 값 형식의 데이터 구조이다.
             * 
             * 참조 형식
             * 개체가 값을 담고 있는 또 다른 개체를 포인터로 바라보는 구조이다. 여러 값이 동일한 개체를 가리킬 수 있다.
             */

            /*
             * 박싱과 언박싱
             * 프로그래밍을 하다 보면 데이터의 형식 변환이 필요하다. 이러한 변환 과정에서 값 형식의 데이터를 참조 형식의 데이터로
             * 변경하는 것을 박싱(Boxing)이라고 한다. 반대로 참조 형식의 데이터를 값 형식의 데이터로 변경하는 것을 언박싱(Unboxing)
             * 이라고 한다.
             * 
             * 박싱
             * 박싱이란 말 그대로 박스에 포장하는 것이다. c#에서 박싱은 값 형식의 데이터를 참조 형식의 데이터로 변환하는 작업을 의미한다.
             * 예를 들어 다음 코드처럼 정수 형식의 데이터를 오브젝트 형식의 데이터에 담는 형태를 박싱이라고 한다.
             * 
             * int number = 1234;
             * object objectValue = number;
             * 
             * 좀 더 어렵게 말하면 스택 메모리 영역에 저장된 값 형식의 데이터를 힙 메모리 영역에 저장하는 단계를 거치기 때문에
             * 시간과 공간이 소비되는 비용이 발생한다.
             * 
             * 언박싱
             * 다음 코드는 object 변수에 저장된 1234를 실제 정수 형식의 데이터로 변환하는 모습을 보여준다.
             * 참조 형식의 데이터를 값 형식의 데이터로 변환하는 과정이 포장을 푸는 것과 비슷해 보여서 언박싱이라고 한다.
             * 언박싱을 캐스트(Cast)또는 캐스팅(Casting)으로 표현한다.
             * 
             * object objectValue = 1234;
             * int number = (int)objectValue;
             * 
             * object 형 변수에 들어 있는 데이터 중에서 숫자 형식의 데이터는 바로 int 형 변수에 대입할 수 없다.
             * object 형 변수 값을 int 형 변수에 대입하려면 형식 변환을 해야 한다. 형식 변환은 캐스팅이나
             * Convert 클래스 같은 변환 API를 사용하면 된다. 즉, (int) 또는 Convert.ToInt32() 같은 형식 변환 관련 기능을
             * 명시적으로 지정해 주어야 한다.
             */

            object objectValue;
            char charValue = 'a';
            int intValue = 97;
            char charValue2;
            objectValue = charValue;
            charValue2 = (char)objectValue;

            Console.WriteLine("object Value : {0}", charValue2);

            Console.WriteLine("{0}", stringField);

        }   // ValueTypeAndRefferenceType()

        public void WhatIsField()
        {
            /*
             * 필드(Field)는 클래스의 부품 역할을 하는 클래스의 내부 상태 값을 저장해 놓는 그릇을 의미한다.
             * 예를 들어 필드는 자동차 클래스에 선언된 변수로 자동차 부품에 해당한다고 할 수 있다.
             * 
             * 필드
             * 클래스 내에서 선언된 변수 또는 배열 등을 c#에서는 필드라고 한다. 필드는 일반적으로 클래스의
             * 부품 역할을 하며, 대부분 private 액세스 한정자(Access modifier)가 붙고 클래스 내에서 데이터를
             * 담는 그릇 역할을 한다. 이러한 필드는 개체 상태를 보관한다.
             * 필드는 선언한 후 초기화하지 않아도 자동으로 초기화한다. 예를 들어 int 형 필드는 0으로,
             * string 형 필드는 string.Empty, 즉 공백으로 초기화된다.
             * 
             * 지역 변수와 전역 변수
             * c#에서 변수를 선언할 때는 Main() 메서드와 같은 메서드 내에서 선언하거나 메서드 밖에서, 즉 메서드와 동등한 레벨에서
             * 변수를 선언할 수 있다. 메서드 내에서 선언된 변수 또는 배열을 지역 변수(Local variable)라고 하며, 메서드 밖에서
             * 선언된 변수를 전역 변수(Global variable)라고 한다. 다만 c#에서는 전역 변수라는 사용하지 않고 메서드와 동일하게
             * 액세스 한정자를 붙여 필드라고 한다.
             * 
             * 지역 변수
             * 변수는 Main() 메서드가 종료되면 자동으로 소멸된다. 변수가 살아 있는 영역은 Main() 메서드의 
             * 중괄호 시작( { )과 끝( } ) 사이이다. 특정 지역을 범위로 하기에 변수를 일반적으로 지역 변수라고 표현한다.
             * 
             * 전역 변수
             * Main() 메서드가 아닌 클래스 내에 선언된 변수를 필드라고 한다. c#에서 필드는 변수와 마찬가지로 주로 
             * 소문자 또는 언더스코어(_)로 시작한다. 이러한 필드는 메서드 내에 선언된 지역 변수와 달리 전역 변수라고도 한다.
             * 
             */
            Console.WriteLine("{0}", stringField);
        }   // WhatIsField()

        public void WhatIsConstructor()
        {
            /*
             * c#에서 생성자는 클래스에서 맨 먼저 호출되는 메서드로, 클래스 기본값 등을 설정한다.
             * 자동차 클래스를 예로 들면, 자동차의 시동 걸기에 해당하는 것이 바로 생성자이다.
             * 
             * 생성자
             * 클래스의 구성 요소 중에는 생성자(Constructor)라는 메서드가 숨어 있다. 단어 그대로 개체를 생성하면서
             * 무엇인가를 하고자 할 때 사용되는 메서드이다. 일반적으로 생성자는 개체를 초기화(주로 클래스 내 필드를 초기화)하는 데
             * 사용된다. 생성자는 생성자 메서드라고도 한다. 이러한 생성자는 독특한 규칙이 있는데,
             * 바로 생성자 이름이 클래스 이름과 동일하다는 것이다. 클래스 내에서 클래스 이름과 동일한 이름을 갖는 메서드는 모두 생성자이다.
             * 
             * 생성자는 매개변수가 없는 기본(Default) 생성자가 있고, 매개변수를 원하는 만큼 정의해서 사용할 수도 있다. 이때 리턴 값은 가지지 않는다.
             * 또 생성자도 static 생성자(정적 생성자)와 public 생성자(인스턴스 생성자)로 구분된다. 
             * 일반적으로 public 키워드를 사용하는 인스턴스 생성자를 많이 사용한다.
             */
        }

        public void WhatIsDestructor()
        {
            /*
             * 소멸자는 생성자와 반대 개념으로 클래스에서 인스턴스화된 개체가 메모리상에서 없어질 때 실행되는 메서드이다.
             * 자동차 클래스를 예로 들면 자동차 주차 대행, 시동 끄기 등으로 볼 수 있다.
             * 
             * 종료자
             * 종료자(Finalizer)라고도 하는 소멸자(Destructor)는 닷넷의 가비지 수집기(Garbage Collector, GC)에서 클래스의
             * 인스턴스를 사용한 후 최종 정리할 때 실행되는 클래스에서 가장 늦게 호출하는 메서드이다. c#에서는 닷넷 가비지 수집기(GC)가
             * 개체를 소멸할 때 메모리를 해제하는 등 역할을 대신해주기 때문에 이 책에서는 소멸자에 직접 접근할 일이 없다.
             * 
             * - 자동차 시동을 끄는 것에 비유할 수 있으며, 운전수가 주차하고 시동을 끄는 것이 아니라, 주차 요원(GC)이 대신 주차하고
             *  시동을 끄는 것과 의미가 비슷하다.
             * - 소멸자는 클래스 이름과 동일한 메서드로 앞에 물결 기호인 ~ (틸드)를 붙여 만든다
             * - 소멸자도 특별한 형태의 메서드이다. 소멸자 또한 소멸자 메서드라고도 한다. 생성자와 달리 매개변수를 받을 수 없다.
             * - 소멸자는 오버로딩을 지원하지 않으며, 직접 호출할 수도 없다.
             * 
             */
        }

        public void WhatIsInheritance()
        {
            /*
             * 클래스 간에는 부모와 자식 관계를 설정할 수 있다. 이러한 내용을 
             * 개체 관계 프로그래밍 (Object relationship programming)이라고도 한다. 상속은 부모 클래스에 정의된 기능을
             * 다시 사용하거나 확장 또는 수정하여 자식 클래스로 만드는 것이다. 특정 클래스에서 만든 기능을 
             * 다른 클래스에 상속으로 물려주면 장점이 많이 있다. 
             * 
             * 클래스 상속하기
             * 개체 지향 프로그래밍의 장점 중 하나는 이미 만든 클래스를 재사용하는 것이다. 이 재사용의 핵심 개념이 바로 상속이다.
             * 부모 재산을 자식에게 상속하듯이 부모 클래스(기본 클래스)의 모든 멤버를 자식 클래스(파생 클래스)가 재사용하도록 허가하는 
             * 기능이다. 여러 클래스 간의 관계를 설정할 때 수평 관계가 아닌 부모와 자식 간 관계처럼 계층적인 관계를 표현할 때
             * 사용하는 개념을 상속이라고 한다. 클래스 상속은 단일 상속(Single inheritance)과 다중 상속(Multiple Inheritance)으로
             * 구분할 수 있다. 단, c#의 클래스 상속은 단일 상속만 지원한다. 다중 상속은 나중에 배울 인터페이스로 지원받을 수 있다.
             * 
             * 클래스 상속 구문
             * c#에서는 다음과 같이 클래스 이름 뒤에 콜론(:)기호와 부모가 되는 클래스 이름을 붙인다.
             * public class [기본 클래스 이름]
             * {
             *  기본 클래스 멤버를 정의
             * }
             * 
             * public class [파생 클래스 이름] : [기본 클래스 이름]
             * {
             *      // 기본 클래스의 멤버를 포함한 자식 클래스의 멤버를 정의
             * }
             * 
             * - System.object 클래스 : System.Object 클래스는 모든 클래스의 부모 클래스이다. 닷넷에서 가장 높은 계층에
             * 속하는 시조(조상) 클래스라고 할 수 있다. 새롭게 만드는 c#의 모든 클래스는 자동으로 object 클래스에서 상속받기에
             * Object 클래스를 상속하는 코드는 생략 가능하다.
             * 
             * - 기본(base) 클래스 : 다른 클래스의 부모 클래스가 되는 클래스로 기본 클래스라고 한다.
             *      기본 클래스를 다른 말로 Base 클래스, Super 클래스, 부모 클래스 라고도 한다.
             *      
             * - 파생(Derived) 클래스 : 다른 클래스의 자식 클래스가 되는 클래스를 파생 클래스라고 한다.
             * 파생 클래스는 다른 클래스에서 멤버를 물려받은 것으로, Dereved 클래스, Sub 클래스, 자식 클래스로 표현한다.
             * 
             * 부모 클래스와 자식 클래스
             * 프로그래밍에서 상속을 표현할 때 상속을 주는 클래스를 부모 클래스라고 하며, 상속을 받는 클래스를 자식 클래스라고 한다.
             * 콜론(:) 기호로 상속 관계를 지정하면 부모 클래스의 public 멤버들을 자식 클래스에서 그대로 물려받아 사용할 수 있다.
             * public, protected 로 선언된 멤버들도 자식 클래스에서 사용 가능하다. (private 로 선언된 멤버는 상속이 안된다.)
             * 
             */
        }   // WhatIsInheritance()

    }   // Description

    class Parent
    {
        public string stringValue = "string Value -> 부모 클래스의 멤버 변수";
        protected int intValue = 1234;
        public void Print()
        {
            Console.WriteLine("부모의 출력이다.");
        }
    }

    class Child : Parent
    {
        public void PrintChild()
        {
            Console.WriteLine("자식의 출력이다.");
            Console.WriteLine("{0} {1}", base.stringValue, base.intValue);
        }
    }

    class CharacterBase
    {
        protected string name;
        protected int hp;
        protected int attack;
        protected int deffense;

        protected double AtkMdf;
        protected double DefMdf;


        private string[] behaviorDescs;
        public string GetBhvDescs(int num)
        {
            return behaviorDescs[num];
        }
        public string GetName()
        {
            return name;
        }

        protected void SetupBhvDescs()
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
            int rdNum = rd.Next(1, 100+1);
            Thread.Sleep(1000);
            if(rdNum <= 20)
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
            Console.WriteLine("{0}이(가) 나타났다!", enemy.GetName());
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
            this.deffense = 2;
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
        public Wolf()
        {
            this.name = "하얀 늑대";
            this.hp = 200;
            this.attack = 200;
            this.deffense = 200;
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
            while(!isBattleEnd)
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
            Console.WriteLine("{0}와(과) 조우했다!", enemy.GetName());
            CurrentPhase = BATTLEPHASE.PLAYERTURN;
        }

        private void prc_PlayerTurn()
        {
            int SelectNumber = 0;
            
            Console.WriteLine("플레이어의 턴");
            while(true)
            {
                Console.WriteLine("플레이어의 행동을 선택하세요.");
                Console.Write("1.공격, 2.방어, 3.모으기, 4.도망 : ");
                int.TryParse(Console.ReadLine(), out SelectNumber);
                if(SelectNumber >= 1 && SelectNumber <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("[System Error] 잘 못 입력하였습니다.");
                }
            }

            switch(SelectNumber)
            {
                case 1:
                    Console.WriteLine(player.GetBhvDescs(0), player.GetName());
                    player.Attack(enemy);
                    break;
                case 2:
                    Console.WriteLine(player.GetBhvDescs(1), player.GetName());
                    player.Deffense();
                    break;
                case 3:
                    Console.WriteLine(player.GetBhvDescs(2), player.GetName());
                    player.Charge();
                    break;
                case 4:
                    Console.WriteLine(player.GetBhvDescs(3), player.GetName());
                    if (player.Escape())
                    {
                        isBattleEnd= true;
                        CurrentPhase = BATTLEPHASE.GETREWARD;
                    }
                    break;
                default:
                    break;
            }
            
            CurrentPhase = BATTLEPHASE.ENEMYTURN;
            if(enemy.IsDead())
            {
                CurrentPhase = BATTLEPHASE.GETREWARD;
            }
        }

        private void prc_EnemyTurn()
        {
            

            Console.Write("{0}이 행동을 결정하고 있습니다", enemy.GetName());

            for(int i = 0; i < 3; i++)
            {
                Thread.Sleep(800);
                Console.Write(".");
            }
            Console.WriteLine();
            
            Random rd = new Random();
            int randNum = rd.Next(1, 4+1);
            switch(randNum)
            {
                case 1:
                    Console.WriteLine(enemy.GetBhvDescs(0), enemy.GetName());
                    enemy.Attack(player);
                    break;
                case 2:
                    Console.WriteLine(enemy.GetBhvDescs(1), enemy.GetName());
                    enemy.Deffense();
                    break;
                case 3:
                    enemy.Charge();
                    Console.WriteLine(enemy.GetBhvDescs(2), enemy.GetName());
                    break;
                case 4:
                    Console.WriteLine(enemy.GetBhvDescs(3), enemy.GetName());
                    if(enemy.Escape())
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
            if(enemy.IsDropItem())
            {
                player.AddItem(enemy.GetItemName());
            }
            Console.WriteLine("전투를 종료합니다.");
            isBattleEnd = true;
        }
    }
}
