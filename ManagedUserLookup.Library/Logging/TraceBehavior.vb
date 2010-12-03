Imports Microsoft.Practices.Unity.InterceptionExtension

Namespace Logging

    Public Class TraceBehavior
        Implements IInterceptionBehavior

        Public Function Invoke(ByVal input As IMethodInvocation, ByVal getNext As GetNextInterceptionBehaviorDelegate) As IMethodReturn Implements IInterceptionBehavior.Invoke
            LoggingFacade.Write(My.Resources.LogMessages.Invoking & input.MethodBase.ToString())

            Dim methodReturn As IMethodReturn = getNext().Invoke(input, getNext)

            If methodReturn.Exception Is Nothing Then
                LoggingFacade.Write(My.Resources.LogMessages.Successfullyfinished & input.MethodBase.ToString())
            Else
                LoggingFacade.Write(My.Resources.LogMessages.ExceptionFinished & input.MethodBase.ToString() & " " & methodReturn.Exception.GetType().Name & " " & methodReturn.Exception.Message)
            End If

            Return methodReturn
        End Function

        Public Function GetRequiredInterfaces() As IEnumerable(Of Type) Implements IInterceptionBehavior.GetRequiredInterfaces
            Return Type.EmptyTypes
        End Function

        Public ReadOnly Property WillExecute() As Boolean Implements IInterceptionBehavior.WillExecute
            Get
                Return True
            End Get
        End Property
    End Class

End Namespace