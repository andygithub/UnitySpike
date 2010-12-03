Imports System
Imports Microsoft.Practices.EnterpriseLibrary.Common.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Logging
Imports Microsoft.Practices.EnterpriseLibrary.Logging.Configuration
Imports Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners

Namespace Extensions

    <ConfigurationElementType(GetType(CustomTraceListenerData))> _
    Public Class ConsoleTraceListener
        Inherits CustomTraceListener

        'Public Sub New(ByVal item As Object)
        '    Debug.WriteLine("hit this")
        'End Sub

        ''' <summary>
        ''' Writes trace information, a data object and event information to the listener specific output.
        ''' </summary>
        ''' <param name="eventCache">An  object that contains the current process ID, thread ID, and stack trace information.</param>
        ''' <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
        ''' <param name="eventType">One of the  values specifying the type of event that has caused the trace.</param>
        ''' <param name="id">A numeric identifier for the event.</param>
        ''' <param name="data">The trace data to emit.</param>
        ''' <remarks></remarks>
        Public Overrides Sub TraceData(ByVal eventCache As System.Diagnostics.TraceEventCache, ByVal source As String, ByVal eventType As System.Diagnostics.TraceEventType, ByVal id As Integer, ByVal data As Object)
            Dim _logEntry = CType(data, LogEntry)
            If _logEntry IsNot Nothing AndAlso Formatter IsNot Nothing Then
                WriteLine(Formatter.Format(_logEntry))
            Else
                WriteLine(data.ToString())
            End If
        End Sub

        ''' <summary>
        ''' When overridden in a derived class, writes the specified message to the listener you create in the derived class.
        ''' </summary>
        ''' <param name="message">A message to write.</param>
        ''' <remarks></remarks>
        Public Overrides Sub Write(ByVal message As String)
            Throw New NotImplementedException
        End Sub

        ''' <summary>
        ''' When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.
        ''' </summary>
        ''' <param name="message">A message to write.</param>
        ''' <remarks></remarks>
        Public Overrides Sub WriteLine(ByVal message As String)
            Console.WriteLine(message)
            Debug.WriteLine(message)
        End Sub

    End Class


End Namespace