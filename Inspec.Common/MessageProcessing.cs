//--------------------------------------------------------------------------
//
// TITLE    : MessageProcessing
//
// SYNOPSIS : Set of message processing utilities.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Xml;
//using Microsoft.XLANGs.BaseTypes;

//using Inspec.Mercury.Workflow.Common.Components.Properties;

//namespace Inspec.Mercury.Workflow.Common.Components
namespace Inspec.Common
{
    /// <summary>
    /// A set of message processing utilities.
    /// </summary>
    /// <remarks>
    /// This class contains a number of methods that are very similar, but differ because of the types of the
    /// parameters that are used. For example, one method may take parameters as <see cref="T:XmlDocument"/>, another
    /// similar method may take parameters as <see cref="T:XLANGMessage"/>. It is not possible to use overloaded
    /// methods here because the .NET Framework runtime can implicitly convert class instances between the type of
    /// <see cref="T:XmlDocument"/> and <see cref="T:XLANGMessage"/>. As a result, at runtime, it cannot
    /// distinguish between the different overloads. Therefore, the method names are different.
    /// <para>
    /// The naming convention used is to suffix the method name with <b>Xml</b> if it takes parameters as
    /// <see cref="T:XmlDocument"/>. No suffix is used if the method takes parameters as <see cref="T:XLANGMessage"/>.
    /// </para>
    /// <para>
    /// The class is marked as not being CLS compliant because the BizTalk Server type <see cref="T:XLANGMessage"/>
    /// is not CLS compliant.
    /// </para>
    /// </remarks>
    // TODO: We should look at rationalising all of these functions.
    // TODO: Look at: http://www.traceofthought.net/PermaLink,guid,5c37f250-0860-4c39-bd40-84647898e486.aspx
    [CLSCompliant(false)]
    public static class MessageProcessing
    {
        /// <summary>
        /// The separator used by XPath to delimit individual XML nodes.
        /// </summary>
        private const string XPathNodeSep = "/";

        #region Namespace Management

        /// <summary>
        /// Creates the namespace manager for the specified XML document.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>An instance of a <see cref="T:XmlNamespaceManager"/> for the XML document.</returns>
        public static XmlNamespaceManager CreateNamespaceMgr(XmlDocument xmlDoc, string defaultNamespacePrefix)
        {
            // Create a new namespace manager for the XML Document
            XmlNamespaceManager nmgr = new XmlNamespaceManager(xmlDoc.NameTable);

            // Define the default namespace using the given prefix, if one is specified
            if (!String.IsNullOrEmpty(defaultNamespacePrefix))
            {
                nmgr.AddNamespace(defaultNamespacePrefix, xmlDoc.DocumentElement.NamespaceURI);
            }
            return nmgr;
        }

        #endregion

        #region ReadNode

        /// <summary>
        /// Reads the textual value for a single node from an XLANG message using the specified XPath.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>The textual value of the node.</returns>
        //public static string ReadNode(XLANGMessage msg, string xPath, string defaultNamespacePrefix)
        //{
        //    // Get the node
        //    XmlNode n = GetSingleNode(msg, xPath, defaultNamespacePrefix);

        //    // We need to handle the case when the XPath did not match any node
        //    if (n != null)
        //    {
        //        return n.InnerText;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        /// <summary>
        /// Reads the textual value for a single node from an XLANG message using the specified XPath.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <param name="returnNullAsNegative"></param>
        /// <returns>The textual value of the node.</returns>
        //public static string ReadNode(XLANGMessage msg,
        //                                string xPath,
        //                                string defaultNamespacePrefix,
        //                                Boolean returnNullAsNegative
        //                                )
        //{
        //    // Get the node
        //    XmlNode n = GetSingleNode(msg, xPath, defaultNamespacePrefix);

        //    // We need to handle the case when the XPath did not match any node
        //    if (n != null)
        //    {
        //        return n.InnerText;
        //    }
        //    else
        //    {
        //        if (returnNullAsNegative == true) return "-1";
        //        else return null;
        //    }
        //}


        /// <summary>
        /// Reads the textual value for a single node from an XLANG message using the specified XPath.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <param name="returnNullAsString"></param>
        /// <param name="isBoolean"></param>
        /// <returns>The textual value of the node.</returns>
        //public static string ReadNode(XLANGMessage msg, 
        //                                string xPath, 
        //                                string defaultNamespacePrefix,
        //                                Boolean returnNullAsString,
        //                                Boolean isBoolean)
        //{
        //    // Get the node
        //    XmlNode n = GetSingleNode(msg, xPath, defaultNamespacePrefix);

