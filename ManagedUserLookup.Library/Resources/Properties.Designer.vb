﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.1
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Class Properties
        
        Private Shared resourceMan As Global.System.Resources.ResourceManager
        
        Private Shared resourceCulture As Global.System.Globalization.CultureInfo
        
        <Global.System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")>  _
        Friend Sub New()
            MyBase.New
        End Sub
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("ManagedUserLookup.Library.Properties", GetType(Properties).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Shared Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to DatabaseUserName.
        '''</summary>
        Friend Shared ReadOnly Property DatabaseUserName() As String
            Get
                Return ResourceManager.GetString("DatabaseUserName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Environment.
        '''</summary>
        Friend Shared ReadOnly Property Environment() As String
            Get
                Return ResourceManager.GetString("Environment", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to ExactMatch.
        '''</summary>
        Friend Shared ReadOnly Property ExactMatch() As String
            Get
                Return ResourceManager.GetString("ExactMatch", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to FirstName.
        '''</summary>
        Friend Shared ReadOnly Property FirstName() As String
            Get
                Return ResourceManager.GetString("FirstName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Id.
        '''</summary>
        Friend Shared ReadOnly Property Id() As String
            Get
                Return ResourceManager.GetString("Id", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to LastName.
        '''</summary>
        Friend Shared ReadOnly Property LastName() As String
            Get
                Return ResourceManager.GetString("LastName", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to matchedRoles.
        '''</summary>
        Friend Shared ReadOnly Property matchedRoles() As String
            Get
                Return ResourceManager.GetString("matchedRoles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Name.
        '''</summary>
        Friend Shared ReadOnly Property Name() As String
            Get
                Return ResourceManager.GetString("Name", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Role.
        '''</summary>
        Friend Shared ReadOnly Property Role() As String
            Get
                Return ResourceManager.GetString("Role", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to RoleList.
        '''</summary>
        Friend Shared ReadOnly Property RoleList() As String
            Get
                Return ResourceManager.GetString("RoleList", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to Scope.
        '''</summary>
        Friend Shared ReadOnly Property Scope() As String
            Get
                Return ResourceManager.GetString("Scope", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to USEC.
        '''</summary>
        Friend Shared ReadOnly Property USEC() As String
            Get
                Return ResourceManager.GetString("USEC", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UserId.
        '''</summary>
        Friend Shared ReadOnly Property UserId() As String
            Get
                Return ResourceManager.GetString("UserId", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to UserIdType.
        '''</summary>
        Friend Shared ReadOnly Property UserIdType() As String
            Get
                Return ResourceManager.GetString("UserIdType", resourceCulture)
            End Get
        End Property
    End Class
End Namespace
