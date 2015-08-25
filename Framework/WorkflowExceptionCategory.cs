//--------------------------------------------------------------------------
//
// TITLE    : WorkflowExceptionCategory
//
// SYNOPSIS : Defines a category for a Workflow exception.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

namespace Framework
{
    /// <summary>
    /// Defines a category for an exception.
    /// </summary>
    public enum WorkflowExceptionCategory
    {
        /// <summary>
        /// A warning exception.
        /// </summary>
        /// <remarks>
        /// A warning is typically used to identify an event that is expected as part of the workflow business process,
        /// for example a user input validation error.
        /// </remarks>
        Warning,

        /// <summary>
        /// An error exception.
        /// </summary>
        /// <remarks>
        /// An error is typically used to identify an event that is not expected as part of the workflow business process,
        /// for example a database error or division by zero or a database connection error.
        /// </remarks>
        Error
    }
}
