using FontAwesome.WPF;
using System.Windows.Controls;

namespace CSharpLab04
{
    /// <summary>
    /// Логика взаимодействия для PersonView.xaml
    /// </summary>
    public partial class PersonView : UserControl
    {
        private ImageAwesome _loader;
        public PersonView()
        {
            InitializeComponent();
            DataContext = new PersonViewModel(ShowLoader);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void ShowLoader(bool isShow)
        {
            LoaderHelper.OnRequestLoader(GridPersonView, ref _loader, isShow);
        }
    }
}
