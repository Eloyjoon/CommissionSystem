using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommisionSystem.WebApplication.Models.ViewModels
{
    public class ReadPolicyModel
    {
        public int PolicyID { get; set; }
        public string Title { get; set; }
        public string Name => Title.Replace(" ", "");
    }
}
