﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResumenParada
    Inherits Ladisac.Foundation.Views.ViewMaster

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsListaResumenParadaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFecIni = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPlanta = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLadrillo = New System.Windows.Forms.TextBox()
        Me.chkSinPruebas = New System.Windows.Forms.CheckBox()
        Me.numMayor = New System.Windows.Forms.NumericUpDown()
        Me.numMenor = New System.Windows.Forms.NumericUpDown()
        Me.numValor = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.chkForma1 = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtExtrusora = New System.Windows.Forms.TextBox()
        CType(Me.dsListaResumenParadaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMayor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMenor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numValor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Size = New System.Drawing.Size(1076, 28)
        Me.lblTitle.Text = "Resumen Parada"
        '
        'dsListaResumenParadaBindingSource
        '
        Me.dsListaResumenParadaBindingSource.DataMember = "ListaResumenParada"
        Me.dsListaResumenParadaBindingSource.DataSource = GetType(dsListaResumenParada)
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(270, 44)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(202, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Fecha Final"
        '
        'dtpFecIni
        '
        Me.dtpFecIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecIni.Location = New System.Drawing.Point(83, 44)
        Me.dtpFecIni.Name = "dtpFecIni"
        Me.dtpFecIni.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecIni.TabIndex = 83
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 13)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Fecha Inicio"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(460, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.Location = New System.Drawing.Point(515, 44)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(294, 20)
        Me.txtPlanta.TabIndex = 105
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(460, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Ladrillo"
        '
        'txtLadrillo
        '
        Me.txtLadrillo.Location = New System.Drawing.Point(515, 75)
        Me.txtLadrillo.Name = "txtLadrillo"
        Me.txtLadrillo.Size = New System.Drawing.Size(294, 20)
        Me.txtLadrillo.TabIndex = 107
        '
        'chkSinPruebas
        '
        Me.chkSinPruebas.AutoSize = True
        Me.chkSinPruebas.Location = New System.Drawing.Point(852, 46)
        Me.chkSinPruebas.Name = "chkSinPruebas"
        Me.chkSinPruebas.Size = New System.Drawing.Size(83, 17)
        Me.chkSinPruebas.TabIndex = 109
        Me.chkSinPruebas.Text = "Sin Pruebas"
        Me.chkSinPruebas.UseVisualStyleBackColor = True
        '
        'numMayor
        '
        Me.numMayor.Location = New System.Drawing.Point(54, 75)
        Me.numMayor.Name = "numMayor"
        Me.numMayor.Size = New System.Drawing.Size(69, 20)
        Me.numMayor.TabIndex = 110
        Me.numMayor.Value = New Decimal(New Integer() {80, 0, 0, 0})
        '
        'numMenor
        '
        Me.numMenor.Location = New System.Drawing.Point(174, 75)
        Me.numMenor.Name = "numMenor"
        Me.numMenor.Size = New System.Drawing.Size(69, 20)
        Me.numMenor.TabIndex = 111
        Me.numMenor.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'numValor
        '
        Me.numValor.DecimalPlaces = 2
        Me.numValor.Location = New System.Drawing.Point(341, 75)
        Me.numValor.Name = "numValor"
        Me.numValor.Size = New System.Drawing.Size(69, 20)
        Me.numValor.TabIndex = 112
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(131, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Menor"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 79)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 114
        Me.Label5.Text = "Mayor"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(258, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 13)
        Me.Label7.TabIndex = 115
        Me.Label7.Text = "Valor x Min S/."
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(852, 75)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(106, 51)
        Me.btnVisualizar.TabIndex = 116
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource2.Name = "dsListaResumenParada"
        ReportDataSource2.Value = Me.dsListaResumenParadaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaResumenParada.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(15, 138)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1049, 386)
        Me.ReportViewer1.TabIndex = 117
        '
        'chkForma1
        '
        Me.chkForma1.AutoSize = True
        Me.chkForma1.Location = New System.Drawing.Point(1003, 44)
        Me.chkForma1.Name = "chkForma1"
        Me.chkForma1.Size = New System.Drawing.Size(61, 17)
        Me.chkForma1.TabIndex = 118
        Me.chkForma1.Text = "Forma1"
        Me.chkForma1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(460, 109)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 120
        Me.Label8.Text = "Extrusora"
        '
        'txtExtrusora
        '
        Me.txtExtrusora.Location = New System.Drawing.Point(515, 106)
        Me.txtExtrusora.Name = "txtExtrusora"
        Me.txtExtrusora.Size = New System.Drawing.Size(294, 20)
        Me.txtExtrusora.TabIndex = 119
        '
        'frmResumenParada
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1076, 536)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtExtrusora)
        Me.Controls.Add(Me.chkForma1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numValor)
        Me.Controls.Add(Me.numMenor)
        Me.Controls.Add(Me.numMayor)
        Me.Controls.Add(Me.chkSinPruebas)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLadrillo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPlanta)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFecIni)
        Me.Controls.Add(Me.Label6)
        Me.Name = "frmResumenParada"
        Me.Text = "Resumen Parada"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.dtpFecIni, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.txtPlanta, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLadrillo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.chkSinPruebas, 0)
        Me.Controls.SetChildIndex(Me.numMayor, 0)
        Me.Controls.SetChildIndex(Me.numMenor, 0)
        Me.Controls.SetChildIndex(Me.numValor, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.chkForma1, 0)
        Me.Controls.SetChildIndex(Me.txtExtrusora, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        CType(Me.dsListaResumenParadaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMayor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMenor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numValor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLadrillo As System.Windows.Forms.TextBox
    Friend WithEvents chkSinPruebas As System.Windows.Forms.CheckBox
    Friend WithEvents numMayor As System.Windows.Forms.NumericUpDown
    Friend WithEvents numMenor As System.Windows.Forms.NumericUpDown
    Friend WithEvents numValor As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaResumenParadaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkForma1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtExtrusora As System.Windows.Forms.TextBox

End Class
