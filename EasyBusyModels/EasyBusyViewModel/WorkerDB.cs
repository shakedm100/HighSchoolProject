using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;

using EasyBusyModels;

namespace EasyBusyViewModel
{
    public class WorkerDB : PeopleDB
    {

        public WorkerDB() : base()
        {

        }

        public WorkerList SelectAll()
        {
            command.CommandText = "SELECT *, PeopleTable.Id as ID  FROM (WorkerTable INNER JOIN PeopleTable ON WorkerTable.ID = PeopleTable.ID)";
            WorkerList workerList = new WorkerList(base.Select());
            return workerList;
        }

        public Worker SelectByName(String username, String password)
        {
            command.CommandText = string.Format("SELECT *, PeopleTable.Id as ID FROM(WorkerTable INNER JOIN PeopleTable ON WorkerTable.ID = PeopleTable.ID) WHERE(PeopleTable.UserName = '{0}') AND(PeopleTable.Password = '{1}')", username, password);
            List<Base> workerList = base.Select();
            if (workerList.Count == 1)
                return workerList[0] as Worker;
            return null;
        }

        public Worker SelectByID(int id)
        {
            command.CommandText = String.Format("SELECT * FROM (WorkerTable INNER JOIN PeopleTable ON WorkerTable.ID = PeopleTable.ID) WHERE ID = {0}", id);
            List<Base> workerList = base.Select();
            if (workerList.Count == 1)
                return workerList[0] as Worker;
            return null;
        }

        protected override Base newEntity()
        {
            return new Worker() as Base;
        }

        protected override Base CreateModel(Base entity)
        {
            Worker worker = entity as Worker;
            base.CreateModel(worker);
            worker.BankAccount = reader["BankAccount"].ToString();
            worker.Rating = (double)reader["Rating"];
            worker.JobType = (int)reader["JobType"];
            worker.Longtitude = (int)reader["Longtitude"];
            worker.Latitude = (int)reader["Latitude"];
            return worker; //(#Sahar) shukad the  king;
        }

        public override void Delete(Base entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                inserted.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
            }
        }

        public override void Insert(Base entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                inserted.Add(new ChangeEntity(base.CreateInsertSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateInsertSQL, entity));

                //מימוש לרבים - רבים
                //ItemOrderDB db = new ItemOrderDB();
                //foreach (ItemOrder item in order.List)
                //{
                //db.Inserted(item);
                //}
            }
        }

        public override void Update(Base entity)
        {
            Worker worker = entity as Worker;
            if (worker != null)
            {
                inserted.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                inserted.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Worker worker = entity as Worker;
            StringBuilder sql = new StringBuilder();
            if (worker != null)
            {
                sql.AppendFormat("INSERT INTO WorkerTable (ID, BankAccount, Rating, JobType, Longtitude, Latitude) VALUES (@ID, @BankAccount, @Rating, @JobType, @Longtitude, @Latitude)");
                command.Parameters.Add(new OleDbParameter("@ID", worker.ID));
                command.Parameters.Add(new OleDbParameter("@BankAccount", worker.BankAccount));
                command.Parameters.Add(new OleDbParameter("@Rating", worker.Rating));
                command.Parameters.Add(new OleDbParameter("@JobType", worker.JobType));
                command.Parameters.Add(new OleDbParameter("@Longtitude", worker.Longtitude));
                command.Parameters.Add(new OleDbParameter("@Latitude", worker.Latitude));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Worker worker = entity as Worker;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("UPDATE WorkerTable SET BankAccount = @BankAccount, Rating = @Rating, JobType = @JobType, Longtitude = @Longtitude, Latitude = @Latitude WHERE (ID = @ID)");
            command.Parameters.Add(new OleDbParameter("@BankAccount", worker.BankAccount));
            command.Parameters.Add(new OleDbParameter("@Rating", worker.Rating));
            command.Parameters.Add(new OleDbParameter("@JobType", worker.JobType));
            command.Parameters.Add(new OleDbParameter("@Longtitude", worker.Longtitude));
            command.Parameters.Add(new OleDbParameter("@Latitude", worker.Latitude));
            command.Parameters.Add(new OleDbParameter("@ID", worker.ID));

        }

        protected override void CreateDeleteSQL(Base entity, OleDbCommand command)
        {
            Worker worker = entity as Worker;
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("DELETE FROM WorkerTable WHERE WorkerTable.ID = @ID)");
            command.Parameters.Add(new OleDbParameter("@ID", worker.ID));
        }
    }
}
