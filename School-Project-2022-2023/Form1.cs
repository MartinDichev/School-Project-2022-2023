using System.Reflection;

namespace School_Project_2022_2023
{
    public partial class Form1 : Form
    {
        public Random random = new Random();

        public string state = "wokring";
        public const int RectangleSleepTime = 3000;
        public const int CircleSleepTime = 4000;
        public const int TriangleSleepTime = 2000;
        public int FiguresCount = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(printCircle));
        }
        public void printCircle(object obj)
        {
            while (this.state != "stop")
            {
                this.CreateGraphics()
                    .DrawEllipse(new Pen(CollorBrush()), new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), random.Next(0, 70), random.Next(0, 70)));
                this.FiguresCount++;

                Thread.Sleep(CircleSleepTime);
            }
        }
       
        private void btnRectangle_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(printRectangle));
        }
        public void printRectangle(object obj)
        {
            while (this.state != "stop")
            {
                this.CreateGraphics()
                    .DrawRectangle(new Pen(CollorBrush()), new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), random.Next(0, 70), random.Next(0, 70)));
                this.FiguresCount++;

                Thread.Sleep(RectangleSleepTime);
            }
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(printTriangle));
        }

        public void printTriangle(object obj)
        {

        }
        private Brush CollorBrush()
        {
            Brush result = Brushes.Transparent;

            Random rnd = new Random();

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
    }
}