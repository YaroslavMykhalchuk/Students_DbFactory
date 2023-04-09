using System.Data.Common;
using System.Data;
using Npgsql;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace Students_ProviderFactory
{
    public partial class Form1 : Form
    {
        private string connStr;
        DataTable dt;
        DbProviderFactory providerFactory;
        private bool isConnected = false;
        private bool dbProvider; // false if sql provider and true if npg provider
        public Form1()
        {
            InitializeComponent();

            dataGridView.Visible = false;
            comboBoxQuery.Visible = false;
            buttonExecute.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
            DbProviderFactories.RegisterFactory("Npgsql", SqlClientFactory.Instance);
            dt = DbProviderFactories.GetFactoryClasses();
            comboBoxDBProviders.DataSource = dt;
            comboBoxDBProviders.DisplayMember = "InvariantName";
        }

        private void comboBoxDBProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(isConnected)
            {
                MessageBox.Show("Disconnect from the base!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (comboBoxDBProviders.GetItemText(comboBoxDBProviders.SelectedItem) == "System.Data.SqlClient")
            {
                providerFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                connStr = ConfigurationManager.ConnectionStrings["SqlDbConnStr"].ConnectionString;
                dbProvider = false;
            }
            else if(comboBoxDBProviders.GetItemText(comboBoxDBProviders.SelectedItem) == "Npgsql")
            {
                providerFactory = DbProviderFactories.GetFactory("Npgsql");
                connStr = ConfigurationManager.ConnectionStrings["MyNpgSqlDb"].ConnectionString;
                dbProvider = true;
            }
            else
            {
                connStr = string.Empty;
            }
        }

        private void comboBoxQuery_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView.DataSource = null;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if(comboBoxDBProviders.SelectedIndex != -1)
            {
                if(isConnected)
                {
                    isConnected = false;
                    buttonConnect.Text = "Connect";
                    dataGridView.Visible = false;
                    comboBoxQuery.Visible = false;
                    buttonExecute.Visible = false;
                    //connStr = string.Empty;
                }
                else
                {
                    isConnected = true;
                    buttonConnect.Text = "Disconnect";
                    dataGridView.Visible = true;
                    comboBoxQuery.Visible = true;
                    buttonExecute.Visible = true;
                    //connStr = ConfigurationManager.ConnectionStrings[comboBoxDBProviders.SelectedIndex].ConnectionString;
                }
            }
            else
            {
                MessageBox.Show("Choose database provider!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DownloadFromSqlDb(string query, DataGridView dataGridView)
        {

        }

        private async void DownloadFromPostgressDb(string query, DataGridView dataGridView)
        {
            using(NpgsqlConnection connection = new NpgsqlConnection(connStr))
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                dt = new DataTable();
                NpgsqlDataReader reader = null;

                try
                {
                    await connection.OpenAsync();
                    reader = command.ExecuteReader();
                    int line = 0;
                    while (reader.Read())
                    {
                        if (line == 0)
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dt.Columns.Add(reader.GetName(i));
                            }
                        }
                        DataRow row= dt.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        dt.Rows.Add(row);
                        line++;
                    }
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        private async Task DownloadDataFromDb(string query, DataGridView dataGridView)
        {
            using(DbConnection connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = connStr;
                DbCommand command = connection.CreateCommand();
                command.CommandText = query;
                command.Connection = connection;
                DbDataReader reader = null;
                DataTable dt = new DataTable();
                try
                {
                    await connection?.OpenAsync();
                    reader = await command.ExecuteReaderAsync();
                    int line = 0;
                    while (await reader.ReadAsync())
                    {
                        if (line == 0)
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                dt.Columns.Add(reader.GetName(i));
                            }
                        DataRow row = dt.NewRow();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[i] = reader[i];
                        }
                        dt.Rows.Add(row);
                        line++;
                    }
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    await connection.CloseAsync();
                }
            }
        }

        private async void buttonExecute_Click(object sender, EventArgs e)
        {
            string query = ChooseQuery(comboBoxQuery);

            await DownloadDataFromDb(query, dataGridView);
        }

        private string ChooseQuery(ComboBox combobox)
        {
            string query = string.Empty;

            switch (combobox.Text)
            {
                case "Відображати всієї інформації з таблиці зі студентами та оцінками.":
                    {
                        query = "select * from Students_rating";
                    }
                    break;
                case "Відображати ПІБ усіх студентів.":
                    {
                        query = "select Id, Firstname, Surname from Students_rating";
                    }
                    break;
                case "Відображати усіх середніх оцінок.":
                    {
                        query = "select Id, Avarage_rating from Students_rating";
                    }
                    break;
                case "Показати ПІБ усіх студентів з мінімальною оцінкою, більшою, ніж зазначена.":
                    {

                    }
                    break;
                case "Показати назви усіх предметів із мінімальними середніми оцінками. Назви предметів мають бути унікальними.":
                    {

                    }
                    break;
                case "Показати мінімальну середню оцінку.":
                    {
                        query = "select MIN(Avarage_rating) from Students_rating";
                    }
                    break;
                case "Показати максимальну середню оцінку.":
                    {
                        query = "select MAX(Avarage_rating) from Students_rating";
                    }
                    break;
                case "Показати кількість студентів з мінімальною середньою оцінкою з математики.":
                    {
                        query = "SELECT COUNT(*) as Min_Math_Rating_Students_Count " +
                                "FROM Students_rating " +
                                "WHERE Avarage_rating = (SELECT MIN(Avarage_rating) FROM Students_rating WHERE Name_subject_min = 'Math')";
                    }
                    break;
                case "Показати кількість студентів, в яких максимальна середня оцінка з математики.":
                    {
                        query = query = "SELECT COUNT(*) as Min_Math_Rating_Students_Count " +
                                        "FROM Students_rating " +
                                        "WHERE Avarage_rating = (SELECT MAX(Avarage_rating) FROM Students_rating WHERE Name_subject_min = 'Math')";
                    }
                    break;
                case "Показати кількість студентів у кожній групі.":
                    {
                        query = "select [Group], count(*) AS students_count from Students_rating group by [Group]";
                    }
                    break;
                case "Показати середню оцінку групи.":
                    {
                        query = $"select AVG(Avarage_rating) from Students_rating where [Group] = @name";
                    }
                    break;
            }
            return query;
        }
    }
}