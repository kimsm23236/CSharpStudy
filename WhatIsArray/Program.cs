// System 이라는 걸 가져와서 이것저것 사용할 예정
using System;
using System.Collections.Generic;
using System.Linq;

// 프로그램 이름
namespace WhatIsArray
{
    class numberBaseball
    {
        
        public List<int> HiddenNum { get; set;}
        public List<int> userInput { get; set;}

        private int loopCnt;
        private int deadCnt;
        private int NumberCount;
        public numberBaseball()
        {
            NumberCount = 9;
            HiddenNum = new List<int>();
            userInput = new List<int>();
            for(int i = 0; i < NumberCount; i++)
            {
                HiddenNum.Add(-2);
                userInput.Add(0);
            }
            loopCnt = 0;
            deadCnt = 3;
            InitHiddenNumber();
            Console.Write("컴퓨터의 히든 넘버를 설정하였습니다.");
        }

        public bool OutAns()
        {
            bool bIsRightAnswer = false;
            int strike = 0, ball = 0;
            /*
            for(int i = 0; i < 3; i++)
            {
                int num1 = userInput[i];
                for(int j = 0; j < 3; j++)
                {
                    int num2 = HiddenNum[j];
                    if(num1 == num2)
                    {
                        if(i == j)
                        {
                            strike++;
                        }
                        else
                        {
                            ball++;
                        }
                    }
                }
            }
            loopCnt++;
            Console.WriteLine("{0}번째 루프 {1} Strike, {2} Ball", loopCnt, strike, ball);
            if (strike >= 3)
            {
                Console.WriteLine("정답이므로 루프를 종료합니다.");
                bIsRightAnswer = true;
            }
            else if(loopCnt >= deadCnt)
            {
                Console.WriteLine("지정된  반복 횟수를 넘겼으므로 루프를 종료합니다.");
                bIsRightAnswer = true;;
            }
            */
            ///////
            for (int i = 0; i < NumberCount; i++)
            {
                int num1 = userInput[i];
                for (int j = 0; j < NumberCount; j++)
                {
                    int num2 = HiddenNum[j];
                    if (num1 == num2)
                    {
                        if (i == j)
                        {
                            strike++;
                        }
                        else
                        {
                            ball++;
                        }
                    }
                }
            }
            loopCnt++;
            Console.WriteLine("{0}번째 루프 {1} Strike, {2} Ball", loopCnt, strike, ball);
            if (strike >= NumberCount)
            {
                Console.WriteLine("정답이므로 루프를 종료합니다.");
                bIsRightAnswer = true;
            }
            else if (loopCnt >= deadCnt)
            {
                Console.WriteLine("지정된  반복 횟수를 넘겼으므로 루프를 종료합니다.");
                bIsRightAnswer = true; ;
            }
            ///////



            return bIsRightAnswer;
        }

        public bool UserInput()
        {
            bool bIsInputSuccess = true;
            Console.Write("숫자 세자리를 입력하세요 (공백으로 구분하고, 중복을 허용하지 않습니다) : ");
            string strinput = Console.ReadLine();
            string[] strarr = strinput.Split(' ');

            /*
            if(strarr.Length != 3)
            {
                bIsInputSuccess = false;
            }

            for(int i = 0; i < 3; i++)
            {
                int.TryParse(strarr[i], out userInput[i]);
            }

            for(int i = 0; i < userInput.Length - 1; i++)
            {
                int searchValue = userInput[i];
                for(int j = i + 1;j < userInput.Length; j++)
                {
                    if (searchValue == userInput[j])
                        bIsInputSuccess = false;
                }
            }
            */
            //////////////////////////////
            if (strarr.Length != NumberCount)
            {
                bIsInputSuccess = false;
                Console.WriteLine("입력한 숫자의 갯수가 적습니다.");
                return bIsInputSuccess;
            }

            for (int i = 0; i < NumberCount; i++)
            {
                userInput[i] = Convert.ToInt32(strarr[i]);
                //int.TryParse(strarr[i], out userInput1[i]);
            }

            for (int i = 0; i < userInput.Count; i++)
            {
                int searchValue = userInput[i];
                for (int j = i + 1; j < userInput.Count; j++)
                {
                    if (searchValue == userInput[j])
                    {
                        bIsInputSuccess = false;
                        Console.WriteLine("중복된 숫자가 있습니다.");
                        return bIsInputSuccess;
                    }
                }
            }
            //////////////////////////////

            return bIsInputSuccess;
        }

