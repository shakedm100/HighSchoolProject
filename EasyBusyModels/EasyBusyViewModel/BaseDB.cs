using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

using EasyBusyModels;

namespace EasyBusyViewModel
{
    public abstract class BaseDB
    {
        private static String connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        //רשימה ל-insert
        protected static List<ChangeEntity> inserted = new List<ChangeEntity>();
        //רשימה לעדכון ולמחיקה
        protected static List<ChangeEntity> updated = new List<ChangeEntity>();

        protected abstract Base newEntity();
        protected abstract Base CreateModel(Base entity);

        protected abstract void CreateInsertSQL(Base entity, OleDbCommand command);
        protected abstract void CreateUpdateSQL(Base entity, OleDbCommand command);
        protected abstract void CreateDeleteSQL(Base entity, OleDbCommand command);


        public BaseDB()
        {

            //connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\shake\source\repos\EasyBusyModels\EasyBusyViewModel\App_Data\EasyBusy.accdb;Persist Security Info=True";
            string s1 = "";
            //  string s = Environment.CurrentDirectory;  // שרץ exe-מקבל את כתובת ה
            String[] arguments = Environment.GetCommandLineArgs();
            string s;
            if (arguments.Length == 1) // direct execution
            { s = arguments[0]; }
            else  // service execution
            {
                s = arguments[1];
                s = s.Replace("/service:", "");  // remove /service: from the begining of the command line
            }
            string[] ss = s.Split('\\');   // פירוק המחרוזת למערך (ע"פ / שמפריד

            int x = ss.Length - 4;  //הורדתי 3 תיקיות מהסוף
            ss[x] = "EasyBusyViewModel";   // ....שיניתי את התיקיה האחרונה ל
            Array.Resize(ref ss, x + 3);  // תיקון של אורך המערך, לאורך העכשווי
            ss[x + 1] = "App_Data";
            ss[x + 2] = "EasyBusy.accdb";
            s1 = String.Join("\\", ss);  // חיבור מחדש של המערך - עם / מפריד
            //string s = Environment.CurrentDirectory;  // שרץ exe-מקבל את כתובת ה
            //string[] ss = s.Split('\\');   // פירוק המחרוזת למערך (ע"פ / שמפריד

            //int x = ss.Length - 3;  //הורדתי 3 תיקיות מהסוף
            //ss[x] = "EasyBusyViewModel";   // ....שיניתי את התיקיה האחרונה ל
            //Array.Resize(ref ss, x + 1);  // תיקון של אורך המערך, לאורך העכשווי

            //string s1 = String.Join("\\", ss);  // חיבור מחדש של המערך - עם / מפריד
            //connectionString = s1;

            //Problem is in the connection String
            //connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=App_Data\EasyBusy.accdb;Persist Security Info=True";
            //@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=App_Data\EasyBusy.accdb;Persist Security Info=True";
            connectionString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=True", s1);

            //@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=App_Data\EasyBusy.accdb;Persist Security Info=True";
            connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
        }

        public virtual void Insert(Base entity)
        {
            Base reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));
        }

        public virtual void Update(Base entity)
        {
            Base reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                inserted.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
        }

        public virtual void Delete(Base entity)
        {
            Base reqEntity = this.newEntity();
            if (entity != null && entity.GetType() == reqEntity.GetType())
                inserted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
        }

        protected List<Base> Select()
        {
            List<Base> list = new List<Base>();
            try
            {
                command.Connection = connection;
                connection.Open();
                this.reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Base entity = newEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            { }
            finally
            {
                if (reader != null)
                    reader.Close();
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }

        public static int SaveChanges()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbTransaction trans = null;

            int records = 0;
            try
            {
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                connection.Open();

                 trans = connection.BeginTransaction();
                
                foreach(var item in inserted)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    command.Transaction = trans;
                    records += command.ExecuteNonQuery();

                    command.CommandText = "Select @@Identity"; //Get Last ID the has been created
                    item.Entity.ID = (int)command.ExecuteScalar();
                }

                foreach(var item in updated)
                {
                    command.Parameters.Clear();
                    item.CreateSql(item.Entity, command);
                    command.Transaction = trans;
                    records += command.ExecuteNonQuery();
                }

                trans.Commit();

            }
            catch(Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Close();
            }

            return records;
        }
    }
}
