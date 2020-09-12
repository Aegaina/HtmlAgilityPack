// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright ©ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System;
using System.IO;
using System.Text;
using System.Xml;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an HTML comment.
    /// </summary>
    public class HtmlComment : HtmlNodeBase
    {
        /// <summary>
        /// Gets the name of a comment node. It is actually defined as '#comment'.
        /// </summary>
        public const string HtmlNodeTypeName = "#comment";

        #region Fields

        private string _comment;

        #endregion

        #region Constructors

        internal HtmlComment(HtmlDocument ownerdocument, int index)
            : base(HtmlNodeType.Comment, ownerdocument, index)
        {
            Name = HtmlNodeTypeName;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the comment text of the node.
        /// </summary>
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        /// <summary>
        /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
        /// </summary>
        public override string InnerHtml
        {
            get { return Comment; }
            set { Comment = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHtml
        {
            get { return string.Format("<!--{0}-->", _comment); }
        }

        #endregion

        /// <summary>
        /// Creates a duplicate of the node.
        /// </summary>
        /// <param name="deep">true to recursively clone the subtree under the specified node; false to clone only the node itself.</param>
        /// <returns>The cloned node.</returns>
        public override HtmlNodeBase Clone(bool deep)
        {
            HtmlComment node = base.Clone(deep) as HtmlComment;
            if (node != null)
            {
                node.Comment = Comment;
            }
            return node;
        }

        /// <summary>
        /// Creates a duplicate of the node.
        /// </summary>
        /// <param name="node">The node to duplicate. May not be <c>null</c>.</param>
        /// <param name="deep">true to recursively clone the subtree under the specified node, false to clone only the node itself.</param>
        public override void CopyFrom(HtmlNodeBase node, bool deep)
        {
            base.CopyFrom(node, deep);

            HtmlComment normalSrc = node as HtmlComment;
            if (normalSrc == null)
            {
                return;
            }

            Comment = normalSrc.Comment;
        }
    }
}