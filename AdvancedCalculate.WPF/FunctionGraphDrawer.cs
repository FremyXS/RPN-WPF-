using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using AdvancedCalculate.Logic;

namespace AdvancedCalculate.WPF
{
    public class FunctionGraphDrawer
    {
        private double height { get; }
        private double width { get; }
        public FunctionGraphDrawer(Canvas functionGraph, TextBox startX, TextBox endX)
        {
            height = functionGraph.ActualHeight;
            width = functionGraph.ActualWidth;

            DrawAxes(functionGraph);
            if (Calculate.AllResultes.Count > 0)
            {
                GetFieldParams(functionGraph, int.Parse(startX.Text), int.Parse(endX.Text));
                DrawPoints(functionGraph);
                DrawFunction(functionGraph);
            }
        }
        private void DrawAxes(Canvas functionGraph)
        {
            functionGraph.Children.Add(GetLine(0, width, height / 2, height / 2));
            functionGraph.Children.Add(GetLine(width / 2, width / 2, 0, height));
        }
        private Line GetLine(double x1, double x2, double y1, double y2)
        {
            var line = new Line
            {
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2,
                Stroke = Brushes.Black,
                StrokeThickness = 2,
            };

            return line;
        }
        private void DrawPoints(Canvas functionGraph)
        {
            foreach (var i in Calculate.AllResultes.Keys)
            {
                SetPointOfLeft(i, functionGraph);
                SetPointOfBottom(Calculate.AllResultes[i], functionGraph);
            }
        }
        private void SetPointOfBottom(int i, Canvas functionGraph)
        {
            var pointOfBottom = GetEllipse();

            Canvas.SetLeft(pointOfBottom, width / 2 - 2);
            Canvas.SetBottom(pointOfBottom, height / 2 + i * Values.ValueZoom);

            functionGraph.Children.Add(pointOfBottom);
        }
        private void SetPointOfLeft(int i, Canvas functionGraph)
        {
            var pointOfLeft = GetEllipse();

            Canvas.SetTop(pointOfLeft, height / 2 - 2);
            Canvas.SetRight(pointOfLeft, width / 2 - i * Values.ValueZoom);

            functionGraph.Children.Add(pointOfLeft);
        }
        private Ellipse GetEllipse()
        {
            Ellipse point = new Ellipse
            {
                Height = 5,
                Width = 5,
                Stroke = Brushes.Black,
                Fill = Brushes.Black,
            };
            return point;
        }
        private void DrawFunction(Canvas functionGraph)
        {
            var polyline = new Polyline
            {
                Stroke = Brushes.Red,
                StrokeThickness = 5,
            }; 

            foreach (var i in Calculate.AllResultes.Keys)
            {
                var point = new Point
                {
                    X = width / 2 + i * Values.ValueZoom,
                    Y = height / 2 - Calculate.AllResultes[i] * Values.ValueZoom,
                };
                polyline.Points.Add(point);
            }

            functionGraph.Children.Add(polyline);
        }
        private void GetFieldParams(Canvas functionGraph, int startX, int endX)
        {
            if (startX > endX)  functionGraph.Width = startX * (Values.ValueZoom * 2);
            else  functionGraph.Width = endX * (Values.ValueZoom * 2);

            int maxY = 0;

            foreach (var i in Calculate.AllResultes.Values)
            {
                if (i > maxY) maxY = i;
            }

            functionGraph.Height = maxY * (Values.ValueZoom * 2);
        }
    }
}
