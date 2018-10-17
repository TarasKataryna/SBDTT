using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicClass;
using ClassLibrary;
using Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Task2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        PolygonShape Polygons;
        Logic logic;
        Serialization.Serialization serial;

        public UnitTest1()
        {

            serial = new Serialization.Serialization();
        }
        [TestMethod]
        public void SetColorTest()
        {
            logic = new Logic();
            logic.setColor(Colors.Blue);
        }
        [TestMethod]
        public void CreateNewPolygonWith3PointsTest()
        {
            
            logic = new Logic();
            logic.polygon.PointList = new System.Collections.Generic.List<Point>();
            logic.polygon.PointList.Add(new Point(5, -5));
            logic.polygon.PointList.Add(new Point(10, -10));
            logic.polygon.PointList.Add(new Point(20, -20));
            Polygon p = logic.createNewPolygon();

            Assert.AreEqual(p.Points[0].X, 5);
        }
        [TestMethod]
        public void ChoosePolygonTest1()
        {
            
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic = new Logic();
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");

            Assert.AreEqual(0, logic.ChosenIndex);
        }
        [TestMethod]
        public void ChoosePolygonTest2()
        {
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic = new Logic();
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");

            Assert.AreEqual(true, logic.polygonCollection[logic.ChosenIndex].IsChoosen);
        }
        [TestMethod]
        public void ChoosePolygonTest3()
        {
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic = new Logic();
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Pryvit");
            Assert.AreEqual(false, logic.polygonCollection[0].IsChoosen);
        }
        [TestMethod]
        public void UnChooseShapeTest()
        {
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic = new Logic();
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");
            logic.UnChoseShape();

            Assert.AreEqual(false, logic.polygonCollection[logic.ChosenIndex].IsChoosen);
        }
        [TestMethod]
        public void ClearChooseTest()
        {
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic = new Logic();
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");
            logic.ChooseShape("Pryvit");
            logic.ClearChoose();

            Assert.AreEqual(false, logic.polygonCollection[logic.ChosenIndex].IsChoosen|| logic.polygonCollection[0].IsChoosen);
        }
        [TestMethod]
        public void GetPointsTest()
        {
            logic = new Logic();
            MyPointCollection.addPoint(new Point(5, -5));
            MyPointCollection.addPoint(new Point(10, -5));
            MyPointCollection.addPoint(new Point(11, -52));
            MyPointCollection.addPoint(new Point(53, -25));
            MyPointCollection.addPoint(new Point(15, -33));
            System.Collections.Generic.List<Point> list =  logic.getPoints();

            Assert.AreEqual(5, list.Count);
        }
        [TestMethod]
        public void RemoveAllPointsTest()
        {
            logic = new Logic();
            MyPointCollection.addPoint(new Point(5, -5));
            MyPointCollection.addPoint(new Point(10, -5));
            MyPointCollection.addPoint(new Point(11, -52));
            MyPointCollection.addPoint(new Point(53, -25));
            MyPointCollection.addPoint(new Point(15, -33));
            logic.removeAllPoint();
            System.Collections.Generic.List<Point> list = logic.getPoints();
            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void SerializeTest()
        {
            Polygons = new PolygonShape("Zdorov", new List<Point>() { new Point(10, 20), new Point(5, -5), new Point(101, 401) }, true);
            ObservableCollection<PolygonShape> list = new ObservableCollection<PolygonShape>();
            list.Add(Polygons);
            PolygonShape poly = new PolygonShape("Abaldet", new List<Point>() { new Point(10, 201), new Point(5, -25), new Point(101, 421) });

            list.Add(poly);
            serial.saveShapes(@"forserialization.txt", list);

            Assert.AreEqual(true,File.Exists(@"forserialization.txt"));
        }
        [TestMethod]
        public void DeserializeTest()
        {
            ObservableCollection<PolygonShape> poly = serial.openShapes(@"forserialization.txt");

            Assert.AreEqual(10,poly[0].PointList[0].X);
        }
        [TestMethod]
        public void TestGenerateName()
        {
            logic = new Logic();
            string name = logic.generateName("Polygon");

            Assert.AreEqual("Polygon1", name);
        }
        [TestMethod]
        public void SetShapeMarginAndStartMovePointTest()
        {
            logic = new Logic();
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            shape.Margin = new Point(1, 2);
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");
            Point p = new Point(5, -5);
            logic.SetShapeMarginAndStartMovePoint(p);

            Assert.AreEqual(shape.Margin.X, logic.marginShape.X);
        }
        [TestMethod]
        public void MoveShapeTest()
        {
            logic = new Logic();
            PolygonShape shape = new PolygonShape("Hello", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            shape.Margin = new Point(1, 2);
            PolygonShape shape1 = new PolygonShape("Pryvit", new System.Collections.Generic.List<Point>() { new Point(5, -5), new Point(10, -10), new Point(20, -20) });
            logic.polygonCollection.Add(shape);
            logic.polygonCollection.Add(shape1);

            logic.ChooseShape("Hello");
            Point p = new Point(5, -5);
            logic.SetShapeMarginAndStartMovePoint(p);

            Point mousePoint = new Point(300, 500);

            logic.MoveShape(mousePoint);
            Point newMargin = new Point(296, 0);

            Assert.AreEqual(newMargin.X, logic.polygonCollection[logic.ChosenIndex].Margin.X);
        }
    }
}
