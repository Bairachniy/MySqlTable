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
using System.Data;
using System.Data.SqlClient;

namespace MySqlTable
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DataSet userStore = null;
        DataTable userTable = null;
        private SqlConnection connection=null;
        SqlCommandBuilder cmd = null;
        SqlDataAdapter sda = null;
        
        public MainWindow()
        {
            InitializeComponent();
            connection= new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=usersdb; Integrated Security=SSPI;");
            label.Content = "UsersTable";
        }  
        private void FillData(string s)
        {
            try
            {
                userStore = new DataSet();
                sda = new SqlDataAdapter(s, connection);
                dataGrid.DataContext = null;
                cmd = new SqlCommandBuilder(sda);
                sda.Fill(userStore, "UsersTable");
                dataGrid.DataContext = userStore.Tables["UsersTable"];
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
        private void Uptade()
        {
            sda.Update(userStore, "UsersTable");
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FillData(textBox.Text);
        }

       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Uptade();
        }
        public void Fill()
        {
            DataRow row = userTable.NewRow();
            row.ItemArray = new object[] { null, "Sveta", "Malahitova" }; // добавляем первую строку
            userTable.Rows.Add(row);// добавляем вторую строку
            userTable.Rows.Add(new object[] { null, "Vlada", "Taratinkina" });
            userTable.Rows.Add(new object[] { null, "Vika", "Korobova" });
            userTable.Rows.Add(new object[] { null, "Kolya", "Tatushkina" });
            userTable.Rows.Add(new object[] { null, "Decl", "Malaya" });
            dataGrid.DataContext = userTable.DefaultView;
        }

    }
}
