using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using P7_UrbanRead;

namespace WebUI.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebUIUser class
public class WebUIUser : IdentityUser
{
    public Person _Person { get; set; }
}

