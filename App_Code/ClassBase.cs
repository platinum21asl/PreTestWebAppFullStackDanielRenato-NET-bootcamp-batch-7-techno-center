using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassBase
/// </summary>
public abstract class ClassBase
{
    internal DataClassesDatabasesPreTestDataContext db;

    public ClassBase(DataClassesDatabasesPreTestDataContext _db)
    {
        db = _db;

        HttpContext context = HttpContext.Current;
    }

    //internal DataClassesDatabasesPreTestDataContext dba;

    //public ClassBase(DataClassesDatabasesPreTestDataContext _dba)
    //{
    //    dba = _dba;

    //    HttpContext context = HttpContext.Current;
    //}
}