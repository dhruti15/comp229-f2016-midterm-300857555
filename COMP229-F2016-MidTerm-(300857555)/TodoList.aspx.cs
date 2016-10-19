using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// using statements that are required to connect to EF DB
using COMP229_F2016_MidTerm__300857555_.Models;
using System.Web.ModelBinding;


namespace COMP229_F2016_MidTerm__300857555_
{
    public partial class TodoList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time
            // populate the student grid
            if (!IsPostBack)
            {
                // Get the Todo data
                this.GetTodos();
            }
        }
        /// <summary>
        /// This method gets the Todo data from the DB
        /// </summary>
        private void GetTodos()
        {
            // connect to EF DB
            using (TodoContext db = new TodoContext())
            {
                // query the Todo Table using EF and LINQ
                var Todos = (from allTodos in db.Todos
                                select allTodos);

                // bind the result to the Students GridView
                TodoListGridView.DataSource = Todos.ToList();
                TodoListGridView.DataBind();
            }
        }

        protected void TodoListGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected TodoID using the Grid's DataKey collection
            int TodoID = Convert.ToInt32(TodoListGridView.DataKeys[selectedRow].Values["TodoID"]);

            // use EF and LINQ to find the selected student in the DB and remove it
            using (TodoContext db = new TodoContext())
            {
                // create object ot the student clas and store the query inside of it
                Todo deletedTodos = (from TodoRecords in db.Todos
                                          where TodoRecords.TodoID == TodoID
                                          select TodoRecords).FirstOrDefault();

                // remove the selected student from the db
                db.Todos.Remove(deletedTodos);

                // save my changes back to the db
                db.SaveChanges();

                // refresh the grid
                this.GetTodos();
            }


        }

      
    }
    }
