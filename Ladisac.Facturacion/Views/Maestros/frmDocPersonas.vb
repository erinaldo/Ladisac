﻿Imports Microsoft.Practices.Unity
Imports System.IO
Imports Ladisac.BE
Imports System.Data
Imports System.Windows.Forms
Namespace Ladisac.Maestros.Views
    Public Class frmDocPersonas
#Region "Primaria 1"
        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        Private pLoaded As Boolean = True
        Private pRegistroNuevo As Boolean = False
        Private pColeccionDatos As Collection = Nothing
        Private pComportamiento As Int32 = 0
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusquedaConsulta As String = ""
        Private pFlagNuevo As Boolean = False

        Protected Shared vrO As Boolean = True
        Protected Shared vrM As Boolean = True
        Private pLongitudId As Integer = 0
        Private pCaracterId As String = Nothing

        Private pCodigoId As String = "" ' PER_ID
        Public vCodigoTDP_ID As String = ""

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
#End Region

#Region "Secundaria 1"
        <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()> _
        Public Property IBCDocPersonas As Ladisac.BL.IBCDocPersonas

        Private EchkPER_ESTADO As New chk
        Private EchkTDP_ESTADO As New chk
        Private EchkDOP_ESTADO As New chk

        Private EtxtPER_ID As New txt
        Private EtxtTDP_ID As New txt

        Private Simple As New Ladisac.BE.DocPersonas
        Private Simple1 As New Ladisac.BE.Personas
        Private Simple2 As New Ladisac.BE.TipoDocPersonas
        Private ErrorData As New Ladisac.BE.DocPersonas.ErrorData

        Private cMisProcedimientos As New Ladisac.MisProcedimientos

        Private Property pLongitudCampoNumero As Int16
        Public Property LongitudCampoNumero As Int16
            Get
                Return pLongitudCampoNumero
            End Get
            Set(ByVal value As Int16)
                pLongitudCampoNumero = value
            End Set
        End Property
#End Region

