using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using AdvancedCalculate.Logic;

namespace AdvancedCalculate.WPF
{
    public class FunctionGraphDrawer
    {
        private double Height { get; }
        private double Width { get; }
        private Canvas FunctionGraph { get; set; }
        private Polyline polyLine { get; set; }
        public FunctionGraphDrawer(Canvas functionGraph, TextBox startX, TextBox endX)
        {
            Height = functionGraph.ActualHeight;
            Width = functionGraph.ActualWidth;

            FunctionGraph = functionGraph;

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
            functionGraph.Children.Add(GetLine(0, Width, Height / 2, Height / 2));
            functionGraph.Children.Add(GetLine(Width / 2, Width / 2, 0, Height));
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
                SetPointOfLeft((int)i, functionGraph);
                SetPointOfBottom((int)Calculate.AllResultes[i], functionGraph);
            }
        }
        private void SetPointOfBottom(int i, Canvas functionGraph)
        {
            var pointOfBottom = GetEllipse();

            Canvas.SetLeft(pointOfBottom, Width / 2 - 2);
            Canvas.SetBottom(pointOfBottom, Height / 2 + i * Values.ValueZoom);

            functionGraph.Children.Add(pointOfBottom);
        }
        private void SetPointOfLeft(int i, Canvas functionGraph)
        {
            var pointOfLeft = GetEllipse();

            Canvas.SetTop(pointOfLeft, Height / 2 - 2);
            Canvas.SetRight(pointOfLeft, Width / 2 - i * Values.ValueZoom);

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
            polyLine = new Polyline
            {
                Stroke = Brushes.Red,
                StrokeThickness = 2,
            }; 

            foreach (var i in Calculate.AllResultes.Keys)
            {
                var point = new Point
                {
                    X = Width / 2 + i * Values.ValueZoom,
                    Y = Height / 2 - Calculate.AllResultes[i] * Values.ValueZoom,
                };
                polyLine.Points.Add(point);
            }

            polyLine.MouseEnter += Polyline_MouseEnter;

            functionGraph.Children.Add(polyLine);
        }

        private void Polyline_MouseEnter(object sender, MouseEventArgs e)
        {
            var cursorPosition = Mouse.GetPosition(FunctionGraph);

            string[] coors = cursorPosition.ToString().Split(new char[] { ';' });

            var toolTip = new ToolTip();

            var stackCoor = new StackPanel();
            stackCoor.Children.Add(GetCoordinates(Math.Round((double.Parse(coors[1]) - Height / 2) / Values.ValueZoom, 2) , "x"));
            stackCoor.Children.Add(GetCoordinates(-1 * Math.Round((double.Parse(coors[0]) - Width / 2) / Values.ValueZoom, 2), "y"));
            toolTip.Content = stackCoor;
            polyLine.ToolTip = toolTip;
        }
        private Label GetCoordinates(double coor, string nameCoor)
        {
            var labelCoor = new Label 
            { 
                Content = $"{nameCoor}: {coor}"
            };

            return labelCoor;
        }

        private void GetFieldParams(Canvas functionGraph, int startX, int endX)
        {
            if (startX > endX)
                functionGraph.Width = startX * (Values.ValueZoom * 2);
            else  
                functionGraph.Width = endX * (Values.ValueZoom * 2);

            double maxY = 0;

            foreach (var i in Calculate.AllResultes.Values)
            {
                if (i > maxY) 
                {
                    maxY = i;
                }
            }

            functionGraph.Height = maxY * (Values.ValueZoom * 2);
        }
    }
}
