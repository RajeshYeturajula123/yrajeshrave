//--------------------------------------------------------------------------
//
// TITLE    : ExceptionProcessing
//
// SYNOPSIS : Set of exception processing utilities.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
using System.Xml;
using System.Xml.Serialization;
using Framework = Inspec.Ideas.Framework;
using Inspec.Ideas.Framework.ExceptionManagement;
using Inspec.Mercury.Workflow.Common.Components.Properties;

namespace Inspec.Mercury.Workflow.Common.Components
{
    /// <summary>
    /// Manages all things relating to exceptions within the Workflow Engine.
    /// </summary>
    public static class ExceptionProcessing
    {
        /// <summary>
        /// Determines the category of the specified exception, i.e. whether it is a <i>Warning</i> or an <i>Error</i>.
        /// </summary>
        /// <param name="ex">The exception to be examined in intricate detail with a big magnifying glass.</param>
        /// <returns>A value from the <see cref="WorkflowExceptionCategory"/> enumeration.</returns>
        /// <remarks>
        /// Both <see cref="BusinessProcessException"/> and <see cref="DacSqlException"/> derive from
        /// <see cref="WorkflowException"/> which defines a category for the exception. This makes it very easy to get
        /// hold of the exception category for the specific exception.
        /// </remarks>
        public static WorkflowExceptionCategory GetExceptionCategory(System.Exception ex)
        {
            BusinessProcessException bpex = ex as BusinessProcessException;
            DacSqlException dex = ex as DacSqlException;
            if (bpex != null)
            {
                // A workflow engine business process exception
                return bpex.Category;
            }
            else if (dex != null)
            {
                // A workflow engine data access component (DAC) exception
                return dex.Category;
            }
            else
            {
                // Some other sort of exception, so this must be an error
                return WorkflowExceptionCategory.Error;
            }
        }

        /// <summary>
        /// Determines the code for the specified exception, used to uniquely identify the exception.
        /// </summary>
        /// <param name="ex">The exception to be examined in intricate detail with a big magnifying glass.</param>
        /// <returns>The exception code. If the type of exception does not have a code, <c>String.Empty</c> is returned.</returns>
        /// <remarks>
        /// Both <see cref="BusinessProcessException"/> and <see cref="DacSqlException"/> derive from
        /// <see cref="WorkflowException"/> which defines a code for the exception. This makes it very easy to get
        /// hold of the exception code for the specific exception.
        /// </remarks>
        public static string GetExceptionCode(System.Exception ex)
        {
            BusinessProcessException bpex = ex as BusinessProcessException;
            DacSqlException dex = ex as DacSqlException;
            if (bpex != null)
            {
                // A workflow engine business process exception
                return bpex.Code;
            }
            else if (dex != null)
            {
                // A workflow engine data access component (DAC) exception
                return dex.Code;
            }
            else
            {
                // Codes do not apply to other types of exception, so return String.Empty. 
                return String.Empty;
            }
        }