#Region "Primaria 2"
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

        Protected Structure chk
            Public Property pFormatearTexto As Boolean
            Public Property pNombreCampo As String
            Public Property vEstado0 As String
            Public Property vEstado1 As String
            Public Property vEstadoX As String
            Public Property pSimple As Object
            Public Property pValorDefault As System.Windows.Forms.CheckState
        End Structure
        Protected Structure txt
            Public Property pTexto1 As String
            Public Property pTexto2 As String
            Public Property pSoloNumerosDecimales As Boolean
            Public Property pSoloNumeros As Boolean
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
        Protected Structure cbo
            Public Property pNombreCampo As String
        End Structure

        Protected Structure RespuestaValidar
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
                NavegarFormulario("PrimerRegistro")
                'MsgBox("No esta disponible el desplazamiento" & Chr(13) & Chr(13) & "Ubiquese en un registro", MsgBoxStyle.Information, Me.Text)
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
                    If lblTitle.Visible Then tsBarra.Dock = System.Windows.Forms.DockStyle.None
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



        Private Sub ProcesoCrearCodigoId(ByVal vVista As String, _
                                                     ByRef oTexto As TextBox, _
                                                     ByVal oSimple As Object)
            Select Case vVista
                Case "CrearCodigoSimple"
                    Dim resp = Me.IBCBusqueda.CrearCodigoSimple(oSimple.CampoPrincipal, _
                                                                oSimple.cTabla.NombreLargo)
                    oTexto.Text = resp
                    For a = 1 To (LongitudId - Len(oTexto.Text.Trim()))
                        oTexto.Text = CaracterId & oTexto.Text
                    Next
                    oTexto.ReadOnly = True
            End Select
        End Sub


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
                If vControl.GetType.BaseType = GetType(System.Windows.Forms.PictureBox) Then
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
                If vControl.GetType.BaseType = GetType(System.Windows.Forms.DataGridView) Then
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
            Next
            If vProceso Then
                Return False
            Else
                Return vDatosControl
            End If
        End Function



        Private Function DevolverTiposCampos(ByVal oNombreCampo As String, ByVal oTexto As String, ByVal oOrm As Object) As String
            oOrm.CampoId = oNombreCampo
            oOrm.Dato = oTexto
            DevolverTiposCampos = oOrm.DevolverTiposCampos()
        End Function
        Public Sub InicializarDatos()
            OrmBusquedaDatos("InicializarDatos")
            pRegistroNuevo = False
            pColeccionDatos = RevisarDatosForm(Nothing, False)
        End Sub


        Private Sub AdicionarFilasGrid()
        End Sub

        Private Sub EliminarFilasGrid()
        End Sub



        ' generico
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
                    Nuevo = True
                    Editar = True
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



        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
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
        Private Sub frm_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                Handles MyBase.Activated
            If pComportamiento <> -1 Then
                Activado()
            End If
        End Sub
        Private Sub frm_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) _
                Handles MyBase.FormClosed
            If pComportamiento <> -1 Then
                Cerrado()
            End If
        End Sub



        Private Sub TeclasAccesoRapido(ByVal vkeyData As System.Windows.Forms.Keys)
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
        Private Sub ComportamientoFormulario()
            If pComportamiento <> -1 Then
                NombresFormulariosControles()
            End If
            pLoaded = False
        End Sub
        Private Sub NombresFormulariosControles()
        End Sub
        Public Sub FiltrarCampos(ByVal vComportamiento As Integer)
            txtDOP_NUMERO.MaxLength = LongitudCampoNumero
            txtDOP_NUMERO.Width = cMisProcedimientos.LongitudCampo(txtDOP_NUMERO, Strings.StrDup(LongitudCampoNumero, "9"))
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

        Private Sub Activado()
            ActivarBarra()
            FormatearBotonesEdicion()
        End Sub
        Private Sub ActivarBarra()
            If tsBarra.Enabled = False Then
                tsBarra.Enabled = True
            End If
        End Sub

        Private Sub Cerrado()
        End Sub



        Private Sub ValidarDatos(ByRef otxt As txt, ByRef texto As TextBox)
            With otxt
                If .pTexto1 <> .pTexto2 Then
                    .pTexto2 = texto.Text
                    If .pBusqueda Then
                        MetodoBusquedaDato(texto.Text, True, otxt)
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
#End Region

