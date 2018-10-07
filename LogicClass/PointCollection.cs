using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LogicClass
{
    public static class MyPointCollection
    {
        public static List<Point> collection;
        static MyPointCollection()
        {
            collection = new List<Point>();
        }
        public static void addPoint(Point p)
        {
            collection.Add(p);
        }
    }
}
