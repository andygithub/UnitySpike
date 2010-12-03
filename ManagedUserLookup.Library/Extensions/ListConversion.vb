Imports System.Web.UI.WebControls

Public Module ListConversion

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToJsonForjqGrid(Of T)(ByVal list As IEnumerable(Of T), ByVal primaryKey As String, ByVal columnNames As IEnumerable(Of String)) As JQGridValidationError
        If list.Count = 0 Then Return New JQGridValidationError


        Dim _grid As New JQGrid With { _
         .rows = (From p In list Select New JQGrid.Row With { _
          .id = Integer.Parse(p.GetPropertyValue(primaryKey).ToString), _
           .cell = ConvertList(p, columnNames) _
         }).ToList _
        }
        _grid.page = 1
        _grid.records = list.Count
        _grid.total = list.Count

        Return New JQGridValidationError With {.JqGrid = _grid}
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToJsonForjqGridList(Of T)(ByVal list As IEnumerable(Of T), ByVal primaryKey As String, ByVal columnNames As IEnumerable(Of String)) As JQGrid
        If list.Count = 0 Then Return New JQGrid


        Dim _grid As New JQGrid With { _
         .rows = (From p In list Select New JQGrid.Row With { _
          .id = Integer.Parse(p.GetPropertyValue(primaryKey).ToString), _
           .cell = ConvertList(p, columnNames) _
         }).ToList _
        }
        _grid.page = 1
        _grid.records = list.Count
        _grid.total = list.Count

        Return _grid
    End Function

    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToExcelExportStream(Of T)(ByVal list As IEnumerable(Of T), ByVal columnNames As List(Of String)) As IO.Stream
        If list.Count = 0 Then Return Nothing


        Using sw As New IO.StringWriter()

            Using htw As New Web.UI.HtmlTextWriter(sw)

                Dim table As New Web.UI.WebControls.Table()
                Dim row As New TableRow()

                'header row
                row.Cells.AddRange((From f In columnNames Select New TableHeaderCell() With {.Text = f}).ToArray)
                table.Rows.Add(row)

                For Each item As T In list
                    Dim _row As New TableRow()
                    Dim _item As T = item
                    _row.Cells.AddRange((From f In columnNames Select New TableCell() With {.Text = _item.GetPropertyValue(f).ToString}).ToArray)
                    table.Rows.Add(_row)
                Next

                table.RenderControl(htw)                
                Return New IO.MemoryStream(Text.Encoding.UTF8.GetBytes(sw.ToString))
                'HttpContext.Current.Response.Write(sw.ToString())

            End Using
        End Using

    End Function

    Public Function ConvertList(Of T)(ByVal record As T, ByVal columnNames As IEnumerable(Of String)) As List(Of String)
        Dim _list As New List(Of String)
        For Each name In columnNames
            _list.Add(record.GetPropertyValue(name).ToString)
        Next
        Return _list
    End Function





End Module
