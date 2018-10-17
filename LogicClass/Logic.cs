using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ClassLibrary;

namespace LogicClass
{
    public class Logic
    {
        public Point marginShape;
        Point startMovePoint;

        public PolygonShape polygon { get; set; }
        public ObservableCollection<PolygonShape> polygonCollection
        {
            get;
            set;
        }
        public static int counter;
        public int ChosenIndex { get; set; } = -1;


        static Logic()
        {
            counter = 1;
        }
        public Logic()
        {
            polygon = new PolygonShape();
            polygonCollection = new ObservableCollection<PolygonShape>();
        }



        public void createAndDrawPolygon(Action act)
        {
            List<Point> points = getPoints();
            if (Math.Sqrt(Math.Pow(points[0].X - points[points.Count - 1].X, 2) + Math.Pow(points[0].Y - points[points.Count - 1].Y, 2)) <= 10 && points.Count > 2)
            {
                points.RemoveAt(points.Count - 1);
                polygon = new PolygonShape(generateName("Polygon"), points);
                polygonCollection.Add(polygon);
                act();
                removeAllPoint();
            }
        }

        public string generateName(string t)
        {
            return t + counter++.ToString();
        }

        public List<Point> getPoints()
        {
            return new List<Point>(MyPointCollection.collection);
        }

        public void removeAllPoint()
        {
            MyPointCollection.collection.RemoveAll(a => a is Point);
        }

        public Polygon createNewPolygon()
        {
            Polygon p = new Polygon();
            foreach (var item in polygon.PointList)
            {
                p.Points.Add(item);
            }
            p.Stroke = Brushes.Black;
            p.Fill = new SolidColorBrush(polygon.Color);
            p.Margin = new Thickness(polygon.Margin.X, polygon.Margin.Y, 0, 0);
            return p;
        }

        public void UnChoseShape()
        {
            if (ChosenIndex != -1)
                polygonCollection[ChosenIndex].IsChoosen = false;
            
        }
        public void ChooseShape(string str)
        {
            ClearChoose();
            ChosenIndex = polygonCollection.IndexOf(polygonCollection.Where(a => a.Name == str).First());
            polygonCollection[ChosenIndex].IsChoosen = true;
        }
        public void ClearChoose()
        {
            foreach (var item in polygonCollection)
            {
                item.IsChoosen = false;
            }
        }

        public void SetShapeMarginAndStartMovePoint(Point startMovePoint)
        {
            marginShape = polygonCollection[ChosenIndex].Margin;
            this.startMovePoint = startMovePoint;
        }

        public void MoveShape(Point mousePoint)
        {
            Point newMarginPoint = new Point(mousePoint.X - startMovePoint.X + marginShape.X, mousePoint.Y - startMovePoint.Y + marginShape.Y);
            polygonCollection[ChosenIndex].Margin = newMarginPoint;
        }


        public void setColor(Color color)
        {
            if (color != Color.FromRgb(255, 255, 255))
            {
                if (ChosenIndex != -1)
                    polygonCollection[ChosenIndex].Color = color;
            }
        }

    }

}
