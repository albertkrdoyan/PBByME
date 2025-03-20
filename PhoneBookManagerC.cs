using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace PBByME_V1._0
{
    class PhoneBookC
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                string fullname = "";

                if (FirstName != "")
                    fullname += $"{FirstName}";
                if (MiddleName != "")
                    fullname += $" {MiddleName}";
                if (LastName != "")
                    fullname += $" {LastName}";

                return fullname;
            }
        }

        public string Info
        {
            get
            {
                string info = $"ID: {ID}, Name: [";

                if (FirstName != "")
                    info += $" {FirstName}";
                if (MiddleName != "")
                    info += $" {MiddleName}";
                if (LastName != "")
                    info += $" {LastName}";

                info += $" ], Phone: {PhoneNumber}";

                return info;
            }
        }

        public PhoneBookC() { }

        public PhoneBookC(int _ID, string _FirstName, string _MiddleName, string _LastName, string _PhoneNumber)
        {
            this.ID = _ID;
            this.FirstName = _FirstName;
            this.MiddleName = _MiddleName;
            this.LastName = _LastName;
            this.PhoneNumber = _PhoneNumber;
        }
    }

    class DB
    {
        private SQLiteConnection sql_conn;
        private bool is_conn_open;
        protected int last_user_index;

        public DB()
        {
            is_conn_open = false;
            last_user_index = -1;

            CreateConnection();
            CreateTable();
        }

        protected void CloseDB()
        {
            if (!is_conn_open) return;
            //MessageBox.Show("HEllo");
            is_conn_open = false;
            sql_conn.Close();
        }

        private void CreateConnection()
        {
            //if (is_conn_open) return;

            sql_conn = new SQLiteConnection(
                "Data Source=phonebookdb.db; Version = 3; New = True; Compress = True; "
            );

            try
            {
                sql_conn.Open();
                is_conn_open = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
                is_conn_open = false;
            }
        }

        private void CreateTable()
        {
            if (!is_conn_open) return;

            SQLiteCommand sqlite_cmd;

            string Createsql = "CREATE TABLE IF NOT EXISTS users(" +
                    "id INTEGER PRIMARY KEY AUTOINCREMENT," +
                    "firstName VARCHAR(30)," +
                    "middleName VARCHAR(30)," +
                    "lastName VARCHAR(30)," +
                    "phoneNumber VARCHAR(25) UNIQUE NOT NULL" +
                ")";

            sqlite_cmd = sql_conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;

            sqlite_cmd.ExecuteNonQuery();
        }

        protected void InsertDataToDB(string d1, string d2, string d3, string d4)
        {
            if (!is_conn_open) return;

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sql_conn.CreateCommand();

            sqlite_cmd.CommandText = "INSERT INTO users ('firstName', 'middleName', 'lastName', 'phoneNumber')" +
                $" VALUES('{d1}', '{d2}', '{d3}', '{d4}'); ";

            sqlite_cmd.ExecuteNonQuery();
        }

        protected void EditDataInDB(int id, string d1, string d2, string d3, string d4)
        {
            if (!is_conn_open) return;

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sql_conn.CreateCommand();

            sqlite_cmd.CommandText = "UPDATE users " +
                $"SET 'firstName' = '{d1}', 'middleName' = '{d2}', 'lastName' = '{d3}', 'phoneNumber' = '{d4}' " +
                $"WHERE id = {id};";

            sqlite_cmd.ExecuteNonQuery();
        }

        protected void RemoveDataFromDB(int id)
        {
            if (!is_conn_open) return;

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sql_conn.CreateCommand();

            sqlite_cmd.CommandText = $"DELETE FROM users WHERE id='{id}';";

            sqlite_cmd.ExecuteNonQuery();
        }

        protected void ReadData()
        {
            if (!is_conn_open) return;

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sql_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM users";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            string readdata;
            while (sqlite_datareader.Read())
            {
                readdata = $"ID: {sqlite_datareader.GetInt32(0)}, Name:";

                for (int i = 1; i < 4; ++i)
                {
                    if (sqlite_datareader.GetString(i) != "")
                        readdata += $" {sqlite_datareader.GetString(i)}";
                }

                readdata += $", Phone: {sqlite_datareader.GetString(4)}";

                MessageBox.Show(readdata);
                //Console.WriteLine(readdata);
            }
        }

        protected void FillDataInList(ref Dictionary<int, PhoneBookC> list)
        {
            if (!is_conn_open) return;

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sql_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM users";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            while (sqlite_datareader.Read())
            {
                list.Add(sqlite_datareader.GetInt32(0), new PhoneBookC
                {
                    ID = sqlite_datareader.GetInt32(0),
                    FirstName = sqlite_datareader.GetString(1),
                    MiddleName = sqlite_datareader.GetString(2),
                    LastName = sqlite_datareader.GetString(3),
                    PhoneNumber = sqlite_datareader.GetString(4)
                });

                last_user_index = sqlite_datareader.GetInt32(0);
            }
        }
    }

    class PhoneBookSqlManager : DB
    {
        private readonly Dictionary<int, PhoneBookC> listP;

        public int LastID
        {
            get
            {
                return this.last_user_index;
            }
        }

        public Dictionary<int, PhoneBookC> ListP
        {
            get
            {
                return listP;
            }
        }

        public PhoneBookSqlManager()
        {
            listP = new Dictionary<int, PhoneBookC>();
            last_user_index = -1;
            // db is connecting automaitcally

            this.FillDataInList(ref listP);
        }

        public void AddUser(string fname, string mname, string lname, string pnumber)
        {
            this.InsertDataToDB(fname, mname, lname, pnumber);
            listP.Add(++last_user_index, new PhoneBookC(last_user_index, fname, mname, lname, pnumber));
        }

        public void EditUser(int id, string fname, string mname, string lname, string pnumber)
        {
            listP[id].FirstName = fname;
            listP[id].MiddleName = mname;
            listP[id].LastName = lname;
            listP[id].PhoneNumber = pnumber;

            this.EditDataInDB(id, fname, mname, lname, pnumber);
        }

        public void PrintInfo()
        {
            //for (int i = 0; i < list.Count; ++i) ;
                //Console.WriteLine(list[i].Info);
        }

        public void UpdateDataGrid(ref DataGridView dgv)
        {
            dgv.Rows.Clear();

            foreach (KeyValuePair<int, PhoneBookC> pbc in listP)
            {
                dgv.Rows.Add(pbc.Value.ID.ToString(), pbc.Value.FullName, pbc.Value.PhoneNumber);
            }
        }

        public void PCloseDB()
        {
            CloseDB();
        }

        public void RemoveContact(int id)
        {
            //MessageBox.Show(listP[id].FullName);
            this.RemoveDataFromDB(id);
            listP.Remove(id);
        }
    }
}
