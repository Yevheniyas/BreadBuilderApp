using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BreadBuilderLibrary;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BreadBuilderApp
{
    public partial class Form1 : Form
    {
        private Director _director;
        private IBuilder _builder;
        public Form1()
        {
            InitializeComponent();
            _builder = new ConcreteBuilder();  // Ініціалізуємо конкретний будівельник
            _director = new Director(_builder);  // Ініціалізуємо директор для управління процесом
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Читання введених значень з TextBox
            string flour = textBox1.Text;
            string water = textBox2.Text;
            string yeast = textBox3.Text;
            string bakingTime = textBox4.Text;

            // Встановлення інгредієнтів в будівельника
            _builder.SetFlour(flour);
            _builder.SetWater(water);
            _builder.SetYeast(yeast);
            _builder.SetBakingTime(bakingTime);

            // Початок процесу будівництва хліба
            _director.Construct();

            // Отримання готового хліба
            Bread bread = _builder.GetResult();

            // Виведення результату
            MessageBox.Show($"Bread is ready: {bread.Flour}, {bread.Water}, {bread.Yeast}, {bread.BakingTime}");

            // Імітація процесу випікання з оновленням ProgressBar
            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(30);  // Затримка для імітації процесу
            }

            // Випікання
            bread.Bake();
        }
    }
    
}
