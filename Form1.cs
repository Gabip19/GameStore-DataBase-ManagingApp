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

        public Form1()
        {
            InitializeComponent();
            InitializeParentGrid();
            InitializeChildGrid();
            CreateConnection();
            InitializeData();
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

        private void InitializeData()
        {
            adapter = new SqlDataAdapter();
            ds = new DataSet();

            ds.Tables.Add("DEZVOLTATORI");
            ds.Tables.Add("JOCURI");

            ReloadParentData();
            
            parentDataGrid.DataSource = ds.Tables["DEZVOLTATORI"];
            childDataGrid.DataSource = ds.Tables["JOCURI"];
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

        private void ParentDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int parentId = (int) parentDataGrid.SelectedRows[0].Cells[0].Value;
            devIdField.Text = parentId.ToString();
            ReloadChildData(parentId);
        }
        
        private void ReloadChildData(int parentId)
        {
            adapter.SelectCommand = new SqlCommand("SELECT * FROM JOCURI WHERE Did=@devId", sqlConnection);
            adapter.SelectCommand.Parameters.Add("@devId", SqlDbType.Int).Value = parentId;
            ds.Tables["JOCURI"].Clear();
            adapter.Fill(ds, "JOCURI");
        }

        private void ChildDataGrid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            int jid = (int)childDataGrid.SelectedRows[0].Cells[0].Value;

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
                    ReloadChildData((int)parentDataGrid.SelectedRows[0].Cells[0].Value);
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
            if (parentDataGrid.SelectedRows.Count != 0)
                devIdField.Text = parentDataGrid.SelectedRows[0].Cells[0].Value.ToString();
        }
    }
}
