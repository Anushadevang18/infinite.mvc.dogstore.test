using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace infinite.mvc.dogstore.test.Models
{
    public class DogStore
    {
        public int Id { get; set; }
        public string PetName { get; set; }
        public string Description { get; set; }
       
        public double  Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Breed Breed { get; set; }
         //foriegn key
         public int BreedId { get; set; }
    }
}