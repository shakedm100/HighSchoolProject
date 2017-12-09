using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;

using EasyBusyModels;

namespace EasyBusyViewModel
{
    public delegate void CreateSql(Base entity, OleDbCommand command);

    public class ChangeEntity
    {
        private Base entity;
        private CreateSql createSql;

        public ChangeEntity(CreateSql createSql, Base entity)
        {
            this.CreateSql = createSql;
            this.Entity = entity;
        }

        public Base Entity
        {
            get => entity;
            set => entity = value;
        }
        public CreateSql CreateSql
        {
            get => createSql;
            set => createSql = value;
        }
    }
}
