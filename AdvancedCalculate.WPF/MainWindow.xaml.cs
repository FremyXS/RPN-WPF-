using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AdvancedCalculate.Logic;

namespace AdvancedCalculate.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Result_Click(object sender, RoutedEventArgs e)
        {
            if (Errors.CheckFunction(functionText.Text) && Errors.IsStep(StepText.Text) 
            && Errors.IsStep(startText.Text) && Errors.IsStep(endText.Text))
            {
                if (Errors.CheckRange(StepText.Text, startText.Text, endText.Text))
                {
                    rpnText.Text = GetStringRPN(functionText.Text);

                    WPFDrawer.GetListResultes(resultesGrid);
                }
            }

            coordinateAxes.Children.Clear();
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }
        private string GetStringRPN(string function)
        {
            object[] rpn = new RPN(Info.GetFunctionList(function)).PostFix.ToArray();

            new Calculate(rpn, double.Parse(startText.Text), double.Parse(endText.Text), double.Parse(StepText.Text));

            string rpnString = "";

            foreach (var i in rpn)
                rpnString += i.ToString();                       

            return rpnString;
        }

        private void CoordinateAxis_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            coordinateAxes.Children.Clear();
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }

        private void ButtonZoomPlus(object sender, RoutedEventArgs e)
        {
            coordinateAxes.Children.Clear();
            Values.ValueZoom += 5;
            coordinateAxes.Height += 5;
            coordinateAxes.Width += 5;
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }

        private void ButtonZoomMinus(object sender, RoutedEventArgs e)
        {
            coordinateAxes.Children.Clear();
            Values.ValueZoom -= 5;
            coordinateAxes.Height -= (double)5;
            coordinateAxes.Width -= 5;
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }
        private bool isDragAndDrop { get; set; }
        private Point pointDragAndDrop { get; set; } 
        private Thickness marginDragAndDrop { get; set; }
        private void coordinateAxes_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragAndDrop = true;
            pointDragAndDrop = Mouse.GetPosition(this);
            marginDragAndDrop = coordinateAxes.Margin;
        }

        private void coordinateAxes_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragAndDrop = false;
        }

        private void coordinateAxes_MouseMove(object sender, MouseEventArgs e)
        {
            var current = Mouse.GetPosition(this);
            var offset = current - pointDragAndDrop;
            if (isDragAndDrop)
            {
                current = Mouse.GetPosition(this);
                offset = current - pointDragAndDrop; 
                coordinateAxes.Margin = new Thickness(marginDragAndDrop.Left + offset.X, marginDragAndDrop.Top + offset.Y, 0, 0);

            }
        }

        private void coordinateAxes_MouseLeave(object sender, MouseEventArgs e)
        {
            isDragAndDrop = false;
        }
    }
}
