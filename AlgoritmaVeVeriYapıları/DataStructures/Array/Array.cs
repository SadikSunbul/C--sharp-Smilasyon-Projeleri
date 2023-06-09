﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Array
{
    public class Array<T> : IEnumerable<T>, ICloneable
    {
        //IEnumerable<T> kullanmak bıze lınq sorgularını kullanmamızı saglar

        //ICloneable clonlanabılme ozellıgını ekler

        public Array() //new ledıgımızde t yı olusturcak ve count degerıne 0 degerını atar
        {
            InnerList = new T[2];
            Count = 0;
            
        }

        public Array(params T[] initial)
        {
            InnerList = new T[initial.Length];
            Count = 0;
            foreach (var item in initial)
            {
                Add(item); //Altakı metotdu cagırdık 
            }
        }
        public Array(IEnumerable<T> collection) //IEnumerable<T> yı kullanan lar gelir buraya 
            //BUraya arraylıst gelemez cunku o tıp korumalı degıldır 
        {
                InnerList = new T[collection.ToArray().Length]; 
            Count = 0;
            foreach(var item in collection)
            {
                Add (item);
            }
        }

        public void Add(T item)
        {
            if (InnerList.Length == Count)
            {
                DoubleArray();
            }
            InnerList[Count] = item;
            Count++;
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new Exception("dızı bos silme işlemi yapılamaz");
            }

            if (InnerList.Length / 4 == Count)
            {
                halfArray();  //dızının boyutu yarıya iner
            }

            var temp = InnerList[Count - 1];
            if (Count > 0)
            {
                Count--;
            }
            return temp;
        }

        private void halfArray()
        {
            if (InnerList.Length > 2)
            {
                var temp = new T[InnerList.Length / 2];
                System.Array.Copy(InnerList, temp, InnerList.Length / 4);
                InnerList = temp;
            }
        }

        private void DoubleArray() //dizi boyutunu artırdık 
        {
            var temp = new T[InnerList.Length * 2];
            //for (int i = 0; i < InnerList.Length; i++)
            //{
            //    temp[i] = InnerList[i]; 
            //} bunun yerıne sudaha ıyı olur
            System.Array.Copy(InnerList, temp, InnerList.Length);
            InnerList = temp; //listenin aderesini değiştirdik gibi
        }

        private T[] InnerList;

        public int Count { get; private set; }

        public int Capasity => InnerList.Length;

        public object Clone() 
        {
            // return this.MemberwiseClone(); 

            /*
             Shallow copy: Referans aktarımıdır , yani  A nin referansını B ye aktarırsınız B dekı degısıklık A yı etkıler
             Deep copy: normal degıskenlerın kopyalanmasıdır verıu artısı olur burada int a=5; int b=a; dersek burada verı artısı olur 

            şimdi burada this.MemberwiseClone(); metodu Shallow veyahutta deep copy diyemeyiz çünkü kullanıldıgı yere bakmak gerekir
            this.MemberwiseClone(); Çalışma mantığı :bunu kullandıgımız sınıfata bır referans tutabılecek bır degısken va ıse burası yenı bır nesne uretır lakin oradaki referans degerlerini refere eder modelliyelim

            A clası[
            int a;
            string b;
            Myclas cls;
            
            clone()
            {
            return this.MemberwiseClone();
            }

            ]

            A a= new ();
            A b=a.clone();

            burada a ile b ayrı nesnelerdir ama içerisindeki cls lerin referans ettıkelrı yerler aynıdır yanı burada Shallow copy yapılmıstır ama burada yenı bır nesen olusturul dugu ıcın de deep copy yapılmıstır yanı a.b="sadık"; dersem b.b degerı degısmez ama a.cls.deger="safasg" yaparsam b.cls.deger de degismis olur

             */

            //Manuel olarak yaptık buarada
            var arr = new Array<T>(); 
            
            
            foreach (var item in this)
            {
                arr.Add(item);
            }
            return arr;
        }

        //foreach kullanmamızı linq kullanmamızı saglar
        public IEnumerator<T> GetEnumerator()
        {
            //return InnerList.Select(x=>x).GetEnumerator();
            return InnerList.Take(Count).GetEnumerator(); //bosları donmez
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}
