Imports Ladisac.BE
Partial Public Class PuntoVentaDatosUsuarios
    Inherits Ladisac.BE.Maestro.Datos.Orm

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 2
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "DAU_ID"
    Public CampoPrincipalSecundario = "PVE_ID"
    Public CampoPrincipalValor = DAU_ID
    Public CampoPrincipalSecundarioValor = PVE_ID
    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Mae.PuntoVentaDatosUsuarios"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "PuntoVentaDatosUsuarios"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwPuntoVentaDatosUsuarios"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaPuntoVentaDatosUsuarios"
            End Get
        End Property
    End Structure
    Private Shared Tabla As sTabla
    Public ReadOnly Property cTabla As Object
        Get
            Return Tabla
        End Get
    End Property
    Public Sub New()
        MyBase.New()
        ConfigurarDatosCampos()
    End Sub
    Private Sub ConfigurarDatosCampos()
        vElementosDatosComboBox = 13
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "DAU_ID"
        vArrayCamposBusqueda(1) = "USU_ID"
        vArrayCamposBusqueda(2) = "PER_ID"
        vArrayCamposBusqueda(3) = "PER_DESCRIPCION"
        vArrayCamposBusqueda(4) = "PER_ESTADO"
        vArrayCamposBusqueda(5) = "PVE_ID"
        vArrayCamposBusqueda(6) = "PVE_DESCRIPCION"
        vArrayCamposBusqueda(7) = "PVE_DIRECCION"
        vArrayCamposBusqueda(8) = "PVE_ESTADO"
        vArrayCamposBusqueda(9) = "PDU_TIPO_LISTA"
        vArrayCamposBusqueda(10) = "PDU_ENTREGA_PLANTA"
        vArrayCamposBusqueda(11) = "PDU_ENTREGA_PUNTO_VENTA"
        vArrayCamposBusqueda(12) = "DAU_ESTADO"
        vArrayCamposBusqueda(13) = "PDU_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "DAU_ID"
        vArrayDatosComboBox(0).Longitud = 6
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 68
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "USU_ID"
        vArrayDatosComboBox(1).Longitud = 10
        vArrayDatosComboBox(1).Tipo = "char"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 111
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "PER_ID"
        vArrayDatosComboBox(2).Longitud = 6
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 68
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "PER_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 77
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 828
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "PER_ESTADO"
        vArrayDatosComboBox(4).Longitud = 9
        vArrayDatosComboBox(4).Tipo = "varchar"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(1, 1)
        vArrayDatosComboBox(4).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(4).Valores(0, 1) = "0"
        vArrayDatosComboBox(4).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(4).Valores(1, 1) = "1"
        vArrayDatosComboBox(4).Ancho = 85
        vArrayDatosComboBox(4).Flag = True

        vArrayDatosComboBox(5).NombreCampo = "PVE_ID"
        vArrayDatosComboBox(5).Longitud = 3
        vArrayDatosComboBox(5).Tipo = "char"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 36
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "PVE_DESCRIPCION"
        vArrayDatosComboBox(6).Longitud = 45
        vArrayDatosComboBox(6).Tipo = "varchar"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 485
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "PVE_DIRECCION"
        vArrayDatosComboBox(7).Longitud = 65
        vArrayDatosComboBox(7).Tipo = "varchar"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 699
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "PVE_ESTADO"
        vArrayDatosComboBox(8).Longitud = 9
        vArrayDatosComboBox(8).Tipo = "varchar"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(1, 1)
        vArrayDatosComboBox(8).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(8).Valores(0, 1) = "0"
        vArrayDatosComboBox(8).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(8).Valores(1, 1) = "1"
        vArrayDatosComboBox(8).Ancho = 85
        vArrayDatosComboBox(8).Flag = True

        vArrayDatosComboBox(9).NombreCampo = "PDU_TIPO_LISTA"
        vArrayDatosComboBox(9).Longitud = 5
        vArrayDatosComboBox(9).Tipo = "smallint"
        vArrayDatosComboBox(9).ParteEntera = 5
        vArrayDatosComboBox(9).ParteDecimal = 0
        ReDim vArrayDatosComboBox(9).Valores(1, 1)
        vArrayDatosComboBox(9).Valores(0, 0) = "AMBOS"
        vArrayDatosComboBox(9).Valores(0, 1) = "0"
        vArrayDatosComboBox(9).Valores(1, 0) = "SEGUN PUNTO DE VENTA"
        vArrayDatosComboBox(9).Valores(1, 1) = "1"
        vArrayDatosComboBox(9).Ancho = 166
        vArrayDatosComboBox(9).Flag = True

        vArrayDatosComboBox(10).NombreCampo = "PDU_ENTREGA_PLANTA"
        vArrayDatosComboBox(10).Longitud = 5
        vArrayDatosComboBox(10).Tipo = "smallint"
        vArrayDatosComboBox(10).ParteEntera = 5
        vArrayDatosComboBox(10).ParteDecimal = 0
        ReDim vArrayDatosComboBox(10).Valores(2, 1)
        vArrayDatosComboBox(10).Valores(0, 0) = "AMBOS"
        vArrayDatosComboBox(10).Valores(0, 1) = "0"
        vArrayDatosComboBox(10).Valores(1, 0) = "EN LOCAL"
        vArrayDatosComboBox(10).Valores(1, 1) = "1"
        vArrayDatosComboBox(10).Valores(2, 0) = "EN OBRA"
        vArrayDatosComboBox(10).Valores(2, 1) = "2"
        vArrayDatosComboBox(10).Ancho = 79
        vArrayDatosComboBox(10).Flag = True

        vArrayDatosComboBox(11).NombreCampo = "PDU_ENTREGA_PUNTO_VENTA"
        vArrayDatosComboBox(11).Longitud = 5
        vArrayDatosComboBox(11).Tipo = "smallint"
        vArrayDatosComboBox(11).ParteEntera = 5
        vArrayDatosComboBox(11).ParteDecimal = 0
        ReDim vArrayDatosComboBox(11).Valores(2, 1)
        vArrayDatosComboBox(11).Valores(0, 0) = "AMBOS"
        vArrayDatosComboBox(11).Valores(0, 1) = "0"
        vArrayDatosComboBox(11).Valores(1, 0) = "EN LOCAL"
        vArrayDatosComboBox(11).Valores(1, 1) = "1"
        vArrayDatosComboBox(11).Valores(2, 0) = "EN OBRA"
        vArrayDatosComboBox(11).Valores(2, 1) = "2"
        vArrayDatosComboBox(11).Ancho = 79
        vArrayDatosComboBox(11).Flag = True

        vArrayDatosComboBox(12).NombreCampo = "DAU_ESTADO"
        vArrayDatosComboBox(12).Longitud = 9
        vArrayDatosComboBox(12).Tipo = "varchar"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(1, 1)
        vArrayDatosComboBox(12).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(12).Valores(0, 1) = "0"
        vArrayDatosComboBox(12).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(12).Valores(1, 1) = "1"
        vArrayDatosComboBox(12).Ancho = 85
        vArrayDatosComboBox(12).Flag = True

        vArrayDatosComboBox(13).NombreCampo = "PDU_ESTADO"
        vArrayDatosComboBox(13).Longitud = 0
        vArrayDatosComboBox(13).Tipo = "bit"
        vArrayDatosComboBox(13).ParteEntera = 0
        vArrayDatosComboBox(13).ParteDecimal = 0
        ReDim vArrayDatosComboBox(13).Valores(1, 1)
        vArrayDatosComboBox(13).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(13).Valores(0, 1) = "0"
        vArrayDatosComboBox(13).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(13).Valores(1, 1) = "1"
        vArrayDatosComboBox(13).Ancho = 85
        vArrayDatosComboBox(13).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "DAU_ID"
                    If Len(DAU_ID.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PVE_ID"
                    If Len(PVE_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PDU_TIPO_LISTA"
                    If PDU_TIPO_LISTA >= 0 And PDU_TIPO_LISTA <= 1 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PDU_ENTREGA_PLANTA"
                    If PDU_ENTREGA_PLANTA >= 0 And PDU_ENTREGA_PLANTA <= 2 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PDU_ENTREGA_PUNTO_VENTA"
                    If PDU_ENTREGA_PUNTO_VENTA >= 0 And PDU_ENTREGA_PUNTO_VENTA <= 2 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mDato
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PDU_FEC_GRAB"
                    If PDU_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PDU_ESTADO"
                    If PDU_ESTADO.GetType = GetType(Boolean) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mEstado
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

            End Select
            If VerificarDatos.NumeroError = 0 Then
                If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)
            End If
        Next
        Return VerificarDatos
    End Function
    Public Function SentenciaSqlBusqueda() As String
        SentenciaSqlBusqueda = ""
        If Vista = "BuscarRegistros" Then
            SentenciaSqlBusqueda = "spVistaPuntoVentaDatosUsuariosXML"
        End If
        If Vista = "ListarRegistros" Then
            SentenciaSqlBusqueda = "spListarPuntoVentaDatosUsuariosXML"
        End If
    End Function
    Public Function DevolverTiposCampos() As String
        DevolverTiposCampos = ""
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then
                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)
                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato Then
                        DevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)
                        Exit Function
                    End If
                Next
            End If
        Next
        Return DevolverTiposCampos
    End Function
    Public Function TipoCampoEspecifico() As String
        TipoCampoEspecifico = ""
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then
                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)
                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato Then
                        TipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)
                        Exit Function
                    End If
                Next
            End If
        Next
        Return TipoCampoEspecifico
    End Function
    Public Function BuscarFormatos()
        BuscarFormatos = Nothing
        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)
            If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) Then
                BuscarFormatos = vArrayDatosComboBox(vFila).Valores
                Exit Function
            End If
        Next
        Return BuscarFormatos
    End Function
    Public Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As Integer
        Try
            Dim oVerificarDatos As New ErrorData
            If Parametros Is Nothing Then
                oVerificarDatos = VerificarDatos(Parametros)
            Else
                oVerificarDatos = VerificarDatos("DAU_ID", "PVE_ID", "PDU_TIPO_LISTA", "PDU_ENTREGA_PLANTA", "PDU_ENTREGA_PUNTO_VENTA", "USU_ID", "PDU_FEC_GRAB", "PDU_ESTADO")
            End If
            If oVerificarDatos.NumeroError = 0 Then
                vMensajeError = oVerificarDatos.MensajeGeneral
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            vMensajeError = ex.Message
            Return 0
        End Try
    End Function
End Class
