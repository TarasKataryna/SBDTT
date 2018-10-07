using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LogicClass
{
    public static class PointEllipseColl
    {
        public static List<Ellipse> collection;
        static PointEllipseColl()
        {
            collection = new List<Ellipse>();
        }
    }
}
