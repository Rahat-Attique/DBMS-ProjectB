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
using System.Text.RegularExpressions;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace projectB
{
    public partial class Update_Clo : Form
    {
        int stuid;
        int cloid;
        int rlid;
        int acid;
        int aid;
        int mid;

        //  Tabs.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);

        public Update_Clo()
        {
            InitializeComponent();
            dispalydata();
            disp_rub();
            disp_clo();
            fillcombo();
            fillrcombo();
            fillscombo();
            fillecombo();
            //Fillr();
            //(int cID);
            ae();


        }

        SqlConnection con = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True");

        SqlCommand cmd;
        public void fillcombo()//binding clo  into combo  box
        {

            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Name FROM Clo", con))
            {
                //Fill the DataTable with records from Table.
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Insert the Default Item to DataTable.
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "Please select";
                dt.Rows.InsertAt(row, 0);

                //Assign DataTable as DataSource.
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "Id";
            }
        }
        public void fillscombo()//binding student  into combo  box
        {

            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, RegistrationNumber FROM Student", con))
            {
                evaluation e = new evaluation();
                //Fill the DataTable with records from Table.
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Insert the Default Item to DataTable.
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "Please select";
                dt.Rows.InsertAt(row, 0);

                //Assign DataTable as DataSource.
                comboBox9.DataSource = dt;
                comboBox9.DisplayMember = "RegistrationNumber";
                comboBox9.ValueMember = "Id";
                comboBox6.DataSource = dt;
                comboBox6.DisplayMember = "RegistrationNumber";
                comboBox6.ValueMember = "Id";
            }
        }

        public void fillecombo()//binding assessments to combo box
        {

            //using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Name FROM AssessmentComponent", con))
            //{
            //    //Fill the DataTable with records from Table.
            //    DataTable dt = new DataTable();
            //    sda.Fill(dt);

            //    //Insert the Default Item to DataTable.
            //    DataRow row = dt.NewRow();
            //    row[0] = 0;
            //    row[1] = "Please select";
            //    dt.Rows.InsertAt(row, 0);

            //    //Assign DataTable as DataSource.
            //    sat.DataSource = dt;
            //    sat.DisplayMember = "Name";
            //    sat.ValueMember = "Id";


            //}
        }
        public void ae()
        {
            SqlConnection con = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id, Title FROM Assessment";

            DataSet objDs = new DataSet();

            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;

            con.Open();

            dAdapter.Fill(objDs);

            con.Close();

            ascom.ValueMember = "Id";

            ascom.DisplayMember = "Title";

            ascom.DataSource = objDs.Tables[0];
            comboBox1.ValueMember = "Id";

            comboBox1.DisplayMember = "Title";

            comboBox1.DataSource = objDs.Tables[0];
        }
        public void fillrcombo()//bindin rubrics to combo box
        {
            using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Id, Details FROM Rubric", con))
            {
                //Fill the DataTable with records from Table.
                DataTable dt = new DataTable();
                sda.Fill(dt);

                //Insert the Default Item to DataTable.
                DataRow row = dt.NewRow();
                //row[0] = Convert.ToInt32("Please Select");
                row[1] = "Please select";
                dt.Rows.InsertAt(row, 0);

                //Assign DataTable as DataSource.
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "Details";
                comboBox3.ValueMember = "Id";
                //   comboBox5.Text = "please select";
                comboBox5.DataSource = dt;
                comboBox5.DisplayMember = "Details";
                comboBox5.ValueMember = "Id";
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtfirstname.Text != "" && txtlastname.Text != "" && txtreg.Text != "" && txtemail.Text != "" && !(txtfirstname.Text.Any(c => Char.IsNumber(c))) && !(txtlastname.Text.Any(c => Char.IsNumber(c))))
            {
                con.Open();
                string query = "insert into Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) values ('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtcontact.Text + "','" + txtemail.Text + "','" + txtreg.Text + "',(select LookupId from Lookup where Name='" + comb_stat.Text + "'))";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                dispalydata();
                cleardata();




            }
            else
            {
                MessageBox.Show("Please Provide  Information in Correct format or provide full details!");
            }
        }
        int rubid;//Rubric id
        private void btn_del_Click(object sender, EventArgs e)//delete a student
        {

            if (stuid != 0)
            {
                //cmd 
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("delete studentresult from StudentResult where StudentId=@id", con);
                //   cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", stuid);
                cmd.ExecuteNonQuery();
                con.Close();
              
                cmd = new SqlCommand("delete studentattendance from StudentAttendance where StudentId=@id", con);
                //   cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", stuid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete student from Student where Id=@id", con);
                //   cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", stuid);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                dispalydata();
                cleardata();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }
        public void dispalydata()//display student data into grid view
        {
            DataTable dt = new DataTable();
            // SqlDataAdapter adapter = new SqlDataAdapter("Select * from Student", con);
            SqlDataAdapter adapter = new SqlDataAdapter("Select Student.Id, Student.FirstName,Student.LastName,Student.Contact,Student.Email,Student.RegistrationNumber,Lookup.Name from Student inner join Lookup on Student.Status=Lookup.LookupId", con);
            adapter.Fill(dt);
            stu_dg.DataSource = dt;
        }
        private void btn_update_Click(object sender, EventArgs e)//Update Studnet
        {
            if (txtfirstname.Text != "" && txtlastname.Text != "" && txtemail.Text != "" && txtcontact.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update Student set [FirstName]='" + txtfirstname.Text + "', [LastName] ='" + txtlastname.Text + "',Contact = '" + txtcontact.Text + "',Email='" + txtemail.Text + "', RegistrationNumber='" + txtreg.Text + "',Status=(select LookupId from Lookup where Name='" + comb_stat.Text + "') where Id ='" + stuid + "'", con);

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                dispalydata();
                cleardata();
            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter adapt = new SqlDataAdapter("Select isnull (max(cast(Id as int)),0)+1 from Student", con);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            //txtid.Text = dt.Rows[0][0].ToString();
            txtfirstname.Focus();
        }
        public void cleardata()
        {
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemail.Text = "";
            txtreg.Text = "";
            txtcontact.Text = "";
            comb_stat.Text = "";

        }//Clear the fields after data is entered

        private void stu_dg_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)//Selecting a row from grid view for deletion and updation
        {
            stuid = Convert.ToInt32(txtfirstname.Text = stu_dg.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtfirstname.Text = stu_dg.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastname.Text = stu_dg.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtcontact.Text = stu_dg.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtemail.Text = stu_dg.Rows[e.RowIndex].Cells[4].Value.ToString();
            // txtreg.Text = Convert.ToDateTime(stu_dg.Rows[e.RowIndex].Cells[5].Value.ToString()).ToString();
            txtreg.Text = stu_dg.Rows[e.RowIndex].Cells[5].Value.ToString();
            //comb_stat.Text = Convert.ToInt32(stu_dg.Rows[e.RowIndex].Cells[6].Value.ToString()).ToString();
            comb_stat.Text = stu_dg.Rows[e.RowIndex].Cells[6].Value.ToString().ToString();


        }

        private void button2_Click(object sender, EventArgs e)//Adding CLO
        {
            if (txtclo.Text != "")
            {
                con.Open();
                string query = "insert into Clo(Name,DateCreated,DateUpdated) values ('" + txtclo.Text + "','" + DateTime.Now + "','" + DateTime.Now + "')";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Clo", con);
                adapter.Fill(dt);
                clo_data.DataSource = dt;
                txtclo.Text = "";
            }


            else
            {
                MessageBox.Show("please Enter the required info");
            }
        }

        private void btn_clo_upd_Click(object sender, EventArgs e)//UPDATING clo
        {
            if (txtclo.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update Clo set [Name]='" + txtclo.Text + "', [DateUpdated] ='" + DateTime.Now + "' where Id ='" + cloid + "'", con);

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                txtclo.Text = "";
                con.Close();
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from clo", con);
                adapter.Fill(dt);
                clo_data.DataSource = dt;
                disp_rub();

            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }

        }

        private void clo_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clo_data_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)//Row Selection of Clo table
        {
            cloid = Convert.ToInt32(txtclo.Text = clo_data.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtclo.Text = clo_data.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            fillrcombo();


        }

        private void label3_FontChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)//Deleting the clo
        {

            if (cloid != 0)
            {
                cmd = new SqlCommand("delete rubriclevel select Rubric.CloId from RubricLevel inner join Rubric on RubricLevel.RubricId=Rubric.Id where Rubric.CloId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", cloid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete rubric where CloId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", cloid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete clo where Id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", cloid);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                txtclo.Text = "";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Clo", con);
                adapter.Fill(dt);
                clo_data.DataSource = dt;
                disp_rub();






            }


            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }



        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

            fillcombo();

        }


        private void button3_Click(object sender, EventArgs e)//Adding Rubrics
        {
            if (comboBox2.Text != "" && txtdetails.Text != "")
            {
                con.Open();
                string query = "insert into Rubric(Details,CloId) values ('" + txtdetails.Text + "',(select Id from Clo where Id='" + comboBox2.SelectedValue + "'))";

                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                txtdetails.Text = "";
                comboBox2.Text = "";

                disp_rub();

            }
            else
            {
                MessageBox.Show("Enter all Details");
            }
        }

        private void tabPage3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void Update_Clo_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from AssessmentComponent", con);
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            DataTable dtt = new DataTable();
            SqlDataAdapter adapterr = new SqlDataAdapter("Select * from Assessment", con);
            adapterr.Fill(dtt);
            dataGridView2.DataSource = dtt;
            DataTable d3t = new DataTable();
            SqlDataAdapter adapter3 = new SqlDataAdapter("Select AssessmentComponent.Name as ComponentName,Rubric.Details,AssessmentComponent.TotalMarks As componentMark,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As Obtained_Marks ,Student.FirstName,Student.Id from StudentResult inner join Student on Student.Id=StudentResult.StudentId  left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on RubricLevel.Id=StudentResult.RubricMeasurementId  ", con);

            adapter3.Fill(d3t);

            dataGridView7.DataSource = d3t;
            dataGridView7.DataSource = d3t;
            DataTable dtt4 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select AssessmentComponent.Name as ComponentName,Rubric.Details,AssessmentComponent.TotalMarks As componentMark,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As Obtained_Marks,Clo.Id,Clo.Name,Rubric.CloId ,Student.FirstName,Student.Id from StudentResult inner join Student on Student.Id=StudentResult.StudentId  left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on RubricLevel.Id=StudentResult.RubricMeasurementId left join Clo on Rubric.CloId=Clo.Id  ", con);

            adapter2.Fill(dtt4);

            dataGridView6.DataSource = dtt4;
            dataGridView6.DataSource = dtt4;
            con.Close();


        }

        private void stu_dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        public void disp_rub()//Dispaly Rubric
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * from Rubric", con);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Rubric.Id as RubricID , Rubric.Details as RubricDetails,Rubric.CloId, Clo.Name as CloName FROM Rubric INNER JOIN Clo ON Rubric.CloId = Clo.Id; ", con);
            adapter.Fill(dt);
            rubic_dg.DataSource = dt;
        }
        public void disp_rubl()//Dispaly Rubric Level
        {
            DataTable dt = new DataTable();
            // SqlDataAdapter adapter = new SqlDataAdapter("Select * from RubricLevel", con);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT RubricLevel.Id,RubricLevel.MeasurementLevel,RubricLevel.Details as RubricLevelDetails ,Rubric.Details as RubricDetails ,Rubric.Id as RubricId FROM RubricLevel INNER JOIN Rubric ON RubricLevel.RubricId = Rubric.Id;", con);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void disp_clo()//Display clo
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Clo", con);
            adapter.Fill(dt);
            clo_data.DataSource = dt;
        }

        private void btn_add_ass_Click(object sender, EventArgs e)//Adding Assessment
        {
            if (txttitle.Text != "" && txtmarks.Text != "" && txtweightage.Text != "")
            {
                con.Open();
                string query = "insert into Assessment(Title,TotalMarks,DateCreated,TotalWeightage) values ('" + txttitle.Text + "','" + txtmarks.Text + "','" + DateTime.Now + "','" + txtweightage.Text + "')";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");

                txttitle.Text = "";
                txtmarks.Text = "";
                txtweightage.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter all info");
            }
        }

        private void btn_comp_add_Click(object sender, EventArgs e)//Adding Assessment Components
        {
            if (txtcomp.Text != "" && txtmarkss.Text != "")
            {
                con.Open();
                string query = "insert into AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) values ('" + txtcomp.Text + "',(select Id from Rubric where Id='" + comboBox3.SelectedValue + "'),'" + txtmarkss.Text + "','" + DateTime.Now + "','" + DateTime.Now + "',(select Id from Assessment where Id='" + comboBox1.SelectedValue + "'))";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                DataTable dtt = new DataTable();
                SqlDataAdapter adapterr = new SqlDataAdapter("Select * from AssessmentComponent", con);
                adapterr.Fill(dtt);
                dataGridView3.DataSource = dtt;
                //cleardata();
            }
            else
            {
                MessageBox.Show("Please enter all info");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)//Adding Rubrics Level
        {

        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            fillcombo();
            disp_rubl();
        }

        private void btn_rub_del_Click(object sender, EventArgs e)//Deleting a Rubric
        {
            if (rubid != 0)

            {
                cmd = new SqlCommand("delete rubriclevel where RubricId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", rubid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete rubric where Id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", rubid);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                txtdetails.Text = "";
                comboBox2.Text = "";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Rubric", con);
                adapter.Fill(dt);
                rubic_dg.DataSource = dt;
                DataTable dtt = new DataTable();
                SqlDataAdapter adaptert = new SqlDataAdapter("Select * from RubricLevel", con);
                adapter.Fill(dtt);
                dataGridView1.DataSource = dtt;



            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtfirstname_Click(object sender, EventArgs e)
        {

        }

        private void txtlastname_CausesValidationChanged(object sender, EventArgs e)
        {

        }

        private void txtlastname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtemail_Leave(object sender, EventArgs e)//Email Validation
        {
            Regex mRegxExpression;
            if (txtemail.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(txtemail.Text.Trim()))
                {
                    MessageBox.Show("E-mail address format is not correct.", "MojoCRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtemail.Focus();
                }
            }
        }

        private void txtcontact_Leave(object sender, EventArgs e)
        {



        }

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)//Numeric Validation
        {


            //We only want to allow numeric style chars
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                //Setting e.Handled cancels the keypress event, so the key is not entered
                e.Handled = true;
            }


            //keypress occurs before the text is updated.  Therefore sender.Text excludes the current key e.KeyChar 
            if (char.IsDigit(e.KeyChar))
            {
                //Count the digits already in the text.  I'm using linq:
                if ((sender as TextBox).Text.Count(Char.IsDigit) >= 11)
                    e.Handled = true;
                //MessageBox.Show("nee");
            }
        }

        private void rubic_dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rubic_dg_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)//Selecting rubric row
        {
            rubid = Convert.ToInt32(txtdetails.Text = rubic_dg.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtdetails.Text = rubic_dg.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox2.Text = rubic_dg.Rows[e.RowIndex].Cells[3].Value.ToString();
            //comboBox2.Text = Convert.ToInt32(rubic_dg.Rows[e.RowIndex].Cells[3].Value.ToString()).ToString();

        }

        private void btn_rub_upd_Click(object sender, EventArgs e)//Updating Rubric
        {
            if (comboBox2.Text != "" && txtdetails.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update Rubric set [CloId]='" + comboBox2.SelectedValue + "', [Details] ='" + txtdetails.Text + "' where Id ='" + rubid + "'", con);

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                txtdetails.Text = "";
                comboBox2.Text = "";
                con.Close();
                disp_rub();
                disp_rubl();
            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }
        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {

        }


        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)//Deleting a Rubric Level
        {
            if (rlid != 0)

            {
                cmd = new SqlCommand("delete rubriclevel where Id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", rlid);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Succesfully");

                dettxt.Text = "";
                comboBox5.Text = "";
                comboBox7.Text = "";
                disp_rubl();



            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)//Adding Rubric Level
        {
            if (dettxt.Text != "" && comboBox5.Text != "")
            {
                con.Open();
                string query = "insert into RubricLevel(RubricId,Details,MeasurementLevel) values ((select Id from Rubric where Id = '" + comboBox5.SelectedValue + "'),'" + dettxt.Text + "','" + comboBox7.Text + "')";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                dettxt.Text = "";
                comboBox5.Text = "";
                comboBox7.Text = "";
                disp_rubl();

            }
            else
            {
                MessageBox.Show("Please enter all info");
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //   this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 8);
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowDefaultCellStyleChanged(object sender, DataGridViewRowEventArgs e)
        {
            //dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
        }

        private void dataGridView1_ColumnHeadersDefaultCellStyleChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_DropDown(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)//Selecting Rubric Level
        {
            rlid = Convert.ToInt32(dettxt.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            dettxt.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //comboBox5.Text = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString()).ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)//Updating Rubric Level
        {
            if (comboBox7.Text != "" && dettxt.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update RubricLevel set [RubricId]='" + comboBox5.SelectedValue + "', [Details] ='" + dettxt.Text + "' where Id ='" + rlid + "'", con);

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                dettxt.Text = "";
                comboBox5.Text = "";
                comboBox7.Text = "";
                con.Close();
                //  disp_rub();
                disp_rubl();
            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }

        }


        private void btn_add_ass_Click_1(object sender, EventArgs e)//Adding Assessment
        {
            if (txttitle.Text != "" && txtmarks.Text != "" && txtweightage.Text != "")
            {
                con.Open();
                string query = "insert into Assessment(Title,DateCreated,TotalMarks,TotalWeightage) values ('" + txttitle.Text + "','" + DateTime.Now + "','" + txtmarks.Text + "','" + txtweightage.Text + "')";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");
                DataTable dt = new DataTable();
                //SqlDataAdapter adapter = new SqlDataAdapter("Select * from StudentAttendance", con);
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Assessment", con);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;




            }
            else
            {
                MessageBox.Show("Please Provide  Information in Correct format or provide full details!");
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int currentRow = int.Parse(e.RowIndex.ToString());
            //int currentColumnIndex = int.Parse(e.ColumnIndex.ToString());
            //if (currentColumnIndex == 0)
            //{
            //    evaluation v = new evaluation();

            //    v.textBox1.Text = this.dataGridView3.Rows[currentRow].Cells[2].Value.ToString();
            //    v.textBox2.Text = this.dataGridView3.Rows[currentRow].Cells[4].Value.ToString();
            //    v.Show();
            //    //    string address = dataGridView3.Rows[currentRow].Cells[2].Value.ToString();

            //}

        }

        internal class MySqlDataReader
        {
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tabPage6_Click_1(object sender, EventArgs e)
        {
            fillscombo();
        }
        private void FillStates(int countryID)

        {

            // SqlConnection con = new SqlConnection();
            SqlConnection con = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id, Name FROM AssessmentComponent WHERE AssessmentId =@CountryID";

            cmd.Parameters.AddWithValue("@CountryID", countryID);

            DataSet objDs = new DataSet();

            SqlDataAdapter dAdapter = new SqlDataAdapter();

            dAdapter.SelectCommand = cmd;

            con.Open();

            dAdapter.Fill(objDs);

            con.Close();

            if (objDs.Tables[0].Rows.Count > 0)
            {
                comcom.ValueMember = "Id";
                comcom.DisplayMember = "Name";
                comcom.DataSource = objDs.Tables[0];

            }
            
        }
        /// int r= Convert.ToInt32(textbox3)
        private void Fillr(int rid)

        {


            SqlConnection con = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True");


            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT Id, RubricId,MeasurementLevel FROM RubricLevel WHERE RubricID =@rid";

            cmd.Parameters.AddWithValue("@rid", rid);

            DataSet objDs = new DataSet();

            SqlDataAdapter dAdapter = new SqlDataAdapter();

            dAdapter.SelectCommand = cmd;

            con.Open();

            dAdapter.Fill(objDs);

            con.Close();

            if (objDs.Tables[0].Rows.Count > 0)

            {

                comboBox4.ValueMember = "Id";

                comboBox4.DisplayMember = "MeasurementLevel";

                comboBox4.DataSource = objDs.Tables[0];

            }

        }
        private void ascom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ascom.SelectedValue.ToString() != "")

            {

                int CountryID = Convert.ToInt32(ascom.SelectedValue.ToString());

                FillStates(CountryID);

               // comcom.SelectedIndex = 0;

            }
        }


        private void comcom_SelectedIndexChanged(object sender, EventArgs e)
        {

            int cID = Convert.ToInt32(comcom.SelectedValue.ToString());

            string query = "select *from  AssessmentComponent where Id = '" + Convert.ToString(comcom.SelectedValue) + "' ";

            SqlConnection con = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dbr;

            con.Open();
            dbr = cmd.ExecuteReader();

            while (dbr.Read())
            {
                // string ID = (string)dbr["ID"].tostring;
                string sname = (string)dbr["Name"]; // name is string value
                string rub = dbr["RubricId"].ToString();                                     //string ssurname = (string)dbr["surname"]
                string sage = (string)dbr["TotalMarks"].ToString();

                // textbox1.text = sid;
                textBox2.Text = sage;
                textBox3.Text = rub;
                using (SqlConnection coon = new SqlConnection(@"Data Source=hi;Initial Catalog=ProjectB;Integrated Security=True"))


                {
                    using (SqlDataAdapter da = new SqlDataAdapter("Select Id,MeasurementLevel from RubricLevel where RubricLevel.RubricId='" + dbr[2].ToString() + "'", coon))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comboBox4.ValueMember = "Id";
                        comboBox4.DisplayMember = "MeasurementLevel";
                        comboBox4.DataSource = dt;
                    }
                }
               
                // textBox3.Text = rub;//dbr["rub"].ToString();





            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            con.Open();
            string query = "insert into StudentResult(RubricMeasurementId,StudentId,AssessmentComponentId,EvaluationDate) values ('" + comboBox4.SelectedValue.ToString() + "',(select Id from Student where Id='" + comboBox9.SelectedValue + "'),(select Id from AssessmentComponent where Id='" + comcom.SelectedValue + "'),'" + DateTime.Now + "')";
            // string query = "insert into StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) values ('"+comboBox9.SelectedValue+"','" + ascom.SelectedValue + "','" + comboBox4.SelectedValue + "','"+DateTime.Now+"')";
            SqlDataAdapter cdn = new SqlDataAdapter(query, con);
            cdn.SelectCommand.ExecuteNonQuery();
            con.Close();
            con.Open();
            ////SELECT a.id, a.name, a.num, b.date, b.rollFROM a INNER JOIN b ON a.id = b.id;
            DataTable dt = new DataTable();
            // DataTable dt1 = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select AssessmentComponent.Name as ComponentName,Rubric.Details,AssessmentComponent.TotalMarks As componentMark,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As Obtained_Marks ,Student.FirstName,Student.Id from StudentResult inner join Student on Student.Id=StudentResult.StudentId and Student.Id='" + comboBox9.SelectedValue + "' left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on RubricLevel.Id=StudentResult.RubricMeasurementId  ", con);

            adapter.Fill(dt);

            dataGridView4.DataSource = dt;
            dataGridView4.DataSource = dt;
            DataTable d3t = new DataTable();
            SqlDataAdapter adapter3 = new SqlDataAdapter("Select AssessmentComponent.Name,Rubric.Details,AssessmentComponent.TotalMarks As componentMark,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As Obtained_Marks ,Student.FirstName,Student.Id from StudentResult inner join Student on Student.Id=StudentResult.StudentId  left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on RubricLevel.Id=StudentResult.RubricMeasurementId  ", con);

            adapter3.Fill(d3t);

            dataGridView7.DataSource = d3t;
            dataGridView7.DataSource = d3t;
            DataTable dtt4 = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select AssessmentComponent.Name,Rubric.Details,AssessmentComponent.TotalMarks As componentMark,((RubricLevel.MeasurementLevel*AssessmentComponent.TotalMarks)/4) As Obtained_Marks,Clo.Id,Clo.Name,Rubric.CloId ,Student.FirstName,Student.Id from StudentResult inner join Student on Student.Id=StudentResult.StudentId  left join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id left join Rubric on Rubric.Id=AssessmentComponent.RubricId left join RubricLevel on RubricLevel.Id=StudentResult.RubricMeasurementId left join Clo on Rubric.CloId=Clo.Id  ", con);

            adapter2.Fill(dtt4);

            dataGridView6.DataSource = dtt4;
            dataGridView6.DataSource = dtt4;
            con.Close();

        }
        ////   cn.SelectCommand.ExecuteNonQuery();
        //con.Close();
        //MessageBox.Show("Data Added Successfully");



        private void rcom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            int rid = Convert.ToInt32(textBox3.Text);
            //int rid = textBox3.Text;

            Fillr(rid);

            //comcom.SelectedIndex = 0;
        }

        private void Assessment_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void textBox3_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void att()
        {
            DataTable dt = new DataTable();
            //SqlDataAdapter adapter = new SqlDataAdapter("Select * from StudentAttendance", con);
            SqlDataAdapter adapter = new SqlDataAdapter("Select Student.Id, Student.FirstName,StudentAttendance.StudentId, StudentAttendance.AttendanceStatus from Student inner join StudentAttendance on Student.Id=StudentAttendance.StudentId", con);
            adapter.Fill(dt);
            dataGridView5.DataSource = dt;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            // if (txtfirstname.Text != "" && txtlastname.Text != "" && txtreg.Text != "" && txtemail.Text != "" && !(txtfirstname.Text.Any(c => Char.IsNumber(c))) && !(txtlastname.Text.Any(c => Char.IsNumber(c))))
            {

                con.Open();
                string query = "insert into ClassAttendance(AttendanceDate) values ('" + DateTime.Now + "')";
                SqlDataAdapter cdn = new SqlDataAdapter(query, con);
                cdn.SelectCommand.ExecuteNonQuery();
                con.Close();






                con.Open();
                string q = "insert into StudentAttendance(StudentId,AttendanceId,AttendanceStatus) values ('" + comboBox6.SelectedValue + "',(select Id from ClassAttendance where AttendanceDate= '" + DateTime.Now + "'),(select LookupId from Lookup where Name='" + fazoliat.Text + "'))";
                SqlDataAdapter cd = new SqlDataAdapter(q, con);
                cd.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Added Successfully");

                att();



            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (aid != 0)
            {
                //cmd 
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", aid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete assessmentcomponent where AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", aid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete assessment where Id=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", aid);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                txttitle.Text = "";
                txtmarks.Text = "";
                txtweightage.Text = "";
                DataTable dt = new DataTable();
                //SqlDataAdapter adapter = new SqlDataAdapter("Select * from StudentAttendance", con);
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Assessment", con);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;



                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT Id, Title FROM Assessment";

                DataSet objDs = new DataSet();

                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = cmd;

                con.Open();

                dAdapter.Fill(objDs);

                con.Close();

                ascom.ValueMember = "Id";

                ascom.DisplayMember = "Title";

                ascom.DataSource = objDs.Tables[0];
                comboBox1.ValueMember = "Id";

                comboBox1.DisplayMember = "Title";

                comboBox1.DataSource = objDs.Tables[0];



            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }





        }



        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            aid = Convert.ToInt32(txttitle.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            txttitle.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmarks.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtweightage.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

        }

        private void dataGridView4_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("Assessment.pdf", FileMode.Create));
            doc.Open();


            PdfPTable table = new PdfPTable(dataGridView4.Columns.Count);
            for (int j = 0; j < dataGridView4.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView4.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;
            for (int k = 0; k < dataGridView4.Rows.Count; k++)
            {
                for (int w = 0; w < dataGridView4.Columns.Count; w++)
                {
                    if (dataGridView4[w, k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView4[w, k].Value.ToString()));

                    }

                }
            }
            doc.Add(table);
            doc.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtcomp.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update AssessmentComponent set [Name]='" + txtcomp.Text + "', [TotalMarks] ='" + txtmarkss.Text + "',[RubricId]=(select Id from Rubric where Details='" + comboBox3.Text + "'),[AssessmentId]=(select Id from Assessment where Title='" + comboBox1.Text + "') where Id ='" + acid + "'", con);

                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
                txtcomp.Text = "";
                txtmarkss.Text = "";
                comboBox1.Text = "";
                comboBox3.Text = "";
                DataTable dt = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from AssessmentComponent", con);
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (txttitle.Text != "")
            {
                con.Open();
                SqlCommand command = new SqlCommand("Update Assessment set [Title] ='" + txttitle.Text + "',[TotalMarks] ='" + txtmarks.Text + "',[TotalWeightage] ='" + txtweightage.Text + "' where Id ='" + aid + "'", con);

                command.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                txttitle.Text = "";
                txtmarks.Text = "";
                txtweightage.Text = "";
                DataTable dt = new DataTable();
                //SqlDataAdapter adapter = new SqlDataAdapter("Select * from StudentAttendance", con);
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Assessment", con);
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "SELECT Id, Title FROM Assessment";

                DataSet objDs = new DataSet();

                SqlDataAdapter dAdapter = new SqlDataAdapter();
                dAdapter.SelectCommand = cmd;

                con.Open();

                dAdapter.Fill(objDs);

                con.Close();

                ascom.ValueMember = "Id";

                ascom.DisplayMember = "Title";

                ascom.DataSource = objDs.Tables[0];
                comboBox1.ValueMember = "Id";

                comboBox1.DisplayMember = "Title";

                comboBox1.DataSource = objDs.Tables[0];



            }
            else
            {
                MessageBox.Show("Please Select the row whose data you want to update");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            acid = Convert.ToInt32(txtcomp.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox3.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtmarkss.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void dataGridView3_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView3_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            acid = Convert.ToInt32(txtcomp.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox3.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtmarkss.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtcomp.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (acid != 0)
            {
                //cmd 
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("delete studentresult from StudentResult where AssessmentComponentId=@id", con);
                //   cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", acid);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = new SqlCommand("delete assessmentcomponent from AssessmentComponent where Id=@id", con);
                //   cmd = new SqlCommand("delete studentresult select AssessmentComponent.AssessmentId from StudentResult inner join AssessmentComponent on StudentResult.AssessmentComponentId=AssessmentComponent.Id where AssessmentComponent.AssessmentId=@id", con);
                con.Open();
                cmd.Parameters.AddWithValue("@id", acid);
                cmd.ExecuteNonQuery();
                con.Close();
                {
                    MessageBox.Show("Deleted");
                    txtcomp.Text = "";
                    txtmarkss.Text = "";
                    comboBox1.Text = "";
                    comboBox3.Text = "";
                    DataTable dt = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter("Select * from AssessmentComponent", con);
                    adapter.Fill(dt);
                    dataGridView3.DataSource = dt;
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("CLOWiseResult.pdf", FileMode.Create));
            doc.Open();


            PdfPTable table = new PdfPTable(dataGridView6.Columns.Count);
            for (int j = 0; j < dataGridView6.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView6.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;
            for (int k = 0; k < dataGridView6.Rows.Count; k++)
            {
                for (int w = 0; w < dataGridView6.Columns.Count; w++)
                {
                    if (dataGridView6[w, k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView6[w, k].Value.ToString()));

                    }

                }
            }
            doc.Add(table);
            doc.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter pdf = PdfWriter.GetInstance(doc, new FileStream("AssessmentWiseResult.pdf", FileMode.Create));
            doc.Open();


            PdfPTable table = new PdfPTable(dataGridView7.Columns.Count);
            for (int j = 0; j < dataGridView7.Columns.Count; j++)
            {
                table.AddCell(new Phrase(dataGridView7.Columns[j].HeaderText));

            }
            table.HeaderRows = 1;
            for (int k = 0; k < dataGridView7.Rows.Count; k++)
            {
                for (int w = 0; w < dataGridView7.Columns.Count; w++)
                {
                    if (dataGridView6[w, k].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView7[w, k].Value.ToString()));

                    }

                }
            }
            doc.Add(table);
            doc.Close();
        }
    }
}

