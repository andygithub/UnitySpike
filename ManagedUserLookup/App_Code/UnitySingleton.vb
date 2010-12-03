Imports Microsoft.Practices.Unity.Configuration
Imports Microsoft.Practices.Unity
Imports Microsoft.Practices.Unity.InterceptionExtension


Public NotInheritable Class UnitySingleton
    Implements IDisposable

    Sub New()
        Initialize()
    End Sub

    Private Shared _Container As IUnityContainer
    Private Shared _syncRoot As New Object

    Private Sub Initialize()
        _Container = New UnityContainer()
        'Container.RegisterType(Of IRolesRepository)( _
        '"myInterceptor", _
        'New Interceptor(Of InterfaceInterceptor)("interceptorName"), _
        'New InterceptionBehavior(Of TraceBehavior)("someBehavior"))
        _Container.LoadConfiguration()
    End Sub

    Public Shared ReadOnly Property Container() As IUnityContainer
        Get
            If _Container Is Nothing Then
                SyncLock _syncRoot
                    Dim _instanace As New UnitySingleton
                End SyncLock
            End If
            Return _Container
        End Get
    End Property


#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
                If Not _Container Is Nothing Then
                    _Container.Dispose()
                    _Container = Nothing
                End If
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
