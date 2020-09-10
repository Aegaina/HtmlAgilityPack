using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an HTML element.
    /// </summary>
    public class HtmlElement : HtmlNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerDoc">The owner document of this node</param>
        /// <param name="index"></param>
        public HtmlElement(HtmlDocument ownerDoc, int index) : base(HtmlNodeType.Element, ownerDoc, index) { }
    }
}