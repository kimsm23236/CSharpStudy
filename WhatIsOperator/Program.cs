namespace WhatIsOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");

            Console.Write("숫자를 입력하세요 : ");
            string stringNumber = Console.ReadLine();
            int intNumber = Convert.ToInt32(stringNumber);
            Console.WriteLine("입력한 숫자 + 10은(는) {0}입니다.", intNumber + 10);

            string stringBinary = Convert.ToString(10, 2);
            Console.WriteLine(stringBinary);
            int intBinary = Convert.ToInt32("0111", 2);
            Console.WriteLine(intBinary);
            */

            /*
             * 연산자
             * 데이터로 연산 작업을 수행할 때는 연산자(Operator)를 사용한다.
             * 연산자는 기능에따라 대입, 산술, 관계, 논리, 증감, 조건, 비트, 시프트, 연산자 등으로 나누며, 
             * 이용 형태에 따라 항 1개로 연산을 하는 단항(Unary) 연산자와 항 2개로 연산을 하는 이항(Binary) 연산자, 
             * 항 3개로 연산을 하는 삼항(Ternary) 연산자로 나눈다.
             * 
             * 단항 연산자
             * 단항 연산자는 연산자와 피연산자 하나로 식을 처리한다.
             * ex) [연산자][피연산자]
             * + 연산자 : 특정 정수형 변수 값을 그대로 출력한다.
             * - 연산자 : 특정 정수형 변수 값을 음수로 변경하여 출력한다. 음수 값이 들어 있다면 양수로 변환해서 반환한다.
             * 
             * 이항 연산자
             * 이항 연산자는 연산자와 피연산자 2개로 식을 처리한다.
             * ex) [피연산자1][연산자][피연산자2]
             * 
             * 삼항 연산자
             * 삼항 연산자는 식 1개의 항(Expresion)과 그 결과에 따른 피연산자 각 1개씩 총 2개 항으로 식을 처리한다.
             * ex) (식) ? 피연산자1 : 피연산자2
             * 
             * 식과 문
             * 값 하나 또는 연산을 진행하는 구문의 계산식을 식(Expression) 또는 표현식이라고 한다. 표현식을 사용하여
             * 명령 하나를 진행하는 구문을 문(Statement) 또는 문장이라고 한다.
             */

            // 단항 연산자
            const int PLUS_FIVE = +5;
            const int MINUS_FIVE = -5;
            const int MINUS_FIVE2 = -5;

            // 이항 연산자
            const int PLUS_TEN = 5 + 5;

            // 삼항 연산자
            string compareTen = (PLUS_FIVE > 10) ? "{0}은(는) 10 보다 크다." : "{0}은(는) 10 보다 크지 않다.";
            Console.WriteLine(compareTen, PLUS_FIVE);

            // 변환 연산자
            // () 기호를 사용하여 특정 값을 원하는 데이터 형식으로 변환할 수 있다.
            const int PI_INT = (int)3.141592;
            const float PI_FLOAT = (float)3.141592;

            Console.WriteLine("PI_INT : {0}, PI_FLOAT : {1}", PI_INT, PI_FLOAT);

            /*
             * 산술, 관계, 논리, 증감, 조건, 비트, 시프트 연산자
             * 
             * 산술 연산자
             * 더하기(Add), 빼기(Subtract), 곱하기(Multiply), 나누기(Divide), 나머지(Remainder, Modules) 등
             * 수학적 연산을 하는 데 사용한다. 보통 정수 형식과 실수 형식의 산술 연산에 사용한다.
             * ex) +, -, *, /, %
             * 
             * 문자열 연결 연산자
             * 산술 연산자 중 하나인 + 연산자는 피연산자의 데이터 타입에 따라 산술 연산 또는 문자열 연결 연산을 수행한다.
             * 
             * + 연산자 : 두 항이 숫자일 때는 산술(+) 연산 가능, 문자열일 때는 문자열 연결 가능
             * 
             */

            string addMessage = "String " + "Plus " + "String";
            Console.WriteLine(addMessage);

            /*
             * 할당 연산자
             * 할당 연산자(Assignment operator)는 변수에 데이터를 대입하는 데 사용한다. 할당 연산자를 대입 연산자라고도 한다.
             * C#에서 = 기호는 같다는 의미가 아니라 오른쪽에 있는 값 또는 식의 결과를 왼쪽 변수에 할당하라도 지시하는 것이다.
             * 
             * ex) = +=, -=, *=, /=, %=
             * 
             * 
             * 증감 연산자(Increment / Decrement operator)
             * 변수 값을 1 증가시키거나 1 감소시키는 연산자이다.
             * 증감 연산자가 변수 앞에 위치하느냐, 뒤에 위치하느냐에 따라 연산 처리 우선순위가 결정된다.
             * 
             * ++(증가 연산자) : 변수 값에 1을 더한다.
             * --(감소 연산자) : 변수 값에 1을 뺀다.
             * 
             * 증감 연산자가 앞에 붙으면 전위 증감 연산자라고 하며, 변수 뒤에 붙으면 후위 증감 연산자라고 한다.
             * 
             * 전위(Prefix) 증감 연산자 : 정수형 변수 앞에 연산자가 위치하여 변수 값을 미리 증감한 후 나머지 연산을 수행한다.
             * 
             * 후위(Postfix) 증감 연산자 : 정수형 변수 뒤에 연산자가 위치하여 연산식(대입)을 먼저 실행한 후 나중에
             *                          변수 값을 증감한다.
             * 
             */

            int number = 0;
            number++;
            Console.WriteLine(number);

            /*
             * 관계형 연산자
             * 관계형 연산자(Relational operator) 또는 비교 연산자(Comparative operator)는 두 항이 큰지, 작은지,
             * 또는 같은지 등을 비교하는 데 사용한다. 관계형 연산자의 결과값을 논리 데이터 형식인 참(True), 또는
             * 거짓(False)으로 출력된다.
             * ex) <, <=, >, >=, ==, !=
             * 
             * 논리 연산자
             * 논리 연산자(Logical operator)는 논리곱(AND), 논리합(OR), 논리부정(NOT)의 조건식에 대한 논리 연산을 수행한다.
             * 연산의 결과값은 참 또는 거짓의 bool 형식으로 반환되어 Boolean 연산자라고도 한다.
             * ex) &&, ||, !
             * 
             * 비트 연산자
             * 비트 연산자(Bit operator)는 정수형 데이터의 값을 이진수 비트 단위로 연산을 수행할 때 사용한다.
             * ex) &, |, ^, ~
             * 
             * 시프트 연산자
             * 시프트 연산자(Shift operator)는 정수 데이터가 담겨 있는 메모리의 비트를 왼쪽 또는 오른쪽으로
             * 지정한 비트만큼 이동시킨다.
             * ex) <<, >>
             * 
             * 조건 연산자
             * 조건 연산자(Conditional operator)는 조건에 따라서 참일 때와 거짓일 때 결과를 다르게 반환하며, 
             * (조건식) ? (식1 또는 값1) : (식2 또는 값2) 형태의 연산자이다. if~else 문의 축약형이기도 하다.
             */

            bool bIsBigger = false;
            bIsBigger = (5 == 10);
            Console.WriteLine(bIsBigger);

            bIsBigger = !bIsBigger;
            Console.WriteLine(bIsBigger);

            int bitNumber = 10;
            int bitResult = 0;
            bitResult = bitNumber << 1;
            Console.WriteLine("bitNumber가 0010 상태를 가지고 있나요? -> {0}", bitResult);

            // 나열(콤마) 연산자
            // 콤마를 구분자로 하여 한 문장에 변수 여러 개를 선언할 때 사용한다.
            int intNumber1, intNumber2, intNumber3;

            /*
             * sizeof 연산자
             * sizeof 연산자는 단항 연산자로 데이터 형식 자체의 크기를 구하는 데 사용한다.
             * sizeof([데이터 타입]) 형태로 사용하며, 운영 체제와 cpu 아키텍처의 종류에 따라 결과값이 다르게 나올 수 있다.
             * 
             */

            Console.WriteLine("int의 메모리 크기는 {0} 바이트입니다.", sizeof(Int32));

            /*
             * 연산자 우선순위
             * 연산자 여러 개를 함께 사용할 때는 연산자 우선순위(Precedence)에 따라 계산된다.
             * 연산자 우선순위를 잘 모를 때는 일단 괄호 연산자부터 잘 사용하도록 연습하는게 좋다.
             */
            
            /*
            Console.Write("주어를 입력하세요 : ");
            string sbj = Console.ReadLine();
            Console.Write("동사를 입력하세요 : ");
            string vb = Console.ReadLine();
            Console.Write("목적어를 입력하세요 : ");
            string obj = Console.ReadLine();
            string strAns = String.Format("{0} {1} a {2}", sbj, vb, obj);
            Console.WriteLine(strAns);

            Console.Write("나이를 입력하세요 : ");
            int age = Convert.ToInt32(Console.ReadLine());
            age += 10;
            Console.WriteLine("10년 후에는 {0}살이 됩니다.", age);

            Console.Write("첫번째 변 : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("두번째 변 : ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 * num1 + num2 * num2;
            double ans = Math.Sqrt(sum);
            Console.WriteLine("빗변 길이 : {0}", ans);
            */

            /*
             * 상자의 길이(Length), 너비(Width), 높이(Height)를 입력하라는 메시지 표시
             * 상자의 부피와 표면적을 계산해서 출력하는 프로그램
             * SA=2lw+2lh+2hw
             */

            Console.Write("상자의 길이 : ");
            int length = 0, width = 0, height = 0; 
            int.TryParse(Console.ReadLine(), out length);
            Console.Write("상자의 너비 : ");
            int.TryParse(Console.ReadLine(), out width);
            Console.Write("상자의 높이 : ");
            int.TryParse(Console.ReadLine(), out height);
            int vol = length * width * height;
            int sfA = (2 * length * width) + (2 * length * height) + (2 * height * width);
            Console.WriteLine("상자의 부피 : {0}", vol);
            Console.WriteLine("상자의 표면적 : {0}", sfA);

            /*
             * 우리나라에서 많이 사용되는 면적의 단위인 평을 평방미터로 환산하는 프로그램 작성
             * 1평은 3.3058m^2
             * ex)  평 : 25.0
             *      평방미터 : ???
             */
            Console.Write("평 : ");
            int feet = 0;
            int.TryParse(Console.ReadLine(), out feet);
            double SquareMeter = feet * 3.3058f;
            Console.WriteLine("평방미터 : {0}", SquareMeter);


            /*
             * 시, 분, 초로 표현된 시간을 초 단위의 시간으로 변환하는 프로그램 작성
             * ex)  시 : 1
             *      분 : 1
             *      초 : 1
             *      전체 초 : ???
             */

            Console.Write("시 : ");
            int hour = Convert.ToInt32(Console.ReadLine());
            Console.Write("분 : ");
            int minute = Convert.ToInt32(Console.ReadLine());
            Console.Write("초 : ");
            int sec = Convert.ToInt32(Console.ReadLine());
            int total = hour * 3600 + minute * 60 + sec;
            Console.WriteLine("전체 초 : {0}", total);

            /*
             * 퀴즈, 중간고사, 기말고사의 성적을 사용자로부터 입력받아서 성적 총합을 계산하는 프로그램 작성
             * ex)  퀴즈  #1 성적 : 10
             *      퀴즈  #2 성적 : 20
             *      퀴즈  #3 성적 : 30
             *      중간고사  성적 : 80
             *      기말고사  성적 : 80
             *      =================
             *      성적 총합 : ???
             *      =================
             */
            Console.Write("퀴즈\t#1\t성적 : ");
            int quiz1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("퀴즈\t#2\t성적 : ");
            int quiz2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("퀴즈\t#3\t성적 : ");
            int quiz3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("중간고사\t성적 : ");
            int mT = Convert.ToInt32(Console.ReadLine());
            Console.Write("기말고사\t성적 : ");
            int fT = Convert.ToInt32(Console.ReadLine());

            int totalGrade = quiz1 + quiz2 + quiz3 + mT + fT;
            
            Console.WriteLine("==========================");
            Console.WriteLine("성적 총합 : {0}", totalGrade);
            Console.WriteLine("==========================");






        }
    }
}