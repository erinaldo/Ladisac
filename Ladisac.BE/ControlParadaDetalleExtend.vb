﻿Partial Public Class ControlParadaDetalle

    Public Function Clone() As ControlParadaDetalle

        Return DirectCast(Me.MemberwiseClone(), ControlParadaDetalle)

    End Function

    'Public Function Clone(Of T)(ByVal source As T) As T
    '    Dim obj = New System.Runtime.Serialization.DataContractSerializer(GetType(T))
    '    Using stream = New System.IO.MemoryStream()
    '        obj.WriteObject(stream, source)
    '        stream.Seek(0, System.IO.SeekOrigin.Begin)
    '        Return DirectCast(obj.ReadObject(stream), T)
    '    End Using
    'End Function
End Class
