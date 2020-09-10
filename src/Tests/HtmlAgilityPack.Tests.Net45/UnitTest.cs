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
                doc.OptionOutputAsXml = true;
                doc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtmlDoc_empty.html"));

                doc.DocumentNode.AppendChild(BuildContent(doc, ex));
                doc.Save(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "HtmlDoc.html"));
            }
        }

        private HtmlNode BuildContent(HtmlDocument htmlDoc, Exception ex)
        {
            HtmlNode rootNode = htmlDoc.CreateElement("div");

            #region caption

            HtmlNode captionNode = htmlDoc.CreateElement("p");
            rootNode.AppendChild(captionNode);

            HtmlNode node = htmlDoc.CreateElement("strong");
            node.AppendChild(htmlDoc.CreateTextNode(string.Format("{0}: ", ex.GetType().FullName)));
            captionNode.AppendChild(node);

            node = htmlDoc.CreateElement("span");
            node.AppendChild(htmlDoc.CreateTextNode(ex.Message));
            captionNode.AppendChild(node);

            #endregion

            HtmlNode listNode = htmlDoc.CreateElement("ul");
            rootNode.AppendChild(listNode);

            HtmlNode listItemNode = htmlDoc.CreateElement("li");
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
