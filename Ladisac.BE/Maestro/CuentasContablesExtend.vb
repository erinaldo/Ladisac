Imports Ladisac.BEPartial Public Class CuentasContablesInherits Ladisac.BE.Maestro.Datos.OrmPublic vArrayDatosComboBox() As DatosComboBoxPublic vElementosDatosComboBox As Int16Public vArrayCamposBusqueda() As StringPublic Property CampoId As StringPublic Property DatoPublic vMensajeError As String = ""Public Property Vista As StringPublic ReadOnly FlagCampoPrincipal As Short = 1Public CadenaFiltrado As String = ""Public CampoPrincipal = "CUC_ID"Public CampoPrincipalValor = CUC_IDPrivate Structure sTablaPublic ReadOnly Property NombreLargo As StringGetReturn "Mae.CuentasContables"End GetEnd PropertyPublic ReadOnly Property NombreCorto As StringGetReturn "CuentasContables"End GetEnd PropertyPublic ReadOnly Property NombreVista As StringGetReturn "vwCuentasContables"End GetEnd PropertyPublic ReadOnly Property NombreFuncionVista As StringGetReturn "fnVistaCuentasContables"End GetEnd PropertyEnd StructurePrivate Shared Tabla As sTablaPublic ReadOnly Property cTabla As ObjectGetReturn TablaEnd GetEnd PropertyPublic Sub New()MyBase.New()ConfigurarDatosCampos()End SubPrivate Sub ConfigurarDatosCampos()vElementosDatosComboBox = 9ReDim vArrayCamposBusqueda(vElementosDatosComboBox)ReDim vArrayDatosComboBox(vElementosDatosComboBox)vArrayCamposBusqueda(0) = "CUC_ID"vArrayCamposBusqueda(1) = "CUC_DESCRIPCION"vArrayCamposBusqueda(2) = "CLS_ID"vArrayCamposBusqueda(3) = "CLS_CLASE"vArrayCamposBusqueda(4) = "CUC_IDCARGO"vArrayCamposBusqueda(5) = "CUC_DESCRIPCION_CARGO"vArrayCamposBusqueda(6) = "CUC_IDABONO"vArrayCamposBusqueda(7) = "CUC_DESCRIPCION_ABONO"vArrayCamposBusqueda(8) = "CUC_ESCENTROCOSTO"vArrayCamposBusqueda(9) = "CUC_ESTADO"vArrayDatosComboBox(0).NombreCampo = "CUC_ID"vArrayDatosComboBox(0).Longitud = 14vArrayDatosComboBox(0).Tipo = "char"vArrayDatosComboBox(0).ParteEntera = 0vArrayDatosComboBox(0).ParteDecimal = 0ReDim vArrayDatosComboBox(0).Valores(0, 0)vArrayDatosComboBox(0).Ancho = 154vArrayDatosComboBox(0).Flag = FalsevArrayDatosComboBox(1).NombreCampo = "CUC_DESCRIPCION"vArrayDatosComboBox(1).Longitud = 45vArrayDatosComboBox(1).Tipo = "varchar"vArrayDatosComboBox(1).ParteEntera = 0vArrayDatosComboBox(1).ParteDecimal = 0ReDim vArrayDatosComboBox(1).Valores(0, 0)vArrayDatosComboBox(1).Ancho = 485vArrayDatosComboBox(1).Flag = FalsevArrayDatosComboBox(2).NombreCampo = "CLS_ID"vArrayDatosComboBox(2).Longitud = 2vArrayDatosComboBox(2).Tipo = "char"vArrayDatosComboBox(2).ParteEntera = 0vArrayDatosComboBox(2).ParteDecimal = 0ReDim vArrayDatosComboBox(2).Valores(0, 0)vArrayDatosComboBox(2).Ancho = 26vArrayDatosComboBox(2).Flag = FalsevArrayDatosComboBox(3).NombreCampo = "CLS_CLASE"vArrayDatosComboBox(3).Longitud = 45vArrayDatosComboBox(3).Tipo = "varchar"vArrayDatosComboBox(3).ParteEntera = 0vArrayDatosComboBox(3).ParteDecimal = 0ReDim vArrayDatosComboBox(3).Valores(0, 0)vArrayDatosComboBox(3).Ancho = 485vArrayDatosComboBox(3).Flag = FalsevArrayDatosComboBox(4).NombreCampo = "CUC_IDCARGO"vArrayDatosComboBox(4).Longitud = 14vArrayDatosComboBox(4).Tipo = "char"vArrayDatosComboBox(4).ParteEntera = 0vArrayDatosComboBox(4).ParteDecimal = 0ReDim vArrayDatosComboBox(4).Valores(0, 0)vArrayDatosComboBox(4).Ancho = 154vArrayDatosComboBox(4).Flag = FalsevArrayDatosComboBox(5).NombreCampo = "CUC_DESCRIPCION_CARGO"vArrayDatosComboBox(5).Longitud = 45vArrayDatosComboBox(5).Tipo = "varchar"vArrayDatosComboBox(5).ParteEntera = 0vArrayDatosComboBox(5).ParteDecimal = 0ReDim vArrayDatosComboBox(5).Valores(0, 0)vArrayDatosComboBox(5).Ancho = 485vArrayDatosComboBox(5).Flag = FalsevArrayDatosComboBox(6).NombreCampo = "CUC_IDABONO"vArrayDatosComboBox(6).Longitud = 14vArrayDatosComboBox(6).Tipo = "char"vArrayDatosComboBox(6).ParteEntera = 0vArrayDatosComboBox(6).ParteDecimal = 0ReDim vArrayDatosComboBox(6).Valores(0, 0)vArrayDatosComboBox(6).Ancho = 154vArrayDatosComboBox(6).Flag = FalsevArrayDatosComboBox(7).NombreCampo = "CUC_DESCRIPCION_ABONO"vArrayDatosComboBox(7).Longitud = 45vArrayDatosComboBox(7).Tipo = "varchar"vArrayDatosComboBox(7).ParteEntera = 0vArrayDatosComboBox(7).ParteDecimal = 0ReDim vArrayDatosComboBox(7).Valores(0, 0)vArrayDatosComboBox(7).Ancho = 485vArrayDatosComboBox(7).Flag = FalsevArrayDatosComboBox(8).NombreCampo = "CUC_ESCENTROCOSTO"vArrayDatosComboBox(8).Longitud = 2vArrayDatosComboBox(8).Tipo = "varchar"vArrayDatosComboBox(8).ParteEntera = 0vArrayDatosComboBox(8).ParteDecimal = 0ReDim vArrayDatosComboBox(8).Valores(1, 1)vArrayDatosComboBox(8).Valores(0, 0) = "NO"vArrayDatosComboBox(8).Valores(0, 1) = "0"vArrayDatosComboBox(8).Valores(1, 0) = "SI"vArrayDatosComboBox(8).Valores(1, 1) = "1"vArrayDatosComboBox(8).Ancho = 40vArrayDatosComboBox(8).Flag = TruevArrayDatosComboBox(9).NombreCampo = "CUC_ESTADO"vArrayDatosComboBox(9).Longitud = 0vArrayDatosComboBox(9).Tipo = "bit"vArrayDatosComboBox(9).ParteEntera = 0vArrayDatosComboBox(9).ParteDecimal = 0ReDim vArrayDatosComboBox(9).Valores(1, 1)vArrayDatosComboBox(9).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(9).Valores(0, 1) = "0"vArrayDatosComboBox(9).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(9).Valores(1, 1) = "1"vArrayDatosComboBox(9).Ancho = 85vArrayDatosComboBox(9).Flag = TrueEnd SubPublic Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorDataVerificarDatos = New ErrorDataVerificarDatos.NumeroError = 1For elemento = 0 To vCampos.Count - 1VerificarDatos.MensajeError = ""Select Case vCampos(elemento)Case "CUC_ID"If Len(CUC_ID.Trim) = 14 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo14VerificarDatos.Objeto = vCampos(elemento)End IfCase "CUC_DESCRIPCION"If Len(CUC_DESCRIPCION.Trim) > 0 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mDescripcionVerificarDatos.Objeto = vCampos(elemento)End IfCase "cls_Id"If IsNothing(cls_Id) ThenElseIf Len(cls_Id.Trim) = 2 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo2VerificarDatos.Objeto = vCampos(elemento)End IfEnd IfCase "cuc_IdCargo"If IsNothing(cuc_IdCargo) ThenElseIf Len(cuc_IdCargo.Trim) = 14 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo14VerificarDatos.Objeto = vCampos(elemento)End IfEnd IfCase "cuc_IdAbono"If IsNothing(cuc_IdAbono) ThenElseIf Len(cuc_IdAbono.Trim) = 14 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo14VerificarDatos.Objeto = vCampos(elemento)End IfEnd IfCase "cuc_EsCentroCosto"If IsNothing(cuc_EsCentroCosto) ThenElseIf cuc_EsCentroCosto.GetType = GetType(Boolean) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mEstadoVerificarDatos.Objeto = vCampos(elemento)End IfEnd IfCase "USU_ID"If Len(USU_ID.Trim) >= 5 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mUsuarioVerificarDatos.Objeto = vCampos(elemento)End IfCase "CUC_FEC_GRAB"If CUC_FEC_GRAB.GetType = GetType(DateTime) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mFechaVerificarDatos.Objeto = vCampos(elemento)End IfCase "CUC_ESTADO"If CUC_ESTADO.GetType = GetType(Boolean) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mEstadoVerificarDatos.Objeto = vCampos(elemento)End IfEnd SelectIf VerificarDatos.NumeroError = 0 Then If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)End IfNextReturn VerificarDatosEnd FunctionPublic Function SentenciaSqlBusqueda() As StringSentenciaSqlBusqueda=""If Vista = "BuscarRegistros"ThenSentenciaSqlBusqueda = "spVistaCuentasContablesXML"End IfEnd FunctionPublic Function DevolverTiposCampos() As StringDevolverTiposCampos = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato ThenDevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)Exit FunctionEnd IfNextEnd IfNextReturn DevolverTiposCamposEnd FunctionPublic Function TipoCampoEspecifico() As StringTipoCampoEspecifico = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato ThenTipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)Exit FunctionEnd IfNextEnd IfNextReturn TipoCampoEspecificoEnd FunctionPublic Function BuscarFormatos()BuscarFormatos = NothingFor vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) ThenBuscarFormatos = vArrayDatosComboBox(vFila).ValoresExit FunctionEnd IfNextReturn BuscarFormatosEnd FunctionPublic Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As IntegerTryDim oVerificarDatos As New ErrorDataIf Parametros Is Nothing ThenoVerificarDatos = VerificarDatos(Parametros)ElseoVerificarDatos = VerificarDatos("CUC_ID","CUC_DESCRIPCION","cls_Id","cuc_IdCargo","cuc_IdAbono","cuc_EsCentroCosto","USU_ID","CUC_FEC_GRAB","CUC_ESTADO")End IfIf oVerificarDatos.NumeroError = 0 ThenvMensajeError = oVerificarDatos.MensajeGeneralReturn 0ElseReturn 1End IfCatch ex As ExceptionvMensajeError = ex.MessageReturn 0End TryEnd FunctionEnd Class