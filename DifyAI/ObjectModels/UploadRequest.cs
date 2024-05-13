using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class UploadRequest: RequestBase
    {
        [Required]
        public string File { get; set; }

        [Required]
        [JsonPropertyName("user")]
        public string User { get; set; }
    }
}
