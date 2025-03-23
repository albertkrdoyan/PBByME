using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PBByME_V1_0
{
    public partial class Form1 : Form
    {
        private PhoneBookSqlManager pb;
        public Form1()
        {
            InitializeComponent();
        }

        private void MainFormClosing(Object sender, FormClosingEventArgs e)
        {
            pb.PCloseDB();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pb = new PhoneBookSqlManager();

            pb.UpdateDataGrid(ref dataGridView1);
        }

        private void AddEditContactButton_Click(object sender, EventArgs e, DataGridView dgv)
        {
            bool isadd = ((PictureBox)sender).Name == "addContactButton";

            if (!isadd && dgv.Rows.Count == 0) return;

            int id = isadd ? -1 : Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            Form contact_form = new Form
            {
                Size = new Size(490, 310),
                StartPosition = FormStartPosition.CenterParent,
                BackColor = Color.FromArgb(255, 154, 189, 245),
                Text = isadd ? "Add new contact" : "Edit contact",
                Name = "contact_form",
                MaximizeBox = false,
                ShowIcon = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            int st_x = 0, width = 200, height = 25, distance = 15, tb_width = contact_form.Width - st_x - distance - (int)(width * 1.15);
            Font font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular);

            Label f_name_label = new Label
            {
                Font = font,
                Location = new Point(st_x, distance),
                ForeColor = Color.Black,
                Text = "First Name: ",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label m_name_label = new Label
            {
                Font = font,
                Location = new Point(st_x, f_name_label.Location.Y + f_name_label.Height + distance),
                ForeColor = Color.Black,
                Text = "Middle Name: ",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label l_name_label = new Label
            {
                Font = font,
                Location = new Point(st_x, m_name_label.Location.Y + m_name_label.Height + distance),
                ForeColor = Color.Black,
                Text = "Last Name: ",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleRight
            };

            Label phone_num_label = new Label
            {
                Font = font,
                Location = new Point(st_x, l_name_label.Location.Y + l_name_label.Height + distance),
                ForeColor = Color.Black,
                Text = "Phone Number: ",
                Size = new Size(width, height),
                TextAlign = ContentAlignment.MiddleRight
            };

            TextBox f_name_textbox = new TextBox
            {
                Font = font,
                Size = new Size(tb_width, height),
                Location = new Point(f_name_label.Location.X + f_name_label.Width + distance,
                                    f_name_label.Location.Y),
                Name = "f_name_textbox",
                Text = isadd ? "" : pb.ListP[id].FirstName
            };

            TextBox m_name_textbox = new TextBox
            {
                Font = font,
                Size = new Size(tb_width, height),
                Location = new Point(m_name_label.Location.X + m_name_label.Width + distance,
                                    m_name_label.Location.Y),
                Name = "m_name_textbox",
                Text = isadd ? "" : pb.ListP[id].MiddleName
            };

            TextBox l_name_textbox = new TextBox
            {
                Font = font,
                Size = new Size(tb_width, height),
                Location = new Point(l_name_label.Location.X + l_name_label.Width + distance,
                                    l_name_label.Location.Y),
                Name = "l_name_textbox",
                Text = isadd ? "" : pb.ListP[id].LastName
            };

            MaskedTextBox phone_number_textbox = new MaskedTextBox
            {
                Font = font,
                Location = new Point(phone_num_label.Location.X + phone_num_label.Width + distance,
                                    phone_num_label.Location.Y),
                Size = new Size(tb_width, height),
                Mask = "+(999) 00-00-00-00",
                Name = "phone_number_textbox",
                Text = isadd ? "" : pb.ListP[id].PhoneNumber
            };

            Button confirm_button = new Button
            {
                Size = new Size(width, (int)(height * 2.75)),
                Location = new Point(phone_number_textbox.Location.X - width, phone_num_label.Location.Y + phone_num_label.Height + distance * 2),
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.confirm_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                UseVisualStyleBackColor = true
            };

            Button close_button = new Button
            {
                Size = new Size(tb_width, (int)(height * 2.75)),
                Location = new Point(phone_number_textbox.Location.X, phone_num_label.Location.Y + phone_num_label.Height + distance * 2),
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.close_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                UseVisualStyleBackColor = true
            };

            confirm_button.Click += isadd ? 
                new EventHandler(Confirm_Add_button_click) 
                :
                delegate (object _sender, EventArgs _e) 
                {
                    Confirm_Edit_button_click(_sender, _e, dgv); 
                };
            
            close_button.MouseClick += new MouseEventHandler(Close_button_click);

            contact_form.Controls.Add(f_name_label);
            contact_form.Controls.Add(m_name_label);
            contact_form.Controls.Add(l_name_label);
            contact_form.Controls.Add(phone_num_label);
            contact_form.Controls.Add(f_name_textbox);
            contact_form.Controls.Add(m_name_textbox);
            contact_form.Controls.Add(l_name_textbox);
            contact_form.Controls.Add(phone_number_textbox);
            contact_form.Controls.Add(confirm_button);
            contact_form.Controls.Add(close_button);
            contact_form.ShowDialog();
        }

        private void Close_button_click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Button button = (Button)(sender);
            button.Parent.Hide();
        }

        private void Confirm_Add_button_click(object sender, EventArgs e)
        {
            Button button = (Button)(sender);

            string f_name = button.Parent.Controls.Find("f_name_textbox", true).FirstOrDefault().Text as string;
            string m_name = button.Parent.Controls.Find("m_name_textbox", true).FirstOrDefault().Text as string;
            string l_name = button.Parent.Controls.Find("l_name_textbox", true).FirstOrDefault().Text as string;
            string p_numb = button.Parent.Controls.Find("phone_number_textbox", true).FirstOrDefault().Text as string;

            pb.AddUser(f_name, m_name, l_name, p_numb);

            dataGridView1.Rows.Add(pb.ListP[pb.LastID].ID, pb.ListP[pb.LastID].FullName, pb.ListP[pb.LastID].PhoneNumber);

            button.Parent.Hide();
        }

        private void Confirm_Edit_button_click(object sender, EventArgs e, DataGridView dgv)
        {
            Button button = (Button)(sender);

            string f_name = button.Parent.Controls.Find("f_name_textbox", true).FirstOrDefault().Text as string;
            string m_name = button.Parent.Controls.Find("m_name_textbox", true).FirstOrDefault().Text as string;
            string l_name = button.Parent.Controls.Find("l_name_textbox", true).FirstOrDefault().Text as string;
            string p_numb = button.Parent.Controls.Find("phone_number_textbox", true).FirstOrDefault().Text as string;

            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);
            pb.EditUser(id, f_name, m_name, l_name, p_numb);

            dgv.SelectedRows[0].Cells[1].Value = pb.ListP[id].FullName;
            dgv.SelectedRows[0].Cells[2].Value = pb.ListP[id].PhoneNumber;

            if (dgv.Name == "resultDGV")
            {
                string str_id = id.ToString();
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == str_id)
                    {
                        dataGridView1.Rows[i].Cells[1].Value = pb.ListP[id].FullName;
                        dataGridView1.Rows[i].Cells[2].Value = pb.ListP[id].PhoneNumber;
                        break;
                    }
                }
            }

            button.Parent.Hide();
        }

        private void DeleteContactButton_Click(object sender, EventArgs e, DataGridView dgv)
        {
            if (dgv.Rows.Count == 0) return;

            int index = dgv.SelectedRows[0].Index;
            int id = Convert.ToInt32(dgv.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show($"Are you sure you want to delete \"{dgv.Rows[index].Cells[1].Value}, {dgv.Rows[index].Cells[2].Value}\" contact from the list?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                pb.RemoveContact(id);
                dgv.Rows.RemoveAt(index);

                if (dgv.Name == "resultDGV")
                {
                    string str_id = id.ToString();
                    for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == str_id)
                        {
                            dataGridView1.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
        }

        private void FindContactButton_Click(object sender, EventArgs e)
        {
            int form_width = 850, form_height = 500;
            int st_x = 25, st_y = 25, dist = 10;

            Font font = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular);

            Form find_contacts_form = new Form
            {
                Name = "find_contacts_form",
                Text = "Find contact",
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(form_width, form_height),
                BackColor = this.BackColor,
                MaximizeBox = false,
                ShowIcon = false,
                FormBorderStyle = FormBorderStyle.FixedDialog
            };

            Label p_number_label = new Label
            {
                Name = "p_number_label",
                Text = "Phone number: ",
                Font = font,
                Location = new Point(st_x, st_y),
                Size = new Size(150, 25),
            };

            MaskedTextBox phone_number_textbox = new MaskedTextBox
            {
                Name = "phone_number_textbox",
                Font = font,
                Location = new Point(st_x + p_number_label.Width + dist, st_y - 3),
                Width = 180,
                Mask = "+(999) 00-00-00-00",
                TabIndex = 1
            };

            Label name_label = new Label
            {
                Name = "name_label",
                Text = "or/and Name: ",
                Font = p_number_label.Font,
                Size = p_number_label.Size,
                Location = new Point(phone_number_textbox.Location.X + phone_number_textbox.Width + dist, st_y),
            };

            TextBox name_textbox = new TextBox
            {
                Name = "name_textbox",
                Location = new Point(name_label.Location.X + name_label.Width + dist, phone_number_textbox.Location.Y),
                Size = new Size((int)(phone_number_textbox.Width * 1.5), phone_number_textbox.Height),
                Font = font,
                TabIndex = 0
            };

            Button find_button = new Button
            {
                Name = "find_button",
                Size = new Size((int)(form_width / 2.5), (int)(p_number_label.Height * 2.5)),
                Location = new Point((form_width - (int)(form_width / 2.5)) / 2, phone_number_textbox.Location.Y + phone_number_textbox.Height + dist),
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.find_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                UseVisualStyleBackColor = true,
                TabIndex = 2
            };

            DataGridView resultDGV = new DataGridView
            {
                Name = "resultDGV",
                Size = new Size(form_width - 3 * st_x, (int)(form_height / 2.2)),
                Location = new Point(st_x, dist + find_button.Location.Y + find_button.Height),
                TabIndex = 3,
                AllowDrop = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                BackgroundColor = dataGridView1.BackgroundColor,
                CellBorderStyle = dataGridView1.CellBorderStyle,
                ClipboardCopyMode = dataGridView1.ClipboardCopyMode,
                ColumnHeadersDefaultCellStyle = dataGridView1.ColumnHeadersDefaultCellStyle,
                ColumnHeadersHeightSizeMode = dataGridView1.ColumnHeadersHeightSizeMode,
                GridColor = System.Drawing.SystemColors.ActiveCaptionText,
                ImeMode = System.Windows.Forms.ImeMode.NoControl,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                RowHeadersWidth = 51,
                RowsDefaultCellStyle = dataGridView1.RowsDefaultCellStyle,
                ScrollBars = System.Windows.Forms.ScrollBars.Vertical,
                SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect,
            };

            DataGridViewTextBoxColumn f_id_column = new DataGridViewTextBoxColumn
            {
                FillWeight = 50F,
                Frozen = true,
                HeaderText = "ID",
                MinimumWidth = 6,
                Name = "id_column",
                ReadOnly = true,
                Width = 63,
            };

            DataGridViewTextBoxColumn f_name_column = new DataGridViewTextBoxColumn
            {
                FillWeight = 75F,
                HeaderText = "Name",
                MinimumWidth = 6,
                Name = "name_column",
                ReadOnly = true,
                Width = 350,
            };

            DataGridViewTextBoxColumn f_phone_column = new DataGridViewTextBoxColumn
            {
                AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill,
                HeaderText = "Phone Number",
                MinimumWidth = 6,
                Name = "phone_column",
                ReadOnly = true
            };

            resultDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            f_id_column,
            f_name_column,
            f_phone_column});
            resultDGV.RowTemplate.Height = 27;

            Button found_contact_change_button = new Button
            {
                Name = "found_contact_change_button",
                Location = new Point(st_x, resultDGV.Location.Y + resultDGV.Height + dist),
                Size = new Size(form_width / 4, (int)(form_height / 7.3)),
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.change_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                TabIndex = 4
            };

            Button found_contact_delete_button = new Button
            {
                Name = "found_contact_delete_button",
                Location = new Point(found_contact_change_button.Location.X + found_contact_change_button.Width + dist, found_contact_change_button.Location.Y),
                Size = found_contact_change_button.Size,
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.delete_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                TabIndex = 5
            };

            Button cancel_button = new Button
            {
                Name = "cancel_button",
                Location = new Point(resultDGV.Location.X + resultDGV.Width - found_contact_change_button.Width, found_contact_change_button.Location.Y),
                Size = found_contact_change_button.Size,
                BackgroundImage = global::PBByME_V1_0.Properties.Resources.cancel_img,
                BackgroundImageLayout = ImageLayout.Zoom,
                TabIndex = 6
            };

            cancel_button.MouseClick += new MouseEventHandler(Close_button_click);
            find_button.MouseClick += new MouseEventHandler(Find_button_click);

            found_contact_change_button.Click += delegate (object _sender, EventArgs _e)
            {
                AddEditContactButton_Click(sender, e, resultDGV);
            };

            found_contact_delete_button.Click += delegate (object _sender, EventArgs _e)
            {
                DeleteContactButton_Click(_sender, _e, resultDGV);
            };

            find_contacts_form.Controls.Add(p_number_label);
            find_contacts_form.Controls.Add(phone_number_textbox);
            find_contacts_form.Controls.Add(name_label);
            find_contacts_form.Controls.Add(name_textbox);
            find_contacts_form.Controls.Add(find_button);
            find_contacts_form.Controls.Add(resultDGV);
            find_contacts_form.Controls.Add(found_contact_change_button);
            find_contacts_form.Controls.Add(found_contact_delete_button);
            find_contacts_form.Controls.Add(cancel_button);
            find_contacts_form.ShowDialog();
        }

        private void Find_button_click(object sender, MouseEventArgs e)
        {
            Button f_button = (Button)sender;

            string p_number = f_button.Parent.Controls.Find("phone_number_textbox", true).FirstOrDefault().Text as string;
            string name = f_button.Parent.Controls.Find("name_textbox", true).FirstOrDefault().Text as string;
            DataGridView dgv = f_button.Parent.Controls.Find("resultDGV", true).FirstOrDefault() as DataGridView;

            List<PhoneBookC> list = pb.Search(name.ToLower(), p_number);

            dgv.Rows.Clear();
            foreach (PhoneBookC data in list)
                dgv.Rows.Add(data.ID, data.FullName, data.PhoneNumber);
        }
    }
}
