//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;

///// <summary>
///// Summary description for ControllerBrand
///// </summary>
//public class ControllerBrand : ClassBase
//{
//    public ControllerBrand(DataClassesDatabaseDataContext _db) : base(_db)
//    {

//    }


//    public table_brand[] Data()
//    {
//        return db.table_brands.ToArray();
//    }
//    public table_brand Cari(string UID)
//    {
//        return db.table_brands.FirstOrDefault(x => x.UID.ToString() == UID);
//    }

//    public table_brand Create(string name, string address, string telephone, string email)
//    {
//        table_brand brand = new table_brand
//        {
//            Name = name,
//            Address = address,
//            Telephone = telephone,
//            Email = email,
//            UID = Guid.NewGuid(),
//            CreateAt = DateTime.Now
//        };

//        db.table_brands.InsertOnSubmit(brand);

//        return brand;
//    }

//    public table_brand Update(string UID, string name, string address, string telelephone, string email)
//    {
//        var brand = Cari(UID);

//        if (brand != null)
//        {
//            brand.Name = name;
//            brand.Address = address;
//            brand.Telephone = telelephone;
//            brand.Email = email;
//            return brand;
//        }
//        else
//        {
//            return null;
//        }

//    }

//    public table_brand Delete(string UID)
//    {
//        var brand = Cari(UID);

//        if (brand != null)
//        {
//            db.table_brands.DeleteOnSubmit(brand);
//            db.SubmitChanges();

//            return brand;
//        }
//        else
//            return null;

//    }
//}