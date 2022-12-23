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

    public enum SORT
    {
        SELECTION,
        BURBLE,
        MERGE
    }
    class Apples
    {
        public int[] randApples { get; set; } // 먹은 사과의 수 배열
        public int[] sortedApple { get; set; } // MergeSort 시 사용할 임시 배열

        private SORT koS { get; set; } // 정렬 함수 실행 시 정렬 방식을 결정할 열거형 변수

        public Apples()
        {
            // Random 객체 생성
            Random rd = new Random();
            // 사과의 수 멤버 배열을 메모리에 할당
            randApples = new int[1000];
            // 정렬에 사용할 임시 배열을 메모리에 할당
            sortedApple = new int[1000];
            koS = SORT.MERGE;
            Console.WriteLine("사과 배열 난수 생성");
            int idx = 0;
            do
            {
                int num = rd.Next(100, 10000 + 1);
                if (!randApples.Contains(num))
                {
                    randApples[idx] = num;
                    idx++;
                }
            }
            while (idx <= randApples.GetUpperBound(0));

            //for (int i = 0; i < 1000; i++)
            //{
            //    randApples[i] = rd.Next(100, 1000 + 1);
            //}
        }

        public void printApples()
        {
            Console.WriteLine("배열을 출력 합니다.");
            for(int i = 0; i < randApples.Length; i++)
            {
                Console.Write("{0,5} ", randApples[i]);
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }
        }

        public void sortApple()
        {
            Console.WriteLine("배열을 {0} 정렬합니다.", koS);
            switch(koS)
            {
                case SORT.SELECTION:
                    selectionSort();
                    break;
                case SORT.BURBLE:
                    burbleSort();
                    break;
                case SORT.MERGE:
                    mergeSort(0, randApples.GetUpperBound(0));
                    break;
                default:
                    break;
            }  
        }

        public void selectionSort()
        {
            for(int i = 0; i < randApples.Length; i++)
            {
                int min = randApples[i];
                int minidx = i;
                for(int j = i + 1; j < randApples.Length; j++)
                {
                    if(min > randApples[j])
                    {
                        min = randApples[j];
                        minidx = j;
                    }
                }

                if(minidx != i)
                {
                    int temp = randApples[i];
                    randApples[i] = randApples[minidx];
                    randApples[minidx] = temp;
                }
            }
        }

        public void burbleSort()
        {
            for(int i = 0; i < randApples.Length;i++)
            {
                for(int j = 0; j < randApples.Length - 1; j++)
                {
                    if (randApples[j] > randApples[j+1])
                    {
                        int temp = randApples[j];
                        randApples[j] = randApples[j+1];
                        randApples[j+1] = temp;
                    }
                }
            }
        }

        public void mergeSort(int left, int right)
        {
            if (left >= right)
                return;

            // 범위를 기반으로 중간 값 설정
            int mid = (left + right) / 2;
            // 나눈 중간을 기준으로 양옆으로 재귀하며 지정범위를 잘게 나눠주며 정렬
            mergeSort(left, mid);
            mergeSort(mid + 1, right);

            // 병합하며 정렬하는 머지함수 실행
            merge(left, mid, right);


        }

        public void merge(int left, int mid, int right)
        {
            
            // 배열을 두개로 나누고
            // 두개의 배열에서 작은 값을 임시 배열에 대입하는 것을 반복하여 임시 배열을 완성한 후
            // 임시배열을 정식 배열에 대입하여 정렬

            // 나눈 배열 중 왼쪽 배열의 첫번째 인덱스 변수
            int i = left;
            // 나눈 배열 중 오른쪽 배열의 첫번째 인덱스 변수
            int j = mid + 1;
            // 임시 배열에 대입을 위한 인덱스 변수
            int k = left;

            // 나머지 배열 인덱스 변수
            int l;


            while(i <= mid && j <= right)
            {
                // 나뉜 배열의 양 옆을 첫번째부터 비교하여
                // 더 작은쪽을 임시 배열에 대입
                // 이것을 나뉜 배열 중 한쪽에 끝에 다다를 때 까지
                if (randApples[i] < randApples[j])
                {
                    sortedApple[k++] = randApples[i++];
                }
                else
                {
                    sortedApple[k++] = randApples[j++];
                }
            }

            // 위에서 나눈 배열 중 한 쪽 배열의 값을 전부 임시 배열에 대입하고
            // 남는 다른 한쪽의 배열을 임시배열에 추가로 대입
            if(i > mid)
            {
                for(l = j; l <= right; l++)
                {
                    sortedApple[k++] = randApples[l];
                }
            }
            else
            {
                for(l = i; l <= mid; l++)
                {
                    sortedApple[k++] = randApples[l];
                }
                
            }

            //  정렬된 임시 배열을 대입  
            for(l = left; l <= right; l++)
            {
                randApples[l] = sortedApple[l];
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

            //int[] numbers = new int[5] {1, 2, 3, 4, 5 };
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(numbers.Length);

            //for(int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}
            //foreach(int element in numbers)
            //{
            //    Console.WriteLine(element);
            //}


            //int number1 = 1;
            //int number2 = 2;
            //int number3 = 3;
            //int number4 = 4;
            //int number5 = 5;

            //Console.WriteLine(number1);

            //int number = 1_0821;
            //Console.WriteLine("64로 Mod 연산 {0}", number % 64);

            /*
             * 다차원 배열
             * 2차원 배열, 3차원 배열 등 차원이 2개 이상인 배열을 다차원 배열이라고 한다.
             * c#에서 배열을 선언할 때는 콤마를 기준으로 차원을 구분한다.
             * 
             */

            //int[] oneArray = new int[2] { 1, 2 };
            //int[,] twoArray = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            //int[,,] threeArray = new int[2, 2, 2]
            //            {
            //                { { 1, 2 }, { 3, 4 } },
            //                { { 5, 6 }, { 7, 8 } }
            //            };

            // 3행 3열짜리 배열에서 행과 열이 같으면 1, 다르면 0을 출력
            //int[,] twoArr = new int[3, 5];
            //{
            //    {1, 1, 1 },
            //    {1, 1, 1 },
            //    {1, 1, 1 }
            //};
            //int[] oneArr = new int[3] { 1, 2, 3 };
            //for(int i = 0; i <= oneArr.GetUpperBound(0); i++)
            //{
            //    Console.Write("{0} ", oneArr[i]);
            //}
            //Console.WriteLine();

            //for(int i = 0; i <= twoArr.GetUpperBound(0); i++)
            //{
            //    for(int j = 0; j <= twoArr.GetUpperBound(1); j++)
            //    {
            //        if (i == j)
            //        {
            //            twoArr[i, j] = 1;
            //            Console.Write("{0} ", twoArr[i, j]);
            //        }
            //        else
            //        {
            //            twoArr[i, j] = 0;
            //            Console.Write("{0} ", twoArr[i, j]);
            //        }   
            //    }
            //    Console.WriteLine();
            //}

            /*
             * 가변 배열
             * 차원이 2개 이상인 배열은 다차원 배열이고, 배열 길이가 가변 길이인 배열은 가변 배열이라고 한다.
             */

            //int[][] zagArray = new int[2][];
            //zagArray[0] = new int[] { 1, 2 };
            //zagArray[1] = new int[] { 3, 4, 5 };

            //for(int i = 0; i < zagArray.Length; i++)
            //{
            //    for(int j = 0; j <  zagArray[i].Length; j++)
            //    {
            //        Console.Write("{0} ", zagArray[i][j]);
            //    }
            //    Console.WriteLine();
            //}

            //// int형 배열 intArray 선언
            //int[] intArray;
            //// int형 데이터 타입의 변수 3개를 메모리에 할당
            //intArray = new int[3];

            //intArray[0] = 1;    // intArray 0번째 인덱스에 1이라는 정수 값을 대입
            //intArray[1] = 2;    // intArray 1번째 인덱스에 2이라는 정수 값을 대입
            //intArray[2] = 3;    // intArray 2번째 인덱스에 3이라는 정수 값을 대입

            //// 배열을 직접 출력해본다.
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine("{0} 번째 인덱스의 값 -> {1}", i, intArray[i]);
            //}

            //for(int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine();
            //}

            //// intArray 배열에서 int 형 데이터 타입의 값을 하나씩 뽑아서 num에 저장하여 사용할 것이다.
            //foreach(int num in intArray)
            //{
            //    Console.WriteLine("intArray 배열에서 뽑아온 값 : {0} ", num);
            //} // loop : intArray배열의 값 개수만큼 루프를 돈다.

            //// 배열을 사용하여 국어 점수의 총점과 평균 구하기
            //int[] arrKoreanGrade = new int[5] {10, 20, 50, 80, 99 };
            //int sum = 0;
            //float avr = 0.0f;
            //for(int i = 0; i <= arrKoreanGrade.GetUpperBound(0); i++)
            //{
            //    sum += arrKoreanGrade[i];
            //}

            //avr = (float)sum / arrKoreanGrade.Length;

            //Console.WriteLine("국어점수의 총점 : {0}", sum);
            //Console.WriteLine("국어점수의 평균 : {0:F1}", avr);

            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine();
            //}

            ///*
            // * 위의 문제를 점수를 입력받아서 푸는 형식으로
            // */

            //int[] arrEnglishGrade = new int[3];
            //for(int i = 0; i < arrEnglishGrade.Length; i++)
            //{
            //    Console.Write("{0} 번째 학생의 영어 점수를 입력하세요 : ", i + 1);
            //    int.TryParse(Console.ReadLine(), out arrEnglishGrade[i]);
            //    if (arrEnglishGrade[i] > 100 || arrEnglishGrade[i] < 1)
            //    {
            //        Console.WriteLine("[System Error] 입력한 범위가 잘못되었습니다.");
            //        i--;
            //    }


            //}

            //sum = 0;
            //for (int i = 0; i <= arrEnglishGrade.GetUpperBound(0); i++)
            //{
            //    sum += arrEnglishGrade[i];
            //}

            //avr = (float)sum / arrEnglishGrade.Length;

            //Console.WriteLine("영어점수의 총점 : {0}", sum);
            //Console.WriteLine("영어점수의 평균 : {0:F1}", avr);


            /*
             * LAB 1. 배열에서 최대값 찾기
             * 크기가 100인 배열을 1투버 100사이의 난수로 채우고 배열 요소 중에서 최대값을 찾아보자
             */

            /*
            // int 데이터 타입 변수의 배열 선언 및 메모리 할당
            int[] numbs = new int[100];
            // 난수 생성을 위한 Random 클래스 객체 생성
            Random rd = new Random();

            // int 배열 numbs의 크기만큼 반복하며 각각 난수 할당
            for(int i = 0; i < numbs.Length; i++)
            {
                // numbs[i] * numbs 배열의 i번째 인덱스를 가리킴
                // * numbs배열의 i번째 주소에 난수로 값을 할당
                numbs[i] = rd.Next(1, 100 + 1);
            }

            // int 배열 numbs의 크기만큼 반복하며 값을 출력
            for (int i = 0; i < numbs.Length; i++)
            {
                // {0, 3} * numbs[i]를 세 자리를 사용해 출력하겠다는 뜻
                Console.Write("{0,3} ", numbs[i]);
                // if와 Mod 연산을 이용해서 10번째 출력마다 줄바꿈
                if ((i + 1) % 10 == 0)
                    Console.WriteLine();
            }

            // *max 최대값 찾기 위한 int 형 변수
            int max = 0;
            // numbs의 수만큼 반복하며
            // * int 형 변수 num을 선언, numbs의 내용을 하나씩 가져와 할당 후 반복문 내에서 사용하겠다는 의미
            foreach(int num in numbs)
            {
                // 삼항 조건 연산자를 사용하여 최대값 갱신
                max = max < num ? num : max;
            }
            Console.WriteLine("배열 중 최대 값은 {0} 입니다.", max);
            Console.WriteLine();
            */

            /*
             * LAB 2. 사과를 제일 좋아하는 사람 찾기
             * 사람들 5명(사람1, 사람2, ...)에게 아침에 먹는 사과 개수를 입력하도록 요청하는 프로그램을 작성
             * 데이터 입력이 마무리되면 누가 가장 많은 사과를 아침으로 먹었는지 출력한다.
             * - 이상한 입력 예외처리
             * - 제일 적게 먹은 사람도 찾도록 수정해보기
             * - 먹은 사과의 개수 순으로 정렬
             * - merge sort 도전해보기
             *      - 정렬 도전 시 유저 입력 X
             *      - 데이터는 난수로 100 ~ 1000 개 정도의 값
             *      - 중복 제거.
             *      - 시간초는 전혀 상관 없음
             */

            /*
            // 사과 개수 유저 입력 버전

            // int 형 배열 선언 후 메모리 할당
            int[] apples = new int[5];
            // 최대값 최소값 체크를 위한 int 형 변수 선언
            int maxNum = -1, minNum = 5000;

            // apples의 길이만큼 반복하겠다는 반복문
            for (int i = 0; i < apples.Length; i++)
            {
                // 사과 개수 입력을 받기 위한 출력문
                Console.Write("{0}번째 사람이 먹은 사과 개수 :", i + 1);
                // 입력받은 string을 int로 형변환하여 apples의 각 인덱스에 넣어준다.
                int.TryParse(Console.ReadLine(), out apples[i]);

                // TryParse가 실패하는 경우, 0을 반환하기에 0을 예외처리 조건으로 넣어줌
                // ex) 특수문자를 입력하는 경우
                if (apples[i] == 0)
                {
                    Console.WriteLine("[System Error] 잘 못 입력하였습니다.");
                    // 입력에 실패했기에 인덱스 또한 다시 줄여준다.
                    i--;
                    continue;
                }
            }

            // apples의 길이 만큼 반복하며, apples 배열의 값을 가져와 int 형 변수 ap를 선언 및 값을 할당하여 사용
            foreach(int ap in apples)
            {
                // 삼항 조건 연산자를 사용하여 최대값 최소값 갱신
                maxNum = maxNum < ap ? ap : maxNum;
                minNum = minNum > ap ? ap : minNum;
            }

            // 출력
            Console.WriteLine("가장 많이 먹은 사람은 {0}개를 먹었습니다.", maxNum);
            Console.WriteLine("가장 적게 먹은 사람은 {0}개를 먹었습니다.", minNum);
            Console.WriteLine();
            */

            /*
            // 사과 개수 난수 버전
            // Apples 객체를 생성
            Apples apples_ = new Apples();
            // Apples 객체의 멤버 변수 배열을 출력하는 함수
            apples_.printApples();
            // Apples 객체의 멤버 변수 배열을 정렬하는 함수
            apples_.sortApple();
            // Apples 객체의 멤버 변수 배열을 출력하는 함수
            apples_.printApples();
            */
            /*
            int[] intMs = new int[100];
            int rdnum = 0;
            int index = 0;
            while(index < 100)
            {
                rdnum = rd.Next(1, 1000);
                if(!intMs.Contains(rdnum))
                {
                    intMs[index] = rdnum;
                    index++;
                }
            }
            */

            /*
             * 사용자로부터 2개의 문자열을 읽어서 같은지 다른지 화면에 출력하는 프로그램 작성
             * ex) 첫번째 문자열 : hello
             *      두번째 문자열 : world
             *      두개의 문자열은 다릅니다.
             */

            string str1, str2;
            Console.Write("첫번째 문자열 : ");
            str1 = Console.ReadLine();
            Console.Write("두번째 문자열 : ");
            str2 = Console.ReadLine();

            if(str1.Length == str2.Length)
            {
                bool isEqual = true;
                for(int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        isEqual = false;
                    }
                }
                if(isEqual)
                {
                    Console.WriteLine("두개의 문자열은 같습니다.");
                }
                else
                {
                    Console.WriteLine("두개의 문자열은 다릅니다.");
                }
            }
            else
            {
                Console.WriteLine("두개의 문자열은 다릅니다.");
            }

            Console.WriteLine();
            Console.WriteLine();

            /*
             * 5개의 음료(콜라, 물, 스프라이트, 주스, 커피)를 판매하는 자판기 머신을 구현해보기
             * 사용자가 1부터 5사이의 숫자를 입력하면
             * 선택한 음료를 출력함
             * 1 ~ 5 이외의 숫자를 선택하면 오류 메시지 출력
             * ex) 콜라, 물, 스프라이트, 주스, 커피(1~5) 중에서 하나를 선택하세요 : 1
             * 콜라를 선택하였습니다.
             */

            string[] drinks = new string[5] { "콜라", "물", "스프라이트", "주스", "커피" };
            Console.Write("음료를 선택해주세요 (1. 콜라, 2. 물, 3. 스프라이트, 4. 주스, 5. 커피) : ");
            int drNum = 0;
            int.TryParse(Console.ReadLine(), out drNum);
            if(drNum > 0 && drNum <= drinks.Length)
            {
                Console.WriteLine("{0}을(를) 선택하였습니다.", drinks[--drNum]);
            }
            else
                Console.WriteLine("[System Error] 입력 범위가 잘못되었습니다.");
            
            Console.WriteLine();
            Console.WriteLine();

            /*
             * 배열 days[]를 아래와 같이 초기화하고 배열 요소의 값을 다음과 같이 출력하는 프로그램 작성
             * * 배열 days[] {31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}
             * ex) 1월은 31일까지 입니다.
             *      2월은 29일까지 입니다.
             *      .
             *      .
             *      .
             *      
             */
            int[] days = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for(int i = 0; i < days.Length; i++)
            {
                Console.WriteLine("{0}월은 {1}일까지 입니다.", i + 1, days[i]);
            }









            // 여기서 끝
        }
    }
}