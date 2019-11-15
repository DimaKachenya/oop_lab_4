using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace taska_4
{
   
    class Program
    {
        static void AddElement(Collection myCollection)
        {
            Square mySquare=new Square() ;
            int choise;
            Console.WriteLine("Введите 1 ,если хотите добавить длину стороны\n" +
                              "Введите 2 ,если хотите добавить радиус вписанной окружности\n" +
                              "Введите 3 ,если хотите добавить площадь квадрата\n"
            );
            choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.WriteLine("Введите длину стороны :");
                    mySquare.SizeOfSide = Convert.ToDouble(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("Введите радиус вписанной окружности :");
                    mySquare.RadiusOfSquare= Convert.ToDouble(Console.ReadLine()); 
                    break;
                case 3:
                    Console.WriteLine("Введите площадь квадрата :");
                    mySquare.AreaOfSquare = Convert.ToDouble(Console.ReadLine());
                    break;
            }
            myCollection.Add(mySquare);
        }
        static void FindInf(Collection myCollection)
        {
            Console.WriteLine("Введите номер элемента , который хотите найти");
            int choise = Convert.ToInt32(Console.ReadLine());
            myCollection.FindInf(choise);
        }
        static void Main(string[] args)
        {
            Collection myCollection=new Collection();
            
            int choise;

            while (true)
            {
                Console.WriteLine("Введите 1 ,если хотите добавить элемент\n" +
                                  "Введите 2 ,если хотите удалить все элементы\n" +
                                  "Введите 3 ,если хотите удалить последний элемент\n" +
                                  "Введите 4 ,если хотите вывести все элементы\n" +
                                  "Введите 5 ,если хотите вывести элемент по его номеру\n" +
                                  "Введите 6 ,если хотите посмотреть колличество элементов\n" +
                                  "Введите 666 для успешного выхода из программы"
                                  );
                choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        AddElement(myCollection);
                        break;
                    case 2:
                        myCollection.DeleteAll();
                        break;
                    case 3:
                        myCollection.DeleteLast();
                        break;
                    case 4:
                        myCollection.ShowInf();
                        break;
                    case 5:
                        FindInf(myCollection);
                        break;
                    case 6:
                        myCollection.ShowNumber();
                        break;
                    case 666:
                        break;

                }

            }

        }
    }
}
