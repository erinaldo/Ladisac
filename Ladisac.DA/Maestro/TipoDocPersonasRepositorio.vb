﻿Imports Microsoft.Practices.Unity
Imports Ladisac.BE

Namespace Ladisac.DA
    Public Class TipoDocPersonasRepositorio
        Implements DA.ITipoDocPersonasRepositorio

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Function Maintenance(ByVal item As BE.TipoDocPersonas) As Short Implements ITipoDocPersonasRepositorio.Maintenance
            Try
                Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
                context.TipoDocPersonas.ApplyChanges(item)
                context.SaveChanges()
                item.AcceptChanges()
                Maintenance = 1
            Catch ex As Exception
                Dim rethrow = ExceptionPolicy.HandleException(ex, PolicyNames.BusinessLogic)
                If (rethrow) Then
                    Throw
                End If
                Maintenance = 0
            End Try
        End Function
    End Class
End Namespace
