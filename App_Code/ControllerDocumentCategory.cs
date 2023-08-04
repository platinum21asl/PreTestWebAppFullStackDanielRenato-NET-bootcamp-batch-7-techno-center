using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ControllerDocumentCategory
/// </summary>
public class ControllerDocumentCategory : ClassBase
{
    public ControllerDocumentCategory(DataClassesDatabasesPreTestDataContext _db) : base(_db)
    {
  
    }

    public Table_Document_Category[] Data()
    {
        return db.Table_Document_Categories.ToArray();
    }

    public Table_Document_Category Cari(string UID)
    {
        return db.Table_Document_Categories.FirstOrDefault(x => x.UID.ToString() == UID);
    }

    public Table_Document_Category Create(string name)
    {
        Table_Document_Category Document_Category = new Table_Document_Category
        {
            UID = Guid.NewGuid(),
            Name = name,
            CreatedBy = 1,
            CreatedAt = DateTime.Now
        };

        db.Table_Document_Categories.InsertOnSubmit(Document_Category);


        return Document_Category;
    }

    public Table_Document_Category Update(string UID, string name)
    {
        var Document_Category = Cari(UID);


        if (Document_Category != null)
        {
            Document_Category.Name = name;
            Document_Category.CreatedBy = 1;
            return Document_Category;
        }
        else
        {
            return null;
        }

    }

    public Table_Document_Category Delete(string UID)
    {
        var Document_Category = Cari(UID);

        var dataDocument = db.Table_Documents.Where(x => x.IDCategory == Document_Category.ID);


        if (Document_Category != null)
        {
            if (dataDocument != null)
            {
                db.Table_Documents.DeleteAllOnSubmit(dataDocument);
                db.SubmitChanges();
            }

            db.Table_Document_Categories.DeleteOnSubmit(Document_Category);
            db.SubmitChanges();

            return Document_Category;
        }
        else
            return null;
    }

    public void DropDownListCategory(DropDownList dropDownList)
    {
        dropDownList.DataSource = Data();
        dropDownList.DataValueField = "ID";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();

        dropDownList.Items.Insert(0, new ListItem { Value = "0", Text = "-Pilih-" });

    }

    public ListItem[] DropDownList()
    {
        List<ListItem> documentcategory = new List<ListItem>();

        //documentcategory.Add(new ListItem { Value = "0", Text = "-Pilih-" });

        documentcategory.AddRange(Data().Select(x => new ListItem
        {
            Value = x.ID.ToString(),
            Text = x.Name
        }));

        return documentcategory.ToArray();
    }
}