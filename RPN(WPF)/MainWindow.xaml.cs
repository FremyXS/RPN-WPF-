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
using RPN.Logic;
using RPN_WPF_.Models;

namespace RPN_WPF_
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
            int[] rangeX = { int.Parse(startBox.Text), int.Parse(endBox.Text) };

            foreach (string i in RPN.Logic.RPN.GetPostfix(functionBox.Text))
            {
                rpn.Text += i;
            }

            new CalculateRPN(RPN.Logic.RPN.GetPostfix(functionBox.Text), rangeX, int.Parse(stepBox.Text));                       

            List<Rezultes> rezultes = new List<Rezultes>();            

            for(var i = 0; i < CalculateRPN.listRangeX.Count; i++)
            {
                rezultes.Add(new Rezultes(CalculateRPN.listRangeX[i], CalculateRPN.listRezultes[i]));              
            }

            resultesGrid.ItemsSource = rezultes;
            
        }

        private void AxesCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Draw();
        }
        public void Draw()
        {
            axesCanvas.Children.Clear();

            var height = axesCanvas.ActualHeight;
            var width = axesCanvas.ActualWidth;

            var Axis_x = new Line();
            var Axis_y = new Line();

            Axis_x.X1 = 0;
            Axis_x.Y1 = height / 2;
            Axis_x.X2 = width;
            Axis_x.Y2 = height / 2;
            Axis_x.Stroke = Brushes.Black;
            Axis_x.StrokeThickness = 2;

            Axis_y.X1 = width / 2;
            Axis_y.Y1 = 0;
            Axis_y.X2 = width / 2;
            Axis_y.Y2 = height;
            Axis_y.Stroke = Brushes.Black;
            Axis_y.StrokeThickness = 2;
            axesCanvas.Children.Add(Axis_x);
            axesCanvas.Children.Add(Axis_y);

        }
    }
}
