Imports Ladisac.BE

Imports System.Runtime.Serialization

Public Class TesoreriaCobranzaLegal
    Inherits Ladisac.BE.Maestro.Datos.Orm

    <DataContract()> Partial Public Structure PropertyNames
        Public Shared TDO_ID As String = "TDO_ID"
        Public Shared DTD_ID As String = "DTD_ID"
        Public Shared CCT_ID As String = "CCT_ID"
        Public Shared TCL_SERIE As String = "TCL_SERIE"
        Public Shared TCL_NUMERO As String = "TCL_NUMERO"
        Public Shared TCL_FECHA_EMI As String = "TCL_FECHA_EMI"
        Public Shared PER_ID_CLI As String = "PER_ID_CLI"
        Public Shared MON_ID As String = "MON_ID"
        Public Shared TCL_MONTO As String = "TCL_MONTO"
        Public Shared USU_ID As String = "USU_ID"
        Public Shared TCL_FEC_GRAB As String = "TCL_FEC_GRAB"
        Public Shared TCL_ESTADO As String = "TCL_ESTADO"
    End Structure

    Public Property TDO_ID As String
    Public Property CCT_ID As String
    Public Property TCL_SERIE As String
    Public Property TCL_NUMERO As String
    Public Property DTD_ID As String
    Public Property TCL_FECHA_EMI As Date
    Public Property PER_ID_CLI As String
    Public Property MON_ID As String
    Public Property TCL_MONTO As Decimal
    Public Property USU_ID As String
    Public Property TCL_FEC_GRAB As Date
    Public Property TCL_ESTADO As Boolean

    Public vArrayDatosComboBox() As DatosComboBox
    Public vElementosDatosComboBox As Int16
    Public vArrayCamposBusqueda() As String
    Public Property CampoId As String
    Public Property Dato
    Public vMensajeError As String = ""
    Public Property Vista As String
    Public ReadOnly FlagCampoPrincipal As Short = 4
    Public CadenaFiltrado As String = ""
    Public CampoPrincipal = "TDO_ID"
    Public CampoPrincipalSecundario = "DTD_ID"
    Public CampoPrincipalTercero = "TCL_SERIE"
    Public CampoPrincipalCuarto = "TCL_NUMERO"

    Public CampoPrincipalValor = TDO_ID
    Public CampoPrincipalSecundarioValor = DTD_ID
    Public CampoPrincipalTerceroValor = TCL_SERIE
    Public CampoPrincipalCuartoValor = TCL_NUMERO

    Private Structure sTabla
        Public ReadOnly Property NombreLargo As String
            Get
                Return "Tes.TesoreriaCobranzaLegal"
            End Get
        End Property
        Public ReadOnly Property NombreCorto As String
            Get
                Return "TesoreriaCobranzaLegal"
            End Get
        End Property
        Public ReadOnly Property NombreVista As String
            Get
                Return "vwTesoreriaCobranzaLegal"
            End Get
        End Property
        Public ReadOnly Property NombreFuncionVista As String
            Get
                Return "fnVistaTesoreriaCobranzaLegal"
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
        vElementosDatosComboBox = 14
        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)
        ReDim vArrayDatosComboBox(vElementosDatosComboBox)

        vArrayCamposBusqueda(0) = "TDO_ID"
        vArrayCamposBusqueda(1) = "TDO_DESCRIPCION"
        vArrayCamposBusqueda(2) = "DTD_ID"
        vArrayCamposBusqueda(3) = "DTD_DESCRIPCION"
        vArrayCamposBusqueda(4) = "CCT_ID"
        vArrayCamposBusqueda(5) = "CCT_DESCRIPCION"
        vArrayCamposBusqueda(6) = "TCL_SERIE"
        vArrayCamposBusqueda(7) = "TCL_NUMERO"
        vArrayCamposBusqueda(8) = "TCL_FECHA_EMI"
        vArrayCamposBusqueda(9) = "PER_ID_CLI"
        vArrayCamposBusqueda(10) = "PER_DESCRIPCION_CLI"
        vArrayCamposBusqueda(11) = "PER_ESTADO_CLI"
        vArrayCamposBusqueda(12) = "MON_ID"
        vArrayCamposBusqueda(13) = "TCL_MONTO"
        vArrayCamposBusqueda(14) = "TCL_ESTADO"

        vArrayDatosComboBox(0).NombreCampo = "TDO_ID"
        vArrayDatosComboBox(0).Longitud = 3
        vArrayDatosComboBox(0).Tipo = "char"
        vArrayDatosComboBox(0).ParteEntera = 0
        vArrayDatosComboBox(0).ParteDecimal = 0
        ReDim vArrayDatosComboBox(0).Valores(0, 0)
        vArrayDatosComboBox(0).Ancho = 36
        vArrayDatosComboBox(0).Flag = False

        vArrayDatosComboBox(1).NombreCampo = "TDO_DESCRIPCION"
        vArrayDatosComboBox(1).Longitud = 45
        vArrayDatosComboBox(1).Tipo = "varchar"
        vArrayDatosComboBox(1).ParteEntera = 0
        vArrayDatosComboBox(1).ParteDecimal = 0
        ReDim vArrayDatosComboBox(1).Valores(0, 0)
        vArrayDatosComboBox(1).Ancho = 485
        vArrayDatosComboBox(1).Flag = False

        vArrayDatosComboBox(2).NombreCampo = "DTD_ID"
        vArrayDatosComboBox(2).Longitud = 3
        vArrayDatosComboBox(2).Tipo = "char"
        vArrayDatosComboBox(2).ParteEntera = 0
        vArrayDatosComboBox(2).ParteDecimal = 0
        ReDim vArrayDatosComboBox(2).Valores(0, 0)
        vArrayDatosComboBox(2).Ancho = 36
        vArrayDatosComboBox(2).Flag = False

        vArrayDatosComboBox(3).NombreCampo = "DTD_DESCRIPCION"
        vArrayDatosComboBox(3).Longitud = 45
        vArrayDatosComboBox(3).Tipo = "varchar"
        vArrayDatosComboBox(3).ParteEntera = 0
        vArrayDatosComboBox(3).ParteDecimal = 0
        ReDim vArrayDatosComboBox(3).Valores(0, 0)
        vArrayDatosComboBox(3).Ancho = 485
        vArrayDatosComboBox(3).Flag = False

        vArrayDatosComboBox(4).NombreCampo = "CCT_ID"
        vArrayDatosComboBox(4).Longitud = 3
        vArrayDatosComboBox(4).Tipo = "char"
        vArrayDatosComboBox(4).ParteEntera = 0
        vArrayDatosComboBox(4).ParteDecimal = 0
        ReDim vArrayDatosComboBox(4).Valores(0, 0)
        vArrayDatosComboBox(4).Ancho = 36
        vArrayDatosComboBox(4).Flag = False

        vArrayDatosComboBox(5).NombreCampo = "CCT_DESCRIPCION"
        vArrayDatosComboBox(5).Longitud = 189
        vArrayDatosComboBox(5).Tipo = "varchar"
        vArrayDatosComboBox(5).ParteEntera = 0
        vArrayDatosComboBox(5).ParteDecimal = 0
        ReDim vArrayDatosComboBox(5).Valores(0, 0)
        vArrayDatosComboBox(5).Ancho = 2025
        vArrayDatosComboBox(5).Flag = False

        vArrayDatosComboBox(6).NombreCampo = "TCL_SERIE"
        vArrayDatosComboBox(6).Longitud = 3
        vArrayDatosComboBox(6).Tipo = "char"
        vArrayDatosComboBox(6).ParteEntera = 0
        vArrayDatosComboBox(6).ParteDecimal = 0
        ReDim vArrayDatosComboBox(6).Valores(0, 0)
        vArrayDatosComboBox(6).Ancho = 36
        vArrayDatosComboBox(6).Flag = False

        vArrayDatosComboBox(7).NombreCampo = "TCL_NUMERO"
        vArrayDatosComboBox(7).Longitud = 10
        vArrayDatosComboBox(7).Tipo = "char"
        vArrayDatosComboBox(7).ParteEntera = 0
        vArrayDatosComboBox(7).ParteDecimal = 0
        ReDim vArrayDatosComboBox(7).Valores(0, 0)
        vArrayDatosComboBox(7).Ancho = 111
        vArrayDatosComboBox(7).Flag = False

        vArrayDatosComboBox(8).NombreCampo = "TCL_FECHA_EMI"
        vArrayDatosComboBox(8).Longitud = 0
        vArrayDatosComboBox(8).Tipo = "smalldatetime"
        vArrayDatosComboBox(8).ParteEntera = 0
        vArrayDatosComboBox(8).ParteDecimal = 0
        ReDim vArrayDatosComboBox(8).Valores(0, 0)
        vArrayDatosComboBox(8).Ancho = 15
        vArrayDatosComboBox(8).Flag = False

        vArrayDatosComboBox(9).NombreCampo = "PER_ID_CLI"        vArrayDatosComboBox(9).Longitud = 6        vArrayDatosComboBox(9).Tipo = "char"        vArrayDatosComboBox(9).ParteEntera = 0        vArrayDatosComboBox(9).ParteDecimal = 0        ReDim vArrayDatosComboBox(9).Valores(0, 0)        vArrayDatosComboBox(9).Ancho = 68        vArrayDatosComboBox(9).Flag = False        vArrayDatosComboBox(10).NombreCampo = "PER_DESCRIPCION_CLI"        vArrayDatosComboBox(10).Longitud = 77        vArrayDatosComboBox(10).Tipo = "varchar"        vArrayDatosComboBox(10).ParteEntera = 0        vArrayDatosComboBox(10).ParteDecimal = 0        ReDim vArrayDatosComboBox(10).Valores(0, 0)        vArrayDatosComboBox(10).Ancho = 828        vArrayDatosComboBox(10).Flag = False        vArrayDatosComboBox(11).NombreCampo = "PER_ESTADO_CLI"        vArrayDatosComboBox(11).Longitud = 9        vArrayDatosComboBox(11).Tipo = "varchar"        vArrayDatosComboBox(11).ParteEntera = 0        vArrayDatosComboBox(11).ParteDecimal = 0        ReDim vArrayDatosComboBox(11).Valores(1, 1)        vArrayDatosComboBox(11).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(11).Valores(0, 1) = "0"        vArrayDatosComboBox(11).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(11).Valores(1, 1) = "1"        vArrayDatosComboBox(11).Ancho = 85        vArrayDatosComboBox(11).Flag = True
        vArrayDatosComboBox(12).NombreCampo = "MON_ID"
        vArrayDatosComboBox(12).Longitud = 3
        vArrayDatosComboBox(12).Tipo = "char"
        vArrayDatosComboBox(12).ParteEntera = 0
        vArrayDatosComboBox(12).ParteDecimal = 0
        ReDim vArrayDatosComboBox(12).Valores(0, 0)
        vArrayDatosComboBox(12).Ancho = 36
        vArrayDatosComboBox(12).Flag = False

        vArrayDatosComboBox(13).NombreCampo = "TCL_MONTO"        vArrayDatosComboBox(13).Longitud = 18        vArrayDatosComboBox(13).Tipo = "numeric"        vArrayDatosComboBox(13).ParteEntera = 14        vArrayDatosComboBox(13).ParteDecimal = 4        ReDim vArrayDatosComboBox(13).Valores(0, 0)        vArrayDatosComboBox(13).Ancho = 197        vArrayDatosComboBox(13).Flag = False

        vArrayDatosComboBox(14).NombreCampo = "TCL_ESTADO"
        vArrayDatosComboBox(14).Longitud = 0
        vArrayDatosComboBox(14).Tipo = "bit"
        vArrayDatosComboBox(14).ParteEntera = 0
        vArrayDatosComboBox(14).ParteDecimal = 0
        ReDim vArrayDatosComboBox(14).Valores(1, 1)
        vArrayDatosComboBox(14).Valores(0, 0) = "NO ACTIVO"
        vArrayDatosComboBox(14).Valores(0, 1) = "0"
        vArrayDatosComboBox(14).Valores(1, 0) = "ACTIVO"
        vArrayDatosComboBox(14).Valores(1, 1) = "1"
        vArrayDatosComboBox(14).Ancho = 85
        vArrayDatosComboBox(14).Flag = True

    End Sub
    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData
        VerificarDatos = New ErrorData
        VerificarDatos.NumeroError = 1
        For elemento = 0 To vCampos.Count - 1
            VerificarDatos.MensajeError = ""
            Select Case vCampos(elemento)
                Case "TDO_ID"
                    If Len(TDO_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "DTD_ID"
                    If Len(DTD_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "CCT_ID"
                    If Len(CCT_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_SERIE"
                    If Len(TCL_SERIE.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_NUMERO"
                    If Len(TCL_NUMERO.Trim) = 10 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo10
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_FECHA_EMI"
                    If TCL_FECHA_EMI.GetType = GetType(Date) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "PER_ID_CLI"
                    If Len(PER_ID_CLI.Trim) = 6 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo6
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "MON_ID"
                    If Len(MON_ID.Trim) = 3 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mCodigo3
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_MONTO"                    If TCL_MONTO.GetType = GetType(Decimal) Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mDato                        VerificarDatos.Objeto = vCampos(elemento)                    End If
                Case "USU_ID"
                    If Len(USU_ID.Trim) >= 5 Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mUsuario
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_FEC_GRAB"
                    If TCL_FEC_GRAB.GetType = GetType(DateTime) Then
                    Else
                        VerificarDatos.NumeroError = 0
                        VerificarDatos.MensajeError = mFecha
                        VerificarDatos.Objeto = vCampos(elemento)
                    End If

                Case "TCL_ESTADO"
                    If TCL_ESTADO.GetType = GetType(Boolean) Then
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
            SentenciaSqlBusqueda = "spVistaTesoreriaCobranzaLegalXML"
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
                oVerificarDatos = VerificarDatos("TDO_ID", "DTD_ID", "CCT_ID", "TCL_SERIE", "TCL_NUMERO", "TCL_FECHA_EMI", "PER_ID_CLI", "MON_ID", "TCL_MONTO", "USU_ID", "TCL_FEC_GRAB", "TCL_ESTADO")
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
