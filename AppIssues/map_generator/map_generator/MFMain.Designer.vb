<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MFMain
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MFMain))
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSuelo = New System.Windows.Forms.Button()
        Me.btnPared = New System.Windows.Forms.Button()
        Me.btnMapCreate = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.AllowUserToResizeColumns = False
        Me.grid.AllowUserToResizeRows = False
        Me.grid.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grid.CausesValidation = False
        Me.grid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.ColumnHeadersHeight = 20
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(60, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(55, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.GridColor = System.Drawing.Color.White
        Me.grid.Location = New System.Drawing.Point(311, 5)
        Me.grid.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.grid.MultiSelect = False
        Me.grid.Name = "grid"
        Me.grid.ReadOnly = True
        Me.grid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.LightGray
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Transparent
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grid.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grid.RowHeadersVisible = False
        Me.grid.RowHeadersWidth = 20
        Me.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.grid.RowTemplate.Height = 20
        Me.grid.RowTemplate.ReadOnly = True
        Me.grid.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grid.ShowCellErrors = False
        Me.grid.ShowCellToolTips = False
        Me.grid.ShowEditingIcon = False
        Me.grid.ShowRowErrors = False
        Me.grid.Size = New System.Drawing.Size(341, 273)
        Me.grid.TabIndex = 0
        Me.grid.TabStop = False
        Me.grid.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnMapCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(78, 952)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(5, 501)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(68, 446)
        Me.Panel2.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSuelo)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPared)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(62, 440)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'btnSuelo
        '
        Me.btnSuelo.BackColor = System.Drawing.Color.FromArgb(CType(CType(145, Byte), Integer), CType(CType(104, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.btnSuelo.FlatAppearance.BorderSize = 0
        Me.btnSuelo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnSuelo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnSuelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSuelo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSuelo.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnSuelo.Location = New System.Drawing.Point(2, 3)
        Me.btnSuelo.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSuelo.Name = "btnSuelo"
        Me.btnSuelo.Size = New System.Drawing.Size(58, 41)
        Me.btnSuelo.TabIndex = 1
        Me.btnSuelo.Text = "Libre"
        Me.btnSuelo.UseVisualStyleBackColor = False
        '
        'btnPared
        '
        Me.btnPared.BackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(55, Byte), Integer))
        Me.btnPared.FlatAppearance.BorderSize = 0
        Me.btnPared.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnPared.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnPared.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPared.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPared.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnPared.Location = New System.Drawing.Point(2, 50)
        Me.btnPared.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnPared.Name = "btnPared"
        Me.btnPared.Size = New System.Drawing.Size(58, 41)
        Me.btnPared.TabIndex = 2
        Me.btnPared.Text = "Pared"
        Me.btnPared.UseVisualStyleBackColor = False
        '
        'btnMapCreate
        '
        Me.btnMapCreate.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMapCreate.FlatAppearance.BorderSize = 0
        Me.btnMapCreate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnMapCreate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnMapCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMapCreate.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMapCreate.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnMapCreate.Location = New System.Drawing.Point(5, 5)
        Me.btnMapCreate.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnMapCreate.Name = "btnMapCreate"
        Me.btnMapCreate.Size = New System.Drawing.Size(68, 41)
        Me.btnMapCreate.TabIndex = 0
        Me.btnMapCreate.Text = "Crear"
        Me.btnMapCreate.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(83, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(204, 273)
        Me.Panel3.TabIndex = 2
        '
        'MFMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(981, 952)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Name = "MFMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cartographer Agents - Map generator"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMapCreate As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSuelo As System.Windows.Forms.Button
    Friend WithEvents btnPared As System.Windows.Forms.Button
    Friend WithEvents grid As System.Windows.Forms.DataGridView

End Class
