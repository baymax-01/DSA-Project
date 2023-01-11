using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Graph_Clouring
{
    public partial class timetable : Form
    {
        public timetable()
        {
            InitializeComponent();
        }
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        private void timetable_Load(object sender, EventArgs e)
        {

        }
       static int sloting = 0;
        string date;
        string name;
        int semester = 1;
        private void btngenerate_Click(object sender, EventArgs e)
        {
            sloting = Convert.ToInt32(textBox2.Text);
            date = dateTimePicker1.Text;
            name = textBox1.Text;
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from coursedetails_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            DataSet dts = new DataSet();
            sda.Fill(dts, "Sorting");
            //count=dts.Tables["Sorting"].Rows.Count;
            List<string> arr1list = new List<string>();
            List<string> arr2list = new List<string>();
            foreach (DataRow row in dts.Tables["Sorting"].Rows)
            {
                arr1list.Add(row["courses_name"].ToString());
                //arr2list.Add(row["courses_name"].ToString());

            }
            string[] allelement = arr1list.ToArray();

            string[] arr1 = allelement[0].Split(' ');
            string[] arr2=null;
            string[] arr3=null;
            string[] arr4=null;
            string[] arr5=null;
            string[] arr6=null;
            
            for (int i = 1; i < allelement.Length; i++)
            {
                arr2 = allelement[1].Split(' ');

            }
            for (int i = 2; i < allelement.Length; i++)
            {
            arr3 = allelement[2].Split(' ');

            }
            for (int i = 3; i < allelement.Length; i++)
            {
                 arr4 = allelement[3].Split(' ');

            }
            for (int i = 4; i < allelement.Length; i++)
            {
                arr5 = allelement[4].Split(' ');

            }
            for (int i = 5; i < allelement.Length; i++)
            {
                arr6 = allelement[5].Split(' ');

            }
            
            Dictionary<string, List<string>> adj = new Dictionary<string, List<string>>();
            Dictionary<string, int> color = new Dictionary<string, int>();
            Initialize(arr1.Length, arr1, arr2.Length, arr2, arr3.Length, arr3, adj, color);

            // Scheduling the Slots
            int maxDays = -1;
            Dictionary<int, List<string>> examSchedule = Schedule(adj, color, ref maxDays);

            // Displaying the Results 
            Display(maxDays, examSchedule, name, semester);
        }

        static Dictionary<int, List<string>> Schedule(Dictionary<string, List<string>> adj, Dictionary<string, int> color, ref int maxDays)
        {
            Dictionary<int, List<string>> hash = new Dictionary<int, List<string>>();
            foreach (var vertex in adj)
            {
                if (!hash.ContainsKey(color[vertex.Key]))
                {
                    hash[color[vertex.Key]] = new List<string>();
                }
                hash[color[vertex.Key]].Add(vertex.Key);
                maxDays = Math.Max(maxDays, color[vertex.Key]);
            }

            int mx = int.MinValue;
            foreach (var ele in color)
            {
                mx = Math.Max(mx, ele.Value);
            }

            maxDays = mx;

            return hash;
        }

        public static void Initialize(int n1, string[] arr1, int n2, string[] arr2, int n3, string[] arr3, Dictionary<string, List<string>> adj, Dictionary<string, int> color)
        {
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (i != j)
                    {
                        if (adj.ContainsKey(arr1[i]))
                        {
                            adj[arr1[i]].Add(arr1[j]);
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            temp.Add(arr1[j]);
                            adj.Add(arr1[i], temp);
                        }
                    }
                }
            }

            for (int i = 0; i < n1; i++)
            {
                if (color.ContainsKey(arr1[i]))
                {

                }
                else
                {
                    color.Add(arr1[i], 1);
                }
            }

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (adj.ContainsKey(arr2[i]))
                    {
                        adj[arr2[i]].Add(arr1[j]);
                    }
                    else
                    {
                        List<string> temp = new List<string>();
                        temp.Add(arr1[j]);
                        adj.Add(arr2[i], temp);
                    }
                }
            }

            for (int i = 0; i < n2; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (i != j)
                    {
                        if (adj.ContainsKey(arr2[i]))
                        {
                            adj[arr2[i]].Add(arr2[j]);
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            temp.Add(arr2[j]);
                            adj.Add(arr2[i], temp);
                        }
                    }
                }
            }
            for (int i = 0; i < n2; i++)
            {
                if (color.ContainsKey(arr2[i]))
                {

                }
                else
                {
                    color.Add(arr2[i], 2);

                }
            }

            for (int i = 0; i < n3; i++)
            {
                for (int j = 0; j < n1; j++)
                {
                    if (adj.ContainsKey(arr3[i]))
                    {
                        adj[arr3[i]].Add(arr1[j]);
                    }
                    else
                    {
                        List<string> temp = new List<string>();
                        temp.Add(arr1[j]);
                        adj.Add(arr3[i], temp);
                    }
                }
            }

            for (int i = 0; i < n3; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (adj.ContainsKey(arr3[i]))
                    {
                        adj[arr3[i]].Add(arr2[j]);
                    }
                    else
                    {
                        List<string> temp = new List<string>();
                        temp.Add(arr2[j]);
                        adj.Add(arr3[i], temp);
                    }
                }
            }

            for (int i = 0; i < n3; i++)
            {
                for (int j = 0; j < n3; j++)
                {
                    if (i != j)
                    {
                        if (adj.ContainsKey(arr3[i]))
                        {
                            adj[arr3[i]].Add(arr3[j]);
                        }
                        else
                        {
                            List<string> temp = new List<string>();
                            temp.Add(arr3[j]);
                            adj.Add(arr3[i], temp);
                        }
                    }
                }
            }

            for (int i = 0; i < n3; i++)
            {
                if (color.ContainsKey(arr3[i]))
                {

                }
                else
                {
                    color.Add(arr3[i], 3);

                }
            }
        }




        static void Display(int days, Dictionary<int, List<string>> hash, string name, int semester)
        {
            //days = 7;
            FileStream file = new FileStream("schedule.txt",FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter writer = new StreamWriter(file,Encoding.UTF8);
            writer.WriteLine("\n\t\t\tNumber of Days to take Examinations would be: {0}\n", days);
            writer.WriteLine("\n\n\t\t----------------------------- Examination Schedule ------------------------------");
            writer.WriteLine("\n\n\t\t\t\t\tCollege: {0}\tSemester: {1}", name, (semester == 1 ? "ODD" : "EVEN"));
            int day_cnt = 1, slot_cnt = 1;
            writer.WriteLine("\n\n\t\t\t-----------------------Day {0}-----------------------\n\n", day_cnt);
            int slots = sloting;


            foreach (var it in hash)
            {
                writer.Write("\t\t\t\tSlot {0} -> ", slot_cnt);
                foreach (var k in it.Value)
                {
                    writer.Write("{0} , ", k);
                }
                writer.WriteLine();
                slot_cnt++;
                if (slot_cnt > slots)
                {
                    day_cnt++;
                    slot_cnt = 1;
                    writer.WriteLine("\n\t\t\t-----------------------Day {0}-----------------------\n\n", day_cnt);
                }
            }











            writer.Close();
            file.Close();
       
          
           
        }









    }

}
