using System.Runtime.Serialization;

namespace GMicroservices.Common.CustomExceptions
{
    [Serializable]
    public abstract class CustomBaseException : Exception
    {
        protected CustomBaseException()
        {

        }

        protected CustomBaseException(SerializationInfo info, StreamingContext context)
           : base(info, context)
        {
        }

        public abstract string MessageCode { get; set; }

        public abstract int HttpStatusCode { get; set; }

        public abstract string[] Params { get; set; }
    }
}
