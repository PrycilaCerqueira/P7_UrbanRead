using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using P7_UrbanRead;

namespace WebUI.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebUIUser class
[Table("AspNetUsers")]
public class WebUIUser : IdentityUser
{
    [PersonalData]
    public Person _Person { get; set; }


}

