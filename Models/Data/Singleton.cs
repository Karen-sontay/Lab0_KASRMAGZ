using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab0_KASRMAGZ.Models.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<Customers> CustomersList;
        private Singleton()
        {
            CustomersList = new List<Customers>();
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
