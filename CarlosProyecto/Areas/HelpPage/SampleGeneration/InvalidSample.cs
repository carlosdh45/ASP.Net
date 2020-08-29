using System;

namespace CarlosProyecto.Areas.HelpPage
{
    /// <summary>
    /// This represents an invalid sample on the help page. There's a display template named InvalidSample associated with this class.
    /// </summary>
    public class InvalidSample
    {
        public InvalidSample(string ERRORMessage)
        {
            if (ERRORMessage == null)
            {
                throw new ArgumentNullException("ERRORMessage");
            }
            ERRORMessage = ERRORMessage;
        }

        public string ERRORMessage { get; private set; }

        public override bool Equals(object obj)
        {
            InvalidSample other = obj as InvalidSample;
            return other != null && ERRORMessage == other.ERRORMessage;
        }

        public override int GetHashCode()
        {
            return ERRORMessage.GetHashCode();
        }

        public override string ToString()
        {
            return ERRORMessage;
        }
    }
}