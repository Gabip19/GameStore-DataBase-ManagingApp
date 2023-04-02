using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGBD_Jocuri_DB
{
    public partial class Form1 : Form
    {
        private readonly string connectionString =
            "Data Source=GABI\\SQLEXPRESS;Initial Catalog=MAGAZIN_DE_JOCURI; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private DataSet ds;
        private DataSet combosDs;

        public Form1()
        {
            InitializeComponent();
            InitializeDevsGrid();
            InitializeGamesGrid();
            CreateConnection();
            InitializeData();
            InitializeComboBoxes();
        }

        private void InitializeDevsGrid()
        {
            devsDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            devsDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            devsDataGrid.MultiSelect = false;
            devsDataGrid.RowHeadersVisible = false;
            devsDataGrid.AllowUserToResizeRows = false;
            devsDataGrid.ClearSelection();
        }

        private void InitializeGamesGrid()
        {
            gamesDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gamesDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gamesDataGrid.MultiSelect = false;
            gamesDataGrid.RowHeadersVisible = false;
            gamesDataGrid.AllowUserToResizeRows = false;
            gamesDataGrid.ClearSelection();
        }

        private void InitializeComboBoxes()
        {
            combosDs = new DataSet();
            

            List<string> statusList = new List<string>() { "online", "online/offline", "offline" };
            statusCombo.DataSource = statusList;


            adapter.SelectCommand = new SqlCommand("SELECT * FROM CATEGORII", sqlConnection);
            adapter.Fill(combosDs, "CATEGORII");
            List<string> categoryList = new List<string>();
            foreach (DataRow el in combosDs.Tables["CATEGORII"].Rows)
            {
                categoryList.Add(el["Cid"] + " " + el["categorie"]);
            }
            categoryCombo.DataSource = categoryList;


            adapter.SelectCommand = new SqlCommand("SELECT * FROM RESTRICTII_VARSTA", sqlConnection);
            adapter.Fill(combosDs, "RESTRICTII_VARSTA");
            List<string> ageRestrictionsList = new List<string>();
            foreach (DataRow el in combosDs.Tables["RESTRICTII_VARSTA"].Rows)
            {
                ageRestrictionsList.Add(el["Rvid"] + " " + el["rating_varsta"]);
            }
            ageRatingCombo.DataSource = ageRestrictionsList;
        }

        private void InitializeData()
        {
            adapter = new SqlDataAdapter();
            ds = new DataSet();

            ds.Tables.Add("DEZVOLTATORI");
            ds.Tables.Add("JOCURI");

/*            DataRelation dataRelation = new DataRelation(
                "FK_JOCURI_Did",
                ds.Tables["DEZVOLTATORI"].Columns["Did"],
                ds.Tables["JOCURI"].Columns["Did"]
            );
            ds.Relations.Add(dataRelation);*/

            ReloadParentData();
            
            devsDataGrid.DataSource = ds.Tables["DEZVOLTATORI"];
            gamesDataGrid.DataSource = ds.Tables["JOCURI"];
        }

        private void ReloadParentData()
        {
            ClearFields();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM DEZVOLTATORI", sqlConnection);
            ds.Clear();
            adapter.Fill(ds, "DEZVOLTATORI");
        }

        private void CreateConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        private void RefreshDataButton_Click(object sender, EventArgs e)
        {
            ReloadParentData();
        }

        private void DevsDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int devId = (int) devsDataGrid.SelectedRows[0].Cells[0].Value;
            devIdField.Text = devId.ToString();
            ReloadChildData(devId);
        }

        private void ReloadChildData(int devId)
        {
            adapter.SelectCommand = new SqlCommand("SELECT * FROM JOCURI WHERE Did=@devId", sqlConnection);
            adapter.SelectCommand.Parameters.Add("@devId", SqlDbType.Int).Value = devId;
            ds.Tables["JOCURI"].Clear();
            adapter.Fill(ds, "JOCURI");
        }

        private void GamesDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string gameName = (string)gamesDataGrid.SelectedRows[0].Cells[1].Value;
            string playerNum = (string)gamesDataGrid.SelectedRows[0].Cells[2].Value;
            string status = (string)gamesDataGrid.SelectedRows[0].Cells[3].Value;
            DateTime date = (DateTime)gamesDataGrid.SelectedRows[0].Cells[4].Value;
            string category = gamesDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            string age = gamesDataGrid.SelectedRows[0].Cells[7].Value.ToString();
            string did = gamesDataGrid.SelectedRows[0].Cells[5].Value.ToString();

            nameField.Text = gameName;
            playerNumField.Text = playerNum;
            statusCombo.Text = status;
            datePicker.Value = date;
            categoryCombo.Text = category;
            ageRatingCombo.Text = age;
            devIdField.Text = did;
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            int jid = (int)gamesDataGrid.SelectedRows[0].Cells[0].Value;
            string name = nameField.Text;
            string playerNum = playerNumField.Text;
            string status = statusCombo.Text;
            DateTime date = datePicker.Value;
            int did = int.Parse(devIdField.Text);
            int cid = int.Parse(categoryCombo.Text.Split(' ')[0]);
            int rvid = int.Parse(ageRatingCombo.Text.Split(' ')[0]);

            adapter.UpdateCommand = 
                new SqlCommand("UPDATE JOCURI SET " +
                "nume=@n, nr_jucatori=@pn, " +
                "status_online=@s, data_aparitie=@d, " +
                "Did=@did, Cid=@cid, Rvid=@rvid " +
                "WHERE Jid=@jid", sqlConnection);

            adapter.UpdateCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = name;
            adapter.UpdateCommand.Parameters.Add("@pn", SqlDbType.VarChar).Value = playerNum;
            adapter.UpdateCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = status;
            adapter.UpdateCommand.Parameters.Add("@d", SqlDbType.Date).Value = date;
            adapter.UpdateCommand.Parameters.Add("@did", SqlDbType.Int).Value = did;
            adapter.UpdateCommand.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
            adapter.UpdateCommand.Parameters.Add("@rvid", SqlDbType.Int).Value = rvid;
            adapter.UpdateCommand.Parameters.Add("@jid", SqlDbType.Int).Value = jid;

            try {
                sqlConnection.Open();
                int x = adapter.UpdateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            
                if (x >= 1)
                {
                    MessageBox.Show("Joc actualizat cu succes.");
                    ClearFields();
                    ReloadChildData((int)devsDataGrid.SelectedRows[0].Cells[0].Value);
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
}

        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string playerNum = playerNumField.Text;
            string status = statusCombo.Text;
            DateTime date = datePicker.Value;
            int did = (int)devsDataGrid.SelectedRows[0].Cells[0].Value;
            int cid = int.Parse(categoryCombo.Text.Split(' ')[0]);
            int rvid = int.Parse(ageRatingCombo.Text.Split(' ')[0]);

            adapter.InsertCommand =
                new SqlCommand("INSERT INTO JOCURI VALUES (@n, @pn, @s, @d, @did, @cid, @rvid)", sqlConnection);

            adapter.InsertCommand.Parameters.Add("@pn", SqlDbType.VarChar).Value = playerNum;
            adapter.InsertCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = status;
            adapter.InsertCommand.Parameters.Add("@d", SqlDbType.Date).Value = date;
            adapter.InsertCommand.Parameters.Add("@n", SqlDbType.VarChar).Value = name;
            adapter.InsertCommand.Parameters.Add("@did", SqlDbType.Int).Value = did;
            adapter.InsertCommand.Parameters.Add("@cid", SqlDbType.Int).Value = cid;
            adapter.InsertCommand.Parameters.Add("@rvid", SqlDbType.Int).Value = rvid;

            try {
                sqlConnection.Open();
                int x = adapter.InsertCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (x >= 1)
                {
                    MessageBox.Show("Joc adaugat cu succes.");
                    ClearFields();
                    ReloadChildData((int)devsDataGrid.SelectedRows[0].Cells[0].Value);
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
}

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            int jid = (int)gamesDataGrid.SelectedRows[0].Cells[0].Value;

            adapter.DeleteCommand = new SqlCommand("DELETE FROM JOCURI WHERE Jid=@jid", sqlConnection);
            
            adapter.DeleteCommand.Parameters.Add("@jid", SqlDbType.Int).Value = jid;

            try
            {
                sqlConnection.Open();
                int x = adapter.DeleteCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (x >= 1)
                {
                    MessageBox.Show("Joc sters cu succes.");
                    ClearFields();
                    ReloadChildData((int)devsDataGrid.SelectedRows[0].Cells[0].Value);
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
        }

        private void ClearFields()
        {
            nameField.Clear();
            playerNumField.Clear();
            statusCombo.Text = string.Empty;
            categoryCombo.Text = string.Empty;
            ageRatingCombo.Text = string.Empty;
            if (devsDataGrid.SelectedRows.Count != 0)
                devIdField.Text = devsDataGrid.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
