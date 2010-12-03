Imports Microsoft.Practices.Unity

<TestFixture()>
Public Class UnityMethodInjectionFixture

    <TestFixtureSetUp()>
    Public Sub SetupContainer()

    End Sub

    <TestFixtureTearDown()>
    Public Sub DestroyContainer()

    End Sub

    <Test()>
    Public Sub TestMethodInjectionTypes()
        Using uContainer As IUnityContainer = New UnityContainer() _
            .RegisterType(Of IMyInterface, Implmented)() _
            .RegisterType(Of MyBaseClass, ChildClass)()
            Dim myInstance As MyObject = uContainer.Resolve(Of MyObject)()
            Assert.That(myInstance.depObjectA.GetType Is GetType(Implmented) AndAlso myInstance.depObjectB.GetType Is GetType(ChildClass))
        End Using
    End Sub

    Public Class MyObject

        Friend depObjectA As IMyInterface
        Friend depObjectB As MyBaseClass

        <InjectionMethod()> _
        Public Sub Initialize(ByVal interfaceObj As IMyInterface, ByVal baseObj As MyBaseClass)
            depObjectA = interfaceObj
            depObjectB = baseObj
        End Sub

    End Class

    Interface IMyInterface

        Property Number As Integer
        Property Text As String
        Sub Execute()

    End Interface

    Public Class Implmented
        Implements IMyInterface

        Public Sub Execute() Implements IMyInterface.Execute

        End Sub

        Public Property Number As Integer Implements IMyInterface.Number

        Public Property Text As String Implements IMyInterface.Text

    End Class

    Public Class MyBaseClass

        Public Property ErrorNumber As String
        Public Property Message As String

    End Class

    Public Class ChildClass
        Inherits MyBaseClass

        Public Property Extra As String
    End Class


End Class
