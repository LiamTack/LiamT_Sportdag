using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiamT_Sportdag
{
    public class Leerling
    {
        //velden
        int _id = 0;
        String _naam = "";
        int _idPakket = 0;

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
        public int PropIdPakket
        { 
            get { return _idPakket; }
            set { _id = value; }
        }


        //functies en methoden

        //constructors
        public Leerling(int id, string naam, int idPakket)
        {
            _id = id;
            _naam = naam;
            _idPakket = idPakket;
        }
    }
}
