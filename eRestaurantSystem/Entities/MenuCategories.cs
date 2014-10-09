using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRestaurantSystem.Entities
{
    public class MenuCategories
    {
        [Key]
        public Int32 MenuCategoryID { get; set; }
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(15, ErrorMessage = "Description has a maximum 15 characters")]
        public string Description { get; set; }

        //navigation
        public virtual ICollection<Items> Items { get; set; }
    }
}
