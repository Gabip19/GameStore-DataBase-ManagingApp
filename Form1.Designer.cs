namespace SGBD_Jocuri_DB
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parentDataGrid = new System.Windows.Forms.DataGridView();
            this.childDataGrid = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.inputPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.parentDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // parentDataGrid
            // 
            this.parentDataGrid.AllowUserToAddRows = false;
            this.parentDataGrid.AllowUserToDeleteRows = false;
            this.parentDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.parentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parentDataGrid.Location = new System.Drawing.Point(17, 68);
            this.parentDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.parentDataGrid.Name = "parentDataGrid";
            this.parentDataGrid.ReadOnly = true;
            this.parentDataGrid.RowHeadersWidth = 51;
            this.parentDataGrid.Size = new System.Drawing.Size(556, 784);
            this.parentDataGrid.TabIndex = 0;
            this.parentDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ParentDataGrid_CellMouseClick);
            // 
            // childDataGrid
            // 
            this.childDataGrid.AllowUserToAddRows = false;
            this.childDataGrid.AllowUserToDeleteRows = false;
            this.childDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.childDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childDataGrid.Location = new System.Drawing.Point(1200, 68);
            this.childDataGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.childDataGrid.Name = "childDataGrid";
            this.childDataGrid.ReadOnly = true;
            this.childDataGrid.RowHeadersWidth = 51;
            this.childDataGrid.Size = new System.Drawing.Size(556, 784);
            this.childDataGrid.TabIndex = 1;
            this.childDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GamesDataGrid_CellMouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(821, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 43);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh Date";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RefreshDataButton_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(815, 666);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(149, 47);
            this.updateBtn.TabIndex = 16;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(992, 666);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(149, 47);
            this.deleteBtn.TabIndex = 17;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(636, 666);
            this.addBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(149, 47);
            this.addBtn.TabIndex = 18;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(163, 12);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(215, 42);
            this.label8.TabIndex = 21;
            this.label8.Text = "Dezvoltatori";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1413, 12);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 42);
            this.label9.TabIndex = 22;
            this.label9.Text = "Jocuri";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(787, 118);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(203, 36);
            this.label10.TabIndex = 23;
            this.label10.Text = "Date joc video";
            // 
            // inputPanel
            // 
            this.inputPanel.Location = new System.Drawing.Point(636, 176);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(505, 483);
            this.inputPanel.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1772, 866);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.childDataGrid);
            this.Controls.Add(this.parentDataGrid);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.parentDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView parentDataGrid;
        private System.Windows.Forms.DataGridView childDataGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel inputPanel;
    }
}

