using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LogicClass;
using System.Windows.Controls.Primitives;
using System.ComponentModel;
using ClassLibrary;
using System.Collections.Specialized;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Logic logic;
        public bool isDone;
        public bool shapeIsChosen;
        public MainWindow()
        {

            InitializeComponent();
            logic = new Logic();
            isDone = false;
            shapeIsChosen = false;
            CommandBindings.Add(new CommandBinding(ApplicationCommands.New, MenuItem_Click));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, MenuItem_Click_1));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, MenuItem_Click_2));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.SaveAs, MenuItem_Click_3));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Close, closeClick));
            ShapesListMenu.ItemsSource = logic.polygonCollection;
            ContextMenuItems.ItemsSource = logic.polygonCollection;

            logic.polygonCollection.CollectionChanged += Shapes_CollectionChanged;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void colorClick(object sender, RoutedEventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            //if(colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) // ... == DialogResult.OK)
            //{
            //    something.whatToColor = new SolidColorBrush(Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B)
            //}
        }

        public void drawPolygon()
        {
            foreach (var item in PointEllipseColl.collection)
                shapeCanvas.Children.Remove(item);
            shapeCanvas.Children.Add(logic.createNewPolygon());
            PointEllipseColl.collection.RemoveAll(a => a is Ellipse);
        }

        private void Polygon_click(object sender, RoutedEventArgs e)
        {
            isDone = true;
            logic.UnChoseShape();
        }
        private void closeClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isDone && e.LeftButton == MouseButtonState.Pressed)
            {
                MyPointCollection.addPoint(Mouse.GetPosition(shapeCanvas));
                Ellipse el = new Ellipse
                {
                    Fill = Brushes.Black,
                    Height = 2,
                    Width = 2,
                    Margin = new Thickness(Mouse.GetPosition(shapeCanvas).X, Mouse.GetPosition(shapeCanvas).Y, 0, 0)
                };
                PointEllipseColl.collection.Add(el);
                shapeCanvas.Children.Add(el);
                Action act = drawPolygon;
                logic.createAndDrawPolygon(act);

            }

        }
        private void MenuItem_Shapes_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.MenuItem menuItem = sender as System.Windows.Controls.MenuItem;

            logic.ChooseShape(menuItem.Header.ToString());
            shapeCanvas.Children[logic.ChosenIndex].MouseDown += CanvasChildren_MouseDown;
            isDone = false;
        }

        private void CanvasChildren_MouseDown(object sender, MouseButtonEventArgs e)
        {
            logic.SetShapeMarginAndStartMovePoint(Mouse.GetPosition(shapeCanvas));
            shapeCanvas.MouseMove += CanvasContainer_MouseMove;
        }

        private void CanvasContainer_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                logic.MoveShape(Mouse.GetPosition(shapeCanvas));
            }
            if (e.LeftButton == MouseButtonState.Released)
            {
                shapeCanvas.MouseMove -= CanvasContainer_MouseMove;
            }
        }

        private void Shapes_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChoosen")
            {
                int strokeThickness = 1;
                if ((sender as PolygonShape).IsChoosen)
                {
                    strokeThickness = 2;
                }
                (shapeCanvas.Children[logic.ChosenIndex] as Shape).StrokeThickness = strokeThickness;
            }
            else if (e.PropertyName == "Margin")
            {
                (shapeCanvas.Children[logic.ChosenIndex] as Shape).Margin = new Thickness((sender as PolygonShape).Margin.X, (sender as PolygonShape).Margin.Y, 0, 0);
            }
            //Дописати
            else if(e.PropertyName == "Color")
            {

            }
        }

        private void Shapes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                (e.NewItems[0] as INotifyPropertyChanged).PropertyChanged += Shapes_PropertyChanged;
        }
    }
}
