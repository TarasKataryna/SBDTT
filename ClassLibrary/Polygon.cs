using System;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;


namespace ClassLibrary
{
    public class PolygonShape : INotifyPropertyChanged
    {

        bool isChoosen;
        Color color = Color.FromArgb(0, 255, 255, 255);
        Point margin;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Point> PointList
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public bool IsChoosen
        {
            get
            {
                return isChoosen;
            }
            set
            {
                if (value != this.isChoosen)
                {
                    this.isChoosen = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public PolygonShape()
        {
        }

        public PolygonShape(string name, List<Point> pointList, bool isChose = false)
        {
            Name = name;
            IsChoosen = isChoosen;
            PointList = new List<Point>();
            foreach (var item in pointList)
            {
                PointList.Add(item);
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (value != this.color)
                {
                    this.color = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Point Margin
        {
            get
            {
                return margin;
            }
            set
            {
                if (value != this.margin)
                {
                    this.margin = value;
                    NotifyPropertyChanged();
                }
            }
        }

    }
}
