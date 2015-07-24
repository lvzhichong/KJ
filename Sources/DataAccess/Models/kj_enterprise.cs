using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class kj_enterprise
    {
        public int enterprise_id { get; set; }
        public int user_id { get; set; }
        public Nullable<int> category_id { get; set; }
        public string enterprise_name { get; set; }
        public Nullable<int> enterprise_area { get; set; }
        public string enterprise_address { get; set; }
        public Nullable<int> enterprise_person { get; set; }
        public Nullable<int> enterprise_primary1 { get; set; }
        public Nullable<int> enterprise_primary2 { get; set; }
        public Nullable<int> enterprise_primary3 { get; set; }
        public string enterprise_intro { get; set; }
        public string enterprise_licence { get; set; }
        public string enterprise_legal { get; set; }
        public string enterprise_capital { get; set; }
        public string enterprise_email { get; set; }
        public string enterprise_tel { get; set; }
        public Nullable<int> enterprise_sex { get; set; }
        public Nullable<int> enterprise_licence_check { get; set; }
        public Nullable<int> enterprise_phone_check { get; set; }
        public Nullable<int> enterprise_sys_recommend { get; set; }
        public string enterprise_logo { get; set; }
        public string enterprise_sitename { get; set; }
        public string enterprise_adcard { get; set; }
        public string enterprise_qrcode { get; set; }
        public string enterprise_qq { get; set; }
        public string enterprise_siteenname { get; set; }
        public string enterprise_siteseokey { get; set; }
        public string enterprise_sitedesc { get; set; }
        public string enterprise_sitetitle { get; set; }
        public Nullable<int> enterprise_city { get; set; }
        public Nullable<int> enterprise_sys_identy { get; set; }
        public string enterprise_shortname { get; set; }
        public string enterprise_color { get; set; }
        public Nullable<int> enterprise_view { get; set; }
    }
}
