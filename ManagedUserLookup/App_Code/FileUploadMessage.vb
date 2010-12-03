Imports System.ServiceModel
Imports System.IO


<MessageContract()> _
Public Class FileUploadMessage

    <MessageHeader(MustUnderstand:=True)> _
    Public Property Metadata As FileMetaData
    <MessageBodyMember(Order:=1)> _
    Public Property FileByteStream As Stream

End Class