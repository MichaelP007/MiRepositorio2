using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcProyectoWeb1.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }

        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
