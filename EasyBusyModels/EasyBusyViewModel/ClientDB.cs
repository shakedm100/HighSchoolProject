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
    public class ClientDB : PeopleDB
    {

        public ClientDB() : base()
        {
            
        }

        public ClientList SelectAll()
        {
            command.CommandText = "SELECT *, PeopleTable.Id as ID  FROM (ClientTable INNER JOIN PeopleTable ON ClientTable.ID = PeopleTable.ID)";
            ClientList clientList = new ClientList(base.Select());
            return clientList;
        }

        public Client SelectByName(String username, String password)
        {
            command.CommandText = string.Format("SELECT *, PeopleTable.Id as ID FROM(ClientTable INNER JOIN PeopleTable ON ClientTable.ID = PeopleTable.ID) WHERE(PeopleTable.UserName = @Username) AND (PeopleTable.Password = @Password)");
            command.Parameters.Add(new OleDbParameter("@Username", username));
            command.Parameters.Add(new OleDbParameter("@Password", password));
            List<Base> clientList = base.Select();
            if (clientList.Count == 1)
                return clientList[0] as Client;
            return null;
        } 

        public override void Delete(Base entity)
        {
            Client client = entity as Client;
            if (client != null)
            {
                updated.Add(new ChangeEntity(base.CreateDeleteSQL, entity));
                updated.Add(new ChangeEntity(this.CreateDeleteSQL, entity));
            }
        }

        public override void Insert(Base entity)
        {
            Client client = entity as Client;
            if (client != null)
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
            Client client = entity as Client;
            if (client != null)
            {
                updated.Add(new ChangeEntity(base.CreateUpdateSQL, entity));
                updated.Add(new ChangeEntity(this.CreateUpdateSQL, entity));
            }
        }

        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            Client client = entity as Client;
            StringBuilder sql = new StringBuilder();
            if (client != null)
            {
                command.CommandText = "INSERT INTO ClientTable (ID, Address, CreditcardNumber) VALUES (@ID, @Address, @CreditcardNumber)";
                command.Parameters.Add(new OleDbParameter("@ID", client.ID));
                command.Parameters.Add(new OleDbParameter("@Address", client.Address));
                command.Parameters.Add(new OleDbParameter("@CreditcardNumber", client.CreditcardNumber));
            }
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            Client client = entity as Client;
            command.CommandText = "UPDATE ClientTable SET Address = @Address, CreditcardNumber = @CreditcardNumber WHERE (ID = @ID)";
            command.Parameters.Add(new OleDbParameter("@Address", client.Address));
            command.Parameters.Add(new OleDbParameter("@CreditcardNumber", client.CreditcardNumber));
            command.Parameters.Add(new OleDbParameter("@ID", client.ID));
        }

        protected override void CreateDeleteSQL(Base entity, OleDbCommand command)
        {
            Client client = entity as Client;
            command.CommandText = "DELETE FROM ClientTable WHERE (ClientTable.ID = @ID)";
            command.Parameters.Add(new OleDbParameter("@ID", client.ID));
        }

        public Client SelectByID(int id)
        {
            command.CommandText = String.Format("SELECT * FROM (ClientTable INNER JOIN PeopleTable ON ClientTable.ID = PeopleTable.ID) WHERE ID = @ID");
            command.Parameters.Add(new OleDbParameter("@ID", id));
            List<Base> clientList = base.Select();
            if (clientList.Count == 1)
                return clientList[0] as Client;
            return null;
        }

        protected override Base newEntity()
        {
            return new Client() as Base;
        }

        protected override Base CreateModel(Base entity)
        {
            Client client = entity as Client;
            base.CreateModel(client);
            client.Address = reader["Address"].ToString();
            client.CreditcardNumber = reader["CreditcardNumber"].ToString();
            return client; //(#Sahar) shukad the  king;
        }
    }
}
