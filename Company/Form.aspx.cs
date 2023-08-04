using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbcompany = new ControllerCompany(db);

                var company = dbcompany.Cari(Request.QueryString["uid"]);

                if (company != null)
                {
                    InputName.Text = company.Name;
                    InputAddress.Text = company.Address;
                    InputEmail.Text = company.Email;
                    InputTelephone.Text = company.Telephone;

                    ButtonOk.Text = "Update";
                    LabelTitle.Text = "Update Company";
                }
                else
                {
                    ButtonOk.Text = "Add Now";
                    LabelTitle.Text = "Add New Company";

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
                ControllerCompany dbcompany = new ControllerCompany(db);

                if (ButtonOk.Text == "Add Now")
                {
                    dbcompany.Create(InputName.Text, InputAddress.Text, InputEmail.Text, InputTelephone.Text);
                }
                else if (ButtonOk.Text == "Update")
                {
                    dbcompany.Update(Request.QueryString["uid"], InputName.Text, InputAddress.Text, InputEmail.Text, InputTelephone.Text);
                }

                db.SubmitChanges();

                Response.Redirect("/Company/Default.aspx");
            }
        }

    }

    protected void ButtonKeluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/Company/Default.aspx");
    }
}