using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            _id = Guid.NewGuid().ToString();
        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    _id = Guid.NewGuid().ToString();
                else
                    _id = value;
            }
        }

        private string _id;
    }
}