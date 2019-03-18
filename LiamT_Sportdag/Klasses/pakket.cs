using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiamT_Sportdag
{
    public class pakket
    {
        //velden
        int _id = 0;
        string _naam = "";
        List<Leerling> _leerlingen = new List<Leerling>();

        //properties
        public int PropId
        {
            get { return _id; }

        }
        public string PropNaam
        {
            get { return _naam; }
            set { _naam = value; }
        }

        public List<Leerling> PropLeerlingen
        {
            get { return _leerlingen; }
            set { _leerlingen = value; }
        }

        //functies en methoden

        //constructors
        public pakket(int id, string naam, List<Leerling> leerlingen)
        {
            _id = id;
            _naam = naam;
            _leerlingen = leerlingen;
           
        }

    }
}
