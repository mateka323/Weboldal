using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace _19.Feladat_TicTacToe_
{
    public partial class Form1 : Form
    {
        private Button[,] gombok = new Button[3, 3]; //globalis valtozok, hogy a program barmely reszen elerhetoek legyenek
        private int szamlalo = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //gombok letrehozasa
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gombok[i, j] = new Button();
                    gombok[i, j].Location = new Point(j * 150, i * 150); // hely beallitasa a gomboknak
                    gombok[i, j].Size = new Size(150, 150); // meret beallitasa
                    gombok[i, j].Font = new Font("arial", 100); // betustilus es meret allitasa
                    gombok[i, j].Click += new EventHandler(Kattintas); // hozzaadok egy Kattintas nevu fuggvenyta a Click esemenyhez
                    this.Controls.Add(gombok[i, j]); // hozzaadom a gombokat Form-hoz
                }
            }

            //ablak beallitasa
            this.Text = ("Tic-Tac-Toe");
            this.ClientSize = new Size(450, 450);
            this.FormBorderStyle = FormBorderStyle.FixedSingle; //nem atmeretezheto ablak
            this.MaximizeBox = false; // nem lehet maximalizalni az ablakot
        }

        private void Kattintas(object sender, EventArgs e) // Kattintas fuggveny letrehozasa
        {
            Button b = (Button)sender; // beallitom a gombokra, hogy lehessen szoveget bele vinni
            if (b.Text == "") // ne tudjunk oda mas jelet rakni, ahol mar van egy
            {
                szamlalo++;
                if (szamlalo % 2 == 1)
                {
                    b.Text = "X"; // kattintasra beviszi a megadott szoveget
                }
                else
                {
                    b.Text = "O";
                }
                Ellenorzes();
            }
        }
        private void Ellenorzes()
        {
            string nyertes = "";
            // sorok
            for (int i = 0; i < 3; i++)
            {
                if (gombok[i, 0].Text == gombok[i, 1].Text &&
                    gombok[i, 1].Text == gombok[i, 2].Text &&
                    gombok[i, 0].Text != "")
                {
                    nyertes = gombok[i, 0].Text;
                }

            }
            // oszlopok
            for (int j = 0; j < 3; j++)
            {
                if (gombok[0, j].Text == gombok[1, j].Text &&
                    gombok[1, j].Text == gombok[2, j].Text &&
                    gombok[0, j].Text != "")
                {
                    nyertes = gombok[0, j].Text;
                }

            }
            // atlo "\"

            if (gombok[0, 0].Text == gombok[1, 1].Text &&
                gombok[1, 1].Text == gombok[2, 2].Text &&
                gombok[0, 0].Text != "")
            {
                nyertes = gombok[0, 0].Text;
            }
            // atlo "/"

            if (gombok[0, 2].Text == gombok[1, 1].Text &&
                gombok[1, 1].Text == gombok[2, 0].Text &&
                gombok[0, 2].Text != "")
            {
                nyertes = gombok[0, 2].Text;
            }
            // van e nyertes vagy dontetlen
            if (nyertes != "")
            {
                MessageBox.Show(nyertes + " nyert!", "Jatek vege");
                Ujrainditas();
            }
            else if (szamlalo == 9)
            {
                MessageBox.Show("Dontetlen", "Jatek vege");
                Ujrainditas();
            }
        }
        private void Ujrainditas()
        {
            szamlalo = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gombok[i, j].Text = "";
                }
            }
        }
    }
}
