using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBusyModels;

namespace EasyBusyViewModel
{
    public class KidometDB : BaseDB
    {
        static private KidometList list = null;

        public KidometList SelectAll()
        {
            command.CommandText = "SELECT * FROM KidometTable";
            list = new KidometList(Select());
            return list;
        }

        public static Kidomet SelectByName(String areaCode)
        {
            if (list == null)
            {
                KidometDB db = new KidometDB();
                list = db.SelectAll();
            }

            Kidomet kidomet = list.Find(item => item.AreaCode == areaCode);
            return kidomet;
        }

        public static Kidomet SelectByID(int id)
        {
            if (list == null)
            {
                KidometDB db = new KidometDB();
                list = db.SelectAll();
            }

            Kidomet kidomet = list.Find(item => item.ID == id);
            return kidomet;
        }

        protected override Base CreateModel(Base entity)
        {
            Kidomet kidomet = entity as Kidomet;
            kidomet.ID = (int)reader["ID"];
            kidomet.AreaCode = reader["Kidomet"].ToString();
            return kidomet;
        }

        protected override Base newEntity()
        {
            return new Kidomet() as Base;
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
