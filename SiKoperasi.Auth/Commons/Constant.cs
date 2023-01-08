namespace SiKoperasi.Auth.Commons
{
    public class Constant
    {
        public const string LOGIN_ERR_USER_NOT_EXIST = "User Not Exist";
        public const string LOGIN_ERR_INVALID_PASSWORD = "Invalid Password";

        public const string REGISTER_ERR_DUPLICATE_USERNAME = "Username already Used";
        public const string REGISTER_ERR_DUPLICATE_EMAIL = "Email already Used";
        public const string REGISTER_ERR_DUPLICATE_PHONENUMBER = "Phone Number already Used";
        public const string REGISTER_ERR_UNMATCH_PASSWORD = "Password not Match";
        public const string REGISTER_ERR_NO_ROLE = "No Role has Assigned";
        public const string REGISTER_ERR_EMAIL_INVALID = "Invalid Email Format";
        public const string REGISTER_ERR_PHONE_INVALID = "Invalid Phone Number Format";
        public const string REGISTER_ERR_PASSWORD_COMPEXITY = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character";

        public const string REGEX_EMAIL = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
        public const string REGEX_MOBILE_PHONE = @"^\+62\d{2}[ -]?\d{3}[ -]?\d{4}$";
        public const string REGEX_PASSWORD_COMPLEXITY = "^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$";

        public const string INDONESIA_PHONE_PREFIX = "+62";
    }
}
