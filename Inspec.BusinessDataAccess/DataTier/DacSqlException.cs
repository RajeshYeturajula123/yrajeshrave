//--------------------------------------------------------------------------
//
// TITLE    : DacSqlException
//
// SYNOPSIS : Workflow Engine data access component (DAC) Sql exception type.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Permissions;
using Framework;

namespace Inspec.BusinessDataAccess.DataTier
{
    /// <summary>
    /// Workflow Engine data access component (DAC) exception type.
    /// </summary>
    /// <remarks>
    /// This exception type is used to represent warnings and errors that occur within the Workflow Engine's
    /// Data Access Component (DAC) as a result of activity with the Microsoft SQL Server database.
    /// </remarks>
    [Serializable]
    public class DacSqlException : WorkflowException
    {
        // Member variable declarations
        private string _detailedMessage;
        private string _databaseServer;
        private byte _severity;
        private string _procedure;
        private int _lineNumber;

        // The exception number of this exception type
        private const int CustomExceptionNumber = 100003;

        #region Constructors

        /// <summary>
        /// Constructor with no params.
        /// </summary>
        public DacSqlException()
            : base()
        {
            this.ExceptionNumber = CustomExceptionNumber;
        }

        /// <summary>
        /// Constructor allowing the Message property to be set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        public DacSqlException(string message)
            : base(message)
        {
            this.ExceptionNumber = CustomExceptionNumber;
        }

        /// <summary>
        /// Constructor allowing the Message and InnerException properties to be set.
        /// </summary>
        /// <param name="message">String setting the message of the exception.</param>
        /// <param name="inner">Sets a reference to the InnerException.</param>
        public DacSqlException(string message, System.Exception inner)
            : base(message, inner)
        {
            this.ExceptionNumber = CustomExceptionNumber;
        }

        /// <summary>
        /// Constructor that uses an instance of a <see cref="SqlException"/> to create a <see cref="DacSqlException"/>.
        /// </summary>
        /// <param name="sqlException">The <see cref="SqlException"/> containing the exception details.</param>
        public DacSqlException(SqlException sqlException)
            : base(sqlException.Message, sqlException)
        {
            this.ExceptionNumber = CustomExceptionNumber;
            InitialiseInformationFromSqlException(sqlException);
        }

        /// <summary>
        /// Constructor used for deserialization of the exception class.
        /// </summary>
        /// <param name="info">Represents the SerializationInfo of the exception.</param>
        /// <param name="context">Represents the context information of the exception.</param>
        protected DacSqlException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.ExceptionNumber = CustomExceptionNumber;

            // Set the exception properties
            this._detailedMessage = info.GetString("dacsqlDetailedMessage");
            this._databaseServer = info.GetString("dacsqlDatabaseServer");
            this._severity = info.GetByte("dacsqlSeverity");
            this._procedure = info.GetString("dacsqlProcedure");
            this._lineNumber = info.GetInt32("dacsqlLineNumber");
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
            info.AddValue("dacsqlDetailedMessage", this._detailedMessage, typeof(string));
            info.AddValue("dacsqlDatabaseServer", this._databaseServer, typeof(string));
            info.AddValue("dacsqlSeverity", this._severity, typeof(byte));
            info.AddValue("dacsqlProcedure", this._procedure, typeof(string));
            info.AddValue("dacsqlLineNumber", this._lineNumber, typeof(int));
            base.GetObjectData(info, context);
        }

        #region Public Properties

        /// <summary>
        /// Gets the detailed exception message.
        /// </summary>
        public string DetailedMessage
        {
            get
            {
                return this._detailedMessage;
            }
        }
        
        /// <summary>
        /// Gets the name of the database server on which the exception occurred.
        /// </summary>
        public string DatabaseServer
        {
            get
            {
                return this._databaseServer;
            }
        }

        /// <summary>
        /// Gets the severity for the database exception.
        /// </summary>
        public byte Severity
        {
            get
            {
                return this._severity;
            }
        }

