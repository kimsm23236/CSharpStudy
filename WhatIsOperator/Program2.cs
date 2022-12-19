using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WhatIsOperator
{
    internal class Program2
    {
        static void Main(string[] args)
        {          
            /*
             * 최대한도의 사탕사기
             * 현재 1000원이 있고 사탕의 가격이 300원 일 때
             * 최대 살 수 있는 사탕의 개수와 나머지 돈은 얼마인지 출력하는 프로그램
             * ex) 현재 가지고있는 돈 : 1000(유저 입력)
             *      사탕 가격 : 300(상수)
             *      사탕 개수 : ???
             *      나머지 금액 : ??? 
             */
            int money = default;
            const int PRICE = 300;
            Console.Write("현재 가지고 있는 돈\t: ");
            int.TryParse(Console.ReadLine(), out money);
            Console.WriteLine("사탕 가격\t\t: {0}", PRICE);
            int NumOfCandy = money / PRICE;
            Console.WriteLine("사탕 개수\t\t: {0}", NumOfCandy);
            int change = money - PRICE * NumOfCandy;
            Console.WriteLine("나머지 금액\t\t: {0}", change);

            /*
             * 화씨온도를 섭씨온도로 바꾸기
             * 우리나라는 섭씨 온도를 사용하지만, 미국에서는 화씨 온도를 사용한다.
             * 화씨 온도를 섭씨 온도로 바꾸는 프로그램을 작성
             * ex)  화씨온도 60도는  섭씨온도 ????입니다.
             * (F - 32) * 5 / 9
             */
            int ft = default;
            Console.Write("화씨온도 입력 : ");
            int.TryParse(Console.ReadLine(), out ft);
            string outStr = "화씨온도 {0}도는 섭씨온도 {1}입니다.";
            Console.WriteLine(outStr, ft, (ft - 32) * 5.0f / 9.0f);

            /*
             * 주사위 게임
             * 2개의 주사위를 던져서 주사위의 합을 표시하는 프로그램을 작성. 주사위를 던지면 랜덤한 수가 나와야 한다.
             * ex) 첫번째 주사위 : ???
             *      두번째 주사위 : ???
             *      두 주사위 합 : ???
             */
            Random rd = new Random();
            int num1 = rd.Next(1, 6 + 1);
            int num2 = rd.Next(1, 6 + 1);
            Console.WriteLine("첫번째 주사위\t: {0}", num1);
            Console.WriteLine("두번째 주사위\t: {0}", num2);
            Console.WriteLine("두 주사위 합\t: {0}", num1 + num2);



        }
    }
}
