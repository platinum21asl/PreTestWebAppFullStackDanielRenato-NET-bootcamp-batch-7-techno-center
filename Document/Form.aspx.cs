using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Document_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbcompany = new ControllerCompany(db);
                ControllerDocumentCategory dbcDocumentCategory = new ControllerDocumentCategory(db);
                ControllerDocument dbDocument = new ControllerDocument(db);

                listCompany.Items.AddRange(dbcompany.DropDownList());
                listCategory.Items.AddRange(dbcDocumentCategory.DropDownList());

                var document = dbDocument.Cari(Request.QueryString["uid"]);

                if (document != null)
                {
                    InputName.Text = document.Name;
                    InputDescription.Text = document.Description;

                    ButtonOk.Text = "Update";
                    LabelTitle.Text = "Update Document";
                }
                else
                {
                    ButtonOk.Text = "Add Now";
                    LabelTitle.Text = "Add New Document";

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
                ControllerDocument dbDocument = new ControllerDocument(db);

                if (ButtonOk.Text == "Add Now")
                {
                    dbDocument.Create(int.Parse(listCompany.SelectedValue), int.Parse(listCategory.SelectedValue), InputName.Text, InputDescription.Text);
                }
                else if (ButtonOk.Text == "Update")
                {
                    dbDocument.Update(int.Parse(listCompany.SelectedValue), int.Parse(listCategory.SelectedValue), Request.QueryString["uid"], InputName.Text, InputDescription.Text);
                }

                db.SubmitChanges();

                Response.Redirect("/Document/Default.aspx");
            }
        }

    }

    protected void ButtonKeluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Document/Default.aspx");
    }
}