﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Serializacja
{

    [Serializable]
    internal class EmployeeJson

    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? IsManager { get; set; }
        public List<int> AccessRooms { get; set; }
        public DateTime? StartAt { get; set; }

        [ScriptIgnore]
        [JsonIgnore]
        public List<string> ExtraData { get; set; }

        [NonSerialized()]
        private string Token;

        public void SetToken(string token)
        {
            Token = token;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
