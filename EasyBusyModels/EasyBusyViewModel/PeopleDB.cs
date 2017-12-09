using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBusyModels;
using System.Data.OleDb;

namespace EasyBusyViewModel
{
    public class PeopleDB : BaseDB
    {

        public PeopleDB() : base()
        {

        }

        

        protected override Base CreateModel(Base entity)
        {
            People people = entity as People;
            people.ID = (int)reader["ID"];
            people.FirstName = reader["FirstName"].ToString();
            people.LastName = reader["LastName"].ToString();
            people.Username = reader["UserName"].ToString();
            people.Password = reader["Password"].ToString();
            people.Birthday = (DateTime)reader["Birthday"];
            people.Taz = reader["Taz"].ToString();
            int kidomet = (int)reader["Kidomet"];
            people.Kidomet = KidometDB.SelectByID(kidomet);
            people.PhoneNumber = reader["PhoneNumber"].ToString();
            int city = (int)reader["City"];
            people.GetSetCity = CityDB.SelectByID(city);
            return people;
        }

        protected override void CreateInsertSQL(Base entity, OleDbCommand command)
        {
            People people = entity as People;
            command.CommandText = "INSERT INTO PeopleTable " +
                "(FirstName, LastName, UserName, [Password], Birthday, Kidomet, PhoneNumber, Taz, City) VALUES (@FirstName, @LastName, @Username, @Password, @Birthday, @Kidomet, @PhoneNumber, @Taz, @City)";
            command.Parameters.Add(new OleDbParameter("@FirstName", people.FirstName));
            command.Parameters.Add(new OleDbParameter("@LastName", people.LastName));
            command.Parameters.Add(new OleDbParameter("@Username", people.Username));
            command.Parameters.Add(new OleDbParameter("@Password", people.Password));
            command.Parameters.Add(new OleDbParameter("@Birthday", people.Birthday));
            command.Parameters.Add(new OleDbParameter("@Kidomet", people.Kidomet.ID));
            command.Parameters.Add(new OleDbParameter("@PhoneNumber", people.PhoneNumber));
            command.Parameters.Add(new OleDbParameter("@Taz", people.Taz));
            command.Parameters.Add(new OleDbParameter("@City", people.GetSetCity.ID));
        }

        protected override void CreateUpdateSQL(Base entity, OleDbCommand command)
        {
            People people = entity as People;
            command.CommandText = "UPDATE PeopleTable SET FirstName = @FirstName, LastName = @LastName, UserName = @Username, [Password] = @Password, Birthday = @Birthday, Kidomet = @Kidomet, PhoneNumber = @PhoneNumber, Taz = @Taz, City = @City WHERE  (ID = @ID)";
            command.Parameters.Add(new OleDbParameter("@FirstName", people.FirstName));
            command.Parameters.Add(new OleDbParameter("@LastName", people.LastName));
            command.Parameters.Add(new OleDbParameter("@Username", people.Username));
            command.Parameters.Add(new OleDbParameter("@Password", people.Password));
            command.Parameters.Add(new OleDbParameter("@Birthday", people.Birthday));
            command.Parameters.Add(new OleDbParameter("@Kidomet", people.Kidomet.ID));
            command.Parameters.Add(new OleDbParameter("@PhoneNumber", people.PhoneNumber));
            command.Parameters.Add(new OleDbParameter("@Taz", people.Taz));
            command.Parameters.Add(new OleDbParameter("@City", people.GetSetCity.ID));
            command.Parameters.Add(new OleDbParameter("@ID", people.ID));
        }

        protected override void CreateDeleteSQL(Base entity, OleDbCommand command)
        {
            People people = entity as People;
            command.CommandText = "DELETE FROM PeopleTable WHERE (PeopleTable.ID = @ID)";
            command.Parameters.Add(new OleDbParameter("@ID", people.ID));
        }

        protected override Base newEntity()
        {
            return new People() as Base;
        }
    }
}
