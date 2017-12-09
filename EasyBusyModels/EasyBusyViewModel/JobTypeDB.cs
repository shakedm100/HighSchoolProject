using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBusyModels;


namespace EasyBusyViewModel
{
    public class JobTypeDB : BaseDB
    { 
        public JobTypeDB() : base()
        {

        }

        static private JobTypeList list = null;

        public JobTypeList SelectAll()
        {
            command.CommandText = "SELECT * FROM JobTypeTable";
            list = new JobTypeList(Select());
            return list;
        }

        public static JobType SelectByID(String job)
        {
            if (list == null)
            {
                JobTypeDB db = new JobTypeDB();
                list = db.SelectAll();
            }

            JobType jobType = list.Find(item => item.Job == job);
            return jobType;
        }

        public static JobType SelectByID(int id)
        {
            if (list == null)
            {
                JobTypeDB db = new JobTypeDB();
                list = db.SelectAll();
            }

            JobType job = list.Find(item => item.ID == id);
            return job;
        }

        protected override Base CreateModel(Base entity)
        {
            JobType job = entity as JobType;
            job.ID = (int)reader["ID"];
            job.Job = reader["Job"].ToString();
            return job;
        }

        protected override Base newEntity()
        {
            return new JobType() as Base;
        }

        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            throw new NotImplementedException();
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            throw new NotImplementedException();
        }

        protected override void CreateDeleteSQL(Base entity, OleDbCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
