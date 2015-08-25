using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Runtime.Serialization;
using Inspec.Common.Resource;

namespace Framework.ExceptionManagement
{
    [Serializable]
    public class BaseApplicationException : Exception
    {

        private string _machineName;
        private string _appDomainName;
        private string _threadIdentity;
        private string _windowsIdentity;
        private DateTime _createdDateTime = DateTime.Now;
        private int _ExceptionNumber = 50000;
        private const int HResultBase = 32772;

        #region "constructors"
        public BaseApplicationException()
        {

        }

        public BaseApplicationException(string message)
            : base(message)
        {
            InitializeEnvironmentInformation();
            // Set the HResult
            this.HResult = (HResultBase << 16) + this.ExceptionNumber;
        }


        public BaseApplicationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this._machineName = info.GetString("machineName");
            this._createdDateTime = info.GetDateTime("createdDateTime");
            this._appDomainName = info.GetString("appDomainName");
            this._threadIdentity = info.GetString("threadIdentity");
            this._windowsIdentity = info.GetString("windowsIdentity");

            //Set the HResult
            this.HResult = (HResultBase << 16) + this.ExceptionNumber;
        }

        public BaseApplicationException(string message, Exception inner)
            : base(message, inner)
        {
            InitializeEnvironmentInformation();
            //Set the HResult
            this.HResult = (HResultBase << 16) + this.ExceptionNumber;
        }

        #endregion

        #region "Protected Properties"
        //<summary>
        // Gets or sets the unique exception number for the exception type.
        //</summary>
        // <value>The exception number for the exception type.</value>

        protected int ExceptionNumber
        {
            get
            {
                return _ExceptionNumber;
            }
            set
            {
                _ExceptionNumber = value;
            }
        }

        #endregion

        #region "Private Methods"

        //<summary>
        //Initialization function that gathers environment information safely.
        //</summary>
        //<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")> _


        private void InitializeEnvironmentInformation()
        {
            try{
                _machineName = Environment.MachineName;}
            catch (SecurityException ex){
                _machineName = CommonMessages.BaseAppExPermissionDenied;}
            catch{
                _machineName = CommonMessages.BaseAppExAccessException;}

            try{
                _threadIdentity = System.Threading.Thread.CurrentPrincipal.Identity.Name;}
            catch (SecurityException ex){
                _threadIdentity = ex.Message;}

            try{
                _windowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent(true).Name;
            }
            catch (SecurityException ex){
                _windowsIdentity = CommonMessages.BaseAppExPermissionDenied;
            }
            catch{
                _windowsIdentity = CommonMessages.BaseAppExAccessException;
            }

            try{
                _appDomainName = AppDomain.CurrentDomain.FriendlyName;
            }
            catch (SecurityException ex){
                _windowsIdentity = CommonMessages.BaseAppExPermissionDenied;
            }
            catch{
                _windowsIdentity = CommonMessages.BaseAppExAccessException;
            }
        }

        #endregion

    }



}

