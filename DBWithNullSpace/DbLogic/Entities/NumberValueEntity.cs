using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DbLogic.Entities
{
    public class NumberValueEntity
    {
        /// <summary>
        /// Id column
        [Key]
        public int NumberId { get; set; }

        /// <summary>
        /// Value column
        public string Value { get; set; }

    }
}
