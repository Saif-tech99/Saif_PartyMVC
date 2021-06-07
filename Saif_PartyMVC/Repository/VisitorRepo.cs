using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Saif_PartyMVC.Models;

namespace test.Repository
{
    public class VisitorRepo
    {
        private static List<Visitor> _lsit = new List<Visitor>();

        public List<Visitor> List
        {
            get { return _lsit; }
        }

        public List<Visitor> GetVisitors(Visitor visitor)
        {
            return VisitorsList(visitor);
        }

        public Visitor Add(Visitor visitor)
        {
            _lsit.Add(visitor);
            return visitor;
        }

        public List<Visitor> VisitorsList(Visitor visitor)
        {
            _lsit.Add(visitor);
            return _lsit;
        }
    }
}
