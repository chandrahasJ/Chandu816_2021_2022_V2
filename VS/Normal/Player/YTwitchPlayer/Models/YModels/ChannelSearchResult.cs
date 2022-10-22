using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YTwitchPlayer.Models.YModels
{
    public class ChannelSearchResult
    {
        [JsonPropertyName("items")]
        public List<Channel> Channels { get; set; }
    }
}
