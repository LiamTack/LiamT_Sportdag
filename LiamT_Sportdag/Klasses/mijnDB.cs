using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;


namespace LiamT_Sportdag
{
    public class mijnDB
    {
        //velden
        static string _connectiePad = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\Documenten\_ICT\Software\_Databanken\Oof Normalisatie\Sportdag.accdb";
        OleDbConnection _conn = new OleDbConnection(_connectiePad);

        //properties

        //functies en methoden
        public List<Leerling> VraagLlnOp()
        {
            List<Leerling> antwoord = new List<Leerling>();

            string sql = "SELECT * FROM Leerling ";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0, idPakket = 0;
            String naam = "";

            _conn.Open();

            while(mijnReader.Read())
            {
                id = Convert.ToInt32(mijnReader["Id"]);
                naam = Convert.ToString(mijnReader["Naam"]);
                idPakket = Convert.ToInt32(mijnReader["IdPakket"]);

                Leerling nieuweLeerling = new Leerling(id, naam, idPakket);
                antwoord.Add(nieuweLeerling);

            }

            _conn.Close();

            return antwoord;
        }

        public List<pakket> VraagPakkettenOp()
        {
            List<pakket> antwoord = new List<pakket>();

            string sql = "SELECT * FROM Pakket";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0;
            string naam = "";
            List<Leerling> listLeerling = new List<Leerling>();

            _conn.Open();

            while (mijnReader.Read())
            {
                id = Convert.ToInt32(mijnReader["Id"]);
                naam = Convert.ToString(mijnReader["Naam"]);

                listLeerling = ZoekLlnVanPakket(id);
                pakket nieuwePakket = new pakket(id, naam, listLeerling);
                antwoord.Add(nieuwePakket);
            }

            _conn.Close();

            return antwoord;
        }

        public List<Leerling> ZoekLlnVanPakket(int ontvId)
        {
            List<Leerling> antwoord = new List<Leerling>();

            string sql = "SELECT * FROM Leerling WHERE IdPakket = " + Convert.ToInt32(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);
            OleDbDataReader mijnReader = mijnCommando.ExecuteReader();

            int id = 0, idPakket = 0;
            String naam = "";

            _conn.Open();

            while (mijnReader.Read())
            {
                id = Convert.ToInt32(mijnReader["Id"]);
                naam = Convert.ToString(mijnReader["Naam"]);
                idPakket = Convert.ToInt32(mijnReader["IdPakket"]);
            

                Leerling nieuweLeerling = new Leerling(id, naam, idPakket);
                antwoord.Add(nieuweLeerling);
            }
            _conn.Close();

            return antwoord;
        }

        public void PakketToevoegen(string ontvNaam)
        {
            string sql = "INSERT INTO Pakket (Naam) VALUES ('" + ontvNaam + "')";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingToevoegen(string ontvNaam)
        {
            string sql = "INSERT INTO Leerling (Naam) VALUES ('" + ontvNaam + "')";
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void PakketVeranderen(int ontvId, string ontvNaam)
        {
            string sql = "UPDATE Pakket SET naam = '" + ontvNaam + "' WHERE Id = "+ Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingVeranderen(int ontvId, string ontvNaam)
        {
            string sql = "UPDATE Leerling SET naam = '" + ontvNaam + "' WHERE Id = " + Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void PakketVerwijderen(int ontvId)
        {
            string sql = "DELETE FROM Pakket WHERE Id = " + Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void LeerlingVerwijderen(int ontvId)
        {
            string sql = "DELETE FROM Leerling WHERE Id = " + Convert.ToString(ontvId);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void KeuzeToevoegen(int ontvIdLln, int ontvIdPakket)
        {
            string sql = "INSERT INTO Leerling (IdPakket) VALUES (" + Convert.ToInt32(ontvIdPakket) + ") WHERE Id = "+ Convert.ToString(ontvIdLln);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        public void KeuzeVeranderen(int ontvIdLln, int ontvIdPakket)
        {
            string sql = "UPDATE Leerling SET IdPakket = '" + Convert.ToString(ontvIdPakket) + "' WHERE Id = " + Convert.ToString(ontvIdLln);
            OleDbCommand mijnCommando = new OleDbCommand(sql, _conn);

            _conn.Open();

            mijnCommando.ExecuteNonQuery();

            _conn.Close();
        }

        //constructors
        public mijnDB()
        {

        }
    }
}
