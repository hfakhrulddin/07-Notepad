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
using System.IO;
using Microsoft.Win32;
namespace Notepad
{
    public partial class MainWindow : Window
    {
        string firstcopy;
        public MainWindow()
        {
            InitializeComponent(); 
        }
        public void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileName = "Document";
            openFileDialog1.DefaultExt = ".txt";
            openFileDialog1.Filter = "Text documents (.txt)|*.txt";
            openFileDialog1.ShowDialog();
            var dir =openFileDialog1.FileName;
            string content = File.ReadAllText(dir);
            txb.Text = content;
            firstcopy = content;
        }
        public void Save(object sender, RoutedEventArgs e)
        {
            Save1();
        }
        public void Save1() { 
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "Document";
            saveFileDialog1.DefaultExt = ".txt";
            saveFileDialog1.Filter = "Text documents (.txt)|*.txt";
            saveFileDialog1.ShowDialog();
            var dir2 = saveFileDialog1.FileName;
            string txb2 = txb.Text;
            File.WriteAllText(dir2,txb2);
        }
        private void Clear(object sender, RoutedEventArgs e)
        {
            const string message = "Would like to clear the current file?";
            const string caption = "Clearing";
            var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                txb.Clear(); 
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            if (txb.Text != firstcopy) {
                const string message = "Would like to save the current file?";
                const string caption = "Question";
                var result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Save1();
                }
            }
            MessageBox.Show("Thank you for using our product");
            Application.Current.Shutdown();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
