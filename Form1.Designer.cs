namespace PBByME_V1._0
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeContactInfoButton = new System.Windows.Forms.PictureBox();
            this.findContactButton = new System.Windows.Forms.PictureBox();
            this.deleteContactButton = new System.Windows.Forms.PictureBox();
            this.addContactButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeContactInfoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.findContactButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteContactButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addContactButton)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PowderBlue;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_column,
            this.name_column,
            this.phone_column});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(185, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(835, 641);
            this.dataGridView1.TabIndex = 4;
            // 
            // id_column
            // 
            this.id_column.FillWeight = 50F;
            this.id_column.Frozen = true;
            this.id_column.HeaderText = "ID";
            this.id_column.MinimumWidth = 6;
            this.id_column.Name = "id_column";
            this.id_column.ReadOnly = true;
            this.id_column.Width = 63;
            // 
            // name_column
            // 
            this.name_column.FillWeight = 75F;
            this.name_column.HeaderText = "Name";
            this.name_column.MinimumWidth = 6;
            this.name_column.Name = "name_column";
            this.name_column.ReadOnly = true;
            this.name_column.Width = 350;
            // 
            // phone_column
            // 
            this.phone_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phone_column.HeaderText = "Phone Number";
            this.phone_column.MinimumWidth = 6;
            this.phone_column.Name = "phone_column";
            this.phone_column.ReadOnly = true;
            // 
            // changeContactInfoButton
            // 
            this.changeContactInfoButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.changeContactInfoButton.Image = global::PBByME_V1._0.Properties.Resources.change_contactInfo_img;
            this.changeContactInfoButton.Location = new System.Drawing.Point(15, 498);
            this.changeContactInfoButton.Name = "changeContactInfoButton";
            this.changeContactInfoButton.Size = new System.Drawing.Size(155, 155);
            this.changeContactInfoButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.changeContactInfoButton.TabIndex = 3;
            this.changeContactInfoButton.TabStop = false;
            // 
            // findContactButton
            // 
            this.findContactButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findContactButton.Image = global::PBByME_V1._0.Properties.Resources.find_contact_img;
            this.findContactButton.Location = new System.Drawing.Point(15, 337);
            this.findContactButton.Name = "findContactButton";
            this.findContactButton.Size = new System.Drawing.Size(155, 155);
            this.findContactButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.findContactButton.TabIndex = 2;
            this.findContactButton.TabStop = false;
            // 
            // deleteContactButton
            // 
            this.deleteContactButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deleteContactButton.Image = global::PBByME_V1._0.Properties.Resources.delete_contact_img;
            this.deleteContactButton.Location = new System.Drawing.Point(15, 176);
            this.deleteContactButton.Name = "deleteContactButton";
            this.deleteContactButton.Size = new System.Drawing.Size(155, 155);
            this.deleteContactButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteContactButton.TabIndex = 1;
            this.deleteContactButton.TabStop = false;
            this.deleteContactButton.Click += new System.EventHandler(this.DeleteContactButton_Click);
            // 
            // addContactButton
            // 
            this.addContactButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addContactButton.Image = global::PBByME_V1._0.Properties.Resources.add_contact_img;
            this.addContactButton.Location = new System.Drawing.Point(15, 15);
            this.addContactButton.Name = "addContactButton";
            this.addContactButton.Size = new System.Drawing.Size(155, 155);
            this.addContactButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.addContactButton.TabIndex = 0;
            this.addContactButton.TabStop = false;
            this.addContactButton.Click += new System.EventHandler(this.AddContactButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1032, 660);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.changeContactInfoButton);
            this.Controls.Add(this.findContactButton);
            this.Controls.Add(this.deleteContactButton);
            this.Controls.Add(this.addContactButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PBByME v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changeContactInfoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.findContactButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteContactButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addContactButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox addContactButton;
        private System.Windows.Forms.PictureBox deleteContactButton;
        private System.Windows.Forms.PictureBox findContactButton;
        private System.Windows.Forms.PictureBox changeContactInfoButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone_column;
    }
}

