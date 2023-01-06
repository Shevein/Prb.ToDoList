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

namespace Prb.ToDoList.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string subject = txtSubject.Text;
            string textFromUser = txtText.Text;

            if (txtSubject.Text == "")
            {
                MessageBox.Show("Gelieve het onderwerp in te geven!", "Fout !", MessageBoxButton.OK, MessageBoxImage.Error);
                txtSubject.Focus();
            }
            else
            {

                lstToDo.Items.Add($"Subject : {subject}\n\nDescription : {textFromUser}");
                Count();

                txtSubject.Clear();
                txtText.Clear();
                txtSubject.Focus();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(lstToDo.SelectedIndex == -1)
            {
                return;
            }
            lstToDo.Items.RemoveAt(lstToDo.SelectedIndex);
            count--;
            tbkNumberOfTasks.Text = count.ToString();
        }

        private void BtnDeleteAllTasks_Click(object sender, RoutedEventArgs e)
        {
            lstToDo.Items.Clear();

            count = 0;
            tbkNumberOfTasks.Text = count.ToString();
        }

        private void BtnEndedTask_Click(object sender, RoutedEventArgs e)
        {
            if (lstToDo.SelectedIndex == -1)
            {
                return;
            }
            lstToDo.Items.RemoveAt(lstToDo.SelectedIndex);
            MessageBox.Show("You did a great job! the task is succeed! ", "Great Job! ", MessageBoxButton.OK, MessageBoxImage.Information);

            count--;
            tbkNumberOfTasks.Text = count.ToString();
        }

        private void Count()
        {
            count = 0;

            foreach(var item in lstToDo.Items)
            {
                count++;
            }
            tbkNumberOfTasks.Text = count.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtSubject.Focus();
        }
    }
}
