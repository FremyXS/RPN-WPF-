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
                && Errors.IsStep(startText.Text) && Errors.IsStep(endText.Text)){
                
                rpnText.Text = GetStringRPN(functionText.Text);

                WPFDrawer.GetListResultes(resultesGrid);
            }

            coordinateAxes.Children.Clear();
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }
        private string GetStringRPN(string function)
        {
            object[] rpn = new RPN(Info.GetFunctionList(function)).PostFix.ToArray();

            new Calculate(rpn, int.Parse(startText.Text), int.Parse(endText.Text), int.Parse(StepText.Text));

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
            Values.ValueZoom += 10;
            coordinateAxes.Height += 10;
            coordinateAxes.Width += 10;
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }

        private void ButtonZoomMinus(object sender, RoutedEventArgs e)
        {
            coordinateAxes.Children.Clear();
            Values.ValueZoom -= 10;
            coordinateAxes.Height -= 10;
            coordinateAxes.Width -= 10;
            new FunctionGraphDrawer(coordinateAxes, startText, endText);
        }
        
    }
}
