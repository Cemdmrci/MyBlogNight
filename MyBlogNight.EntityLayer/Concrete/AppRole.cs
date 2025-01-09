using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogNight.EntityLayer.Concrete
{
    public class AppRole : IdentityRole<int> //bizim rol tablomuz string olarak geliyor rollerle kullanıcılar arasında ilişki var ikisininde veri türü aynı olsun diye bunu yaptık 
    {
    }
}
