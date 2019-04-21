using System.Collections.Generic;
using System.Runtime.Serialization;

/// <summary>
/// Kensored API namespace
/// </summary>
namespace KensoredAPI
{
    /// <summary>
    /// Kensored words
    /// </summary>
    [DataContract]
    public class KensoredWord
    {
        /// <summary>
        /// Reason
        /// </summary>
        [DataMember]
        private string reason;

        /// <summary>
        /// Alternatives
        /// </summary>
        [DataMember]
        private string[] alternatives;

        /// <summary>
        /// Reason
        /// </summary>
        public string Reason
        {
            get
            {
                if (reason == null)
                {
                    reason = "";
                }
                return reason;
            }
        }

        /// <summary>
        /// Alternatives
        /// </summary>
        public IList<string> Alternatives
        {
            get
            {
                if (alternatives == null)
                {
                    alternatives = new string[0];
                }
                return alternatives;
            }
        }
    }
}
