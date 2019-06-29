using System;
using System.Collections.Generic;
using System.Text;
using _03BarracksFactory.Contracts;

namespace P03_BarraksWars.Commands
{
    public abstract class Command : IExecutable
    {
        protected Command(string[] data, IRepository repository, IUnitFactory unitFactory)
        {
            this.Repository = repository;
            this.UnitFactory = unitFactory;
            this.Data = data;
        }

        public IRepository Repository { get; set; }

        public IUnitFactory UnitFactory { get; set; }

        public string[] Data { get; set; }

        public abstract string Execute();

    }
}
