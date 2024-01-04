using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTTH3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtPhuThuSuatDB_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void rbtn2D_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn3D.Checked)
            {
                {
                    label10.Visible = false;
                    txtGheDoi.Visible = false;
                    label9.Visible = true;
                    txtPhuThuSuatDB.Visible = true;
                }

            }
        }

        private void rbtn3D_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn2D.Checked)
            {
                {

                    label10.Visible = true;
                    txtGheDoi.Visible = true;
                    label9.Visible = false;
                    txtPhuThuSuatDB.Visible = false;
                }
            }
        }

        private void txtGheDoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Ban co chac muon thoat?", "Xac nhan thoat!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        void ResetTXT()
        {
            txtMaDon.Clear();
            txtMaDon.Focus();
            txtTenPhim.Clear();
            txtQuocGia.Clear();
            rbtnHanhDong.Checked = false;
            rbtnTinhCam.Checked = false;
            dtpNgayCongChieu.Value = DateTime.Now;
            txtTuoiQuiDinh.Clear();
            rbtn2D.Checked = false;
            rbtn3D.Checked = false;
            txtPhuThuSuatDB.Clear();
            txtGheDoi.Clear();
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(txtMaDon.Text)) || (string.IsNullOrEmpty(txtTenPhim.Text)) || (string.IsNullOrEmpty(txtQuocGia.Text)) || (string.IsNullOrEmpty(txtTuoiQuiDinh.Text)) || (string.IsNullOrEmpty(txtGheDoi.Text)))
            {
                MessageBox.Show("Vui lòng điền đủ thông tin");
            }
            else
            {
                ListViewItem li = new ListViewItem(txtMaDon.Text);
                li.SubItems.Add(txtTenPhim.Text);
                li.SubItems.Add(txtQuocGia.Text);
                li.SubItems.Add(rbtnTinhCam.Checked ? rbtnTinhCam.Text : rbtnHanhDong.Text);
                li.SubItems.Add(dtpNgayCongChieu.Text);
                li.SubItems.Add(txtTuoiQuiDinh.Text);
                li.SubItems.Add(rbtn2D.Checked ? rbtn2D.Text : rbtn3D.Text);
                li.SubItems.Add(txtGheDoi.Text);
                li.SubItems.Add(txtPhuThuSuatDB.Text);   
                ResetTXT();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvDanhSachPhim.SelectedItems.Count > 0)
            {
                int index = lvDanhSachPhim.SelectedItems[0].Index;
                lvDanhSachPhim.Items.RemoveAt(index);
            }
            else
            {
                ResetTXT();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMaDon.Enabled = true;
            txtTenPhim.Enabled = true;
            txtQuocGia.Enabled = true;
            txtTuoiQuiDinh.Enabled = true;
            txtPhuThuSuatDB.Enabled = true;
            dtpNgayCongChieu.Enabled = true;
            pnlTheLoai.Enabled = true;
            pnlDinhDang.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lvDanhSachPhim.SelectedItems.Count != 0)
            {
                ListViewItem li = lvDanhSachPhim.SelectedItems[0];
                li.SubItems[0].Text = txtMaDon.Text;
                li.SubItems[1].Text = txtTenPhim.Text;
                if (rbtnHanhDong.Checked)
                {
                    li.SubItems[2].Text = rbtnHanhDong.Text;
                }
                else
                {
                    li.SubItems[2].Text = rbtnTinhCam.Text;
                }
                li.SubItems[3].Text = dtpNgayCongChieu.Value.ToShortDateString();
                li.SubItems[4].Text = txtQuocGia.Text;
                li.SubItems[5].Text = txtTuoiQuiDinh.Text;
                if (rbtn3D.Checked)
                {
                    li.SubItems[6].Text = rbtn3D.Text;
                }
                else
                {
                    li.SubItems[6].Text = rbtn2D.Text;
                }
                li.SubItems[7].Text = txtPhuThuSuatDB.Text;

                ResetTXT();
            }
            else
            {

                ListViewItem li = new ListViewItem(txtMaDon.Text);
                li.SubItems.Add(txtTenPhim.Text);
                string theloai = rbtnTinhCam.Checked ? rbtnTinhCam.Text : rbtnHanhDong.Text;
                li.SubItems.Add(theloai);
                li.SubItems.Add(dtpNgayCongChieu.Value.ToShortDateString());
                li.SubItems.Add(txtQuocGia.Text);
                li.SubItems.Add(txtTuoiQuiDinh.Text);
                string dinhdang = rbtn2D.Checked ? rbtn2D.Text : rbtn3D.Text;
                li.SubItems.Add(dinhdang);
                li.SubItems.Add(txtPhuThuSuatDB.Text);

                lvDanhSachPhim.Items.Add(li);

                ResetTXT();
            }
        }
    }
}
