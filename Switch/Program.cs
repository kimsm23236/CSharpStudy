using System;
using System.Linq;

namespace Switch
{ 
    class Question
    {
        public char Oper { get; set; }
        public int num1 { get; set; }
        public int num2 { get; set; }
        public int answer { get; set; }
        public string Description { get; set; }

        public string strKoQ { get; set; }
        public Question()
        {
            Random rd = new Random();
            num1 = rd.Next(0, 99 + 1);
            num2 = rd.Next(0, 99 + 1);
            int randOper = rd.Next(1, 4+1);
            switch(randOper)
            {
                case 1:
                    answer = num1 + num2;
                    Oper = '+';
                    strKoQ = "덧셈 문제";
                    break;
                case 2:
                    answer = num1 - num2;
                    Oper = '-';
                    strKoQ = "뺄셈 문제";
                    break;
                case 3:
                    answer = num1 * num2;
                    Oper = '*';
                    strKoQ = "곱셈 문제";
                    break;
                case 4:
                    if(num2 != 0)
                    {
                        answer = num1 / num2;
                    }
                    Oper = '/';
                    strKoQ = "나눗셈 문제";
                    break;
                default:
                    break;
            }
            Description = string.Format("{0} {1} {2} = ", num1, Oper, num2);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 선택문인 switch 문은 값에 따라 다양한 제어를 처리할 수 있다. 조건을 처리할 내용이 많은 경우 유용하다.
             * switch, case, default 키워드를 사용하여 조건을 처리한다.
             */
            /*
            Console.Write("정수 1, 2, 3 중 하나를 입력하세요 : ");
            int switchNumber = 0;
            int.TryParse(Console.ReadLine(), out switchNumber);

            switch(switchNumber)
            {
                case 1:
                    Console.WriteLine("1을(를) 입력하였습니다.");
                    goto case 3; // case 3 으로 점프
                case 2:
                    //Console.WriteLine("2을(를) 입력하였습니다.");
                    //break;
                case 3:
                    Console.WriteLine("3을(를) 입력하였습니다.");
                    break;
                default:
                    Console.WriteLine("처리하지 않은 예외 입력입니다.");
                    break;
            } // switch
            */

            /*
             * 02.5 중간점검
             * 1. case 절에서 break 문을 생략하면 어떻게 되는가?
             */

            /*
            Console.WriteLine("가장 좋아하는 프로그래밍 언어는?");
            Console.Write("1. c \t");
            Console.Write("2. c++ \t");
            Console.Write("3. c# \t");
            Console.Write("4. Java \t");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("c을(를) 선택하였습니다.");
                    break;
                case 2:
                    Console.WriteLine("c++을(를) 선택하였습니다.");
                    break;
                case 3:
                    Console.WriteLine("c#을(를) 선택하였습니다.");
                    break;
                case 4:
                    Console.WriteLine("Java을(를) 선택하였습니다.");
                    break;
                default:
                    Console.WriteLine("[System] 처리하지 않은 예외 입력입니다.");
                    break;
            } // switch
            */

            /*
            Console.WriteLine("오늘의 날씨는 어떤가요? (맑음, 흐림, 비, 눈, ...)");
            string weather = Console.ReadLine();

            switch(weather)
            {
                case "맑음":
                    Console.WriteLine("오늘의 날씨는 맑습니다.");
                    break;
                case "흐림":
                    Console.WriteLine("오늘의 날씨는 흐립니다.");
                    break;
                case "비":
                    Console.WriteLine("오늘의 날씨는 비가 옵니다.");
                    break;
                case "눈":
                    Console.WriteLine("오늘의 날씨는 눈이 옵니다.");
                    break;
                default:
                    Console.WriteLine("[System] 처리하지 않은 예외 입력입니다.");
                    break;
            } // switch
            */

            // while 문은 조건식이 참일 동안 문장을 반복 실행한다.
            // while 문은 반복문인데 5번 실행할 예정

            /*
            int loopCounter = 0;
            while(loopCounter < 5)
            {
                Console.WriteLine("지금이 {0}번째 루프입니다.", ++loopCounter);
            }

            // 10~1 카운트 후 발사 출력하는 프로그램 작성
            loopCounter = 10;
            while (loopCounter > 0)
            {
                Console.WriteLine("{0}", loopCounter--);
            }
            Console.WriteLine("발사!");
            */
            // 예제 #1 구구단 출력하는 프로그램 작성, user input 받아서 해당 단을 출력
            /*Console.Write("구구단 중 출력할 단을 입력하세요 : ");
            int dan = Convert.ToInt32(Console.ReadLine());
            loopCounter = 1;
            while(loopCounter <= 9)
            {
                if (dan >= 10 || dan < 1)
                {
                    Console.WriteLine("입력이 잘 못 되었습니다.");
                    break;
                }
                Console.WriteLine("{0} x {1} = {2}", dan, loopCounter, dan*loopCounter);
                loopCounter++;
            }*/

            /*
             * 문제 1
             * 프로그램 사용자로부터 양의 정수를 하나 입력 받아서, 그 수만큼 "Hello world!"를 출력하는 프로그램 작성
             */
            /*
            Console.Write("양의 정수를 하나 입력하세요 : ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            loopCounter = 0;
            if (userInput < 1)
            {
                Console.WriteLine("[System] 처리하지 않은 예외 입력입니다.");
            }
            while (loopCounter < userInput)
            {
                
                Console.WriteLine("Hello World!");
                loopCounter++;
            }
            */

            /*
             * 문제 2
             * 프로그램 사용자로부터 양의 정수를 하나 입력 받은 다음, 그 수만큼 3의 배수를 출력하는 프로그램 작성
             * ex)  user Input : 5
             *      3, 6, 9, 12, 15
             */
            /*
            Console.Write("양의 정수를 하나 입력하세요 : ");
            userInput = Convert.ToInt32(Console.ReadLine());
            loopCounter = 1;
            if (userInput < 1)
            {
                Console.Write("[System] 처리하지 않은 예외 입력입니다.");
            }
            while (loopCounter <= userInput)
            {
                
                Console.Write("{0} ", loopCounter * 3);
                loopCounter++;
            }
            Console.Write("\n");
            */
            /*
             * 문제 3
             * 프로그램 사용자로부터 계속해서 정수를 입력 받는다. 그리고 그 값을 계속해서 더해 나간다. 이러한 작업은
             * 프로그램 사용자가 0을 입력할 때까지 계속되어야 하며, 0이 입력되면 입력된 모든 정수의 합을 출력하고 프로그램 종료.
             * ex)  user input : 1
             *      user input : 10
             *      user input : 0
             *      모든 정수의 합 : 11
             */
            /*
            userInput = 1;
            int sum = 0;
            while(userInput != 0)
            {
                Console.Write("정수 입력 : ");
                userInput = Convert.ToInt32(Console.ReadLine());
                sum += userInput;
            }
            Console.WriteLine("모든 정수의 합 : {0}", sum);
            */
            /*
             * 문제 4
             * 프로그램 사용자로부터 입력 받은 숫자에 해당하는 구구단을 출력하되, 역순으로 출력하는 프로그램을 작성
             * ex)  user input : 2
             *      18 16 14 12 10 8 6 4 2
             */
            /*
            int gugudan = default;
            Console.Write("단 수 입력 : ");
            gugudan = Convert.ToInt32(Console.ReadLine());
            loopCounter = 9;
            while(loopCounter > 0)
            {
                // 구구단 예외처리
                if(gugudan > 9 || gugudan < 1)
                {
                    Console.WriteLine("[System] 처리하지 않은 예외 입력입니다.");
                    break;
                }
                Console.WriteLine("{0} x {1} = {2}", gugudan, loopCounter, gugudan * loopCounter);
                loopCounter--;
            }
            */
            /*
             * 문제 5
             * 프로그램 사용자로부터 입력 받은 정수의 평균을 출력하는 프로그램을 작성하되, 다음 두 가지의 조건을 만족할 것,
             * - 먼저 몇 개의 정수를 입력할 것인지 프로그램 사용자에게 묻는다. 그리고 그 수만큼 정수를 입력 받는다.
             * - 평균 값은 소수점 이하까지 계산해서 출력한다.
             * ex)  user input(Loop Count) : 3
             *      user input : 10
             *      user input : 10
             *      user input : 10
             *      평균 값 : 10.0
             */
            /*
            Console.Write("User Input (Loop Count) : ");
            int userInputLoopCnt = 0;
            userInputLoopCnt = Convert.ToInt32(Console.ReadLine());
            loopCounter = 0;
            sum = 0;
            while(loopCounter < userInputLoopCnt)
            {
                Console.Write("User Input : ");
                int num = Convert.ToInt32(Console.ReadLine());
                sum += num;
                loopCounter++;
            }
            double avrg = (double)sum / (double)userInputLoopCnt;
            Console.WriteLine("평균 값 : {0:F1}", avrg);
            */

            /*
            const float FLOAT_VALUE = 0.1f;
            int loopCount = 10;
            float sumOfFloatValue = 0.0f;

            while(0 < loopCount)
            {
                sumOfFloatValue += FLOAT_VALUE;
                loopCount--;

            }
            Console.WriteLine("무슨 값이 나오나 : {0}", sumOfFloatValue);
            */

            /*
             * 두 실수를 입력받아서 값이 같은지 다른지 출력하는 프로그램 작성.
             * *블로그
             * - 부동소수점 에러
             * - 엡실론
             */

            /*
            float fv1, fv2;
            Console.Write("첫번째 실수 입력 : ");
            float.TryParse(Console.ReadLine(), out fv1);

            Console.Write("두번째 실수 입력 : ");
            float.TryParse(Console.ReadLine(), out fv2);

            if(fv1 == fv2)
            {
                Console.WriteLine("두 실수 값은 같습니다.");
            }
            else
            {
                Console.WriteLine("두 실수 값은 다릅니다.");
            }
            */
            /*
             * for 문은 일정한 횟수만큼 반복할 때 유용하다.
             * 초기식을 실행한 후에 조건식이 참인 동안, 문장을 반복한다. 한번 반복이 긑날 때마다 증감식이 실행된다.
             */

            // 1~10 까지의 합

            /*int sum = 0;
            for(int i = 1; i <= 10; i++)
            {
                sum += i;
            }
            Console.WriteLine("1부터 10까지의 정수의 합 : {0}", sum);
            Console.WriteLine($"1부터 10까지의 정수의 합 : {sum}");
            */

            /*
             * 1~100 숫자 중에서 3의 배수를 제외한 수의 합 구하기
             */
            /*
            int sum = 0;
            for(int i = 1; i <= 100; i++)
            {
                if(i % 3 == 0) { /* Do Nothing } // 명시적으로 실수가 아님을 알림
                else
                {
                    sum += i;
                }
                //if (i % 3 != 0)
                //    sum += i;

            }
            Console.WriteLine("1 ~ 100 에서 3의 배수를 제외한 수의 합 : {0}", sum);
            */

            /*
             * break 문
             * break 문은 반복 루프를 벗어나기 위해서 사용한다. break 문이 실행되면 반복루프는 즉시 중단되고
             * 반복 루프 다음에 있는 문장이 실행된다.
             * 
             * continue 문
             * continue 문은 현재 수행하고 있는 반복 과정의 나머지를 건너뛰고 다음 반복 과정을 강제적으로 시작하게 만든다.
             * 반복 루프에서 continue 문은 만나게 되면 continue 문 다음에 있는 후속 코드들은 실행되지 않고 건너뛰게 된다.
             */

            /*
             * LAB 1
             * 자음과 모음 개수 세기
             * 사용자로부터 영문자를 받아서 자음과 모음의 갯수를 세는 프로그램을 작성
             * - 대 소문자 모두 카운트
             * ex) user Input : abcde
             *      자음 : 3
             *      모음 : 2
             *      
             */

            /*
            string strInput = Console.ReadLine();
            int numConsonant = 0, numVowel = 0;
            char[] vowel = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            string[] strarr;
            for(int i = 0; i < strInput.Length;i++)
            {
                if(vowel.Contains(strInput[i]))
                    numVowel++;
                /*
                switch(strInput[i]) 
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'A':
                    case 'E':
                    case 'I':
                    case 'O':
                    case 'U':
                        numVowel++;
                        break;
                    default:
                        numConsonant++;
                        break;
                }
                
            }
            Console.WriteLine("자음 개수 : {0}", strInput.Length - numVowel);
            Console.WriteLine("모음 개수 : {0}", numVowel);
            */

            /*
             * LAB 2
             * 숫자 맞추기 게임
             * 숫자 알아맞히기 게임이다. 프로그램은 1 ~ 100 사이의 정수를 저장하고 있음.
             * 사용자는 질문을 통해서 숫자를 알아 맞힌다. 사용자가 답을 제시하면 프로그램은 제시된 정수가 더 낮은지 높은지를
             * 알려준다. 사용자가 맞힐 때 까지 반복한다. (기본형)
             * 
             * (확장형 1)
             * - 프로그램을 수정하여 컴퓨터가 생성한 숫자를 사용자가 추측하는 대신에, 사용자가 결정한 번호를
             *   컴퓨터가 추측하도록 수정한다. 사용자는 컴퓨터가 추측한 숫자가 높거나 낮은지를 알려야 한다.
             * (확장형 2)
             * - 사용자가 결정한 값의 범위는 (1~100) 어떤 숫자를 생각하던 간에 7번 이하의 추측으로 컴퓨터가 맞힐 수 있도록
             *   프로그램 1을 수정하시오. ()
             */

            /*
            Random rd = new Random();
            int randNum = rd.Next(1, 100 + 1);
            Console.WriteLine("당신의 숫자를 입력해주세요 : ");
            int userNum = Convert.ToInt32(Console.ReadLine());
            int AreaS = 0;
            int AreaE = 100;
            int userInputNum = 0;
            int loopCnt = 0;
            while(userInputNum != randNum)
            {
                Console.WriteLine("{0}번째 루프", ++loopCnt);
                Console.Write("숫자를 하나 입력 해주세요 (1 ~ 100) : ");
                int.TryParse(Console.ReadLine(), out userInputNum);

                if(userInputNum > randNum)
                {
                    Console.WriteLine("컴퓨터의 숫자가 당신이 입력한 숫자보다 작습니다.");
                }
                else if(userInputNum < randNum)
                {
                    Console.WriteLine("컴퓨터의 숫자가 당신이 입력한 숫자보다 큽니다.");
                }
                else if(userInputNum > 100 || userInputNum < 1)
                {
                    Console.WriteLine("[System] 입력한 숫자의 범위가 틀립니다. 다시 입력해주세요.");
                    continue;
                }
                else
                {
                    Console.WriteLine("정답입니다!");
                    break;
                }
                int comInput = (AreaS + AreaE) / 2; 
                Console.WriteLine("컴퓨터는 숫자를 {0} 입력하였습니다.", comInput);
                if(comInput > userNum)
                {
                    Console.WriteLine("당신의 숫자{0}은(는) 컴퓨터가 입력한 {1}보다 작습니다.", userNum, comInput);
                    AreaE = comInput - 1;
                }
                else if(comInput < userNum)
                {
                    Console.WriteLine("당신의 숫자{0}은(는) 컴퓨터가 입력한 {1}보다 큽니다.", userNum, comInput);
                    AreaS = comInput + 1;
                }
                else
                {
                    Console.WriteLine("컴퓨터가 정답을 입력하였습니다. 입력한 숫자는 {0}", comInput);
                    break;
                }
                
            } // while
            */

            /*
             * Lab 3
             * 산수문제 자동 출제
             * 산수 문제를 자동으로 출제하는 프로그램을 작성해보자
             * 덧셈 문제들을 자동으로 생성하여야 한다.
             * 피연산자는 0~99 사이의 숫자 (난수)
             * 한 번이라도 맞으면 종료, 틀리면 리트라이 (기본형)
             * 
             * - 뺄셈, 곱셈, 나눗셈 문제도 출제(추가문제)
             * -> 나눗셈 예외처리(무한대 값 주의)
             */

            // 난수 발생을 위한 객체 생성
            Random rd = new Random(); 

            // 두 숫자를 난수로 초기화
            int num1 = rd.Next(0, 99 + 1);
            int num2 = rd.Next(0, 99 + 1);

            // 유저의 답 입력을 받을 변수 선언 및 초기화
            int userInputAns = default;
            /*
            // 정답 배열 선언 및 초기화
            int[] answers = { num1 + num2, num1 - num2, num1 * num2, default, default };

            string[] strKoQ = { "덧셈 문제", "뺄셈 문제", "곱셈 문제", "나눗셈 문제" };

            // 정답 배열 나눗셈 예외처리
            // 두번째 수가 0일 경우 나눗셈 정답이 무한대가 되므로 예외처리
            if(num2 != 0)
            {
                answers[3] = num1 / num2;
            }
            else
            {
                answers[3] = 0;
            }
                
            // operator 배열 선언 및 초기화
            char[] opers = { '+', '-', '*', '/', '?'};

            // 첫번째 정답 변수 선언 및 초기화
            int curAns = answers[0];
            // 정답 개수 변수 선언 및 초기화
            int cntAns = 0;

            // 반복문 문제가 4개이므로 정답 개수가 4개가 될때까지 루프
            while(cntAns < 4)
            {
                // 나눗셈 문제 풀 차례 예외처리
                if (cntAns == 3)
                {
                    if (num2 == 0)
                    {
                        Console.WriteLine("두번째 피 연산자가 0, 답이 무한대가 나오므로 나눗셈 문제는 PASS합니다.");
                        break;
                    }
                    Console.WriteLine("나눗셈 계산시 소수점 제외 해주세요.");     
                }
                    

                Console.Write("{0} {1} {2} = ", num1, opers[cntAns], num2);
                int.TryParse(Console.ReadLine(), out userInputAns);

                if (userInputAns == curAns)
                {
                    Console.WriteLine("{0} 정답입니다.", strKoQ[cntAns]);
                    cntAns++;
                    curAns = answers[cntAns];
                }
                else
                {
                    Console.WriteLine("틀렸습니다. 다시 한번 입력해주세요.");
                }
            } // while
            */

            /*
            Question[] questions = new Question[10];
            for(int i = 0; i < 10; i++)
            {
                questions[i] = new Question();
            }
            int cntAns = 0;
            while(cntAns < questions.Length)
            {
                int curAns = questions[cntAns].answer;
                userInputAns = default;
                Console.Write(questions[cntAns].Description);
                int.TryParse(Console.ReadLine(), out userInputAns);

                if(userInputAns == curAns)
                {
                    Console.WriteLine("{0} 정답입니다.", questions[cntAns].strKoQ);
                    cntAns++;
                }
                else
                {
                    Console.WriteLine("틀렸습니다. 다시 한번 입력해주세요.");
                }
            }
            */

            /*
             * foreach 문은 배열(Array)이나 컬렉션(Collection) 같은 값을 여러 개 담고 있는 데이터 구조에서
             * 각각의 데이터가 들어 있는 만큼 반복하는 반복문이다. 데이터 개수나 반복 조건을 처리할 필요가 없다.
             */

            // string 글자에서 한 글자씩 출력
            string strHw = "Hello World!";
            int lpc = 0;
            foreach(char ch in strHw)
            {
                Console.Write("{0} ", ch);
                lpc++;
            }
            Console.WriteLine();
            Console.WriteLine("Loop Count : {0}, string Text's Length : {1}", lpc, strHw.Length);

            /*
             * 1~100 숫자 중에서 3의 배수이면서 4의 배수인 정수 합 구하기
             */
            int sum = 0;
            for(int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 4 == 0)
                    sum += i;
            }
            Console.WriteLine("1 ~ 100 에서 3의 배수이면서 4의 배수인 정수 합 : {0}", sum);

