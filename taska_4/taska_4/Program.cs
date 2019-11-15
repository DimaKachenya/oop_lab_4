using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace taska_4
{
    public class Square
    {
        private double sizeOfSide;
        private double areaOfSquare;
        private double radiusOfSquare;

        public double SizeOfSide
        {
            get { return sizeOfSide; }
            set
            {
                if (value > 0)
                {
                    sizeOfSide = value;
                    areaOfSquare = Math.Pow(sizeOfSide, 2);
                    radiusOfSquare = sizeOfSide / 2;
                }
                else
                {
                    Console.WriteLine("Incorate date.");
                }
            }
        }

        public double AreaOfSquare
        {
            get { return areaOfSquare; }
            set
            {
                if (value > 0)
                {
                    areaOfSquare = value;
                    sizeOfSide = Math.Sqrt(areaOfSquare);
                    radiusOfSquare = sizeOfSide / 2;
                }
                else
                {
                    Console.WriteLine("Incorate date.");
                }
            }
        }

        public double RadiusOfSquare
        {
            get { return radiusOfSquare; }
            set
            {
                if (value > 0)
                {
                    radiusOfSquare = value;
                    sizeOfSide = radiusOfSquare * 2;
                    areaOfSquare = Math.Pow(sizeOfSide, 2);
                }
                else
                {
                    Console.WriteLine("Incorate date.");
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                   $"Длина стороны: {sizeOfSide}\n" +
                   $"Радиус вписанной окружности : {radiusOfSquare}\n" +
                   $"Площадь квадрата: {areaOfSquare} ";
        }

        public static Square operator +(Square First, Square Second)
        {
            Square SumOfSide = new Square();
            SumOfSide.sizeOfSide = First.sizeOfSide + Second.sizeOfSide;
           
            return SumOfSide;
        }

        public static Square operator -(Square First, Square Second)
        {
            Square SumOfSide = new Square();
            if (First.sizeOfSide - Second.sizeOfSide > 0)
            {
                SumOfSide.sizeOfSide = First.sizeOfSide - Second.sizeOfSide;
            }
            else
            {
                Console.WriteLine("We can't do this square.");
            }
            
            return SumOfSide;
        }
    }

    public class Collection
    {
        public class Information
        {
            public Information() { }
            private string timeOfCreation;
            public string TimeOfCreation
            {
                get { return timeOfCreation; }
                set { timeOfCreation = value; }
            }
        }

        Information timeOfInf = new Information();
        List<Square> MySquares = new List<Square>();

        public Collection()
        {
            DateTime now = DateTime.Now;
            timeOfInf.TimeOfCreation = $"Dima: {now.ToString("F")}";
        }

        public void Add(Square Figure)
        {
            MySquares.Add(Figure);
        }

        public void DeleteLast()
        {
            if (MySquares.Count != 0)
            {
                MySquares.RemoveAt(MySquares.Count - 1);
            }
            else
            {
                Console.WriteLine("Collection is void.");
            }
        }

        public void DeleteAll()
        {
            for (int i = MySquares.Count - 1; i <= 0; i--)
            {
                MySquares.RemoveAt(i);
            }
        }

        public void ShowInf()
        {
            Console.WriteLine($"{timeOfInf.TimeOfCreation}\n");
            for (int i = 0; i < MySquares.Count; i++)
            {
                Console.WriteLine($"{MySquares[i].ToString()}");
            }
        }

        public void FindInf(int i)
        {
            if (i >= 0 && i <= MySquares.Count)
            {
                Console.WriteLine($"{MySquares[i - 1].ToString()}");
            }
        }

        public void ShowNumber()
        {
            Console.WriteLine(MySquares.Count);
        }

    }
    class Program
    {
        static void AddElement(Collection myCollection)
        {
            Square mySquare = new Square();
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
                    mySquare.RadiusOfSquare = Convert.ToDouble(Console.ReadLine());
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
            Collection myCollection = new Collection();

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