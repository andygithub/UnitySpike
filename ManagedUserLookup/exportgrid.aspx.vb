Imports System.IO
Imports System.Reflection
Imports System.Diagnostics
Imports ManagedUserLookup.Library
Imports ManagedUserLookup.Library.Interfaces
Imports Microsoft.Practices.Unity

Partial Class exportgrid
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim _interface As String = Request.Form(Resources.Properties.exportInterface)
        
        'get repository
        Dim _repos As IExport = UnitySingleton.Container.Resolve(Of IExport)(_interface)
        'build list and call method
        If _repos.ValidateExportCriteria(Request.Form) Then
            Export(Resources.Messages.ExportFileName, _repos.GetFieldList, _repos.GetExportData(Request.Form))
        Else
            HttpContext.Current.Response.End()
        End If

    End Sub


#Region "export method"

    'Public Function GetPropertyList(Of T)(ByVal item As T) As IEnumerable(Of String)
    '    Dim _list As New List(Of String)
    '    For Each propinfo As PropertyInfo In item.GetType.GetProperties
    '        _list.Add(propinfo.Name)
    '    Next
    '    Return _list
    'End Function

    Public Sub Export(ByVal fileName As String, ByVal fieldList As IEnumerable(Of String), ByVal excelList As JQGrid)

        HttpContext.Current.Response.Clear()
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" & fileName)
        HttpContext.Current.Response.ContentType = "application/ms-excel"
        HttpContext.Current.Response.Write(excelList.ToHTMLTable(fieldList))
        HttpContext.Current.Response.Flush()
        HttpContext.Current.Response.End()

    End Sub

#End Region

End Class
