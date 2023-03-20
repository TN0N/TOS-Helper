using Prism.Mvvm;
using System;

namespace TOS_Helper.Model
{
    /// <summary>
    /// This class defines a culture as its id and its name in that language.
    /// </summary>
    public class Culture : BindableBase
    {
        /// <summary>
        /// The language code.
        /// </summary>
        public string id { get; set; } = String.Empty;
        /// <summary>
        /// The native name of the language.
        /// </summary>
        public string culture { get; set; } = String.Empty;
    }
}
