using ManageCategoriesApp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoWPF
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

        ManageCategories categories = new ManageCategories();

        private void LoadCategories()
        {
            lvCategories.ItemsSource = categories.GetCategories();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCategories();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sid = txtCategoryID.Text;
                var id = int.Parse(sid);
                var name = txtCategoryName.Text;
                var cate = new Category { CategoryID = id, CategoryName = name };
                categories.UpdateCategory(cate);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "delete category");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sid = txtCategoryID.Text;
                var id = int.Parse(sid);
                categories.DeleteCategory(new Category { CategoryID = id });
                LoadCategories();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "delete category");
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var category = new Category { CategoryName = txtCategoryName.Text };
                categories.InsertCategory(category);
                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Inser category");
            }
        }
    }
}