﻿using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DataBase
{
    public class Service : IService<Car>
    {
        private readonly ICrudProvider<Car> _crudProvider;

        public Service(ICrudProvider<Car> crudProvider)
        {
            _crudProvider = crudProvider;
            

        }

        public void Add(Car item)
        {
            //validacja
            // sprawdzenie czy nie ma juz w bazie

            _crudProvider.GetCrud().Add(item); //zapis do bazy

        }
    }
}
