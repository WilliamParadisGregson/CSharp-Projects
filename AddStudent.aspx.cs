using System;
using Lab_8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab_8
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void cmdOK_Click(object sender, EventArgs e)
        {
            List<Student> lst;
            nameError.Visible = false;
            dropError.Visible = false;
            if (stuName.Text == "")
            {
                nameError.Text = "You must enter a name!";
                nameError.Visible = true;
            }

            if (dropdown.SelectedValue == "-1")
            {
                dropError.Text = "Please pick a position!";
                dropError.Visible = true;
            }

            if (Session["students"] == null)
                    lst = new List<Student>();
            else
                    lst = (List<Student>)Session["students"];
            if (dropError.Visible == false || nameError.Visible == false)
            {
                if (dropdown.SelectedValue == "0")
                {
                    lst.Add(new FulltimeStudent(stuName.Text));
                }
                if (dropdown.SelectedValue == "1")
                {
                    lst.Add(new ParttimeStudent(stuName.Text));
                }
                if (dropdown.SelectedValue == "2")
                {
                    lst.Add(new CoopStudent(stuName.Text));
                }

                Session["students"] = lst;
                foreach (Student student in lst)
                {
                    TableRow rowNew = new TableRow();
                    tblStudent.Rows.Add(rowNew);

                    TableCell cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = student.Id.ToString();

                    cell = new TableCell();
                    rowNew.Cells.Add(cell);
                    cell.Text = student.Name;
                }
            }     
            stuName.Text = String.Empty;
            this.dropdown.SelectedIndex = -1;
        }
    }
}