using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Province
    {

public int ID {get;set; }
    public string Name {get;set; }
}
 
public class City
{
public int ID {get;set; }
public int ProvinceID {get;set; }
public string Name {get;set; }
public string ZipCode {get;set; }
}
    }
