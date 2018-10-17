using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LogicClass;
using ClassLibrary;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

namespace Serialization
{
    public class Serialization
    {
        public void saveShapes(string path,ObservableCollection<PolygonShape> polygonShapes)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(polygonShapes.GetType(),new Type[] { typeof(PolygonShape)});
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                xmlSerializer.Serialize(fs, polygonShapes);
            }
        }
        public ObservableCollection<PolygonShape> openShapes(string path)
        {
            ObservableCollection<PolygonShape> polygons = new ObservableCollection<PolygonShape>();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<PolygonShape>),new Type[] { typeof(PolygonShape)});

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                polygons = (ObservableCollection<PolygonShape>)xmlSerializer.Deserialize(fs);
            }
            return polygons;
        }
    }
}
