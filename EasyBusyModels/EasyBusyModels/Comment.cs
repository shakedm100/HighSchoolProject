using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBusyModels
{
    public class Comment : Base
    {
        private DateTime commentDate;
        private String comment;

        public DateTime CommentDate
        {
            get => commentDate;
            set => commentDate = value;
        }
        public string CommentGetSet
        {
            get => comment;
            set => comment = value;
        }
    }
}
