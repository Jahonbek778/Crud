using System;

namespace Crud
{
    public class Model
    {
        public Guid Id { get; set; } = new Guid();

        public string ProductName { get; set; }

        public long Price { get; set; }
    }
}
