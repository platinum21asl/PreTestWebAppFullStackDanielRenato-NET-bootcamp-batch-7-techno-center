using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ControllerCompany
/// </summary>
public class ControllerCompany : ClassBase
{
    public ControllerCompany(DataClassesDatabaseDataContext _db) : base(_db)
    {

    }

    public TBCompany Cari(Guid UID)
    {
        return db.TBCompanies.FirstOrDefault(item => item.UID == UID);
    }

    public TBCompany CreateUpdate(Guid UID, string Nama)
    {
        var company = Cari(UID);

        if (company == null)
        {
            company = new TBCompany
            {
                UID = Guid.NewGuid(),
                Name = Nama
            };

            db.TBCompanies.InsertOnSubmit(company);
        }
        else
        {
            company.Name = Nama;
        }

        return company;
    }
}