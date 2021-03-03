using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CarImage: IEntity
    {
        public int Id { get; set; }
        public string ImagePath { get; set; } = "default.jpg";
        public DateTime Date { get; set; } = DateTime.Now;

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
