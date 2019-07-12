﻿Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms

Namespace Ladisac.CuentasCorrientes.Views
    Public Class frmCopiarListaPreciosArticulos
#Region "Primaria"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        <Dependency()> _
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        Private eConfigurarDataGridObjeto As New MisProcedimientos.ConfigurarDataGrid
        Private eRegistrosEliminar(1) As ElementosEliminar
        Private vBuscarDetalle As Boolean = True
        Private vMensajeErrorOrm As String = ""

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pRespuestaExtraerDetalle As Int16 = 0
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        Private Shared vrO As Boolean = True
        Private Shared vrM As Boolean = True
        Private pLongitudId As Integer = 0
        Private pCaracterId As String = Nothing
        Private pCodigoId As String = ""

        Private pNuevo As Boolean = True
        Private pEditar As Boolean = True
        Private pCancelarEditar As Boolean = True
        Private pGrabar As Boolean = True
        Private pGrabarNuevo As Boolean = True
        Private pEliminar As Boolean = True
        Private pDeshacer As Boolean = True
        Private pAgregar As Boolean = True
        Private pQuitar As Boolean = True
        Private pBuscar As Boolean = True
        Private pInicio As Boolean = True
        Private pAnterior As Boolean = True
        Private pSiguiente As Boolean = True
        Private pFinal As Boolean = True
        Private pReportes As Boolean = True
        Private pSalida As Boolean = True

#Region "CheckBox"
        Public Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure

        Private Sub ConfigurarCheck_Refrescar(ByRef vObjeto As chk)
            If vObjeto.pFormatearTexto Then
                vObjeto.pSimple.vista = "TipoCampoEspecifico"
                vObjeto.pSimple.CampoId = vObjeto.pNombreCampo

                vObjeto.pSimple.Dato = 0
                vObjeto.vEstado0 = vObjeto.pSimple.TipoCampoEspecifico()

                vObjeto.pSimple.Dato = 1
                vObjeto.vEstado1 = vObjeto.pSimple.TipoCampoEspecifico()

                vObjeto.pSimple.Dato = Nothing
                vObjeto.vEstadoX = vObjeto.pSimple.TipoCampoEspecifico()

                InicializarTexto(vObjeto)
            End If
        End Sub
#End Region
#Region "ComboBox"
        Private Structure cbo
            Public Property pNombreCampo As String
        End Structure
#End Region
#Region "TextBox"
        Private Structure txt
            Public Property pTexto1 As String
            Public Property pTexto2 As String
            Public Property pSoloNumerosDecimales As Boolean
            Public Property pSoloNumeros As Boolean
            Public Property pNegativos As Boolean
            Public Property pParteEntera As Int16
            Public Property pParteDecimal As Int16
            Public Property pMinusculaMayuscula As Boolean
            Public Property pBusqueda As Boolean
            Public Property pCadenaFiltrado As String

            Public Property pOOrm As Object
            Public Property pFormularioConsulta As Boolean

            Public Property pComportamiento As Int16
            Public Property pOrdenBusqueda As Int16
        End Structure

        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                       ByVal vBusquedaDirecta As Boolean, _
                                       ByVal vtxt As txt)
            Try
                Dim vOrdenBusqueda As Int16
                vOrdenBusqueda = vtxt.pOrdenBusqueda
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                If vBusquedaDirecta Then
                    frm.TipoEdicion = 2
                    If pComportamiento = -1 Then
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = vDatoBusqueda
                    End If
                    frm.DatoBusqueda = vDatoBusqueda
                    vOrdenBusqueda = OrdenBusquedaDirecta(vtxt.pComportamiento, vtxt.pOrdenBusqueda)
                Else
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = ""
                End If

                frm.oOrm = vtxt.pOOrm
                frm.Comportamiento = vtxt.pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = vOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - MetodoBusquedaDato")
            End Try
        End Sub
        Private Sub TeclaF1(ByRef otxt As txt, ByRef txt As TextBox)
            If otxt.pBusqueda Then
                otxt.pTexto2 = txt.Text
                ValidarDatos(otxt, txt)
                MetodoBusquedaDato("", False, otxt)
                otxt.pTexto1 = txt.Text
                otxt.pTexto2 = txt.Text
                'TeclaF1SubLlamadas(txt.Name)
            End If
        End Sub
