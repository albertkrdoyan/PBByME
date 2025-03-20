using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBByME_V1._0
{
    public partial class Form1: Form
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

        private void AddEditContactButton_Click(object sender, EventArgs e)
        {
            bool isadd = ((PictureBox)sender).Name == "addContactButton";

            int id = isadd ? -1 : Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

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
                BackgroundImage = global::PBByME_V1._0.Properties.Resources.confirm_img,
                BackgroundImageLayout = ImageLayout.Zoom,
            };

            Button close_button = new Button
            {
                Size = new Size(tb_width, (int)(height * 2.75)),
                Location = new Point(phone_number_textbox.Location.X, phone_num_label.Location.Y + phone_num_label.Height + distance * 2),
                BackgroundImage = global::PBByME_V1._0.Properties.Resources.close_img,
                BackgroundImageLayout = ImageLayout.Zoom,
            };

            if (isadd) confirm_button.MouseClick += new MouseEventHandler(Confirm_Add_button_click);
            else confirm_button.MouseClick += new MouseEventHandler(Confirm_Edit_button_click);
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

        private void Confirm_Add_button_click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Button button = (Button)(sender);

            string f_name = button.Parent.Controls.Find("f_name_textbox", true).FirstOrDefault().Text as string;
            string m_name = button.Parent.Controls.Find("m_name_textbox", true).FirstOrDefault().Text as string;
            string l_name = button.Parent.Controls.Find("l_name_textbox", true).FirstOrDefault().Text as string;
            string p_numb = button.Parent.Controls.Find("phone_number_textbox", true).FirstOrDefault().Text as string;

            pb.AddUser(f_name, m_name, l_name, p_numb);

            dataGridView1.Rows.Add(pb.ListP[pb.LastID].ID, pb.ListP[pb.LastID].FullName, pb.ListP[pb.LastID].PhoneNumber);

            button.Parent.Hide();
        }

        private void Confirm_Edit_button_click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            Button button = (Button)(sender);

            string f_name = button.Parent.Controls.Find("f_name_textbox", true).FirstOrDefault().Text as string;
            string m_name = button.Parent.Controls.Find("m_name_textbox", true).FirstOrDefault().Text as string;
            string l_name = button.Parent.Controls.Find("l_name_textbox", true).FirstOrDefault().Text as string;
            string p_numb = button.Parent.Controls.Find("phone_number_textbox", true).FirstOrDefault().Text as string;

            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            pb.EditUser(id, f_name, m_name, l_name, p_numb);

            dataGridView1.SelectedRows[0].Cells[1].Value = pb.ListP[id].FullName;
            dataGridView1.SelectedRows[0].Cells[2].Value = pb.ListP[id].PhoneNumber;

            button.Parent.Hide();
        }

        private void DeleteContactButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0) return;

            int index = dataGridView1.SelectedRows[0].Index;
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            if (MessageBox.Show($"Are you sure you want to delete \"{dataGridView1.Rows[index].Cells[1].Value}, {dataGridView1.Rows[index].Cells[2].Value}\" contact from the list?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                pb.RemoveContact(id);
                dataGridView1.Rows.RemoveAt(index);
            }
        }
    }
}
