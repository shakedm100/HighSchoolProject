using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBusyModels;

namespace EasyBusyViewModel
{
    public class WorkerClientDB : BaseDB
    {
        public WorkerClientDB()
        {

        }

        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            WorkerClient workerClient = entity as WorkerClient;
            command.CommandText = string.Format("INSERT INTO WorkerToClient (ClientID, WorkerID, ContactDate) VALUES (@ClientID, @WorkerID, @ContactDate)");

            command.Parameters.Add(new OleDbParameter("@ClientID", workerClient.ClientID));
            command.Parameters.Add(new OleDbParameter("@WorkerID", workerClient.WorkerID));
            command.Parameters.Add(new OleDbParameter("@ContactDate", workerClient.ContactDate));
        }

        protected override void CreateDeleteSQL(Base entity, OleDbCommand command)
        {
            WorkerClient workerClient = entity as WorkerClient;
            command.CommandText = string.Format("DELETE FROM WorkerToClient WHERE (WorkerID = @WorkerID) AND (ClientID = @ClientID)");

            command.Parameters.Add(new OleDbParameter("@ClientID", workerClient.ClientID));
            command.Parameters.Add(new OleDbParameter("@WorkerID", workerClient.WorkerID));
        }

        //Most likely won't be used
        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            WorkerClient workerClient = entity as WorkerClient;
            command.CommandText = string.Format("UPDATE WorkerToClient SET WorkerID = @WorkerID, ClientID = @ClientID, ContactDate = @ContactDate WHERE (ID = @ID)");

            command.Parameters.Add(new OleDbParameter("@ClientID", workerClient.ClientID));
            command.Parameters.Add(new OleDbParameter("@WorkerID", workerClient.WorkerID));
            command.Parameters.Add(new OleDbParameter("@ContactDate", workerClient.ContactDate));
            command.Parameters.Add(new OleDbParameter("@ID", workerClient.ID));
        }

        public override void Insert(Base entity)
        {
            WorkerClient workerClient = entity as WorkerClient;
            if (workerClient != null)
            {
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
            WorkerClient workerClient = entity as WorkerClient;
            if (workerClient != null)
            {
                inserted.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        public override void Delete(Base entity)
        {
            WorkerClient workerClient = entity as WorkerClient;
            if (workerClient != null)
            {
                inserted.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
            }
        }

        //Useless
        protected override Base CreateModel(Base entity)
        {
            throw new NotImplementedException();
        }

        protected override Base newEntity()
        {
            return new WorkerClient() as Base;
        }
    }
}