#End Region

        Public ReadOnly Property Loaded() As Boolean
            Get
                Return pLoaded
            End Get
        End Property
        Public Property RegistroNuevo() As Boolean
            Get
                Return pRegistroNuevo
            End Get
            Set(ByVal value As Boolean)
                pRegistroNuevo = value
            End Set
        End Property
        Public Property ColeccionDatos() As Collection
            Get
                Return pColeccionDatos
            End Get
            Set(ByVal value As Collection)
                pColeccionDatos = value
            End Set
        End Property
        Public Property Comportamiento() As Int32
            Get
                Return pComportamiento
            End Get
            Set(ByVal value As Int32)
                pComportamiento = value
            End Set
        End Property
        Public Property OrdenBusqueda() As Int32
            Get
                Return pOrdenBusqueda
            End Get
            Set(ByVal value As Int32)
                pOrdenBusqueda = value
            End Set
        End Property
        Public Property DatoBusquedaConsulta() As String
            Get
                Return pDatoBusquedaConsulta
            End Get
            Set(ByVal value As String)
                pDatoBusquedaConsulta = value
            End Set
        End Property
        Public Property FlagNuevo() As Boolean
            Get
                Return pFlagNuevo
            End Get
            Set(ByVal value As Boolean)
                pFlagNuevo = value
            End Set
        End Property

        Private Structure RespuestaValidar
            Public Property rM As Boolean
                Set(ByVal value As Boolean)
                    vrM = value
                    If value = True Then vrO = rO
                    If value = False Then vrO = False
                End Set
                Get
                    Return vrM
                End Get
            End Property
            Public Property rO As Boolean
                Set(ByVal value As Boolean)
                    vrO = value
                End Set
                Get
                    Return vrO
                End Get
            End Property
        End Structure
        Public Property LongitudId() As Integer
            Get
                Return pLongitudId
            End Get
            Set(ByVal value As Integer)
                pLongitudId = value
            End Set
        End Property
        Public Property CaracterId() As String
            Get
                Return pCaracterId
            End Get
            Set(ByVal value As String)
                pCaracterId = value
            End Set
        End Property
        Public Property CodigoId() As String
            Get
                Return pCodigoId
            End Get
            Set(ByVal value As String)
                pCodigoId = value
            End Set
        End Property

        Public Property Nuevo() As Boolean
            Set(ByVal value As Boolean)
                pNuevo = value
            End Set
            Get
                Return pNuevo
            End Get
        End Property
        Public Property Editar() As Boolean
            Set(ByVal value As Boolean)
                pEditar = value
            End Set
            Get
                Return pEditar
            End Get
        End Property
        Public Property CancelarEditar() As Boolean
            Set(ByVal value As Boolean)
                pCancelarEditar = value
            End Set
            Get
                Return pCancelarEditar
            End Get
        End Property
        Public Property Grabar() As Boolean
            Set(ByVal value As Boolean)
                pGrabar = value
            End Set
            Get
                Return pGrabar
            End Get
        End Property
        Public Property GrabarNuevo() As Boolean
            Set(ByVal value As Boolean)
                pGrabarNuevo = value
            End Set
            Get
                Return pGrabarNuevo
            End Get
        End Property
        Public Property Eliminar() As Boolean
            Set(ByVal value As Boolean)
                pEliminar = value
            End Set
            Get
                Return pEliminar
            End Get
        End Property
        Public Property Deshacer() As Boolean
            Set(ByVal value As Boolean)
                pDeshacer = value
            End Set
            Get
                Return pDeshacer
            End Get
        End Property
        Public Property Agregar() As Boolean
            Set(ByVal value As Boolean)
                pAgregar = value
            End Set
            Get
                Return pAgregar
            End Get
        End Property
        Public Property Quitar() As Boolean
            Set(ByVal value As Boolean)
                pQuitar = value
            End Set
            Get
                Return pQuitar
            End Get
        End Property
        Public Property Buscar() As Boolean
            Set(ByVal value As Boolean)
                pBuscar = value
            End Set
            Get
                Return pBuscar
            End Get
        End Property
        Public Property Inicio() As Boolean
            Set(ByVal value As Boolean)
                pInicio = value
            End Set
            Get
                Return pInicio
            End Get
        End Property
        Public Property Anterior() As Boolean
            Set(ByVal value As Boolean)
                pAnterior = value
            End Set
            Get
                Return pAnterior
            End Get
        End Property
        Public Property Siguiente() As Boolean
            Set(ByVal value As Boolean)
                pSiguiente = value
            End Set
            Get
                Return pSiguiente
            End Get
        End Property
        Public Property Final() As Boolean
            Set(ByVal value As Boolean)
                pFinal = value
            End Set
            Get
                Return pFinal
            End Get
        End Property
        Public Property Reportes() As Boolean
            Set(ByVal value As Boolean)
                pReportes = value
            End Set
            Get
                Return pReportes
            End Get
        End Property
        Public Property Salida() As Boolean
            Set(ByVal value As Boolean)
                pSalida = value
            End Set
            Get
                Return pSalida
            End Get
        End Property

        Public Overrides Sub LlamarMetodo(ByVal NombreMetodo As String)
            Select Case NombreMetodo
                Case "NuevoRegistro"
                    NuevoRegistro()
                Case "EditarRegistro"
                    EditarRegistro()
                Case "CancelarEdicion"
                    CancelarEdicion(False)
                Case "PrepararGuardar"
                    PrepararGuardar(False)
                Case "PrepararGuardarNuevo"
                    PrepararGuardar(True)
                Case "PrepararEliminar"
                    PrepararEliminar()
                Case "DeshacerCambios"
                    Deshacercambios()
                Case "AgregarFilaGrid"
                    AgregarFilaGrid()
                Case "QuitarFilaGrid"
                    QuitarFilaGrid()
                Case "BuscarUnRegistro"
                    BuscarUnRegistro()
                Case "PrimerRegistro"
                    PosicionGrid(NombreMetodo)
                Case "RegistroAnterior"
                    PosicionGrid(NombreMetodo)
                Case "RegistroSiguiente"
                    PosicionGrid(NombreMetodo)
                Case "UltimoRegistro"
                    PosicionGrid(NombreMetodo)
                Case "Salir"
                    Salir()
            End Select
        End Sub

        Public Sub NuevoRegistro()
            pRegistroNuevo = True
            LimpiarDatos()
            HabilitarNuevo()
            ValoresDefaultNuevo()
            BotonesEdicion("Crear registro")
            If Not FlagNuevo Then
                CrearCodigoId()
            Else
                HabilitarEscrituraNuevo()
            End If
            ConfigurarGrid("ElementoItem")
        End Sub
        Public Sub EditarRegistro()
            If Not pFlagNuevo Then If Trim(pCodigoId) = "" Then Return
            BotonesEdicion("Editar registro")
        End Sub
        Public Sub CancelarEdicion(ByVal vDeshacerCambios As Boolean)
            Dim vRegistroNuevo As Boolean = False
            vRegistroNuevo = pRegistroNuevo
            If Not vDeshacerCambios Then
                If Not vRegistroNuevo Then
                    If RevisarDatos(False) Then Return
                End If
            End If
            LimpiarDatos()
            BusquedaDatos("CancelarEdicion")
            If vDeshacerCambios Then
                If vRegistroNuevo Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    BotonesEdicion("Editar registro")
                End If
            Else
                BotonesEdicion("Seleccionar registro")
            End If
        End Sub
        Public Sub PrepararGuardar(ByVal vNuevo As Boolean)
            btnImagen.Focus()
            Dim bRes As Boolean = False
            If Not pRegistroNuevo Then
                If Not RevisarDatos(True) Then
                    If vNuevo Then
                        NuevoRegistro()
                    End If
                    Return
                End If
            End If
            If pRegistroNuevo Then
                bRes = Ingresar()
            Else
                bRes = Modificar()
            End If
            If bRes Then InicializarDatos()
            If (bRes) Then
                BotonesEdicion("Seleccionar registro")
                If vNuevo Then
                    NuevoRegistro()
                End If
            End If
        End Sub
        Public Sub PrepararEliminar()
            Dim bRes As Boolean = False
            Dim oMsgBoxResult As New MsgBoxResult()
            Try
                oMsgBoxResult = MsgBox("Esta seguro de eliminar el registro", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                If (oMsgBoxResult = MsgBoxResult.Yes) Then
                    bRes = EliminarRegistro()
                End If
                If (bRes) Then
                    LimpiarDatos()
                    BusquedaDatos("PrepararEliminar")
                    BotonesEdicion("Seleccionar registro")
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - PrepararEliminar")
            End Try
        End Sub
        Public Sub Deshacercambios()
            CancelarEdicion(True)
        End Sub
        Public Sub AgregarFilaGrid()
            AdicionarFilasGrid()
        End Sub
        Public Sub QuitarFilaGrid()
            EliminarFilasGrid()
        End Sub
        Public Sub BuscarUnRegistro()
            BusquedaDatos("BuscarUnRegistro")
        End Sub
        Public Sub PosicionGrid(ByVal Metodo As String)
            If pCodigoId Is Nothing Or Trim(pCodigoId) = "" Then
                MsgBox("No esta disponible el desplazamiento" & Chr(13) & Chr(13) & "Ubiquese en un registro", MsgBoxStyle.Information, Me.Text)
                Exit Sub
            End If
            If Me.ActiveControl.GetType <> GetType(DataGridView) Then
                NavegarFormulario(Metodo)
            Else
                NavegarGrid(Metodo)
            End If
        End Sub
        Public Sub Salir()
            Me.Close()
        End Sub
        Public Overrides Sub PosicionBarra(ByVal Metodo As String)
            Select Case Metodo
                Case "^"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Top
                    lblTitle.Dock = DockStyle.None
                Case "V"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Bottom
                Case "<"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Left
                Case ">"
                    tsBarra.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
                    tsBarra.Dock = System.Windows.Forms.DockStyle.Right
            End Select
        End Sub

        ' NuevoRegistro
        Private Sub BotonesEdicion(ByVal vProceso As String)
            Select Case vProceso
                Case "Crear registro"
                    Nuevo = False
                    tsbNuevo.Enabled = False
                    Editar = False
                    CancelarEditar = True
                    Grabar = True
                    GrabarNuevo = True
                    Eliminar = False
                    Deshacer = True
                    Agregar = True
                    Quitar = True
                    Buscar = False
                    Inicio = False
                    Anterior = False
                    Siguiente = False
                    Final = False
                    Reportes = False
                    Salida = False
                    pnCuerpo.Enabled = True
                Case "Editar registro"
                    Nuevo = False
                    Editar = False
                    CancelarEditar = True
                    Grabar = True
                    GrabarNuevo = True
                    Eliminar = True
                    Deshacer = True
                    Agregar = True
                    Quitar = True
                    Buscar = False
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = False
                    Salida = False
                    pnCuerpo.Enabled = True
                Case "Seleccionar registro"
                    Nuevo = False 'True
                    Editar = False 'True
                    CancelarEditar = False
                    Grabar = False
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
                    Agregar = False
                    Quitar = False
                    Buscar = True
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = True
                    Salida = True
                    pnCuerpo.Enabled = False
                Case ("Aceptar registro")
                    Nuevo = False
                    Editar = True
                    CancelarEditar = True
                    Grabar = False
                    GrabarNuevo = False
                    Eliminar = False
                    Deshacer = False
                    Agregar = False
                    Quitar = False
                    Buscar = False
                    Inicio = True
                    Anterior = True
                    Siguiente = True
                    Final = True
                    Reportes = False
                    Salida = True
            End Select
            FormatearBotonesEdicion()
        End Sub
        Private Sub FormatearBotonesEdicion()
            tsbNuevo.Enabled = Nuevo
            tsbEditar.Enabled = Editar
            tsbCancelarEditar.Enabled = CancelarEditar
            tsbGrabar.Enabled = Grabar
            TsbGrabarNuevo.Enabled = GrabarNuevo
            tsbEliminar.Enabled = Eliminar
            tsbDeshacer.Enabled = Deshacer
            tsbAgregar.Enabled = Agregar
            tsbQuitar.Enabled = Quitar
            tsbBuscar.Enabled = Buscar
            tsbInicio.Enabled = Inicio
            tsbAnterior.Enabled = Anterior
            tsbSiguiente.Enabled = Siguiente
            tsbFinal.Enabled = Final
            tsbReportes.Enabled = Reportes
            tsbSalir.Enabled = Salida
        End Sub
        Private Sub ProcesoCrearCodigoId(ByVal vVista As String, ByRef oTexto As TextBox)
            Select Case vVista
                Case "CrearCodigoSimple"
                    'Dim resp = Me.IBCBusqueda.CrearCodigoSimple(Compuesto.CampoPrincipal, _
                    '                                            Compuesto.cTabla.NombreLargo)
                    'oTexto.Text = resp
                    'For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                    '    oTexto.Text = CaracterId & oTexto.Text
                    'Next
                    'Compuesto.LPR_ID = Me.IBCBusqueda.NuevoLpr_IdListaPreciosArticulos()
                    oTexto.Text = Me.IBCBusqueda.NuevoLpr_IdListaPreciosArticulos()
                    oTexto.ReadOnly = True
            End Select
        End Sub

        ' CancelarEdicion
        Private Function RevisarDatos(ByVal vBoolean As Boolean) As Boolean
            Return RevisarDatos(pColeccionDatos, vBoolean)
        End Function
        Private Function RevisarDatos(ByVal vColeccionDatos As Collection, _
                              ByVal vRespuestaGrabar As Boolean) As Boolean
            If RevisarDatosForm(vColeccionDatos, True) Then
                If vRespuestaGrabar Then
                    RevisarDatos = True
                Else
                    Dim oMsgBoxResult As New MsgBoxResult()
                    oMsgBoxResult = MsgBox("Registro modificado... ¡Sin Grabar!." & Chr(13) & Chr(13) & "¿Desea continuar?", MsgBoxStyle.Exclamation + MsgBoxStyle.OkCancel, Me.Text & " - Se perderan los datos.")
                    If (oMsgBoxResult = MsgBoxResult.Cancel) Then
                        RevisarDatos = True
                    Else
                        RevisarDatos = False
                    End If
                End If
            Else
                RevisarDatos = False
            End If
            Return RevisarDatos
        End Function
        Private Function RevisarDatosForm(ByVal vColeccion As Collection, _
                                          ByVal vProceso As Boolean) As Object
            Dim vControl As System.Windows.Forms.Control
            Dim vDatosControl As New Collection
            If vColeccion Is Nothing Then
                If vProceso Then
                    Return True
                End If
            End If
            For Each vControl In pnCuerpo.Controls
                If TypeOf vControl Is System.Windows.Forms.TextBox Or _
                   TypeOf vControl Is System.Windows.Forms.ComboBox Or _
                   TypeOf vControl Is System.Windows.Forms.CheckBox Then
                    If TypeOf vControl Is System.Windows.Forms.CheckBox Then
                        Dim vObjeto As Object
                        vObjeto = vControl
                        If vProceso Then
                            If vObjeto.checked.ToString <> vColeccion(vControl.Name.ToString).ToString Then
                                Return True
                            End If
                        Else
                            vDatosControl.Add(vObjeto.checked.ToString, vControl.Name)
                        End If
                    Else
                        If vProceso Then
                            If vControl.Text <> vColeccion(vControl.Name.ToString).ToString Then
                                Return True
                            End If
                        Else
                            vDatosControl.Add(vControl.Text, vControl.Name)
                        End If
                    End If
                End If
                If vControl.GetType = GetType(System.Windows.Forms.PictureBox) Then
                    Dim vObjeto As Object
                    If vProceso Then
                        vObjeto = vControl
                        If vObjeto.tamanio <> vColeccion(vControl.Name.ToString).ToString Then
                            Return True
                        End If
                    Else
                        vObjeto = vControl
                        vDatosControl.Add(vObjeto.tamanio, vObjeto.Name)
                    End If
                End If
                If vControl.GetType = GetType(System.Windows.Forms.DataGridView) Then
                    If vControl.Name = "dgvDetalle" Then
                        If vProceso Then
                            Dim vObjetoOriginal As Object
                            Dim vObjetoCopia As Object
                            vObjetoOriginal = vControl
                            vObjetoCopia = vColeccion(vControl.Name.ToString)
                            If vObjetoOriginal.RowCount <> vObjetoCopia.RowCount Then Return True
                            With vObjetoOriginal
                                For fila As Integer = 0 To .RowCount - 1
                                    For col As Integer = 0 To .Columns.Count - 1
                                        If .item(col, fila).value <> vObjetoCopia.item(col, fila).value Then
                                            Return True
                                        End If
                                    Next
                                Next
                            End With
                        Else
                            Dim vDataGridCopia As New System.Windows.Forms.DataGridView
                            Dim vDataGridOriginal As New System.Windows.Forms.DataGridView
                            vDataGridOriginal = vControl
                            vDataGridCopia.ColumnCount = vDataGridOriginal.ColumnCount
                            vDataGridCopia.RowCount = vDataGridOriginal.RowCount
                            With vDataGridOriginal
                                For fila As Integer = 0 To .RowCount - 1
                                    For col As Integer = 0 To .Columns.Count - 1
                                        vDataGridCopia.Item(col, fila).Value = vDataGridOriginal.Item(col, fila).Value
                                    Next
                                Next
                            End With
                            vDatosControl.Add(vDataGridCopia, vControl.Name)
                        End If
                    End If
                End If
            Next
            If vProceso Then
                Return False
            Else
                Return vDatosControl
            End If
        End Function
        Private Sub BusquedaDatos(ByVal vProceso As String)
            Try
                OrmBusquedaDatos(vProceso)
                Select Case vProceso
                    Case "CancelarEdicion"
                        DatoBusquedaConsulta = CodigoId
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2 '
                        If pComportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "PrepararEliminar"
                        Compuesto.CampoPrincipalValor = pCodigoId
                        Dim resp = Me.IBCBusqueda.RegistroAnterior(Compuesto.CampoPrincipal, _
                                                                   Compuesto.CampoPrincipalValor, _
                                                                   Compuesto.cTabla.NombreLargo)
                        DatoBusquedaConsulta = resp

                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If pComportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = pOrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "BuscarUnRegistro"
                        DatoBusquedaConsulta = ""
                        Compuesto.CadenaFiltrado = " AND PER_ID in (Select PER_ID " & _
                                                   " from vwRolPersonaTipoPersona " & _
                                                   " where PER_CLIENTE='SI' " & _
                                                   " and TPE_CLIENTE='SI' " & _
                                                   " and TPE_DESCRIPCION in('" & cboTipoCliente.Text & "') " & _
                                                   " and RTP_ESTADO='ACTIVO')"
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Compuesto
                        frm.Comportamiento = pComportamiento
                        frm.NombreFormulario = Me
                        'frm.OrdenBusqueda = pOrdenBusqueda
                        frm.OrdenBusqueda = 4
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "Load"
                        If Comportamiento = -1 Then
                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If pComportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Compuesto
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        Else
                            OrmBusquedaDatos(vProceso)
                            Dim resp = Me.IBCBusqueda.PrimerRegistro(Compuesto.CampoPrincipal, _
                                                                     Compuesto.cTabla.NombreLargo)
                            DatoBusquedaConsulta = resp

                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If pComportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Compuesto
                            frm.Comportamiento = pComportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = pOrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        End If
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - BusquedaDatos")
            End Try
        End Sub

        ' PrepararGuardar
        Private Function Ingresar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Ingresar = False
            DatosCabecera()

            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (InsertarDatos()) Then
                        Scope.Complete()
                        Ingresar = True
                        ConfigurarDatosGrabados()
                        vMensajeMostrar = 0
                        'MsgBox("Registro ingresado", MsgBoxStyle.Information, Me.Text)
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            vMensajeMostrar = 1
                            'Return Ingresar
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                            'MsgBox("No se pudo ingresar verifique sus datos" & Chr(13) & Chr(13) & Compuesto.vMensajeError, MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                End Using
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "ingresado") = 1 Then Return Ingresar
            InicializarOrm()
            Return Ingresar
        End Function
        Private Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            'Compuesto.MarkAsAdded()
            'vRespuestaLocal = Me.IBCListaPreciosArticulos.MantenimientoListaPreciosArticulos(Compuesto)
            vRespuestaLocal = Me.IBCListaPreciosArticulos.spInsertarRegistro(Compuesto.LPR_ID, Compuesto.LPR_DESCRIPCION, Compuesto.LPR_PRINCIPAL, Compuesto.PER_ID, Compuesto.MON_ID, Compuesto.USU_ID, Compuesto.LPR_FEC_GRAB, Compuesto.LPR_ESTADO, Compuesto.LPR_CONTROL, Compuesto.LPR_ID_ADJ)
            pRespuestaExtraerDetalle = ExtraerDetalle()
            InsertarDatos = (vRespuestaLocal > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Private Function Modificar() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            pRespuestaExtraerDetalle = 0
            Modificar = False
            FlagModificar = True
            DatosCabecera()

            If (Validar("Cabecera")) Then
                Using Scope As New System.Transactions.TransactionScope()
                    If (ActualizarDatos()) Then
                        Scope.Complete()
                        Modificar = True
                        ConfigurarDatosGrabados()
                        vMensajeMostrar = 0
                        'MsgBox("Registro modificado", MsgBoxStyle.Information, Me.Text)
                    Else
                        If pRespuestaExtraerDetalle = -1 Then
                            Scope.Dispose()
                            vMensajeMostrar = 1
                            'Return Modificar
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                            'MsgBox("No se pudo modificar verifique sus datos :" & Chr(13) & Chr(13) & Compuesto.vMensajeError _
                            '                                                    & Chr(13) & Chr(13) & CompuestoObjeto1.vMensajeError, MsgBoxStyle.Information, Me.Text)
                        End If
                    End If
                End Using
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
            If MensajeOperaciones(vMensajeMostrar, "modificado") = 1 Then Return Ingresar()
            InicializarOrm()
            FlagModificar = False
            Return Modificar
        End Function
        Private Function ActualizarDatos() As Boolean
            pRespuestaExtraerDetalle = ExtraerDetalle()
            'Compuesto.MarkAsModified()
            'ActualizarDatos = (Me.IBCListaPreciosArticulos.MantenimientoListaPreciosArticulos(Compuesto) > 0 And pRespuestaExtraerDetalle = 1)
            ActualizarDatos = (Me.IBCListaPreciosArticulos.spActualizarRegistro(Compuesto.LPR_ID, Compuesto.LPR_DESCRIPCION, Compuesto.LPR_PRINCIPAL, Compuesto.PER_ID, Compuesto.MON_ID, Compuesto.USU_ID, Compuesto.LPR_FEC_GRAB, Compuesto.LPR_ESTADO, Compuesto.LPR_CONTROL, Compuesto.LPR_ID_ADJ) > 0 And pRespuestaExtraerDetalle = 1)
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
        End Sub
        Private Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkLPR_ESTADO"
                    Compuesto.CampoId = EchkLPR_ESTADO.pNombreCampo
                    Compuesto.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Compuesto.DevolverTiposCampos()
        End Function

        ' PrepararEliminar
        Private Function EliminarRegistro() As Boolean
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            Dim vMensajeMostrar As Int16 = 0


            Using Scope As New System.Transactions.TransactionScope()
                'Compuesto.MarkAsDeleted()
                'If (ProcesarEliminarDetalle() > 0 And Me.IBCListaPreciosArticulos.MantenimientoListaPreciosArticulos(Compuesto) > 0) Then
                If (ProcesarEliminarDetalle() > 0 And Me.IBCListaPreciosArticulos.spEliminarRegistro(Compuesto.LPR_ID) > 0) Then
                    Scope.Complete()
                    EliminarRegistro = True
                    vMensajeMostrar = 0
                    'MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
                Else
                    Scope.Dispose()
                    EliminarRegistro = False
                    vMensajeMostrar = 2
                    'MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & Compuesto.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End Using
            Me.Cursor = Windows.Forms.Cursors.Default
            MensajeOperaciones(vMensajeMostrar, "eliminado")
            InicializarOrm()
            Return EliminarRegistro
        End Function

        ' PosicionGrid
        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")
                Select Case Metodo
                    Case "PrimerRegistro"
                        resp = Me.IBCBusqueda.PrimerRegistro(Compuesto.CampoPrincipal, _
                                                             Compuesto.cTabla.NombreLargo)
                    Case "RegistroAnterior"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroAnterior(Compuesto.CampoPrincipal, _
                                                               Compuesto.CampoPrincipalValor, _
                                                               Compuesto.cTabla.NombreLargo)
                    Case "RegistroSiguiente"
                        Compuesto.CampoPrincipalValor = CodigoId
                        resp = Me.IBCBusqueda.RegistroSiguiente(Compuesto.CampoPrincipal, _
                                                                Compuesto.CampoPrincipalValor, _
                                                                Compuesto.cTabla.NombreLargo)
                    Case "UltimoRegistro"
                        resp = Me.IBCBusqueda.UltimoRegistro(Compuesto.CampoPrincipal, _
                                                             Compuesto.cTabla.NombreLargo)
                End Select
                vCodigoId = resp
                If vCodigoId Is Nothing Or Trim(vCodigoId) = "" Then
                    MsgBox("¡No se encontro registros!", MsgBoxStyle.Information, Me.Text)
                    Return
                Else
                    If vCodigoId = CodigoId Then Return
                End If
                LimpiarDatos()
                DatoBusquedaConsulta = vCodigoId
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                frm.TipoEdicion = 2 ' B. directa
                If pComportamiento = -1 Then
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = DatoBusquedaConsulta
                End If
                frm.DatoBusqueda = DatoBusquedaConsulta
                frm.oOrm = Compuesto
                frm.Comportamiento = pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = pOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
                BotonesEdicion("Seleccionar registro")
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - NavegarFormulario")
            End Try
        End Sub
        Private Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        ' Formulario Simple
        '' Load
        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub BuscarFormatos(ByRef vObjeto As cbo, ByVal oCompuesto As Object)
            oCompuesto.CampoId = vObjeto.pNombreCampo
            Select Case vObjeto.pNombreCampo
                Case "LPR_PRINCIPAL"
                    cMisProcedimientos.AdicionarElementoCombosEdicion(cboLPR_PRINCIPAL, oCompuesto.BuscarFormatos(), 0)
            End Select
        End Sub

        '' ProcessCmdKey
        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
        Protected Overridable Sub TeclasAccesoRapido(ByVal vkeyData As System.Windows.Forms.Keys)
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.N Then
                If tsbNuevo.Enabled = True Then LlamarMetodo("NuevoRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.E Then
                If tsbEditar.Enabled = True Then LlamarMetodo("EditarRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.C Then
                If tsbCancelarEditar.Enabled = True Then LlamarMetodo("CancelarEdicion")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.G Then
                If tsbGrabar.Enabled = True Then LlamarMetodo("PrepararGuardar")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.W Then
                If TsbGrabarNuevo.Enabled = True Then LlamarMetodo("PrepararGuardarNuevo")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.X Then
                If tsbEliminar.Enabled = True Then LlamarMetodo("PrepararEliminar")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Z Then
                If tsbDeshacer.Enabled = True Then LlamarMetodo("DeshacerCambios")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Add Then
                If tsbAgregar.Enabled = True Then LlamarMetodo("AgregarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Subtract Then
                If tsbQuitar.Enabled = True Then LlamarMetodo("QuitarFilaGrid")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.B Then
                If tsbBuscar.Enabled = True Then LlamarMetodo("BuscarUnRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.Q Then
                If tsbInicio.Enabled = True Then LlamarMetodo("PrimerRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.A Then
                If tsbAnterior.Enabled = True Then LlamarMetodo("RegistroAnterior")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.S Then
                If tsbSiguiente.Enabled = True Then LlamarMetodo("RegistroSiguiente")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Shift + System.Windows.Forms.Keys.W Then
                If tsbFinal.Enabled = True Then LlamarMetodo("UltimoRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.R Then
                If tsbReportes.Enabled = True Then LlamarMetodo("Reportes")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.S Then
                If tsbSalir.Enabled = True Then LlamarMetodo("Salir")
            End If
        End Sub

        '' FormClosing
        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles MyBase.FormClosing
            If pnCuerpo.Enabled = True Then
                If RevisarDatos(False) Then
                    e.Cancel = True
                    MyBase.OnClosing(e)
                Else
                    MyBase.OnClosing(e)
                End If
            End If
        End Sub

        '' Activated
        Private Sub frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles MyBase.Activated
            If pComportamiento <> -1 Then
                Activado()
            End If
        End Sub
        Private Sub Activado()
            ActivarBarra()
            FormatearBotonesEdicion()
        End Sub
        Private Sub ActivarBarra()
            If tsBarra.Enabled = False Then
                tsBarra.Enabled = True
            End If
        End Sub

        '' FormCLosed
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
            Handles MyBase.FormClosed
            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub
        Private Sub Cerrado()
        End Sub
#End Region
#Region "Primaria 2"
#Region "TextBox"
        Private Sub ValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        MetodoBusquedaDato(texto.Text, True, otxt)
                        If otxt.pOOrm.ctabla.NombreCorto = "vwPersonaDocumentoIdentidad" Then ActualizarNombreListaPrecio()
                    End If
                End If
                If .pSoloNumeros Then
                    If texto.Text = "" Then texto.Text = "0"
                End If
                If .pSoloNumerosDecimales Then
                    Dim vSoloNumerosDecimales As String
                    If .pParteEntera > 0 And .pParteDecimal > 0 Then
                        If .pParteDecimal = 0 Then
                            vSoloNumerosDecimales = Strings.StrDup(.pParteEntera, "#")
                        Else
                            vSoloNumerosDecimales = Strings.StrDup(.pParteEntera, "#") & "." & Strings.StrDup(.pParteDecimal - 1, "#") & "0"
                        End If
                        If texto.Text = "" Then texto.Text = "0"
                        Try
                            texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                            If Len(texto.Text) > (.pParteEntera + .pParteDecimal + 1) Then
                                texto.Text = "0"
                                texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                            End If
                        Catch ex As Exception
                            texto.Text = "0"
                            texto.Text = Format(CDbl(texto.Text), vSoloNumerosDecimales)
                        End Try
                    Else
                        If texto.Text = "" Then texto.Text = "0"
                    End If
                End If
            End With
        End Sub

        Private Sub oKeyPress(ByVal EtxtTemporal As txt, ByRef e As System.Windows.Forms.KeyPressEventArgs)
            If EtxtTemporal.pMinusculaMayuscula Then
                e.KeyChar = UCase(e.KeyChar)
            End If
            If EtxtTemporal.pSoloNumerosDecimales Then
                If Not IsNumeric(e.KeyChar) Then
                    If Asc(e.KeyChar) <> 46 Then
                        If Asc(e.KeyChar) <> 8 Then
                            If Asc(e.KeyChar) = 45 And Not EtxtTemporal.pNegativos Then
                                e.KeyChar = ""
                            ElseIf Asc(e.KeyChar) <> 45 Then
                                e.KeyChar = ""
                            End If
                        End If
                    Else
                        If EtxtTemporal.pParteDecimal = 0 Then
                            e.KeyChar = ""
                        End If
                    End If
                End If
            End If
            If EtxtTemporal.pSoloNumeros Then
                If Not IsNumeric(e.KeyChar) Then
                    If Asc(e.KeyChar) <> 8 Then
                        If Asc(e.KeyChar) = 45 And Not EtxtTemporal.pNegativos Then
                            e.KeyChar = ""
                        ElseIf Asc(e.KeyChar) <> 45 Then
                            e.KeyChar = ""
                        End If
                    End If
                End If
            End If
        End Sub

#End Region
#End Region

#Region "Secundaria"
        <Dependency()> _
        Public Property IBCListaPreciosArticulos As Ladisac.BL.IBCListaPreciosArticulos

        <Dependency()> _
        Public Property IBCDetalleListaPrecios As Ladisac.BL.IBCDetalleListaPrecios

        <Dependency()> _
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames

        <Dependency()> _
        Public Property IBCUtil As BL.IBCUtil

        Private FlagModificar As Boolean = False

        Private EchkPER_ESTADO As New chk
        Private EchkMON_ESTADO As New chk
        Private EchkLPR_ESTADO As New chk

        Private EcboLPR_PRINCIPAL As New cbo

        Private EdgvDetalle As New dgv

        Private EtxtPER_ID As New txt
        Private EtxtMON_ID As New txt
        Private EtxtART_ID As New txt

        Private Compuesto As New Ladisac.BE.ListaPreciosArticulos
        Private CompuestoObjeto1 As New Ladisac.BE.DetalleListaPrecios
        Private CompuestoObjeto2 As New Ladisac.BE.TipoPersonas
        Private CompuestoObjeto3 As New Ladisac.BE.ListaPreciosArticulos
        Private ErrorData As New Ladisac.BE.ListaPreciosArticulos.ErrorData
        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private Structure ElementosEliminar
            Public cLPR_ID As String
            Public cART_ID As String
        End Structure

        Private Structure dgv
            Public Property pMetodoColumnas As Boolean
            Public Property pAnchoColumna As Int16
            Public Property pColorColumna As Drawing.Color
            Public Property pBloquearPk As Boolean
            Public Property pCampoEstadoRegistro As String
            Public Property pArrayCamposPkDetalle As Object
            Public Columnas() As Int16
            Public Elementos As Int16
        End Structure


        Private Sub LimpiarDatos()
            vBuscarDetalle = False

            txtLPR_ID.Text = ""
            ErrorProvider1.SetError(txtLPR_ID, Nothing)

            txtLPR_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtLPR_DESCRIPCION, Nothing)

            cboLPR_PRINCIPAL.Text = ""
            ErrorProvider1.SetError(cboLPR_PRINCIPAL, Nothing)

            txtPER_ID.Text = ""
            ErrorProvider1.SetError(txtPER_ID, Nothing)

            txtPER_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION, Nothing)

            chkPER_ESTADO.Checked = True
            chkPER_ESTADO.CheckState = EchkPER_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkPER_ESTADO, Nothing)


            txtMON_ID.Text = ""
            ErrorProvider1.SetError(txtMON_ID, Nothing)

            txtMON_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtMON_DESCRIPCION, Nothing)

            chkMON_ESTADO.Checked = True
            chkMON_ESTADO.CheckState = EchkMON_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkMON_ESTADO, Nothing)

            chkLPR_ESTADO.Checked = True
            chkLPR_ESTADO.CheckState = EchkLPR_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkLPR_ESTADO, Nothing)

            dgvDetalle.Rows.Clear()
            ErrorProvider1.SetError(dgvDetalle, Nothing)

            dgvListas.DataSource = Nothing
            ErrorProvider1.SetError(dgvListas, Nothing)

            ReDim eRegistrosEliminar(1)

            vBuscarDetalle = True
        End Sub
        Private Sub HabilitarNuevo()
            txtLPR_ID.Enabled = True
            txtPER_ID.Enabled = True
        End Sub
        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkPER_ESTADO)
            ColocarValoresDefault(chkMON_ESTADO)
            ColocarValoresDefault(chkLPR_ESTADO)
        End Sub

        Private Sub CrearCodigoId()
            ProcesoCrearCodigoId("CrearCodigoSimple", txtLPR_ID)
            txtMON_ID.Text = BCVariablesNames.MonedaSistema
            MetodoBusquedaDato(txtMON_ID.Text, True, EtxtMON_ID)
            MetodoBusquedaDato(txtPER_ID.Text, False, EtxtPER_ID)
        End Sub
        Private Sub HabilitarEscrituraNuevo()
            txtLPR_ID.ReadOnly = False
        End Sub
        Private Sub AdicionarFilasGrid()
            dgvDetalle.Rows.Add(txtLPR_ID.Text, txtLPR_DESCRIPCION.Text, cboLPR_PRINCIPAL.Text, _
                    "", "", "", "", "", 0, 0, 0, "ACTIVO", False)
            EdgvDetalle.Elementos = EdgvDetalle.Elementos + 1
        End Sub
        Private Sub EliminarFilasGrid()
            If dgvDetalle.Rows.Count = 0 Then Return
            Dim vfila As DataGridViewRow
            vfila = dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
            If dgvDetalle.Rows.Count > 0 Then
                Try
                    With dgvDetalle.Rows(dgvDetalle.CurrentRow.Index)
                        If .Cells("cEstadoRegistro").Value Then
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cLPR_ID = .Cells("cLPR_ID").Value.ToString()
                            eRegistrosEliminar(eRegistrosEliminar.Count() - 1).cART_ID = .Cells("cART_ID").Value.ToString()
                            ReDim Preserve eRegistrosEliminar(eRegistrosEliminar.Count)
                        End If '
                    End With
                    dgvDetalle.Rows.Remove(vfila)
                Catch ex As Exception
                    MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - QuitarFilaGrid")
                End Try
            End If
        End Sub
        Public Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "PrepararEliminar"
                    Compuesto.Vista = "RegistroAnterior"
                    Compuesto.LPR_ID = CodigoId
                Case "Load"
                    Compuesto.Vista = "PrimerRegistro"
                    Compuesto.LPR_ID = CodigoId
                Case "NavegarFormulario"
                    Compuesto.LPR_ID = CodigoId
                Case "EliminarRegistro"
                    Compuesto.LPR_ID = txtLPR_ID.Text.Trim
                    CodigoId = txtLPR_ID.Text.Trim
                Case "InicializarDatos"
                    Compuesto.LPR_ID = txtLPR_ID.Text.Trim
                    CompuestoObjeto1.LPR_ID = txtLPR_ID.Text.Trim
                    CodigoId = txtLPR_ID.Text.Trim

                    If vBuscarDetalle Then
                        CompuestoObjeto1.Vista = "ListarRegistros"
                        Dim NombreProcedimiento As String = CompuestoObjeto1.SentenciaSqlBusqueda()
                        Dim ds As New DataSet
                        Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, CodigoId, " "))
                        Dim vcontrol As Int16 = sr.Peek
                        If vcontrol <> -1 Then
                            ds.ReadXml(sr)
                            Dim x As Int32 = 0
                            Dim y As Int32 = 0
                            dgvDetalle.Rows.Clear()
                            If (ds.Tables(0).Rows.Count > 0) Then
                                While (x < ds.Tables(0).Rows.Count)
                                    dgvDetalle.Rows.Add()
                                    With ds.Tables(0).Rows(x)
                                        While y < ds.Tables(0).Columns.Count
                                            dgvDetalle.Item(y, dgvDetalle.Rows.Count - 1).Value = Formatos(.Item(y).GetType.ToString, .Item(y).ToString())
                                            y = y + 1
                                        End While
                                        y = 0
                                    End With
                                    x += 1
                                End While
                            Else
                                MsgBox(" No se encontro registros", MsgBoxStyle.Information)
                            End If
                        Else
                            dgvDetalle.DataSource = Nothing
                        End If
                    End If
            End Select
        End Sub
        Function Formatos(ByVal vCadena As String, ByVal vValor As Object)
            Select Case vCadena
                Case "System.String"
                    Return vValor.ToString
                Case "System.DateTime"
                    Return CDate(vValor)
                Case "System.Int32"
                    Return Val(vValor)
                Case Else
                    Return vValor
            End Select
        End Function

        Private Sub DatosCabecera()
            'If FlagModificar Then
            '    Compuesto.LPR_ID = Strings.Trim(txtLPR_ID.Text)
            'Else
            '    Compuesto.LPR_ID = Me.IBCBusqueda.NuevoLpr_IdListaPreciosArticulos()
            '    txtLPR_ID.Text = Compuesto.LPR_ID
            'End If

            Compuesto.LPR_ID = Strings.Trim(txtLPR_ID.Text)

            Compuesto.LPR_DESCRIPCION = Strings.Trim(txtLPR_DESCRIPCION.Text)
            Compuesto.LPR_PRINCIPAL = DevolverTiposCampos("LPR_PRINCIPAL", cboLPR_PRINCIPAL.Text, Compuesto)
            If Strings.Trim(txtPER_ID.Text) = "" Then
                Compuesto.PER_ID = Nothing
            Else
                Compuesto.PER_ID = Strings.Trim(txtPER_ID.Text)
            End If
            Compuesto.MON_ID = Strings.Trim(txtMON_ID.Text)
            Compuesto.USU_ID = SessionService.UserId
            Compuesto.LPR_FEC_GRAB = Now
            Compuesto.LPR_ESTADO = DevolverTiposCampos(chkLPR_ESTADO)
            Compuesto.LPR_CONTROL = 1
        End Sub
        Private Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Compuesto.ColocarErrores(txtLPR_ID, Compuesto.VerificarDatos("LPR_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtLPR_DESCRIPCION, Compuesto.VerificarDatos("LPR_DESCRIPCION"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(cboLPR_PRINCIPAL, Compuesto.VerificarDatos("LRP_PRINCIPAL"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtPER_ID, Compuesto.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(txtMON_ID, Compuesto.VerificarDatos("MON_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(pnCuerpo, Compuesto.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(btnImagen, Compuesto.VerificarDatos("LPR_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(chkLPR_ESTADO, Compuesto.VerificarDatos("LPR_ESTADO"), ErrorProvider1)
                    resp.rM = Compuesto.ColocarErrores(lblTitle, Compuesto.VerificarDatos("LPR_CONTROL"), ErrorProvider1)
                Case "Detalle"
                    resp.rM = CompuestoObjeto1.ColocarErrores(dgvDetalle, _
                                                       CompuestoObjeto1.VerificarDatos(CompuestoObjeto1.LPR_ID, _
                                                                                CompuestoObjeto1.ART_ID, _
                                                                                CompuestoObjeto1.DLP_PRECIO_MINIMO, _
                                                                                CompuestoObjeto1.DLP_PRECIO_UNITARIO, _
                                                                                CompuestoObjeto1.DLP_RECARGO_ENVIO, _
                                                                                CompuestoObjeto1.USU_ID, _
                                                                                CompuestoObjeto1.DLP_FEC_GRAB, _
                                                                                CompuestoObjeto1.DLP_ESTADO), _
                                                       ErrorProvider1)
            End Select
            Return vrO
        End Function
        Private Sub InicializarOrm()
            'CompuestoObjeto1 = Nothing
            'CompuestoObjeto1 = New Ladisac.BE.DetalleListaPrecios
            'Compuesto = Nothing
            'Compuesto = New Ladisac.BE.ListaPreciosArticulos
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            Select Case vComportamiento
                Case 3 ' PersonaDocumentoIdentidad
                    ActualizarNombreListaPrecio()
            End Select
        End Sub
        Private Sub ActualizarNombreListaPrecio()
            If Trim(txtPER_ID.Text) <> "" Then txtLPR_DESCRIPCION.Text = Strings.LSet((txtPER_DESCRIPCION.Text & " - " & cboLPR_PRINCIPAL.Text), LongitudCampoTabla("LPR_DESCRIPCION", Compuesto.vArrayDatosComboBox, Compuesto.vElementosDatosComboBox - 1))
        End Sub
        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = Me.ActiveControl.Text
                If Me.ActiveControl.Name.ToString = "txtMON_ID" Then EtxtMON_ID.pTexto2 = Me.ActiveControl.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                LongitudId = 3
                CaracterId = "0"

                ConfigurarCheck()
                ConfigurarComboBox()
                ConfigurarDataGridView()
                ConfigurarText()

                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()
                ConfigurarGrid("Load")

                If Comportamiento = -1 Then BusquedaDatos("Load")

                If pComportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If

                FormatearCampos(txtLPR_ID, "LPR_ID")
                'FormatearCampos(txtLPR_DESCRIPCION, "LPR_DESCRIPCION")
                FormatearCampos(cboLPR_PRINCIPAL, "LPR_PRINCIPAL")
                FormatearCampos(txtPER_ID, "CODIGO")
                'FormatearCampos(txtPER_DESCRIPCION, "NOMBRE")
                FormatearCampos(txtMON_ID, "MON_ID")
                FormatearCampos(txtMON_DESCRIPCION, "MON_DESCRIPCION")


                Select Case SessionService.UserId
                    Case "GLOPEZ"
                        BuscarTipoCliente(" AND TPE_DESCRIPCION<>'MEGACENTROS' ")
                        'cboTipoCliente.Items.Remove("MEGACENTROS")
                    Case "IRMAG"
                        BuscarTipoCliente(" AND TPE_DESCRIPCION='MEGACENTROS' ")
                        'cboTipoCliente.Text = "MEGACENTROS"
                        cboTipoCliente.Enabled = False
                    Case "ADMIN"
                        BuscarTipoCliente()
                    Case Else
                        BuscarTipoCliente("AND TPE_DESCRIPCION=' '")
                        'cboTipoCliente.DataSource = Nothing
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
        End Sub
        Private Sub AdicionarElementoCombosEdicion()
            BuscarFormatos(EcboLPR_PRINCIPAL, Compuesto)
        End Sub
        Private Sub NombresFormulariosControles()
            'EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            'EtxtMON_ID.pComportamiento = 1
            'EtxtMON_ID.pOrdenBusqueda = 0

            'EtxtART_ID.pOOrm = New Ladisac.BE.Articulos
            'EtxtART_ID.pComportamiento = 2
            'EtxtART_ID.pOrdenBusqueda = 1

            'EtxtPER_ID.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
            'EtxtPER_ID.pComportamiento = 3
            'EtxtPER_ID.pOrdenBusqueda = 1
        End Sub
#Region "CheckBox"
        Private Sub ConfigurarCheck()
            EchkPER_ESTADO.pFormatearTexto = True
            EchkPER_ESTADO.pNombreCampo = "PER_ESTADO"
            EchkPER_ESTADO.pSimple = Compuesto
            EchkPER_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkPER_ESTADO.vEstado0 = ""
            EchkPER_ESTADO.vEstado1 = ""
            EchkPER_ESTADO.vEstadoX = ""

            EchkMON_ESTADO.pFormatearTexto = True
            EchkMON_ESTADO.pNombreCampo = "MON_ESTADO"
            EchkMON_ESTADO.pSimple = Compuesto
            EchkMON_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkMON_ESTADO.vEstado0 = ""
            EchkMON_ESTADO.vEstado1 = ""
            EchkMON_ESTADO.vEstadoX = ""

            EchkLPR_ESTADO.pFormatearTexto = True
            EchkLPR_ESTADO.pNombreCampo = "LPR_ESTADO"
            EchkLPR_ESTADO.pSimple = Compuesto
            EchkLPR_ESTADO.pValorDefault = CheckState.Checked
            EchkLPR_ESTADO.vEstado0 = ""
            EchkLPR_ESTADO.vEstado1 = ""
            EchkLPR_ESTADO.vEstadoX = ""

            ConfigurarCheck_Refrescar(EchkPER_ESTADO)
            ConfigurarCheck_Refrescar(EchkMON_ESTADO)
            ConfigurarCheck_Refrescar(EchkLPR_ESTADO)
        End Sub
        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function
        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkPER_ESTADO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO.pValorDefault
                Case "chkMON_ESTADO"
                    vObjetoChk.pValorDefault = EchkMON_ESTADO.pValorDefault
                Case "chkLPR_ESTADO"
                    vObjetoChk.pValorDefault = EchkLPR_ESTADO.pValorDefault
            End Select

            Select Case vObjetoChk.pValorDefault
                Case CheckState.Checked
                    vObjeto.Checked = True
                    vObjeto.CheckState = CheckState.Checked
                Case CheckState.Unchecked
                    vObjeto.Checked = False
                    vObjeto.CheckState = CheckState.Unchecked
                Case CheckState.Indeterminate
                    vObjeto.Checked = Nothing
                    vObjeto.CheckState = CheckState.Indeterminate
            End Select
        End Sub
        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkLPR_ESTADO.CheckedChanged, chkMON_ESTADO.CheckedChanged, chkPER_ESTADO.CheckedChanged
            Select Case sender.name.ToString
                Case "chkPER_ESTADO"
                    If EchkPER_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkPER_ESTADO)
                    End If
                Case "chkMON_ESTADO"
                    If EchkMON_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkMON_ESTADO)
                    End If
                Case "chkLPR_ESTADO"
                    If EchkLPR_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkLPR_ESTADO)
                    End If
            End Select
        End Sub
        Private Sub InicializarTexto(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PER_ESTADO"
                    With chkPER_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "MON_ESTADO"
                    With chkMON_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "LPR_ESTADO"
                    With chkLPR_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub
        Public Sub Check_Refrescar()
            InicializarTexto(EchkPER_ESTADO)
            InicializarTexto(EchkMON_ESTADO)
            InicializarTexto(EchkLPR_ESTADO)
        End Sub
#End Region

#Region "DataGridView"
        Private Sub ConfigurarDataGridView()
            EdgvDetalle.pAnchoColumna = 20
            EdgvDetalle.pBloquearPk = True
            EdgvDetalle.pColorColumna = Drawing.Color.Black
            EdgvDetalle.pCampoEstadoRegistro = "cEstadoRegistro"
            EdgvDetalle.pMetodoColumnas = False

            ReDim EdgvDetalle.pArrayCamposPkDetalle(1)
            EdgvDetalle.pArrayCamposPkDetalle(1) = "cART_ID"

            dgvDetalle.AllowUserToAddRows = False
            dgvDetalle.AllowUserToDeleteRows = False
            dgvDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top _
                        Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            dgvDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End Sub
        Private Sub ConfigurarGrid(ByVal vProceso As String)
            Select Case vProceso
                Case "Load"
                    eConfigurarDataGridObjeto.Metodo = "SoloAlgunasColumnas"
                    eConfigurarDataGridObjeto.Orm = Nothing
                    eConfigurarDataGridObjeto.Array = {4, 5}
                    ConfigurarGrid(dgvDetalle, eConfigurarDataGridObjeto)
            End Select
        End Sub

        Private Sub dgvDetalle_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles dgvDetalle.KeyDown
            If dgvDetalle.RowCount = 0 Then Exit Sub
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If EtxtART_ID.pBusqueda Then
                                EtxtART_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString 'Me.Text
                                MetodoBusquedaDato("", False, EtxtART_ID)
                                EtxtART_ID.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString 'Me.Text
                                EtxtART_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString 'Me.Text
                            End If
                    End Select
            End Select
        End Sub
        Private Sub dgvDetalle_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellDoubleClick
            If dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name = "cART_ID" Then
                If EtxtART_ID.pFormularioConsulta Then
                    'Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Facturacion.Views.frmArticulos)()
                    'frmConsulta.DatoBusquedaConsulta = dgvDetalle.CurrentCell.Value
                    'frmConsulta.MaximizeBox = False
                    'frmConsulta.MinimizeBox = False
                    'frmConsulta.Comportamiento = -1
                    'frmConsulta.ShowDialog()
                End If
            Else
                If EdgvDetalle.pMetodoColumnas Then
                    For Each EdgvDetalle.Elementos In EdgvDetalle.Columnas
                        If dgvDetalle.CurrentCell.ColumnIndex = EdgvDetalle.Elementos Then
                            If dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna Then
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                            Else
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                                dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna
                                dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = EdgvDetalle.pColorColumna
                            End If
                        End If
                    Next
                End If
            End If
        End Sub
        Private Sub dgvDetalle_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.RowEnter
            If EdgvDetalle.pBloquearPk Then
                Dim vCampoPk As String = ""
                For elemento As Integer = 1 To EdgvDetalle.pArrayCamposPkDetalle.GetUpperBound(0)
                    vCampoPk = EdgvDetalle.pArrayCamposPkDetalle(elemento).ToString
                    If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value Is Nothing Then
                    Else
                        If dgvDetalle.Rows(e.RowIndex).Cells(EdgvDetalle.pCampoEstadoRegistro).Value.ToString <> "1" Then
                            dgvDetalle.Columns(vCampoPk).ReadOnly = False
                            EtxtART_ID.pBusqueda = True
                        Else
                            dgvDetalle.Columns(vCampoPk).ReadOnly = True
                            EtxtART_ID.pBusqueda = False
                        End If
                    End If
                Next elemento
            End If
        End Sub
        Private Sub dgvDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellEnter
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    EtxtART_ID.pTexto1 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString
            End Select
        End Sub
        Private Sub dgvDetalle_CellValidated(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
            Handles dgvDetalle.CellValidated
            Select Case sender.Columns(dgvDetalle.CurrentCell.ColumnIndex).Name.ToString
                Case "cART_ID"
                    EtxtART_ID.pTexto2 = dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString
                    ValidarDatos(EtxtART_ID, dgvDetalle.Item(dgvDetalle.CurrentCell.ColumnIndex, dgvDetalle.CurrentRow.Index).Value.ToString, True)
            End Select
        End Sub
        Private Sub ValidarDatos(ByRef otxt As txt, ByVal texto As String, ByVal BusquedaDirecta As Boolean)
            If otxt.pTexto1 <> otxt.pTexto2 Then
                If otxt.pBusqueda Then
                    MetodoBusquedaDato(texto, BusquedaDirecta, otxt)
                End If
            End If
        End Sub
#End Region

#Region "TextBox"
        Private Sub ConfigurarText()
            EtxtPER_ID.pTexto1 = ""
            EtxtPER_ID.pTexto2 = ""
            EtxtPER_ID.pSoloNumerosDecimales = False
            EtxtPER_ID.pSoloNumeros = False
            EtxtPER_ID.pParteEntera = 0
            EtxtPER_ID.pParteDecimal = 0
            EtxtPER_ID.pMinusculaMayuscula = True
            EtxtPER_ID.pBusqueda = True
            EtxtPER_ID.pCadenaFiltrado = ""

            EtxtMON_ID.pTexto1 = ""
            EtxtMON_ID.pTexto2 = ""
            EtxtMON_ID.pSoloNumerosDecimales = False
            EtxtMON_ID.pSoloNumeros = False
            EtxtMON_ID.pParteEntera = 0
            EtxtMON_ID.pParteDecimal = 0
            EtxtMON_ID.pMinusculaMayuscula = True
            EtxtMON_ID.pBusqueda = True
            EtxtMON_ID.pCadenaFiltrado = ""

            EtxtART_ID.pTexto1 = ""
            EtxtART_ID.pTexto2 = ""
            EtxtART_ID.pSoloNumerosDecimales = False
            EtxtART_ID.pSoloNumeros = False
            EtxtART_ID.pParteEntera = 0
            EtxtART_ID.pParteDecimal = 0
            EtxtART_ID.pMinusculaMayuscula = True
            EtxtART_ID.pBusqueda = True
            EtxtART_ID.pCadenaFiltrado = ""

            'EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID.pOOrm = New Ladisac.BE.PersonaDocumentoIdentidad
            EtxtPER_ID.pFormularioConsulta = True

            EtxtMON_ID.pOOrm = New Ladisac.BE.Moneda
            EtxtMON_ID.pFormularioConsulta = True

            EtxtART_ID.pOOrm = New Ladisac.BE.Articulos
            EtxtART_ID.pFormularioConsulta = True
        End Sub
#End Region

#End Region

#Region "Secundaria 2"
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String)

            Select Case NombreCampo
                Case "CODIGO", "NOMBRE"
                    FormatearCampos(oObjeto, NombreCampo, EtxtPER_ID.pOOrm.vArrayDatosComboBox, EtxtPER_ID.pOOrm.vElementosDatosComboBox - 1)
                Case Else
                    FormatearCampos(oObjeto, NombreCampo, Compuesto.vArrayDatosComboBox, Compuesto.vElementosDatosComboBox - 1)
            End Select

        End Sub
        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String, ByVal vArrayDatosComboBox As Object, ByVal vElementos As Int16)
            For Fila = 0 To vElementos
                If vArrayDatosComboBox(Fila).NombreCampo.ToString = NombreCampo Then
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "char" Or _
                        vArrayDatosComboBox(Fila).Tipo.ToString = "varchar" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = False
                            oObjeto.SoloNumeros = False
                            oObjeto.MinusculaMayuscula = True
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "int" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = False
                            oObjeto.SoloNumeros = True
                            oObjeto.MinusculaMayuscula = False
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    If vArrayDatosComboBox(Fila).Tipo.ToString = "numeric" Then
                        If oObjeto.GetType.BaseType() = GetType(Windows.Forms.TextBox) Then
                            oObjeto.SoloNumerosDecimales = True
                            oObjeto.SoloNumeros = False
                            oObjeto.MinusculaMayuscula = False
                            oObjeto.ParteEntera = vArrayDatosComboBox(Fila).ParteEntera
                            oObjeto.ParteDecimal = vArrayDatosComboBox(Fila).ParteDecimal
                        End If
                        oObjeto.MaxLength = vArrayDatosComboBox(Fila).Longitud
                        oObjeto.Width = vArrayDatosComboBox(Fila).Ancho
                    End If
                    Exit For
                End If
            Next
        End Sub
#Region "ComboBox"
        Private Sub ConfigurarComboBox()
            EcboLPR_PRINCIPAL.pNombreCampo = "LPR_PRINCIPAL"
            cboLPR_PRINCIPAL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        End Sub
#End Region
#Region "TextBox"
        Private Sub txt_OnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.GotFocus, txtMON_ID.GotFocus
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto1 = sender.text
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto1 = sender.text
            End Select
        End Sub
        Private Sub txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.LostFocus, txtMON_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    EtxtPER_ID.pTexto2 = sender.text
                Case "txtMON_ID"
                    EtxtMON_ID.pTexto2 = sender.text
            End Select
        End Sub
        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.Validated, txtMON_ID.Validated
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    txtPER_ID.Text = cMisProcedimientos.VerificarLongitud(txtPER_ID.Text, txtPER_ID.MaxLength)
                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                Case "txtMON_ID"
                    ValidarDatos(EtxtMON_ID, txtMON_ID)
            End Select
        End Sub
        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtPER_ID.KeyPress, txtMON_ID.KeyPress
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    oKeyPress(EtxtPER_ID, e)
                Case "txtMON_ID"
                    oKeyPress(EtxtMON_ID, e)
            End Select
        End Sub
        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles txtPER_ID.DoubleClick, txtMON_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    oDoubleClick(EtxtPER_ID, txtPER_ID, "frmPersonas")
                Case "txtMON_ID"
                    oDoubleClick(EtxtMON_ID, txtMON_ID, "frmMoneda")
            End Select
        End Sub
        Private Sub oDoubleClick(ByVal EtxtTemporal As txt, ByRef txt As TextBox, ByVal e As System.String)
            EtxtTemporal.pTexto2 = txt.Text
            ValidarDatos(EtxtTemporal, txt)
            Dim Texto As String = ""
            If Trim(txt.Text) = "" Then
                Exit Sub
            End If
            Dim frmconsulta As Object = Nothing
            Texto = txt.Text
            If EtxtTemporal.pFormularioConsulta Then
                Select Case e
                    Case "frmPersonas"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                    Case "frmMoneda"
                        frmconsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmMoneda)()
                    Case Else
                        Exit Sub
                End Select
                frmconsulta.DatoBusquedaConsulta = Texto
                frmconsulta.MaximizeBox = False
                frmconsulta.MinimizeBox = False
                frmconsulta.Comportamiento = -1
                frmconsulta.ShowDialog()
            End If
        End Sub
        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtPER_ID.KeyDown, txtMON_ID.KeyDown
            Select Case e.KeyCode
                Case Keys.F1
                    Select Case sender.name.ToString
                        Case "txtPER_ID"
                            TeclaF1(EtxtPER_ID, txtPER_ID)
                        Case "txtMON_ID"
                            TeclaF1(EtxtMON_ID, txtMON_ID)
                    End Select
            End Select
        End Sub
#End Region

#End Region

        Private Sub ConfigurarDatosGrabados()
            ReDim eRegistrosEliminar(1)
            Dim vFilGrid As Int16 = 0
            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    .Cells("cEstadoRegistro").Value = True
                End With
                vFilGrid += 1
            End While
        End Sub

        Private Function ExtraerDetalle() As Int16
            ExtraerDetalle = EliminarRegistroDetalle()
            If ExtraerDetalle = 0 Then Exit Function
            ExtraerDetalle = ProcesarDatosDetalle()
            Return ExtraerDetalle
        End Function
        Private Function EliminarRegistroDetalle() As Int16
            EliminarRegistroDetalle = 0
            If eRegistrosEliminar.Count = 2 Then
                EliminarRegistroDetalle = 1
            Else
                If eRegistrosEliminar.Count - 2 < 1 Then
                    EliminarRegistroDetalle = 1
                    Exit Function
                End If
                For fila = 1 To eRegistrosEliminar.Count - 2
                    vMensajeErrorOrm = ""
                    'CompuestoObjeto1 = Nothing
                    'CompuestoObjeto1 = New Ladisac.BE.DetalleListaPrecios
                    'EliminarRegistroDetalle = Me.IBCDetalleListaPrecios.DeleteRegistroDetalleListaPrecios(CompuestoObjeto1, eRegistrosEliminar(fila).cLPR_ID, eRegistrosEliminar(fila).cART_ID)
                    EliminarRegistroDetalle = Me.IBCDetalleListaPrecios.spEliminarRegistro(eRegistrosEliminar(fila).cLPR_ID, eRegistrosEliminar(fila).cART_ID)
                    If EliminarRegistroDetalle = 0 Then
                        vMensajeErrorOrm = CompuestoObjeto1.vMensajeError
                        Exit For
                    End If
                Next
            End If
            Return EliminarRegistroDetalle
        End Function
        Private Function ProcesarDatosDetalle() As Int16
            Dim vFilGrid As Integer = 0
            ProcesarDatosDetalle = 0
            If dgvDetalle.Rows.Count() = 0 Then
                MsgBox("No existen registros en el detalle", MsgBoxStyle.Information, "Error de datos")
                Exit Function
            End If

            While (dgvDetalle.Rows.Count() > vFilGrid)
                With dgvDetalle.Rows(vFilGrid)
                    vMensajeErrorOrm = ""

                    'CompuestoObjeto1 = Nothing
                    'CompuestoObjeto1 = New Ladisac.BE.DetalleListaPrecios

                    CompuestoObjeto1.LPR_ID = .Cells("cLPR_ID").Value
                    CompuestoObjeto1.ART_ID = .Cells("cART_ID").Value
                    'CompuestoObjeto1.DLP_PRECIO_MINIMO = FormatearNumeros(.Cells("cDLP_PRECIO_MINIMO").Value, "DLP_PRECIO_MINIMO", CompuestoObjeto1)
                    CompuestoObjeto1.DLP_PRECIO_MINIMO = FormatearNumeros(.Cells("cDLP_PRECIO_UNITARIO").Value, "DLP_PRECIO_UNITARIO", CompuestoObjeto1)
                    CompuestoObjeto1.DLP_PRECIO_UNITARIO = FormatearNumeros(.Cells("cDLP_PRECIO_UNITARIO").Value, "DLP_PRECIO_UNITARIO", CompuestoObjeto1)
                    CompuestoObjeto1.DLP_RECARGO_ENVIO = FormatearNumeros(.Cells("cDLP_RECARGO_ENVIO").Value, "DLP_RECARGO_ENVIO", CompuestoObjeto1)
                    CompuestoObjeto1.USU_ID = SessionService.UserId
                    CompuestoObjeto1.DLP_FEC_GRAB = Now
                    CompuestoObjeto1.DLP_ESTADO = DevolverTiposCampos("DLP_ESTADO", .Cells("cDLP_ESTADO").Value.ToString(), CompuestoObjeto1)

                    If vMensajeErrorOrm <> "" Then
                        ErrorProvider1.SetError(dgvDetalle, vMensajeErrorOrm & "En fila:" & vFilGrid + 1)
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If

                    If Not Validar("Detalle") Then
                        ProcesarDatosDetalle = -1
                        Exit Function
                    End If

                    If (.Cells("cEstadoRegistro").Value = 1 Or .Cells("cEstadoRegistro").Value = True) Then
                        'CompuestoObjeto1.MarkAsModified()
                        'ProcesarDatosDetalle = Me.IBCDetalleListaPrecios.MantenimientoDetalleListaPrecios(CompuestoObjeto1)
                        ProcesarDatosDetalle = Me.IBCDetalleListaPrecios.spActualizarRegistro(CompuestoObjeto1.LPR_ID, CompuestoObjeto1.ART_ID, CompuestoObjeto1.DLP_PRECIO_MINIMO, CompuestoObjeto1.DLP_PRECIO_UNITARIO, CompuestoObjeto1.DLP_RECARGO_ENVIO, CompuestoObjeto1.USU_ID, CompuestoObjeto1.DLP_FEC_GRAB, CompuestoObjeto1.DLP_ESTADO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = CompuestoObjeto1.vMensajeError
                            Exit Function
                        End If
                    Else
                        'CompuestoObjeto1.MarkAsAdded()
                        'ProcesarDatosDetalle = Me.IBCDetalleListaPrecios.MantenimientoDetalleListaPrecios(CompuestoObjeto1)
                        ProcesarDatosDetalle = Me.IBCDetalleListaPrecios.spInsertarRegistro(CompuestoObjeto1.LPR_ID, CompuestoObjeto1.ART_ID, CompuestoObjeto1.DLP_PRECIO_MINIMO, CompuestoObjeto1.DLP_PRECIO_UNITARIO, CompuestoObjeto1.DLP_RECARGO_ENVIO, CompuestoObjeto1.USU_ID, CompuestoObjeto1.DLP_FEC_GRAB, CompuestoObjeto1.DLP_ESTADO)
                        If ProcesarDatosDetalle = 0 Then
                            vMensajeErrorOrm = CompuestoObjeto1.vMensajeError
                            Exit Function
                        End If
                    End If
                End With
                vFilGrid += 1
            End While
            Return ProcesarDatosDetalle
        End Function

        Private Function FormatearNumeros(ByVal vDato As String, ByVal vCampo As String, ByVal oOrm As DetalleListaPrecios)
            Dim vEntero As Integer = 0
            Dim vDecimal As Integer = 0
            Dim vFlag As Boolean = False
            For elemento As Integer = 0 To oOrm.vArrayDatosComboBox.GetUpperBound(0)
                If oOrm.vArrayDatosComboBox(elemento).NombreCampo = vCampo Then
                    vEntero = oOrm.vArrayDatosComboBox(elemento).ParteEntera
                    vDecimal = oOrm.vArrayDatosComboBox(elemento).ParteDecimal
                    Exit For
                End If
            Next elemento

            If Not IsNumeric(vDato) Then vDato = 0
            If CDbl(vDato) < 0 Then
                vDato = Strings.Right(vDato, Len(vDato) - 1)
                vFlag = True
            End If

            FormatearNumeros = cMisProcedimientos.FormatoNumero(vEntero, vDecimal, vDato)
            Dim vCadenaError As String = ""
            If FormatearNumeros = 0 Then vCadenaError = "Desborde de la parte entera y decimal"
            If FormatearNumeros = -1 Then vCadenaError = "Desborde de la parte entera"
            If FormatearNumeros = -2 Then vCadenaError = "Desbordo de la parte entera despues de redondearlo"
            If FormatearNumeros = -3 Then vCadenaError = "Dato no númerico"
            If FormatearNumeros = -4 Then vCadenaError = "Error de desbordamiento general"
            If FormatearNumeros <= 0 Then
                If IsNumeric(vDato) Then
                    If Val(vDato) <> 0 Then
                        vMensajeErrorOrm = "Campo: " & vCampo & ", error en el formato de datos númericos, valor: " & vDato & ", " & vCadenaError
                    End If
                Else
                    vMensajeErrorOrm = "Campo: " & vCampo & ", error en el formato de datos númericos, valor: " & vDato & ", " & vCadenaError
                End If
            End If
            If vFlag Then
                FormatearNumeros = FormatearNumeros * -1
            End If
            Return FormatearNumeros
        End Function

        Private Function ProcesarEliminarDetalle() As Int16
            CompuestoObjeto1.LPR_ID = txtLPR_ID.Text.Trim
            Return EliminarDetalle(CompuestoObjeto1)
        End Function
        Private Function EliminarDetalle(ByVal oOrm As DetalleListaPrecios) As Int16
            Return 1

            'Dim context = ContainerService.Resolve(Of Ladisac.BE.LadisacEntities)()
            'Dim query = (From c In context.DetalleListaPrecios Where c.LPR_ID = txtLPR_ID.Text Select c)
            'context.DeleteObject(CompuestoObjeto1)
            'context.SaveChanges()

            'CompuestoObjeto1.MarkAsDeleted()
            'Return Me.IBCDetalleListaPrecios.MantenimientoDetalleListaPrecios(CompuestoObjeto1)
        End Function

        Public Sub ConfigurarGrid(ByRef vMiDataGridView As DataGridView, _
                                  ByVal ConfigurarDataGrid As MisProcedimientos.ConfigurarDataGrid)
            Select Case ConfigurarDataGrid.Metodo
                Case "SoloAlgunasColumnas"
                    ConfigurarAnchoColumnaGrid(vMiDataGridView, ConfigurarDataGrid.Array)
                Case "ElementoItem"
            End Select
        End Sub
        Public Sub ConfigurarAnchoColumnaGrid(ByRef vMiDataGridView As DataGridView, ByVal vArray() As Integer)
            If vMiDataGridView.Name.ToString = "dgvDetalle" Then
                ReDim EdgvDetalle.Columnas(vArray.Length - 1)
                For elemento As Integer = 0 To vArray.Length - 1
                    EdgvDetalle.Columnas(elemento) = vArray(elemento).ToString
                Next elemento
            End If
        End Sub

        Private Sub dgvDetalle_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dgvDetalle.RowHeaderMouseDoubleClick
            If EdgvDetalle.pMetodoColumnas Then
                For Each EdgvDetalle.Elementos In EdgvDetalle.Columnas
                    If dgvDetalle.CurrentCell.ColumnIndex = EdgvDetalle.Elementos Then
                        If dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna Then
                            dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                            dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = Drawing.Color.White
                        Else
                            dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            dgvDetalle.Columns.Item(dgvDetalle.CurrentCell.ColumnIndex).Width = EdgvDetalle.pAnchoColumna
                            dgvDetalle.Columns(dgvDetalle.CurrentCell.ColumnIndex).DefaultCellStyle.BackColor = EdgvDetalle.pColorColumna
                        End If
                    End If
                Next
            End If
        End Sub
        Private Function MensajeOperaciones(ByVal vRespuesta As Int16, ByVal vOperacion As String) As Int16
            MensajeOperaciones = vRespuesta
            Select Case vRespuesta
                Case 0
                    MsgBox("Registro " & vOperacion, MsgBoxStyle.Information, Me.Text)
                Case 1
                Case 2
                    MsgBox("Registro no fue " & vOperacion & " verifique sus datos" & _
                           Chr(13) & Chr(13) & Compuesto.vMensajeError & _
                           Chr(13) & Chr(13) & CompuestoObjeto1.vMensajeError, _
                           MsgBoxStyle.Information, Me.Text)
            End Select
            Return MensajeOperaciones
        End Function

        Private Sub cboLPR_PRINCIPAL_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLPR_PRINCIPAL.SelectedValueChanged
            ActualizarNombreListaPrecio()
        End Sub

        Function LongitudCampoTabla(ByVal NombreCampo As String, ByVal vArrayDatosComboBox As Object, ByVal vElementos As Int16)
            LongitudCampoTabla = 0
            For Fila = 0 To vElementos
                If vArrayDatosComboBox(Fila).NombreCampo.ToString = NombreCampo Then
                    LongitudCampoTabla = vArrayDatosComboBox(Fila).Longitud
                    Exit For
                End If
            Next
        End Function

        Private Function OrdenBusquedaDirecta(ByVal vComportamiento, ByVal vOrdenBusqueda) As Int16
            OrdenBusquedaDirecta = vOrdenBusqueda
            Select Case vComportamiento
                Case 2, 3 ' Artículos - PersonaDocumentoIdentidad
                    OrdenBusquedaDirecta = 0
            End Select
            Return OrdenBusquedaDirecta
        End Function

        Public Sub BuscarTipoCliente(Optional ByVal vCadenaFiltro = "")
            CompuestoObjeto2.Vista = "ListarRegistros"
            Dim NombreProcedimiento As String = CompuestoObjeto2.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, vCadenaFiltro))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    cboTipoCliente.DataSource = ds.Tables(0)
                    cboTipoCliente.DisplayMember = "Descripción"
                    cboTipoCliente.ValueMember = "Código"
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                cboTipoCliente.DataSource = Nothing
            End If
        End Sub

        Private Sub btnJalarListas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJalarListas.Click
            If dgvDetalle.RowCount = 0 Then
                MsgBox("¡Seleccione una lista de precios!", MsgBoxStyle.Information + MsgBoxStyle.Critical, Me.Text)
                Exit Sub
            End If
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vCadenaFiltrado = " WHERE PER_ID in (Select PER_ID " & _
                                                   " from vwRolPersonaTipoPersona " & _
                                                   " where PER_CLIENTE='SI' " & _
                                                         " and TPE_CLIENTE='SI' " & _
                                                         " and TPE_DESCRIPCION in('" & cboTipoCliente.Text & "') " & _
                                                         " and RTP_ESTADO='ACTIVO')" & _
                                  " and LPR_ID<>'" & txtLPR_ID.Text & "'" & _
                                  " and MON_ID='" & txtMON_ID.Text & "'" & _
                                  " and LPR_PRINCIPAL='" & cboLPR_PRINCIPAL.Text & "'"

            dgvListas.DataSource = Nothing
            CompuestoObjeto3.Vista = "BuscarRegistros"
            Dim NombreProcedimiento As String = CompuestoObjeto3.SentenciaSqlBusqueda()
            Dim ds As New DataSet
            Dim sr As New StringReader(IBCMaestro.EjecutarVista(NombreProcedimiento, " 100 percent  ", vCadenaFiltrado))
            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                Dim x As Int32 = 0
                Dim y As Int32 = 0
                Dim vCadenaGeType As String = ""
                If (ds.Tables(0).Rows.Count > 0) Then
                    dgvListas.DataSource = ds.Tables(0)
                Else
                    MsgBox("No se encontro registros", MsgBoxStyle.Information, Me.Text)
                End If
            Else
                dgvListas.DataSource = Nothing
            End If
            Me.Cursor = Windows.Forms.Cursors.Default
        End Sub

        Private Sub cboTipoCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoCliente.SelectedIndexChanged
            LimpiarDatos()
        End Sub

        Private Sub btnActualizarListas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizarListas.Click
            If dgvListas.RowCount = 0 Then Exit Sub
            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            Dim vMensajeMostrar As Int16 = 0
            Dim bRes As Boolean = False
            Dim oMsgBoxResult As New MsgBoxResult()
            Try
                oMsgBoxResult = MsgBox("¿Esta seguro de actualizar las listas de precios?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, Me.Text)
                If (oMsgBoxResult = MsgBoxResult.Yes) Then
                    Using Scope As New System.Transactions.TransactionScope()
                        If IBCListaPreciosArticulos.spDetalleListaPreciosUpdateInsert(IBCUtil.getXml(dgvDetalle, 0, 3, 9, 10, 11), IBCUtil.getXml(dgvListas, 0, 3), SessionService.UserId) > 0 Then
                            Scope.Complete()
                            vMensajeMostrar = 0
                        Else
                            Scope.Dispose()
                            vMensajeMostrar = 2
                        End If
                    End Using
                Else
                    vMensajeMostrar = 1
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message(), MsgBoxStyle.Information, Me.Text & " - Actualizar listas")
            End Try
            Me.Cursor = Windows.Forms.Cursors.Default
            MensajeOperaciones(vMensajeMostrar, "actualizado")
        End Sub
    End Class
End Namespace