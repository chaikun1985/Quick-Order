using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Quick_Order
{
    class SQLiteCreatClassProject
    {
        static private string FileName = "";
        static private string DBVersionString = CommonUsages.CurrentDBVersion;
        static private int DBVersionMajor = 0;
        static private int DBVersionMinor = 0;
        static private SQLiteCommand Cmd;
        static private SQLiteConnection Conn;
        static private string CreatString = "";

        public static void SQLiteCreatClassInit(string _fileName)
        {
            FileName = _fileName;

            DBVersionMajor = CommonUsages.GetIntegerFromString(DBVersionString);
            DBVersionMinor = CommonUsages.GetIntegerFromString(DBVersionString.Split(@".".ToCharArray())[1]);

            CreateADemoDB();
        }

        private static void CreateADemoDB()
        {
            string zSQLFile = "Data Source=" + FileName;
            System.Data.SQLite.SQLiteConnection.CreateFile(FileName);
            Cmd = new SQLiteCommand();
            Conn = new SQLiteConnection(zSQLFile);
            try
            {
                Conn.Open();
                SQLiteTransaction myTransaction = Conn.BeginTransaction();

                CreateTableVersion();
                CreateProjectTable();
                CreatePanelSettingsTable();
                //CreateFittingsTable();

                InsertDefaultValueVersion();

                myTransaction.Commit();
                myTransaction.Dispose();
                Cmd.Dispose();
                Conn.Close();
                //https://stackoverflow.com/questions/8511901/system-data-sqlite-close-not-releasing-database-file
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (Exception)
            {
                Cmd.Dispose();
                Conn.Close();
            }

        }

        private static void CreateTableVersion()
        {
            CreatString = "CREATE TABLE \"_version\" (" + "[Major] INT NOT NULL ON CONFLICT FAIL," + "[Minor] INT NOT NULL ON CONFLICT FAIL)";
            Cmd = new SQLiteCommand(CreatString, Conn);
            Cmd.ExecuteNonQuery();
        }

        private static void CreateProjectTable()
        {
            CreatString = "CREATE TABLE \"project\" (" +
                "[ID] INT64 NOT NULL ON CONFLICT FAIL, " +                
                "[SystemType] CHAR NOT NULL ON CONFLICT FAIL," +
                "[Cat] CHAR NOT NULL ON CONFLICT FAIL, " +
                "[ItemType] CHAR NOT NULL ON CONFLICT FAIL, " +
                "[Name] CHAR," +                
                "[Other] CHAR)";
            Cmd = new SQLiteCommand(CreatString, Conn);
            Cmd.ExecuteNonQuery();
        }

        private static void CreatePanelSettingsTable()
        {
            CreatString = "CREATE TABLE \"model\" (" +
                "[Model] CHAR NOT NULL ON CONFLICT FAIL," +
                "[ItemID] INT64 NOT NULL ON CONFLICT FAIL, " +
                "[Cat] CHAR NOT NULL ON CONFLICT FAIL, " +
                "[Count] INT, " +
                "[Other] CHAR)";
            Cmd = new SQLiteCommand(CreatString, Conn);
            Cmd.ExecuteNonQuery();
        }
             
        private static void InsertDefaultValueVersion()
        {
            CreatString = "INSERT INTO [_version] values(" + DBVersionMajor + "," + DBVersionMinor + ")";
            Cmd = new SQLiteCommand(CreatString, Conn);
            Cmd.ExecuteNonQuery();
        }
    }
}
