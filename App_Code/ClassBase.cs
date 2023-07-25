using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClassBase
/// </summary>
public abstract class ClassBase
{
    internal DataClassesDatabaseDataContext db;

    public ClassBase(DataClassesDatabaseDataContext _db)
    {
        db = _db;

        HttpContext context = HttpContext.Current;
    }
}