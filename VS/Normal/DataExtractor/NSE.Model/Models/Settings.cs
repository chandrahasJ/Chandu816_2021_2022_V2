﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NSE.Model.Models
{
    public  class Settings
    {
        [JsonPropertyName("symbolNames")]
        public List<string> Symbols { get; set; }
    }
}