            /*
             * 두 개의 정수를 입력 받아서 두 수의 차를 출력하는 프로그램 작성
             * 항상 큰 수에서 작은 수를 뺀 결과를 출력할 것
             * 결과는 언제나 0 이상이어야 함
             */
            num1 = default;
            num2 = default;
            Console.Write("첫번째 정수 입력 : ");
            int.TryParse(Console.ReadLine(), out num1);
            Console.Write("두번째 정수 입력 : ");
            int.TryParse(Console.ReadLine(), out num2);
            int biggerNum = num1 >= num2 ? num1 : num2;
            int lowerNum = num1 <= num2 ? num1 : num2;
            Console.WriteLine("큰 수에서 작은 수를 뺀 결과 : {0}", biggerNum - lowerNum);



            /*
             * 구구단을 출력하되 짝수 (2단, 4단, 6단, 8단)만 출력되도록 하는 프로그램을 작성.
             * - 2단은 2 x 2 까지만, 4단은 4 x 4 까지만 ... 8단은 8 x 8 까지만 출력한다.
             * - break와 continue를 사용할 것
             */

            for(int i = 2; i < 9; i++)
            {
                if (i % 2 == 1)
                    continue;
                for(int j = 1; j <= i; j++)
                {
                    Console.WriteLine("{0} x {1} = {2}", i, j, i * j);
                }
            }

            /*
             * 다음 식을 만족하는 모든 A와 Z를 구하는 프로그램을 작성
             *      A Z
             * +    Z A
             * --------
             *       99
             */
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    if((i * 10 + j) + (j * 10 + i) == 99)
                    {
                        Console.WriteLine("  {0}{1}", i, j);
                        Console.WriteLine("+ {0}{1}", j, i);
                        Console.WriteLine("________");
                        Console.WriteLine("     {0}", (i * 10 + j) + (j * 10 + i));
                        Console.WriteLine();
                    }    
                }
            }

            /*
             * 오늘의 과제 LAB 문제 1~3 모든 라인에서 각 라인이 어떤 역할을 하는지 주석으로 설명해서 제출할 것.
             * (형태는 zip 파일, *gitignore 참고 *용량 잘 보고 올릴것.)
             */

        } // Main()
    }
}
/*
string[] str = { 'a', 'b', 'c' };

for(int i = 0; i < str.Length; i++)
{
    str[i]
}*/