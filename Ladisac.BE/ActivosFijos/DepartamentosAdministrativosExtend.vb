Imports Ladisac.BEPartial Public Class DepartamentosAdministrativosInherits Ladisac.BE.Maestro.Datos.OrmPublic vArrayDatosComboBox() As DatosComboBoxPublic vElementosDatosComboBox As Int16Public vArrayCamposBusqueda() As StringPublic Property CampoId As StringPublic Property DatoPublic vMensajeError As String = ""Public Property Vista As StringPublic ReadOnly FlagCampoPrincipal As Short = 1Public CadenaFiltrado As String = ""Public CampoPrincipal = "DEA_ID"Public CampoPrincipalValor = DEA_IDPrivate Structure sTablaPublic ReadOnly Property NombreLargo As StringGetReturn "Act.DepartamentosAdministrativos"End GetEnd PropertyPublic ReadOnly Property NombreCorto As StringGetReturn "DepartamentosAdministrativos"End GetEnd PropertyPublic ReadOnly Property NombreVista As StringGetReturn "vwDepartamentosAdministrativos"End GetEnd PropertyPublic ReadOnly Property NombreFuncionVista As StringGetReturn "fnVistaDepartamentosAdministrativos"End GetEnd PropertyEnd StructurePrivate Shared Tabla As sTablaPublic ReadOnly Property cTabla As ObjectGetReturn TablaEnd GetEnd PropertyPublic Sub New()MyBase.New()ConfigurarDatosCampos()End SubPrivate Sub ConfigurarDatosCampos()vElementosDatosComboBox = 23ReDim vArrayCamposBusqueda(vElementosDatosComboBox)ReDim vArrayDatosComboBox(vElementosDatosComboBox)vArrayCamposBusqueda(0) = "DEA_ID"vArrayCamposBusqueda(1) = "DEA_DESCRIPCION"vArrayCamposBusqueda(2) = "OFI_ID"vArrayCamposBusqueda(3) = "OFI_DESCRIPCION"vArrayCamposBusqueda(4) = "OFI_ESTADO"vArrayCamposBusqueda(5) = "EDI_ID"vArrayCamposBusqueda(6) = "EDI_DESCRIPCION"vArrayCamposBusqueda(7) = "EDI_ESTADO"vArrayCamposBusqueda(8) = "PVE_ID"vArrayCamposBusqueda(9) = "PVE_DESCRIPCION"vArrayCamposBusqueda(10) = "PVE_ESTADO"vArrayCamposBusqueda(11) = "PAI_ID"vArrayCamposBusqueda(12) = "PAI_DESCRIPCION"vArrayCamposBusqueda(13) = "PAI_ESTADO"vArrayCamposBusqueda(14) = "DEP_ID"vArrayCamposBusqueda(15) = "DEP_DESCRIPCION"vArrayCamposBusqueda(16) = "DEP_ESTADO"vArrayCamposBusqueda(17) = "PRO_ID"vArrayCamposBusqueda(18) = "PRO_DESCRIPCION"vArrayCamposBusqueda(19) = "PRO_ESTADO"vArrayCamposBusqueda(20) = "DIS_ID"vArrayCamposBusqueda(21) = "DIS_DESCRIPCION"vArrayCamposBusqueda(22) = "DIS_ESTADO"vArrayCamposBusqueda(23) = "DEA_ESTADO"vArrayDatosComboBox(0).NombreCampo = "DEA_ID"vArrayDatosComboBox(0).Longitud = 3vArrayDatosComboBox(0).Tipo = "char"vArrayDatosComboBox(0).ParteEntera = 0vArrayDatosComboBox(0).ParteDecimal = 0ReDim vArrayDatosComboBox(0).Valores(0, 0)vArrayDatosComboBox(0).Ancho = 36vArrayDatosComboBox(0).Flag = FalsevArrayDatosComboBox(1).NombreCampo = "DEA_DESCRIPCION"vArrayDatosComboBox(1).Longitud = 45vArrayDatosComboBox(1).Tipo = "varchar"vArrayDatosComboBox(1).ParteEntera = 0vArrayDatosComboBox(1).ParteDecimal = 0ReDim vArrayDatosComboBox(1).Valores(0, 0)vArrayDatosComboBox(1).Ancho = 485vArrayDatosComboBox(1).Flag = FalsevArrayDatosComboBox(2).NombreCampo = "OFI_ID"vArrayDatosComboBox(2).Longitud = 3vArrayDatosComboBox(2).Tipo = "char"vArrayDatosComboBox(2).ParteEntera = 0vArrayDatosComboBox(2).ParteDecimal = 0ReDim vArrayDatosComboBox(2).Valores(0, 0)vArrayDatosComboBox(2).Ancho = 36vArrayDatosComboBox(2).Flag = FalsevArrayDatosComboBox(3).NombreCampo = "OFI_DESCRIPCION"vArrayDatosComboBox(3).Longitud = 45vArrayDatosComboBox(3).Tipo = "varchar"vArrayDatosComboBox(3).ParteEntera = 0vArrayDatosComboBox(3).ParteDecimal = 0ReDim vArrayDatosComboBox(3).Valores(0, 0)vArrayDatosComboBox(3).Ancho = 485vArrayDatosComboBox(3).Flag = FalsevArrayDatosComboBox(4).NombreCampo = "OFI_ESTADO"vArrayDatosComboBox(4).Longitud = 9vArrayDatosComboBox(4).Tipo = "varchar"vArrayDatosComboBox(4).ParteEntera = 0vArrayDatosComboBox(4).ParteDecimal = 0ReDim vArrayDatosComboBox(4).Valores(1, 1)vArrayDatosComboBox(4).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(4).Valores(0, 1) = "0"vArrayDatosComboBox(4).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(4).Valores(1, 1) = "1"vArrayDatosComboBox(4).Ancho = 85vArrayDatosComboBox(4).Flag = TruevArrayDatosComboBox(5).NombreCampo = "EDI_ID"vArrayDatosComboBox(5).Longitud = 3vArrayDatosComboBox(5).Tipo = "char"vArrayDatosComboBox(5).ParteEntera = 0vArrayDatosComboBox(5).ParteDecimal = 0ReDim vArrayDatosComboBox(5).Valores(0, 0)vArrayDatosComboBox(5).Ancho = 36vArrayDatosComboBox(5).Flag = FalsevArrayDatosComboBox(6).NombreCampo = "EDI_DESCRIPCION"vArrayDatosComboBox(6).Longitud = 45vArrayDatosComboBox(6).Tipo = "varchar"vArrayDatosComboBox(6).ParteEntera = 0vArrayDatosComboBox(6).ParteDecimal = 0ReDim vArrayDatosComboBox(6).Valores(0, 0)vArrayDatosComboBox(6).Ancho = 485vArrayDatosComboBox(6).Flag = FalsevArrayDatosComboBox(7).NombreCampo = "EDI_ESTADO"vArrayDatosComboBox(7).Longitud = 9vArrayDatosComboBox(7).Tipo = "varchar"vArrayDatosComboBox(7).ParteEntera = 0vArrayDatosComboBox(7).ParteDecimal = 0ReDim vArrayDatosComboBox(7).Valores(1, 1)vArrayDatosComboBox(7).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(7).Valores(0, 1) = "0"vArrayDatosComboBox(7).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(7).Valores(1, 1) = "1"vArrayDatosComboBox(7).Ancho = 85vArrayDatosComboBox(7).Flag = TruevArrayDatosComboBox(8).NombreCampo = "PVE_ID"vArrayDatosComboBox(8).Longitud = 3vArrayDatosComboBox(8).Tipo = "char"vArrayDatosComboBox(8).ParteEntera = 0vArrayDatosComboBox(8).ParteDecimal = 0ReDim vArrayDatosComboBox(8).Valores(0, 0)vArrayDatosComboBox(8).Ancho = 36vArrayDatosComboBox(8).Flag = FalsevArrayDatosComboBox(9).NombreCampo = "PVE_DESCRIPCION"vArrayDatosComboBox(9).Longitud = 45vArrayDatosComboBox(9).Tipo = "varchar"vArrayDatosComboBox(9).ParteEntera = 0vArrayDatosComboBox(9).ParteDecimal = 0ReDim vArrayDatosComboBox(9).Valores(0, 0)vArrayDatosComboBox(9).Ancho = 485vArrayDatosComboBox(9).Flag = FalsevArrayDatosComboBox(10).NombreCampo = "PVE_ESTADO"vArrayDatosComboBox(10).Longitud = 9vArrayDatosComboBox(10).Tipo = "varchar"vArrayDatosComboBox(10).ParteEntera = 0vArrayDatosComboBox(10).ParteDecimal = 0ReDim vArrayDatosComboBox(10).Valores(1, 1)vArrayDatosComboBox(10).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(10).Valores(0, 1) = "0"vArrayDatosComboBox(10).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(10).Valores(1, 1) = "1"vArrayDatosComboBox(10).Ancho = 85vArrayDatosComboBox(10).Flag = TruevArrayDatosComboBox(11).NombreCampo = "PAI_ID"vArrayDatosComboBox(11).Longitud = 3vArrayDatosComboBox(11).Tipo = "char"vArrayDatosComboBox(11).ParteEntera = 0vArrayDatosComboBox(11).ParteDecimal = 0ReDim vArrayDatosComboBox(11).Valores(0, 0)vArrayDatosComboBox(11).Ancho = 36vArrayDatosComboBox(11).Flag = FalsevArrayDatosComboBox(12).NombreCampo = "PAI_DESCRIPCION"vArrayDatosComboBox(12).Longitud = 45vArrayDatosComboBox(12).Tipo = "varchar"vArrayDatosComboBox(12).ParteEntera = 0vArrayDatosComboBox(12).ParteDecimal = 0ReDim vArrayDatosComboBox(12).Valores(0, 0)vArrayDatosComboBox(12).Ancho = 485vArrayDatosComboBox(12).Flag = FalsevArrayDatosComboBox(13).NombreCampo = "PAI_ESTADO"vArrayDatosComboBox(13).Longitud = 9vArrayDatosComboBox(13).Tipo = "varchar"vArrayDatosComboBox(13).ParteEntera = 0vArrayDatosComboBox(13).ParteDecimal = 0ReDim vArrayDatosComboBox(13).Valores(1, 1)vArrayDatosComboBox(13).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(13).Valores(0, 1) = "0"vArrayDatosComboBox(13).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(13).Valores(1, 1) = "1"vArrayDatosComboBox(13).Ancho = 85vArrayDatosComboBox(13).Flag = TruevArrayDatosComboBox(14).NombreCampo = "DEP_ID"vArrayDatosComboBox(14).Longitud = 3vArrayDatosComboBox(14).Tipo = "char"vArrayDatosComboBox(14).ParteEntera = 0vArrayDatosComboBox(14).ParteDecimal = 0ReDim vArrayDatosComboBox(14).Valores(0, 0)vArrayDatosComboBox(14).Ancho = 36vArrayDatosComboBox(14).Flag = FalsevArrayDatosComboBox(15).NombreCampo = "DEP_DESCRIPCION"vArrayDatosComboBox(15).Longitud = 45vArrayDatosComboBox(15).Tipo = "varchar"vArrayDatosComboBox(15).ParteEntera = 0vArrayDatosComboBox(15).ParteDecimal = 0ReDim vArrayDatosComboBox(15).Valores(0, 0)vArrayDatosComboBox(15).Ancho = 485vArrayDatosComboBox(15).Flag = FalsevArrayDatosComboBox(16).NombreCampo = "DEP_ESTADO"vArrayDatosComboBox(16).Longitud = 9vArrayDatosComboBox(16).Tipo = "varchar"vArrayDatosComboBox(16).ParteEntera = 0vArrayDatosComboBox(16).ParteDecimal = 0ReDim vArrayDatosComboBox(16).Valores(1, 1)vArrayDatosComboBox(16).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(16).Valores(0, 1) = "0"vArrayDatosComboBox(16).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(16).Valores(1, 1) = "1"vArrayDatosComboBox(16).Ancho = 85vArrayDatosComboBox(16).Flag = TruevArrayDatosComboBox(17).NombreCampo = "PRO_ID"vArrayDatosComboBox(17).Longitud = 3vArrayDatosComboBox(17).Tipo = "char"vArrayDatosComboBox(17).ParteEntera = 0vArrayDatosComboBox(17).ParteDecimal = 0ReDim vArrayDatosComboBox(17).Valores(0, 0)vArrayDatosComboBox(17).Ancho = 36vArrayDatosComboBox(17).Flag = FalsevArrayDatosComboBox(18).NombreCampo = "PRO_DESCRIPCION"vArrayDatosComboBox(18).Longitud = 45vArrayDatosComboBox(18).Tipo = "varchar"vArrayDatosComboBox(18).ParteEntera = 0vArrayDatosComboBox(18).ParteDecimal = 0ReDim vArrayDatosComboBox(18).Valores(0, 0)vArrayDatosComboBox(18).Ancho = 485vArrayDatosComboBox(18).Flag = FalsevArrayDatosComboBox(19).NombreCampo = "PRO_ESTADO"vArrayDatosComboBox(19).Longitud = 9vArrayDatosComboBox(19).Tipo = "varchar"vArrayDatosComboBox(19).ParteEntera = 0vArrayDatosComboBox(19).ParteDecimal = 0ReDim vArrayDatosComboBox(19).Valores(1, 1)vArrayDatosComboBox(19).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(19).Valores(0, 1) = "0"vArrayDatosComboBox(19).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(19).Valores(1, 1) = "1"vArrayDatosComboBox(19).Ancho = 85vArrayDatosComboBox(19).Flag = TruevArrayDatosComboBox(20).NombreCampo = "DIS_ID"vArrayDatosComboBox(20).Longitud = 3vArrayDatosComboBox(20).Tipo = "char"vArrayDatosComboBox(20).ParteEntera = 0vArrayDatosComboBox(20).ParteDecimal = 0ReDim vArrayDatosComboBox(20).Valores(0, 0)vArrayDatosComboBox(20).Ancho = 36vArrayDatosComboBox(20).Flag = FalsevArrayDatosComboBox(21).NombreCampo = "DIS_DESCRIPCION"vArrayDatosComboBox(21).Longitud = 45vArrayDatosComboBox(21).Tipo = "varchar"vArrayDatosComboBox(21).ParteEntera = 0vArrayDatosComboBox(21).ParteDecimal = 0ReDim vArrayDatosComboBox(21).Valores(0, 0)vArrayDatosComboBox(21).Ancho = 485vArrayDatosComboBox(21).Flag = FalsevArrayDatosComboBox(22).NombreCampo = "DIS_ESTADO"vArrayDatosComboBox(22).Longitud = 9vArrayDatosComboBox(22).Tipo = "varchar"vArrayDatosComboBox(22).ParteEntera = 0vArrayDatosComboBox(22).ParteDecimal = 0ReDim vArrayDatosComboBox(22).Valores(1, 1)vArrayDatosComboBox(22).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(22).Valores(0, 1) = "0"vArrayDatosComboBox(22).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(22).Valores(1, 1) = "1"vArrayDatosComboBox(22).Ancho = 85vArrayDatosComboBox(22).Flag = TruevArrayDatosComboBox(23).NombreCampo = "DEA_ESTADO"vArrayDatosComboBox(23).Longitud = 0vArrayDatosComboBox(23).Tipo = "bit"vArrayDatosComboBox(23).ParteEntera = 0vArrayDatosComboBox(23).ParteDecimal = 0ReDim vArrayDatosComboBox(23).Valores(1, 1)vArrayDatosComboBox(23).Valores(0, 0) = "NO ACTIVO"vArrayDatosComboBox(23).Valores(0, 1) = "0"vArrayDatosComboBox(23).Valores(1, 0) = "ACTIVO"vArrayDatosComboBox(23).Valores(1, 1) = "1"vArrayDatosComboBox(23).Ancho = 85vArrayDatosComboBox(23).Flag = TrueEnd SubPublic Function VerificarDatos(ByVal ParamArray vCampos() As Object) As ErrorDataVerificarDatos = New ErrorDataVerificarDatos.NumeroError = 1For elemento = 0 To vCampos.Count - 1VerificarDatos.MensajeError = ""Select Case vCampos(elemento)Case "DEA_ID"If Len(DEA_ID.Trim) = 3 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo3VerificarDatos.Objeto = vCampos(elemento)End IfCase "DEA_DESCRIPCION"If Len(DEA_DESCRIPCION.Trim) > 0 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mDescripcionVerificarDatos.Objeto = vCampos(elemento)End IfCase "OFI_ID"If Len(OFI_ID.Trim) = 3 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mCodigo3VerificarDatos.Objeto = vCampos(elemento)End IfCase "USU_ID"If Len(USU_ID.Trim) >= 5 ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mUsuarioVerificarDatos.Objeto = vCampos(elemento)End IfCase "DEA_FEC_GRAB"If DEA_FEC_GRAB.GetType = GetType(DateTime) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mFechaVerificarDatos.Objeto = vCampos(elemento)End IfCase "DEA_ESTADO"If DEA_ESTADO.GetType = GetType(Boolean) ThenElseVerificarDatos.NumeroError = 0VerificarDatos.MensajeError = mEstadoVerificarDatos.Objeto = vCampos(elemento)End IfEnd SelectIf VerificarDatos.NumeroError = 0 Then If VerificarDatos.MensajeError <> "" Then VerificarDatos.MensajeGeneral += VerificarDatos.MensajeError & Chr(13)End IfNextReturn VerificarDatosEnd FunctionPublic Function SentenciaSqlBusqueda() As StringSentenciaSqlBusqueda=""If Vista = "BuscarRegistros"ThenSentenciaSqlBusqueda = "spVistaDepartamentosAdministrativosXML"End IfEnd FunctionPublic Function DevolverTiposCampos() As StringDevolverTiposCampos = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 0) = Dato ThenDevolverTiposCampos = vArrayDatosComboBox(vFila).Valores(vSubFila, 1)Exit FunctionEnd IfNextEnd IfNextReturn DevolverTiposCamposEnd FunctionPublic Function TipoCampoEspecifico() As StringTipoCampoEspecifico = ""For vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(vArrayDatosComboBox(vFila).NombreCampo) = UCase(CampoId) ThenFor vSubFila = 0 To vArrayDatosComboBox(vFila).Valores.GetUpperBound(0)If vArrayDatosComboBox(vFila).Valores(vSubFila, 1) = Dato ThenTipoCampoEspecifico = vArrayDatosComboBox(vFila).Valores(vSubFila, 0)Exit FunctionEnd IfNextEnd IfNextReturn TipoCampoEspecificoEnd FunctionPublic Function BuscarFormatos()BuscarFormatos = NothingFor vFila = 0 To vArrayDatosComboBox.GetUpperBound(0)If UCase(Strings.Trim(vArrayDatosComboBox(vFila).NombreCampo)) = UCase(Strings.Trim(CampoId)) ThenBuscarFormatos = vArrayDatosComboBox(vFila).ValoresExit FunctionEnd IfNextReturn BuscarFormatosEnd FunctionPublic Function ProcesarVerificarDatos(ByVal ParamArray Parametros() As String) As IntegerTryDim oVerificarDatos As New ErrorDataIf Parametros Is Nothing ThenoVerificarDatos = VerificarDatos(Parametros)ElseoVerificarDatos = VerificarDatos("DEA_ID","DEA_DESCRIPCION","OFI_ID","USU_ID","DEA_FEC_GRAB","DEA_ESTADO")End IfIf oVerificarDatos.NumeroError = 0 ThenvMensajeError = oVerificarDatos.MensajeGeneralReturn 0ElseReturn 1End IfCatch ex As ExceptionvMensajeError = ex.MessageReturn 0End TryEnd FunctionEnd Class