using System;
using System.Collections.Generic;

namespace hashing
{

    internal class Program
    {
        class hashing
        {
            ulong count;
            ulong p;
            List<ulong>[] array;
            ulong a;
            ulong b;
            ulong inserted;
            public hashing()
            {
                p = 18361375334787046697;
                a = generateA();
                b = generateB();
                Console.WriteLine("a : " + a);
                Console.WriteLine("b : " + b);
                Console.WriteLine();
                inserted = 0;
                count = 1;
                array = new List<ulong>[count];
                for (ulong i = 0; i < count; i++)
                {
                    array[i] = (new List<ulong>());
                }
            }
            public List<ulong> generateRandom(ulong n)
            {
                List<ulong> list = new List<ulong>();
                Random random = new Random();

                for (ulong i = 0; i < n; i++)
                {

                    ulong uRange = (ulong)(1844674407709551616);
                    Random random1 = new Random();
                    ulong ulongRand;
                    do
                    {
                        byte[] buf = new byte[8];
                        random1.NextBytes(buf);
                        ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
                    } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

                    list.Add((ulong)(ulongRand % uRange) + 1);
                    

                }
                foreach (var i in list)
                {
                    Console.WriteLine(i);


                }
                return list;

            }
           
            public void insert(ulong k)
            {
               
                array[((a * k + b) % p) % count].Add(k);

                inserted++;
                if (inserted == count)
                {
                    reSize();
                }
            }
            public void Delete(ulong k)
            {

                array[((a * k + b) % p) % count].Remove(k);
            }
            public void search()
            {
                ulong p = 18361375334787046697;
                ulong uRange = (ulong)(p - 1);
                Random random1 = new Random();
                ulong ulongRand;
                do
                {
                    byte[] buf = new byte[8];
                    random1.NextBytes(buf);
                    ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
                } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

                ulong aa = (ulong)(ulongRand % uRange) + 1;
              
                foreach (var item in array)
                {
                    foreach (var v in item)
                    {
                        if (v == aa)
                        {
                            Console.WriteLine("value is searched");
                        }
                       
                    }

                }
                Console.WriteLine("value is not searched");
            }
           
            public void reSize()
            {
                ulong counter = 0;
                ulong[] array2 = new ulong[count];
                count = count * 2;
                foreach (var item in array)
                {
                    foreach (var v in item)
                    {                      
                        array2[counter] = v;
                        counter++;
                    }
                    
                }
              
                array = new List<ulong>[count];
                for (ulong i = 0; i < count; i++)
                {
                    array[i] = (new List<ulong>(10));
                }
                for (ulong i = 0; i < count / 2; i++)
                {
                    inserted--;
                    insert(array2[i]);
                }
                p = 18361375334787046687;
                a = generateA();
                b = generateB();
            }
            public void print()
            {
                ulong count1 = 0;
                ulong count2 = 0;
                Console.WriteLine();
                Console.WriteLine("Values in hashtable are :");
                Console.WriteLine();
                foreach (var item in array)
                {
                    foreach (var v in item)
                    {
                        if(count1>0)
                        {
                            count2++;
                        }
                        Console.Write(v+"-> ");
                        count1++;
                    }
                    count1 = 0;
                   Console.WriteLine();
                    
                }
                Console.WriteLine("No. of Collision = "+count2);
            }
            static ulong generateA()
            {
                ulong p = 18361375334787046697;
                ulong uRange = (ulong)(p - 1);
                Random random1 = new Random();
                ulong ulongRand;
                do
                {
                    byte[] buf = new byte[8];
                    random1.NextBytes(buf);
                    ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
                } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

                ulong a = (ulong)(ulongRand % uRange) + 1;
                return a;
            }
            static ulong generateB()
            {
                ulong p = 18361375334787046697;
                ulong uRange = (ulong)(p - 1);
                Random random1 = new Random();
                ulong ulongRand;
                do
                {
                    byte[] buf = new byte[8];
                    random1.NextBytes(buf);
                    ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
                } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

                ulong b = (ulong)(ulongRand % uRange) + 1;
                return b;
            }

        }

        static void Main(string[] args)
        {
            hashing h = new hashing();
            List<ulong> list = new List<ulong>();
            list = h.generateRandom(3000);


        


            Random random = new Random();

            foreach (var i in list)
            {
                
                int value = random.Next(1, 3);
                switch (value)
                {
                    case 1:
                        h.insert(i);
                        break;
                    case 2:
                        h.Delete(i);
                        break;
                    case 3:
                        h.search();
                        break ;
                }
                // h.insert(i);
            }
            h.print();
        }
    }
}