        private void InitHiddenNumber()
        {
            /*
            Random rd = new Random();
            int idx = 0;
            while(idx < 3)
            {
                int num = -1;
                    
                while(!HiddenNum.Contains(num))
                {
                    num = rd.Next(0, 9 + 1);
                    if(HiddenNum.Contains(num))
                    {
                        continue;
                    }
                    HiddenNum[idx] = num;
                    idx++;
                }    
            }
            */
            Random rd = new Random();
            int idx = 0;
            while (idx < NumberCount)
            {
                int num = -1;

                while (!HiddenNum.Contains(num))
                {
                    num = rd.Next(0, 9 + 1);
                    if (HiddenNum.Contains(num))
                    {
                        continue;
                    }
                    HiddenNum[idx] = num;
                    idx++;
                }
            }
        }
        
    }
    // 클래스라는 것인데, c#에서는 모든 요소들이 클래스 안에 있어야 함.
    internal class Program
    {
        // c# 콘솔(검은 창)을 사용할 때 무조건 1개가 필요한 Main() 메서드
        // 프로그램은 Main() 메서드 부터 시작한다.
        static void Main(string[] args)
        {
            // 여기서 시작.
            // Console.WriteLine("Hello, World!");

            // 3의 배수를 제외한 수
            /*
            int sumOfNumber = 0;

            for(int i = 1; i <= 100; i++)
            {
                bool bIsRealMultipleOfThree = i % 3 == 0;
                Console.WriteLine("{0} -> bIsRealMultipleOfThree : {1}", i, bIsRealMultipleOfThree);
                if(!bIsRealMultipleOfThree ) 
                {
                    sumOfNumber+= i;
                    Console.WriteLine("잘 더해지고 있나? : {0}", sumOfNumber);
                }
                else
                {

                }
            }
            */

            /*
             * if 분기문의 진행 과정
             * if( 조건 1 )
             * {
             *      조건 1이 True일 경우 if 문 안쪽 코드를 실행
             * }
             * else if( 조건 2 ) // 조건 1이 거짓일 경우 조건 2를 검사
             * {
             *      조건 2가 True일 경우 첫번째 else if 문 안쪽 코드를 실행
             * }
             * else if( 조건 3 ) // 조건 1, 2 가 거짓일 경우 조건 3을 검사 
             * {
             *      조건 3이 True일 경우 두번째 else if 문 안쪽 코드를 실행
             * }
             * .
             * .
             * .
             * else
             * {
             *      위 모든 조건문이 False 일 경우 else 문 안쪽 코드를 실행
             * }
             */

            /*
            for(int i = 0; i< 30; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine("콘솔 정리");

            // 프로그램 사용자로부터 양의 정수를 하나 입력받아서 그 수만큼 Hello World! 출력
            int num = default;
            bool isPositiveInterger = false;
            while(!isPositiveInterger)
            {
                Console.Write("양의 정수 입력 : ");
                int.TryParse(Console.ReadLine(), out num);
                isPositiveInterger = num > 0;
                if(!isPositiveInterger)
                {
                    Console.WriteLine("양의 정수가 아닙니다.");
                }
            }
            for(int i = 0; i < num; i++)
            {
                Console.WriteLine("Hello World!");
            }
            */

            /*
             * 프로그램 사용자로부터 계속해서 정수를 입력받는다.
             * 그리고 그 값을 계속해서 더해 나간다.
             * 이러한 작업은 프로그램 사용자가 0을 입력할 때까지 반복되어야 하며,
             * 0이 입력되면 입력된 모든 정ㅅ의 합을 출력하고 프로그램 종료
             */

            // bool isNumberZero = (num == 0);

            /*
             * 프로그램 사용자로부터 입력받은 숫자에 해당하는 구구단을 출력하되,
             * 역순으로 출력하는 프로그램을 작성
             */

            /*
            int userInputNumber = default;
            int.TryParse(Console.ReadLine(), out num);
            for(int i = 9; i >= 1; i--)
            {
                Console.WriteLine("{0} x {1} = {2}", num, i, num * i);
            }
            */

            /*
             * 프로그램 사용자로부터 입력 받은 정수의 평균을 출력하는 프로그램을 작성하되,
             * 다음 두 가지의 조건을 만족할 것
             * - 먼저 몇 개의 정수를 입력할 것인지 프로그램 사용자에게 묻는다.
             * 그리고 그 수만큼 정수를 입력받는다.
             * - 평균 값은 소수점 이하까지 계산해서 출력한다.
             */

            /*
             * LAB 1 비밀 코드 맞추기
             * 컴퓨터가 숨시고 있는 비밀 코드를 추측하는 게임을 작성
             * 비밀 코드는 a~z 사이의 문자
             * 컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에 있는지를 알려준다.
             * (즉, 사용자에게 힌트를 준다.)
             */

            /*
            char secretCode = 'y';
            char userInputAlphabet = 'z';
            bool isSmallAlphabet = ('a' <= userInputAlphabet && userInputAlphabet <= 'z');
            bool isFore = (userInputAlphabet < secretCode);
            bool isBack = (userInputAlphabet > secretCode);
            if(isFore) 
            {
                Console.WriteLine("당신의 알파벳은 시크릿 코드보다 앞에 있습니다.");
            }
            else
            {
                // Do Nothing 
            }
            if(isBack)
            {
                Console.WriteLine("당신의 알파벳은 시크릿 코드보다 뒤에 있습니다.");
            }

            Console.Write("삼각형의 단 수 입력 : ");
            int.TryParse(Console.ReadLine(), out userInputNumber);
            for(int i = 1; i <= userInputNumber; i++)
            {
                for(int j = 1; j <= i; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }

            Console.Write("다이아몬드 단수 입력(홀수) : ");
            int.TryParse(Console.ReadLine(), out userInputNumber);
            bool isOdd = false;
            isOdd = userInputNumber % 2 == 1;

            if(!isOdd)
            {
                Console.WriteLine("[System Error] 입력이 홀수가 아닙니다.");
            }
            else
            {
                int cntBlank = userInputNumber / 2;
                int cntStar = 1;
                int blankAdder = -1;
                int starAdder = 2;
                for (int i = 1; i <= userInputNumber; i++)
                {
                    for (int j = 1; j <= cntBlank; j++)
                    {
                        Console.Write(' ');
                    }
                    for (int j = 1; j <= cntStar; j++)
                    {
                        Console.Write("*");
                    }
                    Console.Write("\t\t\t\t\t\t\t 현재 단 {0}", i);
                    Console.WriteLine();
                    if (i > userInputNumber / 2)
                    {
                        blankAdder = 1;
                        starAdder = -2;
                    }
                    cntBlank += blankAdder;
                    cntStar += starAdder;
                }
            }
            */

            /*
             * 숫자야구
             */

            /*
            numberBaseball NB = new numberBaseball();
            foreach(int num in NB.HiddenNum)
            {
                Console.Write(" {0} ", num);
            }
            Console.WriteLine();
            while(true)
            {
                if(!NB.UserInput())
                {
                    continue;
                }
                if(NB.OutAns())
                {
                    break;
                }
            }
            */

            /*
             * 컬렉션
             * 이름 하나로 데이터 여러 개를 담을 수 있는 자료 구조를 컬렉션(Collection) 또는
             * 컨테이너(Container) 라고 한다. c#에서 다루는 컬렉션은 배열(Array), 리스트(List),
             * 사전(Dictionary) 등이 있다.
             * 
             * 배열
             * 배열(Array)은 같은 종류의 데이터들이 순차적으로 메모리에 저장되는 자료 구조이다. 각각의 데이터들은
             * 인덱스(번호)를 사용하여 독립적으로 접근된다. 배열을 사용하면 편리하게 데이터를 모아서 관리할 수 있다.
             * 
             * 배열의 특징들
             * 1. 배열 하나에는 데이터 형식 한 종류만 보관할 수 있다.
             * 2. 배열은 메모리의 연속된 공간을 미리 할당하고, 이를 대괄호([])와 0부터 시작하는 정수형 인덱스를
             *      사용하여 접근할 수 있다.
             * 3. 배열을 선언할 때는 new 키워드로 배열은 생성한 후 사용할 수 있다.
             * 4. 배열에서 값 하나는 요소(Element) 또는 항목(Item)으로 표현한다.
             * 5. 필요한 데이터 개수를 정확히 정한다면 메모리를 적게 사용하여 프로그램 크기가 작아지고 성능이
             *      향상된다.
             * 배열에는 세 가지 종류가 있다.
             * 1차원 배열 : 배열의 첨자를 하나만 사용하는 배열
             * 다차원 배열 : 첨자 두개 이상을 사용하는 배열 (2차원, 3차원, 4차원 ... n차원 배열)
             * 가변(Jagged) 배열 : '배열의 배열'이라고도 하며, 이름 하나로 다양한 차원의 배열을 표현할 때 사용한다.
             * 
             */

            // 배열의 선언과 초기화
            
            int[] numbers = new int[5] {1, 2, 3, 4, 5 };
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers.Length);

            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            foreach(int element in numbers)
            {
                Console.WriteLine(element);
            }
            

            //int number1 = 1;
            //int number2 = 2;
            //int number3 = 3;
            //int number4 = 4;
            //int number5 = 5;

            //Console.WriteLine(number1);
            // 여기서 끝
        }
    }
}