Imports Microsoft.Practices.Unity
        Public Function DeleteRegistro(ByVal item As BE.SeriesDatosUsuarios, ByVal cDAU_ID As String, ByVal cPVE_ID As String, ByVal cTDO_ID As String, ByVal cCTD_COR_SERIE As String) As Short Implements ISeriesDatosUsuariosRepositorio.DeleteRegistro
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()

                item = (From c In context.SeriesDatosUsuarios Where c.DAU_ID = cDAU_ID And _
                                                                    c.PVE_ID = cPVE_ID And _
                                                                    c.TDO_ID = cTDO_ID And _
                                                                    c.CTD_COR_SERIE = cCTD_COR_SERIE Select c).FirstOrDefault()
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
    End Class