        /// <summary>
        /// Gets the name of the procedure in which the exception occurred.
        /// </summary>
        public string Procedure
        {
            get
            {
                return this._procedure;
            }
        }

        /// <summary>
        /// Gets the line number of the procedure at which the exception occurred.
        /// </summary>
        public int LineNumber
        {
            get
            {
                return this._lineNumber;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Initialises the <see cref="DacSqlException"/> information using the instance of the <see cref="SqlException"/>.
        /// </summary>
        /// <param name="sqlException">The SQL exception used for initialisation.</param>
        private void InitialiseInformationFromSqlException(SqlException sqlException)
        {
            // These are properties of the base WorkflowException class
            WorkflowExceptionCategory sqlCategory;
            int sqlNumber;
            string sqlCode;

            // All SQL Server errors with a number less than or equal to this value are internal SQL Server errors and not
            // Mercury user-defined messages.
            const int sqlServerErrorMax = 50000;

            // There will be an error for each RAISERROR, this includes both warnings, errors and informational messages.
            // We are only interested in the warnings and errors, i.e. those with a severity > 10. There should only be a single
            // warning or error message, so just look for the first one.
            SqlError sqlErr = null;
            foreach (SqlError x in sqlException.Errors)
            {
                if (x.Class > 10)
                {
                    sqlErr = x;
                    break;
                }
            }

            // Get the error message and error number
            if (sqlErr.Number <= sqlServerErrorMax)
            {
                // This is an internal SQL Server error, no error code available for these
                this._detailedMessage = sqlErr.Message;
                sqlNumber = sqlErr.Number;
                sqlCode = String.Empty;
            }
            else
            {
                // This is a Mercury user-defined message
                // Message format is: <Error Number>: <Error Code>/<Error Message>

                // Get the error number
                int startIndex = 0;
                int ind = sqlErr.Message.IndexOf(": ", startIndex);
                if (ind == -1)                                      // -1 when string not found
                {
                    // No error number, so default to Zero
                    sqlNumber = 0;
                }
                else
                {
                    // Get the error number
                    sqlNumber = Int32.Parse(sqlErr.Message.Remove(ind), CultureInfo.InvariantCulture);
                    startIndex = ind + 2;
                }

                // Get the error code
                ind = sqlErr.Message.IndexOf("/", startIndex);
                if (ind == -1)
                {
                    // No error code, so default to String.Empty
                    sqlCode = String.Empty;
                }
                else
                {
                    // Get the error code
                    sqlCode = sqlErr.Message.Substring(startIndex, ind - startIndex);
                    startIndex = ind + 1;
                }

                // Get the error message
                this._detailedMessage = sqlErr.Message.Remove(0, startIndex);
            }

            // Get the category (warning or error), this depends on the severity of the message
            // All SQL Server errors have numbers 50,000 or less.
            if (sqlErr.Number <= sqlServerErrorMax)
            {
                // This is a SQL Server message, so we'll treat them all as errors
                sqlCategory = WorkflowExceptionCategory.Error;
            }
            else
            {
                // This is a Mercury user-defined message, so we need to look at the severity.
                // Severity 12 is for warnings
                // Severity 16 is for errors
                switch (sqlErr.Class)
                {
                    case 16:
                        sqlCategory = WorkflowExceptionCategory.Error;
                        break;
                    case 12:
                        sqlCategory = WorkflowExceptionCategory.Warning;
                        break;
                    default:
                        // This can't be right, so we'll call it an error
                        sqlCategory = WorkflowExceptionCategory.Error;
                        break;
                }
            }

            // Set the properties of the base WorkflowException class
            InitialiseWorkflowInformation(sqlCategory, sqlNumber, sqlCode);

            // Get other information about the SQL error
            this._databaseServer = sqlErr.Server;
            this._severity = sqlErr.Class;
            this._procedure = sqlErr.Procedure;
            this._lineNumber = sqlErr.LineNumber;
        }

        #endregion

    }
}
