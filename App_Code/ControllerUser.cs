using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ControllerUser
/// </summary>
public class ControllerUser : ClassBase
{
    public ControllerUser(DataClassesDatabasesPreTestDataContext _db) : base(_db)
    {

    }


    public Table_User[] Data()
    {
        return db.Table_Users.ToArray();

    }


    public Table_User Cari(string UID)
    {
        return db.Table_Users.FirstOrDefault(x => x.UID.ToString() == UID);
    }

    public Table_User Create(int IDCompany,int IDPosition, string name, string address, string email, string telephone, string role)
    {

        Table_User user = new Table_User
        {
            UID = Guid.NewGuid(),
            IDCompany = IDCompany,
            IDPosition = IDPosition,
            Name = name,
            Address = address,
            Email = email,
            Telephone = telephone,
            Role = role,
            Flag = 1,
            CreatedBy = 1,
            CreatedAt = DateTime.Now
        };

        db.Table_Users.InsertOnSubmit(user);

        return user;
    }

    public Table_User Update(int IDCompany, int IDPosition, string UID, string name, string address, string email, string telephone, string role)
    {
        var user = Cari(UID);

        if (user != null)
        {
            user.Name = name;
            user.IDCompany = IDCompany;
            user.IDPosition = IDPosition;
            user.Address = address;
            user.Email = email;
            user.Telephone = telephone;
            user.Role = role;
          
            return user;
        }
        else
        {
            return null;
        }

    }

    public Table_User Delete(string UID)
    {
        var user = Cari(UID);

        if (user != null)
        {
            db.Table_Users.DeleteOnSubmit(user);
            db.SubmitChanges();

            return user;
        }
        else
            return null;

    }


}