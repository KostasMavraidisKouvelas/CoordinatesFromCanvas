﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoordinatesFromCanvas.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemID { get; set; }


        public DateTime Time { get; set; }

        public Double x { get; set; }

        public Double y { get; set; }

        public Double Diameter { get; set; }

        [StringLength(30, ErrorMessage = "Title must be less than 30 characters")]
        public string Color {get;set;}
        

        
    }
}