        //    // We need to handle the case when the XPath did not match any node
        //    if (n != null)
        //    {
        //        if (isBoolean)
        //        {
        //            if (Boolean.Parse(n.InnerText)) return "true"; else return "false";
        //        }
        //        return n.InnerText;
        //    }
        //    else
        //    {
        //        if (returnNullAsString == true) return "null";
        //        else return null;
        //    }
        //}


        /// <summary>
        /// Reads the textual value for a single node from an <see cref="T:XmlDocument"/> using the specified XPath.
        /// </summary>
        /// <param name="msgXml">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>The textual value of the node.</returns>
        public static string ReadNodeXml(XmlDocument msgXml, string xPath, string defaultNamespacePrefix)
        {
            // Get the node
            XmlNode n = GetSingleNodeXml(msgXml, xPath, defaultNamespacePrefix);

            // We need to handle the case when the XPath did not match any node
            if (n != null)
            {
                return n.InnerText;
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region NodeCount

        /// <summary>
        /// Counts the number of nodes that match the specified XPath.
        /// </summary>
        /// <param name="msg">The XLANG message.</param>
        /// <param name="xPath">The XPath query identifying the nodes to be count.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>Number of occurances of the node in the XLANG message.</returns>
        //public static int NodeCount(XLANGMessage msg, string xPath, string defaultNamespacePrefix)
        //{
        //    // Get the XML representation of the message.
        //    XmlDocument msgXml = ConvertMsgToXml(msg);

        //    // Configure the namespace manager
        //    XmlNamespaceManager nmgr = CreateNamespaceMgr(msgXml, defaultNamespacePrefix);

        //    // Get the set of nodes matching the XPath
        //    XmlNodeList nList = msgXml.SelectNodes(xPath, nmgr);
        //    return nList.Count;
        //}

        #endregion

        #region GetSingleNode

        /// <summary>
        /// Get a single node from an XLANG message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>A single <see cref="T:XmlNode"/> matching the XPath query.</returns>
        //public static XmlNode GetSingleNode(XLANGMessage msg, string xPath, string defaultNamespacePrefix)
        //{
        //    // Get the XML representation of the message.
        //    XmlDocument msgXml = ConvertMsgToXml(msg);

        //    // Get the node
        //    return GetSingleNodeXml(msgXml, xPath, defaultNamespacePrefix);
        //}

        /// <overloads>
        /// Get a single node from a message.
        /// </overloads>
        /// <summary>
        /// Get a single node from an <see cref="T:XmlNode"/>.
        /// </summary>
        /// <param name="msgXmlNode">The XML node.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>A single <see cref="T:XmlNode"/> matching the XPath query.</returns>
        public static XmlNode GetSingleNodeXml(XmlNode msgXmlNode, string xPath, string defaultNamespacePrefix)
        {
            // Load the XML node into an XML document
            XmlDocument msgXml = new XmlDocument();
            msgXml.LoadXml(msgXmlNode.OuterXml);

            // Get the node
            return GetSingleNodeXml(msgXml, xPath, defaultNamespacePrefix);
        }

        /// <summary>
        /// Get a single node from an <see cref="T:XmlDocument"/>.
        /// </summary>
        /// <param name="msgXml">The message.</param>
        /// <param name="xPath">The XPath query identifying the node to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>A single <see cref="T:XmlNode"/> matching the XPath query.</returns>
        public static XmlNode GetSingleNodeXml(XmlDocument msgXml, string xPath, string defaultNamespacePrefix)
        {
            // Configure the namespace manager
            XmlNamespaceManager nmgr = CreateNamespaceMgr(msgXml, defaultNamespacePrefix);

            // Get the node
            return msgXml.SelectSingleNode(xPath, nmgr);
        }

        #endregion GetSingleNode

        #region GetMultipleNodes

        /// <summary>
        /// Get multiple nodes from an XLANG message.
        /// </summary>
        /// <param name="msg">The message.</param>
        /// <param name="xPath">The XPath query identifying the nodes to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>An <see cref="T:XmlNodeList"/> containing the nodes matching the XPath query.</returns>
        //public static XmlNodeList GetMultipleNodes(XLANGMessage msg, string xPath, string defaultNamespacePrefix)
        //{
        //    // Get the XML representation of the message.
        //    XmlDocument msgXml = ConvertMsgToXml(msg);

        //    // Get the nodes
        //    return GetMultipleNodesXml(msgXml, xPath, defaultNamespacePrefix);
        //}

        /// <summary>
        /// Get multiple nodes from an <see cref="T:XmlDocument"/>.
        /// </summary>
        /// <param name="msgXml">The message.</param>
        /// <param name="xPath">The XPath query identifying the nodes to be read.</param>
        /// <param name="defaultNamespacePrefix">Name of the default namespace prefix for the message.</param>
        /// <returns>An <see cref="T:XmlNodeList"/> containing the nodes matching the XPath query.</returns>
        public static XmlNodeList GetMultipleNodesXml(XmlDocument msgXml, string xPath, string defaultNamespacePrefix)
        {
            // Configure the namespace manager
            XmlNamespaceManager nmgr = CreateNamespaceMgr(msgXml, defaultNamespacePrefix);

            // Get the nodes
            return msgXml.SelectNodes(xPath, nmgr);
        }

        #endregion GetMultipleNodes

        #region CreateMessage

        /// <summary>
        /// Creates a new empty <see cref="XmlDocument"/> using the specified root node name and target namespace.
        /// </summary>
        /// <param name="rootNodeName">Name of the root node for the <see cref="XmlDocument"/>.</param>
        /// <param name="targetNamespace">The target namespacefor the <see cref="XmlDocument"/>.</param>
        /// <returns>An empty <see cref="XmlDocument"/>.</returns>
        public static XmlDocument CreateMessage(string rootNodeName, string targetNamespace)
        {
            XmlDocument msgXml = new XmlDocument();
            XmlElement nodeRoot = msgXml.CreateElement(Resources.DefaultBtsNamespacePrefix, rootNodeName, targetNamespace);
            msgXml.AppendChild(nodeRoot);

            return msgXml;
        }

        #endregion

        #region Create Blank Message

        /// <summary>
        /// Creates a new empty <see cref="XmlDocument"/> consisting of a blank message.
        /// </summary>
        /// <returns></returns>
        public static XmlDocument CreateBlankMessage()
        {
            return CreateMessage("BlankSchema", "http://www.inspec.org/ideas/xsd/wkf/common/blankschema/v1");
        }

        #endregion

        #region CreateVariableMessage

        /// <overloads>
        /// Creates a new Variable <see cref="XmlDocument"/> for a specific data type.
        /// </overloads>
        /// <summary>
        /// Creates a new Variable <see cref="XmlDocument"/> for an <b>Integer</b> data type.
        /// </summary>
        /// <param name="value">The integer value to be added to the message.</param>
        /// <returns>
        /// A response <see cref="XmlDocument"/> with the integer value.
        /// </returns>
        public static XmlDocument CreateVariableMessage(int value)
        {
            // Create empty document and add the integer value
            XmlDocument msgXml = CreateMessage(Resources.MsgProcessingVarIntNodeName, Resources.MsgProcessingVarIntNamespace);
            msgXml.DocumentElement.InnerText = value.ToString(CultureInfo.InvariantCulture);

            return msgXml;
        }

        #endregion

        #region CreateResponseMessage

        /// <overloads>
        /// Creates a new response <see cref="XmlDocument"/>.
        /// </overloads>
        /// <summary>
        /// Creates a new response <see cref="XmlDocument"/> using the specified root node name, target namespace and with a
        /// default <c>Success</c> status value.
        /// </summary>
        /// <param name="rootNodeName">Name of the root node for the <see cref="XmlDocument"/>.</param>
        /// <param name="targetNamespace">The target namespacefor the <see cref="XmlDocument"/>.</param>
        /// <returns>A response <see cref="XmlDocument"/> with a default <c>Success</c> status.</returns>
        /// <remarks>
        /// The <c>Header</c> part of all response messages used by Mercury follow the same structure, so we can use
        /// a generic method to create them.
        /// </remarks>
        public static XmlDocument CreateResponseMessage(string rootNodeName, string targetNamespace)
        {
            return CreateResponseMessage(rootNodeName, targetNamespace, "Success");
        }
        
        /// <summary>
        /// Creates a new response <see cref="XmlDocument"/> using the specified root node name, target namespace and with the
        /// specified status value.
        /// </summary>
        /// <param name="rootNodeName">Name of the root node for the <see cref="XmlDocument"/>.</param>
        /// <param name="targetNamespace">The target namespacefor the <see cref="XmlDocument"/>.</param>
        /// <param name="statusValue">The contents of the <c>Status</c> node.</param>
        /// <returns>A response <see cref="XmlDocument"/> with a status.</returns>
        /// <remarks>
        /// The <c>Header</c> part of all response messages used by Mercury follow the same structure, so we can use
        /// a generic method to create them.
        /// </remarks>
        public static XmlDocument CreateResponseMessage(string rootNodeName, string targetNamespace, string statusValue)
        {
            // Create empty document
            XmlDocument msgXml = CreateMessage(rootNodeName, targetNamespace);

            // Add 'Header' node
            XmlElement nHeader = msgXml.CreateElement(Resources.DefaultBtsNamespacePrefix, "Header", targetNamespace);
            msgXml.DocumentElement.AppendChild(nHeader);

            // Add 'Status' node
            XmlElement nStatus = msgXml.CreateElement(Resources.DefaultBtsNamespacePrefix, "Status", targetNamespace);
            nHeader.AppendChild(nStatus);
            nStatus.InnerText = statusValue;

            return msgXml;
        }

        #endregion

        #region CreateProcessStartResponseMessage

        /// <summary>
        /// Creates a new process start response <see cref="XmlDocument"/> using the specified process id.
        /// </summary>
        /// <param name="processId">The process id for the process that has been started.</param>
        /// <returns>
        /// A process start response <see cref="XmlDocument"/> with the process id.
        /// </returns>
        public static XmlDocument CreateProcessStartResponseMessage(System.Guid processId)
        {
            // Create empty document
            XmlDocument msgXml = CreateMessage(Resources.MsgProcessingProcessStartResponseNodeName,
                                               Resources.MsgProcessingProcessStartResponseNamespace);

            // Add 'ProcessId' node
            XmlElement nProcessId = msgXml.CreateElement(Resources.DefaultBtsNamespacePrefix, "ProcessId",
                                                         Resources.MsgProcessingProcessStartResponseNamespace);
            msgXml.DocumentElement.AppendChild(nProcessId);
            nProcessId.InnerText = processId.ToString();

            return msgXml;
        }

        #endregion

        #region  GetNamespace

        /// <overloads>
        /// Gets the target namespace for the specified XLANG message.
        /// </overloads>
        /// <summary>
        /// Gets the target namespace for the specified XLANG message that consists of a single part only.
        /// </summary>
        /// <param name="msg">The XLANG message.</param>
        /// <returns>The target namespace.</returns>
        //public static string GetNamespace(XLANGMessage msg)
        //{

        //    // Default to the first part - number 0
        //    return GetNamespace(msg, 0);
        //}

        /// <summary>
        /// Gets the target namespace for the specified part of an XLANG message.
        /// </summary>
        /// <param name="msg">The XLANG message.</param>
        /// <param name="partNumber">The part number.</param>
        /// <returns>The target namespace.</returns>
        //public static string GetNamespace(XLANGMessage msg, int partNumber)
        //{
        //    XLANGPart part = msg[partNumber];
        //    System.Xml.Schema.XmlSchema sch = part.XmlSchema;
        //    if (sch == null)
        //    {
        //        return String.Empty;
        //    }
        //    else
        //    {
        //        return sch.TargetNamespace;
        //    }
        //}

        #endregion

        #region Convert Message To XML

        /// <summary>
        /// Converts an XLANG message into an XML document.
        /// </summary>
        /// <param name="msg">The XLANG message.</param>
        /// <returns>The XLANG message as an XML document.</returns>
        /// <remarks>
        /// It is assumed that every XLANG message consists of a single message part only.
        /// </remarks>
        //public static XmlDocument ConvertMsgToXml(XLANGMessage msg)
        //{
        //    // Get the XML representation of the message.
        //    XmlDocument msgXml = (XmlDocument)msg[0].RetrieveAs(typeof(XmlDocument));
        //    return msgXml;
        //}

        #endregion
    }
}

