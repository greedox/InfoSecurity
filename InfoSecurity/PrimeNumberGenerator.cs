﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSecurity
{
    class PrimeNumberGenerator
    {
        public List<uint> SieveEratosthenes(uint n)
        {
            var numbers = new List<uint>();
            //заполнение списка числами от 2 до n-1
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    //удаляем кратные числа из списка
                    numbers.Remove(numbers[i] * j);
                }
            }

            return numbers;
        }
        
    }
}
