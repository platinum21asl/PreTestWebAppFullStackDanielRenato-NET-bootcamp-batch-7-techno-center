﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Company_Default : System.Web.UI.Page
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
        // Memanggil fungsi untuk mendapatkan data karyawan dari tabel "table_company"
        ControllerCompany dbcompany = new ControllerCompany(db);

        var result = dbcompany.Data();

        // Mengikat data ke Repeater
        repeaterCompany.DataSource = result;
        repeaterCompany.DataBind();
    }

    protected void repeaterCompany_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            ControllerCompany dbCompany = new ControllerCompany(db);
            if (e.CommandName == "Update")
            {
                Response.Redirect("/Company/Form.aspx?uid=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {

                var company = db.Table_Companies.FirstOrDefault(x => x.UID.ToString() == e.CommandArgument.ToString());

                db.Table_Companies.DeleteOnSubmit(company);
                dbCompany.Delete(e.CommandArgument.ToString());
                //db.SubmitChanges();

                LoadData(db);
            }

        }
    }
}