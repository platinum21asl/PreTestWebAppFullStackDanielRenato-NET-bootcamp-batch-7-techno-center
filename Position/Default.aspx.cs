using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Position_Default : System.Web.UI.Page
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
        // Memanggil fungsi untuk mendapatkan data karyawan dari tabel "table_Position"
        ControllerPosition dbPosition = new ControllerPosition(db);

        var result = dbPosition.Data();

        // Mengikat data ke Repeater
        repeaterPosition.DataSource = result;
        repeaterPosition.DataBind();
    }

    protected void repeaterPosition_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            ControllerPosition dbPosition = new ControllerPosition(db);
            if (e.CommandName == "Update")
            {
                Response.Redirect("/Position/Form.aspx?uid=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {

                var position = db.Table_Positions.FirstOrDefault(x => x.UID.ToString() == e.CommandArgument.ToString());

                db.Table_Positions.DeleteOnSubmit(position);
                dbPosition.Delete(e.CommandArgument.ToString());
                //db.SubmitChanges();
                LoadData(db);
            }

        }
    }
}