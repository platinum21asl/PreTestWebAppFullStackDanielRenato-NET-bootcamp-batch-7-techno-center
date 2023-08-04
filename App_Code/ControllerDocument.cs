using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ControllerDocument
/// </summary>
public class ControllerDocument: ClassBase
{
    public ControllerDocument(DataClassesDatabasesPreTestDataContext _db) : base(_db)
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Table_Document[] Data()
    {
        return db.Table_Documents.ToArray();
    }
    public Table_Document Cari(string UID)
    {
        return db.Table_Documents.FirstOrDefault(x => x.UID.ToString() == UID);
    }

    public Table_Document Create(int IDCompany, int IDCategory, string name, string description)
    {
        Table_Document Document = new Table_Document
        {
            Name = name,
            IDCompany = IDCompany,
            IDCategory = IDCategory,
            Description = description,
            Flag = 1,
            CreatedBy = 1,
            UID = Guid.NewGuid(),
            CreatedAt = DateTime.Now
        };

        db.Table_Documents.InsertOnSubmit(Document);


        return Document;
    }

    public Table_Document Update(int IDCompany, int IDCategory, string UID, string name, string description)
    {
        var Document = Cari(UID);


        if (Document != null)
        {
            Document.Name = name;
            Document.Description = description;
            Document.IDCompany = IDCompany;
            Document.IDCategory = IDCategory;
            Document.Flag = 1;
            Document.CreatedBy = 1;
            return Document;
        }
        else
        {
            return null;
        }

    }

    public Table_Document Delete(string UID)
    {
        var Document = Cari(UID);


        if (Document != null)
        {
            db.Table_Documents.DeleteOnSubmit(Document);
            db.SubmitChanges();

            return Document;
        }
        else
            return null;


    }

}