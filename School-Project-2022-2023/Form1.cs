using System.Reflection;

namespace School_Project_2022_2023
{
    public partial class Form1 : Form
    {
        public Random random = new Random();

        public string state = "Working";
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
                    .DrawRectangle(new Pen(CollorBrush()), new Rectangle(random.Next(0, this.Width), random.Next(0, this.Height), random.Next(0, 60), random.Next(0, 70)));
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
            while (this.state != "stop")
            {
                PointF point1 = new PointF(new Random().Next(200, this.Width) + new Random().Next(10, 160), new Random().Next(0, this.Height - 50) + new Random().Next(10, 160));
                PointF point2 = new PointF(new Random().Next(200, this.Width) + new Random().Next(10, 160), new Random().Next(0, this.Height - 50) + new Random().Next(10, 160));
                PointF point3 = new PointF(new Random().Next(200, this.Width) + new Random().Next(10, 160), new Random().Next(0, this.Height - 50) + new Random().Next(10, 160));

                PointF[] curvePoints =
                {
                    point1,
                    point2,
                    point3,
                };

                this.CreateGraphics().DrawPolygon(new Pen(CollorBrush()), curvePoints);
                this.FiguresCount++;

                Thread.Sleep(TriangleSleepTime);
            }
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

        private void btnCount_Click(object sender, EventArgs e)
        {
                MessageBox.Show($"There are {this.FiguresCount} figures on the screen.");
        }
    }
}