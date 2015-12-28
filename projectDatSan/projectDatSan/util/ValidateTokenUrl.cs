using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectDatSan.Models
{
    public class ValidateToken
    {
        [JsonProperty("ValidateTokenUrlResult")]
        public ValidateTokenUrlResult ValidateTokenUrlResult { get; set; }
    }

    public class ValidateTokenUrlResult
    {
        [JsonProperty("SessionToken")]
        public string SessionToken { get; set; }
        [JsonProperty("Username")]
        public string Username { get; set; }
    }

    public class UserRole
    {
        public string Token { get; set; }
        public string Username { get; set; }

        [JsonProperty("CheckRoleResult")]
        public int Role { get; set; }
        public bool Active { get; set; }
    }
}