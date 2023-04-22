using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SGBD_Jocuri_DB
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection;
        private SqlDataAdapter adapter;
        private DataSet ds;
        private DataSet combosDs;
        
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        private string parentTable;
        private string childTable;

        public Form1()
        {
            ReadConfigFile();
            InitializeComponent();
            InitializeParentGrid();
            InitializeChildGrid();
            CreateConnection();
            InitializeData();
            InitializeComboBoxes();
        }

        private void ReadConfigFile()
        {
            parentTable = ConfigurationManager.AppSettings["ParentTable"];
            childTable = ConfigurationManager.AppSettings["ChildTable"];
        }

        private void InitializeParentGrid()
        {
            parentDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            parentDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            parentDataGrid.MultiSelect = false;
            parentDataGrid.RowHeadersVisible = false;
            parentDataGrid.AllowUserToResizeRows = false;
            parentDataGrid.ClearSelection();
        }

        private void InitializeChildGrid()
        {
            childDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            childDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            childDataGrid.MultiSelect = false;
            childDataGrid.RowHeadersVisible = false;
            childDataGrid.AllowUserToResizeRows = false;
            childDataGrid.ClearSelection();
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

            ds.Tables.Add(parentTable);
            ds.Tables.Add(childTable);

            ReloadParentData();
            
            parentDataGrid.DataSource = ds.Tables[parentTable];
            childDataGrid.DataSource = ds.Tables[childTable];
        }

        private void ReloadParentData()
        {
            ClearFields();
            adapter.SelectCommand = new SqlCommand("SELECT * FROM " + parentTable, sqlConnection);
            ds.Clear();
            adapter.Fill(ds, parentTable);
        }

        private void CreateConnection()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        private void RefreshDataButton_Click(object sender, EventArgs e)
        {
            ReloadParentData();
        }

        /////////////////////////////// <TODO>
        private void ParentDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int parentId = (int) parentDataGrid.SelectedRows[0].Cells[0].Value;
            devIdField.Text = parentId.ToString(); //////
            ReloadChildData(parentId);
        }

        private void ReloadChildData(int parentId)
        {
            string command = "SELECT * FROM " + childTable + " WHERE " + 
                ConfigurationManager.AppSettings["ParentPKColumn"] + "=@parentId";

            adapter.SelectCommand = new SqlCommand(command, sqlConnection);
            adapter.SelectCommand.Parameters.Add("@parentId", SqlDbType.Int).Value = parentId;

            ds.Tables[childTable].Clear();
            adapter.Fill(ds, childTable);
        }

        /////////////////////////////// <TODO>
        private void GamesDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string gameName = (string)childDataGrid.SelectedRows[0].Cells[1].Value;
            string playerNum = (string)childDataGrid.SelectedRows[0].Cells[2].Value;
            string status = (string)childDataGrid.SelectedRows[0].Cells[3].Value;
            DateTime date = (DateTime)childDataGrid.SelectedRows[0].Cells[4].Value;
            string category = childDataGrid.SelectedRows[0].Cells[6].Value.ToString();
            string age = childDataGrid.SelectedRows[0].Cells[7].Value.ToString();
            string did = childDataGrid.SelectedRows[0].Cells[5].Value.ToString();

            nameField.Text = gameName;
            playerNumField.Text = playerNum;
            statusCombo.Text = status;
            datePicker.Value = date;
            categoryCombo.Text = category;
            ageRatingCombo.Text = age;
            devIdField.Text = did;
        }

        /////////////////////////////// <TODO>
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            int jid = (int)childDataGrid.SelectedRows[0].Cells[0].Value;
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
                    ReloadChildData((int)parentDataGrid.SelectedRows[0].Cells[0].Value);
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
}
        /////////////////////////////// <TODO>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            string name = nameField.Text;
            string playerNum = playerNumField.Text;
            string status = statusCombo.Text;
            DateTime date = datePicker.Value;
            int did = (int)parentDataGrid.SelectedRows[0].Cells[0].Value;
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
                    ReloadChildData((int)parentDataGrid.SelectedRows[0].Cells[0].Value);
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
            int childId = (int)childDataGrid.SelectedRows[0].Cells[0].Value;

            string command = "DELETE FROM " + childTable + " WHERE " +
                ConfigurationManager.AppSettings["ChildPKColumn"] + "=@childId";

            adapter.DeleteCommand = new SqlCommand(command, sqlConnection);
            adapter.DeleteCommand.Parameters.Add("@childId", SqlDbType.Int).Value = childId;

            try
            {
                sqlConnection.Open();
                int x = adapter.DeleteCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (x >= 1)
                {
                    MessageBox.Show("Joc sters cu succes.");
                    ClearFields();
                    ReloadChildData((int)parentDataGrid.SelectedRows[0].Cells[0].Value);
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
        }

        /////////////////////////////// <TODO>
        private void ClearFields()
        {
            nameField.Clear();
            playerNumField.Clear();
            statusCombo.Text = string.Empty;
            categoryCombo.Text = string.Empty;
            ageRatingCombo.Text = string.Empty;
            if (parentDataGrid.SelectedRows.Count != 0)
                devIdField.Text = parentDataGrid.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
