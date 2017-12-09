using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBusyModels;

namespace EasyBusyViewModel
{
    public class CityDB : BaseDB
    {
        static private CityList list = null;

        public CityList SelectAll()
        {
            command.CommandText = "SELECT * FROM CityTable";
            list = new CityList(Select());
            return list;
        }

        public static City SelectByName(String name)
        {
            if (list == null)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }

            City city = list.Find(item => item.Name == name);
            return city;
        }

        public static City SelectByID(int id)
        {
            if(list == null)
            {
                CityDB db = new CityDB();
                list = db.SelectAll();
            }

            City city = list.Find(item => item.ID == id);
            return city;
        }

        protected override Base CreateModel(Base entity)
        {
            City city = entity as City;
            city.ID = (int)reader["ID"];
            city.Name = reader["City"].ToString();
            return city;
        }

        protected override Base newEntity()
        {
            return new City() as Base;
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
