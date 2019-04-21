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
    public class KensoredResult
    {
        /// <summary>
        /// Words
        /// </summary>
        [DataMember]
        private Dictionary<string, KensoredWord> words;

        /// <summary>
        /// Words
        /// </summary>
        public Dictionary<string, KensoredWord> Words
        {
            get
            {
                if (words == null)
                {
                    words = new Dictionary<string, KensoredWord>();
                }
                return words;
            }
        }
    }
}
