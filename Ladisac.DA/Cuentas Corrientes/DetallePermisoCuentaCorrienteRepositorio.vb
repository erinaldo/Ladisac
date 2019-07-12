Imports Microsoft.Practices.Unity
                                       ByVal cPEU_ID As String,
                                       ByVal cCCT_ID As String) As Short Implements IDetallePermisoCuentaCorrienteRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                item = (From c In context.DetallePermisoCuentaCorriente Where c.PEU_ID = cPEU_ID And c.CCT_ID = cCCT_ID Select c).FirstOrDefault()
                item.MarkAsDeleted()
                DeleteRegistro = Maintenance(item)
                'context.DetalleListaPrecios.ApplyChanges(item)
                'context.SaveChanges()
                'item.AcceptChanges()
                'DeleteRegistro = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                DeleteRegistro = 0
            End Try
        End Function