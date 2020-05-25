using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EducationalSoftware
{
    public partial class LinguaggioForm : Form
    {
        public LinguaggioForm()
        {
            InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }



        private void loginButton_Click(object sender, EventArgs e)
        {

            tabControl.SelectedTab = loginTabPage;
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = registerTabPage;
        }

        private void backLoginLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = HomeTabPage;
        }

        private void backRegisterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = HomeTabPage;
        }

        private void goToAccount()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda1 = new SqlDataAdapter("select Status from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'", conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows.Count == 1 && dt1.Rows[0][0].ToString() == "Pass")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 1 && dt1.Rows[0][0].ToString() == "Fail")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2_grey;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 2 && dt1.Rows[1][0].ToString() == "Pass")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 2 && dt1.Rows[1][0].ToString() == "Fail")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3_grey;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 3 && dt1.Rows[2][0].ToString() == "Pass")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3;
                    RevisionPictureBox.Image = EducationalSoftware.Properties.Resources.revision;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 3 && dt1.Rows[2][0].ToString() == "Fail")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3;
                    RevisionPictureBox.Image = EducationalSoftware.Properties.Resources.revision_grey;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 4 && dt1.Rows[3][0].ToString() == "Pass")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3;
                    RevisionPictureBox.Image = EducationalSoftware.Properties.Resources.revision;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else if (dt1.Rows.Count == 4 && dt1.Rows[3][0].ToString() == "Fail")
                {
                    Level2PictureBox.Image = EducationalSoftware.Properties.Resources.level2;
                    Level3PictureBox.Image = EducationalSoftware.Properties.Resources.level3;
                    RevisionPictureBox.Image = EducationalSoftware.Properties.Resources.revision;
                    tabControl.SelectedTab = myAccountTabPage;
                }
                else
                {
                    MessageBox.Show("Something went wrong");
                }
            }
            else
            {
                tabControl.SelectedTab = myAccountTabPage;
            }

        }
        private void loginButton2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select count(*)from userDataTable where username ='" + usernameLoginTextBox.Text + "'and password = '" + passwordLoginTextBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            welcomeAccountLabel.Text = "Καλωσήρθες στον λογαριασμό σου";
            welcomeAccountLabel.Text = welcomeAccountLabel.Text + " " + usernameLoginTextBox.Text;
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (usernameLoginTextBox.Text == "professor")
                {
                    tabControl.SelectedTab = ProfessorTabPage;
                    welcomeAccountProfessorLabel.Text = welcomeAccountProfessorLabel.Text + " " + usernameLoginTextBox.Text;
                }
                else
                {
                    goToAccount();
                }
            }
            else
                MessageBox.Show("Λάθος όνομα χρήστη ή κωδικός πρόσβασης. Προσπαθείστε ξανά.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void backAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = HomeTabPage;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }

            }

            if (PasswordRegisterTextBox.Text == "" || UsernameRegisterTextBox.Text == "" || NameRegisterTextBox.Text == "" || SurnameRegisterTextBox.Text == "")
            {
                MessageBox.Show("Συμπληρώστε όλα τα πεδία.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PasswordRegisterTextBox.Text != ConfPasswordRegisterTextBox.Text)
            {
                MessageBox.Show("Οι κωδικοί πρόσβασης δεν ταιριάζουν. Παρακαλώ δοκιμάστε ξανά.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (IsValidEmail(EmailRegisterTextBox.Text) == false)
            {
                MessageBox.Show("Συμπληρώστε ένα ορθό email.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Query = "insert into userDataTable (username, password, name, surname, email) values ('" + UsernameRegisterTextBox.Text + "', '" + PasswordRegisterTextBox.Text + "', '" + NameRegisterTextBox.Text + "', '" + SurnameRegisterTextBox.Text + "', '" + EmailRegisterTextBox.Text + "')";

                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand cmd = new SqlCommand(Query, conn);
                SqlDataReader myDataReader;
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from userDataTable where username ='" + UsernameRegisterTextBox.Text + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Το συγκεκριμένο όνομα χρήστη υπάρχει ήδη. Παρακαλώ δοκιμάστε ένα άλλο.", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        conn.Open();
                        myDataReader = cmd.ExecuteReader();
                        MessageBox.Show("Επιτυχής δημιουργία λογαριασμού!");
                        tabControl.SelectedTab = HomeTabPage;
                        while (myDataReader.Read())
                        {

                        }
                        ClearAll();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            
        }

        string levelNumber = "1";
        int timesVisitedTheoryLevel1;
        int timesVisitedTheoryLevel2;
        int timesVisitedTheoryLevel3;
        int timesVisitedTheoryRevision = 0;

        private void backToAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void Level1PictureBox_Click(object sender, EventArgs e)
        {
            levelNumber = "1";
            tabControl.SelectedTab = Level1TabPage;
        }
        private void Level1TheoryButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda4 = new SqlDataAdapter("select TimesVisitedTheory from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                DataTable dt4 = new DataTable();
                sda4.Fill(dt4);
                timesVisitedTheoryLevel1 = Convert.ToInt32(dt4.Rows[0][0].ToString()) + 1;
            }
            else
            {
                timesVisitedTheoryLevel1 = 1;
            }

            tabControl.SelectedTab = TheoryLevel1TabPage;
        }

        private void TestLevel1Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel1TabPage;
        }


        private void TestFromTheoryLevel1Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel1TabPage;
        }

        private void BackToLevel1TheoryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level1TabPage;

        }

        private void BackToLevel1TestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level1TabPage;
        }

        private string GetSelectedRadioButtonText(GroupBox grb)
        {
            return grb.Controls.OfType<RadioButton>().SingleOrDefault(rad => rad.Checked == true).Text;
        }

        private void FinishTestLevel1Button_Click(object sender, EventArgs e)
        {
            bool isChecked1Level1 = false;
            bool isChecked2Level1 = false;
            bool isChecked3Level1 = false;
            bool isChecked4Level1 = false;
            bool isChecked5Level1 = false;

            foreach (RadioButton radioButton1 in Question1Level1GroupBox.Controls)
            {
                if (radioButton1.Checked == true)
                {
                    isChecked1Level1 = true;
                }
            }
            foreach (RadioButton radioButton2 in Question2Level1GroupBox.Controls)
            {
                if (radioButton2.Checked == true)
                {
                    isChecked2Level1 = true;
                }
            }
            foreach (RadioButton radioButton3 in Question3Level1GroupBox.Controls)
            {
                if (radioButton3.Checked == true)
                {
                    isChecked3Level1 = true;
                }
            }
            foreach (RadioButton radioButton4 in Question4Level1GroupBox.Controls)
            {
                if (radioButton4.Checked == true)
                {
                    isChecked4Level1 = true;
                }
            }
            foreach (RadioButton radioButton5 in Question5Level1GroupBox.Controls)
            {
                if (radioButton5.Checked == true)
                {
                    isChecked5Level1 = true;
                }
            }

            if (isChecked1Level1 == true && isChecked2Level1 == true && isChecked3Level1 == true && isChecked4Level1 == true && isChecked5Level1 == true)
            {
                string wrongCategory1Level1;
                string wrongCategory2Level1;
                string wrongCategory3Level1;
                string wrongCategory4Level1;
                string wrongCategory5Level1;

                if (Question1GrammarWrongLevel1RadioButton.Checked == true)
                {

                    wrongCategory1Level1 = "grammar";
                }
                else if (Question1VocabularyWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory1Level1 = "vocabulary";
                }
                else if (Question1AllWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory1Level1 = "all";
                }
                else wrongCategory1Level1 = "none";

                if (Question2GrammarWrongLevel1RadioButton.Checked == true)
                {

                    wrongCategory2Level1 = "grammar";
                }
                else if (Question2VocabularyWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory2Level1 = "vocabulary";
                }
                else if (Question2AllWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory2Level1 = "all";
                }
                else wrongCategory2Level1 = "none";

                if (Question3GrammarWrongLevel1RadioButton.Checked == true)
                {

                    wrongCategory3Level1 = "grammar";
                }
                else if (Question3VocabularyWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory3Level1 = "vocabulary";
                }
                else if (Question3AllWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory3Level1 = "all";
                }
                else wrongCategory3Level1 = "none";

                if (Question4GrammarWrongLevel1RadioButton.Checked == true)
                {

                    wrongCategory4Level1 = "grammar";
                }
                else if (Question4VocabularyWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory4Level1 = "vocabulary";
                }
                else if (Question1AllWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory4Level1 = "all";
                }
                else wrongCategory4Level1 = "none";

                if (Question5GrammarWrongLevel1RadioButton.Checked == true)
                {

                    wrongCategory5Level1 = "grammar";
                }
                else if (Question5VocabularyWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory5Level1 = "vocabulary";
                }
                else if (Question5AllWrongLevel1RadioButton.Checked == true)
                {
                    wrongCategory5Level1 = "all";
                }
                else wrongCategory5Level1 = "none";


                string[] level1 = new string[20];
                level1[0] = Question1Level1GroupBox.Text;
                level1[1] = Question1CorrectLevel1RadioButton.Text;
                level1[2] = GetSelectedRadioButtonText(Question1Level1GroupBox);
                level1[3] = wrongCategory1Level1;
                level1[4] = Question2Level1GroupBox.Text;
                level1[5] = Question2CorrectLevel1RadioButton.Text;
                level1[6] = GetSelectedRadioButtonText(Question2Level1GroupBox);
                level1[7] = wrongCategory2Level1;
                level1[8] = Question3Level1GroupBox.Text;
                level1[9] = Question3CorrectLevel1RadioButton.Text;
                level1[10] = GetSelectedRadioButtonText(Question3Level1GroupBox);
                level1[11] = wrongCategory3Level1;
                level1[12] = Question4Level1GroupBox.Text;
                level1[13] = Question4CorrectLevel1RadioButton.Text;
                level1[14] = GetSelectedRadioButtonText(Question4Level1GroupBox);
                level1[15] = wrongCategory4Level1;
                level1[16] = Question5Level1GroupBox.Text;
                level1[17] = Question5CorrectLevel1RadioButton.Text;
                level1[18] = GetSelectedRadioButtonText(Question5Level1GroupBox);
                level1[19] = wrongCategory5Level1;



                for (int i = 0; i < level1.Length; i = i + 4)
                {

                    string Query = "insert into Level1Table (username, Question, CorrectAnswer, UsersAnswer, WrongCategory) values ('" + usernameLoginTextBox.Text + "', '" + level1[i] + "', '" + level1[i + 1] + "', '" + level1[i + 2] + "', '" + level1[i + 3] + "')";
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand(Query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }


                SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from Level1Table where username ='" + usernameLoginTextBox.Text + "'and WrongCategory = 'none'", conn1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string level1Status = null;

                if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= 3)
                {
                    level1Status = "Pass";
                }
                else
                {
                    level1Status = "Fail";
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("select WrongCategory, count(*) as count from Level1Table where username ='" + usernameLoginTextBox.Text + "'group by WrongCategory order by count DESC", conn1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                string totalWrongCategoryLevel1 = null;
                totalWrongCategoryLevel1 = dt1.Rows[0]["WrongCategory"].ToString();
               

                string Query1 = "UPDATE StudentsPerformanceTable SET LevelNumber = '" + levelNumber.ToString() + "', Status = '" + level1Status + "', WrongCategory = '" + totalWrongCategoryLevel1 + "', TimesVisitedTheory = '" + timesVisitedTheoryLevel1 + "' where username = '" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'";
                string Query2 = "insert into StudentsPerformanceTable (username, LevelNumber, Status, WrongCategory, TimesVisitedTheory) values ('" + usernameLoginTextBox.Text + "', '" + levelNumber.ToString() + "', '" + level1Status + "', '" + totalWrongCategoryLevel1 + "', '" + timesVisitedTheoryLevel1 + "')";
                SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                SqlCommand cmd2 = new SqlCommand(Query2, conn1);
                //pinakas StudentsPerformance levelnumber = 1 status = P alliws F  
                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    try
                    {

                        conn1.Open();
                        cmd1.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                if (totalWrongCategoryLevel1 == "grammar")
                {
                    WrongCategoryLevel1Label.Text = "Γραμματική";
                    GrammarTitleSpecificTheoryLevel1Label.Text = GrammarTitleLevel1Label.Text;
                    ShowSpecificTheoryGrammarLevel1Label.Text = GrammarTheoryLevel1Label.Text;
                }
                else if (totalWrongCategoryLevel1 == "vocabulary")
                {
                    WrongCategoryLevel1Label.Text = "Λεξιλόγιο";
                    VocabularyTitleSpecificTheoryLevel1Label.Text = VocabularyTitleLevel1Label.Text;
                    ShowSpecificTheoryVocabularyLevel1Label.Text = VocabularyTheoryLevel1Label.Text;
                }
                else if (totalWrongCategoryLevel1 == "all")
                {
                    WrongCategoryLevel1Label.Text = "Γραμματική και Λεξιλόγιο";
                    GrammarTitleSpecificTheoryLevel1Label.Text = GrammarTitleLevel1Label.Text;
                    ShowSpecificTheoryGrammarLevel1Label.Text = GrammarTheoryLevel1Label.Text;
                    VocabularyTitleSpecificTheoryLevel1Label.Text = VocabularyTitleLevel1Label.Text;
                    ShowSpecificTheoryVocabularyLevel1Label.Text = VocabularyTheoryLevel1Label.Text;
                }

                if (level1Status == "Pass")
                {
                    MessageBox.Show("Μπράβο, πέρασες το επίπεδο! Συγχαρητήρια!");
                    goToAccount();
                }
                else
                {
                    MessageBox.Show("Δυστυχώς, δεν πέρασες το επίπεδο. Διάβασε ξανά τη θεωρία και δοκίμασε από την αρχή.");
                    tabControl.SelectedTab = SpecificTheoryLevel1TabPage;
                }
                conn1.Close();
            }
            else
            {
                MessageBox.Show("Πρέπει να απαντήσεις όλες τις ερωτήσεις.");
            }
            
            



        }
        private void ClearAll()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.SelectedTab = HomeTabPage;
        }
        private void SignOutAccountLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void SignOutLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void SignOutTheoryLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void SignOutTestLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void SignOutSpecificTheoryLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void Level2PictureBox_Click(object sender, EventArgs e)
        {
            levelNumber = "2";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Status from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1 && dt.Rows[0][0].ToString() == "Pass")
                {
                    tabControl.SelectedTab = Level2TabPage;
                }
                else if (dt.Rows.Count == 2 && (dt.Rows[0][0].ToString() == "Pass" || dt.Rows[1][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = Level2TabPage;
                }
                else if (dt.Rows.Count == 3 && dt.Rows[0][0].ToString() == "Pass" && (dt.Rows[1][0].ToString() == "Pass" || dt.Rows[2][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = Level2TabPage;
                }
                else if (dt.Rows.Count == 4 && dt.Rows[0][0].ToString() == "Pass" && dt.Rows[1][0].ToString() == "Pass" && (dt.Rows[2][0].ToString() == "Pass" || dt.Rows[3][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = Level2TabPage;
                }
                else
                {
                    MessageBox.Show("Για να πας στο Επίπεδο 2 (Level 2) πρέπει πρώτα να έχεις περάσει το Επίπεδο 1 (Level 1).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Για να πας στο Επίπεδο 2 (Level 2) πρέπει πρώτα να έχεις περάσει το Επίπεδο 1 (Level 1).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Level2TheoryButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "' and LevelNumber=2", conn1);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda4 = new SqlDataAdapter("select TimesVisitedTheory from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber=2", conn1);
                    DataTable dt4 = new DataTable();
                    sda4.Fill(dt4);
                    timesVisitedTheoryLevel2 = Convert.ToInt32(dt4.Rows[0][0].ToString()) + 1;
                }
                else
                {
                    timesVisitedTheoryLevel2 = 1;
                }
            }
            else
            {
                timesVisitedTheoryLevel2 = 1;
            }


            tabControl.SelectedTab = TheoryLevel2TabPage;
        }

        private void Level2TestButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel2TabPage;
        }

        private void BackToLevel2TheoryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level2TabPage;
        }

        private void SignOutTheoryLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void BackToLevel2TestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level2TabPage;
        }

        private void SignOutTestLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void FinishTestLevel2Button_Click(object sender, EventArgs e)
        {
            bool isChecked1Level2 = false;
            bool isChecked2Level2 = false;
            bool isChecked3Level2 = false;
            bool isChecked4Level2 = false;
            bool isChecked5Level2 = false;

            foreach (RadioButton radioButton1 in Question1Level2GroupBox.Controls)
            {
                if (radioButton1.Checked == true)
                {
                    isChecked1Level2 = true;
                }
            }
            foreach (RadioButton radioButton2 in Question2Level2GroupBox.Controls)
            {
                if (radioButton2.Checked == true)
                {
                    isChecked2Level2 = true;
                }
            }
            foreach (RadioButton radioButton3 in Question3Level2GroupBox.Controls)
            {
                if (radioButton3.Checked == true)
                {
                    isChecked3Level2 = true;
                }
            }
            foreach (RadioButton radioButton4 in Question4Level2GroupBox.Controls)
            {
                if (radioButton4.Checked == true)
                {
                    isChecked4Level2 = true;
                }
            }
            foreach (RadioButton radioButton5 in Question5Level2GroupBox.Controls)
            {
                if (radioButton5.Checked == true)
                {
                    isChecked5Level2 = true;
                }
            }

            if (isChecked1Level2 == true && isChecked2Level2 == true && isChecked3Level2 == true && isChecked4Level2 == true && isChecked5Level2 == true)
            {

                string wrongCategory1Level2;
                string wrongCategory2Level2;
                string wrongCategory3Level2;
                string wrongCategory4Level2;
                string wrongCategory5Level2;

                if (Question1GrammarWrongLevel2RadioButton.Checked == true)
                {

                    wrongCategory1Level2 = "grammar";
                }
                else if (Question1VocabularyWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory1Level2 = "vocabulary";
                }
                else if (Question1AllWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory1Level2 = "all";
                }
                else wrongCategory1Level2 = "none";

                if (Question2GrammarWrongLevel2RadioButton.Checked == true)
                {

                    wrongCategory2Level2 = "grammar";
                }
                else if (Question2VocabularyWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory2Level2 = "vocabulary";
                }
                else if (Question2AllWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory2Level2 = "all";
                }
                else wrongCategory2Level2 = "none";

                if (Question3GrammarWrongLevel2RadioButton.Checked == true)
                {

                    wrongCategory3Level2 = "grammar";
                }
                else if (Question3VocabularyWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory3Level2 = "vocabulary";
                }
                else if (Question3AllWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory3Level2 = "all";
                }
                else wrongCategory3Level2 = "none";

                if (Question4GrammarWrongLevel2RadioButton.Checked == true)
                {

                    wrongCategory4Level2 = "grammar";
                }
                else if (Question4VocabularyWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory4Level2 = "vocabulary";
                }
                else if (Question1AllWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory4Level2 = "all";
                }
                else wrongCategory4Level2 = "none";

                if (Question5GrammarWrongLevel2RadioButton.Checked == true)
                {

                    wrongCategory5Level2 = "grammar";
                }
                else if (Question5VocabularyWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory5Level2 = "vocabulary";
                }
                else if (Question5AllWrongLevel2RadioButton.Checked == true)
                {
                    wrongCategory5Level2 = "all";
                }
                else wrongCategory5Level2 = "none";


                string[] level2 = new string[20];
                level2[0] = Question1Level2GroupBox.Text;
                level2[1] = Question1CorrectLevel2RadioButton.Text;
                level2[2] = GetSelectedRadioButtonText(Question1Level2GroupBox);
                level2[3] = wrongCategory1Level2;
                level2[4] = Question2Level2GroupBox.Text;
                level2[5] = Question2CorrectLevel2RadioButton.Text;
                level2[6] = GetSelectedRadioButtonText(Question2Level2GroupBox);
                level2[7] = wrongCategory2Level2;
                level2[8] = Question3Level2GroupBox.Text;
                level2[9] = Question3CorrectLevel2RadioButton.Text;
                level2[10] = GetSelectedRadioButtonText(Question3Level2GroupBox);
                level2[11] = wrongCategory3Level2;
                level2[12] = Question4Level2GroupBox.Text;
                level2[13] = Question4CorrectLevel2RadioButton.Text;
                level2[14] = GetSelectedRadioButtonText(Question4Level2GroupBox);
                level2[15] = wrongCategory4Level2;
                level2[16] = Question5Level2GroupBox.Text;
                level2[17] = Question5CorrectLevel2RadioButton.Text;
                level2[18] = GetSelectedRadioButtonText(Question5Level2GroupBox);
                level2[19] = wrongCategory5Level2;



                for (int i = 0; i < level2.Length; i = i + 4)
                {

                    string Query = "insert into Level2Table (username, Question, CorrectAnswer, UsersAnswer, WrongCategory) values ('" + usernameLoginTextBox.Text + "', '" + level2[i] + "', '" + level2[i + 1] + "', '" + level2[i + 2] + "', '" + level2[i + 3] + "')";
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand(Query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }


                SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from Level2Table where username ='" + usernameLoginTextBox.Text + "'and WrongCategory = 'none'", conn1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string level2Status = null;

                if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= 3)
                {
                    level2Status = "Pass";
                }
                else
                {
                    level2Status = "Fail";
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("select WrongCategory, count(*) as count from Level2Table where username ='" + usernameLoginTextBox.Text + "'group by WrongCategory order by count DESC", conn1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                string totalWrongCategoryLevel2 = null;
                totalWrongCategoryLevel2 = dt1.Rows[0]["WrongCategory"].ToString();

                string Query1 = "UPDATE StudentsPerformanceTable SET LevelNumber = '" + levelNumber + "', Status = '" + level2Status + "', WrongCategory = '" + totalWrongCategoryLevel2 + "', TimesVisitedTheory = '" + timesVisitedTheoryLevel2 + "' where username = '" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'";
                string Query2 = "insert into StudentsPerformanceTable (username, LevelNumber, Status, WrongCategory, TimesVisitedTheory) values ('" + usernameLoginTextBox.Text + "', '" + levelNumber + "', '" + level2Status + "', '" + totalWrongCategoryLevel2 + "', '" + timesVisitedTheoryLevel2 + "')";
                SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                SqlCommand cmd2 = new SqlCommand(Query2, conn1);
                //pinakas StudentsPerformance levelnumber = 1 status = P alliws F  
                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    try
                    {

                        conn1.Open();
                        cmd1.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                if (totalWrongCategoryLevel2 == "grammar")
                {
                    WrongCategoryLevel2Label.Text = "Γραμματική";
                    GrammarTitleSpecificTheoryLevel2Label.Text = GrammarTitleLevel2Label.Text;
                    ShowSpecificTheoryGrammarLevel2Label.Text = GrammarTheoryLevel2Label.Text;
                }
                else if (totalWrongCategoryLevel2 == "vocabulary")
                {
                    WrongCategoryLevel2Label.Text = "Λεξιλόγιο";
                    VocabularyTitleSpecificTheoryLevel2Label.Text = VocabularyTitleLevel2Label.Text;
                    ShowSpecificTheoryVocabularyLevel2Label.Text = VocabularyTheoryLevel2Label.Text;
                }
                else if (totalWrongCategoryLevel2 == "all")
                {
                    WrongCategoryLevel2Label.Text = "Γραμματική και Λεξιλόγιο";
                    GrammarTitleSpecificTheoryLevel2Label.Text = GrammarTitleLevel2Label.Text;
                    ShowSpecificTheoryGrammarLevel2Label.Text = GrammarTheoryLevel2Label.Text;
                    VocabularyTitleSpecificTheoryLevel2Label.Text = VocabularyTitleLevel2Label.Text;
                    ShowSpecificTheoryVocabularyLevel2Label.Text = VocabularyTheoryLevel2Label.Text;
                }

                if (level2Status == "Pass")
                {
                    MessageBox.Show("Μπράβο, πέρασες το επίπεδο! Συγχαρητήρια!");
                    goToAccount();
                }
                else
                {
                    MessageBox.Show("Δυστυχώς, δεν πέρασες το επίπεδο. Διάβασε ξανά τη θεωρία και δοκίμασε από την αρχή.");
                    tabControl.SelectedTab = SpecificTheoryLevel2TabPage;
                }
                conn1.Close();
            }
            else
            {
                MessageBox.Show("Πρέπει να απαντήσεις όλες τις ερωτήσεις.");
            }
        }

        private void TestFromTheoryLevel2Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel2TabPage;
        }

        private void backToAccountSpecificTheoryLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = myAccountTabPage;
        }

        private void backToAccountSpecificTheoryLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = myAccountTabPage;
        }

        private void SignOutSpecificTheoryLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void Level3PictureBox_Click(object sender, EventArgs e)
        {
            levelNumber = "3";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Status from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
       
                if (dt.Rows.Count == 2 && dt.Rows[0][0].ToString() == "Pass" && dt.Rows[1][0].ToString() == "Pass")
                {
                    tabControl.SelectedTab = Level3TabPage;
                }
                else if (dt.Rows.Count == 3 && dt.Rows[0][0].ToString() == "Pass" && (dt.Rows[1][0].ToString() == "Pass" || dt.Rows[2][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = Level3TabPage;
                }
                else if (dt.Rows.Count == 4 && dt.Rows[0][0].ToString() == "Pass" && dt.Rows[1][0].ToString() == "Pass" && (dt.Rows[2][0].ToString() == "Pass" || dt.Rows[3][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = Level3TabPage;
                }
                else
                {
                    MessageBox.Show("Για να πας στο Επίπεδο 3 (Level 3) πρέπει πρώτα να έχεις περάσει το Επίπεδο 2 (Level 2).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Για να πας στο Επίπεδο 3 (Level 3) πρέπει πρώτα να έχεις περάσει το Επίπεδο 2 (Level 2).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backToAccountLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void SignOutLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void FinishTestLevel3Button_Click(object sender, EventArgs e)
        {
            bool isChecked1Level3 = false;
            bool isChecked2Level3 = false;
            bool isChecked3Level3 = false;
            bool isChecked4Level3 = false;
            bool isChecked5Level3 = false;

            foreach (RadioButton radioButton1 in Question1Level3GroupBox.Controls)
            {
                if (radioButton1.Checked == true)
                {
                    isChecked1Level3 = true;
                }
            }
            foreach (RadioButton radioButton2 in Question2Level3GroupBox.Controls)
            {
                if (radioButton2.Checked == true)
                {
                    isChecked2Level3 = true;
                }
            }
            foreach (RadioButton radioButton3 in Question3Level3GroupBox.Controls)
            {
                if (radioButton3.Checked == true)
                {
                    isChecked3Level3 = true;
                }
            }
            foreach (RadioButton radioButton4 in Question4Level3GroupBox.Controls)
            {
                if (radioButton4.Checked == true)
                {
                    isChecked4Level3 = true;
                }
            }
            foreach (RadioButton radioButton5 in Question5Level3GroupBox.Controls)
            {
                if (radioButton5.Checked == true)
                {
                    isChecked5Level3 = true;
                }
            }

            if (isChecked1Level3 == true && isChecked2Level3 == true && isChecked3Level3 == true && isChecked4Level3 == true && isChecked5Level3 == true)
            {
                string wrongCategory1Level3;
                string wrongCategory2Level3;
                string wrongCategory3Level3;
                string wrongCategory4Level3;
                string wrongCategory5Level3;

                if (Question1GrammarWrongLevel3RadioButton.Checked == true)
                {

                    wrongCategory1Level3 = "grammar";
                }
                else if (Question1VocabularyWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory1Level3 = "vocabulary";
                }
                else if (Question1AllWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory1Level3 = "all";
                }
                else wrongCategory1Level3 = "none";

                if (Question2GrammarWrongLevel3RadioButton.Checked == true)
                {

                    wrongCategory2Level3 = "grammar";
                }
                else if (Question2VocabularyWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory2Level3 = "vocabulary";
                }
                else if (Question2AllWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory2Level3 = "all";
                }
                else wrongCategory2Level3 = "none";

                if (Question3GrammarWrongLevel3RadioButton.Checked == true)
                {

                    wrongCategory3Level3 = "grammar";
                }
                else if (Question3VocabularyWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory3Level3 = "vocabulary";
                }
                else if (Question3AllWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory3Level3 = "all";
                }
                else wrongCategory3Level3 = "none";

                if (Question4GrammarWrongLevel3RadioButton.Checked == true)
                {

                    wrongCategory4Level3 = "grammar";
                }
                else if (Question4VocabularyWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory4Level3 = "vocabulary";
                }
                else if (Question1AllWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory4Level3 = "all";
                }
                else wrongCategory4Level3 = "none";

                if (Question5GrammarWrongLevel3RadioButton.Checked == true)
                {

                    wrongCategory5Level3 = "grammar";
                }
                else if (Question5VocabularyWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory5Level3 = "vocabulary";
                }
                else if (Question5AllWrongLevel3RadioButton.Checked == true)
                {
                    wrongCategory5Level3 = "all";
                }
                else wrongCategory5Level3 = "none";


                string[] level3 = new string[20];
                level3[0] = Question1Level3GroupBox.Text;
                level3[1] = Question1CorrectLevel3RadioButton.Text;
                level3[2] = GetSelectedRadioButtonText(Question1Level3GroupBox);
                level3[3] = wrongCategory1Level3;
                level3[4] = Question2Level3GroupBox.Text;
                level3[5] = Question2CorrectLevel3RadioButton.Text;
                level3[6] = GetSelectedRadioButtonText(Question2Level3GroupBox);
                level3[7] = wrongCategory2Level3;
                level3[8] = Question3Level3GroupBox.Text;
                level3[9] = Question3CorrectLevel3RadioButton.Text;
                level3[10] = GetSelectedRadioButtonText(Question3Level3GroupBox);
                level3[11] = wrongCategory3Level3;
                level3[12] = Question4Level3GroupBox.Text;
                level3[13] = Question4CorrectLevel3RadioButton.Text;
                level3[14] = GetSelectedRadioButtonText(Question4Level3GroupBox);
                level3[15] = wrongCategory4Level3;
                level3[16] = Question5Level3GroupBox.Text;
                level3[17] = Question5CorrectLevel3RadioButton.Text;
                level3[18] = GetSelectedRadioButtonText(Question5Level3GroupBox);
                level3[19] = wrongCategory5Level3;



                for (int i = 0; i < level3.Length; i = i + 4)
                {

                    string Query = "insert into Level3Table (username, Question, CorrectAnswer, UsersAnswer, WrongCategory) values ('" + usernameLoginTextBox.Text + "', '" + level3[i] + "', '" + level3[i + 1] + "', '" + level3[i + 2] + "', '" + level3[i + 3] + "')";
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand(Query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }


                SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from Level3Table where username ='" + usernameLoginTextBox.Text + "'and WrongCategory = 'none'", conn1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string level3Status = null;

                if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= 3)
                {
                    level3Status = "Pass";
                }
                else
                {
                    level3Status = "Fail";
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("select WrongCategory, count(*) as count from Level3Table where username ='" + usernameLoginTextBox.Text + "'group by WrongCategory order by count DESC", conn1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                string totalWrongCategoryLevel3 = null;
                totalWrongCategoryLevel3 = dt1.Rows[0]["WrongCategory"].ToString();

                string Query1 = "UPDATE StudentsPerformanceTable SET LevelNumber = '" + levelNumber + "', Status = '" + level3Status + "', WrongCategory = '" + totalWrongCategoryLevel3 + "', TimesVisitedTheory = '" + timesVisitedTheoryLevel3 + "' where username = '" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'";
                string Query2 = "insert into StudentsPerformanceTable (username, LevelNumber, Status, WrongCategory, TimesVisitedTheory) values ('" + usernameLoginTextBox.Text + "', '" + levelNumber + "', '" + level3Status + "', '" + totalWrongCategoryLevel3 + "', '" + timesVisitedTheoryLevel3 + "')";
                SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                SqlCommand cmd2 = new SqlCommand(Query2, conn1);
                //pinakas StudentsPerformance levelnumber = 1 status = P alliws F  
                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    try
                    {

                        conn1.Open();
                        cmd1.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                if (totalWrongCategoryLevel3 == "grammar")
                {
                    WrongCategoryLevel3Label.Text = "Γραμματική";
                    GrammarTitleSpecificTheoryLevel3Label.Text = GrammarTitleLevel3Label.Text;
                    ShowSpecificTheoryGrammarLevel3Label.Text = GrammarTheoryLevel3Label.Text;
                }
                else if (totalWrongCategoryLevel3 == "vocabulary")
                {
                    WrongCategoryLevel3Label.Text = "Λεξιλόγιο";
                    VocabularyTitleSpecificTheoryLevel3Label.Text = VocabularyTitleLevel3Label.Text;
                    ShowSpecificTheoryVocabularyLevel3Label.Text = VocabularyTheoryLevel3Label.Text;
                }
                else if (totalWrongCategoryLevel3 == "all")
                {
                    WrongCategoryLevel3Label.Text = "Γραμματική και Λεξιλόγιο";
                    GrammarTitleSpecificTheoryLevel3Label.Text = GrammarTitleLevel3Label.Text;
                    ShowSpecificTheoryGrammarLevel3Label.Text = GrammarTheoryLevel3Label.Text;
                    VocabularyTitleSpecificTheoryLevel3Label.Text = VocabularyTitleLevel3Label.Text;
                    ShowSpecificTheoryVocabularyLevel3Label.Text = VocabularyTheoryLevel3Label.Text;
                }

                if (level3Status == "Pass")
                {
                    MessageBox.Show("Μπράβο, πέρασες το επίπεδο! Συγχαρητήρια!");
                    goToAccount();
                }
                else
                {
                    MessageBox.Show("Δυστυχώς, δεν πέρασες το επίπεδο. Διάβασε ξανά τη θεωρία και δοκίμασε από την αρχή.");
                    tabControl.SelectedTab = SpecificTheoryLevel3TabPage;
                }
                conn1.Close();
            }
            else
            {
                MessageBox.Show("Πρέπει να απαντήσεις όλες τις ερωτήσεις.");
            }
            
        }

        private void Level3TheoryButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");

            SqlDataAdapter sda3 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "' and LevelNumber='" + levelNumber.ToString() + "'", conn1);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                if (dt3.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda4 = new SqlDataAdapter("select TimesVisitedTheory from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                    DataTable dt4 = new DataTable();
                    sda4.Fill(dt4);
                    timesVisitedTheoryLevel3 = Convert.ToInt32(dt4.Rows[0][0].ToString()) + 1;
                }
                else
                {
                    timesVisitedTheoryLevel3 = 1;
                }
            }
            else
            {
                timesVisitedTheoryLevel3 = 1;
            }


            tabControl.SelectedTab = TheoryLevel3TabPage;
        }

        private void Level3TestButton_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel3TabPage;
        }

        private void backToAccountLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void SignOutLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void TestFromTheoryLevel3Button_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = TestLevel3TabPage;
        }

        private void BackToLevel3TheoryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level3TabPage;
        }

        private void SignOutTheoryLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void BackToLevel3TestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = Level3TabPage;
        }

        private void SignOutTestLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void backToAccountSpecificTheoryLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = myAccountTabPage;
        }

        private void SignOutSpecificTheoryLevel3LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void SignOutTestRevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void TheoryLevel1LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = TheoryLevel1TabPage;
        }

        private void TheoryLevel2LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = TheoryLevel2TabPage;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl.SelectedTab = TheoryLevel3TabPage;
        }

        private void FinishTestRevisionButton_Click(object sender, EventArgs e)
        {
            bool isChecked1Revision = false;
            bool isChecked2Revision = false;
            bool isChecked3Revision = false;
            bool isChecked4Revision = false;
            bool isChecked5Revision = false;

            foreach (RadioButton radioButton1 in Question1RevisionGroupBox.Controls)
            {
                if (radioButton1.Checked == true)
                {
                    isChecked1Revision = true;
                }
            }
            foreach (RadioButton radioButton2 in Question2RevisionGroupBox.Controls)
            {
                if (radioButton2.Checked == true)
                {
                    isChecked2Revision = true;
                }
            }
            foreach (RadioButton radioButton3 in Question3RevisionGroupBox.Controls)
            {
                if (radioButton3.Checked == true)
                {
                    isChecked3Revision = true;
                }
            }
            foreach (RadioButton radioButton4 in Question4RevisionGroupBox.Controls)
            {
                if (radioButton4.Checked == true)
                {
                    isChecked4Revision = true;
                }
            }
            foreach (RadioButton radioButton5 in Question5RevisionGroupBox.Controls)
            {
                if (radioButton5.Checked == true)
                {
                    isChecked5Revision = true;
                }
            }

            if (isChecked1Revision == true && isChecked2Revision == true && isChecked3Revision == true && isChecked4Revision == true && isChecked5Revision == true)
            {
                string wrongCategory1Revision;
                string wrongCategory2Revision;
                string wrongCategory3Revision;
                string wrongCategory4Revision;
                string wrongCategory5Revision;

                if (Question1GrammarWrongRevisionRadioButton.Checked == true)
                {

                    wrongCategory1Revision = "grammar";
                }
                else if (Question1VocabularyWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory1Revision = "vocabulary";
                }
                else if (Question1AllWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory1Revision = "all";
                }
                else wrongCategory1Revision = "none";

                if (Question2GrammarWrongRevisionRadioButton.Checked == true)
                {

                    wrongCategory2Revision = "grammar";
                }
                else if (Question2VocabularyWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory2Revision = "vocabulary";
                }
                else if (Question2AllWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory2Revision = "all";
                }
                else wrongCategory2Revision = "none";

                if (Question3GrammarWrongRevisionRadioButton.Checked == true)
                {

                    wrongCategory3Revision = "grammar";
                }
                else if (Question3VocabularyWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory3Revision = "vocabulary";
                }
                else if (Question3AllWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory3Revision = "all";
                }
                else wrongCategory3Revision = "none";

                if (Question4GrammarWrongRevisionRadioButton.Checked == true)
                {

                    wrongCategory4Revision = "grammar";
                }
                else if (Question4VocabularyWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory4Revision = "vocabulary";
                }
                else if (Question1AllWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory4Revision = "all";
                }
                else wrongCategory4Revision = "none";

                if (Question5GrammarWrongRevisionRadioButton.Checked == true)
                {

                    wrongCategory5Revision = "grammar";
                }
                else if (Question5VocabularyWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory5Revision = "vocabulary";
                }
                else if (Question5AllWrongRevisionRadioButton.Checked == true)
                {
                    wrongCategory5Revision = "all";
                }
                else wrongCategory5Revision = "none";


                string[] revision = new string[20];
                revision[0] = Question1RevisionGroupBox.Text;
                revision[1] = Question1CorrectRevisionRadioButton.Text;
                revision[2] = GetSelectedRadioButtonText(Question1RevisionGroupBox);
                revision[3] = wrongCategory1Revision;
                revision[4] = Question2RevisionGroupBox.Text;
                revision[5] = Question2CorrectRevisionRadioButton.Text;
                revision[6] = GetSelectedRadioButtonText(Question2RevisionGroupBox);
                revision[7] = wrongCategory2Revision;
                revision[8] = Question3RevisionGroupBox.Text;
                revision[9] = Question3CorrectRevisionRadioButton.Text;
                revision[10] = GetSelectedRadioButtonText(Question3RevisionGroupBox);
                revision[11] = wrongCategory3Revision;
                revision[12] = Question4RevisionGroupBox.Text;
                revision[13] = Question4CorrectRevisionRadioButton.Text;
                revision[14] = GetSelectedRadioButtonText(Question4RevisionGroupBox);
                revision[15] = wrongCategory4Revision;
                revision[16] = Question5RevisionGroupBox.Text;
                revision[17] = Question5CorrectRevisionRadioButton.Text;
                revision[18] = GetSelectedRadioButtonText(Question5RevisionGroupBox);
                revision[19] = wrongCategory5Revision;



                for (int i = 0; i < revision.Length; i = i + 4)
                {

                    string Query = "insert into RevisionTable (username, Question, CorrectAnswer, UsersAnswer, WrongCategory) values ('" + usernameLoginTextBox.Text + "', '" + revision[i] + "', '" + revision[i + 1] + "', '" + revision[i + 2] + "', '" + revision[i + 3] + "')";
                    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand(Query, conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    conn.Close();
                }


                SqlConnection conn1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from RevisionTable where username ='" + usernameLoginTextBox.Text + "'and WrongCategory = 'none'", conn1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string revisionStatus = null;

                if (Convert.ToInt32(dt.Rows[0][0].ToString()) >= 3)
                {
                    revisionStatus = "Pass";
                }
                else
                {
                    revisionStatus = "Fail";
                }
                SqlDataAdapter sda1 = new SqlDataAdapter("select WrongCategory, count(*) as count from RevisionTable where username ='" + usernameLoginTextBox.Text + "'group by WrongCategory order by count DESC", conn1);
                DataTable dt1 = new DataTable();
                sda1.Fill(dt1);
                string totalWrongCategoryRevision = null;
                totalWrongCategoryRevision = dt1.Rows[0]["WrongCategory"].ToString();

                string Query1 = "UPDATE StudentsPerformanceTable SET LevelNumber = '" + levelNumber + "', Status = '" + revisionStatus + "', WrongCategory = '" + totalWrongCategoryRevision + "', TimesVisitedTheory = '" + timesVisitedTheoryRevision + "' where username = '" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'";
                string Query2 = "insert into StudentsPerformanceTable (username, LevelNumber, Status, WrongCategory, TimesVisitedTheory) values ('" + usernameLoginTextBox.Text + "', '" + levelNumber + "', '" + revisionStatus + "', '" + totalWrongCategoryRevision + "', '" + timesVisitedTheoryRevision + "')";
                SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                SqlCommand cmd2 = new SqlCommand(Query2, conn1);
                //pinakas StudentsPerformance levelnumber = 1 status = P alliws F  
                SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'and LevelNumber='" + levelNumber.ToString() + "'", conn1);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                if (dt2.Rows[0][0].ToString() == "1")
                {
                    try
                    {

                        conn1.Open();
                        cmd1.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        conn1.Open();
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


                if (totalWrongCategoryRevision == "grammar")
                {
                    WrongCategoryGrammar1RevisionLabel.Text = "Γραμματική";
                    WrongCategoryGrammar2RevisionLabel.Text = "Γραμματική";
                    WrongCategoryGrammar3RevisionLabel.Text = "Γραμματική";
                    GrammarTitle1SpecificTheoryRevisionLabel.Text = GrammarTitleLevel1Label.Text;
                    ShowSpecificTheoryGrammar1RevisionLabel.Text = GrammarTheoryLevel1Label.Text;
                    GrammarTitle2SpecificTheoryRevisionLabel.Text = GrammarTitleLevel2Label.Text;
                    ShowSpecificTheoryGrammar2RevisionLabel.Text = GrammarTheoryLevel2Label.Text;
                    GrammarTitle3SpecificTheoryRevisionLabel.Text = GrammarTitleLevel3Label.Text;
                    ShowSpecificTheoryGrammar3RevisionLabel.Text = GrammarTheoryLevel3Label.Text;
                    ContinueGrammar3Revision.Hide();
                    BackVocabularyRevision.Hide();
                }
                else if (totalWrongCategoryRevision == "vocabulary")
                {
                    WrongCategoryVocabularyRevisionLabel.Text = "Λεξιλόγιο";
                    VocabularyTitleSpecificTheoryRevisionLabel.Text = VocabularyTitleLevel3Label.Text;
                    ShowSpecificTheoryVocabulary1RevisionLabel.Text = VocabularyTheoryLevel1Label.Text;
                    ShowSpecificTheoryVocabulary2RevisionLabel.Text = VocabularyTheoryLevel2Label.Text;
                    ShowSpecificTheoryVocabulary3RevisionLabel.Text = VocabularyTheoryLevel3Label.Text;
                    BackVocabularyRevision.Hide();
                }
                else if (totalWrongCategoryRevision == "all")
                {
                    WrongCategoryGrammar1RevisionLabel.Text = "Γραμματική και Λεξιλόγιο";
                    WrongCategoryGrammar2RevisionLabel.Text = "Γραμματική και Λεξιλόγιο";
                    WrongCategoryGrammar3RevisionLabel.Text = "Γραμματική και Λεξιλόγιο";
                    WrongCategoryVocabularyRevisionLabel.Text = "Γραμματική και Λεξιλόγιο";
                    GrammarTitle1SpecificTheoryRevisionLabel.Text = GrammarTitleLevel1Label.Text;
                    ShowSpecificTheoryGrammar1RevisionLabel.Text = GrammarTheoryLevel1Label.Text;
                    GrammarTitle2SpecificTheoryRevisionLabel.Text = GrammarTitleLevel2Label.Text;
                    ShowSpecificTheoryGrammar2RevisionLabel.Text = GrammarTheoryLevel2Label.Text;
                    GrammarTitle3SpecificTheoryRevisionLabel.Text = GrammarTitleLevel3Label.Text;
                    ShowSpecificTheoryGrammar3RevisionLabel.Text = GrammarTheoryLevel3Label.Text;
                    VocabularyTitleSpecificTheoryRevisionLabel.Text = VocabularyTitleLevel3Label.Text;
                    ShowSpecificTheoryVocabulary1RevisionLabel.Text = VocabularyTheoryLevel1Label.Text;
                    ShowSpecificTheoryVocabulary2RevisionLabel.Text = VocabularyTheoryLevel2Label.Text;
                    ShowSpecificTheoryVocabulary3RevisionLabel.Text = VocabularyTheoryLevel3Label.Text;
                }

                if (revisionStatus == "Pass")
                {
                    MessageBox.Show("Μπράβο, πέρασες το επίπεδο! Συγχαρητήρια!");
                    goToAccount();
                }
                else
                {
                    MessageBox.Show("Δυστυχώς, δεν πέρασες το επίπεδο. Διάβασε ξανά τη θεωρία και δοκίμασε από την αρχή.");
                    if (totalWrongCategoryRevision == "grammar" || totalWrongCategoryRevision == "all")
                    {
                        tabControl.SelectedTab = SpecificTheoryGrammar1RevisionTabPage;
                    }
                    else
                    {
                        tabControl.SelectedTab = SpecificTheoryVocabularyRevisionTabPage;
                    }
                }
                conn1.Close();
            }
            else
            {
                MessageBox.Show("Πρέπει να απαντήσεις όλες τις ερωτήσεις.");
            }

            
        }

        private void backToAccountRevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void ContinueGrammar1Revision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryGrammar2RevisionTabPage;
        }

        private void ContinueGrammar2Revision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryGrammar3RevisionTabPage;
        }

        private void BackGrammar2Revision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryGrammar1RevisionTabPage;
        }

        private void ContinueGrammar3Revision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryVocabularyRevisionTabPage;
        }

        private void BackGrammar3Revision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryGrammar2RevisionTabPage;
        }

        private void BackVocabularyRevision_Click(object sender, EventArgs e)
        {
            tabControl.SelectedTab = SpecificTheoryGrammar3RevisionTabPage;
        }

        private void backToAccountSpecificTheoryVocabularyRevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void backToAccountSpecificTheoryGrammar3RevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void backToAccountSpecificTheoryGrammar2RevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void backToAccountSpecificTheoryGrammar1RevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            goToAccount();
        }

        private void RevisionPictureBox_Click(object sender, EventArgs e)
        {
            levelNumber = "Revision";
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\annou\OneDrive\Έγγραφα\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("select Status from StudentsPerformanceTable where username ='" + usernameLoginTextBox.Text + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
              
                if (dt.Rows.Count == 3 && dt.Rows[0][0].ToString() == "Pass" && (dt.Rows[1][0].ToString() == "Pass" && dt.Rows[2][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = RevisionTabPage;
                }
                else if (dt.Rows.Count == 4 && dt.Rows[0][0].ToString() == "Pass" && dt.Rows[1][0].ToString() == "Pass" && (dt.Rows[2][0].ToString() == "Pass" || dt.Rows[3][0].ToString() == "Pass"))
                {
                    tabControl.SelectedTab = RevisionTabPage;
                }
                else
                {
                    MessageBox.Show("Για να πας στην Επανάληψη (Revision) πρέπει πρώτα να έχεις περάσει το Επίπεδο 3 (Level 3).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Για να πας στην Επανάληψη (Revision) πρέπει πρώτα να έχεις περάσει το Επίπεδο 3 (Level 3).", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LinguaggioForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myDatabaseDataSet.StudentsPerformanceTable' table. You can move, or remove it, as needed.
            this.studentsPerformanceTableTableAdapter.Fill(this.myDatabaseDataSet.StudentsPerformanceTable);

        }

        private void SignOutProfessorLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }

        private void QuestionMark1PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp1Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark2PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp2Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark3PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp3Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark4PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp4Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark5PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp5Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark6PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp6Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark7PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp7Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark8PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp8Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark9PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp9Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark10PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp10Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void QuestionMark11PictureBox_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void NeedHelp11Label_Click(object sender, EventArgs e)
        {
            OnlineHelpForm form = new OnlineHelpForm();
            form.Show();
        }

        private void SignOutSpecificTheoryVocabularyRevisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearAll();
        }
    }
}