namespace Client.Models
{
    public class User
    {
        public string User_login { get; set; }

        public string User_password { get; set; }

        public string User_first_name { get; set; }

        public string User_middle_name { get; set; }

        public string User_last_name { get; set; }

        public int User_role_code { get; set; }

        public int User_position_code { get; set; }

        public int User_secret_code { get; set; }
    }
}
