using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace userApp.Models
{
    public class UserEditorModel
    {
        public int UserID { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="string lenght should not exceed 10")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public Nullable<int> Age { get; set; }
        public string Address { get; set; }
        public Nullable<int> NationalityID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string MobileNo { get; set; }

        public IList<SelectListItem> NationalitiesList { get; set; }
        public IList<SelectListItem> CompaniesList { get; set; }
    }
}