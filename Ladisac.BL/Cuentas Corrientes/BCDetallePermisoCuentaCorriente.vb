Imports Ladisac.BE
            Try
                Dim rep = ContainerService.Resolve(Of DA.IDetallePermisoCuentaCorrienteRepositorio)()
                Using Scope As New System.Transactions.TransactionScope()
                    'If Item.ChangeTracker.State <> ObjectState.Deleted Then
                    'If Item.ProcesarVerificarDatos() = 0 Then
                    'DeleteRegistroDetalleListaPrecios = 0
                    'Exit Function
                    'End If
                    'End If
                    DeleteRegistro = rep.DeleteRegistro(Item, cPEU_ID, cCCT_ID)
                    Scope.Complete()
                End Using
            Catch ex As Exception
                MsgBox(ex.ToString)
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                'If (rethrow) Then
                'Throw
                'End If
                If ex.InnerException Is Nothing Then
                    Item.vMensajeError = ex.Message
                Else
                    Item.vMensajeError = ex.InnerException.Message
                End If

                DeleteRegistro = 0
            End Try
        End Function