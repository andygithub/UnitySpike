
' The lower case properties here are required to be lower case
' I cant find a way to rename them when they are serialized to JSON
' XmlElement("yournamehere") does not work for JSON :(
Public Class JQGrid

    Public Class Row
        Public Property id As Integer
        Public Property cell As New List(Of String)

    End Class

    Public Property page As Integer
    Public Property total As Integer
    Public Property records As Integer
    Public Property rows As New List(Of Row)

    Public Function ToHTMLTable(ByVal headers As IEnumerable(Of String)) As String
        Dim _table As String

        Using sw As New IO.StringWriter()

            Using htw As New Web.UI.HtmlTextWriter(sw)

                Dim table As New Web.UI.WebControls.Table()
                Dim row As New Web.UI.WebControls.TableRow()

                'header row
                row.Cells.AddRange((From f In headers Select New Web.UI.WebControls.TableCell() With {.Text = f}).ToArray)
                table.Rows.Add(row)

                For Each _row As JQGrid.Row In Me.rows
                    Dim _tablerow As New Web.UI.WebControls.TableRow()

                    _tablerow.Cells.AddRange((From c In _row.cell Select New Web.UI.WebControls.TableCell() With {.Text = c}).ToArray)
                    table.Rows.Add(_tablerow)
                Next

                table.RenderControl(htw)
                _table = sw.ToString

            End Using
        End Using

        Return _table.ToString
    End Function


End Class