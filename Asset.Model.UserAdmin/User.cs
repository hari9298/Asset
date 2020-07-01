using System;


namespace Asset.Model.UserAdmin
{
    public class User
    {
         public int? UserID {get; set;}
        public int? companyID { get; set; }
        public string companyName { get; set; }
        public string groupName {get; set;}
        public int? groupID {get; set;}
       
         public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordExpiryDate { get; set; }
        public int? PasswordRecvQuestion { get; set; }
        public string PasswordRecvAnswer { get; set; }
        public DateTime? UserModifiedOn { get; set; }
        public string UserModifiedBy { get; set; }
        public int? StatusID { get; set; }
        public string StatusName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}