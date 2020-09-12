using System;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlAgilityPack.Tests.fx._4._5
{
    [TestClass]
    public class UnitTest
    {
        #region Document Building

        [TestMethod]
        public void Build()
        {
            try
            {
                try
                {
                    throw new InvalidOperationException("This is an inner exception");
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An exception occurs", ex);
                }
            }
            catch (Exception ex)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.OptionDefaultStreamEncoding = new UTF8Encoding(false);
                doc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtmlDoc_empty.html"));

                doc.DocumentNode.AppendChild(BuildContent(doc, ex));
                doc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtmlDoc.html"));
            }
        }

        private HtmlElement BuildContent(HtmlDocument htmlDoc, Exception ex)
        {
            HtmlElement rootNode = htmlDoc.CreateElement("div");

            #region caption

            HtmlElement captionNode = htmlDoc.CreateElement("p");
            rootNode.AppendChild(captionNode);

            HtmlElement node = htmlDoc.CreateElement("strong");
            captionNode.AppendChild(node);
            HtmlText textNode = htmlDoc.CreateTextNode(string.Format("{0}: ", ex.GetType().FullName));
            node.AppendChild(textNode);

            node = htmlDoc.CreateElement("span");
            node.AppendChild(htmlDoc.CreateTextNode(ex.Message));
            captionNode.AppendChild(node);
            //textNode.AppendChild(node);

            HtmlComment commentNode = htmlDoc.CreateComment("This is a comment");
            captionNode.AppendChild(commentNode);
            //commentNode.AppendChild(htmlDoc.CreateComment("An inner comment?"));

            #endregion

            HtmlElement listNode = htmlDoc.CreateElement("ul");
            rootNode.AppendChild(listNode);

            HtmlElement listItemNode = htmlDoc.CreateElement("li");
            listItemNode.AppendChild(htmlDoc.CreateTextNode(ex.StackTrace.Replace("\r\n", "<br/>")));
            listNode.AppendChild(listItemNode);

            if (ex.InnerException != null)
            {
                listItemNode = htmlDoc.CreateElement("li");
                listNode.AppendChild(listItemNode);

                listItemNode.AppendChild(BuildContent(htmlDoc, ex.InnerException));
            }

            return rootNode;
        }

        #endregion
    }
}
