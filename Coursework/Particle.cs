using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework
{
    using System.Drawing; //чтобы использовать Grafics
    class Particle
    {
        public int Radius; //радуис частицы
        public float X;   //X координата положения частицы в пространстве
        public float Y;   //Y координата положения частицы в пространстве

        public float Direction; //направление движения
        public float Speed;     //скорость перемещения
        public Color color;
        public int Life;  //запас здоровья частицы

        public static Random rand = new Random();  //генератор случайных чисел
        
        //конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            X = rand.Next(840);
            Y = -20;
            Direction = 270 + (rand.Next(10) - 5);
            Speed = 1 + rand.Next(5);
            Radius = 2 + rand.Next(10);
            Life = 100 + rand.Next(500);  //исходный запас здоровья от 20 до 100
            if (X < 80) color = Color.FromArgb(Life / 5, Color.Red);
            else if (X < 160) color = Color.FromArgb(Life / 5, Color.Orange);
            else if (X < 240) color = Color.FromArgb(Life / 5, Color.Yellow);
            else if (X < 320) color = Color.FromArgb(Life / 5, Color.Green);
            else if (X < 400) color = Color.FromArgb(Life / 5, Color.AliceBlue);
            else if (X < 480) color = Color.FromArgb(Life / 5, Color.Blue);
            else color = Color.FromArgb(Life / 5, Color.Violet);
        }

        public void Draw(Graphics g)
        {
            //Кисть
            SolidBrush b = new SolidBrush(color);
            //нарисовали залитый кружок радиусом Radius с центром в X, Y
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            b.Dispose();  //удалили кисть из памяти
        }

        public void Update()
        {
            X = rand.Next(840);
            Y = -20;
            Direction = 270 + (rand.Next(10) - 5);
            Speed = 1 + rand.Next(5);
            Radius = 5 + rand.Next(10);
            Life = 100 + rand.Next(400);  //исходный запас здоровья от 20 до 100
            if (X < 80) color = Color.FromArgb(Life / 5, Color.Red);
            else if (X < 160) color = Color.FromArgb(Life / 5, Color.Orange);
            else if (X < 240) color = Color.FromArgb(Life / 5, Color.Yellow);
            else if (X < 320) color = Color.FromArgb(Life / 5, Color.Green);
            else if (X < 400) color = Color.FromArgb(Life / 5, Color.AliceBlue);
            else if (X < 480) color = Color.FromArgb(Life / 5, Color.Blue);
            else color = Color.FromArgb(Life / 5, Color.Violet);
        }
    }
}
