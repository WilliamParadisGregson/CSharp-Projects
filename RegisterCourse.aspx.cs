using System;
using Lab_8.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Lab_8
{
	public partial class RegisterCourse : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack == false)
			{
				foreach (Course b in Helper.GetAvailableCourses())
				{
					courseList.Items.Add(new ListItem(b.Title + " - " + b.WeeklyHours + " Hours/Week", b.Code));
				}

				int val = 0;
				foreach (Student student in (List<Student>)Session["students"])
				{
					studentDropdown.Items.Add(new ListItem(student.ToString(), val.ToString()));
					val++;
				}
			}
		}

		protected void cmdOK_Click(object sender, System.EventArgs e)
		{
			double totalHours = 0;
			int numberOfCourses = 0;

			List<Student> slst = (List<Student>)Session["students"];
			List<Course> clst = new List<Course>();


			foreach (ListItem listItem in courseList.Items)
			{
				if (listItem.Selected == true)
				{
					numberOfCourses++;

					Course c = Helper.GetCourseByCode(listItem.Value);
					clst.Add(c);

					totalHours += c.WeeklyHours;
				}
			}



			if (studentDropdown.SelectedValue == "-1")
			{
				studentError.Text = "Please pick a student!";
				studentError.Visible = true;
				registered.Visible = false;
			}
			else
			{
				studentError.Visible = false;
				registered.Visible = true;
			}

			if (studentError.Visible == false)
			{
				try
				{
					slst[int.Parse(studentDropdown.SelectedValue)].RegisterCourses(clst);
					courseError.Visible = false;
				}
				catch (Exception exception)
				{
					courseError.Text = exception.Message;
					courseError.Visible = true;
					registered.Visible = false;
				}
			}
			registered.Text = "Selected student has registered " + numberOfCourses + " course(s), " + totalHours + " hours weekly";
		}

		protected void studentDropdown_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<Student> slst = (List<Student>)Session["students"];

			double totalHours = 0;
			int numberOfCourses = 0;

			foreach (ListItem listItem in courseList.Items)
			{
				listItem.Selected = false;
			}

			foreach (ListItem listItem in courseList.Items)
			{
				foreach (Course course in slst[int.Parse(studentDropdown.SelectedValue)].registeredCourses)
				{
					if (Helper.GetCourseByCode(listItem.Value).Code == course.Code)
					{
						listItem.Selected = true;
						break;
					}
				}
				if (listItem.Selected == true)
				{
					Course c = Helper.GetCourseByCode(listItem.Value);
					numberOfCourses++;
					totalHours += c.WeeklyHours;
				}
			}
			registered.Text = "Selected student has registered " + numberOfCourses + " course(s), " + totalHours + " hours weekly";
		}
			
	}
}