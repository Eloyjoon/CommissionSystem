using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommissionSystem.WebApplication.Models.ViewModels
{
    public class ReadBrandModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Name=> Title.Replace(" ", "");
    }
}
