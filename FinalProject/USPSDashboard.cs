using FinalProject.Models;
using FinalProject.Repositories;
using static FinalProject.Models.Student;

namespace FinalProject
{
    public partial class USPSDashboard : Form
    {
        private Student _student;
        private readonly IStudentRepository _studRepo;



        public USPSDashboard(IStudentRepository studRepo, Student student)
        {
            InitializeComponent();
            _studRepo = studRepo;
            _student = student;
            LoadDashboardData();
            LoadAbsencesTab();
            LoadBalanceTab(_student);
            GetStudentSchedule();
            LoadTotalUnits();
            LoadScheduleTab(_student);
            LoadTab3AcademicOverview();
            //LoadGradesTab();


        }
        private void LoadTab3AcademicOverview()
        {
            flowLayoutPanelTab3.Controls.Clear();


            for (int year = 1; year <= 4; year++)
            {

                Label lblYear = new Label
                {
                    Text = $"YEAR {year}",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    AutoSize = true,
                    Margin = new Padding(10, 20, 10, 5)
                };
                flowLayoutPanelTab3.Controls.Add(lblYear);


                string yearPrefix = $"{year}st Year";
                if (year == 2) yearPrefix = "2nd Year";
                if (year == 3) yearPrefix = "3rd Year";
                if (year == 4) yearPrefix = "4th Year";

                string[] semesters = { "1st Semester", "2nd Semester", "MidYear" };

                foreach (var sem in semesters)
                {
                    string key = $"{yearPrefix} - {sem}";
                    if (_student.AcademicRecord.ContainsKey(key))
                    {
                        var semesterSubjects = _student.AcademicRecord[key];
                        Panel semPanel = CreateSemesterPanel(key, semesterSubjects);
                        flowLayoutPanelTab3.Controls.Add(semPanel);
                    }
                    else
                    {

                        Panel emptySemPanel = CreateSemesterPanel(key, new Dictionary<string, (int Units, double? Grade)>());
                        flowLayoutPanelTab3.Controls.Add(emptySemPanel);
                    }
                }
            }
        }

        private Panel CreateSemesterPanel(string semesterName, Dictionary<string, (int Units, double? Grade)> subjects)
        {
            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Margin = new Padding(30, 0, 10, 10)
            };


            Label lblSemester = new Label
            {
                Text = semesterName,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Margin = new Padding(0, 0, 0, 5)
            };
            panel.Controls.Add(lblSemester);

            TableLayoutPanel table = new TableLayoutPanel
            {
                ColumnCount = 3,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Grade
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Subject
            table.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize)); // Units

            // Header row
            table.Controls.Add(new Label { Text = "Grade", Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(5) }, 0, 0);
            table.Controls.Add(new Label { Text = "Subject", Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(5) }, 1, 0);
            table.Controls.Add(new Label { Text = "Units", Font = new Font("Segoe UI", 9, FontStyle.Bold), Margin = new Padding(5) }, 2, 0);

            int row = 1;
            foreach (var subj in subjects)
            {
                var lblGrade = new Label
                {
                    Text = subj.Value.Grade?.ToString() ?? "-",
                    BackColor = subj.Value.Grade.HasValue && subj.Value.Grade.Value < 75 ? Color.Tomato :
                                  subj.Value.Grade.HasValue && subj.Value.Grade.Value == 75 ? Color.Yellow :
                                  Color.Transparent,
                    Margin = new Padding(5),
                    AutoSize = true
                };

                var lblSubject = new Label
                {
                    Text = subj.Key,
                    Margin = new Padding(5),
                    AutoSize = true
                };

                var lblUnits = new Label
                {
                    Text = subj.Value.Units.ToString(),
                    Margin = new Padding(5),
                    AutoSize = true
                };

                table.Controls.Add(lblGrade, 0, row);
                table.Controls.Add(lblSubject, 1, row);
                table.Controls.Add(lblUnits, 2, row);

                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                row++;
            }

