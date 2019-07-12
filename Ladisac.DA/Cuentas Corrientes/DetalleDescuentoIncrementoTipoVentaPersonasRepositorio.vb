Imports Microsoft.Practices.Unity
        Public Function DeleteRegistro(ByVal item As BE.DetalleDescuentoIncrementoTipoVentaPersonas, ByVal cDTP_ID As String, ByVal cART_ID As String, ByVal cDDT_ITEM As Short) As Short Implements IDetalleDescuentoIncrementoTipoVentaPersonasRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                item = (From c In context.DetalleDescuentoIncrementoTipoVentaPersonas Where c.DTP_ID = cDTP_ID And c.ART_ID = cART_ID And c.DDT_ITEM = cDDT_ITEM Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function
    End Class