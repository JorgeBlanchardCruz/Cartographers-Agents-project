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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnSuelo = New System.Windows.Forms.Button()
        Me.btnPared = New System.Windows.Forms.Button()
        Me.btnAgente = New System.Windows.Forms.Button()
        Me.btnMapCreate = New System.Windows.Forms.Button()
        Me.pnlMapCreate = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMapCreate_OK = New System.Windows.Forms.Button()
        Me.txtHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWidth = New System.Windows.Forms.NumericUpDown()
        Me.SplitContainer = New System.Windows.Forms.SplitContainer()
        Me.btnAgua = New System.Windows.Forms.Button()
        Me.btnArbol = New System.Windows.Forms.Button()
        Me.btnEscombros = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlMapCreate.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.txtHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer.Panel1.SuspendLayout()
        Me.SplitContainer.Panel2.SuspendLayout()
        Me.SplitContainer.SuspendLayout()
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(55, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(55, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(107, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(55, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.DefaultCellStyle = DataGridViewCellStyle2
        Me.grid.EnableHeadersVisualStyles = False
        Me.grid.GridColor = System.Drawing.Color.White
        Me.grid.Location = New System.Drawing.Point(159, 7)
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
        Me.grid.Size = New System.Drawing.Size(75, 58)
        Me.grid.TabIndex = 0
        Me.grid.TabStop = False
        Me.grid.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.btnMapCreate)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(79, 952)
        Me.Panel1.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnSave.Location = New System.Drawing.Point(5, 46)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 41)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Guardar"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(95, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.Panel2.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(5, 501)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel2.Size = New System.Drawing.Size(69, 446)
        Me.Panel2.TabIndex = 1
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.btnSuelo)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPared)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnEscombros)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAgua)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnArbol)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnAgente)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(63, 440)
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
        Me.btnSuelo.Tag = "0"
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
        Me.btnPared.Tag = "1"
        Me.btnPared.Text = "Pared"
        Me.btnPared.UseVisualStyleBackColor = False
        '
        'btnAgente
        '
        Me.btnAgente.BackColor = System.Drawing.Color.Silver
        Me.btnAgente.FlatAppearance.BorderSize = 0
        Me.btnAgente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnAgente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnAgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgente.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgente.ForeColor = System.Drawing.Color.DimGray
        Me.btnAgente.Location = New System.Drawing.Point(2, 238)
        Me.btnAgente.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAgente.Name = "btnAgente"
        Me.btnAgente.Size = New System.Drawing.Size(58, 41)
        Me.btnAgente.TabIndex = 3
        Me.btnAgente.Tag = "-1"
        Me.btnAgente.Text = "Agente"
        Me.btnAgente.UseVisualStyleBackColor = False
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
        Me.btnMapCreate.Size = New System.Drawing.Size(69, 41)
        Me.btnMapCreate.TabIndex = 0
        Me.btnMapCreate.Text = "Crear"
        Me.btnMapCreate.UseVisualStyleBackColor = True
        '
        'pnlMapCreate
        '
        Me.pnlMapCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(57, Byte), Integer))
        Me.pnlMapCreate.Controls.Add(Me.Panel3)
        Me.pnlMapCreate.Location = New System.Drawing.Point(0, 0)
        Me.pnlMapCreate.Name = "pnlMapCreate"
        Me.pnlMapCreate.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlMapCreate.Size = New System.Drawing.Size(21, 22)
        Me.pnlMapCreate.TabIndex = 2
        Me.pnlMapCreate.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.btnMapCreate_OK)
        Me.Panel3.Controls.Add(Me.txtHeight)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtWidth)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(2, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel3.Size = New System.Drawing.Size(17, 18)
        Me.Panel3.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Alto"
        '
        'btnMapCreate_OK
        '
        Me.btnMapCreate_OK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnMapCreate_OK.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray
        Me.btnMapCreate_OK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnMapCreate_OK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnMapCreate_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMapCreate_OK.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMapCreate_OK.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnMapCreate_OK.Location = New System.Drawing.Point(10, -33)
        Me.btnMapCreate_OK.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnMapCreate_OK.Name = "btnMapCreate_OK"
        Me.btnMapCreate_OK.Size = New System.Drawing.Size(0, 41)
        Me.btnMapCreate_OK.TabIndex = 4
        Me.btnMapCreate_OK.Text = "Ok"
        Me.btnMapCreate_OK.UseVisualStyleBackColor = True
        '
        'txtHeight
        '
        Me.txtHeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHeight.Location = New System.Drawing.Point(82, 34)
        Me.txtHeight.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.txtHeight.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(42, 22)
        Me.txtHeight.TabIndex = 0
        Me.txtHeight.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(22, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ancho"
        '
        'txtWidth
        '
        Me.txtWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtWidth.Location = New System.Drawing.Point(82, 77)
        Me.txtWidth.Maximum = New Decimal(New Integer() {150, 0, 0, 0})
        Me.txtWidth.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(42, 22)
        Me.txtWidth.TabIndex = 2
        Me.txtWidth.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'SplitContainer
        '
        Me.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer.Name = "SplitContainer"
        '
        'SplitContainer.Panel1
        '
        Me.SplitContainer.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer.Panel1MinSize = 78
        '
        'SplitContainer.Panel2
        '
        Me.SplitContainer.Panel2.Controls.Add(Me.pnlMapCreate)
        Me.SplitContainer.Panel2.Controls.Add(Me.grid)
        Me.SplitContainer.Size = New System.Drawing.Size(981, 952)
        Me.SplitContainer.SplitterDistance = 79
        Me.SplitContainer.TabIndex = 3
        '
        'btnAgua
        '
        Me.btnAgua.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(179, Byte), Integer))
        Me.btnAgua.FlatAppearance.BorderSize = 0
        Me.btnAgua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnAgua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnAgua.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAgua.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgua.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnAgua.Location = New System.Drawing.Point(2, 144)
        Me.btnAgua.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnAgua.Name = "btnAgua"
        Me.btnAgua.Size = New System.Drawing.Size(58, 41)
        Me.btnAgua.TabIndex = 4
        Me.btnAgua.Tag = "3"
        Me.btnAgua.Text = "Agua"
        Me.btnAgua.UseVisualStyleBackColor = False
        '
        'btnArbol
        '
        Me.btnArbol.BackColor = System.Drawing.Color.FromArgb(CType(CType(98, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.btnArbol.FlatAppearance.BorderSize = 0
        Me.btnArbol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnArbol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnArbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnArbol.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArbol.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnArbol.Location = New System.Drawing.Point(2, 191)
        Me.btnArbol.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnArbol.Name = "btnArbol"
        Me.btnArbol.Size = New System.Drawing.Size(58, 41)
        Me.btnArbol.TabIndex = 5
        Me.btnArbol.Tag = "4"
        Me.btnArbol.Text = "Árbol"
        Me.btnArbol.UseVisualStyleBackColor = False
        '
        'btnEscombros
        '
        Me.btnEscombros.BackColor = System.Drawing.Color.FromArgb(CType(CType(242, Byte), Integer), CType(CType(210, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnEscombros.FlatAppearance.BorderSize = 0
        Me.btnEscombros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnEscombros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnEscombros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEscombros.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEscombros.ForeColor = System.Drawing.Color.DimGray
        Me.btnEscombros.Location = New System.Drawing.Point(2, 97)
        Me.btnEscombros.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnEscombros.Name = "btnEscombros"
        Me.btnEscombros.Size = New System.Drawing.Size(58, 41)
        Me.btnEscombros.TabIndex = 6
        Me.btnEscombros.Tag = "2"
        Me.btnEscombros.Text = "Escombros"
        Me.btnEscombros.UseVisualStyleBackColor = False
        '
        'btnLoad
        '
        Me.btnLoad.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnLoad.FlatAppearance.BorderSize = 0
        Me.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.CadetBlue
        Me.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.Gainsboro
        Me.btnLoad.Location = New System.Drawing.Point(5, 87)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(69, 41)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Text = "Cargar"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'MFMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(981, 952)
        Me.Controls.Add(Me.SplitContainer)
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
        Me.pnlMapCreate.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWidth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.Panel1.ResumeLayout(False)
        Me.SplitContainer.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMapCreate As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlMapCreate As System.Windows.Forms.Panel
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnSuelo As System.Windows.Forms.Button
    Friend WithEvents btnPared As System.Windows.Forms.Button
    Friend WithEvents grid As System.Windows.Forms.DataGridView
    Friend WithEvents btnMapCreate_OK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer As System.Windows.Forms.SplitContainer
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAgente As System.Windows.Forms.Button
    Friend WithEvents btnAgua As System.Windows.Forms.Button
    Friend WithEvents btnArbol As System.Windows.Forms.Button
    Friend WithEvents btnEscombros As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button

End Class
