using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOperator
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            /*
             * 제어문 소개
             * 프로그램을 이루는 3가지의 중요한 제어 구조에는 순차 구조(순차문), 선택 구조(조건문), 반복 구조(반복문)가 있다.
             * 
             * 순차문
             * 프로그램은 기본적으로 Main() 메서드 시작 지점부터 끝 지점까지 코드가 나열되면 순서대로 실행 후 종료한다.
             * 
             * 제어문
             * 프로그램 실행 순서를 제어하거나 프로그램 내용을 반복하는 작업 등을 처리할 때 사용하는 구문으로
             * 조건문과 반복문으로 구분된다.
             * 
             * 조건문(선택문)
             * 조건의 참 또는 거짓에 따라 서로 다른 명령문을 실행할 수 있는 구조이다. 분기문 또는 비교 판단문이라고
             * 하기도 한다.
             * 
             * 반복문
             * 특정 명령문을 지정된 수만큼 반복해서 실행할 때나 조건식이 참일 동안 반복시킬 때 사용한다.
             */

            /*
             * if / else 문
             * 프로그램 흐름을 여러 가지 갈래로 가지치기(Branching)할 수 있는데, 이때 if 문을 사용한다.
             * if 문은 조건을 비교해서 판단하는 ㄱ무ㅜㄴ으로 if, else if, else 세가지 키워드가 있다.
             */

            // 02.3 예제 #1
            // 두개의 정수 중에서 더 큰 수를 찾는 프로그램

            //int numberX, numberY;
            //Console.Write("X 값을 입력하세요 : ");
            //int.TryParse(Console.ReadLine(), out numberX);
            //Console.Write("Y 값을 입력하세요 : ");
            //int.TryParse(Console.ReadLine(), out numberY);

            //if(numberX > numberY)
            //{
            //    Console.WriteLine("X가 Y보다 큽니다.");
            //}
            //else
            //{
            //    Console.WriteLine("X가 Y보다 크지 않습니다.");
            //}

            // 02.4 중간점검 1
            // 컵의 사이즈를 받아서 100ml 미만은 small, 100ml 이상 200ml미만은 medium, 200ml 이상은 large라고
            // 출력하는 if-else 문을 작성
            //int intSize = default;
            //Console.Write("컵의 사이즈 입력하세요 : ");
            //int.TryParse(Console.ReadLine(), out intSize);
            //string outstr = "컵의 사이즈는 {0}입니다.";
            //string strSize = string.Empty;
            //if(intSize >= 200)
            //{
            //    strSize = "large";
            //}
            //else if(intSize >= 100)
            //{
            //    strSize = "medium";
            //}
            //else if(intSize >= 1)
            //{
            //    strSize = "small";
            //}
            //else 
            //{
            //    outstr = "사이즈를 잘못 입력하였습니다.";
            //}
            //Console.WriteLine(outstr, strSize);

            // LAB 1 비밀 코드 맞추기
            // 컴퓨터가 숨기고 있는 비밀 코드를 추측하는 게임을 작성
            // 비밀 코드는 A부터 Z사이의 문자
            // 컴퓨터는 사용자의 추측을 읽고서 앞에있는지 뒤에 있는지를 알려준다.
            char inputCh = default;
            Random rd = new Random();
            int intSecCode = rd.Next(97, 122 + 1);
            char SecCode = (char)intSecCode;
            while(inputCh != SecCode)
            {
                Console.Write("문자를 입력하세요 : ");
                char.TryParse(Console.ReadLine(), out inputCh);
                if (inputCh > 122 || inputCh < 97)
                {
                    Console.WriteLine("코드를 잘못입력하였습니다.");
                }
                else if(inputCh > SecCode)
                {
                    Console.WriteLine("{0} 앞에 있습니다.", inputCh);
                }
                else if(inputCh < SecCode)
                {
                    Console.WriteLine("{0} 뒤에 있습니다.", inputCh);
                }
                else
                {
                    Console.WriteLine("비밀 코드를 맞추었습니다.");
                }
            }

            // LAB 2 세개의 정수 중에서 큰 수 찾기
            // 사용자로부터 받은 3개의 정수 중에서 가장 큰 수를 찾는 프로그램 작성
            // ex) 3개의 정수를 입력하세요 : 20 10 30
            // out) 가장 큰 정수는 : 30
            string inputNumbers = string.Empty;
            Console.Write("3개의 정수를 입력하세요 : ");
            inputNumbers = Console.ReadLine();
            string[] strArr = inputNumbers.Split(' ');
            int[] numArr = new int[strArr.Length];
            for(int i = 0;i < strArr.Length; i++)
            {
                int.TryParse(strArr[i], out numArr[i]);
            }
            //int.TryParse(strArr[0], out numArr[0]);
            //int.TryParse(strArr[1], out numArr[1]);
            //int.TryParse(strArr[2], out numArr[2]);
            int max = 0;
            foreach(int i in numArr)
            {
                if(i > max)
                {
                    max = i;
                }
            }
            Console.WriteLine("가장 큰 정수는 : {0}", max);








        }   // Main()
    }
}
