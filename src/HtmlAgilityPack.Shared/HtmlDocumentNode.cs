using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents the root node of an HTML document.
    /// </summary>
    public class HtmlDocumentNode : HtmlNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerDoc">The owner document of this node</param>
        /// <param name="index"></param>
        public HtmlDocumentNode(HtmlDocument ownerDoc, int index) : base(HtmlNodeType.Document, ownerDoc, index) { }
    }
}