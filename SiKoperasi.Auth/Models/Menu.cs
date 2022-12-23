using SiKoperasi.Core.Data;

namespace SiKoperasi.Auth.Models
{
    public class Menu : BaseModel
    {
        public Menu()
        {
            MenuPermissions = new HashSet<MenuPermission>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string IconUrl { get; set; }

        public ICollection<MenuPermission> MenuPermissions { get; set; }
    }
}
