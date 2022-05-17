using System.Reflection;
using Plugin;

namespace CalculatorExtraVIPDiamond
{
    public partial class Form1 : Form
    {

        String path = @".\plugins"; // . bulunduðun klasörü ifade eder. 
        List<Type> islemler = new List<Type>();

        public Form1()
        {
            InitializeComponent();
            LoadAssemblies();

            createButtons();
                        
        }

        public void LoadAssemblies()
        {

            String[] paths = Directory.GetFiles(path,"*.dll"); // get every thing from the path ending with *.dll
                
            foreach (String lpath in paths)
            {
                //listBox1.Items.Add(lpath);
                
                Assembly assembly = Assembly.LoadFrom(lpath);
                Type[] t = assembly.GetTypes();
                foreach (Type t2 in t)
                {
                    
                    
                    if (t2.IsClass  && typeof(IHesap).IsAssignableFrom(t2)) // sýnýf ise ve IHesap ile iliþkili ile 
                    {
                        //object obj = Activator.CreateInstance(t2); // bundan bir sýnýf oluþtur. 

                        islemler.Add(t2);
                        listBox1.Items.Add(t2);

                        

                    }
                }
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            IHesap obj = (IHesap)Activator.CreateInstance(islemler[listBox1.SelectedIndex]);

            int sonuc = obj.hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));

            label1.Text = sonuc.ToString();

        }


        public void createButtons()
        {

            Button toplama = new Button();
            toplama.Text = "+";
            toplama.Location = new Point(10,43);
            groupBox1.Controls.Add(toplama);
            toplama.Click += button_click; // adding a event to a dinamically created button. 

            Button cikarma = new Button();
            cikarma.Text = "-";
            cikarma.Location = new Point(10, 73);
            groupBox1.Controls.Add(cikarma);
            cikarma.Click += button_click;


            Button carpma = new Button();
            carpma.Text = "*";
            carpma.Location = new Point(10, 103);
            groupBox1.Controls.Add(carpma);
            carpma.Click += button_click;

            Button bolme = new Button();
            bolme.Text = "/";
            bolme.Location = new Point(10, 133);
            groupBox1.Controls.Add(bolme);
            bolme.Click += button_click;

        }

        public void button_click(object sender, EventArgs e)
        {
            // Creating a button of the sender and getting the text of the created object. 
            Button button = (Button)sender;
            String islemTipi = button.Text;

            int sonuc = 0;

            IHesap obj;

            // switching the variable based on the text of the button
            switch (islemTipi)
            {
                case "+":
                   obj = (IHesap)Activator.CreateInstance(islemler[3]);
                    sonuc = obj.hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    break;
                case "-":
                    obj = (IHesap)Activator.CreateInstance(islemler[2]);
                    sonuc = obj.hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    break;

                case "*":
                    obj = (IHesap)Activator.CreateInstance(islemler[1]);
                    sonuc = obj.hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    break;

                case "/":
                    obj = (IHesap)Activator.CreateInstance(islemler[0]);
                    sonuc = obj.hesapla(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                    break;
                
            }

            label1.Text = sonuc.ToString();


        }

        

       
    }
}