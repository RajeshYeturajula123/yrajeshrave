//--------------------------------------------------------------------------
//
// TITLE    : AssemblyInfo
//
// SYNOPSIS : Provides assembly attributes for this assembly.
// 
// AUTHOR   : Mark Abrams
//
//--------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Inspec.Mercury.WorkFlow.Common.Components")]
[assembly: AssemblyDescription("Inspec.Mercury.WorkFlow.Common.Components")]
[assembly: AssemblyConfiguration("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// Indicates that the assembly is compliant with the Common Language Specification (CLS).
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("ad6dac54-3d06-447b-9527-ba7f65c4d889")]

#region Enterprise Services assembly attributes

// The name of the Enterprise Services application which will host the assembly's components
[assembly: System.EnterpriseServices.ApplicationName("Inspec.Ideas.Workflow")]

// The description of the Enterprise Services application which will host the assembly's components
[assembly: System.EnterpriseServices.Description("Inspec.Ideas.Workflow")]

// Indicates where assembly components are loaded on activation:
//     - Library : components run in the creator's process
//     - Server  : components run in a system process, dllhost.exe
[assembly: System.EnterpriseServices.ApplicationActivation(System.EnterpriseServices.ActivationOption.Library)]

// Indicates that Enterprise Services application security is required
[assembly: System.EnterpriseServices.ApplicationAccessControl(true)]

#endregion