﻿Imports Microsoft.Practices.Unity
Imports System.IO
Imports System.Windows.Forms

Public Class frmRptListaSalidaHornoVsDespacho
    <Dependency()> _
    Public Property BCProduccion As Ladisac.BL.IBCProduccion

    Private Sub frmRptListaSalidaHornoVsDespacho_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnVisualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizar.Click
        Try
            ReportViewer1.LocalReport.DataSources.Clear()

            Dim ds As New DataSet
            Dim query = BCProduccion.ListaSalidaHornoVsDespacho(dtpFecIni.Value.Date, dtpFecFin.Value.Date)
            Dim rea As New StringReader(query)
            ds.ReadXml(rea)

            ReportViewer1.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("dsListaSalidaHornoVsDespacho", ds.Tables(0)))
            'ReportViewer1.LocalReport.DataSources("dsListaKardex").Value.List.Table.Merge(ds.Tables(0)) 'Asi tambien funciona
            'Dim parametro(1) As Microsoft.Reporting.WinForms.ReportParameter
            'parametro(0) = New Microsoft.Reporting.WinForms.ReportParameter("FecIni", dtpFecIni.Value.Date)
            'parametro(1) = New Microsoft.Reporting.WinForms.ReportParameter("FecFin", dtpFecFin.Value.Date)
            'parametro(2) = New Microsoft.Reporting.WinForms.ReportParameter("Sem", DatePart("ww", dtpFecFin.DateTime.Date))

            '' Añado uno o varios parámetros(En este caso solo uno al ReportViewer
            'Me.ReportViewer1.LocalReport.SetParameters(parametro)
            ReportViewer1.RefreshReport()
        Catch ex As Exception

        End Try
    End Sub
End Class