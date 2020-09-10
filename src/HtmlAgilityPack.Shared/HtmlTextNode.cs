// Description: Html Agility Pack - HTML Parsers, selectors, traversors, manupulators.
// Website & Documentation: http://html-agility-pack.net
// Forum & Issues: https://github.com/zzzprojects/html-agility-pack
// License: https://github.com/zzzprojects/html-agility-pack/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright ©ZZZ Projects Inc. 2014 - 2017. All rights reserved.

using System.IO;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Represents an HTML text node.
    /// </summary>
    public class HtmlTextNode : HtmlNode
    {
        #region Fields

        private string _text;

        #endregion

        #region Constructors

        internal HtmlTextNode(HtmlDocument ownerdocument, int index)
            :
            base(HtmlNodeType.Text, ownerdocument, index)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
        /// </summary>
        public override string InnerHtml
        {
            get { return OuterHtml; }
            set { _text = value; }
        }

        /// <summary>
        /// Gets or Sets the object and its content in HTML.
        /// </summary>
        public override string OuterHtml
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHtml;
                }

                return _text;
            }
        }

        /// <summary>
        /// Gets or Sets the text of the node.
        /// </summary>
        public string Text
        {
            get
            {
                if (_text == null)
                {
                    return base.OuterHtml;
                }

                return _text;
            }
            set
            {
                _text = value;
                SetChanged();
            }
        }

        #endregion

        /// <summary>
        /// Saves the current node to the specified TextWriter.
        /// </summary>
        /// <param name="outText">The TextWriter to which you want to save.</param>
        /// <param name="level">identifies the level we are in starting at root with 0</param>
        public override void WriteTo(TextWriter outText, int level = 0)
        {
            outText.Write(_ownerdocument.OptionOutputAsXml ? HtmlDocument.HtmlEncodeWithCompatibility(Text, _ownerdocument.BackwardCompatibility) : Text);
        }
    }
}