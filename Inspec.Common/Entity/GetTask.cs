//--------------------------------------------------------------------------
//
// TITLE    : GetTaskRequest
//
// SYNOPSIS : Schema classes for the GetTaskRequest message schema.
// 
// AUTHOR   : Martin Ng
//
//--------------------------------------------------------------------------
using System;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Schema;
using System.ComponentModel;
using Inspec.Mercury.Workflow.Common.SchemaClasses;
using Inspec.Mercury.Workflow.Common.SchemaClasses.InspecIdeas;

//namespace Inspec.Mercury.Workflow.Control.SchemaClasses.GetTask
namespace Inspec.Common.Entity
{

    /// <remarks/>
    // http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1#GetTaskRequest --> GetTaskRequest
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1", IsNullable = false)]
    public partial class GetTaskRequest
    {

        private GetTaskRequestHeader headerField;

        private GetTaskRequestBody bodyField;

        /// <remarks/>
        public GetTaskRequestHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public GetTaskRequestBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1")]
    public partial class GetTaskRequestHeader
    {

        private int userIdField;

        private string sessionIdField;

        /// <remarks/>
        public int UserId
        {
            get
            {
                return this.userIdField;
            }
            set
            {
                this.userIdField = value;
            }
        }

        /// <remarks/>
        public string SessionId
        {
            get
            {
                return this.sessionIdField;
            }
            set
            {
                this.sessionIdField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1")]
    public partial class GetTaskRequestBody
    {

        private GetTaskRequestBodySpecificEntity specificEntityField;

        /// <remarks/>
        public GetTaskRequestBodySpecificEntity SpecificEntity
        {
            get
            {
                return this.specificEntityField;
            }
            set
            {
                this.specificEntityField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1")]
    public partial class GetTaskRequestBodySpecificEntity
    {

        private GetTaskRequestBodySpecificEntityEntityType entityTypeField;

        private int functionTypeIDField;

        private int entityIDField;

        private string entityMINField;

        /// <remarks/>
        public GetTaskRequestBodySpecificEntityEntityType EntityType
        {
            get
            {
                return this.entityTypeField;
            }
            set
            {
                this.entityTypeField = value;
            }
        }

        /// <remarks/>
        public int FunctionTypeID
        {
            get
            {
                return this.functionTypeIDField;
            }
            set
            {
                this.functionTypeIDField = value;
            }
        }

        /// <remarks/>
        public int EntityID
        {
            get
            {
                return this.entityIDField;
            }
            set
            {
                this.entityIDField = value;
            }
        }

        /// <remarks/>
        public string EntityMIN
        {
            get
            {
                return this.entityMINField;
            }
            set
            {
                this.entityMINField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskrequest/v1")]
    public enum GetTaskRequestBodySpecificEntityEntityType
    {

        /// <remarks/>
        Item,

        /// <remarks/>
        Batch,

        /// <remarks/>
        Publication,
    }

    /// <remarks/>
    // http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1#GetTaskResponse --> GetTaskResponse
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1", IsNullable = false)]
    public partial class GetTaskResponse
    {

        private GetTaskResponseHeader headerField;

        private GetTaskResponseBody bodyField;

        /// <remarks/>
        public GetTaskResponseHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public GetTaskResponseBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    public partial class GetTaskResponseHeader
    {

        private GetTaskResponseHeaderStatus statusField;

        /// <remarks/>
        public GetTaskResponseHeaderStatus Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    public enum GetTaskResponseHeaderStatus
    {

        /// <remarks/>
        Success,

        /// <remarks/>
        NoTaskInQueue,

        /// <remarks/>
        LockAcquireAlreadyLocked,

        /// <remarks/>
        UserNotProduction,

        /// <remarks/>
        UserTaskNotExist,

        /// <remarks/>
        UserTaskLockFailed,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    public partial class GetTaskResponseBody
    {

        private GetTaskResponseBodyTask taskField;

        private Bundle bundleField;

        /// <remarks/>
        public GetTaskResponseBodyTask Task
        {
            get
            {
                return this.taskField;
            }
            set
            {
                this.taskField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://Inspec.Mercury.Workflow.Common.SchemasMaps.InspecIdeas")]
        public Bundle Bundle
        {
            get
            {
                return this.bundleField;
            }
            set
            {
                this.bundleField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    public partial class GetTaskResponseBodyTask
    {

        private GetTaskResponseBodyTaskLock lockField;

        private string functionTypeField;

        /// <remarks/>
        public GetTaskResponseBodyTaskLock Lock
        {
            get
            {
                return this.lockField;
            }
            set
            {
                this.lockField = value;
            }
        }

        /// <remarks/>
        public string FunctionType
        {
            get
            {
                return this.functionTypeField;
            }
            set
            {
                this.functionTypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("BTSWebSvcWiz", "3.0.1.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.inspec.org/ideas/xsd/wkf/control/gettaskresponse/v1")]
    public partial class GetTaskResponseBodyTaskLock
    {

        private int lockIdField;

        private System.DateTime lockAcquiredDateTimeField;

        private System.DateTime lockTimeoutDateTimeField;

        /// <remarks/>
        public int LockId
        {
            get
            {
                return this.lockIdField;
            }
            set
            {
                this.lockIdField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LockAcquiredDateTime
        {
            get
            {
                return this.lockAcquiredDateTimeField;
            }
            set
            {
                this.lockAcquiredDateTimeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime LockTimeoutDateTime
        {
            get
            {
                return this.lockTimeoutDateTimeField;
            }
            set
            {
                this.lockTimeoutDateTimeField = value;
            }
        }
    }    

}
