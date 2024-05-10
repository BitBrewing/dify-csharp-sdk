using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DifyAI
{
    public class DifyAIException : Exception
    {
        public DifyAIException(string code, string message, int status) : base(message)
        {
            Code = code;
            Status = status;
        }

        protected DifyAIException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Code = info.GetString(nameof(Code));
            Status = info.GetInt32(nameof(Status));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Code), Code);
            info.AddValue(nameof(Status), Status);

            base.GetObjectData(info, context);
        }

        public string Code { get; }
        public int Status { get; set; }
    }
}
