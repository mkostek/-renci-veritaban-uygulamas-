/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: MERT
 * Tarih: 8.11.2019
 * Zaman: 21:21
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ogrenciUygulaması
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		SqlConnection con;
		object dsTables;
		DataSet ds;
		SqlCommand cmd;
		SqlDataAdapter da;
		void griddoldur()
		{
			con = new SqlConnection("server=.;Initial Catalog=okul;Integrated Security=True;");
			da = new SqlDataAdapter("select *from ogrenci", con);
			ds = new DataSet();
			con.Open();
			da.Fill(ds, "ogrenci");
			dataGridView1.DataSource = (ds).Tables["ogrenci"];
			con.Close();
		}
		void temizle(){
			for (int i = 0; i < this.Controls.Count; i++) {//for ile formdaki bütün kontrolleri dolaşıyoruz
				Control a = this.Controls[i];
				if (a is TextBox)//eğer a bir yazıkutusuysa
					a.Text = "";//a bomboş olsun
			}
		}
		void MainFormLoad(object sender, EventArgs e)
		{
			griddoldur();
		}
		void Button1Click(object sender, EventArgs e)
		{
			cmd = new SqlCommand();
			con.Open();
			cmd.Connection = con;
			cmd.CommandText = "insert into ogrenci(ogrenci_ad,ogrenci_soyad,ogrenci_sehir) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
			cmd.ExecuteNonQuery();
			con.Close();
			griddoldur();temizle();
		}
		void Button3Click(object sender, EventArgs e)
		{
			cmd =new SqlCommand();
			con.Open();
			cmd.Connection= con;
			cmd.CommandText="update ogrenci set ogrenci_ad='"+ textBox2.Text+"',ogrenci_soyad='"+ textBox3.Text+"',ogrenci_sehir='"+ textBox4.Text+"' where ogrenci_no="+textBox1.Text+"";
			cmd.ExecuteNonQuery();
			con.Close();
			griddoldur();temizle();
		}
		void Button2Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Length!=0){
			cmd =new SqlCommand();
			con.Open();
			cmd.Connection= con;
			cmd.CommandText="delete from ogrenci where ogrenci_no="+textBox1.Text+"";
			cmd.ExecuteNonQuery();
			con.Close();
			griddoldur();temizle();
			}
		
		}
		void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int satır=e.RowIndex;//önce satırın bulunduğu index i alıyoruz
			textBox1.Text=dataGridView1.Rows[satır].Cells[0].Value.ToString();//sonrada yazı kutularına hücreleri aktarıyoruz
			textBox2.Text=dataGridView1.Rows[satır].Cells[1].Value.ToString();
			textBox3.Text=dataGridView1.Rows[satır].Cells[2].Value.ToString();
			textBox4.Text=dataGridView1.Rows[satır].Cells[3].Value.ToString();
			
		}
	}
}
