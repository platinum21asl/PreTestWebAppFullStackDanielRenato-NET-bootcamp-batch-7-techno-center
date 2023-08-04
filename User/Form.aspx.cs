using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Form : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbcompany = new ControllerCompany(db);
                ControllerPosition dbposition = new ControllerPosition(db);
                ControllerUser dbbuser = new ControllerUser(db);

                listCompany.Items.AddRange(dbcompany.DropDownList());
                listPosition.Items.AddRange(dbposition.DropDownList());

                var user = dbbuser.Cari(Request.QueryString["uid"]);

                if (user != null)
                {
                    InputName.Text = user.Name;
                    InputAddress.Text = user.Address;
                    InputEmail.Text = user.Email;
                    InputTelephone.Text = user.Telephone;
                    InputRole.Text = user.Role;
                    ButtonOk.Text = "Update";
                    LabelTitle.Text = "Update User";
                }
                else
                {
                    ButtonOk.Text = "Add Now";
                    LabelTitle.Text = "Add New User";

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
                ControllerUser dbbuser = new ControllerUser(db);

                if (ButtonOk.Text == "Add Now")
                {
                    dbbuser.Create(int.Parse(listCompany.SelectedValue), int.Parse(listCompany.SelectedValue), InputName.Text, InputAddress.Text, InputEmail.Text, InputTelephone.Text, InputRole.Text);
                }
                else if (ButtonOk.Text == "Update")
                {
                    dbbuser.Update(int.Parse(listCompany.SelectedValue), int.Parse(listCompany.SelectedValue), Request.QueryString["uid"], InputName.Text, InputAddress.Text, InputEmail.Text, InputTelephone.Text, InputRole.Text );
                }

                db.SubmitChanges();

                Response.Redirect("/User/Default.aspx");
            }
        }

    }

    protected void ButtonKeluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("/User/Default.aspx");
    }
}