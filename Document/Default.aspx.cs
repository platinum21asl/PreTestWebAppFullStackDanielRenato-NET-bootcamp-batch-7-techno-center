using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Document_Default : System.Web.UI.Page
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
        repeaterDocument.DataSource = db.Table_Documents.Select(x => new
        {
            x.ID,
            x.UID,
            x.IDCompany,
            x.IDCategory,
            x.Name,
            NameCompany = x.Table_Company.Name,
            NameCategory = x.Table_Document_Category.Name,
            x.Description
 

        }).ToArray();
        repeaterDocument.DataBind();


    }

    protected void repeaterDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            if (e.CommandName == "Update")
            {
                Response.Redirect("/Document/Form.aspx?uid=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {

                var user = db.Table_Documents.FirstOrDefault(x => x.UID.ToString() == e.CommandArgument.ToString());
                db.Table_Documents.DeleteOnSubmit(user);
                db.SubmitChanges();

                LoadData(db);
            }

        }
    }
}