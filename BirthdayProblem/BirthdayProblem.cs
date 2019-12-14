using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BirthdayProblem
{
    public partial class BirthdayProblem : Form
    {
        public BirthdayProblem()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView50.Rows.Add("January");
            dataGridView50.Rows.Add("February");
            dataGridView50.Rows.Add("March");
            dataGridView50.Rows.Add("April");
            dataGridView50.Rows.Add("May");
            dataGridView50.Rows.Add("June");
            dataGridView50.Rows.Add("July");
            dataGridView50.Rows.Add("August");
            dataGridView50.Rows.Add("September");
            dataGridView50.Rows.Add("October");
            dataGridView50.Rows.Add("November");
            dataGridView50.Rows.Add("December");

            dataGridView100.Rows.Add("January");
            dataGridView100.Rows.Add("February");
            dataGridView100.Rows.Add("March");
            dataGridView100.Rows.Add("April");
            dataGridView100.Rows.Add("May");
            dataGridView100.Rows.Add("June");
            dataGridView100.Rows.Add("July");
            dataGridView100.Rows.Add("August");
            dataGridView100.Rows.Add("September");
            dataGridView100.Rows.Add("October");
            dataGridView100.Rows.Add("November");
            dataGridView100.Rows.Add("December");

            dataGridView250.Rows.Add("January");
            dataGridView250.Rows.Add("February");
            dataGridView250.Rows.Add("March");
            dataGridView250.Rows.Add("April");
            dataGridView250.Rows.Add("May");
            dataGridView250.Rows.Add("June");
            dataGridView250.Rows.Add("July");
            dataGridView250.Rows.Add("August");
            dataGridView250.Rows.Add("September");
            dataGridView250.Rows.Add("October");
            dataGridView250.Rows.Add("November");
            dataGridView250.Rows.Add("December");

            dataGridView1000.Rows.Add("January");
            dataGridView1000.Rows.Add("February");
            dataGridView1000.Rows.Add("March");
            dataGridView1000.Rows.Add("April");
            dataGridView1000.Rows.Add("May");
            dataGridView1000.Rows.Add("June");
            dataGridView1000.Rows.Add("July");
            dataGridView1000.Rows.Add("August");
            dataGridView1000.Rows.Add("September");
            dataGridView1000.Rows.Add("October");
            dataGridView1000.Rows.Add("November");
            dataGridView1000.Rows.Add("December");

            dataGridViewResult.Rows.Add("Step 1");
            dataGridViewResult.Rows.Add("Step 2");
            dataGridViewResult.Rows.Add("Step 3");
            dataGridViewResult.Rows.Add("Step 4");
            dataGridViewResult.Rows.Add("Step 5");
            dataGridViewResult.Rows.Add("Step 6");
            dataGridViewResult.Rows.Add("Step 7");
            dataGridViewResult.Rows.Add("Step 8");
            dataGridViewResult.Rows.Add("Step 9");
            dataGridViewResult.Rows.Add("Step 10");
            dataGridViewResult.Rows.Add("Step 11");
            dataGridViewResult.Rows.Add("Step 12");
            dataGridViewResult.Rows.Add("Step 13");
            dataGridViewResult.Rows.Add("Step 14");
            dataGridViewResult.Rows.Add("Step 15");
            dataGridViewResult.Rows.Add("Step 16");
            dataGridViewResult.Rows.Add("Step 17");
            dataGridViewResult.Rows.Add("Step 18");
            dataGridViewResult.Rows.Add("Step 19");
            dataGridViewResult.Rows.Add("Step 20");
            dataGridViewResult.Rows.Add("Total");
        }

        private Random gen = new Random();
        public DateTime RandomDay()
        {
            DateTime start = new DateTime(2017, 11, 5);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }


        List<string> temp = new List<string>();
        List<int> matchCount = new List<int>();
        List<string> matchedDate = new List<string>();

        int totalMatchCount = 0;

        public void experiment(int peopleCount)
        {
            progressBar1.Value = 0;

            for (int circleInt = 0; circleInt < 20; circleInt++)
            {
                for (int i = 0; i < peopleCount; i++)
                {
                    DateTime currentDate = RandomDay();

                    if (checkBoxTwin.Checked == true)
                    {
                        if ((peopleCount % 20) == 0)
                        {
                            if (gen.Next(0, 2) == 1)
                            {
                                temp.Add(currentDate.ToShortDateString());
                                temp.RemoveAt(gen.Next(0, temp.Count));
                            }
                        }
                    }
                    temp.Add(currentDate.ToShortDateString());
                }

                int matchSelf = 0;
                for (int j = 0; j < temp.Count; j++)
                {
                    for (int k = 0; k < temp.Count; k++)
                    {
                        if (temp.Count > j && temp[j].ToString() == temp[k].ToString())
                        {
                            matchSelf += 1;
                            if (matchSelf > 1)
                            {
                                string monthStr = temp[j].ToString().Split('/')[0];
                                int monthInt = Convert.ToInt16(monthStr);

                                string dayStr = temp[j].ToString().Split('/')[1];
                                int dayInt = Convert.ToInt16(dayStr);

                                if (peopleCount == 50)
                                {
                                    int position = Convert.ToInt16(dataGridView50[dayInt, monthInt -= 1].Value);
                                    position += 1;
                                    dataGridView50[dayInt, monthInt].Value = position;
                                }
                                else if (peopleCount == 100)
                                {
                                    int position = Convert.ToInt16(dataGridView100[dayInt, monthInt -= 1].Value);
                                    position += 1;
                                    dataGridView100[dayInt, monthInt].Value = position;
                                }
                                else if (peopleCount == 250)
                                {
                                    int position = Convert.ToInt16(dataGridView250[dayInt, monthInt -= 1].Value);
                                    position += 1;
                                    dataGridView250[dayInt, monthInt].Value = position;
                                }
                                else
                                {
                                    int position = Convert.ToInt16(dataGridView1000[dayInt, monthInt -= 1].Value);
                                    position += 1;
                                    dataGridView1000[dayInt, monthInt].Value = position;
                                }
                                matchedDate.Add(temp[j].ToString().Split('/')[0] + " " + temp[j].ToString().Split('/')[1]);
                                temp.RemoveAt(j);
                            }
                        }
                    }
                    matchSelf = 0;
                }

                matchCount.Add(matchedDate.Count);
                for (int o = 0; o < matchCount.Count; o++)
                {
                    if (peopleCount == 50)
                    {
                        dataGridViewResult[1, o].Value = matchCount[o];
                        totalMatchCount += matchCount[o];
                    }
                    else if (peopleCount == 100)
                    {
                        dataGridViewResult[2, o].Value = matchCount[o];
                        totalMatchCount += matchCount[o];
                    }
                    else if (peopleCount == 250)
                    {
                        dataGridViewResult[3, o].Value = matchCount[o];
                        totalMatchCount += matchCount[o];
                    }
                    else
                    {
                        dataGridViewResult[4, o].Value = matchCount[o];
                        totalMatchCount += matchCount[o];
                    }
                }

                if (peopleCount == 50)
                {
                    dataGridViewResult[1, 20].Value = totalMatchCount;
                }
                else if (peopleCount == 100)
                {
                    dataGridViewResult[2, 20].Value = totalMatchCount;
                }
                else if (peopleCount == 250)
                {
                    dataGridViewResult[3, 20].Value = totalMatchCount;
                }
                else
                {
                    dataGridViewResult[4, 20].Value = totalMatchCount;
                }

                matchedDate.Clear();
                temp.Clear();
                totalMatchCount = 0;
                progressBar1.Value += 5;
            }
            matchCount.Clear();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < dataGridView50.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView50.Rows.Count; j++)
                {
                    dataGridView50[i, j].Value = 0;
                    dataGridView100[i, j].Value = 0;
                    dataGridView250[i, j].Value = 0;
                    dataGridView1000[i, j].Value = 0;
                }
            }

            experiment(50);
            experiment(100);
            experiment(250);
            experiment(1000);
        }
    }
}
