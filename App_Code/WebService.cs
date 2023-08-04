using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Services.Client;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Linq;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{
    private object formatting;
    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    
    [WebMethod]
    public void Company()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var company = db.Table_Companies.Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    Telephone = x.Telephone,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = company,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Company"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void CompanybyUID(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var company = db.Table_Companies.Where(x => x.UID.ToString() == UID).Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    Telephone = x.Telephone,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = company,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Company"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void CompanyInsert(string name, string address, string email, string telephone)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbController = new ControllerCompany(db);


                var company = dbController.Create(name, address, email, telephone);


                db.SubmitChanges();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = company,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Company"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void CompanyUpdate(string UID, string name, string address, string email, string telephone)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbController = new ControllerCompany(db);


                var company = dbController.Update(UID, name, address, email, telephone);
                if (company != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = company,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Company"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void CompanyDelete(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerCompany dbController = new ControllerCompany(db);


                var company = dbController.Delete(UID);

                if (company != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = company,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Ada Data"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Company"
                }
            }, Formatting.Indented));
        }
    }

    public void Document()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var Document = db.Table_Documents.Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    IDCompany = x.IDCompany,
                    IDCategory = x.IDCategory,
                    Name = x.Name,
                    Description = x.Description,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = Document,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document "
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentbyUID(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var Document = db.Table_Documents.Where(x => x.UID.ToString() == UID).Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    IDCompany = x.IDCompany,
                    IDCategory = x.IDCategory,
                    Name = x.Name,
                    Description = x.Description,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = Document,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document "
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentInsert(int IDCompany, int IDCategory, string name, string description)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocument dbController = new ControllerDocument(db);


                var Document = dbController.Create(IDCompany, IDCategory, name, description);

                if(Document != null) 
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = Document,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }

                
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentUpdate(int IDCompany, int IDCategory, string UID, string name, string description)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocument dbController = new ControllerDocument(db);


                var Document = dbController.Update(IDCompany, IDCategory, UID, name, description);
                if (Document != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = Document,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document "
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentDelete(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocument dbController = new ControllerDocument(db);


                var Document = dbController.Delete(UID);

                if (Document != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = Document,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentCategory()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var DocumentCategory = db.Table_Document_Categories.Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = DocumentCategory,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentCategorybyUID(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var DocumentCategory = db.Table_Document_Categories.Where(x => x.UID.ToString() == UID).Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = DocumentCategory,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentCategoryInsert(string name)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocumentCategory dbController = new ControllerDocumentCategory(db);


                var DocumentCategory = dbController.Create(name);


                db.SubmitChanges();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = DocumentCategory,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentCategoryUpdate(string UID, string name)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocumentCategory dbController = new ControllerDocumentCategory(db);


                var DocumentCategory = dbController.Update(UID, name);
                if (DocumentCategory != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = DocumentCategory,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void DocumentCategoryDelete(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerDocumentCategory dbController = new ControllerDocumentCategory(db);


                var DocumentCategory = dbController.Delete(UID);

                if (DocumentCategory != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = DocumentCategory,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Ada Data"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Document Category"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void Position()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var Position = db.Table_Positions.Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = Position,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void PositionbyUID(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var Position = db.Table_Positions.Where(x => x.UID.ToString() == UID).Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    Name = x.Name,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = Position,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Position"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void PositionInsert(string name)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerPosition dbController = new ControllerPosition(db);


                var Position = dbController.Create(name);


                db.SubmitChanges();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = Position,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Position"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void PositionUpdate(string UID, string name)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerPosition dbController = new ControllerPosition(db);


                var Position = dbController.Update(UID, name);
                if (Position != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = Position,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Position"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void PositionDelete(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerPosition dbController = new ControllerPosition(db);


                var Position = dbController.Delete(UID);

                if (Position != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = Position,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Ada Data"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error Position"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void User()
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var User = db.Table_Users.Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    IDCompany = x.IDCompany,
                    IDPosition = x.IDPosition,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    Telephone = x.Telephone,
                    Role = x.Role,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = User,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void UserbyUID(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                var User = db.Table_Users.Where(x => x.UID.ToString() == UID).Select(x => new
                {
                    ID = x.ID,
                    UID = x.UID,
                    IDCompany = x.IDCompany,
                    IDPosition = x.IDPosition,
                    Name = x.Name,
                    Address = x.Address,
                    Email = x.Email,
                    Telephone = x.Telephone,
                    Role = x.Role,
                    Flag = x.Flag,
                    CreatedBy = x.CreatedBy,
                    CreatedAt = x.CreatedAt
                }).ToArray();

                Context.Response.Write(JsonConvert.SerializeObject(new
                {
                    Data = User,
                    Result = new WebServiceResult
                    {
                        EnumWebService = (int)EnumWebService.Success,
                        Pesan = "Success"
                    }
                }, Formatting.Indented));
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void UserInsert(int IDCompany, int IDPosition, string name, string address, string email, string telephone, string role)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerUser dbController = new ControllerUser(db);


                var User = dbController.Create(IDCompany, IDPosition, name, address, email, telephone, role);
                if (User != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = User,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void UserUpdate(int IDCompany, int IDPosition, string UID, string name, string address, string email, string telephone, string role)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerUser dbController = new ControllerUser(db);


                var User = dbController.Update(IDCompany, IDPosition, UID, name, address, email, telephone, role);
                if (User != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = User,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }


            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }

    [WebMethod]
    public void UserDelete(string UID)
    {
        Context.Response.Clear();
        Context.Response.ContentType = "application/json";

        try
        {
            using (DataClassesDatabasesPreTestDataContext db = new DataClassesDatabasesPreTestDataContext())
            {
                ControllerUser dbController = new ControllerUser(db);


                var User = dbController.Delete(UID);

                if (User != null)
                {
                    db.SubmitChanges();

                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = User,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Success,
                            Pesan = "Success"
                        }
                    }, Formatting.Indented));
                }
                else
                {
                    Context.Response.Write(JsonConvert.SerializeObject(new
                    {
                        Data = (string)null,
                        Result = new WebServiceResult
                        {
                            EnumWebService = (int)EnumWebService.Exception,
                            Pesan = "Error"
                        }
                    }, Formatting.Indented));
                }
            }
        }
        catch (Exception ex)
        {
            Context.Response.Write(JsonConvert.SerializeObject(new
            {
                Data = (string)null,
                Result = new WebServiceResult
                {
                    EnumWebService = (int)EnumWebService.Exception,
                    Pesan = ex.Message.StartsWith("error") ? ex.Message : "Error User"
                }
            }, Formatting.Indented));
        }
    }


}
