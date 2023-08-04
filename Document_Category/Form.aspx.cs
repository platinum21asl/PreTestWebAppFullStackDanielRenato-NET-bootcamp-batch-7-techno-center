using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Document_Category_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocumentCategory dbDocumentCategory = new ControllerDocumentCategory(db);

                var DocumentCategory = dbDocumentCategory.Cari(Request.QueryString["uid"]);

                if (DocumentCategory != null)
                {
                    InputName.Text = DocumentCategory.Name;
                    ButtonOk.Text = "Update";
                    LabelTitle.Text = "Update Document Category";
                }
                else
                {
                    ButtonOk.Text = "Add Now";
                    LabelTitle.Text = "Add New Document Category";

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
                ControllerDocumentCategory dbDocumentCategory = new ControllerDocumentCategory(db);

                if (ButtonOk.Text == "Add Now")
                {
                    dbDocumentCategory.Create(InputName.Text);
                }
                else if (ButtonOk.Text == "Update")
                {
                    dbDocumentCategory.Update(Request.QueryString["uid"], InputName.Text);
                }

                db.SubmitChanges();

                Response.Redirect("/Document_Category/Default.aspx");
            }
        }

    }

    protected void ButtonKeluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Document_Category/Default.aspx");
    }
}