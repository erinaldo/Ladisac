Imports Ladisac.BEPartial Public Class TipoUnidadInherits Ladisac.BE.Maestro.Datos.OrmPublic vArrayDatosComboBox() As DatosComboBoxPublic vElementosDatosComboBox As Int16Public vArrayCamposBusqueda() As StringPublic Property CampoId As StringPublic Property DatoPublic vMensajeError As String = ""Public Property Vista As StringPublic ReadOnly FlagCampoPrincipal As Short = 1Public CadenaFiltrado As String = ""Public CampoPrincipal = "TUN_ID"Public CampoPrincipalValor = TUN_IDPrivate Structure sTablaPublic ReadOnly Property NombreLargo As StringGetReturn "Mae.TipoUnidad"End GetEnd PropertyPublic ReadOnly Property NombreCorto As StringGetReturn "TipoUnidad"End GetEnd PropertyPublic ReadOnly Property NombreVista As StringGetReturn "vwTipoUnidad"End GetEnd PropertyPublic ReadOnly Property NombreFuncionVista As StringGetReturn "fnVistaTipoUnidad"End GetEnd PropertyEnd StructurePrivate Shared Tabla As sTablaPublic ReadOnly Property cTabla As ObjectGetReturn TablaEnd GetEnd PropertyPublic Sub New()MyBase.New()ConfigurarDatosCampos()End SubPrivate Sub ConfigurarDatosCampos()vElementosDatosComboBox = 2ReDim vArrayCamposBusqueda(vElementosDatosComboBox)ReDim vArrayDatosComboBox(vElementosDatosComboBox)vArrayCamposBusqueda(0) = "TUN_ID"vArrayCamposBusqueda(1) = "TUN_DESCRIPCION"vArrayCamposBusqueda(2) = "TUN_ESTADO"vArrayDatosComboBox(0).NombreCampo = "TUN_ID"vArrayDatosComboBox(0).Longitud = 3vArrayDatosComboBox(0).Tipo = "char"vArrayDatosComboBox(0).ParteEntera = 0vArrayDatosComboBox(0).ParteDecimal = 0ReDim vArrayDatosComboBox(0).Valores(0, 0)vArrayDatosComboBox(0).Ancho = 36vArrayDatosComboBox(0).Flag = FalsevArrayDatosComboBox(1).NombreCampo = "TUN_DESCRIPCION"vArrayDatosComboBox(1).Longitud = 45vArrayDatosComboBox(1).Tipo = "varchar"vArrayDatosComboBox(1).ParteEntera = 0vArrayDatosComboBox(1).ParteDecimal = 0ReDim vArrayDatosComboBox(1).Valores(0, 0)vArrayDatosComboBox(1).Ancho = 485vArrayDatosComboBox(1).Flag = FalsevArrayDatosComboBox(2).NombreCampo = "TUN_ESTADO"vArrayDatosComboBox(2).Longitud = 0vArrayDatosComboBox(2).Tipo = "bit"vArrayDatosComboBox(2).ParteEntera = 0vArrayDatosComboBox(2).ParteDecimal = 0ReDim vArrayDatosComboBox(2).Valores(1, 1)vArrayDatosComboBox(2).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(2).Valores(0, 1) = "0"vArrayDatosComboBox(2).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(2).Valores(1, 1) = "1"vArrayDatosComboBox(2).Ancho = 85vArrayDatosComboBox(2).Flag = TrueEnd SubPublic Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorDataVerificarDatos = New ErrorDataVerificarDatos.NumeroError = 1For elemento = 0 To vCampos.Count - 1VerificarDatos.MensajeError = ""Select Case vCampos(elemento)Case "TUN_ID"                    If Len(TUN_ID.Trim) > 0 Then                    Else                        VerificarDatos.NumeroError = 0                        VerificarDatos.MensajeError = mCodigo3_1                        VerificarDatos.Objeto = vCampos(elemento)                    End IfCase "TUN_DESCRIPCION"If Len(TUN_DESCRIPCION.Trim) > 0 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mDescripcionVerificarDatos.Objeto = vCampos(elemento)End IfCase "USU_ID"If Len(USU_ID.Trim) >= 5 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mUsuarioVerificarDatos.Objeto = vCampos(elemento)End IfCase "TUN_FEC_GRAB"If TUN_FEC_GRAB.GetType = GetType(DateTime) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mFechaVerificarDatos.Objeto = vCampos(elemento)End IfCase "TUN_ESTADO"If TUN_ESTADO.GetType = GetType(Boolean) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mEstadoVerificarDatos.Objeto = vCampos(elemento)End IfEnd SelectIf VerificarDatos.NumeroError = 0 Then If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)End IfNextReturn VerificarDatosEnd FunctionPublic Function SentenciaSqlBusqueda() As StringSentenciaSqlBusqueda=""If Vista = "BuscarRegistros"ThenSentenciaSqlBusqueda = "spVistaTipoUnidadXML"End IfEnd FunctionPublic Function DevolverTiposCampos() As StringDevolverTiposCampos = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato ThenDevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)Exit FunctionEnd IfNextEnd IfNextReturn DevolverTiposCamposEnd FunctionPublic Function TipoCampoEspecifico() As StringTipoCampoEspecifico = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato ThenTipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)Exit FunctionEnd IfNextEnd IfNextReturn TipoCampoEspecificoEnd FunctionPublic Function BuscarFormatos()BuscarFormatos = NothingFor vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) ThenBuscarFormatos = vArrayDatosComboBox(vFila).ValoresExit FunctionEnd IfNextReturn BuscarFormatosEnd FunctionPublic Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As IntegerTryDim oVerificarDatos As New ErrorDataIf Parametros Is Nothing ThenoVerificarDatos = VerificarDatos(Parametros)ElseoVerificarDatos = VerificarDatos("TUN_ID","TUN_DESCRIPCION","USU_ID","TUN_FEC_GRAB","TUN_ESTADO")End IfIf oVerificarDatos.NumeroError = 0 ThenvMensajeError = oVerificarDatos.MensajeGeneralReturn 0ElseReturn 1End IfCatch ex As ExceptionvMensajeError = ex.MessageReturn 0End TryEnd FunctionEnd Class