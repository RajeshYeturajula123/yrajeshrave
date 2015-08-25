//--------------------------------------------------------------------------
//
// TITLE    : WorkflowException
//
// SYNOPSIS : Workflow Engine base exception type.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Framework.ExceptionManagement;

namespace Framework
{
    /// <summary>
    /// Workflow Engine base exception type.
    /// </summary>
    /// <remarks>
    /// This exception type is used as a generic base exception for all Workflow Exception exception types and is
    /// derived from the Inspec.Mercury base application exception <see cref="BaseApplicationException"/>.
    /// This type includes a public property that allows a category to be specified indicating
    /// whether an instance of the exception is an Warning or Error.
    /// </remarks>
    [Serializable]
    public class WorkflowException : BaseApplicationException
    {
        // Member variable declarations
        private WorkflowExceptionCategory _exCategory;
        private int _exNumber;
        private string _exCode;

        // The exception number of this exception type
        private const int CustomExceptionNumber = 100001;

        #region Constructors

        /// <summary>
        /// Constructor with no params.
        /// </summary>
        /// <remarks>
        /// Default the exception category to <i>Error</i>, the exception code to <c>String.Empty and the</c>
        /// exception number to Zero.
        /// </remarks>
        public WorkflowException()
            : this(WorkflowExceptionCategory.Error, 0, String.Empty)
        {
        }

        /// <summary>
        /// Constructor allowing the exception category, number and code properties to be set.
        /// </summary>
        /// <param name="category">The category for the exception.</param>
        /// <param name="number">The number for the exception.</param>
        /// <param name="code">The code for the exception.</param>
        public WorkflowException(WorkflowExceptionCategory category, int number, string code)
            : base()
        {
            this.ExceptionNumber = CustomExceptionNumber;
            InitialiseWorkflowInformation(category, number, code);
        }

        /// <summary>
        /// Constructor allowing the Message property to be set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        /// <remarks>
        /// Default the exception category to <i>Error</i>, the exception code to <c>String.Empty and the</c>
        /// exception number to Zero.
        /// </remarks>
        public WorkflowException(string message)
            : this(message, WorkflowExceptionCategory.Error, 0, String.Empty)
        {
        }

        /// <summary>
        /// Constructor allowing the exception message, category, number and code properties to be set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        /// <param name="category">The category for the exception.</param>
        /// <param name="number">The number for the exception.</param>
        /// <param name="code">The code for the exception.</param>
        public WorkflowException(string message, WorkflowExceptionCategory category, int number, string code)
            : base(message)
        {
            this.ExceptionNumber = CustomExceptionNumber;
            InitialiseWorkflowInformation(category, number, code);
        }

        /// <summary>
        /// Constructor allowing the Message and InnerException properties to be set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        /// <param name="inner">Sets a reference to the InnerException.</param>
        /// <remarks>
        /// Default the exception category to <i>Error</i>, the exception code to <c>String.Empty and the</c>
        /// exception number to Zero.
        /// </remarks>
        public WorkflowException(string message, System.Exception inner)
            : this(message, WorkflowExceptionCategory.Error, 0, String.Empty, inner)
        {
        }

        /// <summary>
        /// Constructor allowing the exception message, category, number, code and the InnerException properties to be
        /// set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        /// <param name="category">The category for the exception.</param>
        /// <param name="number">The number for the exception.</param>
        /// <param name="code">The code for the exception.</param>
        /// <param name="inner">Sets a reference to the InnerException.</param>
        public WorkflowException(string message, WorkflowExceptionCategory category, int number, string code, System.Exception inner)
            : base(message, inner)
        {
            this.ExceptionNumber = CustomExceptionNumber;
            InitialiseWorkflowInformation(category, number, code);
        }

        /// <summary>
        /// Constructor used for deserialization of the exception class.
        /// </summary>
        /// <param name="info">Represents the SerializationInfo of the exception.</param>
        /// <param name="context">Represents the context information of the exception.</param>
        protected WorkflowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ExceptionNumber = CustomExceptionNumber;

            // Set the exception properties
            this._exCategory = (WorkflowExceptionCategory)info.GetValue("exCategory", typeof(WorkflowExceptionCategory));
            this._exNumber = info.GetInt32("exNumber");
            this._exCode = info.GetString("exCode");
        }

        #endregion

        /// <summary>
        /// Override the GetObjectData method to serialize custom values.
        /// </summary>
        /// <param name="info">Represents the SerializationInfo of the exception.</param>
        /// <param name="context">Represents the context information of the exception.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("exCategory", this._exCategory, typeof(WorkflowExceptionCategory));
            info.AddValue("exNumber", this._exNumber, typeof(int));
            info.AddValue("exCode", this._exCode, typeof(string));
            base.GetObjectData(info, context);
        }

        #region Public Properties

        /// <summary>
        /// Gets the category for the workflow exception.
        /// </summary>
        public WorkflowExceptionCategory Category
        {
            get
            {
                return this._exCategory;
            }
        }

        /// <summary>
        /// Gets the number for the workflow exception.
        /// </summary>
        public int Number
        {
            get
            {
                return this._exNumber;
            }
        }

        /// <summary>
        /// Gets the code for the workflow exception.
        /// </summary>
        public string Code
        {
            get
            {
                return this._exCode;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Initialises the private members of the <see cref="WorkflowException"/> exception class.
        /// </summary>
        /// <param name="category">The category for the exception.</param>
        /// <param name="number">The number for the exception.</param>
        /// <param name="code">The code for the exception.</param>
        /// <remarks>
        /// This protected method can be used by derived classes to set the private members of the class
        /// after the class constructor has been called.
        /// </remarks>
        protected void InitialiseWorkflowInformation(WorkflowExceptionCategory category, int number, string code)
        {
            this._exCategory = category;
            this._exNumber = number;
            this._exCode = code;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="category"></param>
        /// <param name="number"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual object CreateException(string message, WorkflowExceptionCategory category, int number, string code)
        {
            return new WorkflowException(message, category, number, code);
        }
    }
}
