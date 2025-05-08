using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifyAI.ObjectModels
{
    public class TextToAudioResponse : ResponseBase
    {
        public string MediaType { get; set; }

        public byte[] AudioBytes { get; set; }
    }
}
