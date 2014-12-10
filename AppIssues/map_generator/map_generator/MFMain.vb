Imports System.Reflection

Public Class MFMain


    Private Const ROWSIZE = 30

    Private SelectedColor As Color
    Private Painting As Boolean = False


#Region "Procedures"

    Private Sub MapCreate(Optional ByVal Height As Integer = 30, Optional ByVal Width As Integer = 30)
        Cursor = System.Windows.Forms.Cursors.WaitCursor
        Try
            Me.grid.Visible = False
            Me.grid.Rows.Clear()

            Me.grid.ColumnCount = Width
            For index = 1 To Width
                Me.grid.Columns(index - 1).Name = index.ToString
                Me.grid.Columns(index - 1).Width = ROWSIZE
            Next index


            For index = 0 To Height
                Dim row = New DataGridViewRow
                row.Height = ROWSIZE
                Me.grid.Rows.Add(row)
            Next index

            Me.grid.Dock = DockStyle.Fill
            Me.grid.BringToFront()
            Me.grid.Visible = True
            Me.grid.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    Private Sub MakeGridViewDoubleBuffered(ByVal dgv As DataGridView)
        Dim dgvType As Type = dgv.[GetType]()
        Dim pi As PropertyInfo = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic)
        pi.SetValue(dgv, True, Nothing)
    End Sub

#End Region


#Region "Events"

    Private Sub MFMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SelectedColor = New Color
        SelectedColor = btnPared.BackColor

        MakeGridViewDoubleBuffered(Me.grid)
    End Sub

    Private Sub btnMapCreate_Click(sender As Object, e As EventArgs) Handles btnMapCreate.Click
        Me.pnlMapCreate.Size = New Size(147, 176)
        Me.pnlMapCreate.BringToFront()
        Me.pnlMapCreate.Visible = Not Me.pnlMapCreate.Visible
    End Sub

    Private Sub btnMapCreate_OK_Click(sender As Object, e As EventArgs) Handles btnMapCreate_OK.Click
        Me.pnlMapCreate.Visible = False
        MapCreate(Me.txtHeight.Value, Me.txtWidth.Value)
    End Sub

    Private Sub btnBlock_Click(sender As Object, e As EventArgs) Handles btnSuelo.Click, btnPared.Click
        SelectedColor = CType(sender, Button).BackColor
        Me.grid.DefaultCellStyle.SelectionBackColor = SelectedColor
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Map file|*.map"
        saveFileDialog1.Title = "Guardar fichero de mapa"
        saveFileDialog1.ShowDialog()
        If saveFileDialog1.FileName <> String.Empty Then

        End If
    End Sub

#Region "   Paint"

    Private Sub grid_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grid.CellMouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Painting = True

            If (e.RowIndex > -1) And (e.ColumnIndex > -1) Then
                Me.grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = SelectedColor
            End If
        End If

        If e.Button = Windows.Forms.MouseButtons.Right Then
            If (e.RowIndex > -1) And (e.ColumnIndex > -1) Then
                Me.grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Me.btnSuelo.BackColor
            End If
        End If
    End Sub

    Private Sub grid_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellMouseEnter
        If (Not Painting) Then
            Exit Sub
        End If

        If (e.RowIndex > -1) And (e.ColumnIndex > -1) Then
            Me.grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = SelectedColor
        End If
    End Sub

    Private Sub grid_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellMouseLeave
        If (Not Painting) Then
            Exit Sub
        End If

        If (e.RowIndex > -1) And (e.ColumnIndex > -1) Then
            Me.grid.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = SelectedColor
        End If
    End Sub

    Private Sub grid_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles grid.CellMouseUp
        Painting = False
    End Sub

#End Region

#End Region






End Class
