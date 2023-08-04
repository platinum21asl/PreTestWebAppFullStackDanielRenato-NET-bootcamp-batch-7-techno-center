using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            if (!IsPostBack)
            {
                LoadData(db);
            }
        }
    }

    private void LoadData(DataClassesDatabasesPreTestDataContext db)
    {
        repeaterUser.DataSource = db.Table_Users.Select(x => new
        {
            x.ID,
            x.UID,
            x.IDCompany,
            x.IDPosition,
            x.Name,
            NameCompany = x.Table_Company.Name,
            NamePosition = x.Table_Position.Name,
            x.Email,
            x.Telephone,
            x.Role

        }).ToArray();
        repeaterUser.DataBind();

        
    }

    protected void repeaterUser_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            if (e.CommandName == "Update")
            {
                Response.Redirect("/User/Form.aspx?uid=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {

                var user = db.Table_Users.FirstOrDefault(x => x.UID.ToString() == e.CommandArgument.ToString());
                db.Table_Users.DeleteOnSubmit(user);
                db.SubmitChanges();

                LoadData(db);
            }

        }
    }
}