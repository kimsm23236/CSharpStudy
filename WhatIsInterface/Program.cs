using System;

namespace WhatIsInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Yelp();
            WhatIsCollection wic = new WhatIsCollection();
            wic.CollectionDesc();
        }
    }
}