using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for ControllerCompany
/// </summary>
public class ControllerCompany : ClassBase
{
    public ControllerCompany(DataClassesDatabasesPreTestDataContext _db) : base(_db)
    {
     
    }

    public Table_Company[] Data()
    {
        return db.Table_Companies.ToArray();
    }
    public Table_Company Cari(string UID)
    {
        return db.Table_Companies.FirstOrDefault(x => x.UID.ToString() == UID);
    }

    public Table_Company Create(string name, string address, string email, string telephone)
    {
        Table_Company company = new Table_Company
        {
            Name = name,
            Address = address,
            Email = email,
            Telephone = telephone,
            Flag = 1,
            CreatedBy = 1,
            UID = Guid.NewGuid(),
            CreatedAt = DateTime.Now
        };

        db.Table_Companies.InsertOnSubmit(company);


        return company;
    }

    public Table_Company Update(string UID, string name, string address, string email, string telephone)
    {
        var company = Cari(UID);


        if (company != null)
        {
            company.Name = name;
            company.Address = address;
            company.Email = email;
            company.Telephone = telephone;
            company.Flag = 1;
            company.CreatedBy = 1;
            return company;
        }
        else
        {
            return null;
        }

    }

    public Table_Company Delete(string UID)
    {
        var company = Cari(UID);

        var dataUsers = db.Table_Users.Where(x => x.IDCompany == company.ID);

       
        if (company != null)
        {
            if (dataUsers != null)
            {
                db.Table_Users.DeleteAllOnSubmit(dataUsers);
                db.SubmitChanges();
            }

            db.Table_Companies.DeleteOnSubmit(company);
            db.SubmitChanges();

            return company;
        }
        else
            return null;


    }

    public void DropDownListCompany(DropDownList dropDownList)
    {
        dropDownList.DataSource = Data();
        dropDownList.DataValueField = "ID";
        dropDownList.DataTextField = "Name";
        dropDownList.DataBind();

        dropDownList.Items.Insert(0, new ListItem { Value = "0", Text = "-Pilih-" });

    }

    public ListItem[] DropDownList()
    {
        List<ListItem> company = new List<ListItem>();

        //company.Add(new ListItem { Value = "0", Text = "-Pilih-" });

        company.AddRange(Data().Select(x => new ListItem
        {
            Value = x.ID.ToString(),
            Text = x.Name
        }));

        return company.ToArray();
    }
}