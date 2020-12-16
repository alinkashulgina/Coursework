using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Form1 : Form
    {

        float spCoef = 1;
        List<Particle> particles = new List<Particle>(); //список рандомных частиц

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height); //привязала изображение
            for (var i = 0; i < 300; ++i)
            {
                Particle particle = new Particle();
                particles.Add(particle);
            }
        }

        private void UpdateState()  //функцию обновления состояния системы (обновляется логика)
        {
            foreach (var particle in particles)
            {
                particle.Life -= (int)(5*spCoef);
                if (particle.Y > 450 || particle.Life < 0)  //если здоровье кончилось или частица вышла за пределы pictureBox
                {
                    particle.Update();
                }
                else { 
                    float directionInRadians = (float)(particle.Direction / 180 * Math.PI);
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians) * spCoef);
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians) * spCoef);
                }
            }
        }

        private void Render(Graphics g)   //функция рендеринга
        {
            foreach (var particle in particles)   //отрисовка частиц
            {
                particle.Draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();  //каждый тик обновляем систему
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);    //очистка
                Render(g);               //рендерим систему
            }
            picDisplay.Invalidate();     //обновить picDisplay
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            spCoef = trackBar1.Value * 0.2f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text.Equals("Стоп"))
            {
                timer1.Stop();
                button1.Text = "Пуск";
            }
            else
            {
                timer1.Start();
                button1.Text = "Стоп";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White);    //очистка
                Render(g);               //рендерим систему
            }
            picDisplay.Invalidate();
        }
    }
}
        
        