        /// <summary>
        /// Creates a SoapFaultDetail message based upon the type of exception specified.
        /// </summary>
        /// <param name="ex">An exception containing information that is to be added to the SoapFaultDetail message.</param>
        /// <returns>The SoapFaultDetail message.</returns>
        public static XmlDocument CreateSoapFaultDetailMsg(System.Exception ex)
        {
            // Create the message
            SoapFaultDetail msg = new SoapFaultDetail();
            msg.Internal = new SoapFaultDetailInternal();
            msg.Internal.Workflow = new SoapFaultDetailInternalWorkflow();

            // Set the Message, Exception Number and any other specific information
            BusinessProcessException bpex = ex as BusinessProcessException;
            DacSqlException dex = ex as DacSqlException;
            if (bpex != null)
            {
                // A workflow engine business process exception
                HandleBpException(bpex, ref msg);
            }
            else if (dex != null)
            {
                // A workflow engine data access component (DAC) exception
                HandleDacException(dex, ref msg);
            }
            else
            {
                // Handle it as a generic System.Exception
                HandleSystemException(ex, ref msg);
            }

            // Category
            switch (GetExceptionCategory(ex))
            {
                case WorkflowExceptionCategory.Error:
                    msg.Category = SoapFaultDetailCategory.Error;
                    break;
                case WorkflowExceptionCategory.Warning:
                    msg.Category = SoapFaultDetailCategory.Warning;
                    break;
            }

            // Exception Case Number
            msg.ExceptionCaseNumber = Framework.ExceptionManagement.ExceptionCaseNumber.Generate();

            // Exception Code
            msg.ExceptionCode = GetExceptionCode(ex);

            // Internal - Subsystem
            msg.Internal.Subsystem = Framework.Subsystem.WorkflowEngine.ToString();
            
            // Internal - Source
            msg.Internal.Source = ex.Source;

            // Internal - Stack Trace
            msg.Internal.StackTrace = ex.StackTrace.Trim();

            // Internal - Workflow - Workflow Server
            msg.Internal.Workflow.WorkflowServer = System.Environment.MachineName;

            // Internal - Workflow - Orchestration Name
            // Note: We are trying to get information about the orchestration in which the error occurred.
            //       However, if there is a messaging error (e.g. a message could not be delivered to a
            //       SOAP web service, the error will occur in an assembly in the BizTalk Engine, thus the
            //       top-level stack frame will be the BizTalk Engine and not the orchestration.
            //       Also, if there is an error in a component that is called from an Expression shape, the
            //       top-level stack frame will be the component and not the orchestration.
            //       Variable 'sf' will be null if the exception occurred outside of Orchestration
            StackFrame sf = Framework.ExceptionManagement.ExceptionManager.GetStackFrameByNamespace(ex, ".Orchestrations");
            if (sf == null)
            {
                msg.Internal.Workflow.OrchestrationName = "";
            }
            else
            {
                msg.Internal.Workflow.OrchestrationName = sf.GetMethod().DeclaringType.FullName;
            }

            // Serialise the class into Xml and return it as an Xml document
            XmlDocument msgXml = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(SoapFaultDetail));
            using (System.IO.MemoryStream writer = new System.IO.MemoryStream())
            {
                serializer.Serialize(writer, msg);
                writer.Flush();
                writer.Position = 0;
                msgXml.Load(writer);
            }
            return msgXml;
        }

        #region Private Exception Handlers

        /// <summary>
        /// Handles instances of <see cref="DacSqlException"/>.
        /// </summary>
        /// <param name="dex">The <see cref="DacSqlException"/> exception class.</param>
        /// <param name="msg">The Soap Fault Detail message being created.</param>
        private static void HandleDacException(DacSqlException dex, ref SoapFaultDetail msg)
        {
            // Get the error message and business process error number
            msg.Message = dex.DetailedMessage;                              // not the 'Message' property
            msg.ExceptionNumber = dex.Number;

            // Now we need to add the database-specific info
            msg.Internal.Database = new SoapFaultDetailInternalDatabase();
            msg.Internal.Database.DatabaseServer = dex.DatabaseServer;
            msg.Internal.Database.Severity = dex.Severity;
            msg.Internal.Database.Procedure = dex.Procedure;
            msg.Internal.Database.LineNumber = dex.LineNumber;
        }

        /// <summary>
        /// Handles instances of <see cref="BusinessProcessException"/>.
        /// </summary>
        /// <param name="bpex">The <see cref="BusinessProcessException"/> exception class.</param>
        /// <param name="msg">The Soap Fault Detail message being created.</param>
        private static void HandleBpException(BusinessProcessException bpex, ref SoapFaultDetail msg)
        {
            // Get the error message and business process error number
            msg.Message = bpex.Message;
            msg.ExceptionNumber = bpex.Number;
        }

        /// <summary>
        /// Handles instances of <see cref="System.Exception"/>.
        /// </summary>
        /// <param name="ex">The <see cref="System.Exception"/> exception class.</param>
        /// <param name="msg">The Soap Fault Detail message being created.</param>
        private static void HandleSystemException(System.Exception ex, ref SoapFaultDetail msg)
        {
            // Get the error message
            msg.Message = ex.Message;

            // Get the error number
            // .NET Exceptions are type-based, but each type has a unique HResult property, so we'll use this instead.
            msg.ExceptionNumber = Framework.ExceptionManagement.ExceptionManager.GetExHResult(ex);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="key"></param>
        public static string GetExceptionData(System.Exception ex, string key)
        {
            if (ex.Data != null)
            {
                foreach (System.Collections.DictionaryEntry de in ex.Data)
                {
                    if (de.Key.ToString() == key) return de.Value.ToString();
                }
            }
            return "null";
        }
        #endregion

    }
}
