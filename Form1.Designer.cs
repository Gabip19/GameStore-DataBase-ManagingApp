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
            this.parentNameLabel = new System.Windows.Forms.Label();
            this.childNameLabel = new System.Windows.Forms.Label();
            this.childDataLabel = new System.Windows.Forms.Label();
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
            this.parentDataGrid.Location = new System.Drawing.Point(13, 55);
            this.parentDataGrid.Name = "parentDataGrid";
            this.parentDataGrid.ReadOnly = true;
            this.parentDataGrid.RowHeadersWidth = 51;
            this.parentDataGrid.Size = new System.Drawing.Size(417, 637);
            this.parentDataGrid.TabIndex = 0;
            this.parentDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ParentDataGrid_CellMouseClick);
            // 
            // childDataGrid
            // 
            this.childDataGrid.AllowUserToAddRows = false;
            this.childDataGrid.AllowUserToDeleteRows = false;
            this.childDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.childDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.childDataGrid.Location = new System.Drawing.Point(900, 55);
            this.childDataGrid.Name = "childDataGrid";
            this.childDataGrid.ReadOnly = true;
            this.childDataGrid.RowHeadersWidth = 51;
            this.childDataGrid.Size = new System.Drawing.Size(417, 637);
            this.childDataGrid.TabIndex = 1;
            this.childDataGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GamesDataGrid_CellMouseClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(616, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Refresh Date";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RefreshDataButton_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateBtn.Location = new System.Drawing.Point(611, 541);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(112, 38);
            this.updateBtn.TabIndex = 16;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(744, 541);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(112, 38);
            this.deleteBtn.TabIndex = 17;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(477, 541);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(112, 38);
            this.addBtn.TabIndex = 18;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // parentNameLabel
            // 
            this.parentNameLabel.AutoSize = true;
            this.parentNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parentNameLabel.Location = new System.Drawing.Point(122, 10);
            this.parentNameLabel.Name = "parentNameLabel";
            this.parentNameLabel.Size = new System.Drawing.Size(170, 33);
            this.parentNameLabel.TabIndex = 21;
            this.parentNameLabel.Text = "Dezvoltatori";
            // 
            // childNameLabel
            // 
            this.childNameLabel.AutoSize = true;
            this.childNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.childNameLabel.Location = new System.Drawing.Point(1060, 10);
            this.childNameLabel.Name = "childNameLabel";
            this.childNameLabel.Size = new System.Drawing.Size(94, 33);
            this.childNameLabel.TabIndex = 22;
            this.childNameLabel.Text = "Jocuri";
            // 
            // childDataLabel
            // 
            this.childDataLabel.AutoSize = true;
            this.childDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.childDataLabel.Location = new System.Drawing.Point(472, 94);
            this.childDataLabel.Name = "childDataLabel";
            this.childDataLabel.Size = new System.Drawing.Size(245, 29);
            this.childDataLabel.TabIndex = 23;
            this.childDataLabel.Text = "Date instanta JOCURI";
            // 
            // inputPanel
            // 
            this.inputPanel.Location = new System.Drawing.Point(477, 143);
            this.inputPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(379, 392);
            this.inputPanel.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 704);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.childDataLabel);
            this.Controls.Add(this.childNameLabel);
            this.Controls.Add(this.parentNameLabel);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.childDataGrid);
            this.Controls.Add(this.parentDataGrid);
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
        private System.Windows.Forms.Label parentNameLabel;
        private System.Windows.Forms.Label childNameLabel;
        private System.Windows.Forms.Label childDataLabel;
        private System.Windows.Forms.Panel inputPanel;
    }
}

