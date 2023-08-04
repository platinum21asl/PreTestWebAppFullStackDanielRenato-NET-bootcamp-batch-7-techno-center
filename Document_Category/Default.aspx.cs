using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Document_Category_Default : System.Web.UI.Page
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
        // Memanggil fungsi untuk mendapatkan data karyawan dari tabel "table_DocumentCategories"
        ControllerDocumentCategory dbDocumentCategory = new ControllerDocumentCategory(db);

        var result = dbDocumentCategory.Data();

        // Mengikat data ke Repeater
        repeaterDocument_Category.DataSource = result;
        repeaterDocument_Category.DataBind();
    }

    protected void repeaterDocument_Category_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
        {
            ControllerDocumentCategory dbDocumentCategory = new ControllerDocumentCategory(db);
            if (e.CommandName == "Update")
            {
                Response.Redirect("/Document_Category/Form.aspx?uid=" + e.CommandArgument);
            }
            else if (e.CommandName == "Delete")
            {

                var DocumentCategory = db.Table_Document_Categories.FirstOrDefault(x => x.UID.ToString() == e.CommandArgument.ToString());

                db.Table_Document_Categories.DeleteOnSubmit(DocumentCategory);
                dbDocumentCategory.Delete(e.CommandArgument.ToString());
                //db.SubmitChanges();
                LoadData(db);
            }

        }
    }
}