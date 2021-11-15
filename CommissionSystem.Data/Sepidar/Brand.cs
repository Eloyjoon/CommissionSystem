using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.Data.Sepidar
{
    [Table("Grouping", Schema = "gnr")]
    public class Brand
    {
        [Column("GroupingID")]
        public int ID { get; set; }
        [Column("Title")]
        public string Name { get; set; }

        public string EntityType { get; set; }

    }
}
