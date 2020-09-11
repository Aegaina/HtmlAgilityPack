using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents the root node of an HTML document.
    /// </summary>
    public class HtmlDocumentNode : NormalHtmlNode
    {
        /// <summary>
        /// Gets the name of the document node. It is actually defined as '#document'.
        /// </summary>
        public const string HtmlNodeTypeName = "#document";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ownerDoc">The owner document of this node</param>
        /// <param name="index"></param>
        internal HtmlDocumentNode(HtmlDocument ownerDoc, int index)
            : base(HtmlNodeType.Document, ownerDoc, index) { }

        #region Properties



        #endregion

        /// <summary>
        /// Initialize the Name property
        /// </summary>
        protected override void InitName()
        {
            Name = HtmlNodeTypeName;
        }

        /// <summary>
        /// Initialize the end node field
        /// </summary>
        protected override void InitEndNode()
        {
            EndNode = this;
        }

        protected override string GetBasePath()
        {
            return "/";
        }

        protected override string GetRelativeXpath()
        {
            if (ParentNode == null)
            {
                return Name;
            }
            return string.Empty;
        }

        #region Write

        /// <summary>
        /// Saves the current node to the specified TextWriter.
        /// </summary>
        /// <param name="outText">The TextWriter to which you want to save.</param>
        /// <param name="level">identifies the level we are in starting at root with 0</param>
        public override void WriteTo(TextWriter outText, int level = 0)
        {
            WriteContentTo(outText, level);
        }

        #endregion
    }
}