#Region "Secundaria 2"
        Private Sub LimpiarDatos()
            txtPER_ID.Text = ""
            ErrorProvider1.SetError(txtPER_ID, Nothing)

            txtPER_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtPER_DESCRIPCION, Nothing)

            chkPER_ESTADO.Checked = Nothing
            chkPER_ESTADO.CheckState = EchkPER_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkPER_ESTADO, Nothing)

            txtTDP_ID.Text = ""
            ErrorProvider1.SetError(txtTDP_ID, Nothing)

            txtTDP_DESCRIPCION.Text = ""
            ErrorProvider1.SetError(txtTDP_DESCRIPCION, Nothing)

            chkTDP_ESTADO.Checked = Nothing
            chkTDP_ESTADO.CheckState = EchkTDP_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkTDP_ESTADO, Nothing)


            txtDOP_NUMERO.Text = "0"
            ErrorProvider1.SetError(txtDOP_NUMERO, Nothing)

            chkDOP_ESTADO.Checked = Nothing
            chkDOP_ESTADO.CheckState = EchkDOP_ESTADO.pValorDefault
            ErrorProvider1.SetError(chkDOP_ESTADO, Nothing)
        End Sub

        Private Sub HabilitarNuevo()
            txtPER_ID.Enabled = True
            txtTDP_ID.Enabled = True
            txtPER_ID.ReadOnly = False
            txtTDP_ID.ReadOnly = False
        End Sub

        Private Sub ValoresDefaultNuevo()
            ColocarValoresDefault(chkPER_ESTADO)
            ColocarValoresDefault(chkTDP_ESTADO)
            ColocarValoresDefault(chkDOP_ESTADO)
        End Sub

        Public Sub ColocarValoresDefault(ByRef vObjeto As CheckBox)
            Dim vObjetoChk As New chk
            Select Case vObjeto.Name
                Case "chkPER_ESTADO"
                    vObjetoChk.pValorDefault = EchkPER_ESTADO.pValorDefault
                Case "chkTDP_ESTADO"
                    vObjetoChk.pValorDefault = EchkTDP_ESTADO.pValorDefault
                Case "chkDOP_ESTADO"
                    vObjetoChk.pValorDefault = EchkDOP_ESTADO.pValorDefault
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

        Private Sub CrearCodigoId()
        End Sub

        Private Sub HabilitarEscrituraNuevo()
            txtPER_ID.ReadOnly = False
            txtTDP_ID.ReadOnly = False
        End Sub

        Private Sub OrmBusquedaDatos(ByVal vProceso As String)
            Select Case vProceso
                Case "CancelarEdicion"
                    CodigoId = CodigoId & vCodigoTDP_ID
                Case "PrepararEliminar"
                    Simple.Vista = "RegistroAnterior"
                    Simple.PER_ID = CodigoId
                    Simple.TDP_ID = vCodigoTDP_ID
                Case "Load"
                    Simple.Vista = "PrimerRegistro"
                    Simple.PER_ID = CodigoId
                    Simple.TDP_ID = vCodigoTDP_ID
                Case "NavegarFormulario"
                    Simple.PER_ID = CodigoId
                    Simple.TDP_ID = vCodigoTDP_ID
                Case "EliminarRegistro"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TDP_ID = txtTDP_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim
                    vCodigoTDP_ID = txtTDP_ID.Text.Trim
                Case "InicializarDatos"
                    Simple.PER_ID = txtPER_ID.Text.Trim
                    Simple.TDP_ID = txtTDP_ID.Text.Trim
                    CodigoId = txtPER_ID.Text.Trim
                    vCodigoTDP_ID = txtTDP_ID.Text.Trim
            End Select
        End Sub

        Private Function Ingresar() As Boolean
            Ingresar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (InsertarDatos()) Then
                    Ingresar = True
                    MsgBox("Registro ingresado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo ingresar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.DocPersonas
            Return Ingresar
        End Function

        Private Sub DatosCabecera()
            Simple.PER_ID = Strings.Trim(txtPER_ID.Text)
            Simple.TDP_ID = Strings.Trim(txtTDP_ID.Text)

            If IsNumeric(txtDOP_NUMERO.Text) Then
                Simple.DOP_NUMERO = CDec(txtDOP_NUMERO.Text.Trim)
            Else
                txtDOP_NUMERO.Text = "0"
                Simple.DOP_NUMERO = CDec(txtDOP_NUMERO.Text.Trim)
            End If

            Simple.USU_ID = SessionService.UserId
            Simple.DOP_FEC_GRAB = Now
            Simple.DOP_ESTADO = DevolverTiposCampos(chkDOP_ESTADO)
        End Sub

        Protected Function DevolverTiposCampos(ByRef oObjeto As CheckBox) As String
            Select Case oObjeto.Name.ToString
                Case "chkPER_ESTADO"
                    Simple.CampoId = EchkPER_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkTDP_ESTADO"
                    Simple.CampoId = EchkTDP_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
                Case "chkDOP_ESTADO"
                    Simple.CampoId = EchkDOP_ESTADO.pNombreCampo
                    Simple.Dato = oObjeto.Text
            End Select
            DevolverTiposCampos = Simple.DevolverTiposCampos()
        End Function

        Protected Function Validar(ByVal vModelos As String) As Boolean
            Dim resp As New RespuestaValidar
            vrM = True
            vrO = True
            Select Case vModelos
                Case "Cabecera"
                    resp.rM = Simple.ColocarErrores(txtPER_ID, Simple.VerificarDatos("PER_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtTDP_ID, Simple.VerificarDatos("TDP_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(txtDOP_NUMERO, Simple.VerificarDatos("TDOP_NUMERO"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("USU_ID"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(lblTitle, Simple.VerificarDatos("DOP_FEC_GRAB"), ErrorProvider1)
                    resp.rM = Simple.ColocarErrores(chkDOP_ESTADO, Simple.VerificarDatos("DOP_ESTADO"), ErrorProvider1)
            End Select
            If Simple.DOP_NUMERO.Length <> LongitudCampoNumero Then
                ErrorProvider1.SetError(txtDOP_NUMERO, "La longitud del campo debe ser: " & LongitudCampoNumero)
                vrO = False
            End If
            Return vrO
        End Function

        Protected Function InsertarDatos() As Boolean
            Dim vRespuestaLocal As Short = 0
            'Simple.MarkAsAdded()
            'vRespuestaLocal = Me.IBCDocPersonas.MantenimientoDocPersonas(Simple)
            vRespuestaLocal = IBCDocPersonas.InsertarRegistro(Simple.PER_ID, Simple.TDP_ID, Simple.DOP_NUMERO, Simple.USU_ID, Simple.DOP_FEC_GRAB, Simple.DOP_ESTADO)
            InsertarDatos = (vRespuestaLocal > 0)
        End Function

        Protected Function Modificar() As Boolean
            Modificar = False
            DatosCabecera()
            If (Validar("Cabecera")) Then
                If (ActualizarDatos()) Then
                    Modificar = True
                    MsgBox("Registro modificado", MsgBoxStyle.Information, Me.Text)
                Else
                    MsgBox("No se pudo modificar verifique sus datos :" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
                End If
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.DocPersonas
            Return Modificar
        End Function

        Protected Function ActualizarDatos() As Boolean
            'Simple.MarkAsModified()
            'ActualizarDatos = (Me.IBCDocPersonas.MantenimientoDocPersonas(Simple) > 0)
            ActualizarDatos = (IBCDocPersonas.ActualizarRegistro(Simple.PER_ID, Simple.TDP_ID, Simple.DOP_NUMERO, Simple.USU_ID, Simple.DOP_FEC_GRAB, Simple.DOP_ESTADO) > 0)
        End Function

        Protected Function EliminarRegistro() As Boolean
            OrmBusquedaDatos("EliminarRegistro")
            Dim bRes As Boolean = False
            'Simple.MarkAsDeleted()
            If (IBCDocPersonas.EliminarRegistro(Simple.PER_ID, Simple.TDP_ID) > 0) Then
                'If (Me.IBCDocPersonas.MantenimientoDocPersonas(Simple) > 0) Then
                EliminarRegistro = True
                MsgBox("Registro eliminado", MsgBoxStyle.Information, Me.Text)
            Else
                EliminarRegistro = False
                MsgBox("No se pudo eliminar verifique sus datos" & Chr(13) & Chr(13) & Simple.vMensajeError, MsgBoxStyle.Information, Me.Text)
            End If
            'Simple = Nothing
            'Simple = New Ladisac.BE.DocPersonas
            Return EliminarRegistro
        End Function

        Protected Sub NavegarGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, ActiveControl, Me.Text)
        End Sub

        Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
            If keyData = Keys.Enter Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = txtPER_ID.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID" Then EtxtTDP_ID.pTexto2 = txtTDP_ID.Text
                SendKeys.Send(Chr(Keys.Tab))
                Return True
            End If
            If keyData = Keys.Tab Then
                If Me.ActiveControl.Name.ToString = "txtPER_ID" Then EtxtPER_ID.pTexto2 = txtPER_ID.Text
                If Me.ActiveControl.Name.ToString = "txtTDP_ID" Then EtxtTDP_ID.pTexto2 = txtTDP_ID.Text
            End If
            Return MyBase.ProcessDialogKey(keyData)
        End Function

        Private Sub frm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
               Handles MyBase.Load
            tsBarra.Dock = DockStyle.Top
            lblTitle.Dock = DockStyle.None
            lblTitle.Visible = False
            lblTitle.Enabled = False
            If DesignMode Then Return
            Try
                LongitudId = 2
                CaracterId = "0"
                ConfigurarCheck()
                ConfigurarText()
                ConfigurarComboBox()
                AdicionarElementoCombosEdicion()
                ComportamientoFormulario()

                If Comportamiento = -1 Then BusquedaDatos("Load")

                FormatearCampos(txtPER_ID, "PER_ID")
                'FormatearCampos(txtPER_DESCRIPCION, "PER_DESCRIPCION")
                FormatearCampos(txtTDP_ID, "TDP_ID")
                'FormatearCampos(txtTDP_DESCRIPCION, "TDP_DESCRIPCION")

                If Comportamiento <> -1 Then
                    BotonesEdicion("Seleccionar registro")
                Else
                    tsBarra.Enabled = False
                End If
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - Load")
            End Try
        End Sub

        Private Sub ConfigurarCheck()
            EchkPER_ESTADO.pFormatearTexto = True
            EchkPER_ESTADO.pNombreCampo = "PER_ESTADO"
            EchkPER_ESTADO.pSimple = Simple1
            EchkPER_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkPER_ESTADO.vEstado0 = ""
            EchkPER_ESTADO.vEstado1 = ""
            EchkPER_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkPER_ESTADO)

            EchkTDP_ESTADO.pFormatearTexto = True
            EchkTDP_ESTADO.pNombreCampo = "TDP_ESTADO"
            EchkTDP_ESTADO.pSimple = Simple2
            EchkTDP_ESTADO.pValorDefault = CheckState.Indeterminate
            EchkTDP_ESTADO.vEstado0 = ""
            EchkTDP_ESTADO.vEstado1 = ""
            EchkTDP_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkTDP_ESTADO)

            EchkDOP_ESTADO.pFormatearTexto = True
            EchkDOP_ESTADO.pNombreCampo = "DOP_ESTADO"
            EchkDOP_ESTADO.pSimple = Simple
            EchkDOP_ESTADO.pValorDefault = CheckState.Checked
            EchkDOP_ESTADO.vEstado0 = ""
            EchkDOP_ESTADO.vEstado1 = ""
            EchkDOP_ESTADO.vEstadoX = ""
            ConfigurarCheck_Refrescar(EchkDOP_ESTADO)
        End Sub

        Private Sub InicializarTexto(ByVal vObjeto As chk)
            Select Case vObjeto.pNombreCampo
                Case "PER_ESTADO"
                    With chkPER_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "TDP_ESTADO"
                    With chkTDP_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
                Case "DOP_ESTADO"
                    With chkDOP_ESTADO
                        If .CheckState = CheckState.Checked Then .Text = vObjeto.vEstado1
                        If .CheckState = CheckState.Unchecked Then .Text = vObjeto.vEstado0
                        If .CheckState = CheckState.Indeterminate Then .Text = vObjeto.vEstadoX
                    End With
            End Select
        End Sub

        Public Sub Check_Refrescar()
            InicializarTexto(EchkPER_ESTADO)
            InicializarTexto(EchkTDP_ESTADO)
            InicializarTexto(EchkDOP_ESTADO)
        End Sub

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

            EtxtPER_ID.pOOrm = New Ladisac.BE.Personas
            EtxtPER_ID.pFormularioConsulta = True

            EtxtPER_ID.pComportamiento = 1
            EtxtPER_ID.pOrdenBusqueda = 0

            EtxtTDP_ID.pTexto1 = ""
            EtxtTDP_ID.pTexto2 = ""
            EtxtTDP_ID.pSoloNumerosDecimales = False
            EtxtTDP_ID.pSoloNumeros = False
            EtxtTDP_ID.pParteEntera = 0
            EtxtTDP_ID.pParteDecimal = 0
            EtxtTDP_ID.pMinusculaMayuscula = True
            EtxtTDP_ID.pBusqueda = True
            EtxtTDP_ID.pCadenaFiltrado = ""

            EtxtTDP_ID.pOOrm = New Ladisac.BE.TipoDocPersonas
            EtxtTDP_ID.pFormularioConsulta = True

            EtxtTDP_ID.pComportamiento = 2
            EtxtTDP_ID.pOrdenBusqueda = 0
        End Sub

        Private Sub ConfigurarComboBox()
        End Sub

        Private Sub AdicionarElementoCombosEdicion()
        End Sub

        Private Function BuscarFormatos(ByRef oObjeto As cbo, ByVal oSimple As Object) As Boolean
            Return True
        End Function

        Private Sub chk_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkPER_ESTADO.CheckedChanged, chkTDP_ESTADO.CheckedChanged, chkDOP_ESTADO.CheckedChanged
            'MsgBox(sender.name.ToString)
            Select Case sender.name.ToString
                Case "chkPER_ESTADO"
                    If EchkPER_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkPER_ESTADO)
                    End If
                Case "chkTDP_ESTADO"
                    If EchkTDP_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkTDP_ESTADO)
                    End If
                Case "chkDOP_ESTADO"
                    If EchkDOP_ESTADO.pFormatearTexto Then
                        InicializarTexto(EchkDOP_ESTADO)
                    End If
            End Select
        End Sub

        Private Sub Txt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles txtPER_ID.LostFocus, txtTDP_ID.LostFocus
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    If Not txtPER_ID.ReadOnly Then
                        EtxtPER_ID.pTexto2 = sender.text
                    End If
                Case "txtTDP_ID"
                    If Not txtTDP_ID.ReadOnly Then
                        EtxtTDP_ID.pTexto2 = sender.text
                    End If
            End Select
        End Sub

        Private Sub txt_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtPER_ID.Validated, txtTDP_ID.Validated
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                Case "txtTDP_ID"
                    ValidarDatos(EtxtTDP_ID, txtTDP_ID)
            End Select
        End Sub

        Private Sub txt_OnKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtPER_ID.KeyDown, txtTDP_ID.KeyDown
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtPER_ID.ReadOnly Then
                                If EtxtPER_ID.pBusqueda Then
                                    EtxtPER_ID.pTexto2 = txtPER_ID.Text
                                    ValidarDatos(EtxtPER_ID, txtPER_ID)
                                    MetodoBusquedaDato("", False, EtxtPER_ID)
                                    EtxtPER_ID.pTexto1 = txtPER_ID.Text
                                    EtxtPER_ID.pTexto2 = txtPER_ID.Text
                                End If
                            End If
                    End Select
                Case "txtTDP_ID"
                    Select Case e.KeyCode
                        Case Keys.F1
                            If Not txtTDP_ID.ReadOnly Then
                                If EtxtTDP_ID.pBusqueda Then
                                    EtxtTDP_ID.pTexto2 = txtTDP_ID.Text
                                    ValidarDatos(EtxtTDP_ID, txtTDP_ID)
                                    MetodoBusquedaDato("", False, EtxtTDP_ID)
                                    EtxtTDP_ID.pTexto1 = txtTDP_ID.Text
                                    EtxtTDP_ID.pTexto2 = txtTDP_ID.Text
                                End If
                            End If
                    End Select
            End Select
        End Sub

        Private Sub txt_OnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
            Handles txtPER_ID.KeyPress, txtTDP_ID.KeyPress
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    If EtxtPER_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtPER_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtPER_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtPER_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If
                Case "txtTDP_ID"
                    If EtxtTDP_ID.pMinusculaMayuscula Then
                        e.KeyChar = UCase(e.KeyChar)
                    End If
                    If EtxtTDP_ID.pSoloNumerosDecimales Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 46 Then
                                If Asc(e.KeyChar) <> 8 Then
                                    e.KeyChar = ""
                                End If
                            Else
                                If EtxtTDP_ID.pParteDecimal = 0 Then
                                    e.KeyChar = ""
                                End If
                            End If
                        End If
                    End If
                    If EtxtTDP_ID.pSoloNumeros Then
                        If Not IsNumeric(e.KeyChar) Then
                            If Asc(e.KeyChar) <> 8 Then
                                e.KeyChar = ""
                            End If
                        End If
                    End If
            End Select
        End Sub

        Private Sub txt_OnDoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles txtPER_ID.DoubleClick, txtTDP_ID.DoubleClick
            Select Case sender.name.ToString
                Case "txtPER_ID"
                    If Not txtPER_ID.ReadOnly Then
                        EtxtPER_ID.pTexto2 = txtPER_ID.Text
                        ValidarDatos(EtxtPER_ID, txtPER_ID)
                        If Trim(txtPER_ID.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtPER_ID.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmPersonas)()
                        frmConsulta.DatoBusquedaConsulta = txtPER_ID.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
                Case "txtTDP_ID"
                    If Not txtTDP_ID.ReadOnly Then
                        EtxtTDP_ID.pTexto2 = txtTDP_ID.Text
                        ValidarDatos(EtxtTDP_ID, txtTDP_ID)
                        If Trim(txtTDP_ID.Text) = "" Then
                            Exit Sub
                        End If
                    End If
                    If EtxtTDP_ID.pFormularioConsulta Then
                        Dim frmConsulta = Me.ContainerService.Resolve(Of Ladisac.Maestros.Views.frmTipoDocPersonas)()
                        frmConsulta.DatoBusquedaConsulta = txtTDP_ID.Text
                        frmConsulta.MaximizeBox = False
                        frmConsulta.MinimizeBox = False
                        frmConsulta.Comportamiento = -1
                        frmConsulta.ShowDialog()
                    End If
            End Select
        End Sub
#End Region

#Region "Primaria 3"
        Private Sub BusquedaDatos(ByVal vProceso As String)
            Try
                OrmBusquedaDatos(vProceso)
                Select Case vProceso
                    Case "CancelarEdicion"
                        DatoBusquedaConsulta = CodigoId
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If Comportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "PrepararEliminar"
                        'Simple.CampoPrincipalValor = CodigoId
                        'Dim resp = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal, _
                        '                                           Simple.CampoPrincipalValor, _
                        '                                           Simple.cTabla.NombreLargo)
                        'DatoBusquedaConsulta = resp
                        DatoBusquedaConsulta = ProcesarNavegar("RegistroAnterior")
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 2
                        If Comportamiento = -1 Then
                            frm.TipoEdicion = 1
                            frm.DatoBusqueda = DatoBusquedaConsulta
                        End If
                        frm.DatoBusqueda = DatoBusquedaConsulta
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "BuscarUnRegistro"
                        DatoBusquedaConsulta = ""
                        Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = ""
                        frm.oOrm = Simple
                        frm.Comportamiento = Comportamiento
                        frm.NombreFormulario = Me
                        frm.OrdenBusqueda = OrdenBusqueda
                        frm.ShowDialog()
                        frm.Dispose()
                    Case "Load"
                        If Comportamiento = -1 Then
                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If Comportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Simple
                            frm.Comportamiento = Comportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = OrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        Else
                            OrmBusquedaDatos(vProceso)
                            Dim resp = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal, _
                                                                     Simple.cTabla.NombreLargo)
                            DatoBusquedaConsulta = resp

                            Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                            If True Then
                                frm.TipoEdicion = 2
                                If Comportamiento = -1 Then
                                    frm.TipoEdicion = 1
                                    frm.DatoBusqueda = DatoBusquedaConsulta
                                End If
                                frm.DatoBusqueda = DatoBusquedaConsulta
                            Else
                                frm.TipoEdicion = 1
                                frm.DatoBusqueda = ""
                            End If
                            frm.oOrm = Simple
                            frm.Comportamiento = Comportamiento
                            frm.NombreFormulario = Me
                            frm.OrdenBusqueda = OrdenBusqueda
                            frm.ShowDialog()
                            frm.Dispose()
                        End If
                End Select
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - BusquedaDatos")
            End Try
        End Sub

        Private Sub NavegarFormulario(ByVal Metodo As String)
            Try
                If pnCuerpo.Enabled = True Then If RevisarDatos(False) Then Return
                Dim vCodigoId As String
                Dim resp As String = ""
                OrmBusquedaDatos("NavegarFormulario")

                'Select Case Metodo
                '    Case "PrimerRegistro"
                '        resp = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                             Simple.cTabla.NombreLargo)
                '    Case "RegistroAnterior"
                '        Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                '        resp = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                               Simple.CampoPrincipalValor, _
                '                                               Simple.cTabla.NombreLargo)
                '    Case "RegistroSiguiente"
                '        Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                '        resp = Me.IBCBusqueda.RegistroSiguiente(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                                Simple.CampoPrincipalValor, _
                '                                                Simple.cTabla.NombreLargo)
                '    Case "UltimoRegistro"
                '        resp = Me.IBCBusqueda.UltimoRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                '                                             Simple.cTabla.NombreLargo)
                'End Select

                vCodigoId = ProcesarNavegar(Metodo)
                'vCodigoId = resp

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
                If Comportamiento = -1 Then
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = DatoBusquedaConsulta
                End If
                frm.DatoBusqueda = DatoBusquedaConsulta
                frm.oOrm = Simple
                frm.Comportamiento = Comportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = OrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
                BotonesEdicion("Seleccionar registro")
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - NavegarFormulario")
            End Try
        End Sub

        Private Function ProcesarNavegar(ByVal Metodo As String)
            ProcesarNavegar = ""
            Select Case Metodo
                Case "PrimerRegistro"
                    ProcesarNavegar = Me.IBCBusqueda.PrimerRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                                                         Simple.cTabla.NombreLargo)
                Case "RegistroAnterior"
                    Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                    ProcesarNavegar = Me.IBCBusqueda.RegistroAnterior(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                                                           Simple.CampoPrincipalValor, _
                                                           Simple.cTabla.NombreLargo)
                Case "RegistroSiguiente"
                    Simple.CampoPrincipalValor = CodigoId & vCodigoTDP_ID
                    ProcesarNavegar = Me.IBCBusqueda.RegistroSiguiente(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                                                            Simple.CampoPrincipalValor, _
                                                            Simple.cTabla.NombreLargo)
                Case "UltimoRegistro"
                    ProcesarNavegar = Me.IBCBusqueda.UltimoRegistro(Simple.CampoPrincipal & "+" & Simple.CampoPrincipalSecundario, _
                                                         Simple.cTabla.NombreLargo)
            End Select
            Return ProcesarNavegar
        End Function

        Private Sub FormatearCampos(ByRef oObjeto As Object, ByVal NombreCampo As String)
            FormatearCampos(oObjeto, NombreCampo, Simple.vArrayDatosComboBox, Simple.vElementosDatosComboBox - 1)
        End Sub

        Private Sub MetodoBusquedaDato(ByVal vDatoBusqueda As String, _
                                      ByVal vBusquedaDirecta As Boolean, _
                                      ByVal vtxt As txt)
            Try
                Dim frm = Me.ContainerService.Resolve(Of Ladisac.frmBusqueda)()
                If vBusquedaDirecta Then
                    frm.TipoEdicion = 2
                    If Comportamiento = -1 Then
                        frm.TipoEdicion = 1
                        frm.DatoBusqueda = vDatoBusqueda
                    End If
                    frm.DatoBusqueda = vDatoBusqueda
                Else
                    frm.TipoEdicion = 1
                    frm.DatoBusqueda = ""
                End If
                frm.oOrm = vtxt.pOOrm
                frm.Comportamiento = vtxt.pComportamiento
                frm.NombreFormulario = Me
                frm.OrdenBusqueda = vtxt.pOrdenBusqueda
                frm.ShowDialog()
                frm.Dispose()
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - MetodoBusquedaDato")
            End Try
        End Sub

#End Region
    End Class
End Namespace