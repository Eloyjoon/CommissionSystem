using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Data.Sepidar
{
    [Table("FiscalYear", Schema = "FMK")]
    public class FiscalYear
    {
        [Column("FiscalYearID")]
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
    }
}
