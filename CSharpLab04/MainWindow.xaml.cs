using System.ComponentModel;
using System.Windows;


namespace CSharpLab04
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            DBAdapter.SaveData();
            base.OnClosing(e);
        }
    }
}
