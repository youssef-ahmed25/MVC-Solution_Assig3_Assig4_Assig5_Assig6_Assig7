﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DataAccess.model
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy{ get; set; }

        public DateTime? CreatedOn { get; set; }

        public int LastModifiedBy { get; set; }

        public DateTime LastModifiedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
