using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using statements required for EF DB access
using COMP229_F2016_MidTerm__300857555_.Models;
using System.Web.ModelBinding;

namespace COMP229_F2016_MidTerm__300857555_
{
    public partial class TodoDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.Gettodos();
            }
        }

        protected void Gettodos()
        {
            // populate the form with existing data from db
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoContext db = new TodoContext())
            {
                // populate a Todo object instance with the TodoID from 
                // the URL parameter
               Todo updatedTodo = (from Todo in db.Todos
                                          where Todo.TodoID == TodoID
                                          select Todo).FirstOrDefault();

                // map the Todo properties to the form control
                if (updatedTodo != null)
                {
                    TodoDescriptionTextBox.Text = updatedTodo.TodoDescription;
                    TodoNotesTextBox.Text = updatedTodo.TodoNotes;
                    CompleteTextBox.Text = updatedTodo.Completed.ToString();
                }
            }
        }
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to the TodoList page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to conect to the server
            using (TodoContext db = new TodoContext())
            {

                // save a new record

                Todo newTodo = new Todo();

                int TodoName = 0;

                if (Request.QueryString.Count > 0) // our URL has a TodoName in it
                {
                    // get the id from the URL
                }

                // add form data to the new Todo record
                newTodo.TodoDescription = TodoDescriptionTextBox.Text;
                newTodo.TodoNotes = TodoNotesTextBox.Text;
                newTodo.Completed = Convert.ToBoolean(CompleteTextBox.Text);

                // use LINQ to ADO.NET to add / insert new Todo into the db

                if (TodoName == 0)
                {
                    db.Todos.Add(newTodo);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated Todo page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}
