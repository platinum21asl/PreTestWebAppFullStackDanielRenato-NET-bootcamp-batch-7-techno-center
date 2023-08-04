using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Position_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerPosition dbPosition = new ControllerPosition(db);

                var position = dbPosition.Cari(Request.QueryString["uid"]);

                if (position != null)
                {
                    InputName.Text = position.Name;
   
                    ButtonOk.Text = "Update";
                    LabelTitle.Text = "Update Position";
                }
                else
                {
                    ButtonOk.Text = "Add Now";
                    LabelTitle.Text = "Add New Position";

                }
            }
        }
    }

    protected void ButtonOk_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerPosition dbPosition = new ControllerPosition(db);

                if (ButtonOk.Text == "Add Now")
                {
                    dbPosition.Create(InputName.Text);
                }
                else if (ButtonOk.Text == "Update")
                {
                    dbPosition.Update(Request.QueryString["uid"], InputName.Text);
                }

                db.SubmitChanges();

                Response.Redirect("/Position/Default.aspx");
            }
        }

    }

    protected void ButtonKeluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Position/Default.aspx");
    }
}