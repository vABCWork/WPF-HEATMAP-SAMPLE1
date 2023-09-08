using ScottPlot;
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

namespace TestHeatmap
{

    // Heatmapの表示
    //
    // ヒートマップ:https://scottplot.net/cookbook/4.1/#heatmap
    // カラーバー:  https://scottplot.net/cookbook/4.1/category/plottable-colorbar/
    // カラーマップ:  https://scottplot.net/cookbook/4.1/colormaps/
    //

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Test_Heatmap.Configuration.Pan = false;  // パン(グラフの移動)不可
            Test_Heatmap.Configuration.ScrollWheelZoom = false; //ズーム(グラフの拡大、縮小)不可

            //double[,] data2D = { { 1, 2, 3 }, { 4, 5, 6 } };

            double[,] data2D;
            data2D = new double[2, 3];

            data2D[0, 0] = 1;
            data2D[0, 1] = 2;
            data2D[0, 2] = 3;
            data2D[1, 0] = 4;
            data2D[1, 1] = 5;
            data2D[1, 2] = 6;

           // Test_Heatmap.Plot.XAxis.Ticks(false, false, false); // X軸目盛り(大、小)とラベルの非表示
           // Test_Heatmap.Plot.YAxis.Ticks(false, false, false); // Y軸目盛り(大、小)とラベルの非表示

            var hm = Test_Heatmap.Plot.AddHeatmap(data2D,lockScales:false); // ヒートマップ表示  data2D[col,row]を左上から順に表示

            var cb = Test_Heatmap.Plot.AddColorbar(hm); // カラーバー表示

            for (int i = 0; i < 2; i++)       //   配列データの表示
            {
                for (int j = 0; j < 3; j++)
                {
                    string str_data = "data2D[" + i.ToString() + "," + j.ToString() + "] = " +  data2D[i, j].ToString();
                    
                    Test_Heatmap.Plot.AddText(str_data, 0.2 + j, 1.5 - i, size:14, color: System.Drawing.Color.White);
                }
            }

            Test_Heatmap.Render();                      // ヒートマップの表示
        }

    }
}
