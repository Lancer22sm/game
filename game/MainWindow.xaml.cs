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
using System.Drawing;
using System.Windows.Media.Media3D;

namespace game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double left;
        double up;
        double right;
        double down;
        double speed = 1;
        List<Border> borderList = new();
        List<System.Drawing.Rectangle> rectList = new();
        System.Drawing.Rectangle rectGeneralBorder = new();
        private readonly Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            CreateRedSquares();
            CreateRectangles();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            GetMySquareMargin();
            speed *= 1.1;
            if (e.Key == Key.A) left -= 1 * speed;
            if (e.Key == Key.W) up -= 1 * speed;
            if (e.Key == Key.D) left += 1 * speed;
            if (e.Key == Key.S) up += 1 * speed;
            mySquare.Margin = new Thickness(left, up, right, down);
            rectGeneralBorder = new System.Drawing.Rectangle(
                new System.Drawing.Point(Convert.ToInt32(mySquare.Margin.Left),
                Convert.ToInt32(mySquare.Margin.Top)),
                new System.Drawing.Size(Convert.ToInt32(mySquare.Width),
                Convert.ToInt32(mySquare.Height)));
            System.Drawing.Rectangle check = new();
            for (int i = 0; i < rectList.Count; i++)
            {
                check = System.Drawing.Rectangle.Intersect(rectGeneralBorder, rectList[i]);
                if (check != System.Drawing.Rectangle.Empty) break;
            }
            if (check != System.Drawing.Rectangle.Empty) MessageBox.Show("ты проиграл!");

        }
        private void GetMySquareMargin()
        {
            left = mySquare.Margin.Left;
            up = mySquare.Margin.Top;
            right = mySquare.Margin.Right;
            down = mySquare.Margin.Bottom;
        }
        private void CreateRedSquares()
        {
            double heightBadBorders;
            double widthBadBorders;
            double marginLeftBadBorders;
            double marginTopBadBorders;
            for (int i = 0; i < 30; i++)
            {
                Border badBorder = new();
                badBorder.Name = $"BadBorder{i}";
                badBorder.HorizontalAlignment = HorizontalAlignment.Left;
                badBorder.VerticalAlignment = VerticalAlignment.Top;
                heightBadBorders = random.Next(1, 50);
                badBorder.Height = heightBadBorders;
                widthBadBorders = random.Next(1, 50);
                badBorder.Width = widthBadBorders;
                badBorder.Background = Brushes.Red;
                marginLeftBadBorders = random.Next(1, 750);
                marginTopBadBorders = random.Next(1, 400);
                badBorder.Margin = new Thickness(marginLeftBadBorders, marginTopBadBorders, 0, 0);
                myGrid.Children.Add(badBorder);
                borderList.Add(badBorder);
            }
        }

        private void CreateRectangles()
        {
            for (int i = 0; i < 30; i++)
            {
                System.Drawing.Rectangle badRectangles = new System.Drawing.Rectangle(
                new System.Drawing.Point(Convert.ToInt32(borderList[i].Margin.Left),
                Convert.ToInt32(borderList[i].Margin.Top)),
                new System.Drawing.Size(Convert.ToInt32(borderList[i].Width),
                Convert.ToInt32(borderList[i].Height)));
                rectList.Add(badRectangles);
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            speed = 1;
        }
    }
}