            panel.Controls.Add(table);
            return panel;
        }
        private void LoadDashboardData()
        {
            if (_student == null)
            {
                MessageBox.Show("Error: No student data found.");
                return;
            }


            labelUSPSName.Text = _student.FirstName + " " + _student.LastName;
            labelUSPSId.Text = _student.StudentID;
            labelUSPSCourseAndYear.Text = _student.CourseAndYear;
            double totalBalance = _student.FirstTermBalance + _student.MidTermBalance +
                      _student.MidTermBalance + _student.MidYearBalance +
                      _student.FinalTermBalance;
            labelAccountBalance.Text = $"Account Balance: ₱{totalBalance:N0}";
            labelTotalAbscences.Text = $"Total Absences: {_student.TotalAbsences}";


            if (_student.SubjectsGrades != null && _student.SubjectsGrades.Count > 0)
            {
                double totalGrade = _student.SubjectsGrades.Values.Sum();
                int subjectCount = _student.SubjectsGrades.Count;
                double averageGrade = totalGrade / subjectCount;

                labelTotalGrade.Text = $"Average: {averageGrade:F2}";

                tableLayoutPanelGrades.Controls.Clear();
                tableLayoutPanelGrades.RowStyles.Clear();


                tableLayoutPanelGrades.AutoSize = true;
                tableLayoutPanelGrades.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tableLayoutPanelGrades.ColumnCount = 2;
                tableLayoutPanelGrades.RowCount = _student.SubjectsGrades.Count + 1;
                tableLayoutPanelGrades.ColumnStyles.Clear();
                tableLayoutPanelGrades.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
                tableLayoutPanelGrades.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));

                int row = 0;
                foreach (var subject in _student.SubjectsGrades)
                {

                    var subjLabel = new Label
                    {
                        Text = subject.Key,
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleLeft,
                        AutoSize = true,
                        Margin = new Padding(5, 2, 5, 2)
                    };

                    var gradeLabel = new Label
                    {
                        Text = subject.Value.ToString(),
                        Font = new Font("Segoe UI", 10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        AutoSize = true,
                        Margin = new Padding(5, 2, 5, 2)
                    };
                    if (subject.Value == 75)
                    {
                        gradeLabel.BackColor = Color.Yellow;
                    }
                    else if (subject.Value < 75)
                    {
                        gradeLabel.BackColor = Color.Tomato;
                    }

                    tableLayoutPanelGrades.Controls.Add(subjLabel, 0, row);
                    tableLayoutPanelGrades.Controls.Add(gradeLabel, 1, row);
                    tableLayoutPanelGrades.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    row++;
                }


                var avgTextLabel = new Label
                {
                    Text = "Average",
                    Font = new Font("Segoe UI", 10, FontStyle.Bold | FontStyle.Italic),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true,
                    Margin = new Padding(5, 5, 5, 5)
                };


                var avgValueLabel = new Label
                {
                    Text = $"{averageGrade:F2}",
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = true,
                    Margin = new Padding(5, 5, 5, 5)

                };


                tableLayoutPanelGrades.Controls.Add(avgTextLabel, 0, row);
                tableLayoutPanelGrades.Controls.Add(avgValueLabel, 1, row);
                tableLayoutPanelGrades.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

        }








        //private void LoadGradesTab()
        //{
        //    tabPage2.Controls.Clear();

        //    if (_student.SubjectsGrades != null)
        //    {
        //        int y = 20;
        //        foreach (var kvp in _student.SubjectsGrades)
        //        {
        //            Label subjectLabel = new Label();
        //            subjectLabel.Text = kvp.Key;
        //            subjectLabel.Location = new Point(20, y);
        //            subjectLabel.AutoSize = true;

        //            Label gradeLabel = new Label();
        //            gradeLabel.Text = kvp.Value.ToString();
        //            gradeLabel.Location = new Point(200, y);
        //            gradeLabel.AutoSize = true;

        //            tabPage2.Controls.Add(subjectLabel);
        //            tabPage2.Controls.Add(gradeLabel);

        //            y += 30;
        //        }
        //    }
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void tbxStudentName_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelTotalGrade_Click(object sender, EventArgs e)
        {
            var grades = _student.SubjectsGrades;
            foreach (var subject in grades)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value}");
            }
        }

        private void LoadBalanceTab(Student student)
        {

            tableLayoutPanelBalance.Controls.Clear();
            tableLayoutPanelBalance.ColumnStyles.Clear();
            tableLayoutPanelBalance.RowStyles.Clear();

            tableLayoutPanelBalance.ColumnCount = 2;
            tableLayoutPanelBalance.RowCount = 4;
            tableLayoutPanelBalance.AutoSize = true;
            tableLayoutPanelBalance.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            tableLayoutPanelBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanelBalance.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));


            var balances = new Dictionary<string, double>
    {
        { "First Term", student.FirstTermBalance },
        { "Mid Term", student.MidTermBalance },
        { "Finals", student.FinalTermBalance },
        { "MidYear", student.MidYearBalance }
    };

            int row = 0;
            foreach (var kvp in balances)
            {
                string termName = kvp.Key;
                double balanceValue = kvp.Value;

                var termLabel = new Label
                {
                    Text = termName,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    AutoSize = false,
                    MinimumSize = new Size(100, 30),
                    Margin = new Padding(2)
                };

                var valueLabel = new Label
                {
                    Text = $"₱{balanceValue:N0}",
                    Font = new Font("Segoe UI", 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    AutoSize = false,
                    MinimumSize = new Size(100, 30),
                    Margin = new Padding(2)
                };

                tableLayoutPanelBalance.Controls.Add(termLabel, 0, row);
                tableLayoutPanelBalance.Controls.Add(valueLabel, 1, row);
                tableLayoutPanelBalance.RowStyles.Add(new RowStyle(SizeType.AutoSize));

                row++;
            }
        }

        private void labelTotalAbscences_Click(object sender, EventArgs e)
        {

        }

        private void labelTotalUnits_Click(object sender, EventArgs e)
        {

        }

        private void labelUSPSCourseAndYear_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelAbsences_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadAbsencesTab()
        {
            flowLayoutPanelAbsences.Controls.Clear();
            flowLayoutPanelAbsences.AutoScroll = true;

            var subjectInfo = new Dictionary<string, (string Type, double HoursPerAbsence)>
    {
        { "Data Structures", ("Major", 2.5) },
        { "OOP", ("Major", 2.5) },
        { "Calculus", ("Major", 2.0) },
        { "COA", ("Major", 2.5) },

        { "CFE", ("Minor", 1.5) },
        { "GSelf", ("Minor", 1.5) },
        { "GCWorld", ("Minor", 1.5) },
        { "PEECO", ("Minor", 1.5) },
        { "Path Fit", ("Minor", 1.5) },
    };

            double totalHours = 0;

            foreach (var subject in subjectInfo)
            {
                string subjectName = subject.Key;
                string type = subject.Value.Type;
                double hoursPerAbsence = subject.Value.HoursPerAbsence;


                int absences = 0;
                if (_student.SubjectsAbsences != null && _student.SubjectsAbsences.ContainsKey(subjectName))
                {
                    absences = _student.SubjectsAbsences[subjectName];
                }


                double hours = absences * hoursPerAbsence;
                totalHours += hours;


                Panel p = new Panel();
                p.Width = flowLayoutPanelAbsences.Width - 30;
                p.Height = 45;
                p.BorderStyle = BorderStyle.FixedSingle;

                if (hours >= 10 && hours < 12)
                {
                    p.BackColor = Color.Yellow;
                }

                Label lblSubject = new Label
                {
                    Text = subjectName,
                    Location = new Point(10, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };

                Label lblType = new Label
                {
                    Text = type,
                    Location = new Point(180, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9, FontStyle.Italic)
                };

                Label lblAbs = new Label
                {
                    Text = $"Absences: {absences}",
                    Location = new Point(260, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10)
                };

                Label lblHours = new Label
                {
                    Text = $"{hours} hrs",
                    Location = new Point(390, 10),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10)
                };


                if (hours >= 12)
                {
                    p.BackColor = Color.LightCoral;
                    lblHours.ForeColor = Color.DarkRed;
                    lblAbs.ForeColor = Color.DarkRed;
                }

                p.Controls.Add(lblSubject);
                p.Controls.Add(lblType);
                p.Controls.Add(lblAbs);
                p.Controls.Add(lblHours);

                flowLayoutPanelAbsences.Controls.Add(p);
            }
        }
        private void LoadTotalUnits()
        {
            if (_student.SubjectsAbsences == null || _student.SubjectsAbsences.Count == 0)
            {
                labelTotalUnits.Text = "Total Units: 0";
                return;
            }


            var subjectUnits = new Dictionary<string, double>
    {
        { "Data Structures", 3 },
        { "OOP", 3 },
        { "Calculus", 3 },
        { "COA", 3 },
        { "CFE", 2 },
        { "GSelf", 2 },
        { "GCWorld", 2 },
        { "PEECO", 2 },
        { "Path Fit", 2 }
    };

            double totalUnits = 0;
            foreach (var subject in _student.SubjectsGrades.Keys)
            {
                if (subjectUnits.ContainsKey(subject))
                    totalUnits += subjectUnits[subject];
            }

            labelTotalUnits.Text = $"Total Units: {totalUnits}";
        }

        private void tableLayoutPanelBalance_Paint(object sender, PaintEventArgs e)
        {

        }
        private Dictionary<string, List<(string Subject, string Time)>> GetStudentSchedule()
        {
            return new Dictionary<string, List<(string, string)>>()
    {
        {
            "MTh", new List<(string, string)>
            {
                ("Data Structures", "7:30 AM - 10:00 AM"),
                ("GSelf", "10:30 AM - 12:00 PM"),
                ("PEECO", "1:30 PM - 3:00 PM"),
                ("CSMath", "4:30 PM - 6:30 PM")
            }
        },
        {
            "TF", new List<(string, string)>
            {
                ("CFE", "7:30 AM - 9:00 AM"),
                ("Path Fit", "9:00 AM - 10:00 AM"),
                ("OOP", "10:30 AM - 1:00 PM"),
                ("COA", "1:30 PM - 4:30 PM"),
                ("GC World", "4:30 PM - 6:00 PM")
            }
        }
    };
        }

        private void labelFirstTerm_Click(object sender, EventArgs e)
        {

        }

        private void labelMidYear_Click(object sender, EventArgs e)
        {

        }

        private void labelFinals_Click(object sender, EventArgs e)
        {

        }

        private void labelMidTerm_Click(object sender, EventArgs e)
        {

        }

        private void labelFirstTermV_Click(object sender, EventArgs e)
        {

        }

        private void labelMidTermV_Click(object sender, EventArgs e)
        {

        }

        private void labelFinalsV_Click(object sender, EventArgs e)
        {

        }

        private void labelMidYearV_Click(object sender, EventArgs e)
        {

        }

        private void labelAccountBalance_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelSchedule_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadScheduleTab(Student student)
        {
            flowLayoutPanelSchedule.Controls.Clear();

            foreach (var dayKey in student.Schedule.Keys)
            {

                Label dayLabel = new Label
                {
                    Text = dayKey,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    AutoSize = true
                };
                flowLayoutPanelSchedule.Controls.Add(dayLabel);

                DateTime? lastEnd = null;


                foreach (var entry in student.Schedule[dayKey])
                {

                    if (lastEnd != null && entry.StartTime > lastEnd)
                    {
                        Label vacant = new Label
                        {
                            Text = $"Vacant: {lastEnd.Value.ToShortTimeString()} - {entry.StartTime.ToShortTimeString()}",
                            Font = new Font("Segoe UI", 9, FontStyle.Italic),
                            ForeColor = Color.Gray,
                            AutoSize = true,
                            Margin = new Padding(10, 0, 0, 5)
                        };
                        flowLayoutPanelSchedule.Controls.Add(vacant);
                    }

                    Label lbl = new Label
                    {
                        Text = $"{entry.Subject} — {entry.Time}",
                        AutoSize = true,
                        Font = new Font("Segoe UI", 9),
                        Margin = new Padding(5)
                    };
                    flowLayoutPanelSchedule.Controls.Add(lbl);

                    lastEnd = entry.EndTime;
                }


                flowLayoutPanelSchedule.Controls.Add(new Label { Height = 10 });
            }
        }

        private void labelAbsences_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void tabPage3_Enter(object sender, EventArgs e)
        {
            LoadTab3AcademicOverview();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you",
                  "Log out Successful", MessageBoxButtons.OK,
                  MessageBoxIcon.Information);
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you",
                              "Log out Successful", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you",
                              "Log out Successful", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            Application.Exit();
        }

        private void tableLayoutPanelGrades_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
    
    
    

