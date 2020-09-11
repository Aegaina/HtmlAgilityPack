using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlAgilityPack
{
    /// <summary>
    /// Defines an object that can hold HTML nodes.
    /// </summary>
    public interface IHtmlNodeContainer
    {
        #region Properties

        /// <summary>
        /// Gets or sets this object's name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the parent of this object.
        /// </summary>
        IHtmlNodeContainer ParentNode { get; }

        /// <summary>
        /// Gets a value indicating whether this object contains any child nodes.
        /// </summary>
        bool HasChildNodes { get; }

        /// <summary>
        /// Gets all the nodes held by this object.
        /// </summary>
        HtmlNodeCollection ChildNodes { get; }

        /// <summary>
        /// Gets the first node held by this object.
        /// </summary>
        HtmlNode FirstChild { get; }

        /// <summary>
        /// Gets the last child held by this object.
        /// </summary>
        HtmlNode LastChild { get; }

        /// <summary>
        /// The depth of the node relative to the opening root html element. This value is used to determine if a document has to many nested html nodes which can cause stack overflows
        /// </summary>
        int Depth { get; }

        /// <summary>
        /// Gets a valid XPath string that points to this object
        /// </summary>
        string XPath { get; }

        /// <summary>
        /// Indicates whether the InnerHtml and the OuterHtml must be regenerated.
        /// </summary>
        bool IsChanged { get; set; }

        #endregion

        #region Attibutes

        /// <summary>Gets data attribute.</summary>
        /// <param name="key">The key.</param>
        /// <returns>The data attribute.</returns>
        HtmlAttribute GetDataAttribute(string key);

        /// <summary>Gets the data attributes in this collection.</summary>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the data attributes in this
        /// collection.
        /// </returns>
        IEnumerable<HtmlAttribute> GetDataAttributes();

        /// <summary>Gets the attributes in this collection.</summary>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the attributes in this collection.
        /// </returns>
        IEnumerable<HtmlAttribute> GetAttributes();

        /// <summary>Gets the attributes in this collection.</summary>
        /// <param name="attributeNames">A variable-length parameters list containing attribute names.</param>
        /// <returns>
        /// An enumerator that allows foreach to be used to process the attributes in this collection.
        /// </returns>
        IEnumerable<HtmlAttribute> GetAttributes(params string[] attributeNames);

        /// <summary>
        /// Helper method to get the value of an attribute of this node. If the attribute is not found, the default value will be returned.
        /// </summary>
        /// <param name="name">The name of the attribute to get. May not be <c>null</c>.</param>
        /// <param name="def">The default value to return if not found.</param>
        /// <returns>The value of the attribute if found, the default value if not found.</returns>
        string GetAttributeValue(string name, string def);

        /// <summary>
        /// Helper method to get the value of an attribute of this node. If the attribute is not found, the default value will be returned.
        /// </summary>
        /// <param name="name">The name of the attribute to get. May not be <c>null</c>.</param>
        /// <param name="def">The default value to return if not found.</param>
        /// <returns>The value of the attribute if found, the default value if not found.</returns>
        int GetAttributeValue(string name, int def);

        /// <summary>
        /// Helper method to get the value of an attribute of this node. If the attribute is not found, the default value will be returned.
        /// </summary>
        /// <param name="name">The name of the attribute to get. May not be <c>null</c>.</param>
        /// <param name="def">The default value to return if not found.</param>
        /// <returns>The value of the attribute if found, the default value if not found.</returns>
        bool GetAttributeValue(string name, bool def);

#if !(METRO || NETSTANDARD1_3 || NETSTANDARD1_6)
        /// <summary>
        /// Helper method to get the value of an attribute of this node. If the attribute is not found,
        /// the default value will be returned.
        /// </summary>
        /// <param name="name">The name of the attribute to get. May not be <c>null</c>.</param>
        /// <param name="def">The default value to return if not found.</param>
        /// <returns>The value of the attribute if found, the default value if not found.</returns>
        T GetAttributeValue<T>(string name, T def);
#endif

        /// <summary>
        /// Helper method to set the value of an attribute of this node. If the attribute is not found, it will be created automatically.
        /// </summary>
        /// <param name="name">The name of the attribute to set. May not be null.</param>
        /// <param name="value">The value for the attribute.</param>
        /// <returns>The corresponding attribute instance.</returns>
        HtmlAttribute SetAttributeValue(string name, string value);

        #endregion

        #region Children

        /// <summary>
        /// Inserts the specified node immediately after the specified reference node.
        /// </summary>
        /// <param name="newChild">The node to insert. May not be <c>null</c>.</param>
        /// <param name="refChild">The node that is the reference node. The newNode is placed after the refNode.</param>
        /// <returns>The node being inserted.</returns>
        HtmlNode InsertAfter(HtmlNode newChild, HtmlNode refChild);

        /// <summary>
        /// Inserts the specified node immediately before the specified reference node.
        /// </summary>
        /// <param name="newChild">The node to insert. May not be <c>null</c>.</param>
        /// <param name="refChild">The node that is the reference node. The newChild is placed before this node.</param>
        /// <returns>The node being inserted.</returns>
        HtmlNode InsertBefore(HtmlNode newChild, HtmlNode refChild);

        /// <summary>
        /// Adds the specified node to the beginning of the list of children of this node.
        /// </summary>
        /// <param name="newChild">The node to add. May not be <c>null</c>.</param>
        /// <returns>The node added.</returns>
        HtmlNode PrependChild(HtmlNode newChild);

        /// <summary>
        /// Adds the specified node list to the beginning of the list of children of this node.
        /// </summary>
        /// <param name="newChildren">The node list to add. May not be <c>null</c>.</param>
        void PrependChildren(HtmlNodeCollection newChildren);

        /// <summary>
        /// Removes all the children of the current node.
        /// </summary>
        void RemoveAllChildren();

        /// <summary>
        /// Removes the specified child node.
        /// </summary>
        /// <param name="oldChild">The node being removed. May not be <c>null</c>.</param>
        /// <returns>The node removed.</returns>
        HtmlNode RemoveChild(HtmlNode oldChild);

        /// <summary>
        /// Removes the specified child node.
        /// </summary>
        /// <param name="oldChild">The node being removed. May not be <c>null</c>.</param>
        /// <param name="keepGrandChildren">true to keep grand children of the node, false otherwise.</param>
        /// <returns>The node removed.</returns>
        HtmlNode RemoveChild(HtmlNode oldChild, bool keepGrandChildren);

        /// <summary>
        /// Replaces the child node oldChild with newChild node.
        /// </summary>
        /// <param name="newChild">The new node to put in the child list.</param>
        /// <param name="oldChild">The node being replaced in the list.</param>
        /// <returns>The node replaced.</returns>
        HtmlNode ReplaceChild(HtmlNode newChild, HtmlNode oldChild);

        /// <summary>Removes all id.</summary>
        void RemoveAllID();

        #endregion

        /// <summary>
        /// Removes all the children and/or attributes of the current node.
        /// </summary>
        void RemoveAll();

        #region Descendants

        /// <summary>
        /// Gets all Descendant nodes in enumerated list
        /// </summary>
        /// <remarks>DO NOT REMOVE, the empty method is required for Fizzler third party library</remarks>
        IEnumerable<HtmlNode> Descendants();

        /// <summary>
        /// Gets all Descendant nodes in enumerated list
        /// </summary>
        /// <returns></returns>
        IEnumerable<HtmlNode> Descendants(int level);

        /// <summary>
        /// Get all descendant nodes with matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<HtmlNode> Descendants(string name);

        /// <summary>
        /// Returns a collection of all descendant nodes of this element, in document order
        /// </summary>
        /// <returns></returns>
        IEnumerable<HtmlNode> DescendantsAndSelf();

        /// <summary>
        /// Gets all descendant nodes including this node
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<HtmlNode> DescendantsAndSelf(string name);

        #endregion

        /// <summary>
        /// Gets first generation child node matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HtmlNode Element(string name);

        /// <summary>
        /// Gets matching first generation child nodes matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<HtmlNode> Elements(string name);
    }
}