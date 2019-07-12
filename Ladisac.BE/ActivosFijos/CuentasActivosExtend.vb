Imports Ladisac.BEPartial Public Class CuentasActivos    Inherits Ladisac.BE.Maestro.Datos.Orm    Public vArrayDatosComboBox() As DatosComboBox    Public vElementosDatosComboBox As Int16    Public vArrayCamposBusqueda() As String    Public Property CampoId As String    Public Property Dato    Public vMensajeError As String = ""    Public Property Vista As String    Public ReadOnly FlagCampoPrincipal As Short = 1    Public CadenaFiltrado As String = ""    Public CampoPrincipal = "CUA_ID"    Public CampoPrincipalValor = CUA_ID    Private Structure sTabla        Public ReadOnly Property NombreLargo As String            Get                Return "Act.CuentasActivos"            End Get        End Property        Public ReadOnly Property NombreCorto As String            Get                Return "CuentasActivos"            End Get        End Property        Public ReadOnly Property NombreVista As String            Get                Return "vwCuentasActivos"            End Get        End Property        Public ReadOnly Property NombreFuncionVista As String            Get                Return "fnVistaCuentasActivos"            End Get        End Property    End Structure    Private Shared Tabla As sTabla    Public ReadOnly Property cTabla As Object        Get            Return Tabla        End Get    End Property    Public Sub New()        MyBase.New()        ConfigurarDatosCampos()    End Sub    Private Sub ConfigurarDatosCampos()        vElementosDatosComboBox = 21        ReDim vArrayCamposBusqueda(vElementosDatosComboBox)        ReDim vArrayDatosComboBox(vElementosDatosComboBox)        vArrayCamposBusqueda(0) = "CUA_ID"        vArrayCamposBusqueda(1) = "CUC_ID_ACT"        vArrayCamposBusqueda(2) = "CUC_DESCRIPCION_ACT"        vArrayCamposBusqueda(3) = "CUC_ESTADO_ACT"        vArrayCamposBusqueda(4) = "CUC_ID_DEP"        vArrayCamposBusqueda(5) = "CUC_DESCRIPCION_DEP"        vArrayCamposBusqueda(6) = "CUC_ESTADO_DEP"        vArrayCamposBusqueda(7) = "CUC_ID_PRO"        vArrayCamposBusqueda(8) = "CUC_DESCRIPCION_PRO"        vArrayCamposBusqueda(9) = "CUC_ESTADO_PRO"        vArrayCamposBusqueda(10) = "CUC_ID_ACT_ACU"        vArrayCamposBusqueda(11) = "CUC_DESCRIPCION_ACT_ACU"        vArrayCamposBusqueda(12) = "CUC_ESTADO_ACT_ACU"        vArrayCamposBusqueda(13) = "CUC_ID_DEP_ACU"        vArrayCamposBusqueda(14) = "CUC_DESCRIPCION_DEP_ACU"        vArrayCamposBusqueda(15) = "CUC_ESTADO_DEP_ACU"        vArrayCamposBusqueda(16) = "CUC_ID_RES"        vArrayCamposBusqueda(17) = "CUC_DESCRIPCION_RES"        vArrayCamposBusqueda(18) = "CUC_ESTADO_RES"        vArrayCamposBusqueda(19) = "CUA_TASA_ANUAL"        vArrayCamposBusqueda(20) = "CUA_MESES"        vArrayCamposBusqueda(21) = "CUA_ESTADO"        vArrayDatosComboBox(0).NombreCampo = "CUA_ID"        vArrayDatosComboBox(0).Longitud = 6        vArrayDatosComboBox(0).Tipo = "char"        vArrayDatosComboBox(0).ParteEntera = 0        vArrayDatosComboBox(0).ParteDecimal = 0        ReDim vArrayDatosComboBox(0).Valores(0, 0)        vArrayDatosComboBox(0).Ancho = 68        vArrayDatosComboBox(0).Flag = False        vArrayDatosComboBox(1).NombreCampo = "CUC_ID_ACT"        vArrayDatosComboBox(1).Longitud = 14        vArrayDatosComboBox(1).Tipo = "char"        vArrayDatosComboBox(1).ParteEntera = 0        vArrayDatosComboBox(1).ParteDecimal = 0        ReDim vArrayDatosComboBox(1).Valores(0, 0)        vArrayDatosComboBox(1).Ancho = 154        vArrayDatosComboBox(1).Flag = False        vArrayDatosComboBox(2).NombreCampo = "CUC_DESCRIPCION_ACT"        vArrayDatosComboBox(2).Longitud = 45        vArrayDatosComboBox(2).Tipo = "varchar"        vArrayDatosComboBox(2).ParteEntera = 0        vArrayDatosComboBox(2).ParteDecimal = 0        ReDim vArrayDatosComboBox(2).Valores(0, 0)        vArrayDatosComboBox(2).Ancho = 485        vArrayDatosComboBox(2).Flag = False        vArrayDatosComboBox(3).NombreCampo = "CUC_ESTADO_ACT"        vArrayDatosComboBox(3).Longitud = 9        vArrayDatosComboBox(3).Tipo = "varchar"        vArrayDatosComboBox(3).ParteEntera = 0        vArrayDatosComboBox(3).ParteDecimal = 0        ReDim vArrayDatosComboBox(3).Valores(1, 1)        vArrayDatosComboBox(3).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(3).Valores(0, 1) = "0"        vArrayDatosComboBox(3).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(3).Valores(1, 1) = "1"        vArrayDatosComboBox(3).Ancho = 85        vArrayDatosComboBox(3).Flag = True        vArrayDatosComboBox(4).NombreCampo = "CUC_ID_DEP"        vArrayDatosComboBox(4).Longitud = 14        vArrayDatosComboBox(4).Tipo = "char"        vArrayDatosComboBox(4).ParteEntera = 0        vArrayDatosComboBox(4).ParteDecimal = 0        ReDim vArrayDatosComboBox(4).Valores(0, 0)        vArrayDatosComboBox(4).Ancho = 154        vArrayDatosComboBox(4).Flag = False        vArrayDatosComboBox(5).NombreCampo = "CUC_DESCRIPCION_DEP"        vArrayDatosComboBox(5).Longitud = 45        vArrayDatosComboBox(5).Tipo = "varchar"        vArrayDatosComboBox(5).ParteEntera = 0        vArrayDatosComboBox(5).ParteDecimal = 0        ReDim vArrayDatosComboBox(5).Valores(0, 0)        vArrayDatosComboBox(5).Ancho = 485        vArrayDatosComboBox(5).Flag = False        vArrayDatosComboBox(6).NombreCampo = "CUC_ESTADO_DEP"        vArrayDatosComboBox(6).Longitud = 9        vArrayDatosComboBox(6).Tipo = "varchar"        vArrayDatosComboBox(6).ParteEntera = 0        vArrayDatosComboBox(6).ParteDecimal = 0        ReDim vArrayDatosComboBox(6).Valores(1, 1)        vArrayDatosComboBox(6).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(6).Valores(0, 1) = "0"        vArrayDatosComboBox(6).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(6).Valores(1, 1) = "1"        vArrayDatosComboBox(6).Ancho = 85        vArrayDatosComboBox(6).Flag = True        vArrayDatosComboBox(7).NombreCampo = "CUC_ID_PRO"        vArrayDatosComboBox(7).Longitud = 14        vArrayDatosComboBox(7).Tipo = "char"        vArrayDatosComboBox(7).ParteEntera = 0        vArrayDatosComboBox(7).ParteDecimal = 0        ReDim vArrayDatosComboBox(7).Valores(0, 0)        vArrayDatosComboBox(7).Ancho = 154        vArrayDatosComboBox(7).Flag = False        vArrayDatosComboBox(8).NombreCampo = "CUC_DESCRIPCION_PRO"        vArrayDatosComboBox(8).Longitud = 45        vArrayDatosComboBox(8).Tipo = "varchar"        vArrayDatosComboBox(8).ParteEntera = 0        vArrayDatosComboBox(8).ParteDecimal = 0        ReDim vArrayDatosComboBox(8).Valores(0, 0)        vArrayDatosComboBox(8).Ancho = 485        vArrayDatosComboBox(8).Flag = False        vArrayDatosComboBox(9).NombreCampo = "CUC_ESTADO_PRO"        vArrayDatosComboBox(9).Longitud = 9        vArrayDatosComboBox(9).Tipo = "varchar"        vArrayDatosComboBox(9).ParteEntera = 0        vArrayDatosComboBox(9).ParteDecimal = 0        ReDim vArrayDatosComboBox(9).Valores(1, 1)        vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(9).Valores(0, 1) = "0"        vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(9).Valores(1, 1) = "1"        vArrayDatosComboBox(9).Ancho = 85        vArrayDatosComboBox(9).Flag = True        vArrayDatosComboBox(10).NombreCampo = "CUC_ID_ACT_ACU"        vArrayDatosComboBox(10).Longitud = 14        vArrayDatosComboBox(10).Tipo = "char"        vArrayDatosComboBox(10).ParteEntera = 0        vArrayDatosComboBox(10).ParteDecimal = 0        ReDim vArrayDatosComboBox(10).Valores(0, 0)        vArrayDatosComboBox(10).Ancho = 154        vArrayDatosComboBox(10).Flag = False        vArrayDatosComboBox(11).NombreCampo = "CUC_DESCRIPCION_ACT_ACU"        vArrayDatosComboBox(11).Longitud = 45        vArrayDatosComboBox(11).Tipo = "varchar"        vArrayDatosComboBox(11).ParteEntera = 0        vArrayDatosComboBox(11).ParteDecimal = 0        ReDim vArrayDatosComboBox(11).Valores(0, 0)        vArrayDatosComboBox(11).Ancho = 485        vArrayDatosComboBox(11).Flag = False        vArrayDatosComboBox(12).NombreCampo = "CUC_ESTADO_ACT_ACU"        vArrayDatosComboBox(12).Longitud = 9        vArrayDatosComboBox(12).Tipo = "varchar"        vArrayDatosComboBox(12).ParteEntera = 0        vArrayDatosComboBox(12).ParteDecimal = 0        ReDim vArrayDatosComboBox(12).Valores(1, 1)        vArrayDatosComboBox(12).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(12).Valores(0, 1) = "0"        vArrayDatosComboBox(12).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(12).Valores(1, 1) = "1"        vArrayDatosComboBox(12).Ancho = 85        vArrayDatosComboBox(12).Flag = True        vArrayDatosComboBox(13).NombreCampo = "CUC_ID_DEP_ACU"        vArrayDatosComboBox(13).Longitud = 14        vArrayDatosComboBox(13).Tipo = "char"        vArrayDatosComboBox(13).ParteEntera = 0        vArrayDatosComboBox(13).ParteDecimal = 0        ReDim vArrayDatosComboBox(13).Valores(0, 0)        vArrayDatosComboBox(13).Ancho = 154        vArrayDatosComboBox(13).Flag = False        vArrayDatosComboBox(14).NombreCampo = "CUC_DESCRIPCION_DEP_ACU"        vArrayDatosComboBox(14).Longitud = 45        vArrayDatosComboBox(14).Tipo = "varchar"        vArrayDatosComboBox(14).ParteEntera = 0        vArrayDatosComboBox(14).ParteDecimal = 0        ReDim vArrayDatosComboBox(14).Valores(0, 0)        vArrayDatosComboBox(14).Ancho = 485        vArrayDatosComboBox(14).Flag = False        vArrayDatosComboBox(15).NombreCampo = "CUC_ESTADO_DEP_ACU"        vArrayDatosComboBox(15).Longitud = 9        vArrayDatosComboBox(15).Tipo = "varchar"        vArrayDatosComboBox(15).ParteEntera = 0        vArrayDatosComboBox(15).ParteDecimal = 0        ReDim vArrayDatosComboBox(15).Valores(1, 1)        vArrayDatosComboBox(15).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(15).Valores(0, 1) = "0"        vArrayDatosComboBox(15).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(15).Valores(1, 1) = "1"        vArrayDatosComboBox(15).Ancho = 85        vArrayDatosComboBox(15).Flag = True        vArrayDatosComboBox(16).NombreCampo = "CUC_ID_RES"        vArrayDatosComboBox(16).Longitud = 14        vArrayDatosComboBox(16).Tipo = "char"        vArrayDatosComboBox(16).ParteEntera = 0        vArrayDatosComboBox(16).ParteDecimal = 0        ReDim vArrayDatosComboBox(16).Valores(0, 0)        vArrayDatosComboBox(16).Ancho = 154        vArrayDatosComboBox(16).Flag = False        vArrayDatosComboBox(17).NombreCampo = "CUC_DESCRIPCION_RES"        vArrayDatosComboBox(17).Longitud = 45        vArrayDatosComboBox(17).Tipo = "varchar"        vArrayDatosComboBox(17).ParteEntera = 0        vArrayDatosComboBox(17).ParteDecimal = 0        ReDim vArrayDatosComboBox(17).Valores(0, 0)        vArrayDatosComboBox(17).Ancho = 485        vArrayDatosComboBox(17).Flag = False        vArrayDatosComboBox(18).NombreCampo = "CUC_ESTADO_RES"        vArrayDatosComboBox(18).Longitud = 9        vArrayDatosComboBox(18).Tipo = "varchar"        vArrayDatosComboBox(18).ParteEntera = 0        vArrayDatosComboBox(18).ParteDecimal = 0        ReDim vArrayDatosComboBox(18).Valores(1, 1)        vArrayDatosComboBox(18).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(18).Valores(0, 1) = "0"        vArrayDatosComboBox(18).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(18).Valores(1, 1) = "1"        vArrayDatosComboBox(18).Ancho = 85        vArrayDatosComboBox(18).Flag = True        vArrayDatosComboBox(19).NombreCampo = "CUA_TASA_ANUAL"        vArrayDatosComboBox(19).Longitud = 2        vArrayDatosComboBox(19).Tipo = "numeric"        vArrayDatosComboBox(19).ParteEntera = 2        vArrayDatosComboBox(19).ParteDecimal = 0        ReDim vArrayDatosComboBox(19).Valores(0, 0)        vArrayDatosComboBox(19).Ancho = 26        vArrayDatosComboBox(19).Flag = False        vArrayDatosComboBox(20).NombreCampo = "CUA_MESES"        vArrayDatosComboBox(20).Longitud = 2        vArrayDatosComboBox(20).Tipo = "numeric"        vArrayDatosComboBox(20).ParteEntera = 2        vArrayDatosComboBox(20).ParteDecimal = 0        ReDim vArrayDatosComboBox(20).Valores(0, 0)        vArrayDatosComboBox(20).Ancho = 26        vArrayDatosComboBox(20).Flag = False        vArrayDatosComboBox(21).NombreCampo = "CUA_ESTADO"        vArrayDatosComboBox(21).Longitud = 0        vArrayDatosComboBox(21).Tipo = "bit"        vArrayDatosComboBox(21).ParteEntera = 0        vArrayDatosComboBox(21).ParteDecimal = 0        ReDim vArrayDatosComboBox(21).Valores(1, 1)        vArrayDatosComboBox(21).Valores(0, 0) = "NO ACTIVO"        vArrayDatosComboBox(21).Valores(0, 1) = "0"        vArrayDatosComboBox(21).Valores(1, 0) = "ACTIVO"        vArrayDatosComboBox(21).Valores(1, 1) = "1"        vArrayDatosComboBox(21).Ancho = 85        vArrayDatosComboBox(21).Flag = True    End Sub    Public Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorData        VerificarDatos = New ErrorData        VerificarDatos.NumeroError = 1        For elemento = 0 To vCampos.Count - 1            VerificarDatos.MensajeError = ""            Select Case vCampos(elemento)                Case "CUA_ID"                    If Len(CUA_ID.Trim) = 6 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mCodigo6                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "CUC_ID_ACT"                    If Len(CUC_ID_ACT.Trim) > 0 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mCodigo14                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "CUC_ID_DEP"                    If IsNothing(CUC_ID_DEP) Then                    Else                        If Len(CUC_ID_DEP.Trim) > 0 Then                        Else                            VerificarDatos.NumeroError = 0                            VerificarDatos.MensajeError = mCodigo14                            VerificarDatos.Objeto = vCampos(elemento)                        End If                    End If                Case "CUC_ID_PRO"                    If IsNothing(CUC_ID_PRO) Then                    Else                        If Len(CUC_ID_PRO.Trim) > 0 Then                        Else                            VerificarDatos.NumeroError = 0                            VerificarDatos.MensajeError = mCodigo14                            VerificarDatos.Objeto = vCampos(elemento)                        End If                    End If                Case "CUC_ID_ACT_ACU"                    If IsNothing(CUC_ID_ACT_ACU) Then                    Else                        If Len(CUC_ID_ACT_ACU.Trim) > 0 Then                        Else                            VerificarDatos.NumeroError = 0                            VerificarDatos.MensajeError = mCodigo14                            VerificarDatos.Objeto = vCampos(elemento)                        End If                    End If                Case "CUC_ID_DEP_ACU"                    If IsNothing(CUC_ID_DEP_ACU) Then                    Else                        If Len(CUC_ID_DEP_ACU.Trim) > 0 Then                        Else                            VerificarDatos.NumeroError = 0                            VerificarDatos.MensajeError = mCodigo14                            VerificarDatos.Objeto = vCampos(elemento)                        End If                    End If                Case "CUC_ID_RES"                    If IsNothing(CUC_ID_RES) Then                    Else                        If Len(CUC_ID_RES.Trim) > 0 Then                        Else                            VerificarDatos.NumeroError = 0                            VerificarDatos.MensajeError = mCodigo14                            VerificarDatos.Objeto = vCampos(elemento)                        End If                    End If                Case "CUA_TASA_ANUAL"                    If CUA_TASA_ANUAL >= 1 And CUA_TASA_ANUAL <= 99 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mDato                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "CUA_MESES"                    If CUA_MESES >= 0 And CUA_MESES <= 60 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mDato                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "USU_ID"                    If Len(USU_ID.Trim) >= 5 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mUsuario                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "CUA_FEC_GRAB"                    If CUA_FEC_GRAB.GetType = GetType(DateTime) Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mFecha                        VerificarDatos.Objeto = vCampos(elemento)                    End If                Case "CUA_ESTADO"                    If CUA_ESTADO.GetType = GetType(Boolean) Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mEstado                        VerificarDatos.Objeto = vCampos(elemento)                    End If            End Select            If VerificarDatos.NumeroError = 0 Then                If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)            End If        Next        Return VerificarDatos    End Function    Public Function SentenciaSqlBusqueda() As String        SentenciaSqlBusqueda = ""        If Vista = "BuscarRegistros" Then            SentenciaSqlBusqueda = "spVistaCuentasActivosXML"        End If    End Function    Public Function DevolverTiposCampos() As String        DevolverTiposCampos = ""        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato Then                        DevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)                        Exit Function                    End If                Next            End If        Next        Return DevolverTiposCampos    End Function    Public Function TipoCampoEspecifico() As String        TipoCampoEspecifico = ""        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)            If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) Then                For vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)                    If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato Then                        TipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)                        Exit Function                    End If                Next            End If        Next        Return TipoCampoEspecifico    End Function    Public Function BuscarFormatos()        BuscarFormatos = Nothing        For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)            If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) Then                BuscarFormatos = vArrayDatosComboBox(vFila).Valores                Exit Function            End If        Next        Return BuscarFormatos    End Function    Public Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As Integer        Try            Dim oVerificarDatos As New ErrorData            If Parametros Is Nothing Then                oVerificarDatos = VerificarDatos(Parametros)            Else                oVerificarDatos = VerificarDatos("CUA_ID", "CUC_ID_ACT", "CUC_ID_DEP", "CUC_ID_PRO", "CUC_ID_ACT_ACU", "CUC_ID_DEP_ACU", "CUC_ID_RES", "CUA_TASA_ANUAL", "CUA_MESES", "USU_ID", "CUA_FEC_GRAB", "CUA_ESTADO")            End If            If oVerificarDatos.NumeroError = 0 Then                vMensajeError = oVerificarDatos.MensajeGeneral                Return 0            Else                Return 1            End If        Catch ex As Exception            vMensajeError = ex.Message            Return 0        End Try    End FunctionEnd Class