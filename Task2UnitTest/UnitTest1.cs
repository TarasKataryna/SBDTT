using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicClass;
using ClassLibrary;
using Serialization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

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
    }
}
