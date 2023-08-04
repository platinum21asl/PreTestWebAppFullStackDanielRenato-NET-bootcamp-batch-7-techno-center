using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ControllerPosition
/// </summary>
public class ControllerPosition : ClassBase
{
    public ControllerPosition(DataClassesDatabasesPreTestDataContext _db) : base(_db)
    {
    
    }

    public Table_Position[] Data()
    {
        return db.Table_Positions.ToArray();
    }

    public Table_Position Cari(string UID)
    {
        return db.Table_Positions.FirstOrDefault(x => x.UID.ToString() == UID);
    }

    public Table_Position Create(string name)
    {
        Table_Position position = new Table_Position
        {
            UID = Guid.NewGuid(),
            Name = name,
            CreatedBy = 1,
            CreatedAt = DateTime.Now
        };

        db.Table_Positions.InsertOnSubmit(position);


        return position;
    }

    public Table_Position Update(string UID, string name)
    {
        var position = Cari(UID);


        if (position != null)
        {
            position.Name = name;
            position.CreatedBy = 1;
            return position;
        }
        else
        {
            return null;
        }

    }

    public Table_Position Delete(string UID)
    {
        var position = Cari(UID);

        var dataUsers = db.Table_Users.Where(x => x.IDPosition == position.ID);


        if (position != null)
        {
            if (dataUsers != null)
            {
                db.Table_Users.DeleteAllOnSubmit(dataUsers);
                db.SubmitChanges();
            }

            db.Table_Positions.DeleteOnSubmit(position);
            db.SubmitChanges();

            return position;
        }
        else
            return null;
    }

    public void DropDownListPosition(DropDownList dropDownList)
    {
        dropDownList.DataSource = Data();
        dropDownList.DataValueField = "ID";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();

        dropDownList.Items.Insert(0, new ListItem { Value = "0", Text = "-Pilih-" });

    }

    public ListItem[] DropDownList()
    {
        List<ListItem> position = new List<ListItem>();


        position.AddRange(Data().Select(x => new ListItem
        {
            Value = x.ID.ToString(),
            Text = x.Name
        }));

        return position.ToArray();
    }
}