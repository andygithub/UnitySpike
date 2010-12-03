Namespace Interfaces

    Public Interface IExport

        Function GetExportData(ByVal criteria As Specialized.NameValueCollection) As JQGrid
        Function ValidateExportCriteria(ByVal criteria As Specialized.NameValueCollection) As Boolean
        Function GetFieldList() As IEnumerable(Of String)

    End Interface

End Namespace