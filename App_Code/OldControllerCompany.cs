//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using System.Web.UI.WebControls;

///// <summary>
///// Summary description for ControllerCompany
///// </summary>
//public class ControllerCompany : ClassBase
//{

//    public ControllerCompany(DataClassesDatabaseDataContext _db) : base(_db)
//    {

//    }


//    public table_company[] Data()
//    {
//        return db.table_companies.ToArray();
//    }
//    public table_company Cari(string UID)
//    {
//        return db.table_companies.FirstOrDefault(x => x.UID.ToString() == UID);
//    }

//    public table_company Create(string name, string address, string telephone)
//    {
//        table_company company = new table_company
//        {
//            Name = name,
//            Address = address,
//            Telephone = telephone,
//            UID = Guid.NewGuid(),
//            CreateAt = DateTime.Now
//        };

//        db.table_companies.InsertOnSubmit(company);
     

//        return company;
//    }

//    public table_company Update(string UID, string name, string address, string telelephone)
//    {
//        var company = Cari(UID);
        

//        if (company != null)
//        {
//            company.Name = name;
//            company.Address = address;
//            company.Telephone = telelephone;
//            return company;
//        }
//        else
//        {
//            return null;
//        }

//    }

//    public table_company Delete(string UID)
//    {
//        var company = Cari(UID);

//        var dataUsers = db.table_users.Where(x => x.IDCompany == company.ID);

//        //var companyToDelete = db.table_companies.FirstOrDefault(c => c.ID == IDCompany);
//        if (company != null)
//        { 
//            if (dataUsers != null)
//            {
//                db.table_users.DeleteAllOnSubmit(dataUsers);
//                db.SubmitChanges();
//            }
        
//            db.table_companies.DeleteOnSubmit(company);
//            db.SubmitChanges();

//            return company;
//        }
//        else
//            return null;


//    }

//    public void DropDownListCompany(DropDownList dropDownList)
//    {
//        dropDownList.DataSource = Data();
//        dropDownList.DataValueField = "ID";
//        dropDownList.DataTextField = "Name";
//        dropDownList.DataBind();

//        dropDownList.Items.Insert(0, new ListItem{ Value = "0", Text = "-Pilih-" });

//    }

//    public ListItem[] DropDownList()
//    {
//        List<ListItem> company = new List<ListItem>();

//        //company.Add(new ListItem { Value = "0", Text = "-Pilih-" });

//        company.AddRange(Data().Select(x => new ListItem
//        {
//            Value = x.ID.ToString(),
//            Text = x.Name
//        }));

//        return company.ToArray();
//    }
    
//}

    