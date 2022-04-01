using System;
using System.Linq;

namespace BookMenuTask.Modals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!\n");
            Console.WriteLine("Kitab arrayini uzunlugunu daxil edin !\n");
            int bookArrLenght = int.Parse(Console.ReadLine());
            bool programRunStatus = true;
            Book[] bookArr = new Book[bookArrLenght];

            for (int i = 0; i < bookArrLenght; i++)
            {
                bookArr[i] = AddBook();
            }
            
 
            while (programRunStatus)
            {
                ShowMenu();
                SelectMenuOption();


            }
            //artan sira ile filetr





            #region Funksiyalar
            string allIntNumValidate(string readLineItem)
            {
                if (readLineItem.All(char.IsDigit))
                {
                    return readLineItem;
                }
                else
                {
                    Console.WriteLine("yanlis deyer yanliz reqem daxil edin");
                    var reWantvalue = Console.ReadLine();
                    allIntNumValidate(reWantvalue);
                    return "-1";
                }
                
            }
            Book AddBook()
            {
                Console.WriteLine("__________");
                Console.WriteLine("Id daxil et ");
                int id = int.Parse(allIntNumValidate(Console.ReadLine()));
                Console.WriteLine("Name daxil et ");
                string name = Console.ReadLine();
                Console.WriteLine("Price daxil et ");
                double price = double.Parse(Console.ReadLine());
                Console.WriteLine("Count daxil et ");
                int count = int.Parse(allIntNumValidate(Console.ReadLine()));
                Console.WriteLine("Genre daxil et ");
                string genre = Console.ReadLine();
                Console.WriteLine("---------");


                return new Book(id, name, price, count, genre);
            }
            void ShowMenu()
            {
                Console.WriteLine("");
                Console.WriteLine(" 1. Kitablari qiymete gore filterle");
                Console.WriteLine(" 2. Butun Kitablari goster");
                Console.WriteLine(" 0. Programi bagla");
                Console.WriteLine("");
            }
            void MenuOption_1_Filter()
            {
                Console.WriteLine("max min diymetleri teyin edin");
                Console.WriteLine("min qiymet");
                double minPrice = double.Parse(Console.ReadLine());
                Console.WriteLine("max qiymet");
                double maxPrice = double.Parse(Console.ReadLine());
                Book[] temp = CopyObjArr(bookArr);
                //bubble sort
                for (int i = 0; i < temp.Length; i++)
                {
                    
                    for (int j = i; j < temp.Length; j++)
                    {
                        if (temp[i].price>temp[j].price)
                        {
                            Book temp1 = temp[i];
                            temp[i] =temp[j];
                            temp[j] = temp1;
                        }
                    }
                }


                ShowByFilterPrice(minPrice,maxPrice,temp);
              
            }
            void MenuOption_2_ShowAll(Book[] temp)
            {
                Book[] bookArrCopy = CopyObjArr(temp);
                bookArrCopy = FilterByNo(bookArrCopy);
                foreach (Book book in bookArrCopy)
                {
                    book.ShowInfo();
                }
            }
            void MenuOption_0_Close()
            {
                programRunStatus = false;
                Console.WriteLine("baglandi");
            }
            void SelectMenuOption()
            {
                string menuOptionStr = Console.ReadLine();

                // keydown  validation
                if (menuOptionStr.Length==1)
                {
                    //catch keydown and handle

                    char menuOption = char.Parse(menuOptionStr);
                    if (menuOption == '1')
                    {
                        MenuOption_1_Filter();
                    }
                    else if (menuOption == '2')
                    {
                        MenuOption_2_ShowAll(bookArr);
                    }
                    else if (menuOption == '0')
                    {
                        MenuOption_0_Close();
                    }
                    return ;
                }

                    Console.WriteLine("Zehmet olmasa 1 , 2 ve ya 0 daxil edin ");
                    Console.WriteLine("");
                    ShowMenu();
                    SelectMenuOption();
                
            }
            void ShowByFilterPrice(double min,double max,Book[] temp)
            {
                for (int i = 0; i < bookArr.Length; i++)
                {
                    if (temp[i].price > min && temp[i].price < max)
                    {
                        temp[i].ShowInfo();
                    }
                }
               
            }
            Book[] FilterByNo(Book[] temp)
            {
                for (int i = 0; i < temp.Length; i++)
                {

                    for (int j = i; j < temp.Length; j++)
                    {
                        if (temp[i].no > temp[j].no)
                        {
                            int temp1 = temp[i].no;
                            temp[i].no = temp[j].no;
                            temp[j].no = temp1;
                        }
                    }
                }
                return temp;
            }
            Book[] CopyObjArr(Book[] arr)
            {
                Book[] temp = new Book[arr.Length];
                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = arr[i];
                }
                return temp;
            }

            #endregion


        }
    }
}
