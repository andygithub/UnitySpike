Imports System.Runtime.Serialization
Imports ManagedUserLookup.Library.Constants

<DataContract(Namespace:="http://schemas.acme.it/2009/04")> _
Public Class FileMetaData

    Sub New(ByVal localFileName As String, ByVal remoteFileName As String)

        Me.LocalFileName = localFileName
        Me.RemoteFileName = remoteFileName
        Me.FileType = FileTypeEnum.Generic
    End Sub

    Sub New(ByVal localFileName As String, ByVal remoteFileName As String, ByVal fileType As FileTypeEnum)
        Me.LocalFileName = localFileName
        Me.RemoteFileName = remoteFileName
        Me.FileType = fileType
    End Sub

    <DataMember(Name:="FileType", Order:=0, IsRequired:=True)> _
    Public Property FileType As FileTypeEnum
    <DataMember(Name:="localFilename", Order:=1, IsRequired:=False)> _
    Public Property LocalFileName As String
    <DataMember(Name:="remoteFilename", Order:=2, IsRequired:=False)> _
    Public Property RemoteFileName As String


End Class