using Microsoft.AspNetCore.Identity;

namespace Web.Models
{
    public class User: IdentityUser<int>//不加int的话是默认主键为guid
    {
        public string PassWord { get; set; }
    }
}
