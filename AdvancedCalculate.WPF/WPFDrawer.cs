using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AdvancedCalculate.Logic;

namespace AdvancedCalculate.WPF
{
    public class WPFDrawer
    {
        public static void GetListResultes(DataGrid resultesGrid)
        {
            List<Resultes> resultes = new List<Resultes>();

            foreach(var i in Calculate.AllResultes.Keys)
            {
                resultes.Add(new Resultes(i, Calculate.AllResultes[i]));
            }

            resultesGrid.ItemsSource = resultes;
        }
    }
}
