using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace kronometre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            renk = button1.Foreground;
        }
        DispatcherTimer timer = new DispatcherTimer();
        Brush renk;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            lblSayi.Content = "1"; 
            timer.Start();
            button1.IsEnabled = false;
            button1.Foreground = new SolidColorBrush(Colors.Red);
            button2.Visibility = System.Windows.Visibility.Visible;
        }

        void timer_Tick(object sender, EventArgs e)
        {

            if (lblSayi.Content.ToString() != textBox1.Text)
                lblSayi.Content = Int32.Parse(lblSayi.Content.ToString()) + 1;
            else
            {
                timer.Stop();
                lblSayi.Content = "Bitti";
                button1.IsEnabled = true;
                button1.Foreground = renk;
               MessageBox.Show("Bitti");
            }
                
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            MessageBox.Show("Durduruldu.");
            button1.IsEnabled = true;
            button1.Foreground = renk;
            button2.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
