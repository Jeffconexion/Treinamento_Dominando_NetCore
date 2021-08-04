using System;

namespace DevTraining.Business.Models
{
    public class Entity
    {
        public Guid Id { set; get; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
