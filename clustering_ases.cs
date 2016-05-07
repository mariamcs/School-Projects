using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualBasic;



namespace clustering
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> list = new List<double>();
            double parentIQR = 0.02857143 - 0.01428571;
            double peer_firstIQR = 0;
            double child_firstIQR = 0;
            double parent_firstIQR = 0.01428571 - 1.5 * parentIQR;
            double parent_thirdIQR = 0.01428571 + 1.5 * parentIQR;

            var reader = new StreamReader(File.OpenRead(@"C:\Users\maryam\Desktop\data_parents_peers_childs_id.csv"));
            System.IO.StreamWriter minoutlierfile = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\minoutlierfile.txt");
            System.IO.StreamWriter maxoutlierfile = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\maxoutlierfile.txt");
            System.IO.StreamWriter removeOutlierfile = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\removeOutlier_withoutid.txt");

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                bool outlier = false;
                var line = reader.ReadLine();
                if (line.IndexOf("Peers") > 0)
                {
                    //do nothing
                }
                else
                {
                    var values = line.Split(',');
                    if (Convert.ToDouble(values[0]) < parent_firstIQR)
                    {
                        listA.Add(line);
                        minoutlierfile.WriteLine(line);
                        outlier = true;
                    }
                    if (Convert.ToDouble(values[0]) > parent_thirdIQR)
                    {
                        listB.Add(line);
                        maxoutlierfile.WriteLine(line);
                        outlier = true;
                    }
                    if (!outlier)
                    {
                        string newline = values[0] + "," + values[1] + "," + values[2];
                        removeOutlierfile.WriteLine(newline);
                    }
                }
            }

            label1.Text = "\n Done!";


        }
        public static String Find_Medium(List<double> list)
        {
            double Size = list.Count;
            double Final_Number = 0;
            if (Size % 2 == 0)
            {
                int HalfWay = list.Count / 2;
                double Value1 = Convert.ToDouble(list[HalfWay - 1].ToString());
                double Value2 = Convert.ToDouble(list[HalfWay - 1 + 1].ToString());
                double Number = Value1 + Value2;
                Final_Number = Number / 2;
            }
            else
            {
                int HalfWay = list.Count / 2;
                double Value1 = Convert.ToDouble(list[HalfWay].ToString());
                Final_Number = Value1;
            }
            return Convert.ToString(Final_Number);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList group5 = new ArrayList();
            ArrayList group4 = new ArrayList();
            ArrayList group3 = new ArrayList();
            ArrayList group2 = new ArrayList();
            ArrayList group1 = new ArrayList();
            var reader = new StreamReader(File.OpenRead(@"C:\Users\maryam\Desktop\mydata.txt"));

            System.IO.StreamWriter group5file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\group5file.txt");
            System.IO.StreamWriter group4file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\group4file.txt");
            System.IO.StreamWriter group3file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\group3file.txt");
            System.IO.StreamWriter group2file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\group2file.txt");
            System.IO.StreamWriter group1file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\group1file.txt");




            string sampleline2 = "149" + ",0,0.0123143788,0.5913236382,4";
            /*
             * string[] values = sampleline2.Split(',');
            if (values[4] == "4")
            {
                label1.Text += "\n yes";
            }
             */
            //label1.Text = "\n " + values[0] + "\n " + values[1] + "\n " + values[2] + "\n " + values[3];

            while (!reader.EndOfStream)
            {
                bool outlier = false;
                var line = reader.ReadLine();
                if (line.IndexOf("fit.cluster") > 0)
                {
                    //do nothing
                }
                else
                {
                    string[] values = line.Split(',');
                    string newline="";
                    if (values[4] == "5")
                    {
                       
                        newline = values[1]+","+values[2]+","+values[3];
                        group5.Add(newline);
                        group5file.WriteLine(line);
                    }
                    if (values[4] == "4")
                    {
                        
                        newline = values[1]+","+values[2]+","+values[3];
                        group4.Add(newline);
                        group4file.WriteLine(line);
                    }
                    if (values[4] == "3")
                    {
                        
                        newline = values[1]+","+values[2]+","+values[3];
                        group3.Add(newline);
                        group3file.WriteLine(line);
                    }
                    if (values[4] == "2")
                    {
                        
                        newline = values[1]+","+values[2]+","+values[3];
                        group2.Add(newline);
                        group2file.WriteLine(line);
                    }
                    if (values[4] == "1")
                    {
                        
                        newline = values[1]+","+values[2]+","+values[3];
                        group1.Add(newline);
                        group1file.WriteLine(line);
                    }
                }
            }

            /*foreach (string id in group4)
            {
                group4file.WriteLine(id);
            }
            foreach (string id in group2)
            {
                group2file.WriteLine(id);
            }*/

            label1.Text += "\n done";
            label1.Text += "\n group4 count " + group4.Count;
            label1.Text += "\n group2 count " + group2.Count;

            group1file.Close();
            group2file.Close();
            group3file.Close();
            group4file.Close();
            group5file.Close();


            var reader1 = new StreamReader(File.OpenRead(@"C:\Users\maryam\Desktop\normilized_data_parents_peers_childs_ids.csv"));


            System.IO.StreamWriter g5file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\g5fileID.txt");
            //System.IO.StreamWriter g4file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\g4fileID.txt");
            //System.IO.StreamWriter g3file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\g3fileID.txt");
            //System.IO.StreamWriter g2file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\g2fileID.txt");
            System.IO.StreamWriter g1file = new System.IO.StreamWriter(@"C:\Users\maryam\Desktop\g1fileID.txt");



            List<string> lines = new List<string>();
            while (!reader1.EndOfStream)
            {
                var line = reader1.ReadLine();
                lines.Add(line);
            }
            reader1.Close();



            foreach (string id in group5)
            {
                foreach (string l in lines)
                {
                    if (l.Contains(id))
                    {
                        g5file.WriteLine(l);
                    }
                }
            }


           /* foreach (string id in group4)
            {
                foreach (string l in lines)
                {
                    if (l.Contains(id))
                    {
                        g4file.WriteLine(l);
                    }
                }
            }

            foreach (string id in group3)
            {
                foreach (string l in lines)
                {
                    if (l.Contains(id))
                    {
                        g3file.WriteLine(l);
                    }
                }
            }

            foreach (string id in group2)
            {
                foreach (string l in lines)
                {
                    if (l.Contains(id))
                    {
                        g2file.WriteLine(l);
                    }
                }
            }*/

            foreach (string id in group1)
            {
                foreach (string l in lines)
                {
                    if (l.Contains(id))
                    {
                        g1file.WriteLine(l);
                        label1.Text += "\n" +l;
                    }
                }
            }

            g5file.Close();
            //g4file.Close();
            //g3file.Close();
            //g2file.Close();
            g1file.Close();

            label1.Text = "\n Finally";


        }

        private void button3_Click(object sender, EventArgs e)
        {
            var reader = new StreamReader(File.OpenRead(@"C:\Users\maryam\Desktop\normilized_data_parents_peers_childs_ids.txt"));

            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
            }

        }
    }
}
