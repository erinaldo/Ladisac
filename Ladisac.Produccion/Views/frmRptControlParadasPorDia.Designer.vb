﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptControlParadasPorDia
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.dsListaCtrlParadasXDiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.dsListaResumenControlParadaPorDiaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnVisualizar = New System.Windows.Forms.Button()
        Me.dtpFecFin = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.chkForma1 = New System.Windows.Forms.CheckBox()
        CType(Me.dsListaCtrlParadasXDiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dsListaResumenControlParadaPorDiaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.Text = "Reporte Lista Control Paradas por Dia"
        '
        'dsListaCtrlParadasXDiaBindingSource
        '
        Me.dsListaCtrlParadasXDiaBindingSource.DataMember = "ListaCtrlParadasXDia"
        Me.dsListaCtrlParadasXDiaBindingSource.DataSource = GetType(dsListaCtrlParadasXDia)
        '
        'dsListaResumenControlParadaPorDiaBindingSource
        '
        Me.dsListaResumenControlParadaPorDiaBindingSource.DataMember = "ListaResumenControlParadaPorDia"
        Me.dsListaResumenControlParadaPorDiaBindingSource.DataSource = GetType(dsListaResumenControlParadaPorDia)
        '
        'btnVisualizar
        '
        Me.btnVisualizar.Location = New System.Drawing.Point(180, 40)
        Me.btnVisualizar.Name = "btnVisualizar"
        Me.btnVisualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnVisualizar.TabIndex = 67
        Me.btnVisualizar.Text = "Visualizar"
        Me.btnVisualizar.UseVisualStyleBackColor = True
        '
        'dtpFecFin
        '
        Me.dtpFecFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecFin.Location = New System.Drawing.Point(66, 41)
        Me.dtpFecFin.Name = "dtpFecFin"
        Me.dtpFecFin.Size = New System.Drawing.Size(85, 20)
        Me.dtpFecFin.TabIndex = 66
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "Fecha"
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ReportDataSource1.Name = "dsListaCtrlParadasXDia"
        ReportDataSource1.Value = Me.dsListaCtrlParadasXDiaBindingSource
        ReportDataSource2.Name = "dsListaResumenControlParadaPorDia"
        ReportDataSource2.Value = Me.dsListaResumenControlParadaPorDiaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "rptListaCtrlParadasXDia.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(14, 88)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(609, 308)
        Me.ReportViewer1.TabIndex = 68
        '
        'chkForma1
        '
        Me.chkForma1.AutoSize = True
        Me.chkForma1.Location = New System.Drawing.Point(288, 43)
        Me.chkForma1.Name = "chkForma1"
        Me.chkForma1.Size = New System.Drawing.Size(61, 17)
        Me.chkForma1.TabIndex = 69
        Me.chkForma1.Text = "Forma1"
        Me.chkForma1.UseVisualStyleBackColor = True
        '
        'frmRptControlParadasPorDia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(635, 408)
        Me.Controls.Add(Me.chkForma1)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.btnVisualizar)
        Me.Controls.Add(Me.dtpFecFin)
        Me.Controls.Add(Me.Label3)
        Me.Name = "frmRptControlParadasPorDia"
        Me.Text = "Reporte Lista Control Paradas por Dia"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dtpFecFin, 0)
        Me.Controls.SetChildIndex(Me.btnVisualizar, 0)
        Me.Controls.SetChildIndex(Me.ReportViewer1, 0)
        Me.Controls.SetChildIndex(Me.chkForma1, 0)
        CType(Me.dsListaCtrlParadasXDiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dsListaResumenControlParadaPorDiaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnVisualizar As System.Windows.Forms.Button
    Friend WithEvents dtpFecFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dsListaCtrlParadasXDiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dsListaResumenControlParadaPorDiaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkForma1 As System.Windows.Forms.CheckBox

End Class
