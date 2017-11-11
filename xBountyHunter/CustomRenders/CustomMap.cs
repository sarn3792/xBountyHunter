using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace xBountyHunter.CustomRenders
{
    public class CustomMap : Map
    {
        public CustomMap(MapSpan span)
        {
            new Map(span);
        }

        public MapCircle Circle { get; set; }
    }
}
