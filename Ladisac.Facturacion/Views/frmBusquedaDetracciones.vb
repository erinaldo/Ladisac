﻿Imports Microsoft.Practices.Unity
Imports System.Data
Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing

Namespace Ladisac
    Public Class frmBusquedaDetracciones
 <Dependency()>
        Public Property SessionService As Ladisac.Foundation.Services.ISessionService

        <Dependency()>
        Public Property IBCMaestro As Ladisac.BL.IBCMaestro

        <Dependency()>
        Public Property BCVariablesNames As Ladisac.BL.BCVariablesNames


        <Dependency()> _
        Public Property IBCBusqueda As Ladisac.BL.IBCBusqueda

        Public Property pDatosBuscados As String = ""

        Private vTextoCboBuscar As String = ""
        Private OcultarCamposProcesado As Boolean = False
        Private pLoaded As Boolean = True
        Private pTipoEdicion As Int16 = 1
        Private pOrdenBusqueda As Int32 = 0
        Private pDatoBusqueda As String
        Public pFlagCambioDatoBusqueda As Boolean = False
        Private pMostrarDatosGrid As Boolean = False
        Private pSeleccionarTodosEnMarcados As Boolean = False
        Private pTotalizarCampo As Boolean = False
        Private pNombreCampoTotalizar As String = ""
        Private vRefrescarBusqueda As Boolean = False
        Private vSaltar As Boolean = False
        Public vEnTiempoReal As Boolean = False
        Private vDataSourceGrid As Boolean = True
        Private pNombreFormulario As New Ladisac.Foundation.Views.ViewManMaster
        'Public pImporteDesdeDocumento As Boolean = False
        Public pVerificarMonto As Boolean = False
        Public pVerificarMontoSoloNuevosRegistro As Boolean = True
        Public pDevolverDatosUnicoRegistro As Boolean = False
        Public pDgvConMarcado As Boolean = False

        Private vFlagCabeceraColumnaGrid As Boolean = False


        Public pAumentarLetraGrilla As Boolean = False

        Private pComportamiento As Int32 = 0
        Public oOrm As New Object
        Private vArrayDatosComboBox() As Ladisac.MisProcedimientos.DatosComboBox
        Public pCantidadRegistros As Int32 = 100
        Private pFilaGrid As Int16 = 0

        Private pOkbusqueda As Boolean = True
        Private pInicio As Boolean = True
        Private pAnterior As Boolean = True
        Private pSiguiente As Boolean = True
        Private pFinal As Boolean = True
        Private pSalida As Boolean = True

        Private vPosActualX As Int16
        Private vPosActualY As Int16

        Private dv As New DataView

        Protected vClaseDibujar As New Ladisac.ClaseDibujar
        Protected cMisProcedimientos As New Ladisac.MisProcedimientos
        Protected sConfigurarDataGrid As New Ladisac.MisProcedimientos.ConfigurarDataGrid

        Public ReadOnly Property Loaded() As Boolean
            Get
                Return pLoaded
            End Get
        End Property
        Public Property TipoEdicion() As Int16
            Get
                Return pTipoEdicion
            End Get
            Set(ByVal value As Int16)
                If value = 1 Or value = 2 Then
                    pTipoEdicion = value
                Else
                    pTipoEdicion = 1
                End If

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
        Public Property DatoBusqueda() As String
            Get
                Return pDatoBusqueda
            End Get
            Set(ByVal value As String)
                pDatoBusqueda = value
            End Set
        End Property
        Public Property MostrarDatosGrid() As Boolean
            Get
                Return pMostrarDatosGrid
            End Get
            Set(ByVal value As Boolean)
                pMostrarDatosGrid = value
            End Set
        End Property
        Public Property SeleccionarTodosEnMarcados() As Boolean
            Get
                Return pSeleccionarTodosEnMarcados
            End Get
            Set(ByVal value As Boolean)
                pSeleccionarTodosEnMarcados = value
            End Set
        End Property
        Public Property TotalizarCampo() As Boolean
            Get
                Return pTotalizarCampo
            End Get
            Set(ByVal value As Boolean)
                pTotalizarCampo = value
            End Set
        End Property
        Public Property NombreCampoTotalizar() As String
            Get
                Return pNombreCampoTotalizar
            End Get
            Set(ByVal value As String)
                pNombreCampoTotalizar = value
            End Set
        End Property

        Public Property NombreFormulario() As Object
            Set(ByVal value As Object)
                pNombreFormulario = value
            End Set
            Get
                Return pNombreFormulario
            End Get
        End Property
        Public Property Comportamiento() As Int32
            Get
                Return pComportamiento
            End Get
            Set(ByVal value As Int32)
                pComportamiento = value
            End Set
        End Property

        Public Property OkBusqueda() As Boolean
            Set(ByVal value As Boolean)
                pOkbusqueda = value
            End Set
            Get
                Return pOkbusqueda
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
        Public Property Salida() As Boolean
            Set(ByVal value As Boolean)
                pSalida = value
            End Set
            Get
                Return pSalida
            End Get
        End Property

        Protected Overridable Sub SubBarra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            tsbOkBusqueda.Click, tsbInicio.Click, tsbAnterior.Click, tsbSiguiente.Click, tsbFinal.Click, tsbSalir.Click
            LlamarMetodo(sender.ToString)
        End Sub
        Public Sub LlamarMetodo(ByVal NombreMetodo As String)
            Select Case NombreMetodo
                Case "DevolverDatos"
                    DevolverDatos()
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

        Public Sub DevolverDatos()
            Try
                If TipoEdicion = 2 Then
                    If dgvDatos.RowCount <> 1 Then
                        InicializarDatos()
                        Me.Close()
                        Exit Sub
                    End If
                End If

                If dgvDatos.RowCount <= 0 Then
                    Me.Close()
                    Return
                End If

                With dgvDatos.SelectedRows(0)
                    If (.Selected()) Then
                        Select Case NombreFormulario.name.ToString
                            ' Maestros
                            Case "frmDatosUsuarios"
                                DatosUsuarios()
                                If vSaltar Then Exit Sub
                            Case "frmPuntoVentaDatosUsuarios"
                                PuntoVentaDatosUsuarios()
                                If vSaltar Then Exit Sub

                            Case "frmRolArticulosTipoArticulos"
                                RolArticulosTipoArticulos()
                                If vSaltar Then Exit Sub
                            Case "frmRolAlmacenTipoArticulos"
                                RolAlmacenTipoArticulos()
                                If vSaltar Then Exit Sub
                            Case "frmPesosArticulos"
                                PesosArticulos()
                                If vSaltar Then Exit Sub

                            Case "frmTipoUnidad"
                                TipoUnidad()
                                If vSaltar Then Exit Sub
                            Case "frmConfiguracionVehicular"
                                ConfiguracionVehicular()
                                If vSaltar Then Exit Sub
                            Case "frmUnidadesTransporte"
                                UnidadesTransporte()
                                If vSaltar Then Exit Sub
                            Case "frmPlacas"
                                Placas()
                                If vSaltar Then Exit Sub

                            Case "frmDireccionesPersonas"
                                DireccionesPersonas()
                                If vSaltar Then Exit Sub
                            Case "frmContactoPersona"
                                ContactoPersona()
                                If vSaltar Then Exit Sub
                            Case "frmTipoDocPersonas"
                                TipoDocPersonas()
                                If vSaltar Then Exit Sub
                            Case "frmDocPersonas"
                                DocPersonas()
                                If vSaltar Then Exit Sub
                            Case "frmPersonas"
                                Personas()
                                If vSaltar Then Exit Sub
                            Case "frmTipoPersonas"
                                TipoPersonas()
                                If vSaltar Then Exit Sub
                            Case "frmRolPersonaTipoPersona"
                                RolPersonaTipoPersona()
                                If vSaltar Then Exit Sub
                            Case "frmBloqueosCodigoPersona"
                                BloqueosCodigoPersona()
                                If vSaltar Then Exit Sub

                            Case "frmPais"
                                Pais()
                                If vSaltar Then Exit Sub
                            Case "frmDepartamento"
                                Departamento()
                                If vSaltar Then Exit Sub
                            Case "frmProvincia"
                                Provincia()
                                If vSaltar Then Exit Sub
                            Case "frmDistrito"
                                Distrito()
                                If vSaltar Then Exit Sub
                            Case "frmPuntoVenta"
                                PuntoVenta()
                                If vSaltar Then Exit Sub

                            Case "frmMoneda"
                                Moneda()
                                If vSaltar Then Exit Sub
                            Case "frmTipoCambioMoneda"
                                TipoCambioMoneda()
                                If vSaltar Then Exit Sub


                            Case "frmCorrelativoTipoDocumento"
                                CorrelativoTipoDocumento()
                                If vSaltar Then Exit Sub

                            Case "frmRolPuntoVentaAlmacen"
                                RolPuntoVentaAlmacen()
                                If vSaltar Then Exit Sub

                            Case "frmCierre"
                                Cierre()
                                If vSaltar Then Exit Sub

                            Case "frmCierreDiario"
                                CierreDiario()
                                If vSaltar Then Exit Sub

                            Case "frmRolOpeCtaCte"
                                RolOpeCtaCte()
                                If vSaltar Then Exit Sub

                                ' Facturación
                            Case "frmRestriccionArticulo"
                                RestriccionArticulo()
                                If vSaltar Then Exit Sub

                            Case "frmComision"
                                Comision()
                                If vSaltar Then Exit Sub
                            Case "frmTipoDocumentos"
                                TipoDocumentos()
                                If vSaltar Then Exit Sub
                            Case "frmFletesTransportes"
                                FletesTransportes()
                                If vSaltar Then Exit Sub
                            Case "frmDocumentos", "frmPedidoBoletaFactura", _
                                 "frmProformaFacturas", "frmOrdenCompraBoletas", "frmOrdenCompraFacturas", _
                                 "frmBoletas", "frmBoletas01", "frmBoletas02", "frmBoletas03", "frmBoletas04", _
                                 "frmFacturas", "frmFacturas01", "frmFacturas02", "frmFacturas03", "frmFacturas04", _
                                 "frmNotaCredito", "frmNotaDebito", "frmTipoVentaBoletaFactura"
                                Documentos()
                                If vSaltar Then Exit Sub
                                NombreFormulario.pBusquedaDevolvioDatos = True
                            Case "frmGenerarDocumentoPromocion"
                                GenerarDocumentoPromocion()
                                If vSaltar Then Exit Sub

                            Case "frmDocumentosEmitidos", "frmDocumentosEmitidosPorPromotor"
                                DocumentosEmitidos()
                                If vSaltar Then Exit Sub

                                ' Despachos
                            Case "frmGuiaDespacho", "frmGuiaDevolucion", "frmGuiaIngreso", "frmGuiaSalida", _
                                 "frmGuiaTransferencia", "frmCronogramaDespacho", "frmGuiaDespachoDesdeDistribuidora", "frmGuiaDevolucionDesdeDistribuidora"
                                Despachos()
                                If vSaltar Then Exit Sub
                            Case "frmControlGarita"
                                Try
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.pPVE_ID, dgvDatos, "PVE_ID")
                                Catch ex As Exception
                                End Try
                                MarcarSalidaGuia()
                                If vSaltar Then Exit Sub
                            Case "frmKardexDocumento", "frmPendientesAtencion", "frmEntregaDespachos", "frmToneladasMillaresVentas", "frmTrasladoEntreAlmacenes", "frmDetalleVentaPorArticulo", "frmReporteGuias", "frmReporteGuiasProduccion"
                                KardexDocumento()
                                If vSaltar Then Exit Sub
                            Case "frmGuiaRemisionTransportista"
                                GuiasRemision()
                                If vSaltar Then Exit Sub
                            Case "frmReporteCronogramaDespacho"
                                ReporteCronogramaDespacho()
                                If vSaltar Then Exit Sub

                                ' Tesorería
                            Case "frmCajaCtaCte"
                                CajaCtaCte()
                                If vSaltar Then Exit Sub
                            Case "frmCheques"
                                Cheques()
                                If vSaltar Then Exit Sub
                            Case "frmTesoreriaEditar"
                                TesoreriaEditar()
                                If vSaltar Then Exit Sub
                            Case "frmCajeroAnexo"
                                CajeroAnexo()
                                If vSaltar Then Exit Sub

                            Case "frmReciboIngresos", "frmReciboIngresos01", "frmReciboIngresos02", "frmReciboIngresos03", "frmReciboIngresos04", _
                                 "frmReciboEgresos", "frmReciboEgresos01", "frmReciboEgresos02", "frmReciboEgresos03", "frmReciboEgresos04", _
                                 "frmPlanillaEgresos", "frmTransferenciaEntreCajas", "frmDepositosBancarios", "frmDepositoTercero", "frmNotaAbonoCtaBanco", "frmBancoEgresos", "frmVoucherCheque", "frmNotaCargoCtaBanco", "frmDetraccionesNotaCargoCtaBanco", "frmConsultasTesoreria"
                                Tesoreria()
                                If vSaltar Then Exit Sub

                            Case "frmMovimientoCajaBancos"
                                MovimientoCajaBancos()
                                If vSaltar Then Exit Sub

                                ' Cuentas Corrientes
                            Case "frmListaPreciosArticulos"
                                ListaPreciosArticulos()
                                If vSaltar Then Exit Sub
                            Case "frmDescuentoIncrementoTipoVentaPersonas"
                                DescuentoIncrementoTipoVentaPersonas()
                                If vSaltar Then Exit Sub

                            Case "frmTipoVenta"
                                TipoVenta()
                                If vSaltar Then Exit Sub
                            Case "frmPermisoCuentaCorriente"
                                PermisoCuentaCorriente()
                                If vSaltar Then Exit Sub

                            Case "frmCartaFianza"
                                CartaFianza()
                                If vSaltar Then Exit Sub

                            Case "frmLiquidacionDocumento", "frmPlanillaRendicionCuentas"
                                Tesoreria()
                                If vSaltar Then Exit Sub

                            Case "frmKardexCtaCte"
                                KardexCtaCte()
                                If vSaltar Then Exit Sub
                            Case "frmReporteListaPrecios"
                                ReporteListaPrecios()
                                If vSaltar Then Exit Sub


                                ' Activos Fijos
                            Case "frmIncidencias"
                                Incidencias()
                                If vSaltar Then Exit Sub
                            Case "frmCuentasActivos"
                                CuentasActivos()
                                If vSaltar Then Exit Sub
                            Case "frmEdificios"
                                Edificios()
                                If vSaltar Then Exit Sub
                            Case "frmOficinas"
                                Oficinas()
                                If vSaltar Then Exit Sub
                            Case "frmDepartamentosAdministrativos"
                                DepartamentosAdministrativos()
                                If vSaltar Then Exit Sub
                        End Select
                        Me.Close()
                    Else
                        MsgBox("Seleccione un registro", MsgBoxStyle.Information, Me.Text)
                    End If
                End With
            Catch ex As Exception
                MsgBox(Err.Number & " - " & ex.Message, MsgBoxStyle.Information, Me.Text & " - DevolverDatos")
            End Try
        End Sub
        Public Sub InicializarDatos()
            Select Case NombreFormulario.name.ToString
                ' Maestros
                Case "frmDatosUsuarios"
                    DatosUsuariosI()
                Case "frmPuntoVentaDatosUsuarios"
                    PuntoVentaDatosUsuariosI()

                Case "frmRolAlmacenTipoArticulos"
                    RolAlmacenTipoArticulosI()
                Case "frmPesosArticulos"
                    PesosArticulosI()

                Case "frmTipoUnidad"
                    TipoUnidadI()
                Case "frmConfiguracionVehicular"
                    ConfiguracionVehicularI()
                Case "frmUnidadesTransporte"
                    UnidadesTransporteI()
                Case "frmPlacas"
                    PlacasI()

                Case "frmDepartamento"
                    DepartamentoI()
                Case "frmProvincia"
                    ProvinciaI()
                Case "frmDistrito"
                    DistritoI()
                Case "frmPuntoVenta"
                    PuntoVentaI()

                Case "frmPersonas"
                    PersonasI()
                Case "frmDireccionesPersonas"
                    DireccionesPersonasI()
                Case "frmDocPersonas"
                    DocPersonasI()
                Case "frmTipoPersonas"
                    TipoPersonasI()
                Case "frmRolPersonaTipoPersona"
                    RolPersonaTipoPersonaI()
                Case "frmBloqueosCodigoPersona"
                    BloqueosCodigoPersonaI()

                Case "frmCorrelativoTipoDocumento"
                    CorrelativoTipoDocumentoI()

                Case "frmTipoCambioMoneda"
                    TipoCambioMonedaI()

                Case "frmRolPuntoVentaAlmacen"
                    RolPuntoVentaAlmacenI()

                Case "frmCierre"
                    CierreI()

                Case "frmCierreDiario"
                    CierreDiarioI()

                Case "frmRolOpeCtaCte"
                    RolOpeCtaCteI()

                    ' Facturación
                Case "frmRestriccionArticulo"
                    RestriccionArticuloI()
                Case "frmDocumentosEmitidos", "frmDocumentosEmitidosPorPromotor"
                    DocumentosEmitidosI(Comportamiento)

                Case "frmTipoDocumentos"
                    'TipoDocumentosI()
                Case "frmFletesTransportes"
                    FletesTransportesI()

                Case "frmPedidoBoletaFactura", "frmProformaFacturas", "frmOrdenCompraBoletas", "frmOrdenCompraFacturas", "frmBoletas", "frmBoletas01", "frmBoletas02", "frmBoletas03", "frmBoletas04", "frmFacturas", "frmFacturas01", "frmFacturas02", "frmFacturas03", "frmFacturas04", "frmNotaCredito", "frmNotaDebito", "frmTipoVentaBoletaFactura"
                    DocumentosI(Comportamiento)
                    NombreFormulario.pBusquedaDevolvioDatos = True

                Case "frmGenerarDocumentoPromocion"
                    GenerarDocumentoPromocionI(Comportamiento)

                    ' Despachos
                Case "frmGuiaDespacho", "frmGuiaDevolucion", "frmGuiaIngreso", "frmGuiaSalida", _
                     "frmGuiaTransferencia", "frmCronogramaDespacho", "frmGuiaDespachoDesdeDistribuidora", "frmGuiaDevolucionDesdeDistribuidora"
                    DespachosI(Comportamiento)
                    NombreFormulario.pBusquedaDevolvioDatos = True
                Case "frmControlGarita"
                    MarcarSalidaGuiaI(Comportamiento)
                    NombreFormulario.pBusquedaDevolvioDatos = True
                Case "frmKardexDocumento", "frmPendientesAtencion", "frmEntregaDespachos", "frmToneladasMillaresVentas", "frmTrasladoEntreAlmacenes", "frmDetalleVentaPorArticulo", "frmReporteGuias", "frmReporteGuiasProduccion"
                    KardexDocumentoI()
                Case "frmGuiaRemisionTransportista"
                    GuiasRemisionI()
                Case "frmReporteCronogramaDespacho"
                    ReporteCronogramaDespachoI()

                    ' Tesorería
                Case "frmCajaCtaCte"
                    CajaCtaCteI()
                Case "frmCheques"
                    ChequesI()
                Case "frmTesoreriaEditar"
                    TesoreriaEditarI()
                Case "frmCajeroAnexo"
                    CajeroAnexoI()


                Case "frmReciboIngresos", "frmReciboIngresos01", "frmReciboIngresos02", "frmReciboIngresos03", "frmReciboIngresos04", _
                     "frmReciboEgresos", "frmReciboEgresos01", "frmReciboEgresos02", "frmReciboEgresos03", "frmReciboEgresos04", _
                     "frmPlanillaEgresos", "frmTransferenciaEntreCajas", "frmDepositosBancarios", "frmDepositoTercero", _
                     "frmNotaAbonoCtaBanco", "frmBancoEgresos", "frmVoucherCheque", _
                     "frmNotaCargoCtaBanco", "frmDetraccionesNotaCargoCtaBanco", _
                     "frmConsultasTesoreria"
                    If NombreFormulario.VerificarClienteDocumento(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv) And Comportamiento = 17 Then
                        TesoreriaI(-17)
                    Else
                        TesoreriaI(Comportamiento)
                    End If


                Case "frmMovimientoCajaBancos"
                    MovimientoCajaBancosI()

                    'Cuentas Corrientes
                Case "frmListaPreciosArticulos"
                    ListaPreciosArticulosI()
                Case "frmDescuentoIncrementoTipoVentaPersonas"
                    DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                Case "frmCartaFianza"
                    CartaFianzaI()
                Case "frmPlanillaRendicionCuentas"
                    TesoreriaI(Comportamiento)
                Case "frmLiquidacionDocumento" ', "frmPlanillaRendicionCuentas" 
                    Try
                        If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvDetalle.Item("cCUC_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value) _
                           And Comportamiento = 15 Then
                            TesoreriaI(-15)
                        ElseIf Trim(NombreFormulario.dgvDetalle.Item("cPER_ID_CLI_1", NombreFormulario.dgvDetalle.CurrentRow.Index).Value.ToString) <> "" _
                            And Comportamiento = 18 Then
                            TesoreriaI(-18)
                        Else
                            TesoreriaI(Comportamiento)
                        End If
                    Catch ex As Exception
                        TesoreriaI(Comportamiento)
                    End Try
                Case "frmKardexCtaCte"
                    KardexCtaCteI()
                Case "frmReporteListaPrecios"
                    ReporteListaPreciosI()

                    'Activos Fijos
                Case "frmCuentasActivos"
                    CuentasActivosI()
                Case "frmEdificios"
                    EdificiosI()
                Case "frmOficinas"
                    OficinasI()
                Case "frmDepartamentosAdministrativos"
                    DepartamentosAdministrativosI()
            End Select
        End Sub

        Public Function FormatearNumero(ByVal oOrm As Object, ByVal NombreCampo As String, ByVal Valor As String) As String
            FormatearNumero = Valor
            For Fila = 0 To oOrm.vElementosDatosComboBox - 1
                If oOrm.vArrayDatosComboBox(Fila).NombreCampo.ToString = NombreCampo Then
                    Dim completar As Int16 = oOrm.vArrayDatosComboBox(Fila).Longitud - Len(Trim(Valor))
                    If completar > 0 Then
                        FormatearNumero = Strings.StrDup(completar, "0") & Valor
                    End If
                    Exit For
                End If
            Next
            Return FormatearNumero
        End Function
        Protected Overridable Function DevolverTiposCampos(ByVal NombreCampo As String, _
                                                           ByVal Dato As String, _
                                                           ByVal oOrm1 As Object) As String
            oOrm1.CampoId = NombreCampo
            oOrm1.Dato = Dato
            DevolverTiposCampos = oOrm1.DevolverTiposCampos()
        End Function

        Public Overridable Sub PosicionGrid(ByVal Metodo As String)
            cMisProcedimientos.PosicionGrid(Metodo, dgvDatos, Me.Text)
        End Sub
        Protected Overridable Sub ConfigurarGrid(ByVal vProceso As String)
            Select Case vProceso
                Case "Load"
                    sConfigurarDataGrid.Array = Nothing
                    cMisProcedimientos.AdicionarNumeroColumnaArray(sConfigurarDataGrid.Array, oOrm.vArrayCamposBusqueda)
            End Select
        End Sub
        Private Sub dgvDatos_RowHeaderMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dgvDatos.RowHeaderMouseDoubleClick
            If dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect Then
                If pDgvConMarcado Then
                Else
                    DevolverDatos()
                    Return
                End If
            End If
        End Sub
        Private Sub dgvDatos_RowHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) _
            Handles dgvDatos.RowHeaderMouseClick
            If dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect Then
                If pDgvConMarcado Then
                    If vFlagCabeceraColumnaGrid = True Then
                        vFlagCabeceraColumnaGrid = False
                        Exit Sub
                    End If
                    vFlagCabeceraColumnaGrid = False
                    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

                    If pDgvConMarcado Then
                        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
                        If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                            dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Black
                            dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                            dgvDatos.SelectedRows(0).Cells("Marcado").Value = 0
                            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
                            If pTotalizarCampo Then
                                txtTotal.Text = Val(txtTotal.Text) - dgvDatos.SelectedRows(0).Cells(pNombreCampoTotalizar).Value
                            End If
                        Else
                            dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Red
                            dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                            dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1
                            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                            If pTotalizarCampo Then
                                txtTotal.Text = Val(txtTotal.Text) + dgvDatos.SelectedRows(0).Cells(pNombreCampoTotalizar).Value
                            End If
                        End If
                        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                        Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
                    End If

                End If
            End If
        End Sub
        Private Sub dgvDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellDoubleClick
            If dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect Then
                If pDgvConMarcado Then
                Else
                    DevolverDatos()
                    Return
                End If
            End If
        End Sub
        Private Sub dgvDatos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.CellContentClick
            If vFlagCabeceraColumnaGrid = True Then
                vFlagCabeceraColumnaGrid = False
                Exit Sub
            End If
            vFlagCabeceraColumnaGrid = False
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

            If pDgvConMarcado Then
                DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
                If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                    dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Black
                    dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                    dgvDatos.SelectedRows(0).Cells("Marcado").Value = 0
                    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
                    If pTotalizarCampo Then
                        txtTotal.Text = Val(txtTotal.Text) - dgvDatos.SelectedRows(0).Cells(pNombreCampoTotalizar).Value
                    End If
                Else
                    dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Red
                    dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                    dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1
                    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                    If pTotalizarCampo Then
                        txtTotal.Text = Val(txtTotal.Text) + dgvDatos.SelectedRows(0).Cells(pNombreCampoTotalizar).Value
                    End If
                End If
                DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
                FormatearColorMarcados()
            End If
        End Sub
        Private Sub dgvDatos_ColumnHeaderMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvDatos.ColumnHeaderMouseClick
            vFlagCabeceraColumnaGrid = True

            cboBuscar.Text = sender.Columns(e.ColumnIndex).name.ToString
            ColorearFilas()
            FormatearColorMarcados()
            If pDgvConMarcado Then
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
                If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                    dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Red
                    dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                Else
                    dgvDatos.SelectedRows(0).DefaultCellStyle.ForeColor = Drawing.Color.Black
                    dgvDatos.SelectedRows(0).DefaultCellStyle.BackColor = Drawing.Color.White
                    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
                End If
                DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
            End If
        End Sub
        Private Sub dgvDatos_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDatos.RowEnter
            If pDgvConMarcado Then
                Try
                    If Not IsNothing(dgvDatos.Rows.Count) Then
                        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
                        If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                        Else
                            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
                        End If
                        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                        Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
                    End If
                Catch ex As Exception

                End Try
            End If
        End Sub
        Private Sub dgvDatos_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles dgvDatos.CellValidating
            pFilaGrid = e.RowIndex
        End Sub

        Public Overridable Sub Salir()
            Me.Close()
        End Sub

        Protected Overridable Sub RefrescarBusqueda(ByVal sender As System.Object, ByVal e As System.EventArgs) _
            Handles chkTipoBusqueda.CheckedChanged, _
            txtBuscar.TextChanged, _
            cboDatoBuscar.TextChanged
            If pTipoEdicion = 2 Then Return
            If vRefrescarBusqueda Then Return
            If cboBuscar.Text.Trim = "" Then Return
            If Not vEnTiempoReal Then Return
            If cboDatoBuscar.Enabled Then Buscar(DatosCboBuscar)
            If txtBuscar.Enabled Then Buscar(txtBuscar.Text)
        End Sub
        Private Sub txtBuscar_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
            Handles txtBuscar.KeyUp
            If e.KeyData = Keys.Enter Then
                If chkBusquedaTiempoReal.CheckState = CheckState.Unchecked Then btnBuscar.PerformClick()
            End If
        End Sub

        Protected Overridable Sub Buscar(ByVal sBuscar As String)
            If pLoaded Then
                OcultarCampos()
                Return
            End If

            If Not vEnTiempoReal Then
                OcultarCampos()
                If cboDatoBuscar.Enabled Then cboDatoBuscar.Focus()
                If txtBuscar.Enabled Then txtBuscar.Focus()
                chkTipoBusqueda.CheckState = CheckState.Checked
                If pMostrarDatosGrid Then
                    btnBuscar.PerformClick()
                    If pDevolverDatosUnicoRegistro Then
                        If dgvDatos.RowCount = 1 Then
                            LlamarMetodo("DevolverDatos")
                        End If
                    End If
                End If
                Return
            End If

            Me.Cursor = Windows.Forms.Cursors.WaitCursor

            If cboBuscar.Text = "DOC_NUMERO" Then
                sBuscar = cMisProcedimientos.VerificarLongitud(sBuscar, 10)
            End If

            Dim vFiltro As String = "%'"
            Dim vTipoBusqueda As String = ""
            If chkTipoBusqueda.Checked Then vTipoBusqueda = "%"
            If oOrm.pBuscarRegistros Then oOrm.Vista = "BuscarRegistros"

            Dim NombreProcedimiento As String = oOrm.SentenciaSqlBusqueda()
            Dim FiltroProcedimiento As String = ""
            If cboDatoBuscar.Enabled And chkTipoBusqueda.Checked Then vFiltro = "%'"
            If cboDatoBuscar.Enabled Then vFiltro = "'"

            If pTipoEdicion = 2 Or pComportamiento = -1 Then
                If oOrm.FlagCampoPrincipal = 2 Then
                    If cboBuscar.Text = oOrm.CampoPrincipal Or _
                       cboBuscar.Text = oOrm.CampoPrincipalSecundario Then
                        FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + cast(" & oOrm.CampoPrincipalSecundario & " as varchar) " & _
                                               " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    Else
                        FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    End If
                ElseIf oOrm.FlagCampoPrincipal = 3 Then
                    If cboBuscar.Text = oOrm.CampoPrincipal Or _
                       cboBuscar.Text = oOrm.CampoPrincipalSecundario Or _
                       cboBuscar.Text = oOrm.CampoPrincipalTercero Then
                        If NombreFormulario.name.ToString = "frmRestriccionArticulo" Then
                            FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + cast(" & oOrm.CampoPrincipalSecundario & " as varchar) + convert(varchar," & oOrm.CampoPrincipalTercero & ", 103) " & _
                                                   " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                        Else
                            FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + cast(" & oOrm.CampoPrincipalSecundario & " as varchar) + convert(varchar," & oOrm.CampoPrincipalTercero & ", 112) " & _
                                                   " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                        End If
                    Else
                        FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    End If
                ElseIf oOrm.FlagCampoPrincipal = 4 Then
                    Select Case oOrm.cTabla.NombreCorto
                        Case "SaldosKardexDocumentos"
                            Select Case oOrm.Vista
                                ''Case "VistaSaldoDTD"
                                Case "VistaSaldoDTDNuevo"
                                    FiltroProcedimiento &= " AND " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                Case Else
                                    Select Case UCase(cboBuscar.Text)
                                        Case "SALDO"
                                            FiltroProcedimiento &= " AND " & "SUM(CARGO)-SUM(ABONO)" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                        Case "CCT_DESCRIPCION_REF", "PER_DESCRIPCION_CLI", "TDO_DESCRIPCION_REF", "DTD_DESCRIPCION_REF", "MON_DESCRIPCION"
                                            FiltroProcedimiento &= " AND " & "max(" & cboBuscar.Text & ")" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                        Case "DOC_FECHA_EMI_REF", "DOC_FECHA_VEN_REF"
                                            FiltroProcedimiento &= " AND " & "min(cast(" & cboBuscar.Text & " as DATE))" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                        Case Else
                                            FiltroProcedimiento &= " AND " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                    End Select
                            End Select
                        Case Else
                            If cboBuscar.Text = oOrm.CampoPrincipal Or _
                               cboBuscar.Text = oOrm.CampoPrincipalSecundario Or _
                               cboBuscar.Text = oOrm.CampoPrincipalTercero Or _
                               cboBuscar.Text = oOrm.CampoPrincipalCuarto Then
                                FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + " & _
                                                              "rtrim(ltrim(cast(isnull(" & oOrm.CampoPrincipalSecundario & ",'') as varchar))) + " & _
                                                              "cast(" & oOrm.CampoPrincipalTercero & " as varchar) + " & _
                                                              "rtrim(ltrim(cast(isnull(" & oOrm.CampoPrincipalCuarto & ",'') as varchar)))" & _
                                                       " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                            Else
                                FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                            End If
                    End Select
                ElseIf oOrm.FlagCampoPrincipal = 5 Then
                    If cboBuscar.Text = oOrm.CampoPrincipal Or _
                       cboBuscar.Text = oOrm.CampoPrincipalSecundario Or _
                       cboBuscar.Text = oOrm.CampoPrincipalTercero Or _
                       cboBuscar.Text = oOrm.CampoPrincipalCuarto Or _
                       cboBuscar.Text = oOrm.CampoPrincipalQuinto Then
                        FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalSecundario & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalTercero & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalCuarto & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalQuinto & " as varchar)" & _
                                               " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    Else
                        FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    End If
                ElseIf oOrm.FlagCampoPrincipal = 6 Then
                    If cboBuscar.Text = oOrm.CampoPrincipal Or _
                       cboBuscar.Text = oOrm.CampoPrincipalSecundario Or _
                       cboBuscar.Text = oOrm.CampoPrincipalTercero Or _
                       cboBuscar.Text = oOrm.CampoPrincipalCuarto Or _
                       cboBuscar.Text = oOrm.CampoPrincipalQuinto Or _
                       cboBuscar.Text = oOrm.CampoPrincipalSexto Then
                        FiltroProcedimiento &= " WHERE cast(" & oOrm.CampoPrincipal & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalSecundario & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalTercero & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalCuarto & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalQuinto & " as varchar) + " & _
                                                      "cast(" & oOrm.CampoPrincipalSexto & " as varchar)" & _
                                               " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    Else
                        FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                    End If
                Else
                    FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                End If
            Else
                Select Case oOrm.cTabla.NombreCorto
                    Case "SaldosKardexDocumentos"
                        Select Case oOrm.Vista
                            ''Case "VistaSaldoDTD"
                            Case "VistaSaldoDTDNuevo"
                                FiltroProcedimiento &= " AND " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                            Case Else
                                Select Case UCase(cboBuscar.Text)
                                    Case "SALDO"
                                        FiltroProcedimiento &= " AND " & "SUM(CARGO)-SUM(ABONO)" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                    Case "CCT_DESCRIPCION_REF", "PER_DESCRIPCION_CLI", "TDO_DESCRIPCION_REF", "DTD_DESCRIPCION_REF", "MON_DESCRIPCION"
                                        FiltroProcedimiento &= " AND " & "max(" & cboBuscar.Text & ")" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                    Case "DOC_FECHA_EMI_REF", "DOC_FECHA_VEN_REF"
                                        FiltroProcedimiento &= " AND " & "min(cast(" & cboBuscar.Text & " as DATE))" & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                    Case Else
                                        FiltroProcedimiento &= " AND " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                End Select
                        End Select
                    Case Else
                        Select Case oOrm.cTabla.NombreCorto
                            Case "vwDocumentosKardexDocumento"
                                If cboBuscar.Text = "NUMERO" Then
                                    FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & "' AND SERIE LIKE '%" & Strings.Trim(txtBuscarSerie.Text) & vFiltro & oOrm.CadenaFiltrado
                                Else
                                    FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                End If
                            Case "Documentos"
                                If cboBuscar.Text = "DOC_NUMERO" Then
                                    FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & "' AND DOC_SERIE LIKE '%" & Strings.Trim(txtBuscarSerie.Text) & vFiltro & oOrm.CadenaFiltrado
                                Else
                                    FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                                End If
                            Case Else
                                FiltroProcedimiento &= " WHERE " & cboBuscar.Text & " LIKE '" & vTipoBusqueda & Strings.Trim(sBuscar) & vFiltro & oOrm.CadenaFiltrado
                        End Select
                End Select
            End If

            Dim ds As New DataSet
            Dim vCantidadRegistros As Integer = 0
            Dim vFiltroProcedimiento As String = ""

            Dim CadenaVista As String = ""
            vCantidadRegistros = pCantidadRegistros
            vFiltroProcedimiento = FiltroProcedimiento

            Select Case oOrm.cTabla.NombreCorto
                Case "DetalleListaPrecios"
                    If oOrm.Vista = "ListaPreciosEspecialPuntoVentaPlanta" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vLPR_ID1, oOrm.vLPR_ID2, oOrm.vTIP_ID, vFiltroProcedimiento)
                    Else
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vCantidadRegistros, vFiltroProcedimiento)
                    End If
                Case "Documentos"
                    If oOrm.Vista = "BuscarRegistrosParaDespachos" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vPER_ID_CLI, vFiltroProcedimiento)
                    ElseIf oOrm.Vista = "BuscarRegistrosParaDespachosProforma" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vPER_ID_VEN, vFiltroProcedimiento)
                    ElseIf oOrm.Vista = "BuscarRegistrosParaDespachosDesdeDistribuidora" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vPER_ID_CLI, vFiltroProcedimiento)
                    Else
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vCantidadRegistros, vFiltroProcedimiento)
                    End If
                Case "SaldosKardexDocumentos"
                    If oOrm.Vista = "BuscarRegistros" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vCCT_ID, oOrm.vCCC_ID, oOrm.vPER_ID_CLI, oOrm.vCCT_ID_REF, oOrm.vTDO_ID, oOrm.vDTD_ID, oOrm.vDOC_SERIE, oOrm.vDOC_NUMERO, oOrm.vDOCUMENTO, oOrm.vProcesarAnticipoPorCobrar)
                    End If
                    ''If oOrm.Vista = "VistaSaldoDTD" Then
                    If oOrm.Vista = "VistaSaldoDTDNuevo" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, oOrm.vPER_ID_CLI, vFiltroProcedimiento)
                    End If
                    If oOrm.Vista = "spSaldoDocumentoMontoNoCero" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFiltroProcedimiento)
                    End If
                    If oOrm.Vista = "spSaldoDocumentoMontoNoCeroConCheck" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFiltroProcedimiento)
                    End If
                    If oOrm.Vista = "spSaldoDocumentoMontoNoCeroDetracciones" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFiltroProcedimiento)
                    End If
                    If oOrm.Vista = "spSaldoDocumentoMontoNoCeroDetraccionesConCheck" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFiltroProcedimiento)
                    End If
                    If oOrm.Vista = "spSaldoDocumentoMontoNoCeroDetraccionesCopiaXML" Then
                        CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vFiltroProcedimiento)
                    End If
                Case Else
                    CadenaVista = IBCMaestro.EjecutarVista(NombreProcedimiento, vCantidadRegistros, vFiltroProcedimiento)
            End Select

            Dim sr As New StringReader(CadenaVista)

            Dim vcontrol As Int16 = sr.Peek
            If vcontrol <> -1 Then
                ds.ReadXml(sr)
                dgvDatos.DataSource = ds.Tables(0)
            Else
                dgvDatos.DataSource = Nothing
            End If
            OcultarCampos(False, True)


            If pTipoEdicion = 2 Or pComportamiento = -1 Then DevolverDatos()

            vEnTiempoReal = False
            If chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Checked Then vEnTiempoReal = True
            Me.Cursor = Windows.Forms.Cursors.Default

            SeleccionarTodosMarcados()
            ColorearFilas()

        End Sub

        Private Sub SeleccionarTodosMarcados()
            If pSeleccionarTodosEnMarcados Then
                If pDgvConMarcado Then
                    Dim vFilGrid As Integer
                    Dim vTotal As Double = 0
                    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                    DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText

                    vFilGrid = 0
                    If dgvDatos.Rows.Count() > 0 Then
                        While (dgvDatos.Rows.Count() > vFilGrid)
                            With dgvDatos.Rows(vFilGrid)
                                .DefaultCellStyle.ForeColor = Drawing.Color.Red
                                .DefaultCellStyle.BackColor = Drawing.Color.White
                                .Cells("Marcado").Value = 1
                                DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                                DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                                DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                                Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
                                If pTotalizarCampo Then
                                    vTotal += .Cells(pNombreCampoTotalizar).Value
                                End If
                            End With
                            vFilGrid += 1
                        End While
                    End If
                    txtTotal.Text = vTotal
                End If
            End If
        End Sub
        Private Sub FormatearColorMarcados()
            If pDgvConMarcado Then
                Dim vFilGrid As Integer
                Dim vTotal As Double = 0
                Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
                DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
                DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText

                vFilGrid = 0
                If dgvDatos.Rows.Count() > 0 Then
                    While (dgvDatos.Rows.Count() > vFilGrid)
                        With dgvDatos.Rows(vFilGrid)
                            If .Cells("Marcado").Value = 0 Then
                                .DefaultCellStyle.ForeColor = Drawing.Color.Black
                                .DefaultCellStyle.BackColor = Drawing.Color.White
                                DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                                DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
                            Else
                                .DefaultCellStyle.ForeColor = Drawing.Color.Red
                                .DefaultCellStyle.BackColor = Drawing.Color.White
                                DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
                                DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red
                            End If

                            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                            Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle2
                        End With
                        vFilGrid += 1
                    End While
                End If
            End If
        End Sub

        Sub ColorearFilas()
            Select Case NombreFormulario.name.ToString
                Case "frmGuiaDespacho", "frmGuiaDespachoDesdeDistribuidora"
                    Select Case Comportamiento
                        Case Is <= 0 ' Documentos
                        Case 3 ' DetalleTipoDocumentos
                        Case 4, 14 ' RolPuntoVentaAlmacen
                        Case 6, 16 ' Personas - Cliente, Vendedor 
                        Case 7 ' Documentos - Facturas/Boletas
                        Case 8 ' DetalleFleteTransporte
                        Case 13 ' Placas
                        Case 17 ' Despachos - Cronograma
                            If dgvDatos.DataSource IsNot Nothing Then
                                dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
                                'dgvDatos.Columns("DTD_DESCRIPCION_DOC").Width = 20
                                For Each mR As DataGridViewRow In dgvDatos.Rows
                                    If mR.Cells("DOC_TIPO_LISTA").Value = "PLANTA" Then
                                        mR.DefaultCellStyle.BackColor = Color.LightPink
                                    Else
                                        mR.DefaultCellStyle.BackColor = Color.LightGreen
                                    End If

                                Next
                            End If

                    End Select
            End Select
        End Sub

        Protected Overridable Sub cboBuscar_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles cboBuscar.SelectedValueChanged
            If pLoaded Then Return
            vRefrescarBusqueda = True
            EstablecerAncho()
            If pDgvConMarcado Then
            Else
                If cboDatoBuscar.Enabled Then Buscar(cboDatoBuscar.Text)
                If txtBuscar.Enabled Then Buscar(txtBuscar.Text)
            End If
            vRefrescarBusqueda = False
        End Sub
        Protected Overridable Function DatosCboBuscar()
            Return cboDatoBuscar.Text
        End Function
        Private Sub EstablecerAncho()
            txtBuscarSerie.Enabled = False
            txtBuscarSerie.Visible = False
            cboDetalleTipoDocumento.Enabled = False
            cboDetalleTipoDocumento.Visible = False

            'txtBuscar.Location = New System.Drawing.Point(209, 6)

            For Filas = 0 To vArrayDatosComboBox.Count() - 1
                If cboBuscar.Text = vArrayDatosComboBox(Filas).NombreCampo And vArrayDatosComboBox(Filas).Flag Then
                    cMisProcedimientos.AdicionarElementoCombosEdicion(cboDatoBuscar, vArrayDatosComboBox(Filas).Valores, 0)
                    cboDatoBuscar.Width = vArrayDatosComboBox(Filas).Ancho
                    txtBuscar.Enabled = False
                    txtBuscar.Visible = False
                    txtBuscar.Text = ""
                    cboDatoBuscar.Enabled = True
                    cboDatoBuscar.Visible = True
                    cboDatoBuscar.SelectedText.ToString()
                    Exit For
                Else
                    If cboBuscar.Text = vArrayDatosComboBox(Filas).NombreCampo And Not vArrayDatosComboBox(Filas).Flag Then
                        cboDatoBuscar.Enabled = False
                        cboDatoBuscar.Visible = False
                        txtBuscar.Enabled = True
                        txtBuscar.Visible = True
                        FormatearCampos(txtBuscar, vArrayDatosComboBox(Filas).NombreCampo, vArrayDatosComboBox, vArrayDatosComboBox.Count - 1)
                        Select Case oOrm.cTabla.NombreCorto
                            Case "SaldosKardexDocumentos"
                                If cboBuscar.Text = "DOC_NUMERO_REF" Then
                                    txtBuscarSerie.Enabled = True
                                    txtBuscarSerie.Visible = True

                                    cboDetalleTipoDocumento.Enabled = True
                                    cboDetalleTipoDocumento.Visible = True

                                    vPosActualX = txtBuscar.Location.X
                                    vPosActualY = txtBuscar.Location.Y

                                    txtBuscarSerie.Location = txtBuscar.Location
                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX + (45), vPosActualY)

                                    vPosActualX = txtBuscar.Location.X
                                    vPosActualY = txtBuscar.Location.Y

                                    cboDetalleTipoDocumento.Location = txtBuscar.Location
                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX + (225), vPosActualY)
                                Else
                                    txtBuscarSerie.Enabled = False
                                    txtBuscarSerie.Visible = False

                                    cboDetalleTipoDocumento.Enabled = False
                                    cboDetalleTipoDocumento.Visible = False

                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX, vPosActualY)
                                End If

                            Case "vwDocumentosKardexDocumento"
                                If cboBuscar.Text = "NUMERO" Then
                                    txtBuscarSerie.Enabled = True
                                    txtBuscarSerie.Visible = True

                                    vPosActualX = txtBuscar.Location.X
                                    vPosActualY = txtBuscar.Location.Y

                                    txtBuscarSerie.Location = txtBuscar.Location
                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX + (45), vPosActualY)
                                Else
                                    txtBuscarSerie.Enabled = False
                                    txtBuscarSerie.Visible = False

                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX, vPosActualY)
                                End If
                            Case "Documentos"
                                If cboBuscar.Text = "DOC_NUMERO" Then
                                    txtBuscarSerie.Enabled = True
                                    txtBuscarSerie.Visible = True

                                    vPosActualX = txtBuscar.Location.X
                                    vPosActualY = txtBuscar.Location.Y

                                    txtBuscarSerie.Location = txtBuscar.Location
                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX + (45), vPosActualY)
                                Else
                                    txtBuscarSerie.Enabled = False
                                    txtBuscarSerie.Visible = False

                                    txtBuscar.Location = New System.Drawing.Point(vPosActualX, vPosActualY)
                                End If
                            Case Else
                                txtBuscarSerie.Enabled = False
                                txtBuscarSerie.Visible = False

                                cboDetalleTipoDocumento.Enabled = False
                                cboDetalleTipoDocumento.Visible = False
                        End Select
                        Exit For
                    End If
                End If
            Next
        End Sub
        Public Sub FormatearCampos(ByRef oObjeto As Object, _
                           ByVal NombreCampo As String, _
                           ByVal vArrayDatosComboBox() As Ladisac.MisProcedimientos.DatosComboBox, _
                           ByVal vElementos As Int16)
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

        Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
            TeclasAccesoRapido(keyData)
            Return MyBase.ProcessCmdKey(msg, keyData)
        End Function
        Protected Overridable Sub TeclasAccesoRapido(ByVal vkeyData As System.Windows.Forms.Keys)
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.D Then
                If tsbOkBusqueda.Enabled = True Then LlamarMetodo("DevolverDatos")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.Q Then
                If tsbInicio.Enabled = True Then LlamarMetodo("PrimerRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.A Then
                If tsbAnterior.Enabled = True Then LlamarMetodo("RegistroAnterior")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.S Then
                If tsbSiguiente.Enabled = True Then LlamarMetodo("RegistroSiguiente")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.W Then
                If tsbFinal.Enabled = True Then LlamarMetodo("UltimoRegistro")
            End If
            If vkeyData = System.Windows.Forms.Keys.Control + System.Windows.Forms.Keys.Alt + System.Windows.Forms.Keys.S Then
                If tsbSalir.Enabled = True Then LlamarMetodo("Salir")
            End If
        End Sub

        Private Sub Busqueda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If DesignMode Then Return
            Me.lblTitle.Text = "Búsqueda : " & pDatosBuscados

            ReDim vArrayDatosComboBox(oOrm.vElementosDatosComboBox)
            For vItem = 0 To oOrm.vElementosDatosComboBox
                vArrayDatosComboBox(vItem).NombreCampo = oOrm.vArrayDatosComboBox(vItem).NombreCampo
                vArrayDatosComboBox(vItem).Valores = oOrm.vArrayDatosComboBox(vItem).valores
                vArrayDatosComboBox(vItem).Ancho = oOrm.vArrayDatosComboBox(vItem).Ancho
                vArrayDatosComboBox(vItem).Longitud = oOrm.vArrayDatosComboBox(vItem).Longitud
                vArrayDatosComboBox(vItem).Flag = oOrm.vArrayDatosComboBox(vItem).Flag
                vArrayDatosComboBox(vItem).Tipo = oOrm.vArrayDatosComboBox(vItem).Tipo
            Next
            cMisProcedimientos.AdicionarElementoCombosEdicion(Me.cboBuscar, oOrm.vArrayCamposBusqueda, pOrdenBusqueda)
            vTextoCboBuscar = cboBuscar.Text
            If pTipoEdicion = 1 Then
                vClaseDibujar.AnchoAntes = cboBuscar.Size.Width
                cboBuscar.Width = cMisProcedimientos.LongitudCampo(oOrm.vArrayCamposBusqueda, cboBuscar)
                vClaseDibujar.AnchoDespues = cboBuscar.Size.Width
                cMisProcedimientos.ubicacion(vClaseDibujar, cboDatoBuscar)
                cMisProcedimientos.ubicacion(vClaseDibujar, txtBuscar)

                ConfigurarGrid("Load")
                EstablecerAncho()
            End If

            pLoaded = False

            If pTipoEdicion = 2 Or pComportamiento = -1 Then
                vEnTiempoReal = True
                chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Checked
            Else
                vEnTiempoReal = False
                chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Unchecked
            End If
            If Not oOrm.pFiltradoWhere Then
                vEnTiempoReal = True
                chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Checked
                btnRefrescar.Enabled = True
                btnRefrescar.Visible = True
            Else
                btnRefrescar.Enabled = False
                btnRefrescar.Visible = False
            End If

            Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()

            If pAumentarLetraGrilla Then
                DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
                DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
                DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
                DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
                DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle21
            Else
                DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
                DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window
                DataGridViewCellStyle21.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText
                DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
                DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
                DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
                Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle21
            End If
            Buscar(pDatoBusqueda)
        End Sub
        Public Overridable Sub OcultarCampos(Optional ByVal vFlagCbo As Boolean = True, _
                                             Optional ByVal vFlagDgv As Boolean = False)
            Select Case NombreFormulario.name.ToString
                Case "frmDescuentoIncrementoTipoVentaPersonas"
                    DescuentoIncrementoTipoVentaPersonasO(vFlagCbo, vFlagDgv)
                Case "frmKardexDocumento", "frmDetalleVentaPorArticulo", "frmReporteGuias", "frmReporteGuiasProduccion"
                    KardexDocumentoO(vFlagCbo, vFlagDgv)
                Case "frmProvincia"
                    ProvinciaO()
                Case "frmUsuarios"
                Case "frmArticulos"
                Case "frmPersonas"
                    PersonasO(vFlagCbo, vFlagDgv)
                Case "Moneda"
                Case "frmDocumentosEmitidos", "frmDocumentosEmitidosPorPromotor"
                    DocumentosEmitidosO(vFlagCbo, vFlagDgv)
                Case "frmPedidoBoletaFactura", "frmProformaFacturas", "frmOrdenCompraBoletas", "frmOrdenCompraFacturas", "frmBoletas", "frmBoletas01", "frmBoletas02", "frmBoletas03", "frmBoletas04", "frmFacturas", "frmFacturas01", "frmFacturas02", "frmFacturas03", "frmFacturas04", "frmNotaCredito", "frmNotaDebito", "frmTipoVentaBoletaFactura"
                    DocumentosO(vFlagCbo, vFlagDgv)
                Case "frmGenerarDocumentoPromocion"
                    GenerarDocumentoPromocionO(vFlagCbo, vFlagDgv)

                Case "frmGuiaDespacho", "frmGuiaDevolucion", "frmGuiaIngreso", "frmGuiaSalida", _
                     "frmGuiaTransferencia", "frmCronogramaDespacho", "frmGuiaDespachoDesdeDistribuidora", "frmGuiaDevolucionDesdeDistribuidora"
                    DespachosO(vFlagCbo, vFlagDgv)
                Case "frmControlFarita"
                    MarcarSalidaGuiaO(vFlagCbo, vFlagDgv)
                Case "frmReciboIngresos", "frmReciboIngresos01", "frmReciboIngresos02", "frmReciboIngresos03", "frmReciboIngresos04", _
                     "frmReciboEgresos", "frmReciboEgresos01", "frmReciboEgresos02", "frmReciboEgresos03", "frmReciboEgresos04", _
                     "frmPlanillaEgresos", "frmTransferenciaEntreCajas", "frmDepositosBancarios", "frmDepositoTercero", "frmNotaAbonoCtaBanco", "frmBancoEgresos", "frmVoucherCheque", "frmNotaCargoCtaBanco", "frmDetraccionesNotaCargoCtaBanco", "frmConsultasTesoreria"
                    TesoreriaO(vFlagCbo, vFlagDgv)
                Case "frmLiquidacionDocumento", "frmPlanillaRendicionCuentas"
                    TesoreriaO(vFlagCbo, vFlagDgv)
                Case "frmDireccionesPersonas"
                    DireccionesPersonasO(vFlagCbo, vFlagDgv)
                Case "frmGuiaRemisionTransportista"
                    GuiasRemisionO(vFlagCbo, vFlagDgv)
                Case "frmReporteCronogramaDespacho"
                    ReporteCronogramaDespachoO(vFlagCbo, vFlagDgv)
            End Select
        End Sub
        Public Overridable Sub OcultarNombresCampos(ByVal NombreCampo As String, _
                                                    Optional ByVal vFlagCbo As Boolean = True, _
                                                    Optional ByVal vFlagDgv As Boolean = False)
            If vFlagCbo Then
                cboBuscar.Items.Remove(NombreCampo)
                cboBuscar.SelectedText = vTextoCboBuscar
                If cboBuscar.Text = "" Then cboBuscar.SelectedIndex = 0
            End If

            If Not dgvDatos.DataSource Is Nothing Then If vFlagDgv Then MostrarCampoListado(NombreCampo, False)
        End Sub
        Public Overridable Sub MostrarCampoListado(ByVal vNombreCampo, ByVal vMostrar)
            dgvDatos.Columns(vNombreCampo).Visible = vMostrar
        End Sub
        Private Sub DatosUsuarios()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' DatosUsuarios
                    NombreFormulario.txtDAU_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDAU_ID, dgvDatos, "DAU_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtDAU_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_ID, dgvDatos, "USU_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.chkPER_ESTADO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DAU_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DAU_ESTADO"), oOrm), NombreFormulario.ChkDAU_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 2 ' Usuarios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_ID, dgvDatos, "USU_ID")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), _
                            NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.dgvDetalle.Item("cPVE_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("PVE_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cPVE_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("PVE_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cPVE_DIRECCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("PVE_DIRECCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DatosUsuariosI()
            Select Case Comportamiento
                Case 2 ' Usuarios
                    NombreFormulario.txtUSU_ID.Text = ""
                Case 3 ' Personas
                    NombreFormulario.txtPER_ID.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO)
                Case 4 ' PuntoVenta
                    NombreFormulario.dgvDetalle.Item("cPVE_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cPVE_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cPVE_DIRECCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Private Sub PuntoVentaDatosUsuarios()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' PuntoVentaDatosUsuarios
                    NombreFormulario.txtDAU_ID.Enabled = False
                    NombreFormulario.txtPVE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDAU_ID, dgvDatos, "DAU_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtDAU_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                    NombreFormulario.vCodigoPVE_ID = NombreFormulario.txtPVE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO"), oOrm), NombreFormulario.chkPVE_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_TIPO_LISTA, dgvDatos, "PDU_TIPO_LISTA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_ENTREGA_PUNTO_VENTA, dgvDatos, "PDU_ENTREGA_PUNTO_VENTA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_ENTREGA_PLANTA, dgvDatos, "PDU_ENTREGA_PLANTA")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PDU_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PDU_ESTADO"), oOrm), NombreFormulario.ChkPDU_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PuntoVentaDatosUsuarios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PDU_ESTADO") = "NO ACTIVO" Or
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DAU_ESTADO") = "NO ACTIVO" Or
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDAU_ID, dgvDatos, "DAU_ID")
                        NombreFormulario.CodigoId = NombreFormulario.txtDAU_ID.Text

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        NombreFormulario.vCodigoPVE_ID = NombreFormulario.txtPVE_ID.Text

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO"), oOrm), NombreFormulario.chkPVE_ESTADO)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_TIPO_LISTA, dgvDatos, "PDU_TIPO_LISTA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_ENTREGA_PUNTO_VENTA, dgvDatos, "PDU_ENTREGA_PUNTO_VENTA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPDU_ENTREGA_PLANTA, dgvDatos, "PDU_ENTREGA_PLANTA")

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PDU_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PDU_ESTADO"), oOrm), NombreFormulario.ChkPDU_ESTADO)

                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 2 ' CorrelativoTipoDocumento
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CTD_ESTADO") = "NO ACTIVO" Or
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.dgvDetalle.Item("cTDO_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cTDO_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cTDO_ESTADO", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_ESTADO").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cCTD_COR_SERIE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CTD_COR_SERIE").Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PuntoVentaDatosUsuariosI()
            Select Case Comportamiento
                Case 1 ' PuntoVentaDatosUsuarios
                    NombreFormulario.txtDAU_ID.Text = ""
                    NombreFormulario.txtPVE_ID.Text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
                    NombreFormulario.cboPDU_TIPO_LISTA.Text = ""
                    NombreFormulario.cboPDU_ENTREGA_PUNTO_VENTA.Text = ""
                    NombreFormulario.cboPDU_ENTREGA_PLANTA.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPDU_ESTADO)
                Case 2 ' CorrelativoTipoDocumento
                    NombreFormulario.dgvDetalle.Item("cTDO_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cTDO_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cTDO_ESTADO", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cCTD_COR_SERIE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Private Sub RolArticulosTipoArticulos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' RolArticulosTipoArticulos
                    NombreFormulario.txtART_ID.Enabled = False
                    NombreFormulario.txtTIP_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtART_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                        NombreFormulario.chkART_ESTADO)


                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, 3)
                    NombreFormulario.vCodigoTIP_ID = NombreFormulario.txtTIP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, 4)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.chkTIP_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("RAR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), NombreFormulario.ChkRAR_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Articulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34), oOrm), _
                            NombreFormulario.ChkART_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' TipoArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkTIP_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RolArticulosTipoArticulosI()
            Select Case Comportamiento
                Case 1 ' Articulos
                    NombreFormulario.txtART_ID.Text = ""
                    NombreFormulario.txtART_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkART_ESTADO)
                Case 2 ' TipoArticulos
                    NombreFormulario.txtTIP_ID.Text = ""
                    NombreFormulario.txtTIP_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkTIP_ESTADO)
            End Select
        End Sub

        Private Sub RolAlmacenTipoArticulos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' RolAlmacenTipoArticulos
                    NombreFormulario.txtALM_ID.Enabled = False
                    NombreFormulario.txtTIP_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtALM_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                        NombreFormulario.chkALM_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, 3)
                    NombreFormulario.vCodigoTIP_ID = NombreFormulario.txtTIP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, 4)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.chkTIP_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("RAT_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), NombreFormulario.ChkRAT_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Almacén
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16), oOrm), _
                            NombreFormulario.ChkALM_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' TipoArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkTIP_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RolAlmacenTipoArticulosI()
            Select Case Comportamiento
                Case 1 ' Almacén
                    NombreFormulario.txtALM_ID.Text = ""
                    NombreFormulario.txtALM_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkALM_ESTADO)
                Case 2 ' TipoArticulos
                    NombreFormulario.txtTIP_ID.Text = ""
                    NombreFormulario.txtTIP_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkTIP_ESTADO)
            End Select
        End Sub

        Private Sub PesosArticulos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' PesosArticulos
                    NombreFormulario.txtPAR_ANIO.Enabled = False
                    NombreFormulario.cboPAR_MES.Enabled = False
                    NombreFormulario.txtART_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 0)
                    NombreFormulario.vCodigoART_ID = NombreFormulario.txtART_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                        NombreFormulario.chkART_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPAR_MES, dgvDatos, 3)
                    NombreFormulario.vCodigoPAR_MES = NombreFormulario.cboPAR_MES.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAR_ANIO, dgvDatos, 4)
                    NombreFormulario.CodigoId = NombreFormulario.txtPAR_ANIO.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAR_PESO_MAX, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAR_PESO_MIN, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_ID, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_DESCRIPCION, dgvDatos, 8)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("UM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), _
                        NombreFormulario.ChkUM_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), NombreFormulario.ChkPAR_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Articulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34), oOrm), _
                            NombreFormulario.ChkART_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' UnidadMedidaArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("UM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                            NombreFormulario.ChkUM_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PesosArticulosI()
            Select Case Comportamiento
                Case 1 ' Articulos
                    NombreFormulario.txtART_ID.Text = ""
                    NombreFormulario.txtART_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkART_ESTADO)
                Case 2 ' UnidadMedidaArticulos
                    NombreFormulario.txtUM_ID.Text = ""
                    NombreFormulario.txtUM_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkUM_ESTADO)
            End Select
        End Sub
        Private Sub PesosArticulosO()
            Select Case Comportamiento
            End Select
        End Sub

        Private Sub TipoUnidad()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' TipoUnidad
                    NombreFormulario.txtTUN_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtTUN_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TUN_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkTUN_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub
        Private Sub TipoUnidadI()
            Select Case Comportamiento
            End Select
        End Sub

        Private Sub ConfiguracionVehicular()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' ConfiguracionVehicular
                    NombreFormulario.txtCVE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCVE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCVE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID_TRACTO, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION_TRACTO, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID_CARRETA, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION_CARRETA, dgvDatos, 4)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCVE_PESO, dgvDatos, 5)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), _
                        NombreFormulario.chkCVE_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' TipoUnidad - Tracto
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ConfiguracionVehicularI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID_TRACTO, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION_TRACTO, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' TipoUnidad - Carreta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ConfiguracionVehicularI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID_CARRETA, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION_CARRETA, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ConfiguracionVehicularI()
            Select Case Comportamiento
                Case 1 ' TipoUnidad - Tracto
                    NombreFormulario.txtTUN_ID_TRACTO.Text = ""
                    NombreFormulario.txtTUN_DESCRIPCION_TRACTO.Text = ""
                Case 2 ' TipoUnidad - Carreta
                    NombreFormulario.txtTUN_ID_CARRETA.Text = ""
                    NombreFormulario.txtTUN_DESCRIPCION_CARRETA.Text = ""
            End Select
        End Sub

        Private Sub UnidadesTransporte()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' UnidadesTransporte
                    NombreFormulario.txtUNT_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtUNT_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUNT_COMPORTAMIENTO, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUNT_TIPO, dgvDatos, 2)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION, dgvDatos, 4)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TUN_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.ChkTUN_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_ID, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION, dgvDatos, 7)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MAR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8), oOrm), _
                        NombreFormulario.ChkMAR_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_ID, dgvDatos, 9)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION, dgvDatos, 10)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MOD_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 11), oOrm), _
                        NombreFormulario.ChkMOD_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_TARA, dgvDatos, 12)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_INS, dgvDatos, 13)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 14)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 15)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), _
                        NombreFormulario.ChkPER_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID, dgvDatos, 16)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION, dgvDatos, 17)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO, dgvDatos, 18)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19), oOrm), _
                        NombreFormulario.ChkDOP_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_KILOMETRAJE, dgvDatos, 21)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_HOROMETRO, dgvDatos, 22)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_SERIE, dgvDatos, 23)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_MOTOR, dgvDatos, 24)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ANIO_FABRICACION, dgvDatos, 25)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpUNT_FECHA_ADQUISICION, dgvDatos, 26)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("UNT_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 27), oOrm), NombreFormulario.ChkUNT_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Datos MarcaArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MAR_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkMAR_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' Datos ModeloArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MOD_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkMOD_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 3 ' Datos DocPersonas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkPER_ESTADO)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO, dgvDatos, 3)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), _
                            NombreFormulario.ChkDOP_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 4 ' TipoUnidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTUN_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TUN_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkTUN_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub UnidadesTransporteI()
            Select Case Comportamiento
                Case 1 ' MarcaArticulos
                    NombreFormulario.txtMAR_ID.Text = ""
                    NombreFormulario.txtMAR_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefaultCheckBox(NombreFormulario.chkMAR_ESTADO)
                Case 2 ' ModeloArticulos
                    NombreFormulario.txtMOD_ID.Text = ""
                    NombreFormulario.txtMOD_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefaultCheckBox(NombreFormulario.chkMOD_ESTADO)
                Case 3 ' DocPersonas
                    NombreFormulario.txtPER_ID.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION.Text = ""
                    NombreFormulario.txtTDP_ID.Text = ""
                    NombreFormulario.txtTDP_DESCRIPCION.Text = ""
                    NombreFormulario.txtDOP_NUMERO.Text = ""
                    NombreFormulario.ColocarValoresDefaultCheckBox(NombreFormulario.chkDOP_ESTADO)
                    NombreFormulario.ColocarValoresDefaultCheckBox(NombreFormulario.chkPER_ESTADO)
                Case 4 ' TipoUnidad
                    NombreFormulario.txtTUN_ID.Text = ""
                    NombreFormulario.txtTUN_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefaultCheckBox(NombreFormulario.chkTUN_ESTADO)
            End Select
        End Sub
        Private Sub UnidadesTransporteO()
            Select Case Comportamiento
                Case 2
                    'dgvDatos.Columns("USU_CONTRASENA").Visible = False
                    'OcultarNombresCampos("USU_CONTRASENA")
                Case 3
                Case 4
                Case 5
            End Select
        End Sub

        Private Sub Placas()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Placas
                    NombreFormulario.txtPLA_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPLA_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPLA_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_1, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA1, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA1, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA1, dgvDatos, 4)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_TRA1", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.ChkPER_ESTADO_TRA1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION_TRA1, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION_TRA1, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_TARA_TRA1, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_INS_TRA1, dgvDatos, 9)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_2, dgvDatos, 10)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA2, dgvDatos, 11)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA2, dgvDatos, 12)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA2, dgvDatos, 13)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_TRA2", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 14), oOrm), _
                        NombreFormulario.ChkPER_ESTADO_TRA2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION_TRA2, dgvDatos, 15)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION_TRA2, dgvDatos, 16)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_TARA_TRA2, dgvDatos, 17)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_INS_TRA2, dgvDatos, 18)


                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CHO, dgvDatos, 19)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CHO, dgvDatos, 20)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE_CHO, dgvDatos, 21)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CHO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22), oOrm), _
                        NombreFormulario.ChkPER_ESTADO_CHO)


                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PLA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 23), oOrm), NombreFormulario.ChkPLA_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' UnidadesTransporte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 27) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_1, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION_TRA1, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION_TRA1, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_TARA_TRA1, dgvDatos, 12)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_INS_TRA1, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA1, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA1, dgvDatos, 15)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), NombreFormulario.Simple1), _
                            NombreFormulario.ChkPER_ESTADO_TRA1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA1, dgvDatos, 18)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' UnidadesTransporte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 27) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_2, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMAR_DESCRIPCION_TRA2, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMOD_DESCRIPCION_TRA2, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_TARA_TRA2, dgvDatos, 12)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_NRO_INS_TRA2, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA2, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA2, dgvDatos, 15)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), NombreFormulario.Simple1), _
                            NombreFormulario.ChkPER_ESTADO_TRA2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA2, dgvDatos, 18)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 3 'Personas - Chofer
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO"  Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CHO, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CHO, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE_CHO, dgvDatos, "PER_BREVETE")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), _
                            NombreFormulario.ChkPER_ESTADO_CHO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PlacasI()
            Select Case Comportamiento
                Case 1 ' UnidadesTransporte
                    NombreFormulario.txtUNT_ID_1.Text = ""
                    NombreFormulario.txtMAR_DESCRIPCION_TRA1.Text = ""
                    NombreFormulario.txtMOD_DESCRIPCION_TRA1.Text = ""
                    NombreFormulario.txtUNT_TARA_TRA1.Text = ""
                    NombreFormulario.txtUNT_NRO_INS_TRA1.Text = ""
                    NombreFormulario.txtPER_ID_TRA1.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_TRA1.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_TRA1)
                    NombreFormulario.txtRUC_TRA1.Text = ""
                Case 2 ' UnidadesTransporte
                    NombreFormulario.txtUNT_ID_2.Text = ""
                    NombreFormulario.txtMAR_DESCRIPCION_TRA2.Text = ""
                    NombreFormulario.txtMOD_DESCRIPCION_TRA2.Text = ""
                    NombreFormulario.txtUNT_TARA_TRA2.Text = ""
                    NombreFormulario.txtUNT_NRO_INS_TRA2.Text = ""
                    NombreFormulario.txtPER_ID_TRA2.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_TRA2.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_TRA2)
                    NombreFormulario.txtRUC_TRA2.Text = ""
                Case 3 ' Personas
                    NombreFormulario.txtPER_ID_CHO.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CHO.Text = ""
                    NombreFormulario.txtPER_BREVETE_CHO.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_CHO)
            End Select
            NombreFormulario.FiltrarCampos(Comportamiento)
        End Sub
        Private Sub PlacasO()
            Select Case Comportamiento
                Case 2
                    'dgvDatos.Columns("USU_CONTRASENA").Visible = False
                    'OcultarNombresCampos("USU_CONTRASENA")
                Case 3
                Case 4
                Case 5
            End Select
        End Sub

        Private Sub TipoPersonas()
            Select Case Comportamiento
                Case Is <= 0 ' TipoPersonas
                    NombreFormulario.txtTPE_ID.Enabled = True

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_ID, dgvDatos, "TPE_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTPE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_DESCRIPCION, dgvDatos, "TPE_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_ID, dgvDatos, "COM_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_DESCRIPCION, dgvDatos, "COM_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("COM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "COM_ESTADO"), oOrm), NombreFormulario.ChkCOM_ESTADO)


                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CLIENTE", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CLIENTE"), oOrm), NombreFormulario.ChkTPE_CLIENTE)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_PROVEEDOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_PROVEEDOR"), oOrm), NombreFormulario.ChkTPE_PROVEEDOR)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRABAJADOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRABAJADOR"), oOrm), NombreFormulario.ChkTPE_TRABAJADOR)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_BANCO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_BANCO"), oOrm), NombreFormulario.ChkTPE_BANCO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_GRUPO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_GRUPO"), oOrm), NombreFormulario.ChkTPE_GRUPO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CONTACTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CONTACTO"), oOrm), NombreFormulario.ChkTPE_CONTACTO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRANSPORTISTA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRANSPORTISTA"), oOrm), NombreFormulario.ChkTPE_TRANSPORTISTA)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_ESTADO"), oOrm), NombreFormulario.ChkTPE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Comisión
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TipoPersonasI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("COM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), NombreFormulario.ChkCOM_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub TipoPersonasI()
            Select Case Comportamiento
                Case 1 ' Comisión
                    NombreFormulario.txtCOM_ID.text = ""
                    NombreFormulario.txtCOM_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkCOM_ESTADO)
            End Select
        End Sub

        Private Sub TipoDocPersonas()
            Select Case Comportamiento
                Case Is <= 0 ' DireccionesPersonas

                    NombreFormulario.txtTDP_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtTDP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_LONGITUD, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_COD_SUNAT, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkTDP_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub

        Private Sub Personas()
            Select Case Comportamiento
                Case Is <= 0 ' Personas
                    NombreFormulario.txtPER_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_APE_PAT, dgvDatos, "PER_APE_PAT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_APE_MAT, dgvDatos, "PER_APE_MAT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_NOMBRES, dgvDatos, "PER_NOMBRES")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CLIENTE", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CLIENTE"), oOrm), NombreFormulario.ChkPER_CLIENTE)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_CLIENTE_OP_CON, dgvDatos, "PER_CLIENTE_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_PROVEEDOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_PROVEEDOR"), oOrm), NombreFormulario.ChkPER_PROVEEDOR)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_PROVEEDOR_OP_CON, dgvDatos, "PER_PROVEEDOR_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRANSPORTISTA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRANSPORTISTA"), oOrm), NombreFormulario.ChkPER_TRANSPORTISTA)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_TRANSPORTISTA_OP_CON, dgvDatos, "PER_TRANSPORTISTA_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRABAJADOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRABAJADOR"), oOrm), NombreFormulario.ChkPER_TRABAJADOR)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_TRABAJADOR_OP_CON, dgvDatos, "PER_TRABAJADOR_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_BANCO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_BANCO"), oOrm), NombreFormulario.ChkPER_BANCO)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_BANCO_OP_CON, dgvDatos, "PER_BANCO_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_GRUPO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_GRUPO"), oOrm), NombreFormulario.ChkPER_GRUPO)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_GRUPO_OP_CON, dgvDatos, "PER_GRUPO_OP_CON")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CONTACTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CONTACTO"), oOrm), NombreFormulario.ChkPER_CONTACTO)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_CONTACTO_OP_CON, dgvDatos, "PER_CONTACTO_OP_CON")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_TRANSP_PROPIO, dgvDatos, "PER_TRANSP_PROPIO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE, dgvDatos, "PER_BREVETE")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_FORMA_VENTA, dgvDatos, "PER_FORMA_VENTA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_TELEFONOS, dgvDatos, "PER_TELEFONOS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_EMAIL, dgvDatos, "PER_EMAIL")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_PAGINA_WEB, dgvDatos, "PER_PAGINA_WEB")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_LINEA_CREDITO, dgvDatos, "PER_LINEA_CREDITO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DIAS_CREDITO, dgvDatos, "PER_DIAS_CREDITO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID_VEN")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, "PER_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_COB, dgvDatos, "PER_DESCRIPCION_COB")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA, dgvDatos, "PER_ID_TRA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA, dgvDatos, "PER_DESCRIPCION_TRA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, "PER_ID_BAN")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, "PER_DESCRIPCION_BAN")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, "PER_ID_GRU")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_GRU, dgvDatos, "PER_DESCRIPCION_GRU")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_DIASEM_PAGO, dgvDatos, "PER_DIASEM_PAGO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_COND_DIASEM, dgvDatos, "PER_COND_DIASEM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DIAMES_PAGO, dgvDatos, "PER_DIAMES_PAGO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_DOC_PAGO, dgvDatos, "PER_DOC_PAGO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_HORA_PAGO, dgvDatos, "PER_HORA_PAGO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_OBSERVACIONES, dgvDatos, "PER_OBSERVACIONES")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPER_CARTA_FIANZA, dgvDatos, "PER_CARTA_FIANZA")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_PROMOCIONES", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_PROMOCIONES"), oOrm), NombreFormulario.ChkPER_PROMOCIONES)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_CUOTA_MENSUAL, dgvDatos, "PER_CUOTA_MENSUAL")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_CUOTA_OBJETIVO, dgvDatos, "PER_CUOTA_OBJETIVO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BONO, dgvDatos, "PER_BONO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID_CLI, dgvDatos, "CCC_ID_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION_CLI, dgvDatos, "CCC_DESCRIPCION_CLI")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_CARGO, dgvDatos, "PER_CARGO")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_REP_LEGAL", _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_REP_LEGAL"), oOrm), NombreFormulario.ChkPER_REP_LEGAL)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_FIRMA_AUT", _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_FIRMA_AUT"), oOrm), NombreFormulario.ChkPER_FIRMA_AUT)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                    'Case 1 ' DireccionesPersonas
                    '    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                    '        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                    '        If TipoEdicion = 1 Then
                    '            Exit Sub
                    '        Else
                    '            PersonasI()
                    '            Me.Close()
                    '        End If
                    '    Else
                    '        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID, dgvDatos, 0)
                    '        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION, dgvDatos, 4)
                    '        NombreFormulario.FiltrarCampos(Comportamiento)
                    '    End If
                Case 2 ' RolPersonaTipoPersona - Vendedor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 24) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, 1)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' RolPersonaTipoPersona - Cobrador
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 24) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_COB, dgvDatos, 1)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' RolPersonaTipoPersona - Transportista
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 24) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA, dgvDatos, 1)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' RolPersonaTipoPersona - Banco
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 24) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, 1)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' RolPersonaTipoPersona - Grupo
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 22) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 24) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_GRU, dgvDatos, 1)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 7 ' Distrito
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DIS_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.dgvDireccionPersona.Item("cDIS_ID1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DIS_ID").Value.ToString()
                        NombreFormulario.dgvDireccionPersona.Item("cDIS_DESCRIPCION1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DIS_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDireccionPersona.Item("cDIS_ESTADO1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DIS_ESTADO").Value.ToString()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 8 ' CajaCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            Exit Sub
                        Else
                            PersonasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID_CLI, dgvDatos, "CCC_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION_CLI, dgvDatos, "CCC_DESCRIPCION")
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PersonasI()
            Select Case Comportamiento
                'Case 1 ' DireccionesPersonas
                '    NombreFormulario.txtDIR_ID.text = ""
                '    NombreFormulario.txtDIR_DESCRIPCION.text = ""
                Case 2 ' RolPersonaTipoPersona - Vendedor
                    NombreFormulario.txtPER_ID_VEN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_VEN.text = ""
                Case 3 ' RolPersonaTipoPersona - Cobrador
                    NombreFormulario.txtPER_ID_COB.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_COB.text = ""
                Case 4 ' RolPersonaTipoPersona - Transportista
                    NombreFormulario.txtPER_ID_TRA.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_TRA.text = ""
                Case 5 ' RolPersonaTipoPersona - Banco
                    NombreFormulario.txtPER_ID_BAN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_BAN.text = ""
                Case 6 ' RolPersonaTipoPersona - Grupo
                    NombreFormulario.txtPER_ID_GRU.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_GRU.text = ""
                Case 7 ' Distrito
                    NombreFormulario.dgvDireccionPersona.Item("cDIS_ID1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDireccionPersona.Item("cDIS_DESCRIPCION1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDireccionPersona.Item("cDIS_ESTADO1", NombreFormulario.dgvDireccionPersona.CurrentRow.Index).Value = "NO ACTIVO"
                Case 8 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID_CLI.text = ""
                    NombreFormulario.txtCCC_DESCRIPCION_CLI.text = ""
            End Select
        End Sub
        Private Sub PersonasO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Personas
                    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_PAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_MAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_NOMBRES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 2, 3, 4, 5, 6 ' Vendedor,Cobrador,Transportista,Banco,Grupo
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TPE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_VENTA_CAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CONTROL", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("RTP_ESTADO", vFlagCbo, vFlagDgv)
                Case 8 'CajaCtaCte
                    'OcultarNombresCampos("CCC_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_BAN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_CUENTA_BANCARIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CAJ", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CAJ", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_CAJ", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_FECHA_SAL_INI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_MONTO_SAL_INI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
            End Select
        End Sub
        Private Sub DocPersonas()
            Select Case Comportamiento
                Case Is <= 0 ' DocPersonas
                    NombreFormulario.txtPER_ID.Enabled = True
                    NombreFormulario.txtTDP_ID.Enabled = True

                    NombreFormulario.txtPER_ID.ReadOnly = True
                    NombreFormulario.txtTDP_ID.ReadOnly = True

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkPER_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO, dgvDatos, 3)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID, dgvDatos, 4)
                    NombreFormulario.vCodigoTDP_ID = NombreFormulario.txtTDP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION, dgvDatos, 5)

                    NombreFormulario.LongitudCampoNumero = dgvDatos.SelectedRows(0).Cells(6).Value.ToString()

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8), oOrm), NombreFormulario.ChkTDP_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), NombreFormulario.ChkDOP_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.LongitudCampoNumero, dgvDatos, 6)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocPersonasI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' TipoDocPersonas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocPersonasI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkTDP_ESTADO)
                        NombreFormulario.LongitudCampoNumero = dgvDatos.SelectedRows(0).Cells(2).Value
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DocPersonasI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO)
                Case 2 ' TipoDocPersonas
                    NombreFormulario.txtTDP_ID.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkTDP_ESTADO)
            End Select
        End Sub

        Private Sub DireccionesPersonas()
            Select Case Comportamiento
                Case Is <= 0 ' DireccionesPersonas
                    NombreFormulario.txtDIR_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtDIR_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 2)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), _
                        NombreFormulario.chkPER_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDIR_TIPO, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION, dgvDatos, 8)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIS_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), _
                        NombreFormulario.chkDIS_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19), oOrm), _
                        NombreFormulario.ChkDIR_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DireccionesPersonasI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Distrito
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 12) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DireccionesPersonasI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIS_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), NombreFormulario.ChkDIS_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DireccionesPersonasI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO)
                Case 2 ' Distrito
                    NombreFormulario.txtDIS_ID.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkDIS_ESTADO)
            End Select
        End Sub
        Private Sub DireccionesPersonasO(Optional ByVal vFlagCbo As Boolean = True, _
                                         Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case 2 ' Distrito
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_COD_SUNAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO", vFlagCbo, vFlagDgv)

                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_COD_SUNAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO", vFlagCbo, vFlagDgv)

                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO", vFlagCbo, vFlagDgv)
            End Select
        End Sub
        Private Sub ContactoPersona()
            Select Case Comportamiento
                Case Is <= 0 ' ContactoPersona
                    NombreFormulario.txtPER_ID.Enabled = True
                    NombreFormulario.txtCOP_ID.Enabled = True

                    NombreFormulario.txtPER_ID.ReadOnly = True
                    NombreFormulario.txtCOP_ID.ReadOnly = True

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOP_ID, dgvDatos, "COP_ID")
                    NombreFormulario.vCodigoCOP_ID = NombreFormulario.txtCOP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCOP_TIPO, dgvDatos, "COP_TIPO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOP_DESCRIPCION, dgvDatos, "COP_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOP_DIRECCION, dgvDatos, "COP_DIRECCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOP_TELEFONO, dgvDatos, "COP_TELEFONO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOP_EMAIL, dgvDatos, "COP_EMAIL")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("COP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "COP_ESTADO"), oOrm), NombreFormulario.ChkCOP_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ContactoPersonaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ContactoPersonaI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO)
            End Select
        End Sub

        Private Sub RolPersonaTipoPersona()
            Select Case Comportamiento
                Case Is <= 0 ' RolPersonaTipoPersona
                    NombreFormulario.txtPER_ID.Enabled = False
                    NombreFormulario.txtTPE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_PROVEEDOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_PROVEEDOR"), oOrm), NombreFormulario.ChkPER_PROVEEDOR)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CLIENTE", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CLIENTE"), oOrm), NombreFormulario.ChkPER_CLIENTE)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRANSPORTISTA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRANSPORTISTA"), oOrm), NombreFormulario.ChkPER_TRANSPORTISTA)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRABAJADOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRABAJADOR"), oOrm), NombreFormulario.ChkPER_TRABAJADOR)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_BANCO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_BANCO"), oOrm), NombreFormulario.ChkPER_BANCO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_GRUPO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_GRUPO"), oOrm), NombreFormulario.ChkPER_GRUPO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CONTACTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CONTACTO"), oOrm), NombreFormulario.ChkPER_CONTACTO)


                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_ID, dgvDatos, "TPE_ID")
                    NombreFormulario.vCodigoTPE_ID = NombreFormulario.txtTPE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_DESCRIPCION, dgvDatos, "TPE_DESCRIPCION")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CLIENTE", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CLIENTE"), oOrm), NombreFormulario.ChkTPE_CLIENTE)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_PROVEEDOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_PROVEEDOR"), oOrm), NombreFormulario.ChkTPE_PROVEEDOR)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRANSPORTISTA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRANSPORTISTA"), oOrm), NombreFormulario.ChkTPE_TRANSPORTISTA)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRABAJADOR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRABAJADOR"), oOrm), NombreFormulario.ChkTPE_TRABAJADOR)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_BANCO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_BANCO"), oOrm), NombreFormulario.ChkTPE_BANCO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_GRUPO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_GRUPO"), oOrm), NombreFormulario.ChkTPE_GRUPO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CONTACTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CONTACTO"), oOrm), NombreFormulario.ChkTPE_CONTACTO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("RTP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RTP_ESTADO"), oOrm), NombreFormulario.ChkRTP_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolPersonaTipoPersonaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CLIENTE", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CLIENTE"), oOrm), NombreFormulario.ChkPER_CLIENTE)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_PROVEEDOR", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_PROVEEDOR"), oOrm), NombreFormulario.ChkPER_PROVEEDOR)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRABAJADOR", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRABAJADOR"), oOrm), NombreFormulario.ChkPER_TRABAJADOR)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_BANCO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_BANCO"), oOrm), NombreFormulario.ChkPER_BANCO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_GRUPO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_GRUPO"), oOrm), NombreFormulario.ChkPER_GRUPO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_CONTACTO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_CONTACTO"), oOrm), NombreFormulario.ChkPER_CONTACTO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_TRANSPORTISTA", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_TRANSPORTISTA"), oOrm), NombreFormulario.ChkPER_TRANSPORTISTA)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' TipoPersonas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolPersonaTipoPersonaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_ID, dgvDatos, "TPE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTPE_DESCRIPCION, dgvDatos, "TPE_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CLIENTE", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CLIENTE"), oOrm), NombreFormulario.ChkTPE_CLIENTE)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_PROVEEDOR", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_PROVEEDOR"), oOrm), NombreFormulario.ChkTPE_PROVEEDOR)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRABAJADOR", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRABAJADOR"), oOrm), NombreFormulario.ChkTPE_TRABAJADOR)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_BANCO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_BANCO"), oOrm), NombreFormulario.ChkTPE_BANCO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_GRUPO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_GRUPO"), oOrm), NombreFormulario.ChkTPE_GRUPO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_CONTACTO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_CONTACTO"), oOrm), NombreFormulario.ChkTPE_CONTACTO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TPE_TRANSPORTISTA", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_TRANSPORTISTA"), oOrm), NombreFormulario.ChkTPE_TRANSPORTISTA)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RolPersonaTipoPersonaI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION.Text = ""
                Case 2 ' TipoPersonas
                    NombreFormulario.txtTPE_ID.Text = ""
                    NombreFormulario.txtTPE_DESCRIPCION.Text = ""
            End Select
        End Sub

        Private Sub BloqueosCodigoPersona()
            Select Case Comportamiento
                Case Is <= 0 ' BloqueosCodigoPersona
                    NombreFormulario.txtPER_ID.Enabled = True
                    NombreFormulario.txtPER_ID.ReadOnly = True

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_CONTRAENTREGA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_CONTRAENTREGA"), oOrm), NombreFormulario.ChkDOC_CONTRAENTREGA)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_SOLO_CONTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_SOLO_CONTADO"), oOrm), NombreFormulario.ChkDOC_SOLO_CONTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("BCP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "BCP_ESTADO"), oOrm), NombreFormulario.ChkBCP_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ContactoPersonaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub BloqueosCodigoPersonaI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO)
            End Select
        End Sub

        Private Sub Pais()
            Select Case Comportamiento
                Case Is <= 0 ' Datos Pais
                    NombreFormulario.txtPAI_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPAI_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                        NombreFormulario.ChkPAI_ESTADO)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub

        Private Sub Departamento()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Datos Departamento
                    NombreFormulario.txtDEP_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtDEP_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                        NombreFormulario.ChkPAI_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_COD_SUNAT, dgvDatos, 5)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), _
                        NombreFormulario.ChkDEP_ESTADO)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Datos Pais
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DepartamentoI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkPai_Estado)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select

        End Sub
        Private Sub DepartamentoI()
            Select Case Comportamiento
                Case 1 ' Datos país
                    NombreFormulario.txtPAI_ID.Text = ""
                    NombreFormulario.txtPAI_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPAI_ESTADO)
            End Select

        End Sub

        Private Sub Provincia()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Datos Provincia
                    NombreFormulario.txtPRO_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPRO_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.ChkDEP_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 7)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8), oOrm), _
                        NombreFormulario.ChkPAI_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_COD_SUNAT, dgvDatos, 9)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PRO_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), _
                        NombreFormulario.ChkPRO_ESTADO)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Datos Departamento
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ProvinciaI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION, dgvDatos, 1)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 3)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                            NombreFormulario.ChkPAI_ESTADO)

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), _
                            NombreFormulario.ChkDEP_ESTADO)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ProvinciaI()
            Select Case Comportamiento
                Case 1 ' Datos Departamento
                    NombreFormulario.txtDEP_ID.Text = ""
                    NombreFormulario.txtDEP_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkDEP_ESTADO)
                    NombreFormulario.txtPAI_ID.Text = ""
                    NombreFormulario.txtPAI_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPAI_ESTADO)
            End Select
        End Sub
        Private Sub ProvinciaO()
            Select Case Comportamiento
                Case 2
                    'dgvDatos.Columns("USU_CONTRASENA").Visible = False
                    'OcultarNombresCampos("USU_CONTRASENA")
                Case 3
                Case 4
                Case 5
            End Select
        End Sub

        Private Sub Distrito()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Datos Distrito
                    NombreFormulario.txtDis_Id.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtDIS_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PRO_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.ChkPRO_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION, dgvDatos, 7)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), _
                        NombreFormulario.ChkDEP_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 10)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 11)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 12), oOrm), _
                        NombreFormulario.ChkPAI_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_COD_SUNAT, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUBIGEO, dgvDatos, 14)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIS_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), _
                        NombreFormulario.ChkDis_Estado)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Datos Provincias
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ProvinciaI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION, dgvDatos, 1)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION, dgvDatos, 3)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEP_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                            NombreFormulario.ChkDep_Estado)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID, dgvDatos, 6)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION, dgvDatos, 7)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PAI_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8), oOrm), _
                            NombreFormulario.ChkPAI_ESTADO)

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PRO_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), _
                            NombreFormulario.ChkPro_Estado)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DistritoI()
            Select Case Comportamiento
                Case 1 ' Datos provincias
                    NombreFormulario.txtPRO_ID.Text = ""
                    NombreFormulario.txtPRO_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPRO_ESTADO)
                    NombreFormulario.txtDEP_ID.Text = ""
                    NombreFormulario.txtDEP_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkDEP_ESTADO)
                    NombreFormulario.txtPAI_ID.Text = ""
                    NombreFormulario.txtPAI_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPAI_ESTADO)
            End Select

        End Sub

        Private Sub PuntoVenta()
            Select Case Comportamiento
                Case Is <= 0 ' Datos PuntoVenta
                    NombreFormulario.txtPVE_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPVE_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DIRECCION, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_TELEFONOS, dgvDatos, 3)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION, dgvDatos, 14)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIS_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), _
                        NombreFormulario.chkDIS_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, 16)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, 17)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("LPR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 18), oOrm), _
                        NombreFormulario.ChkLPR_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboPVE_TIPO, dgvDatos, 19)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), _
                        NombreFormulario.ChkPVE_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Datos Distrito
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 12) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            PuntoVentaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DIS_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), NombreFormulario.ChkDis_Estado)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Datos ListaPreciosArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            PuntoVentaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("LPR_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO"), oOrm), NombreFormulario.ChkLPR_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PuntoVentaI()
            Select Case Comportamiento
                Case 1 ' Datos Distrito
                    NombreFormulario.txtDIS_ID.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkDIS_ESTADO)
                Case 2 ' Datos ListaPreciosArticulos
                    NombreFormulario.txtLPR_ID.text = ""
                    NombreFormulario.txtLPR_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkLPR_ESTADO)
            End Select
        End Sub

        Private Sub Moneda()
            Select Case Comportamiento
                Case Is <= 0 ' Datos Moneda
                    NombreFormulario.txtMON_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtMON_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, 2)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ORIGEN", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), _
                        NombreFormulario.ChkMON_ORIGEN)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                        NombreFormulario.ChkMON_ESTADO)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub

        Private Sub TipoCambioMoneda()
            Select Case Comportamiento
                Case Is <= 0 ' TipoCambioMoneda
                    NombreFormulario.txtMON_ID_1.Enabled = False
                    NombreFormulario.txtMON_ID_0.Enabled = False
                    NombreFormulario.dtpTCA_FECHA.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_1, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtMON_ID_1.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_1, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_1, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ORIGEN_1, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO_1", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                        NombreFormulario.chkMON_ESTADO_1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_0, dgvDatos, 6)
                    NombreFormulario.vCodigoMON_ID_0 = NombreFormulario.txtMON_ID_0.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_0, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_0, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ORIGEN_0, dgvDatos, 9)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO_0", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), _
                        NombreFormulario.chkMON_ESTADO_0)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpTCA_FECHA, dgvDatos, 12)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTCA_COMPRA, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTCA_VENTA, dgvDatos, 14)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TCA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), _
                        NombreFormulario.chkTCA_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Moneda - Sistema
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TipoCambioMonedaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_1, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_1, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_1, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ORIGEN_1, dgvDatos, 3)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                            NombreFormulario.chkMON_ESTADO_1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Moneda - A cambiar
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TipoCambioMonedaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_0, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_0, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_0, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ORIGEN_0, dgvDatos, 3)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                            NombreFormulario.chkMON_ESTADO_0)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub TipoCambioMonedaI()
            Select Case Comportamiento
                Case 1 ' Moneda - Sistema
                    NombreFormulario.txtMON_ID_1.text = ""
                    NombreFormulario.txtMON_DESCRIPCION_1.text = ""
                    NombreFormulario.txtMON_SIMBOLO_1.text = ""
                    NombreFormulario.txtMON_ORIGEN_1.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkMON_ESTADO_1)
                Case 2 ' Moneda - A cambiar
                    NombreFormulario.txtMON_ID_0.text = ""
                    NombreFormulario.txtMON_DESCRIPCION_0.text = ""
                    NombreFormulario.txtMON_SIMBOLO_0.text = ""
                    NombreFormulario.txtMON_ORIGEN_0.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkMON_ESTADO_0)
            End Select
        End Sub

        Private Sub CorrelativoTipoDocumento()
            Select Case Comportamiento
                Case Is <= 0 ' CorrelativoTipoDocumento
                    NombreFormulario.txtTDO_ID.Enabled = False
                    NombreFormulario.txtCTD_COR_SERIE.Enabled = False
                    NombreFormulario.txtPVE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTDO_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, "TDO_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDO_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO"), oOrm), _
                        NombreFormulario.chkTDO_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCTD_COR_SERIE, dgvDatos, "CTD_COR_SERIE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCTD_COR_NUMERO, dgvDatos, "CTD_COR_NUMERO")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CTD_USAR_COR", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CTD_USAR_COR"), oOrm), _
                        NombreFormulario.chkCTD_USAR_COR)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DIRECCION, dgvDatos, "PVE_DIRECCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO"), oOrm), _
                        NombreFormulario.ChkPVE_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CTD_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CTD_ESTADO"), oOrm), _
                        NombreFormulario.ChkCTD_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' TipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CorrelativoTipoDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDO_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), NombreFormulario.ChkTDO_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CorrelativoTipoDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DIRECCION, dgvDatos, 2)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), NombreFormulario.ChkPVE_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CorrelativoTipoDocumentoI()
            Select Case Comportamiento
                Case 1 ' TipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtTDO_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkTDO_ESTADO)
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.txtPVE_DIRECCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
            End Select
        End Sub

        Private Sub RolPuntoVentaAlmacen()
            Select Case Comportamiento
                Case Is <= 0 ' RolPuntoVentaAlmacen
                    NombreFormulario.txtPVE_ID.Enabled = False
                    NombreFormulario.txtALM_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPVE_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16), oOrm), _
                        NombreFormulario.chkPVE_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, 17)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, 18)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 33), oOrm), _
                        NombreFormulario.ChkALM_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("RPA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34), oOrm), _
                        NombreFormulario.ChkRPA_ESTADO)

                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CorrelativoTipoDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), NombreFormulario.ChkPVE_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Almacen
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CorrelativoTipoDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 16), oOrm), NombreFormulario.ChkALM_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RolPuntoVentaAlmacenI()
            Select Case Comportamiento
                Case 1 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
                Case 2 ' Almacen
                    NombreFormulario.txtALM_ID.text = ""
                    NombreFormulario.txtALM_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkALM_ESTADO)
            End Select
        End Sub

        Private Sub Cierre()
            Select Case Comportamiento
                Case Is <= 0 ' Cierre
                    NombreFormulario.txtCIE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCIE_ID, dgvDatos, "CIE_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtCIE_ID.Text

                    NombreFormulario.dtpFecha.value = Convert.ToDateTime(dgvDatos.SelectedRows(0).Cells("CIE_ANIO").Value & dgvDatos.SelectedRows(0).Cells("CIE_MES").Value & dgvDatos.SelectedRows(0).Cells("CIE_DIA").Value)
                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCIE_MES, dgvDatos, 1)
                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCIE_ANIO, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CIE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CIE_ESTADO"), oOrm), _
                        NombreFormulario.chkCIE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CierreI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTD_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CierreI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item("cDTD_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDTD_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CierreI()
            Select Case Comportamiento
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
                Case 3 ' DetalleTipoDocumentos
                    NombreFormulario.dgvDetalle.Item(1, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(2, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Private Sub CierreDiario()
            Select Case Comportamiento
                Case Is <= 0 ' CierreDiario
                    NombreFormulario.txtCIE_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCIE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCIE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCIE_MES, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCIE_ANIO, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 4)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CIE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), _
                        NombreFormulario.chkCIE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CierreI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 11) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 13) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CierreI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item("cDTD_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDTD_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CierreDiarioI()
            Select Case Comportamiento
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
                Case 3 ' DetalleTipoDocumentos
                    NombreFormulario.dgvDetalle.Item(1, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(2, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Private Sub RolOpeCtaCte()
            Select Case Comportamiento
                Case Is <= 0 ' RolOpeCtaCte
                    NombreFormulario.txtCCT_ID.Enabled = False
                    NombreFormulario.txtTDO_ID.Enabled = False
                    NombreFormulario.txtDTD_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCCT_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, 2)
                    NombreFormulario.vCodigoTDO_ID = NombreFormulario.txtTDO_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, 3)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, 4)
                    NombreFormulario.vCodigoDTD_ID = NombreFormulario.txtDTD_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_CARGO_ABONO, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_IDMN, dgvDatos, 11)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_MN, dgvDatos, 12)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_IDME, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ME, dgvDatos, 14)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ROC_ESCONTABLE", _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), _
                       NombreFormulario.chkROC_ESCONTABLE)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ROC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17), oOrm), _
                        NombreFormulario.chkROC_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolOpeCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 11) = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 13) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolOpeCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, 3)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_CARGO_ABONO, dgvDatos, 3)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' CuentasContables MN
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolOpeCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_IDMN, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_MN, dgvDatos, 1)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' CuentasContables ME
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            RolOpeCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_IDME, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ME, dgvDatos, 1)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RolOpeCtaCteI()
            Select Case Comportamiento
                Case 1 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                Case 2 ' DetalleTipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtTDO_DESCRIPCION.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
                Case 3 ' CuentasContables MN
                    NombreFormulario.txtCUC_IDMN.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_MN.text = ""
                Case 4 ' CuentasContables ME
                    NombreFormulario.txtCUC_IDME.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_ME.text = ""
            End Select
        End Sub

        ' Facturación
        Private Sub RestriccionArticulo()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' RestriccionArticulo
                    NombreFormulario.txtPER_ID.Enabled = False
                    NombreFormulario.txtART_ID.Enabled = False
                    NombreFormulario.dtpREA_FECHA.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtPER_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 2)
                    NombreFormulario.vCodigoART_ID = NombreFormulario.txtART_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 3)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpREA_FECHA, dgvDatos, 4)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("REA_CONDICION", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), NombreFormulario.ChkREA_CONDICION)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtREA_CANTIDAD, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboREA_MOVIMIENTO, dgvDatos, 7)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("REA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8), oOrm), NombreFormulario.ChkREA_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), _
                            NombreFormulario.ChkPER_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

                Case 2 ' Articulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            InicializarDatos()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 34), oOrm), _
                            NombreFormulario.ChkART_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub RestriccionArticuloI()
            Select Case Comportamiento
                Case 1 ' Personas
                    NombreFormulario.txtPER_ID.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION.Text = ""
                Case 2 ' Articulos
                    NombreFormulario.txtART_ID.Text = ""
                    NombreFormulario.txtART_DESCRIPCION.Text = ""
            End Select
        End Sub

        Private Sub Comision()
            Select Case Comportamiento
                Case Is <= 0 ' Comision
                    NombreFormulario.txtCOM_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCOM_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_POR_CUO_MEN, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_POR_OBJ_MEN, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCOM_VENTA_CAN, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCOM_FORMULA, dgvDatos, 5)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("COM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), NombreFormulario.ChkCOM_ESTADO)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub

        Private Sub TipoDocumentos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' RestriccionArticulo
                    NombreFormulario.txtTDO_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtTDO_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, 1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboTDO_UBICACION, dgvDatos, 2)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TDO_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), NombreFormulario.ChkTDO_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub

        Private Sub FletesTransportes()
            Select Case Comportamiento
                Case Is <= 0 ' FLetesTransportes
                    NombreFormulario.txtFLE_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtFLE_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 3)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_MONTO_COB, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_MONTO_PAG, dgvDatos, 9)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboFLE_TIPO, dgvDatos, 10)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("FLE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 11), oOrm), NombreFormulario.ChkFLE_ESTADO)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            FletesTransportesI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            FletesTransportesI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' Distrito
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PRO_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DEP_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PAI_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DIS_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            FletesTransportesI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item(3, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(0).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(4, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(1).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(5, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(15).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(6, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(2).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(7, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(3).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(8, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(5).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(9, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(6).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(10, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(7).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(11, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(9).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(12, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(10).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(13, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(11).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(14, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(12).Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub FletesTransportesI()
            Select Case Comportamiento
                Case 1 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                Case 2 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                Case 3 ' Distrito
                    NombreFormulario.dgvDetalle.Item(1, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(2, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(3, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(4, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(5, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = "NO ACTIVO"
                    NombreFormulario.dgvDetalle.Item(6, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(7, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(8, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = "NO ACTIVO"
                    NombreFormulario.dgvDetalle.Item(9, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(10, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(11, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = "NO ACTIVO"
                    NombreFormulario.dgvDetalle.Item(12, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(13, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(14, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = "NO ACTIVO"
            End Select
        End Sub

        Private Sub Documentos()
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
                    NombreFormulario.DeshabilitarModificar()

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTDO_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                    NombreFormulario.vCodigoDTD_ID = NombreFormulario.txtDTD_ID.Text
                    If NombreFormulario.NAME = "frmTipoVentaBoletaFactura" Then
                        NombreFormulario.Text = "Dar Pase a " & dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                    Else
                        NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                    End If


                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboSerieCorrelativo, dgvDatos, "DOC_SERIE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_SERIE, dgvDatos, "DOC_SERIE")
                    NombreFormulario.vCodigoDOC_SERIE = NombreFormulario.txtDOC_SERIE.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NUMERO, dgvDatos, "DOC_NUMERO")
                    NombreFormulario.vCodigoDOC_NUMERO = NombreFormulario.txtDOC_NUMERO.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FECHA_EMI, dgvDatos, "DOC_FECHA_EMI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FECHA_ENT, dgvDatos, "DOC_FECHA_ENT")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")

                    If NombreFormulario.name.ToString = "frmTipoVentaBoletaFactura" Then
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")
                        If Me.IBCBusqueda.FormaVentaTipoVenta(NombreFormulario.txtTIV_ID.Text) = BCVariablesNames.TipoVentaDescripcion.Contraentrega Then
                            NombreFormulario.txtTIV_ID.BackColor = System.Drawing.SystemColors.Control
                            NombreFormulario.txtTIV_ID.ForeColor = System.Drawing.Color.Blue

                            NombreFormulario.txtTIV_DESCRIPCION.BackColor = System.Drawing.SystemColors.Control
                            NombreFormulario.txtTIV_DESCRIPCION.ForeColor = System.Drawing.Color.Blue
                        Else
                            NombreFormulario.txtTIV_ID.BackColor = System.Drawing.SystemColors.Control
                            NombreFormulario.txtTIV_ID.ForeColor = System.Drawing.Color.Black

                            NombreFormulario.txtTIV_DESCRIPCION.BackColor = System.Drawing.SystemColors.Control
                            NombreFormulario.txtTIV_DESCRIPCION.ForeColor = System.Drawing.Color.Black
                        End If
                        'NombreFormulario.tsbGrabar.Enabled = True
                        NombreFormulario.tsbGrabar.Enabled = False
                        NombreFormulario.OcultarControlesDarPase()
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")
                    End If
                    

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_IGV_POR, dgvDatos, "DOC_IGV_POR")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION_CLI")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, "TDP_ID_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, "TDP_DESCRIPCION_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, "DOP_NUMERO_CLI")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_FIS, dgvDatos, "DIR_ID_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_FIS, dgvDatos, "DIR_DESCRIPCION_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_FIS, dgvDatos, "DIR_REFERENCIA_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_FIS, dgvDatos, "DIS_ID_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_FIS, dgvDatos, "DIS_DESCRIPCION_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_FIS, dgvDatos, "PRO_ID_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_FIS, dgvDatos, "PRO_DESCRIPCION_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_FIS, dgvDatos, "DEP_ID_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_FIS, dgvDatos, "DEP_DESCRIPCION_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_FIS, dgvDatos, "PAI_ID_FIS")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_FIS, dgvDatos, "PAI_DESCRIPCION_FIS")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_DOM, dgvDatos, "DIR_ID_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_DOM, dgvDatos, "DIR_DESCRIPCION_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_DOM, dgvDatos, "DIR_REFERENCIA_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_DOM, dgvDatos, "DIS_ID_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_DOM, dgvDatos, "DIS_DESCRIPCION_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_DOM, dgvDatos, "PRO_ID_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_DOM, dgvDatos, "PRO_DESCRIPCION_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_DOM, dgvDatos, "DEP_ID_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_DOM, dgvDatos, "DEP_DESCRIPCION_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_DOM, dgvDatos, "PAI_ID_DOM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_DOM, dgvDatos, "PAI_DESCRIPCION_DOM")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_COB, dgvDatos, "DIR_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_COB, dgvDatos, "DIR_DESCRIPCION_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_COB, dgvDatos, "DIR_REFERENCIA_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_COB, dgvDatos, "DIS_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_COB, dgvDatos, "DIS_DESCRIPCION_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_COB, dgvDatos, "PRO_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_COB, dgvDatos, "PRO_DESCRIPCION_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_COB, dgvDatos, "DEP_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_COB, dgvDatos, "DEP_DESCRIPCION_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_COB, dgvDatos, "PAI_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_COB, dgvDatos, "PAI_DESCRIPCION_COB")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, "TDP_ID_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, "TDP_DESCRIPCION_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, "DOP_NUMERO_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, "DIR_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, "DIR_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, "DIR_REFERENCIA_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, "DIS_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, "DIS_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, "PRO_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, "PRO_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, "DEP_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, "DEP_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, "PAI_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, "PAI_DESCRIPCION_ENT_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_ORDEN_COMPRA, dgvDatos, "DOC_ORDEN_COMPRA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_TIPO_ORDEN_COMPRA, dgvDatos, "DOC_TIPO_ORDEN_COMPRA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FECHA_EXP, dgvDatos, "DOC_FECHA_EXP")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID_VEN")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, "PER_ID_COB")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_COB, dgvDatos, "PER_DESCRIPCION_COB")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, "PER_ID_GRU")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_GRU, dgvDatos, "PER_DESCRIPCION_GRU")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CON, dgvDatos, "PER_ID_CON")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CON, dgvDatos, "PER_DESCRIPCION_CON")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_PRO, dgvDatos, "PER_ID_PRO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_PRO, dgvDatos, "PER_DESCRIPCION_PRO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_OBSERVACIONES, dgvDatos, "DOC_OBSERVACIONES")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID_DES, dgvDatos, "PVE_ID_DES")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION_DES, dgvDatos, "PVE_DESCRIPCION_DES")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_MONTO_FLE, dgvDatos, "DOC_MONTO_FLE")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_ESTADO, dgvDatos, "DOC_ESTADO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_NUMERO_PRO, dgvDatos, "CAF_IX_NUMERO_PRO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_ORDEN_COM, dgvDatos, "CAF_IX_ORDEN_COM")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_ENTREGADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ENTREGADO"), oOrm), NombreFormulario.ChkDOC_ENTREGADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_ASIENTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ASIENTO"), oOrm), NombreFormulario.ChkDOC_ASIENTO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_CIERRE, dgvDatos, "DOC_CIERRE")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_REQUIERE_GUIA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_REQUIERE_GUIA"), oOrm), NombreFormulario.ChkDOC_REQUIERE_GUIA)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_AFE, dgvDatos, "TDO_ID_AFE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_AFE, dgvDatos, "DTD_ID_AFE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_AFE, dgvDatos, "DTD_DESCRIPCION_AFE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID_AFE, dgvDatos, "CCT_ID_AFE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION_AFE, dgvDatos, "CCT_DESCRIPCION_AFE")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_SERIE_AFE, dgvDatos, "DOC_SERIE_AFE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NUMERO_AFE, dgvDatos, "DOC_NUMERO_AFE")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_MOT_EMI, dgvDatos, "DOC_MOT_EMI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NOMBRE_RECEP, dgvDatos, "DOC_NOMBRE_RECEP")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_DNI_RECEP, dgvDatos, "DOC_DNI_RECEP")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FEC_RECEP, dgvDatos, "DOC_FEC_RECEP")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_MONTO_TOTAL, dgvDatos, "DOC_MONTO_TOTAL")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_OBSERVACIONES, dgvDatos, "DOC_OBSERVACIONES")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_ATENCION, dgvDatos, "DOC_ATENCION")

                    NombreFormulario.ProcesarTipoCambioMoneda()
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    ' ojito
                    If Comportamiento = -1 Then
                        NombreFormulario.BuscarDetalle(NombreFormulario.CodigoId, _
                                                       NombreFormulario.vCodigoDTD_ID, _
                                                       NombreFormulario.vCodigoDOC_SERIE, _
                                                       NombreFormulario.vCodigoDOC_NUMERO, _
                                                       NombreFormulario.txtCCT_ID.Text)
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                    'If NombreFormulario.pDocumentoProcesandose = 1000 Then NombreFormulario.btnImagen.focus()
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 18) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID_DES, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_TIPO_LISTA, dgvDatos, 19)

                        Select Case NombreFormulario.txtPVE_ID.text
                            Case BCVariablesNames.PuntosVentaArequipa.Apacheta, _
                                 BCVariablesNames.PuntosVentaArequipa.CerroColorado, _
                                 BCVariablesNames.PuntosVentaArequipa.ConoNorte, _
                                 BCVariablesNames.PuntosVentaArequipa.MariscalCastilla
                                NombreFormulario.vDOC_TIPO_LISTA = "PLANTA"
                            Case Else
                                cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_TIPO_LISTA, dgvDatos, "PVE_TIPO")
                        End Select

                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_TIPO_LISTA, dgvDatos, "PVE_TIPO")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vPVE_TIPO, dgvDatos, 19)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, 16)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 13) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, 2)
                        NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells(3).Value.ToString()

                        NombreFormulario.pDTD_ID = NombreFormulario.txtDTD_ID.text

                        Select Case NombreFormulario.pDTD_ID
                            Case BCVariablesNames.ProcesosFacturación.PBBoleta
                                NombreFormulario.pTDO_ID = NombreFormulario.txtTDO_ID.text
                                NombreFormulario.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoDNI
                            Case BCVariablesNames.ProcesosFacturación.PFFactura
                                NombreFormulario.pTDO_ID = NombreFormulario.txtTDO_ID.text
                                NombreFormulario.pTDP_ID_CLI = BCVariablesNames.TipoDocumentosPersonas.TipoDocumentoRUC
                        End Select

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, 2)
                        NombreFormulario.ProcesarTipoCambioMoneda()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' TipoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' Personas - Cliente
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        Dim vPER_PROMOCIONES As String = ""
                        cMisProcedimientos.ColocarDatosGrid(vPER_PROMOCIONES, dgvDatos, "PER_PROMOCIONES")
                        If vPER_PROMOCIONES = BCVariablesNames.ProcesarDescuento Then
                            NombreFormulario.pProcesarDescuentoIncremento = True
                        Else
                            NombreFormulario.pProcesarDescuentoIncremento = False
                        End If

                        NombreFormulario.pPER_FORMA_VENTA = dgvDatos.SelectedRows(0).Cells("PER_FORMA_VENTA").Value.ToString

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID_VEN")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, "PER_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, "PER_ID_GRU")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_LINEA_CREDITO, dgvDatos, "PER_LINEA_CREDITO")

                        NombreFormulario.txtDeuda.text = "0"
                        NombreFormulario.txtDisponible.text = "0"

                        DocumentosI(26)  ' Documentos - Nota Crédito/Débito

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 7 ' DocPersona - Cliente
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.txtPER_ID_CLI.text.trim = "" Then
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, 0)
                        End If
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, 3)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 8 ' DireccionesPersonas - Fiscal
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_FIS, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_FIS, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_FIS, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_FIS, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_FIS, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_FIS, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_FIS, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_FIS, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_FIS, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_FIS, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_FIS, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 9 ' DireccionesPersonas - Domicilio
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_DOM, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_DOM, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_DOM, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_DOM, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_DOM, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_DOM, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_DOM, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_DOM, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_DOM, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_DOM, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_DOM, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 10 ' DireccionesPersonas - Cobranza
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_COB, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_COB, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_COB, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_COB, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_COB, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_COB, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_COB, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_COB, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_COB, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_COB, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_COB, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 11 ' DireccionesPersonas - Entrega
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 12 ' Personas - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 13 ' DocPersona - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.txtPER_ID_REC.text.trim = "" Then
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, 0)
                        End If
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, 3)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 14 ' DireccionesPeronas - Entrega - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 15 ' Personas - Vendedor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 16 ' Personas - Cobrador
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_COB, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 17 ' Personas - Grupo
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ID") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_GRU, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 18 ' Personas - Contacto
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CON, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CON, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 19 ' Personas - Promotor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_PRO, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_PRO, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 20 ' PuntoVenta - Despacho
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 18) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID_DES, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION_DES, dgvDatos, 1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, 16)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 21 ' ListaPreciosArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 22 ' DetalleFletesTransporte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "FDE_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "FLE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")
                        If NombreFormulario.txtMON_ID.Text <> dgvDatos.SelectedRows(0).Cells("MON_ID").Value Then
                            If CDbl(NombreFormulario.TipoCambioCompraMoneda) = 0 Then
                                NombreFormulario.txtDOC_MONTO_FLE.text = "0"
                            Else
                                NombreFormulario.txtDOC_MONTO_FLE.text = (CDbl(dgvDatos.SelectedRows(0).Cells("FLE_MONTO_COB").Value) / _
                                                                          CDbl(NombreFormulario.TipoCambioCompraMoneda))
                            End If
                        Else
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_MONTO_FLE, dgvDatos, "FLE_MONTO_COB")
                        End If

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 23 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 24 ' CartaFianza - Número de proceso
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_NUMERO_PRO, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_ORDEN_COM, dgvDatos, 12)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 25 ' DetalleListaPrecios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DLP_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.txtMON_ID.Text <> dgvDatos.SelectedRows(0).Cells("MON_ID").Value Then
                            If CDbl(NombreFormulario.TipoCambioCompraMoneda) = 0 Then
                                NombreFormulario.pDLP_PRECIO_MINIMO = 0
                                NombreFormulario.pDLP_PRECIO_UNITARIO = 0
                                NombreFormulario.pDLP_RECARGO_ENVIO = 0
                                NombreFormulario.dgvDetalle.Item("cDDO_PRE_UNI", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                            Else
                                NombreFormulario.pDLP_PRECIO_MINIMO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_MINIMO").Value.ToString) / _
                                                                       CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                NombreFormulario.pDLP_PRECIO_UNITARIO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_UNITARIO").Value.ToString) / _
                                                                         CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                NombreFormulario.pDLP_RECARGO_ENVIO = (
                                                                        (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_RECARGO_ENVIO").Value.ToString)
                                                                      ) / _
                                                                       CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                ''* CDbl(dgvDatos.SelectedRows(0).Cells("ART_FACTOR").Value.ToString)
                                NombreFormulario.ProcesarPrecios()
                            End If
                        Else
                            NombreFormulario.pDLP_PRECIO_MINIMO = CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_MINIMO").Value.ToString)
                            NombreFormulario.pDLP_PRECIO_UNITARIO = CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_UNITARIO").Value.ToString)
                            NombreFormulario.pDLP_RECARGO_ENVIO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_RECARGO_ENVIO").Value.ToString))
                            ''* CDbl(dgvDatos.SelectedRows(0).Cells("ART_FACTOR").Value.ToString))
                            NombreFormulario.ProcesarPrecios()
                        End If
                        NombreFormulario.dgvDetalle.Item("cART_ID_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_ID_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cUM_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("UM_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDDO_ART_FACTOR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_FACTOR").Value.ToString()

                        NombreFormulario.dgvDetalle.Item("cDDO_DES_INC_PRE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                        NombreFormulario.dgvDetalle.Item("cTDO_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvDetalle.Item("cDTD_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvDetalle.Item("cCCT_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvDetalle.Item("cDDO_SERIE_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvDetalle.Item("cDDO_NUMERO_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""

                        NombreFormulario.dgvDetalle.Item("cDDO_INC_IGV", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_INC_IGV").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_AFE_PER", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_AFE_PER").Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 26 ' Documentos - Nota Crédito/Débito
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_AFE, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_AFE, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_AFE, dgvDatos, "DTD_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID_AFE, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION_AFE, dgvDatos, "CCT_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_SERIE_AFE, dgvDatos, "DOC_SERIE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NUMERO_AFE, dgvDatos, "DOC_NUMERO")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.lblMON_SIMBOLO_AFE, dgvDatos, "MON_SIMBOLO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_AFE, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMONTO_AFE, dgvDatos, "DOC_MONTO_TOTAL")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 27 ' SaldosKardexDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "SALDO") = 0 Or _
                       Trim(NombreFormulario.dgvDetalle.Item("cART_ID_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value) = "" Or _
                       NombreFormulario.dgvDetalle.Item("cDDO_CANTIDAD", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0 Or _
                       NombreFormulario.dgvDetalle.Item("cDDO_DES_INC_PRE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value >= 0 Or _
                       NombreFormulario.dgvDetalle.Item("cDDO_PRE_UNI", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0 Then
                        MsgBox("Datos no se pueden procesar :" & Chr(13) & _
                               " - Saldo del anticipo es 0." & Chr(13) & _
                               " - Código de artículo errado." & Chr(13) & _
                               " - Cantidad errada." & Chr(13) & _
                               " - Descuento/Incremento, debe tener valor negativo." & Chr(13) & _
                               " - Precio unitario errado." & Chr(13), _
                               MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.dgvDetalle.Item("cDDO_DES_INC_PRE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = CDbl(NombreFormulario.dgvDetalle.Item("cDDO_PRE_UNI", NombreFormulario.dgvDetalle.CurrentRow.Index).Value) * -1
                        NombreFormulario.dgvDetalle.Item("cTDO_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDTD_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cCCT_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDDO_SERIE_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cDDO_NUMERO_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()

                        NombreFormulario.ProcesarPrecios()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 28 ' DetalleListaPrecios - Detalle, precio
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DLP_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.txtMON_ID.Text <> dgvDatos.SelectedRows(0).Cells("MON_ID").Value Then
                            If CDbl(NombreFormulario.TipoCambioCompraMoneda) = 0 Then
                                NombreFormulario.pDLP_PRECIO_MINIMO = 0
                                NombreFormulario.pDLP_PRECIO_UNITARIO = 0
                                NombreFormulario.pDLP_RECARGO_ENVIO = 0
                                NombreFormulario.dgvDetalle.Item(6, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                                NombreFormulario.ProcesarPrecios()
                            Else
                                NombreFormulario.pDLP_PRECIO_MINIMO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_MINIMO").Value.ToString) / _
                                                                       CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                NombreFormulario.pDLP_PRECIO_UNITARIO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_UNITARIO").Value.ToString) / _
                                                                         CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                NombreFormulario.pDLP_RECARGO_ENVIO = (
                                                                        (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_RECARGO_ENVIO").Value.ToString)
                                                                      ) / _
                                                                      CDbl(NombreFormulario.TipoCambioCompraMoneda))
                                '' * CDbl(dgvDatos.SelectedRows(0).Cells("ART_FACTOR").Value.ToString)
                                NombreFormulario.ProcesarPrecios()
                            End If
                        Else
                            If CDbl(NombreFormulario.dgvDetalle.Item("cDDO_PRE_UNI", NombreFormulario.dgvDetalle.CurrentRow.Index).Value) < _
                               CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_MINIMO").Value) Then
                                NombreFormulario.pDLP_PRECIO_MINIMO = CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_MINIMO").Value.ToString)
                                NombreFormulario.pDLP_PRECIO_UNITARIO = CDbl(dgvDatos.SelectedRows(0).Cells("DLP_PRECIO_UNITARIO").Value.ToString)
                                NombreFormulario.pDLP_RECARGO_ENVIO = (CDbl(dgvDatos.SelectedRows(0).Cells("DLP_RECARGO_ENVIO").Value.ToString))
                                '' * CDbl(dgvDatos.SelectedRows(0).Cells("ART_FACTOR").Value.ToString)
                                NombreFormulario.ProcesarPrecios()
                            End If
                        End If
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 29 ' SaldosKardexDocumentos - btnAnticipos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "SALDO") >= 0 Then
                        MsgBox("Datos no se pueden procesar", _
                               MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.pMontoAnticipo = CDbl(dgvDatos.SelectedRows(0).Cells("SALDO").Value) * -1
                        NombreFormulario.pTDO_ID_ANT = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                        NombreFormulario.pDTD_ID_ANT = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                        NombreFormulario.pCCT_ID_ANT = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                        NombreFormulario.pDDO_SERIE_ANT = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                        NombreFormulario.pDDO_NUMERO_ANT = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()

                        NombreFormulario.ProcesarAnticipos()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 30 ' Documentos - Proformas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ESTADO") <> "POR PROCESAR" Then
                        MsgBox("Datos no se pueden procesar", _
                               MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.DeshabilitarModificar()
                        NombreFormulario.pProcesandoProforma = True
                        Dim vCodigoTDO_ID = ""
                        Dim vCodigoDTD_ID = ""
                        Dim vCodigoCCT_ID = ""
                        Dim vCodigoDOC_SERIE = ""
                        Dim vCodigoDOC_NUMERO = ""

                        cMisProcedimientos.ColocarDatosGrid(vCodigoTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDOC_SERIE, dgvDatos, "DOC_SERIE")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDOC_NUMERO, dgvDatos, "DOC_NUMERO")

                        If NombreFormulario.dtpDOC_FECHA_EMI.value > cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_FECHA_ENT") Then
                            NombreFormulario.dtpDOC_FECHA_ENT.value = NombreFormulario.dtpDOC_FECHA_EMI.value
                        Else
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FECHA_ENT, dgvDatos, "DOC_FECHA_ENT")
                        End If

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_IGV_POR, dgvDatos, "DOC_IGV_POR")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION_CLI")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, "TDP_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, "TDP_DESCRIPCION_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, "DOP_NUMERO_CLI")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_FIS, dgvDatos, "DIR_ID_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_FIS, dgvDatos, "DIR_DESCRIPCION_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_FIS, dgvDatos, "DIR_REFERENCIA_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_FIS, dgvDatos, "DIS_ID_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_FIS, dgvDatos, "DIS_DESCRIPCION_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_FIS, dgvDatos, "PRO_ID_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_FIS, dgvDatos, "PRO_DESCRIPCION_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_FIS, dgvDatos, "DEP_ID_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_FIS, dgvDatos, "DEP_DESCRIPCION_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_FIS, dgvDatos, "PAI_ID_FIS")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_FIS, dgvDatos, "PAI_DESCRIPCION_FIS")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_DOM, dgvDatos, "DIR_ID_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_DOM, dgvDatos, "DIR_DESCRIPCION_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_DOM, dgvDatos, "DIR_REFERENCIA_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_DOM, dgvDatos, "DIS_ID_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_DOM, dgvDatos, "DIS_DESCRIPCION_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_DOM, dgvDatos, "PRO_ID_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_DOM, dgvDatos, "PRO_DESCRIPCION_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_DOM, dgvDatos, "DEP_ID_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_DOM, dgvDatos, "DEP_DESCRIPCION_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_DOM, dgvDatos, "PAI_ID_DOM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_DOM, dgvDatos, "PAI_DESCRIPCION_DOM")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_COB, dgvDatos, "DIR_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_COB, dgvDatos, "DIR_DESCRIPCION_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_COB, dgvDatos, "DIR_REFERENCIA_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_COB, dgvDatos, "DIS_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_COB, dgvDatos, "DIS_DESCRIPCION_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_COB, dgvDatos, "PRO_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_COB, dgvDatos, "PRO_DESCRIPCION_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_COB, dgvDatos, "DEP_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_COB, dgvDatos, "DEP_DESCRIPCION_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_COB, dgvDatos, "PAI_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_COB, dgvDatos, "PAI_DESCRIPCION_COB")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, "TDP_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, "TDP_DESCRIPCION_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, "DOP_NUMERO_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, "DIR_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, "DIR_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, "DIR_REFERENCIA_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, "DIS_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, "DIS_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, "PRO_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, "PRO_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, "DEP_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, "DEP_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, "PAI_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, "PAI_DESCRIPCION_ENT_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_ORDEN_COMPRA, dgvDatos, "DOC_ORDEN_COMPRA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_TIPO_ORDEN_COMPRA, dgvDatos, "DOC_TIPO_ORDEN_COMPRA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FECHA_EXP, dgvDatos, "DOC_FECHA_EXP")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID_VEN")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_COB, dgvDatos, "PER_ID_COB")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_COB, dgvDatos, "PER_DESCRIPCION_COB")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_GRU, dgvDatos, "PER_ID_GRU")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_GRU, dgvDatos, "PER_DESCRIPCION_GRU")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CON, dgvDatos, "PER_ID_CON")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CON, dgvDatos, "PER_DESCRIPCION_CON")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_PRO, dgvDatos, "PER_ID_PRO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_PRO, dgvDatos, "PER_DESCRIPCION_PRO")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID_DES, dgvDatos, "PVE_ID_DES")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION_DES, dgvDatos, "PVE_DESCRIPCION_DES")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_MONTO_FLE, dgvDatos, "DOC_MONTO_FLE")

                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")

                        If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ESTADO") = "POR PROCESAR" Then
                            NombreFormulario.cboDOC_ESTADO.text = "ACTIVO"
                        End If

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_NUMERO_PRO, dgvDatos, "CAF_IX_NUMERO_PRO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_ORDEN_COM, dgvDatos, "CAF_IX_ORDEN_COM")

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_ENTREGADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ENTREGADO"), oOrm), NombreFormulario.ChkDOC_ENTREGADO)

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_ASIENTO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ASIENTO"), oOrm), NombreFormulario.ChkDOC_ASIENTO)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_CIERRE, dgvDatos, "DOC_CIERRE")

                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DOC_REQUIERE_GUIA", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_REQUIERE_GUIA"), oOrm), NombreFormulario.ChkDOC_REQUIERE_GUIA)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_AFE, dgvDatos, "TDO_ID_AFE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_AFE, dgvDatos, "DTD_ID_AFE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_AFE, dgvDatos, "DTD_DESCRIPCION_AFE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID_AFE, dgvDatos, "CCT_ID_AFE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION_AFE, dgvDatos, "CCT_DESCRIPCION_AFE")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_SERIE_AFE, dgvDatos, "DOC_SERIE_AFE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NUMERO_AFE, dgvDatos, "DOC_NUMERO_AFE")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDOC_MOT_EMI, dgvDatos, "DOC_MOT_EMI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_NOMBRE_RECEP, dgvDatos, "DOC_NOMBRE_RECEP")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_DNI_RECEP, dgvDatos, "DOC_DNI_RECEP")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDOC_FEC_RECEP, dgvDatos, "DOC_FEC_RECEP")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_MONTO_TOTAL, dgvDatos, "DOC_MONTO_TOTAL")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_OBSERVACIONES, dgvDatos, "DOC_OBSERVACIONES")

                        NombreFormulario.ProcesarTipoCambioMoneda()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.BuscarDetalle(vCodigoTDO_ID, _
                                                       vCodigoDTD_ID, _
                                                       vCodigoDOC_SERIE, _
                                                       vCodigoDOC_NUMERO, _
                                                       vCodigoCCT_ID, _
                                                       True)
                    End If
            End Select
        End Sub
        Private Sub DocumentosI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_ID_DES.text = ""
                    NombreFormulario.txtLPR_ID.text = ""
                Case 3 ' DetalleTipoDocumentos
                    NombreFormulario.txtDTD_ID.text = ""
                Case 4 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.txtMON_SIMBOLO.text = ""
                Case 5 ' TipoVenta
                    NombreFormulario.txtTIV_ID.text = ""
                    NombreFormulario.txtTIV_DESCRIPCION.text = ""
                Case 6 ' Personas - Cliente
                    NombreFormulario.txtPER_ID_CLI.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CLI.text = ""
                    NombreFormulario.txtPER_ID_VEN.text = ""
                    NombreFormulario.txtPER_ID_COB.text = ""
                    NombreFormulario.txtPER_ID_GRU.text = ""
                    NombreFormulario.pPER_FORMA_VENTA = BCVariablesNames.FormaVenta.Ninguno
                    NombreFormulario.txtPER_LINEA_CREDITO.text = "0"
                    NombreFormulario.txtDeuda.text = "0"
                    NombreFormulario.txtDisponible.text = "0"
                    DocumentosI(26)
                Case 7 ' DocPersona - Cliente
                    NombreFormulario.txtTDP_ID_CLI.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION_CLI.text = ""
                    NombreFormulario.txtDOP_NUMERO_CLI.text = ""
                Case 8 ' DireccionesPersonas - Fiscal
                    NombreFormulario.txtDIR_ID_FIS.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_FIS.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_FIS.text = ""
                    NombreFormulario.txtDIS_ID_FIS.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_FIS.text = ""
                    NombreFormulario.txtPRO_ID_FIS.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_FIS.text = ""
                    NombreFormulario.txtDEP_ID_FIS.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_FIS.text = ""
                    NombreFormulario.txtPAI_ID_FIS.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_FIS.text = ""
                Case 9 ' DireccionesPersonas - Domicilio
                    NombreFormulario.txtDIR_ID_DOM.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_DOM.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_DOM.text = ""
                    NombreFormulario.txtDIS_ID_DOM.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_DOM.text = ""
                    NombreFormulario.txtPRO_ID_DOM.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_DOM.text = ""
                    NombreFormulario.txtDEP_ID_DOM.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_DOM.text = ""
                    NombreFormulario.txtPAI_ID_DOM.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_DOM.text = ""
                Case 10 ' DireccionesPersonas - Cobranza
                    NombreFormulario.txtDIR_ID_COB.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_COB.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_COB.text = ""
                    NombreFormulario.txtDIS_ID_COB.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_COB.text = ""
                    NombreFormulario.txtPRO_ID_COB.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_COB.text = ""
                    NombreFormulario.txtDEP_ID_COB.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_COB.text = ""
                    NombreFormulario.txtPAI_ID_COB.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_COB.text = ""
                Case 11 ' DireccionesPersonas - Entrega
                    NombreFormulario.txtDIR_ID_ENT.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT.text = ""
                    NombreFormulario.txtDIS_ID_ENT.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPRO_ID_ENT.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDEP_ID_ENT.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPAI_ID_ENT.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT.text = ""
                Case 12 ' Personas - Recepciona
                    NombreFormulario.txtPER_ID_REC.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_REC.text = ""
                Case 13 ' DocPersona - Recepciona
                    NombreFormulario.txtTDP_ID_REC.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION_REC.text = ""
                    NombreFormulario.txtDOP_NUMERO_REC.text = ""
                Case 14 ' DireccionesPersonas - Entrega - Recepciona
                    NombreFormulario.txtDIR_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT_REC.text = ""
                    NombreFormulario.txtDIS_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPRO_ID_ENT_REC.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDEP_ID_ENT_REC.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPAI_ID_ENT_REC.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT_REC.text = ""
                Case 15 ' Personas - Vendedor
                    NombreFormulario.txtPER_ID_VEN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_VEN.text = ""
                Case 16 ' Personas - Cobrador
                    NombreFormulario.txtPER_ID_COB.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_COB.text = ""
                Case 17 ' Personas - Grupo
                    NombreFormulario.txtPER_ID_GRU.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_GRU.text = ""
                Case 18 ' Personas - Contacto
                    NombreFormulario.txtPER_ID_CON.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CON.text = ""
                Case 19 ' Personas - Promotor
                    NombreFormulario.txtPER_ID_PRO.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_PRO.text = ""
                Case 20 ' PuntoVenta - Despacho
                    NombreFormulario.txtPVE_ID_DES.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION_DES.text = ""
                Case 21 ' ListaPreciosArticulo
                    NombreFormulario.txtLPR_ID.text = ""
                    NombreFormulario.txtLPR_DESCRIPCION.text = ""
                Case 22 ' FletesTransporte
                    NombreFormulario.txtFLE_ID.text = ""
                    NombreFormulario.txtFLE_DESCRIPCION.text = ""
                    NombreFormulario.txtDOC_MONTO_FLE.text = ""
                Case 23 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                Case 24 ' CartaFianza - Número de proceso
                    NombreFormulario.txtCAF_IX_NUMERO_PRO.text = ""
                    NombreFormulario.txtCAF_IX_ORDEN_COM.text = ""
                Case 25 ' DetalleListaPrecios
                    NombreFormulario.pDLP_PRECIO_MINIMO = 0
                    NombreFormulario.pDLP_PRECIO_UNITARIO = 0
                    NombreFormulario.pDLP_RECARGO_ENVIO = 0
                    NombreFormulario.dgvDetalle.Item("cART_ID_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_ID_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cUM_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_CANTIDAD", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvDetalle.Item("cDDO_ART_FACTOR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvDetalle.Item("cDDO_PRE_UNI", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvDetalle.Item("cDDO_DES_INC_PRE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvDetalle.Item("cTDO_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDTD_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cCCT_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_SERIE_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_NUMERO_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_INC_IGV", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_AFE_PER", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = "NINGUNO"
                Case 26 ' Documentos - Nota Crédito/Débito
                    NombreFormulario.txtTDO_ID_AFE.text = ""
                    NombreFormulario.txtDTD_ID_AFE.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION_AFE.text = ""
                    NombreFormulario.txtCCT_ID_AFE.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION_AFE.text = ""

                    NombreFormulario.txtDOC_SERIE_AFE.text = ""
                    NombreFormulario.txtDOC_NUMERO_AFE.text = ""

                    NombreFormulario.lblMON_SIMBOLO_AFE.text = ""
                    NombreFormulario.txtMON_ID_AFE.text = ""
                    NombreFormulario.txtMONTO_AFE.text = ""
                Case 27 'SaldosKardexDocumentos
                    NombreFormulario.dgvDetalle.Item("cDDO_DES_INC_PRE", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = CDbl(0)
                    NombreFormulario.dgvDetalle.Item("cTDO_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDTD_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cCCT_ID_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_SERIE_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cDDO_NUMERO_ANT", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                Case 28 ' DetalleListaPrecios
                    NombreFormulario.pDLP_PRECIO_MINIMO = 0
                    NombreFormulario.pDLP_PRECIO_UNITARIO = 0
                    NombreFormulario.pDLP_RECARGO_ENVIO = 0
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(vComportamiento)
        End Sub
        Private Sub DocumentosO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
                    If pNombreFormulario.Name.ToString = "frmTipoVentaBoletaFactura" Then
                        OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DOC_SERIE", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DOC_NUMERO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_TIPO_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDP_ID_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOP_NUMERO_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PVE_ID_DES", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PVE_DESCRIPCION_DES", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TIV_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("TIV_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_CON", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_CON", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDP_ID_CLI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ID_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_TIPO_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_REFERENCIA_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_ID_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_ID_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_ID_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_ID_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ESTADO_FIS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ID_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_TIPO_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_REFERENCIA_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_ID_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_ID_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_ID_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_ID_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ESTADO_DOM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ID_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_TIPO_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_ID_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_ID_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_ID_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_ID_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ESTADO_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_TIPO_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_REFERENCIA_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIS_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PRO_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DEP_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PAI_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DIR_ESTADO_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_FECHA_EMI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_FECHA_ENT", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_FECHA_EXP", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_PRO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_PRO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_MONTO_TOTAL", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_CONTRAVALOR", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_IGV_POR", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_ASIENTO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_CIERRE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("FLE_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("FLE_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDO_ID_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDO_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_ID_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CCT_ID_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CCT_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_CARGO_ABONO_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO_D_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_SERIE_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_NUMERO_AFE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_MOT_EMI", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_NOMBRE_RECEP", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_DNI_RECEP", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_FEC_RECEP", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_ENTREGADO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CAF_IX_NUMERO_PRO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("CAF_IX_ORDEN_COM", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DOC_ESTADO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TIV_DIAS", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    Else
                        OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)

                        OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

                        OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                        OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    'OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_UBICACION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_PROCESO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_TABLA", vFlagCbo, vFlagDgv)
                Case 6, 12 ' Personas : Cliente, Recepciona
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_PAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_MAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_NOMBRES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 7, 13 ' DocPersona - Cliente
                    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOP_NUMERO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_LONGITUD", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_COD_SUNAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOP_ESTADO", vFlagCbo, vFlagDgv)
                Case 8, 9, 10, 11, 14 ' DireccionPersona
                    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO", vFlagCbo, vFlagDgv)
                Case 15, 16, 17 ' Vendedor, Cobrador, Grupo
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_PAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_MAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_NOMBRES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 22 ' DetalleFleteTransporte
                    OcultarNombresCampos("FLE_ID", False, vFlagDgv)
                    OcultarNombresCampos("FDE_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", False, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION", False, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("MON_ID", False, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("FLE_TIPO", False, vFlagDgv)
                    OcultarNombresCampos("FLE_MONTO_COB", False, vFlagDgv)
                    OcultarNombresCampos("FLE_MONTO_PAG", False, vFlagDgv)
                Case 25 ' DetalleListaPrecios - Detalle
                    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_PRINCIPAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ART_FACTOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ART_INC_IGV", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_CONTROL", True, False)
                Case 27, 29 ' SaldosKardexDocumentos - Detalle
                    OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("SALDO", True, False)
                    'OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                Case Is = 30 ' Documentos - Proforma
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)

                    'OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

                    'OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        Private Sub GenerarDocumentoPromocion()
            Select Case Comportamiento
                Case Is <= 0 ' GenerarDocumentoPromocion
                    NombreFormulario.txtDPR_NUMERO.Enabled = False
                    NombreFormulario.cboDPR_TIPO_PROMOCION.Enabled = False
                    NombreFormulario.txtPER_ID_PRO.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDPR_NUMERO, dgvDatos, "DPR_NUMERO")
                    NombreFormulario.CodigoId = NombreFormulario.txtDPR_NUMERO.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDPR_TIPO_PROMOCION, dgvDatos, "DPR_TIPO_PROMOCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDPR_FECHA, dgvDatos, "DPR_FECHA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_PRO, dgvDatos, "PER_ID_PRO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_PRO, dgvDatos, "PER_DESCRIPCION_PRO")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_PRO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_PRO"), oOrm), NombreFormulario.ChkPER_ESTADO_PRO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DPR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DPR_ESTADO"), oOrm), NombreFormulario.ChkDPR_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                    'If NombreFormulario.pDocumentoProcesandose = 1000 Then NombreFormulario.btnImagen.focus()
                Case 1 ' Personas - Promotor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_PRO, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_PRO, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                                cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO_PRO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub GenerarDocumentoPromocionI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 1 ' Personas - Promotor
                    NombreFormulario.txtPER_ID_PRO.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_PRO.text = ""
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(vComportamiento)
        End Sub
        Private Sub GenerarDocumentoPromocionO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
        End Sub


        Private Sub DocumentosEmitidos()
            Select Case Comportamiento
                Case Is <= 0 ' DetalleDocumentos
                Case 1 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "ENTRAN TODOS" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "ENTRAN TODOS" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "ENTRAN TODOS" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                        NombreFormulario.txtCTD_COR_SERIE.text = ""
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "ENTRAN TODOS" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_DESCRIPCION, dgvDatos, "TDO_DESCRIPCION")
                        If NombreFormulario.chkProcesar.CheckState = CheckState.Checked Then
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        Else
                            NombreFormulario.txtDTD_ID.Text = ""
                            NombreFormulario.txtDTD_DESCRIPCION.Text = ""
                        End If
                        NombreFormulario.txtCTD_COR_SERIE.text = ""
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' TipoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIV_ESTADO") = "ENTRAN TODOS" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' CorrelativoTipoDocumento
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CTD_USAR_COR") = "ENTRAN TODOS" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCTD_COR_SERIE, dgvDatos, "CTD_COR_SERIE")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' PersonasDocumentoIdentidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DocumentosEmitidosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "NOMBRE")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DocumentosEmitidosI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 1 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.txtMON_SIMBOLO.text = ""
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.txtCTD_COR_SERIE.text = ""
                Case 3 ' DetalleTipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtTDO_DESCRIPCION.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
                    NombreFormulario.txtCTD_COR_SERIE.text = ""
                Case 4 ' TipoVenta
                    NombreFormulario.txtTIV_ID.text = ""
                    NombreFormulario.txtTIV_DESCRIPCION.text = ""
                Case 5 ' CorrelativoTipoDocumento
                    NombreFormulario.txtCTD_COR_SERIE.text = ""
                Case 6 ' Personas
                    NombreFormulario.txtPER_ID_CLI.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CLI.text = ""
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(vComportamiento)
        End Sub
        Private Sub DocumentosEmitidosO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                'Case Is <= 0 ' Documentos
                '    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)

                '    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

                '    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                '    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                Case 2 ' PuntoVenta
                    'OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_TIPO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                Case 3 ' DetalleTipoDocumento
                    'OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_UBICACION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_PROCESO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CONTROL", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_TABLA", vFlagCbo, vFlagDgv)
                Case 5 ' CorrelativoTipoDocumento
                    'OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CTD_COR_SERIE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CTD_COR_NUMERO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CTD_USAR_COR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CTD_ESTADO", vFlagCbo, vFlagDgv)
                    'Case 7, 13 ' DocPersona - Cliente
                    '    OcultarNombresCampos("TDP_LONGITUD", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("TDP_COD_SUNAT", vFlagCbo, vFlagDgv)
                    'Case 25 ' DetalleListaPrecios - Detalle
                    '    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("LPR_PRINCIPAL", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("UM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("ART_FACTOR", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("ART_INC_IGV", vFlagCbo, vFlagDgv)
                    'Case 27, 29 ' SaldosKardexDocumentos - Detalle
                    '    OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    '    'OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                    'Case Is = 30 ' Documentos - Proforma
                    '    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    '    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    '    'OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                    '    'OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)

                    '    'OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    '    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

                    '    'OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    '    'OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
            End Select
        End Sub


        ' Despachos
        Private Sub Despachos()
            Select Case Comportamiento
                Case Is <= 0 ' Despachos
                    NombreFormulario.vBuscarDetalle = True
                    Dim vUNT_NRO_INS_TRA1 As String = ""
                    Dim vUNT_NRO_INS_TRA2 As String = ""

                    NombreFormulario.DeshabilitarModificar()

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTDO_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                    NombreFormulario.vCodigoDTD_ID = NombreFormulario.txtDTD_ID.Text

                    Select Case NombreFormulario.pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                        Case Else
                            NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                    End Select

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboSerieCorrelativo, dgvDatos, "DES_SERIE")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_SERIE, dgvDatos, "DES_SERIE")
                    NombreFormulario.vCodigoDES_SERIE = NombreFormulario.txtDES_SERIE.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_NUMERO, dgvDatos, "DES_NUMERO")
                    NombreFormulario.vCodigoDES_NUMERO = NombreFormulario.txtDES_NUMERO.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDES_FEC_EMI, dgvDatos, "DES_FEC_EMI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDES_FEC_TRA, dgvDatos, "DES_FEC_TRA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, "ALM_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, "ALM_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO"), oOrm), NombreFormulario.ChkALM_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDES_ESTADO, dgvDatos, "DES_ESTADO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDES_TIPO_GUIA, dgvDatos, "DES_TIPO_GUIA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION, dgvDatos, "ALM_DIRECCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM, dgvDatos, "DIS_ID_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM, dgvDatos, "DIS_DESCRIPCION_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM, dgvDatos, "PRO_ID_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM, dgvDatos, "PRO_DESCRIPCION_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM, dgvDatos, "DEP_ID_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM, dgvDatos, "DEP_DESCRIPCION_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM, dgvDatos, "PAI_ID_ALM")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM, dgvDatos, "PAI_DESCRIPCION_ALM")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID_LLEGADA, dgvDatos, "ALM_ID_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION_LLEGADA, dgvDatos, "ALM_DESCRIPCION_LLEGADA")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO_LLEGADA", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO_LLEGADA"), oOrm), NombreFormulario.ChkALM_ESTADO_LLEGADA)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION_LLEGADA, dgvDatos, "ALM_DIRECCION_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM_LLEGADA, dgvDatos, "DIS_ID_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DIS_DESCRIPCION_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM_LLEGADA, dgvDatos, "PRO_ID_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PRO_DESCRIPCION_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM_LLEGADA, dgvDatos, "DEP_ID_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DEP_DESCRIPCION_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM_LLEGADA, dgvDatos, "PAI_ID_ALM_LLEGADA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PAI_DESCRIPCION_ALM_LLEGADA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION_CLI")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, "TDP_ID_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, "TDP_DESCRIPCION_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, "DOP_NUMERO_CLI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_DOC, dgvDatos, "TDO_ID_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_DOC, dgvDatos, "DTD_ID_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_DOC, dgvDatos, "DTD_DESCRIPCION_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_SERIE_DOC, dgvDatos, "DES_SERIE_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_NUMERO_DOC, dgvDatos, "DES_NUMERO_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_ORDEN_COMPRA, dgvDatos, "DOC_ORDEN_COMPRA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID_DOC, dgvDatos, "TIV_ID_DOC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION_DOC, dgvDatos, "TIV_DESCRIPCION_DOC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_MONTO_FLETE, dgvDatos, "DES_MONTO_FLETE")


                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, "TDP_ID_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, "TDP_DESCRIPCION_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, "DOP_NUMERO_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, "DIR_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, "DIR_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, "DIR_REFERENCIA_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, "DIS_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, "DIS_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, "PRO_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, "PRO_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, "DEP_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, "DEP_DESCRIPCION_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, "PAI_ID_ENT_REC")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, "PAI_DESCRIPCION_ENT_REC")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPLA_ID, dgvDatos, "PLA_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_1, dgvDatos, "UNT_ID_1")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_2, dgvDatos, "UNT_ID_2")

                    vUNT_NRO_INS_TRA1 = dgvDatos.SelectedRows(0).Cells("UNT_NRO_INS_TRA1").Value.ToString()
                    vUNT_NRO_INS_TRA2 = dgvDatos.SelectedRows(0).Cells("UNT_NRO_INS_TRA2").Value.ToString()

                    If Not IsNothing(vUNT_NRO_INS_TRA1) Then
                        NombreFormulario.txtCertificado.text = vUNT_NRO_INS_TRA1
                    End If
                    If Not IsNothing(vUNT_NRO_INS_TRA2) Then
                        NombreFormulario.txtCertificado.text = NombreFormulario.txtCertificado.text & " - " & vUNT_NRO_INS_TRA2
                    End If

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA1, dgvDatos, "PER_ID_TRA1")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA1, dgvDatos, "PER_DESCRIPCION_TRA1")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA1, dgvDatos, "RUC_TRA1")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_TRA1", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_TRA1"), oOrm), NombreFormulario.ChkPER_ESTADO_TRA1)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CHO, dgvDatos, "PER_ID_CHO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CHO, dgvDatos, "PER_DESCRIPCION_CHO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE_CHO, dgvDatos, "PER_BREVETE_CHO")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CHO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CHO"), oOrm), NombreFormulario.ChkPER_ESTADO_CHO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.BuscarDetalle()
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.pPVE_ID, dgvDatos, "PVE_ID")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTD_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        Select Case NombreFormulario.pDTD_ID
                            Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                            Case Else
                                NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                        End Select

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' RolPuntoVentaAlmacen
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RPA_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, "ALM_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, "ALM_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO"), oOrm), _
                            NombreFormulario.ChkALM_ESTADO)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION, dgvDatos, "ALM_DIRECCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM, dgvDatos, "DIS_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM, dgvDatos, "DIS_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM, dgvDatos, "PRO_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM, dgvDatos, "PRO_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM, dgvDatos, "DEP_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM, dgvDatos, "DEP_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM, dgvDatos, "PAI_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM, dgvDatos, "PAI_DESCRIPCION_ALM")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, 1)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' Personas - Cliente
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 7 ' Documentos - Ventas boletas, Ventas facturas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        Dim vDIR_ID As String = ""
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_DOC, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_DOC, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_DOC, dgvDatos, "DTD_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, "TDP_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, "TDP_DESCRIPCION_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, "DOP_NUMERO_CLI")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_SERIE_DOC, dgvDatos, "DOC_SERIE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_NUMERO_DOC, dgvDatos, "DOC_NUMERO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_ORDEN_COMPRA, dgvDatos, "DOC_ORDEN_COMPRA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID_DOC, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION_DOC, dgvDatos, "TIV_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        NombreFormulario.txtDES_MONTO_FLETE.Text = 0

                        'Select Case NombreFormulario.pDTD_ID
                        'Case BCVariablesNames.ProcesosDespacho.CroDesCronogramaDespacho
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION_CLI")
                        'End Select
                        Select Case NombreFormulario.txtTDO_ID_DOC.text
                            Case BCVariablesNames.ProcesosFacturación.VentaBoleta
                                cMisProcedimientos.ColocarDatosGrid(vDIR_ID, dgvDatos, "DIR_ID_ENT")
                                If Trim(vDIR_ID) = "" Then
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_DOM")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_DOM")
                                Else
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")
                                End If
                            Case BCVariablesNames.ProcesosFacturación.VentaFactura
                                cMisProcedimientos.ColocarDatosGrid(vDIR_ID, dgvDatos, "DIR_ID_ENT")
                                If Trim(vDIR_ID) = "" Then
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_FIS")
                                    'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_FIS")
                                Else
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")
                                End If
                        End Select

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, "TDP_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, "TDP_DESCRIPCION_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, "DOP_NUMERO_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, "DIR_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, "DIR_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, "DIR_REFERENCIA_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, "DIS_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, "DIS_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, "PRO_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, "PRO_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, "DEP_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, "DEP_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, "PAI_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, "PAI_DESCRIPCION_ENT_REC")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 8 ' DetalleFletesTransporte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "FDE_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "FLE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")

                        If NombreFormulario.txtMON_ID.Text <> dgvDatos.SelectedRows(0).Cells("MON_ID").Value Then
                            If CDbl(NombreFormulario.TipoCambioCompraMoneda) = 0 Then
                                NombreFormulario.txtDES_MONTO_FLETE.text = "0"
                            Else
                                NombreFormulario.txtDES_MONTO_FLETE.text = (CDbl(dgvDatos.SelectedRows(0).Cells("FLE_MONTO_PAG").Value) / _
                                                                          CDbl(NombreFormulario.TipoCambioCompraMoneda))
                            End If
                        Else
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_MONTO_FLETE, dgvDatos, "FLE_MONTO_PAG")
                        End If

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 9 ' DireccionesPersonas - Entrega
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DIR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 10 ' Personas - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 11 ' DocPersona - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 8) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.txtPER_ID_REC.text.trim = "" Then
                            cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, 0)
                        End If
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, 3)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 12 ' DireccionesPersonas - Entrega - Recepciona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 19) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, 4)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, 7)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, 8)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, 10)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, 11)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, 13)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, 14)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, 16)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, 17)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 13 ' Placas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PLA_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CHO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_TRA2") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_TRA1") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        Dim vUNT_NRO_INS_TRA1 As String = ""
                        Dim vUNT_NRO_INS_TRA2 As String = ""

                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPLA_ID, dgvDatos, "PLA_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_1, dgvDatos, "UNT_ID_1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_2, dgvDatos, "UNT_ID_2")

                        vUNT_NRO_INS_TRA1 = dgvDatos.SelectedRows(0).Cells("UNT_NRO_INS_TRA1").Value.ToString()
                        vUNT_NRO_INS_TRA2 = dgvDatos.SelectedRows(0).Cells("UNT_NRO_INS_TRA2").Value.ToString()

                        If Not IsNothing(vUNT_NRO_INS_TRA1) Then
                            NombreFormulario.txtCertificado.text = vUNT_NRO_INS_TRA1
                        End If
                        If Not IsNothing(vUNT_NRO_INS_TRA2) Then
                            NombreFormulario.txtCertificado.text = NombreFormulario.txtCertificado.text & " - " & vUNT_NRO_INS_TRA2
                        End If

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA1, dgvDatos, "PER_ID_TRA1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA1, dgvDatos, "PER_DESCRIPCION_TRA1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA1, dgvDatos, "RUC_TRA1")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_TRA1", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_TRA1"), oOrm), _
                            NombreFormulario.chkPER_ESTADO_TRA1)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CHO, dgvDatos, "PER_ID_CHO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CHO, dgvDatos, "PER_DESCRIPCION_CHO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE_CHO, dgvDatos, "PER_BREVETE_CHO")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CHO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CHO"), oOrm), _
                            NombreFormulario.chkPER_ESTADO_CHO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 14 ' RolPuntoVentaAlmacen
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RPA_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID_LLEGADA, dgvDatos, "ALM_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION_LLEGADA, dgvDatos, "ALM_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO"), oOrm), _
                            NombreFormulario.ChkALM_ESTADO_LLEGADA)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION_LLEGADA, dgvDatos, "ALM_DIRECCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM_LLEGADA, dgvDatos, "DIS_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DIS_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM_LLEGADA, dgvDatos, "PRO_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PRO_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM_LLEGADA, dgvDatos, "DEP_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DEP_DESCRIPCION_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM_LLEGADA, dgvDatos, "PAI_ID_ALM")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PAI_DESCRIPCION_ALM")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 15 ' RolArticulosTipoArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RAR_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIP_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item("cART_ID_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_ID_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_DESCRIPCION").Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 16 ' Personas - Vendedor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN1, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN1, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 17 ' Despachos - Cronograma
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DES_ESTADO") <> BCVariablesNames.EstadoRegistro.Procesado Then
                        MsgBox("Datos no se pueden procesar", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DespachosI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        NombreFormulario.DeshabilitarModificar()
                        NombreFormulario.pProcesandoCronograma = True
                        Dim vCodigoTDO_ID = ""
                        Dim vCodigoDTD_ID = ""
                        Dim vCodigoDES_SERIE = ""
                        Dim vCodigoDES_NUMERO = ""

                        cMisProcedimientos.ColocarDatosGrid(vCodigoTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDES_SERIE, dgvDatos, "DES_SERIE")
                        cMisProcedimientos.ColocarDatosGrid(vCodigoDES_NUMERO, dgvDatos, "DES_NUMERO")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDES_FEC_EMI, dgvDatos, "DES_FEC_EMI")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDES_FEC_TRA, dgvDatos, "DES_FEC_TRA")

                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, "ALM_ID")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, "ALM_DESCRIPCION")
                        'cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO", _
                        'cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO"), oOrm), NombreFormulario.ChkALM_ESTADO)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDES_ESTADO, dgvDatos, "DES_ESTADO")

                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION, dgvDatos, "ALM_DIRECCION")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM, dgvDatos, "DIS_ID_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM, dgvDatos, "DIS_DESCRIPCION_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM, dgvDatos, "PRO_ID_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM, dgvDatos, "PRO_DESCRIPCION_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM, dgvDatos, "DEP_ID_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM, dgvDatos, "DEP_DESCRIPCION_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM, dgvDatos, "PAI_ID_ALM")
                        'cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM, dgvDatos, "PAI_DESCRIPCION_ALM")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID_LLEGADA, dgvDatos, "ALM_ID_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION_LLEGADA, dgvDatos, "ALM_DESCRIPCION_LLEGADA")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ALM_ESTADO_LLEGADA", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO_LLEGADA"), oOrm), NombreFormulario.ChkALM_ESTADO_LLEGADA)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DIRECCION_LLEGADA, dgvDatos, "ALM_DIRECCION_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ALM_LLEGADA, dgvDatos, "DIS_ID_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DIS_DESCRIPCION_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ALM_LLEGADA, dgvDatos, "PRO_ID_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PRO_DESCRIPCION_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ALM_LLEGADA, dgvDatos, "DEP_ID_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ALM_LLEGADA, dgvDatos, "DEP_DESCRIPCION_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ALM_LLEGADA, dgvDatos, "PAI_ID_ALM_LLEGADA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ALM_LLEGADA, dgvDatos, "PAI_DESCRIPCION_ALM_LLEGADA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION_CLI")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_CLI, dgvDatos, "TDP_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_CLI, dgvDatos, "TDP_DESCRIPCION_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_CLI, dgvDatos, "DOP_NUMERO_CLI")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID_DOC, dgvDatos, "TDO_ID_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID_DOC, dgvDatos, "DTD_ID_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION_DOC, dgvDatos, "DTD_DESCRIPCION_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION_VEN")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_SERIE_DOC, dgvDatos, "DES_SERIE_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_NUMERO_DOC, dgvDatos, "DES_NUMERO_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOC_TIPO_LISTA, dgvDatos, "DOC_TIPO_LISTA")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.vDOC_ORDEN_COMPRA, dgvDatos, "DOC_ORDEN_COMPRA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID_DOC, dgvDatos, "TIV_ID_DOC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION_DOC, dgvDatos, "TIV_DESCRIPCION_DOC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_ID, dgvDatos, "FLE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtFLE_DESCRIPCION, dgvDatos, "FLE_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDES_MONTO_FLETE, dgvDatos, "DES_MONTO_FLETE")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT, dgvDatos, "DIR_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT, dgvDatos, "DIR_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT, dgvDatos, "DIR_REFERENCIA_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT, dgvDatos, "DIS_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT, dgvDatos, "DIS_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT, dgvDatos, "PRO_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT, dgvDatos, "PRO_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT, dgvDatos, "DEP_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT, dgvDatos, "DEP_DESCRIPCION_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT, dgvDatos, "PAI_ID_ENT")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT, dgvDatos, "PAI_DESCRIPCION_ENT")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, "PER_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_REC, dgvDatos, "PER_DESCRIPCION_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_ID_REC, dgvDatos, "TDP_ID_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDP_DESCRIPCION_REC, dgvDatos, "TDP_DESCRIPCION_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDOP_NUMERO_REC, dgvDatos, "DOP_NUMERO_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_ID_ENT_REC, dgvDatos, "DIR_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_DESCRIPCION_ENT_REC, dgvDatos, "DIR_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIR_REFERENCIA_ENT_REC, dgvDatos, "DIR_REFERENCIA_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_ID_ENT_REC, dgvDatos, "DIS_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDIS_DESCRIPCION_ENT_REC, dgvDatos, "DIS_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_ID_ENT_REC, dgvDatos, "PRO_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPRO_DESCRIPCION_ENT_REC, dgvDatos, "PRO_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_ID_ENT_REC, dgvDatos, "DEP_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEP_DESCRIPCION_ENT_REC, dgvDatos, "DEP_DESCRIPCION_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_ID_ENT_REC, dgvDatos, "PAI_ID_ENT_REC")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPAI_DESCRIPCION_ENT_REC, dgvDatos, "PAI_DESCRIPCION_ENT_REC")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPLA_ID, dgvDatos, "PLA_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_1, dgvDatos, "UNT_ID_1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID_2, dgvDatos, "UNT_ID_2")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA1, dgvDatos, "PER_ID_TRA1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA1, dgvDatos, "PER_DESCRIPCION_TRA1")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtRUC_TRA1, dgvDatos, "RUC_TRA1")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_TRA1", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_TRA1"), oOrm), NombreFormulario.ChkPER_ESTADO_TRA1)

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CHO, dgvDatos, "PER_ID_CHO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CHO, dgvDatos, "PER_DESCRIPCION_CHO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_BREVETE_CHO, dgvDatos, "PER_BREVETE_CHO")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CHO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CHO"), oOrm), NombreFormulario.ChkPER_ESTADO_CHO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)

                        NombreFormulario.BuscarDetalle(vCodigoTDO_ID, _
                                                       vCodigoDTD_ID, _
                                                       vCodigoDES_SERIE, _
                                                       vCodigoDES_NUMERO, _
                                                       True)
                    End If
            End Select
        End Sub
        Private Sub DespachosI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.pPVE_ID = BCVariablesNames.PuntoVentaPrincipal
                Case 3 ' DetalleTipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtDTD_ID.text = ""

                    Select Case NombreFormulario.pDTD_ID
                        Case BCVariablesNames.ProcesosDespacho.GuiaSalidaDesdeDistribuidora
                        Case Else
                            NombreFormulario.Text = ""
                    End Select

                Case 4 ' RolPuntoVentaAlmacen
                    NombreFormulario.txtALM_ID.text = ""
                    NombreFormulario.txtALM_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkALM_ESTADO)
                    NombreFormulario.txtALM_DIRECCION.text = ""
                    NombreFormulario.txtDIS_ID_ALM.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ALM.text = ""
                    NombreFormulario.txtPRO_ID_ALM.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ALM.text = ""
                    NombreFormulario.txtDEP_ID_ALM.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ALM.text = ""
                    NombreFormulario.txtPAI_ID_ALM.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ALM.text = ""
                Case 5 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                Case 6 ' Personas - Cliente
                    NombreFormulario.txtPER_ID_CLI.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CLI.text = ""
                Case 7 ' Documentos - Ventas boletas, Ventas facturas
                    NombreFormulario.txtTDO_ID_DOC.text = ""
                    NombreFormulario.txtDTD_ID_DOC.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION_DOC.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_VEN.text = ""
                    NombreFormulario.txtTDP_ID_CLI.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION_CLI.text = ""
                    NombreFormulario.txtDOP_NUMERO_CLI.text = ""

                    NombreFormulario.txtDES_SERIE_DOC.text = ""
                    NombreFormulario.txtDES_NUMERO_DOC.text = ""
                    NombreFormulario.txtDOC_TIPO_LISTA.text = ""

                    NombreFormulario.txtTIV_ID_DOC.text = ""
                    NombreFormulario.txtTIV_DESCRIPCION_DOC.text = ""

                    NombreFormulario.txtFLE_ID.text = ""
                    NombreFormulario.txtFLE_DESCRIPCION.text = ""

                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.txtDES_MONTO_FLETE.Text = 0

                    NombreFormulario.txtDIR_ID_ENT.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT.text = ""
                    NombreFormulario.txtDIS_ID_ENT.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPRO_ID_ENT.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDEP_ID_ENT.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPAI_ID_ENT.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT.text = ""

                    NombreFormulario.txtPER_ID_REC.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_REC.text = ""
                    NombreFormulario.txtTDP_ID_REC.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION_REC.text = ""
                    NombreFormulario.txtDOP_NUMERO_REC.text = ""
                    NombreFormulario.txtDIR_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT_REC.text = ""
                    NombreFormulario.txtDIS_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPRO_ID_ENT_REC.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDEP_ID_ENT_REC.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPAI_ID_ENT_REC.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT_REC.text = ""
                Case 8 ' FletesTransporte
                    NombreFormulario.txtFLE_ID.text = ""
                    NombreFormulario.txtFLE_DESCRIPCION.text = ""
                    NombreFormulario.txtDES_MONTO_FLETE.text = "0"
                Case 9 ' DireccionesPersonas - Entrega
                    NombreFormulario.txtDIR_ID_ENT.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT.text = ""
                    NombreFormulario.txtDIS_ID_ENT.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPRO_ID_ENT.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtDEP_ID_ENT.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT.text = ""
                    NombreFormulario.txtPAI_ID_ENT.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT.text = ""
                Case 10 ' Personas - Recepciona
                    NombreFormulario.txtPER_ID_REC.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_REC.text = ""
                Case 11 ' DocPersona - Recepciona
                    If NombreFormulario.txtPER_ID_REC.text.trim = "" Then
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_REC, dgvDatos, 0)
                    End If
                    NombreFormulario.txtTDP_ID_REC.text = ""
                    NombreFormulario.txtTDP_DESCRIPCION_REC.text = ""
                    NombreFormulario.txtDOP_NUMERO_REC.text = ""
                Case 12 ' DireccionesPersonas - Entrega - Recepciona
                    NombreFormulario.txtDIR_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIR_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDIR_REFERENCIA_ENT_REC.text = ""
                    NombreFormulario.txtDIS_ID_ENT_REC.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPRO_ID_ENT_REC.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtDEP_ID_ENT_REC.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ENT_REC.text = ""
                    NombreFormulario.txtPAI_ID_ENT_REC.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ENT_REC.text = ""
                Case 13 ' Placas
                    NombreFormulario.txtPLA_ID.text = ""
                    NombreFormulario.txtUNT_ID_1.text = ""
                    NombreFormulario.txtUNT_ID_2.text = ""
                    NombreFormulario.txtCertificado.text = ""
                    NombreFormulario.txtPER_ID_TRA1.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_TRA1.text = ""
                    NombreFormulario.txtRUC_TRA1.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_TRA1)
                    NombreFormulario.txtPER_ID_CHO.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CHO.text = ""
                    NombreFormulario.txtPER_BREVETE_CHO.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_CHO)
                Case 14 ' RolPuntoVentaAlmacen
                    NombreFormulario.txtALM_ID_LLEGADA.text = ""
                    NombreFormulario.txtALM_DESCRIPCION_LLEGADA.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkALM_ESTADO_LLEGADA)
                    NombreFormulario.txtALM_DIRECCION_LLEGADA.text = ""
                    NombreFormulario.txtDIS_ID_ALM_LLEGADA.text = ""
                    NombreFormulario.txtDIS_DESCRIPCION_ALM_LLEGADA.text = ""
                    NombreFormulario.txtPRO_ID_ALM_LLEGADA.text = ""
                    NombreFormulario.txtPRO_DESCRIPCION_ALM_LLEGADA.text = ""
                    NombreFormulario.txtDEP_ID_ALM_LLEGADA.text = ""
                    NombreFormulario.txtDEP_DESCRIPCION_ALM_LLEGADA.text = ""
                    NombreFormulario.txtPAI_ID_ALM_LLEGADA.text = ""
                    NombreFormulario.txtPAI_DESCRIPCION_ALM_LLEGADA.text = ""
                Case 15 ' RolArticulosTipoArticulos
                    NombreFormulario.dgvDetalle.Item("cART_ID_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_IMP", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_ID_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION_KAR", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                Case 16 ' Personas - Vendedor
                    NombreFormulario.txtPER_ID_VEN1.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_VEN1.text = ""
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(vComportamiento)
        End Sub
        Private Sub DespachosO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
                    'OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)

                    'OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)

                    ''OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                    ''OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)
                    ''OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    ''OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)


                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_FEC_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_FEC_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ID_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DESCRIPCION_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DIRECCION_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ESTADO_LLEGADA", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_SERIE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_NUMERO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_SERIE_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_NUMERO_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_REC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("FLE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_MONTO_FLETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_CONTRAVALOR", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PLA_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA1", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("RUC_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_ID_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_ID_2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_CHO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_ESTADO", vFlagCbo, vFlagDgv)
                Case 3 ' DetalleTipoDocumentos
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_UBICACION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_PROCESO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CONTROL", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TDO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_TABLA", vFlagCbo, vFlagDgv)
                Case 4, 14 ' RolPuntoVentaAlmacen
                    'OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ALM_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ALM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ALM_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ALM", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIS_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ALM", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PRO_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ALM", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DEP_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ALM", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PAI_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("RPA_ESTADO", vFlagCbo, vFlagDgv)
                Case 6, 16 ' Personas - Cliente, Vendedor 
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_PAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_MAT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_NOMBRES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("<PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    If Comportamiento = 6 Then
                        'OcultarNombresCampos("<DIR_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_TIPO", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIS_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    Else
                        'OcultarNombresCampos("<DIR_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIR_TIPO", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIS_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("<DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                        'OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    End If
                    'OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 7 ' Documentos - Facturas/Boletas
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_SERIE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_NUMERO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_TIPO_ORDEN_COMPRA", vFlagCbo, vFlagDgv)

                    OcultarNombresCampos("PER_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TIV_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_COB", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_FECHA_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_EXP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_MONTO_TOTAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_CONTRAVALOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_IGV_POR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ASIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_CIERRE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("FLE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_SERIE_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_NUMERO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_MOT_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_NOMBRE_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_DNI_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FEC_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ENTREGADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CAF_IX_NUMERO_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CAF_IX_ORDEN_COM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_DIAS", vFlagCbo, vFlagDgv)
                Case 8 ' DetalleFleteTransporte
                    OcultarNombresCampos("FLE_ID", False, vFlagDgv)
                    OcultarNombresCampos("FDE_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", False, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION", False, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("MON_ID", False, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", False, vFlagDgv)
                    OcultarNombresCampos("FLE_TIPO", False, vFlagDgv)
                    OcultarNombresCampos("FLE_MONTO_COB", False, vFlagDgv)
                    OcultarNombresCampos("FLE_MONTO_PAG", False, vFlagDgv)
                Case 13 ' Placas
                    'OcultarNombresCampos("PLA_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("UNT_ID_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA1", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("RUC_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_TARA_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA1", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("UNT_ID_2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA2", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("RUC_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_TARA_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CHO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CHO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_BREVETE_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PLA_ESTADO", vFlagCbo, vFlagDgv)
                Case 17 ' Despachos - Cronograma
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_FEC_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_FEC_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_PVE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_ALM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ID_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DESCRIPCION_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_DIRECCION_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO_ALM_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ALM_ESTADO_LLEGADA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_SERIE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_NUMERO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_SERIE_DOC", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DES_NUMERO_DOC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAIS_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("FLE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_MONTO_FLETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_CONTRAVALOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PLA_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("RUC_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_ID_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_ID_2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MAR_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MOD_DESCRIPCION_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("UNT_NRO_INS_TRA2", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_CHO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DES_TIPO_GUIA", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        ' MarcarSalidaGuia
        Private Sub MarcarSalidaGuia()
            Select Case Comportamiento
                Case 18 ' UnidadesTransporte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "UNT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MarcarSalidaGuiaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        Dim vUNT_NRO_INS_TRA1 As String = ""
                        Dim vUNT_NRO_INS_TRA2 As String = ""

                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUNT_ID, dgvDatos, "UNT_ID")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub MarcarSalidaGuiaI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 18 ' UnidadesTransporte
                    NombreFormulario.txtUNT_ID.text = ""
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(vComportamiento)
        End Sub
        Private Sub MarcarSalidaGuiaO(Optional ByVal vFlagCbo As Boolean = True, _
                                Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
            End Select
        End Sub

        Private Sub KardexDocumento()
            Select Case Comportamiento
                Case Is <= 0 ' KardexDocumento
                Case 1 ' TipoArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIP_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, "TIP_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, "TIP_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTD_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' Documentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DOC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtSERIE, dgvDatos, "DOC_SERIE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtNUMERO, dgvDatos, "DOC_NUMERO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID_CLI")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION_CLI")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "XXXXXXX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.txtSERIE.text = ""
                        NombreFormulario.txtNUMERO.text = ""
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' Almacen - Salida
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID, dgvDatos, "ALM_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION, dgvDatos, "ALM_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 7 ' Almacen - Llegada
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ALM_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_ID_LLEGADA, dgvDatos, "ALM_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtALM_DESCRIPCION_LLEGADA, dgvDatos, "ALM_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 8 ' Punto venta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 9 ' PersonaDocumentoIdentidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "XXXXXXX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.txtSERIE.text = ""
                        NombreFormulario.txtNUMERO.text = ""
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI, dgvDatos, "NOMBRE")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 10 ' DocumentosKardexDocumento
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DOCUMENTO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtSERIE, dgvDatos, "SERIE")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtNUMERO, dgvDatos, "NUMERO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "NOMBRE")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

            End Select
        End Sub
        Private Sub KardexDocumentoI()
            Select Case Comportamiento
                Case 1 ' TipoArticulos
                    NombreFormulario.txtTIP_ID.text = ""
                    NombreFormulario.txtTIP_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' DetalleTipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 3 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 4, 10 ' Documento, DocumentoKardexDocumento
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtSerie.text = ""
                    NombreFormulario.txtNUmero.text = ""
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 5, 9 ' Persona, PersonaDocumentoIdentidad
                    'NombreFormulario.txtTDO_ID.text = ""
                    'NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtSerie.text = ""
                    NombreFormulario.txtNumero.text = ""
                    NombreFormulario.txtPER_ID_CLI.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CLI.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 6 ' Almacén - salida
                    NombreFormulario.txtALM_ID.text = ""
                    NombreFormulario.txtALM_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 7 ' Almacén - llegada
                    NombreFormulario.txtALM_ID_LLEGADA.text = ""
                    NombreFormulario.txtALM_DESCRIPCION_LLEGADA.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 8 ' Punto venta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub
        Private Sub KardexDocumentoO(Optional ByVal vFlagCbo As Boolean = True, _
                                     Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
                Case 1 ' TipoArticulos
                    OcultarNombresCampos("TIP_CONTROL", vFlagCbo, vFlagDgv)
                Case 2 ' DetalleTipoDocumentos
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_UBICACION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_PROCESO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_TABLA", vFlagCbo, vFlagDgv)
                Case 4 ' Documentos
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_SERIE", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_NUMERO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_TIPO_ORDEN_COMPRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT_REC", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION_DES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_CON", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDP_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOP_NUMERO_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_FIS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_DOM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ESTADO_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_ENT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_EXP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_TIPO_LISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_MONTO_TOTAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_CONTRAVALOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_IGV_POR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ASIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_CIERRE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("FLE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_MONTO_FLE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_REQUIERE_GUIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_SERIE_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_NUMERO_AFE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_MOT_EMI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_NOMBRE_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_DNI_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FEC_RECEP", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_ENTREGADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CAF_IX_NUMERO_PRO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CAF_IX_ORDEN_COM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TIV_DIAS", vFlagCbo, vFlagDgv)
                Case 10 ' DocumentosKardexDocumento
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        Private Sub ReporteCronogramaDespacho()
            Select Case Comportamiento
                Case Is <= 0 ' ReporteCronogramDespacho
                Case 1 ' Personas - Vendedor
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "XXXXXXX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexDocumentoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_VEN, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_VEN, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ReporteCronogramaDespachoI()
            Select Case Comportamiento
                Case 1 ' Persona
                    NombreFormulario.txtPER_ID_VEN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_VEN.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub
        Private Sub ReporteCronogramaDespachoO(Optional ByVal vFlagCbo As Boolean = True, _
                                     Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
            End Select
        End Sub

        Private Sub GuiasRemision()
            Select Case Comportamiento
                Case Is <= 0 ' GuiasRemision
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            GuiasRemisionI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_TRA, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_TRA, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TDO_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTD_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            GuiasRemisionI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub GuiasRemisionI()
            Select Case Comportamiento
                Case 1 ' Persona
                    NombreFormulario.txtPER_ID_TRA.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_TRA.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' DetalleTipoDocumentos
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub
        Private Sub GuiasRemisionO(Optional ByVal vFlagCbo As Boolean = True, _
                                     Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0
                Case 1 ' Personas
                Case 2 ' DetalleTipoDocumentos
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_UBICACION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_PROCESO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_CONTROL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_TABLA", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        ' Tesoreria
        Private Sub CajaCtaCte()
            Select Case Comportamiento
                Case Is <= 0 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCCC_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCCC_TIPO, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_BAN", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkPER_ESTADO_BAN)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_CUENTA_BANCARIA, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, 8)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CAJ", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), NombreFormulario.ChkPER_ESTADO_CAJ)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 10)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 11)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 12), oOrm), NombreFormulario.ChkPVE_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpCCC_FECHA_SAL_INI, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_MONTO_SAL_INI, dgvDatos, 14)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 15)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 16)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17), oOrm), NombreFormulario.ChkMON_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID, dgvDatos, 18)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION, dgvDatos, 19)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17), oOrm), NombreFormulario.ChkCUC_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CCC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 21), oOrm), NombreFormulario.ChkCCC_ESTADO)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Personas - Bancos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO_BAN)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Personas - Cajeros
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), NombreFormulario.ChkPER_ESTADO_CAJ)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), _
                            NombreFormulario.ChkPVE_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), _
                            NombreFormulario.ChkMON_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), _
                            NombreFormulario.ChkCUC_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CajaCtaCteI()
            Select Case Comportamiento
                Case 1 ' Personas - Bancos
                    NombreFormulario.txtPER_ID_BAN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_BAN.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_BAN)
                Case 2 ' Personas - Cajeros
                    NombreFormulario.txtPER_ID_CAJ.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CAJ.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO_CAJ)
                Case 3 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPVE_ESTADO)
                Case 4 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkMON_ESTADO)
                Case 5 ' CuentasContables
                    NombreFormulario.txtCUC_ID.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO)
            End Select
        End Sub

        Private Sub Cheques()
            Select Case Comportamiento
                Case Is <= 0 ' Cheques
                    NombreFormulario.txtCHE_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCCC_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_INICIO, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_FIN, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_CORRELATIVO, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCHE_TIPO, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCHE_FORMA_GIRO, dgvDatos, 9)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CHE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), NombreFormulario.ChkCHE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' CajaCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 21) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajaCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, 5)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, 2)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, 3)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ChequesI()
            Select Case Comportamiento
                Case 1 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID.text = ""
                    NombreFormulario.txtCCC_DESCRIPCION.text = ""
                    NombreFormulario.txtPER_ID_BAN.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_BAN.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub

        Private Sub TesoreriaEditar()
            Select Case Comportamiento
                Case Is <= 0 ' TesoreriaEditar
                    NombreFormulario.txtTEE_USU_ID.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTEE_USU_ID, dgvDatos, "TEE_USU_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTEE_USU_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_ID, dgvDatos, "TEE_USU_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_DESCRIPCION, dgvDatos, "USU_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUSU_TIPO, dgvDatos, "USU_TIPO")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("USU_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO"), oOrm), _
                        NombreFormulario.chkUSU_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TES_FECHA_EMI", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TES_FECHA_EMI"), oOrm), _
                        NombreFormulario.chkTES_FECHA_EMI)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TEE_NO_CAJERO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TEE_NO_CAJERO"), oOrm), _
                        NombreFormulario.chkTEE_NO_CAJERO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TEE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TEE_ESTADO"), oOrm), _
                        NombreFormulario.chkTEE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PermisoUsuario
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PEU_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaEditarI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTEE_USU_ID, dgvDatos, "USU_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_DESCRIPCION, dgvDatos, "USU_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUSU_TIPO, dgvDatos, "USU_TIPO")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("USU_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO"), oOrm), _
                            NombreFormulario.chkUSU_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub TesoreriaEditarI()
            Select Case Comportamiento
                Case 1 ' PermisoUsuario
                    NombreFormulario.txtTEE_USU_ID.text = ""
                    NombreFormulario.txtUSU_DESCRIPCION.text = ""
                    NombreFormulario.cboUSU_TIPO.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkUSU_ESTADO)
            End Select
        End Sub


        Private Sub CajeroAnexo()
            Select Case Comportamiento
                Case Is <= 0 ' CajeroAnexo
                    NombreFormulario.txtPVE_ID.Enabled = False
                    NombreFormulario.txtCCC_ID.Enabled = False
                    NombreFormulario.txtPER_ID_CAJ.Enabled = False

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPVE_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO"), oOrm), _
                        NombreFormulario.chkPVE_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, "CCC_ID")
                    NombreFormulario.vCodigoCCC_ID = NombreFormulario.txtCCC_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, "CCC_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CCC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO"), oOrm), _
                        NombreFormulario.chkCCC_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, "PER_ID_CAJ")
                    NombreFormulario.vCodigoPER_ID_CAJ = NombreFormulario.txtPER_ID_CAJ.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, "PER_DESCRIPCION_CAJ")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO_CAJ", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CAJ"), oOrm), _
                        NombreFormulario.chkPER_ESTADO_CAJ)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CAN_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CAN_ESTADO"), oOrm), _
                        NombreFormulario.chkCAN_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajeroAnexoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO"), oOrm), _
                            NombreFormulario.chkPVE_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' CajaCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajeroAnexoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, "CCC_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, "CCC_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CCC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO"), oOrm), _
                            NombreFormulario.chkCCC_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' RolPersonaTipoPersona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RTP_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CajeroAnexoI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, "PER_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), _
                            NombreFormulario.chkPER_ESTADO_CAJ)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CajeroAnexoI()
            Select Case Comportamiento
                Case 1 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPVE_ESTADO)
                Case 2 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID.text = ""
                    NombreFormulario.txtCCC_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkCCC_ESTADO)
                Case 3 ' RolPersonaTipoPersonas
                    NombreFormulario.txtPER_ID_CAJ.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CAJ.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.chkPER_ESTADO_CAJ)
            End Select
        End Sub

        Private Sub Tesoreria()
            Select Case Comportamiento
                Case Is <= 0 ' Tesoreria
                    NombreFormulario.DeshabilitarModificar()

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 14)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtTDO_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")

                    NombreFormulario.vCodigoDTD_ID = NombreFormulario.txtDTD_ID.Text
                    If NombreFormulario.pDocumentoProcesandose = 1000 Then
                        NombreFormulario.Text = "CONSULTA - " & dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                    Else
                        NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString()
                    End If

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCCC_TIPO, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, 6)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboSerieCorrelativo, dgvDatos, 11)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTES_SERIE, dgvDatos, 11)
                    NombreFormulario.vCodigoTES_SERIE = NombreFormulario.txtTES_SERIE.Text
                    'NombreFormulario.cboSerieCorrelativo.Items.AddRange(New Object() {NombreFormulario.txtTES_SERIE.Text})
                    'NombreFormulario.cboSerieCorrelativo.text = NombreFormulario.txtTES_SERIE.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTES_NUMERO, dgvDatos, 12)
                    NombreFormulario.vCodigoTES_NUMERO = NombreFormulario.txtTES_NUMERO.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpTES_FECHA_EMI, dgvDatos, 13)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_CCC, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_CCC, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_CCC, dgvDatos, 9)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, 17)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, 18)


                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TES_ASIENTO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 21), oOrm), NombreFormulario.ChkTES_ASIENTO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboTES_CIERRE, dgvDatos, 22)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TES_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 23), oOrm), NombreFormulario.ChkTES_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTES_MONTO_TOTAL, dgvDatos, 20)
                    NombreFormulario.ProcesarTipoCambioMoneda()
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 18) = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MensajeError("Datos no activos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        NombreFormulario.pPVE_ID = NombreFormulario.txtPVE_ID.text
                        TesoreriaI(4)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 3 ' RolOpeCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ROC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTDO_ID, dgvDatos, "TDO_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        NombreFormulario.pCCT_ID = NombreFormulario.txtCCT_ID.text
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")
                        NombreFormulario.Text = dgvDatos.SelectedRows(0).Cells("DTD_DESCRIPCION").Value.ToString() & " - " & dgvDatos.SelectedRows(0).Cells("CCT_DESCRIPCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 4 ' CajaCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CAJ") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_BAN") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        Dim vCCC_DESCRIPCION As String = ""
                        Dim vCCC_CUENTA_BANCARIA As String = ""
                        Dim vPER_DESCRIPCION_BAN As String = ""
                        Dim vPER_ID_CAJ As String = ""
                        Dim vPER_ID_BAN As String = ""
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, "CCC_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCCC_TIPO, dgvDatos, "CCC_TIPO")

                        cMisProcedimientos.ColocarDatosGrid(vCCC_DESCRIPCION, dgvDatos, "CCC_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(vCCC_CUENTA_BANCARIA, dgvDatos, "CCC_CUENTA_BANCARIA")
                        cMisProcedimientos.ColocarDatosGrid(vPER_DESCRIPCION_BAN, dgvDatos, "PER_DESCRIPCION_BAN")
                        NombreFormulario.txtCCC_DESCRIPCION.Text = vCCC_DESCRIPCION & " " & vCCC_CUENTA_BANCARIA & " " & vPER_DESCRIPCION_BAN

                        cMisProcedimientos.ColocarDatosGrid(vPER_ID_CAJ, dgvDatos, "PER_ID_CAJ")
                        cMisProcedimientos.ColocarDatosGrid(vPER_ID_BAN, dgvDatos, "PER_ID_BAN")
                        NombreFormulario.CodigoBanco = vPER_ID_BAN

                        Select Case NombreFormulario.pTDO_ID
                            Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                                BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas, _
                                BCVariablesNames.ProcesosCaja.TransferenciaEntreCajas
                                NombreFormulario.tslCajero.Text = " - "
                            Case Else
                                If vPER_ID_CAJ = NombreFormulario.pPER_ID_CAJ Then
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, "PER_ID_CAJ")
                                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, "PER_DESCRIPCION_CAJ")
                                    NombreFormulario.tslCajero.Text = " - "
                                Else
                                    NombreFormulario.txtPER_ID_CAJ.Text = ""
                                    NombreFormulario.txtPER_DESCRIPCION_CAJ.Text = ""
                                    NombreFormulario.tslCajero.Text = "Cajero asignado a la Caja Cta. Cte., no concuerda con el usuario."
                                End If
                        End Select

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID_CCC, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION_CCC, dgvDatos, "MON_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO_CCC, dgvDatos, "MON_SIMBOLO")

                        NombreFormulario.ProcesarTipoCambioMoneda()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 5 ' Personas - Cajero
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CAJ, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CAJ, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 6 ' CtaCte - Detalle - manejado en la cabecera del formulario
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")
                        NombreFormulario.pCCT_ID = NombreFormulario.txtCCT_ID.text

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If

                Case 7 ' CajaCtaCte - Detalle
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_BAN") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CAJ") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvFormulario.Item("cCCC_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("CCC_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cCCC_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("CCC_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 8 ' Personas - Clientes - Detalle
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "xNO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        TesoreriaI(Comportamiento)
                        Select Case NombreFormulario.pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.CajaIngreso, _
                                 BCVariablesNames.ProcesosCaja.CajaEgreso, _
                                 BCVariablesNames.ProcesosCaja.DepositoTercero

                                Select Case NombreFormulario.tcoTipoRecibo.SelectedTab.Name
                                    Case "tpaPagos"
                                        NombreFormulario.txtPER_ID_CLI_REC.text = dgvDatos.SelectedRows(0).Cells("PER_ID").Value.ToString()
                                        NombreFormulario.txtPER_DESCRIPCION_CLI_REC.text = dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION").Value.ToString()
                                End Select
                        End Select
                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("PER_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 9 ' SaldosKardexDocumentos
                        vSaltar = False

                        Dim vMON_ID As String = ""

                        Dim vPER_ID_CLI As String = ""
                        Dim vTDO_ID As String = ""
                        Dim vDTD_ID As String = ""
                        Dim vDTE_SERIE As String = ""
                        Dim vDTE_NUMERO As String = ""
                        Dim vDTE_IMPORTE As Double = 0

                        Dim vCambiarMonedaSaldo As Double = 0
                        Dim vProcesarEnviarDatos As Boolean = True
                        Dim vProcesarTipoDocumento As Object
                        vMON_ID = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                        vCambiarMonedaSaldo = NombreFormulario.CambiarMonedaSaldo(vMON_ID)
                        If vMON_ID <> BCVariablesNames.MonedaSistema Then
                            If vCambiarMonedaSaldo = 0 Then
                                MensajeError(dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString() & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                Exit Sub
                            End If
                        End If
                        vPER_ID_CLI = dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                        vTDO_ID = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                        vDTD_ID = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                        vDTE_SERIE = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                        vDTE_NUMERO = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()
                        vDTE_IMPORTE = dgvDatos.SelectedRows(0).Cells("SALDO").Value
                        vProcesarTipoDocumento = NombreFormulario.ProcesarTipoDocumento(vDTE_IMPORTE, False)
                        vDTE_IMPORTE = vProcesarTipoDocumento.Importe
                        vProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
                        If vProcesarEnviarDatos Then
                            NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vTDO_ID
                            NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTD_ID
                            NombreFormulario.pDTD_ID_DOC = vDTD_ID
                            NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_SERIE
                            NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_NUMERO
                            NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_FECHA_VEN_REF").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            NombreFormulario.dgvFormulario.Item("cDTD_MOVIMIENTO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.ProcesarTipoMovimientoDeDocumento(dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString(), vTDO_ID, vDTD_ID)
                            Select Case NombreFormulario.ProcesarCambioTipoMonedaDoc(NombreFormulario.dgvFormulario, _
                                                                                     NombreFormulario.pIdentificadorDgv, _
                                                                                     vDTE_IMPORTE, _
                                                                                     vTDO_ID, vDTD_ID, _
                                                                                     vDTE_SERIE, vDTE_NUMERO, _
                                                                                     vMON_ID, vCambiarMonedaSaldo, _
                                                                                     True, True, vPER_ID_CLI)
                                Case 1
                                    MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                    Exit Sub
                                Case 2
                                    Exit Sub
                                Case Else
                            End Select
                            NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()
                            NombreFormulario.LimpiarCentroCosto()
                            NombreFormulario.RecalcularMontoAbono(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                            NombreFormulario.Check_Refrescar()
                            NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                        End If
                Case 12 ' SaldosKardexDocumentos - DTE_IMPORTE_DOC
                        vSaltar = False
                        Dim vMON_ID As String = ""
                        Dim vImporte As Double = 0
                        Dim vContravalor As Double = 0
                        Dim vImporteTemporal As Double = 0
                        Dim vContravalorTemporal As Double = 0

                        Dim vPER_ID_CLI As String = ""
                        Dim vTDO_ID As String = ""
                        Dim vDTD_ID As String = ""
                        Dim vDTE_SERIE As String = ""
                        Dim vDTE_NUMERO As String = ""

                        Dim vCambiarMonedaSaldo As Double = 0
                        Dim vMontoTemporal As Double = 0
                        Dim vDatoBusquedaTemporal As Double = 0
                        Dim vSaldoDocumento As Double = 0
                        Dim vSaldo As Double = 0
                        Dim vSaldoTemporal As Double = 0

                        vPER_ID_CLI = dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                        vTDO_ID = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                        vDTD_ID = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                        vDTE_SERIE = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                        vDTE_NUMERO = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()

                        vMON_ID = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                        vCambiarMonedaSaldo = NombreFormulario.CambiarMonedaSaldo(vMON_ID)

                        NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value _
                            = 0
                        NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value _
                            = 0

                        Select Case NombreFormulario.ProcesarCambioTipoMonedaDoc(NombreFormulario.dgvFormulario, _
                                                                                 NombreFormulario.pIdentificadorDgv, _
                                                                                 pDatoBusqueda, _
                                                                                 vTDO_ID, vDTD_ID, _
                                                                                 vDTE_SERIE, vDTE_NUMERO, _
                                                                                 vMON_ID, vCambiarMonedaSaldo, _
                                                                                 pVerificarMonto, False, vPER_ID_CLI)
                            Case 1
                                MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                Exit Sub
                            Case 2
                                Exit Sub
                            Case Else
                        End Select

                        vContravalorTemporal = 0
                        If NombreFormulario.txtMON_ID_CCC.Text = vMON_ID Then
                            vMontoTemporal = NombreFormulario.VerificarMontoDocumento(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, vTDO_ID, vDTD_ID, vDTE_SERIE, vDTE_NUMERO, vMON_ID, vPER_ID_CLI, pVerificarMontoSoloNuevosRegistro) - NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value
                        Else
                            vMontoTemporal = NombreFormulario.VerificarMontoDocumento(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, vTDO_ID, vDTD_ID, vDTE_SERIE, vDTE_NUMERO, vMON_ID, vPER_ID_CLI, pVerificarMontoSoloNuevosRegistro) - NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value
                        End If

                        vMontoTemporal = NombreFormulario.VerificarMonedaDelImporte(vMontoTemporal, vMON_ID, vCambiarMonedaSaldo)
                        If vMontoTemporal < 0 Then vMontoTemporal = 0

                        If dgvDatos.SelectedRows(0).Cells("SALDO").Value < 0 Then
                            vSaldoDocumento = dgvDatos.SelectedRows(0).Cells("SALDO").Value * -1
                        Else
                            vSaldoDocumento = dgvDatos.SelectedRows(0).Cells("SALDO").Value
                        End If

                        vSaldoTemporal = vSaldoDocumento
                        vSaldo = NombreFormulario.VerificarMonedaDelImporte(vSaldoDocumento, vMON_ID, vCambiarMonedaSaldo)
                        vImporte = vSaldo
                        vImporteTemporal = vSaldo - vMontoTemporal
                        If vImporteTemporal < 0 Then
                            vImporteTemporal = vSaldoTemporal
                            pVerificarMonto = True
                        End If

                        vContravalor = 0
                        vContravalorTemporal = 0

                        If (pDatoBusqueda + vMontoTemporal) > vImporte Then
                            NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0

                            If NombreFormulario.ProcesarCambioTipoMonedaDoc(NombreFormulario.dgvFormulario, _
                                                                            NombreFormulario.pIdentificadorDgv, _
                                                                            vImporteTemporal, _
                                                                            vTDO_ID, vDTD_ID, _
                                                                            vDTE_SERIE, vDTE_NUMERO, _
                                                                            vMON_ID, vCambiarMonedaSaldo, _
                                                                            pVerificarMonto, False, vPER_ID_CLI) = 1 Then
                                MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                Exit Sub
                            End If
                        End If
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                Case 14 ' RolPersonaTipoPersonas - Banco - Detalle
                        If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RTP_ESTADO") = "NO ACTIVO" Or _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Or _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TPE_ESTADO") = "NO ACTIVO" Then
                            MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                            If TipoEdicion = 1 Then
                                vSaltar = True
                                Exit Sub
                            Else
                                TesoreriaI(Comportamiento)
                                Me.Close()
                            End If
                        Else
                            vSaltar = False
                            NombreFormulario.dgvFormulario.Item("cPER_ID_BAN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                dgvDatos.SelectedRows(0).Cells("PER_ID").Value.ToString()

                            NombreFormulario.Check_Refrescar()
                            NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                        End If

                Case 15 ' Personas - Clientes - Detalle - Liquidación de documento/Entrega a rendir cuenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "xNO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            Select Case NombreFormulario.name.ToString
                                Case "frmPlanillaRendicionCuentas"
                                    TesoreriaI(Comportamiento)
                                Case Else
                                    If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                                        TesoreriaI(-15)
                                    Else
                                        TesoreriaI(Comportamiento)
                                    End If
                            End Select
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        Select Case NombreFormulario.name.ToString
                            Case "frmPlanillaRendicionCuentas"
                            Case Else
                                If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value, True) Then
                                    MensajeError("Se ingreso cuenta contable: " & NombreFormulario.dgvFormulario.Item("cCUC_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                                    TesoreriaI(-15)
                                    Exit Sub
                                End If
                        End Select

                        If Not NombreFormulario.DocumentoPorCtaContable(NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                            MensajeError("Cuenta contable detectada." & Chr(13) & "Ingrese un monto en cargo,  para generar documento por Cuenta contable ")
                            TesoreriaI(-15)
                            Exit Sub
                        End If

                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("PER_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION").Value.ToString()
                        TesoreriaI(16)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If

                Case 16 ' SaldosKardexDocumentos
                    vSaltar = False
                    Select Case NombreFormulario.name.ToString
                        Case "frmPlanillaRendicionCuentas"
                        Case Else
                            If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value, True) Then
                                MensajeError("Se ingreso cuenta contable: " & NombreFormulario.dgvFormulario.Item("cCUC_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                                Exit Sub
                            End If
                    End Select

                    Dim vMON_ID As String = ""
                    Dim vCambiarMonedaSaldo As Double = 0
                    Dim vVerificarMon_Id As Object

                    vVerificarMon_Id = NombreFormulario.VerificarMon_Id(dgvDatos.SelectedRows(0).Cells("MON_ID").Value)
                    vMON_ID = vVerificarMon_Id.Mon_Id
                    vCambiarMonedaSaldo = vVerificarMon_Id.CambiarMonedaSaldo
                    If Not vVerificarMon_Id.VerificarMon_Id Then
                        MensajeError(dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString() & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                        Exit Sub
                    End If

                    Select Case NombreFormulario.pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento, _
                            BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            If NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value <> 0 Then
                                NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            End If
                    End Select

                    Dim vVerificarImporte As Object
                    Select Case NombreFormulario.pTDO_ID
                        Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                            vVerificarImporte = NombreFormulario.VerificarImporteEntregas(vVerificarMon_Id, _
                                                      dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value, _
                                                      NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value, _
                                                      dgvDatos.SelectedRows(0).Cells("SALDO").Value, _
                                                      True
                                                      )
                        Case Else
                            vVerificarImporte = NombreFormulario.VerificarImporte(vVerificarMon_Id, _
                                                      dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value, _
                                                      dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value, _
                                                      NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value, _
                                                      dgvDatos.SelectedRows(0).Cells("SALDO").Value, _
                                                      True
                                                      )
                    End Select


                    If vVerificarImporte.ProcesarEnviarDatos Then
                        NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.TDO_ID
                        NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.DTD_ID
                        NombreFormulario.pDTD_ID_DOC_1 = vVerificarImporte.DTD_ID
                        NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.Serie
                        NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.Numero
                        NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_FECHA_VEN_REF").Value.ToString()

                        NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.Importe
                        NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vVerificarImporte.Contravalor

                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 17 ' CentroCostos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCO_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            If NombreFormulario.VerificarClienteDocumento(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv) Then
                                TesoreriaI(-17)
                            Else
                                TesoreriaI(Comportamiento)
                            End If
                            Me.Close()
                        End If
                    Else
                        vSaltar = False

                        If NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                            MensajeError("Debe ingresar una cuenta contable")
                            TesoreriaI(Comportamiento)
                            Exit Sub
                        End If

                        If NombreFormulario.VerificarClienteDocumento(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv) Then
                            MensajeError("Ingreso documento a abonar del cliente:" & NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                            TesoreriaI(-17)
                            Exit Sub
                        End If

                        NombreFormulario.dgvFormulario.Item("cCCO_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCO_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cCCO_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCO_DESCRIPCION").Value.ToString()
                        NombreFormulario.ColocarDatosAdicionalesCentroCosto(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 18 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CUC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            If NombreFormulario.VerificarClienteDocumento1 Then
                                TesoreriaI(-18)
                            Else
                                TesoreriaI(Comportamiento)
                            End If
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.VerificarClienteDocumento1 Then
                            MensajeError("Ingreso cliente a abonar:" & NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                            TesoreriaI(-18)
                            Exit Sub
                        End If

                        If Not NombreFormulario.VerificarCco_Id(NombreFormulario.dgvFormulario.Item("cCCO_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                            MensajeError("Ingreso centro de costo:" & NombreFormulario.dgvFormulario.Item("cCCO_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                            TesoreriaI(Comportamiento)
                            Exit Sub
                        End If

                        If NombreFormulario.DocumentoNoContable(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv) Then
                            MensajeError("Documento a cargar ingresado")
                            TesoreriaI(-18)
                            Exit Sub
                        End If

                        NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CUC_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cCUC_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CUC_DESCRIPCION").Value.ToString()
                        If NombreFormulario.VerificarBorrarDatosAdicionalesCuentaContable Then NombreFormulario.ImporteMonedaDoc_1Cuc_Id()
                        NombreFormulario.ColocarDatosAdicionalesCuentaContable(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 19 ' RolOpeCtaCte - F12 Nuevo documento - Planilla rendición de cuenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ROC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False

                        NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_ID").Value.ToString()
                        NombreFormulario.pDTD_ID_DOC = dgvDatos.SelectedRows(0).Cells("DTD_ID").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.dgvFormulario.Item("cDTE_SERIE" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value
                        NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.dgvFormulario.Item("cDTE_NUMERO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value
                        NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Now

                        NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                        NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0

                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.txtMON_ID_CCC.text
                        NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.txtMON_DESCRIPCION_CCC.text

                        NombreFormulario.LimpiarCentroCosto()
                        NombreFormulario.RecalcularMontoAbono(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 20 ' PersonaDocumentoIdentidad - Cliente Recibo
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "xNO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_CLI_REC, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_CLI_REC, dgvDatos, "NOMBRE")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 21 ' SaldosKardexDocumentos
                    If pDgvConMarcado Then
                        Dim vFilGrid As Integer
                        vFilGrid = 0
                        If dgvDatos.Rows.Count() > 0 Then
                            While (dgvDatos.Rows.Count() > vFilGrid)
                                dgvDatos.Rows(vFilGrid).Selected = True
                                If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                                    NombreFormulario.vProcesarBusquedaDirectaDocumento = False
                                    If Not NombreFormulario.AdicionarFilasGridDesdeBusqueda Then Exit Sub
                                    Dim vMON_ID As String = ""

                                    Dim vPER_ID_CLI As String = ""
                                    Dim vTDO_ID As String = ""
                                    Dim vDTD_ID As String = ""
                                    Dim vDTE_SERIE As String = ""
                                    Dim vDTE_NUMERO As String = ""
                                    Dim vDTE_IMPORTE As Double = 0

                                    Dim vCambiarMonedaSaldo As Double = 0
                                    Dim vProcesarEnviarDatos As Boolean = True
                                    Dim vProcesarTipoDocumento As Object
                                    vMON_ID = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                                    vCambiarMonedaSaldo = NombreFormulario.CambiarMonedaSaldo(vMON_ID)
                                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                                        If vCambiarMonedaSaldo = 0 Then
                                            MensajeError(dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString() & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                            Exit Sub
                                        End If
                                    End If
                                    vPER_ID_CLI = dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                                    vTDO_ID = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                                    vDTD_ID = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                                    vDTE_SERIE = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                                    vDTE_NUMERO = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()
                                    vDTE_IMPORTE = dgvDatos.SelectedRows(0).Cells("SALDO").Value
                                    vProcesarTipoDocumento = NombreFormulario.ProcesarTipoDocumento(vDTE_IMPORTE, False)
                                    vDTE_IMPORTE = vProcesarTipoDocumento.Importe
                                    vProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
                                    If vProcesarEnviarDatos Then
                                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                            dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                            dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION_CLI").Value.ToString()

                                        NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vTDO_ID
                                        NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTD_ID
                                        NombreFormulario.pDTD_ID_DOC = vDTD_ID
                                        NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_SERIE
                                        NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_NUMERO
                                        NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_FECHA_VEN_REF").Value.ToString()

                                        NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                        NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                        NombreFormulario.dgvFormulario.Item("cDTD_MOVIMIENTO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.ProcesarTipoMovimientoDeDocumento(dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString(), vTDO_ID, vDTD_ID)

                                        Select Case NombreFormulario.ProcesarCambioTipoMonedaDoc(NombreFormulario.dgvFormulario, _
                                                                                                 NombreFormulario.pIdentificadorDgv, _
                                                                                                 vDTE_IMPORTE, _
                                                                                                 vTDO_ID, vDTD_ID, _
                                                                                                 vDTE_SERIE, vDTE_NUMERO, _
                                                                                                 vMON_ID, vCambiarMonedaSaldo, _
                                                                                                 True, True, vPER_ID_CLI)
                                            Case 1
                                                MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                                Exit Sub
                                            Case 2
                                                Exit Sub
                                            Case Else
                                        End Select
                                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()
                                        NombreFormulario.LimpiarCentroCosto()
                                        NombreFormulario.RecalcularMontoAbono(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                                        NombreFormulario.Check_Refrescar()
                                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                                    End If
                                End If
                                vFilGrid += 1
                            End While
                        End If
                        vSaltar = False
                    Else
                        vSaltar = True
                        NombreFormulario.vProcesarBusquedaDirectaDocumento = False
                        If Not NombreFormulario.AdicionarFilasGridDesdeBusqueda Then Exit Sub
                        Dim vMON_ID As String = ""

                        Dim vPER_ID_CLI As String = ""
                        Dim vTDO_ID As String = ""
                        Dim vDTD_ID As String = ""
                        Dim vDTE_SERIE As String = ""
                        Dim vDTE_NUMERO As String = ""
                        Dim vDTE_IMPORTE As Double = 0

                        Dim vCambiarMonedaSaldo As Double = 0
                        Dim vProcesarEnviarDatos As Boolean = True
                        Dim vProcesarTipoDocumento As Object
                        vMON_ID = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                        vCambiarMonedaSaldo = NombreFormulario.CambiarMonedaSaldo(vMON_ID)
                        If vMON_ID <> BCVariablesNames.MonedaSistema Then
                            If vCambiarMonedaSaldo = 0 Then
                                MensajeError(dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString() & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                Exit Sub
                            End If
                        End If
                        vPER_ID_CLI = dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                        vTDO_ID = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                        vDTD_ID = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                        vDTE_SERIE = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                        vDTE_NUMERO = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()
                        vDTE_IMPORTE = dgvDatos.SelectedRows(0).Cells("SALDO").Value

                        vProcesarTipoDocumento = NombreFormulario.ProcesarTipoDocumento(vDTE_IMPORTE, False)
                        vDTE_IMPORTE = vProcesarTipoDocumento.Importe
                        vProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
                        If vProcesarEnviarDatos Then
                            NombreFormulario.dgvFormulario.Item("cPER_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION_CLI").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vTDO_ID
                            NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTD_ID
                            NombreFormulario.pDTD_ID_DOC = vDTD_ID
                            NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_SERIE
                            NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_NUMERO
                            NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_FECHA_VEN_REF").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                            NombreFormulario.dgvFormulario.Item("cDTD_MOVIMIENTO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.ProcesarTipoMovimientoDeDocumento(dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString(), vTDO_ID, vDTD_ID)

                            Select Case NombreFormulario.ProcesarCambioTipoMonedaDoc(NombreFormulario.dgvFormulario, _
                                                                                     NombreFormulario.pIdentificadorDgv, _
                                                                                     vDTE_IMPORTE, _
                                                                                     vTDO_ID, vDTD_ID, _
                                                                                     vDTE_SERIE, vDTE_NUMERO, _
                                                                                     vMON_ID, vCambiarMonedaSaldo, _
                                                                                     True, True, vPER_ID_CLI)
                                Case 1
                                    MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                    Exit Sub
                                Case 2
                                    Exit Sub
                                Case Else
                            End Select
                            NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()
                            NombreFormulario.LimpiarCentroCosto()
                            NombreFormulario.RecalcularMontoAbono(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                            NombreFormulario.Check_Refrescar()
                            NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                        End If
                    End If
                Case 22 ' RolOpeCtaCte - CCT_IDe
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ROC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        If NombreFormulario.dgvFormulario.name = "dgvDetalleEntregas" Then
                            NombreFormulario.dgvFormulario.Item("cDTD_IDr" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTD_ID").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cTDO_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("TDO_ID").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cCCT_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID").Value.ToString()
                            NombreFormulario.dgvFormulario.Item("cCCT_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_DESCRIPCION").Value.ToString()

                            NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID").Value.ToString()
                        End If

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 23 ' SaldosKardexDocumentos
                    If pDgvConMarcado Then
                        Dim vFilGrid As Integer
                        vFilGrid = 0
                        If dgvDatos.Rows.Count() > 0 Then
                            While (dgvDatos.Rows.Count() > vFilGrid)
                                dgvDatos.Rows(vFilGrid).Selected = True
                                If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                                    NombreFormulario.vProcesarBusquedaDirectaDocumento = False
                                    If Not NombreFormulario.AdicionarFilasGridDesdeBusqueda Then Exit Sub
                                    Dim vMON_ID As String = ""

                                    Dim vPER_ID_CLI As String = ""
                                    Dim vTDO_ID As String = ""
                                    Dim vDTD_ID As String = ""
                                    Dim vDTE_SERIE As String = ""
                                    Dim vDTE_NUMERO As String = ""
                                    Dim vDTE_IMPORTE As Double = 0

                                    Dim vCambiarMonedaSaldo As Double = 0
                                    Dim vProcesarEnviarDatos As Boolean = True
                                    Dim vProcesarTipoDocumento As Object
                                    vMON_ID = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                                    vCambiarMonedaSaldo = NombreFormulario.CambiarMonedaSaldo(vMON_ID)
                                    If vMON_ID <> BCVariablesNames.MonedaSistema Then
                                        If vCambiarMonedaSaldo = 0 Then
                                            MensajeError(dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString() & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                            Exit Sub
                                        End If
                                    End If
                                    vPER_ID_CLI = dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                                    vTDO_ID = dgvDatos.SelectedRows(0).Cells("TDO_ID_REF").Value.ToString()
                                    vDTD_ID = dgvDatos.SelectedRows(0).Cells("DTD_ID_REF").Value.ToString()
                                    vDTE_SERIE = dgvDatos.SelectedRows(0).Cells("DOC_SERIE_REF").Value.ToString()
                                    vDTE_NUMERO = dgvDatos.SelectedRows(0).Cells("DOC_NUMERO_REF").Value.ToString()
                                    vDTE_IMPORTE = dgvDatos.SelectedRows(0).Cells("SALDO").Value

                                    vProcesarTipoDocumento = NombreFormulario.ProcesarTipoDocumento(vDTE_IMPORTE, False, "dgvDetalleEntregas")
                                    vDTE_IMPORTE = vProcesarTipoDocumento.Importe
                                    vProcesarEnviarDatos = vProcesarTipoDocumento.ProcesarEnviarDatos
                                    If vProcesarEnviarDatos Then
                                        '' ojitoojito
                                        'Select Case NombreFormulario.pTDO_ID
                                        'Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                                        'Case Else
                                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                            dgvDatos.SelectedRows(0).Cells("PER_ID_CLI").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                                            dgvDatos.SelectedRows(0).Cells("PER_DESCRIPCION_CLI").Value.ToString()

                                        NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vTDO_ID
                                        NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTD_ID
                                        'ojitoojito NombreFormulario.pDTD_ID_DOC = vDTD_ID
                                        NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_SERIE
                                        NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = vDTE_NUMERO
                                        NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DOC_FECHA_VEN_REF").Value.ToString()

                                        NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                        NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                        NombreFormulario.dgvFormulario.Item("cDTD_MOVIMIENTO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.ProcesarTipoMovimientoDeDocumento(dgvDatos.SelectedRows(0).Cells("CCT_ID_REF").Value.ToString(), vTDO_ID, vDTD_ID)
                                        'End Select

                                        Select Case NombreFormulario.ProcesarCambioTipoMonedaDoc_1(NombreFormulario.dgvFormulario, _
                                                                                                     NombreFormulario.pIdentificadorDgv, _
                                                                                                     vDTE_IMPORTE, _
                                                                                                     vTDO_ID, vDTD_ID, _
                                                                                                     vDTE_SERIE, vDTE_NUMERO, _
                                                                                                     vMON_ID, vCambiarMonedaSaldo, _
                                                                                                     True, True, vPER_ID_CLI)

                                            Case 1
                                                MensajeError(NombreFormulario.txtMON_DESCRIPCION_CCC.Text & " - No existe tipo de cambio para el día : " & NombreFormulario.dtpTES_FECHA_EMI.Text)
                                                Exit Sub
                                            Case 2
                                                Exit Sub
                                            Case Else
                                        End Select
                                        Select Case NombreFormulario.pTDO_ID
                                            Case BCVariablesNames.ProcesosCtaCte.PlanillaRendicionCuentas
                                                If NombreFormulario.dgvformulario.name = "dgvDetalleEntregas" Then
                                                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Now
                                                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = NombreFormulario.txtMON_ID_CCC.text
                                                End If
                                        End Select
                                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_ID").Value.ToString()
                                        NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MON_DESCRIPCION").Value.ToString()
                                        NombreFormulario.LimpiarCentroCosto()
                                        'NombreFormulario.RecalcularMontoAbono(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                                        NombreFormulario.Check_Refrescar()
                                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                                    End If
                                End If
                                vFilGrid += 1
                            End While
                        End If
                        vSaltar = False
                    End If
                Case 24 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID_REC, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION_REC, dgvDatos, "CCT_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 25 ' CajaCtaCte - DES
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_CAJ") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO_BAN") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        Dim vCCC_DESCRIPCION As String = ""
                        Dim vCCC_CUENTA_BANCARIA As String = ""
                        Dim vPER_DESCRIPCION_BAN As String = ""
                        Dim vPER_ID_CAJ As String = ""
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID_DES, dgvDatos, "CCC_ID")
                        cMisProcedimientos.ColocarDatosGrid(vCCC_DESCRIPCION, dgvDatos, "CCC_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(vCCC_CUENTA_BANCARIA, dgvDatos, "CCC_CUENTA_BANCARIA")
                        cMisProcedimientos.ColocarDatosGrid(vPER_DESCRIPCION_BAN, dgvDatos, "PER_DESCRIPCION_BAN")
                        NombreFormulario.txtCCC_DESCRIPCION_DES.Text = vCCC_DESCRIPCION & " " & vCCC_CUENTA_BANCARIA & " " & vPER_DESCRIPCION_BAN
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_DES, dgvDatos, "PER_ID_BAN")
                    End If
                Case 26 ' DetalleTesoreria
                    If pDgvConMarcado Then
                        Dim vFilGrid As Integer
                        vFilGrid = 0
                        If dgvDatos.Rows.Count() > 0 Then
                            While (dgvDatos.Rows.Count() > vFilGrid)
                                dgvDatos.Rows(vFilGrid).Selected = True
                                If dgvDatos.SelectedRows(0).Cells("Marcado").Value = 1 Then
                                    NombreFormulario.vProcesarBusquedaDirectaDocumento = False
                                    If Not NombreFormulario.AdicionarFilasGridDesdeBusqueda Then Exit Sub
                                    Dim vMON_ID As String = ""

                                    Dim vPER_ID_CLI As String = ""
                                    Dim vTDO_ID As String = ""
                                    Dim vDTD_ID As String = ""
                                    Dim vDTE_SERIE As String = ""
                                    Dim vDTE_NUMERO As String = ""
                                    Dim vDTE_IMPORTE As Double = 0

                                    Dim vCambiarMonedaSaldo As Double = 0
                                    Dim vProcesarEnviarDatos As Boolean = True
                                    Dim vProcesarTipoDocumento As Object

                                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTE_IMPORTE_DOC").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("DTE_CONTRAVALOR_DOC").Value.ToString()

                                    NombreFormulario.dgvFormulario.Item("cCHE_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CHE_ID").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_MEDIO_PAGO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_MEDIO_PAGO").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_SERIE_MEDIO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_SERIE_MEDIO").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_NUMERO_MEDIO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_NUMERO_MEDIO").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_GIRADO_A" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_GIRADO_A").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_CONCEPTO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_CONCEPTO").Value.ToString()

                                    NombreFormulario.dgvFormulario.Item("cPER_ID_BAN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("PER_ID_BAN").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_DIFERIDO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_DIFERIDO").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_FECHA_DIFERIDO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_FECHA_DIFERIDO").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_RECEPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_RECEPCION").Value.ToString()
                                    NombreFormulario.dgvFormulario.Item("cMPT_UBICACION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("MPT_UBICACION").Value.ToString()
                                End If
                                vFilGrid += 1
                            End While
                        End If
                        vSaltar = False
                    End If

                Case 27 ' Personas - Clientes - Detalle
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "xNO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            TesoreriaI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        TesoreriaI(Comportamiento)
                        Select Case NombreFormulario.pTDO_ID
                            Case BCVariablesNames.ProcesosCaja.CajaIngreso, _
                                 BCVariablesNames.ProcesosCaja.CajaEgreso, _
                                 BCVariablesNames.ProcesosCaja.DepositoTercero
                                Select Case NombreFormulario.tcoTipoRecibo.SelectedTab.Name
                                    Case "tpaPagos"
                                        NombreFormulario.txtPER_ID_CLI_REC.text = dgvDatos.SelectedRows(0).Cells("CODIGO").Value.ToString()
                                        NombreFormulario.txtPER_DESCRIPCION_CLI_REC.text = dgvDatos.SelectedRows(0).Cells("NOMBRE").Value.ToString()
                                End Select
                        End Select
                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("CODIGO").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("NOMBRE").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
                Case 28 ' Personas - Clientes - Detalle - Liquidación de documento
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "xNO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            Select Case NombreFormulario.name.ToString
                                Case "frmPlanillaRendicionCuentas"
                                    TesoreriaI(Comportamiento)
                                Case Else
                                    If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                                        TesoreriaI(-28)
                                    Else
                                        TesoreriaI(Comportamiento)
                                    End If
                            End Select
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        Select Case NombreFormulario.name.ToString
                            Case "frmPlanillaRendicionCuentas"
                            Case Else
                                If Not NombreFormulario.VerificarCuc_Id(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value, True) Then
                                    MensajeError("Se ingreso cuenta contable: " & NombreFormulario.dgvFormulario.Item("cCUC_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value)
                                    TesoreriaI(-28)
                                    Exit Sub
                                End If
                        End Select

                        If Not NombreFormulario.DocumentoPorCtaContable(NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value) Then
                            MensajeError("Cuenta contable detectada." & Chr(13) & "Ingrese un monto en cargo,  para generar documento por Cuenta contable ")
                            TesoreriaI(-28)
                            Exit Sub
                        End If

                        NombreFormulario.dgvFormulario.Item("cPER_ID_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("CODIGO").Value.ToString()
                        NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = _
                            dgvDatos.SelectedRows(0).Cells("NOMBRE").Value.ToString()
                        TesoreriaI(16)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub MensajeError(ByVal vMensaje As String)
            MsgBox(vMensaje, MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
        End Sub
        Private Sub TesoreriaI(ByVal vComportamiento As Int16)
            Select Case vComportamiento
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                Case 3 ' RolOpeCtaCte
                    NombreFormulario.txtTDO_ID.text = ""
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.pCCT_ID = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                    NombreFormulario.Text = ""

                    NombreFormulario.txtCCC_ID.Text = ""
                    NombreFormulario.cboCCC_TIPO.Text = ""
                    NombreFormulario.txtCCC_DESCRIPCION.Text = ""
                    NombreFormulario.txtPER_ID_CAJ.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CAJ.Text = ""
                    NombreFormulario.tslCajero.Text = ""
                    NombreFormulario.txtMON_ID_CCC.Text = ""
                    NombreFormulario.txtMON_DESCRIPCION_CCC.Text = ""
                    NombreFormulario.txtMON_SIMBOLO_CCC.Text = ""

                    NombreFormulario.BuscarSeries()
                Case 4 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID.Text = ""
                    NombreFormulario.cboCCC_TIPO.Text = ""
                    NombreFormulario.txtCCC_DESCRIPCION.Text = ""
                    NombreFormulario.txtPER_ID_CAJ.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CAJ.Text = ""
                    NombreFormulario.tslCajero.Text = ""
                    NombreFormulario.txtMON_ID_CCC.Text = ""
                    NombreFormulario.txtMON_DESCRIPCION_CCC.Text = ""
                    NombreFormulario.txtMON_SIMBOLO_CCC.Text = ""
                Case 5 ' Personas - Cajero
                    NombreFormulario.txtPER_ID_CAJ.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CAJ.Text = ""
                Case 6 ' CtaCte - Detalle - Manejado en la cabecera del formulario
                    NombreFormulario.txtCCT_ID.Text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.Text = ""
                    NombreFormulario.pCCT_ID = ""
                Case 7 ' CajaCtaCte - Detalle
                    NombreFormulario.dgvFormulario.Item("cCCC_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cCCC_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                Case 8, 27 ' Personas - Clientes - Detalle
                    NombreFormulario.dgvFormulario.Item("cPER_ID_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""

                    Select Case NombreFormulario.pTDO_ID
                        Case BCVariablesNames.ProcesosCaja.CajaIngreso,
                             BCVariablesNames.ProcesosCaja.CajaEgreso,
                             BCVariablesNames.ProcesosCaja.DepositoTercero,
                             BCVariablesNames.ProcesosCtaCte.LiquidacionDocumento
                            Select Case NombreFormulario.tcoTipoRecibo.SelectedTab.Name
                                Case "tpaPagos"
                                    NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                Case "tpaEntregas"
                                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Today
                            End Select
                        Case BCVariablesNames.ProcesosCaja.NotaAbonoCtaBanco,
                             BCVariablesNames.ProcesosCaja.PlanillaEgreso
                            Select Case NombreFormulario.tcoTipoRecibo.SelectedTab.Name
                                Case "tpaPagos"
                                    NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                Case "tpaEntregas"
                                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Today
                            End Select
                        Case BCVariablesNames.ProcesosCaja.VoucherCheque
                            If NombreFormulario.cboTipoRecibo.TEXT = "OTROS" Then
                            Else
                                NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                            End If
                        Case BCVariablesNames.ProcesosCaja.NotaCargoCtaBanco
                            Select Case NombreFormulario.tcoTipoRecibo.SelectedTab.Name
                                Case "tpaOtros"
                                Case Else
                                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                            End Select
                        Case Else
                            NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                            NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    End Select
                Case 9 ' SaldosKardexDocumentos - DTD_ID_DOC
                    NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                Case 12 ' SaldosKardexDocumentos - DTE_IMPORTE_DOC
                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                Case 14 ' RolPersonaTipoPersonas - Banco - Detalle
                    NombreFormulario.dgvFormulario.Item("cPER_ID_BAN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                Case 15, -15, 28, -28 ' Personas - Clientes - Detalle - Liquidación de documentos
                    NombreFormulario.dgvFormulario.Item("cPER_ID_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cPER_DESCRIPCION_CLI_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                    If vComportamiento = 15 Then
                        NombreFormulario.VerificarImporteCuentaContable(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                    End If
                Case 16 ' SaldosKardexDocumentos
                    NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                    NombreFormulario.dgvFormulario.Item("cDTE_IMPORTE_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvFormulario.Item("cDTE_CONTRAVALOR_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = 0
                    NombreFormulario.dgvFormulario.Item("cMON_ID_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cMON_DESCRIPCION_DOC_1" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                Case 17, -17 ' CentroCostos
                    NombreFormulario.dgvFormulario.Item("cCCO_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cCCO_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    If vComportamiento = 17 And Not NombreFormulario.EsLiquidacionDocumento Then
                        NombreFormulario.dgvFormulario.Item("cCCT_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cTDO_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cDTD_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cDTE_SERIE_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cDTE_NUMERO_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cMON_ID_DOC" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cDTE_FEC_VEN" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = Nothing
                        NombreFormulario.dgvFormulario.Item("cDTE_MOVIMIENTO" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = BCVariablesNames.Movimiento.Movimiento0
                        NombreFormulario.VerificarImporteCentroCosto(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                    End If
                Case 18, -18 ' CuentasContables
                    NombreFormulario.dgvFormulario.Item("cCUC_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvFormulario.Item("cCUC_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    If vComportamiento = 18 Then
                        NombreFormulario.VerificarImporteCuentaContable(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv)
                    End If
                    If NombreFormulario.VerificarBorrarDatosAdicionalesCuentaContable Then TesoreriaI(-17)
                Case 20 ' PersonaDocumentoIdentidad - Cliente Recibo
                    NombreFormulario.txtPER_ID_CLI_REC.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION_CLI_REC.Text = ""
                Case 22 ' CtaCte - Detalle - Manejado en dgvDetalleEntregas
                    If NombreFormulario.dgvFormulario.name = "dgvDetalleEntregas" Then
                        NombreFormulario.dgvFormulario.Item("cDTD_IDr" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cCCT_ID" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                        NombreFormulario.dgvFormulario.Item("cCCT_DESCRIPCION" & NombreFormulario.pIdentificadorDgv, NombreFormulario.dgvFormulario.CurrentRow.Index).Value = ""
                    End If
                Case 24 ' CtaCte
                    NombreFormulario.txtCCT_ID_REC.Text = ""
                    NombreFormulario.txtCCT_DESCRIPCION_REC.Text = ""
                Case 25 ' CajaCtaCte - Des
                    NombreFormulario.txtCCC_ID_DES.Text = ""
                    NombreFormulario.txtCCC_DESCRIPCION_DES.Text = ""
                    NombreFormulario.txtPER_ID_DES.Text = ""
            End Select
            NombreFormulario.Check_Refrescar()
            NombreFormulario.FiltrarCampos(NombreFormulario.dgvFormulario, NombreFormulario.pIdentificadorDgv, Comportamiento)
        End Sub
        Private Sub TesoreriaO(Optional ByVal vFlagCbo As Boolean = True, _
                               Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case Is <= 0 ' Documentos
                Case 2 ' PuntoVenta
                    'OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_DIRECCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_TIPO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                Case 3 ' RolOpeCtaCte
                    'OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_MODULO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_IDMN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_DESCRIPCION_MN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_IDME", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_DESCRIPCION_ME", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_ESCONTABLE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_FEC_GRAB", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ROC_ESTADO", vFlagCbo, vFlagDgv)
                Case 4 ' CajaCtaCte
                    Select Case NombreFormulario.name.ToString
                        Case "frmReciboIngresos", "frmReciboIngresos01", "frmReciboIngresos02", "frmReciboIngresos03", "frmReciboIngresos04"
                            OcultarNombresCampos("CCC_TIPO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ESTADO_BAN", vFlagCbo, vFlagDgv)
                        Case "frmDepositoTercero"
                            'OcultarNombresCampos("CCC_ID", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_TIPO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ESTADO_BAN", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_DESCRIPCION", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_CUENTA_BANCARIA", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CAJ", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PER_DESCRIPCION_CAJ", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ESTADO_CAJ", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_FECHA_SAL_INI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_MONTO_SAL_INI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CUC_ID", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CUC_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CUC_ESTADO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_ESTADO", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                        Case "frmTransferenciaEntreCajas", "frmDepositosBancarios"
                            'OcultarNombresCampos("CCC_ID", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_TIPO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ESTADO_BAN", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_DESCRIPCION", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_CUENTA_BANCARIA", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CAJ", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PER_DESCRIPCION_CAJ", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ESTADO_CAJ", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_FECHA_SAL_INI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCC_MONTO_SAL_INI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CUC_ID>", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CUC_DESCRIPCION", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CUC_ESTADO", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCC_ESTADO", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                    End Select
                Case 5 ' Personas - Cajero
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_APE_PAT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_APE_MAT", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_NOMBRES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 7 ' CajaCtaCte - Detalle
                    'OcultarNombresCampos("CCC_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_BAN", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_CUENTA_BANCARIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_CAJ", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CAJ", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO_CAJ", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PVE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_FECHA_SAL_INI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_MONTO_SAL_INI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CUC_ID>", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CUC_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCC_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_SIMBOLO", vFlagCbo, vFlagDgv)
                Case 8 ' Personas - Cliente
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_APE_PAT", vFlagCbo, False)
                    OcultarNombresCampos("PER_APE_MAT", vFlagCbo, False)
                    OcultarNombresCampos("PER_NOMBRES", vFlagCbo, False)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO_OP_CON", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSP_PROPIO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BREVETE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FORMA_VENTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_REFERENCIA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIR_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DIS_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PRO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DEP_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PAI_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TELEFONOS", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_EMAIL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PAGINA_WEB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_LINEA_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAS_CREDITO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_VEN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_COB", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_TRA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_GRU", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIASEM_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_COND_DIASEM", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DIAMES_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DOC_PAGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_HORA_PAGO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_OBSERVACIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROMOCIONES", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARTA_FIANZA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_MENSUAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CUOTA_OBJETIVO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_ID_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCC_CUENTA_BANCARIA_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION_BAN_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CARGO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_REP_LEGAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_FIRMA_AUT", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROCESAR_DESCUENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ALIAS", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                Case 9 ' SaldosKardexDocumentos
                    Select Case NombreFormulario.name.ToString
                        Case "frmDepositoTercero"
                            'OcultarNombresCampos("DOC_FECHA_EMI_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("DTD_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("DOC_SERIE_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("DOC_NUMERO_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("SALDO", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                        Case "frmReciboIngresos", "frmReciboIngresos01", "frmReciboIngresos02", "frmReciboIngresos03", "frmReciboIngresos04", _
                             "frmReciboEgresos", "frmReciboEgresos01", "frmReciboEgresos02", "frmReciboEgresos03", "frmReciboEgresos04"
                            OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                        Case "frmLiquidacionDocumento", "frmPlanillaRendicionCuentas"
                            'OcultarNombresCampos("DOC_FECHA_EMI_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    End Select
                Case 14 ' Persona - banco
                    'OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("TPE_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("COM_VENTA_CAN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CLIENTE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_PROVEEDOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_TRANSPORTISTA", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_TRABAJADOR", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_BANCO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_GRUPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CONTACTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TPE_CONTROL", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("RTP_ESTADO", vFlagCbo, vFlagDgv)
                Case 16 ' SaldosKardexDocumentos
                    Select Case NombreFormulario.name.ToString
                        Case "frmLiquidacionDocumento", "frmPlanillaRendicionCuentas"
                            OcultarNombresCampos("DOC_FECHA_EMI_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                            'OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                            OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    End Select
                Case 20 ' PersonaDocumentoIdentidad - CLiente Recibo
                    'OcultarNombresCampos("CODIGO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("NOMBRE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOCUMENTO", vFlagCbo, False)
                    'OcultarNombresCampos("NUMERO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ESTADO", vFlagCbo, vFlagDgv)
                Case 21 ' SaldosKardexDocumentos
                    'OcultarNombresCampos("DOC_FECHA_EMI_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DOC_FECHA_VEN_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_ID_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CCT_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_ID_CLI", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("PER_DESCRIPCION_CLI", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID_REF", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_ID_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_SERIE_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DOC_NUMERO_REF", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("SALDO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                Case 22 ' RolOpeCtaCte - CCT_IDe - DTD_IDre
                    'OcultarNombresCampos("CCT_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("CCT_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("TDO_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DTD_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_CARGO_ABONO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_SIGNO_D_1", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("DTD_MOVIMIENTO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_TIPO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_MODULO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_IDMN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_DESCRIPCION_MN", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_IDME", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("CUC_DESCRIPCION_ME", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_ESCONTABLE", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("ROC_FEC_GRAB", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ROC_ESTADO", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        Private Sub MovimientoCajaBancos()
            Select Case Comportamiento
                Case Is <= 0 ' Cheques
                    NombreFormulario.txtCHE_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCCC_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID_BAN, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_INICIO, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_FIN, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCHE_CORRELATIVO, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCHE_TIPO, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCHE_FORMA_GIRO, dgvDatos, 9)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CHE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 10), oOrm), NombreFormulario.ChkCHE_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' CajaCtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCC_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_ID, dgvDatos, "CCC_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_DESCRIPCION, dgvDatos, "CCC_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION_BAN, dgvDatos, "PER_DESCRIPCION_BAN")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_CUENTA_BANCARIA, dgvDatos, "CCC_CUENTA_BANCARIA")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCC_TIPO, dgvDatos, "CCC_TIPO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' RolPersonaTipoPersona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RTP_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' DetalleTipoDocumentos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTD_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_ID, dgvDatos, "DTD_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTD_DESCRIPCION, dgvDatos, "DTD_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' PersonaDocumentoIdentidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            MovimientoCajaBancosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "NOMBRE")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub MovimientoCajaBancosI()
            Select Case Comportamiento
                Case 1 ' CajaCtaCte
                    NombreFormulario.txtCCC_ID.text = ""
                    NombreFormulario.txtCCC_DESCRIPCION.text = ""
                    NombreFormulario.txtPER_DESCRIPCION_BAN.text = ""
                    NombreFormulario.txtCCC_CUENTA_BANCARIA.text = ""
                    NombreFormulario.txtCCC_TIPO.text = ""
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_SIMBOLO.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 3, 6 ' RolPersonaTipoPersona, PersonaDocumentoIdentidad
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 4 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_SIMBOLO.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                Case 5 ' DetalleTipoDocumentos
                    NombreFormulario.txtDTD_ID.text = ""
                    NombreFormulario.txtDTD_DESCRIPCION.text = ""
            End Select
        End Sub


        ' Cuentas Corrientes
        Private Sub ListaPreciosArticulos()
            Select Case Comportamiento
                Case Is <= 0 ' Datos ListaPreciosArticulos
                    NombreFormulario.txtLPR_ID.Enabled = False
                    NombreFormulario.txtPER_ID.Enabled = False
                    NombreFormulario.txtMON_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtLPR_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboLPR_PRINCIPAL, dgvDatos, "LPR_PRINCIPAL")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PER_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO"), oOrm), _
                        NombreFormulario.ChkPER_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                    cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO"), oOrm), _
                    NombreFormulario.ChkMON_ESTADO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("LPR_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO"), oOrm), _
                        NombreFormulario.ChkLPR_ESTADO)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ListaPreciosArticulosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("MON_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO"), oOrm), _
                            NombreFormulario.ChkMON_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Articulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ListaPreciosArticulosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item(3, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(0).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(4, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(1).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(5, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(6).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(6, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(29).Value.ToString()
                        NombreFormulario.dgvDetalle.Item(7, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells(34).Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ListaPreciosArticulosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "CODIGO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "NOMBRE")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO"), oOrm), _
                            NombreFormulario.ChkPER_ESTADO)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If

            End Select
        End Sub
        Private Sub ListaPreciosArticulosI()
            Select Case Comportamiento
                Case 1 ' Moneda
                    NombreFormulario.txtMON_ID.Text = ""
                    NombreFormulario.txtMON_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkMON_ESTADO)
                Case 2 ' Articulos
                    NombreFormulario.dgvDetalle.Item(3, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(4, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(5, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(6, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item(7, NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                Case 3 ' Personas
                    NombreFormulario.txtPER_ID.Text = ""
                    NombreFormulario.txtPER_DESCRIPCION.Text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPER_ESTADO)
            End Select
        End Sub

        Private Sub DescuentoIncrementoTipoVentaPersonas()
            Select Case Comportamiento
                Case Is <= 0 ' Datos DescuentoIncrementoTipoVentaPersonas
                    NombreFormulario.txtLPR_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_DESCRIPCION, dgvDatos, "DTP_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtLPR_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, "ART_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, "ART_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_DESCRIPCION, dgvDatos, "UM_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_FACTOR, dgvDatos, "ART_FACTOR")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO"), oOrm), _
                        NombreFormulario.ChkART_ESTADO)

                    NombreFormulario.PorArticulo()

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_PRECIO_MINIMO, dgvDatos, "DLP_PRECIO_MINIMO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_PRECIO_UNITARIO, dgvDatos, "DLP_PRECIO_UNITARIO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_RECARGO_ENVIO, dgvDatos, "DLP_RECARGO_ENVIO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DIAS, dgvDatos, "TIV_DIAS")
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIV_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIV_ESTADO"), oOrm), _
                        NombreFormulario.ChkTIV_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_MONTO_TIV, dgvDatos, "DTP_MONTO_TIV")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_MONTO_PER, dgvDatos, "DTP_MONTO_PER")

                    NombreFormulario.PorPersona()

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboDTP_TIPO_DESC_INC, dgvDatos, "DTP_TIPO_DESC_INC")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DTP_CRITERIO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTP_CRITERIO"), oOrm), _
                        NombreFormulario.chkDTP_CRITERIO)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DTP_SUB_CRITERIO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTP_SUB_CRITERIO"), oOrm), _
                        NombreFormulario.chkDTP_SUB_CRITERIO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_MONTO_MINIMO, dgvDatos, "DTP_MONTO_MINIMO")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_MONTO_MAXIMO, dgvDatos, "DTP_MONTO_MAXIMO")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_CANT_MINIMA, dgvDatos, "DTP_CANT_MINIMA")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_CANT_MAXIMA, dgvDatos, "DTP_CANT_MAXIMA")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDTP_FEC_INI, dgvDatos, "DTP_FEC_INI")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpDTP_FEC_FIN, dgvDatos, "DTP_FEC_FIN")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DTP_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DTP_ESTADO"), oOrm), _
                        NombreFormulario.chkDTP_ESTADO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDTP_ID, dgvDatos, "DTP_ID")

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()

                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If

                Case 1 ' Detalle lista de precios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DLP_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_ID, dgvDatos, "ART_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_DESCRIPCION, dgvDatos, "ART_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUM_DESCRIPCION, dgvDatos, "UM_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtART_FACTOR, dgvDatos, "ART_FACTOR")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("ART_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO"), oOrm), _
                            NombreFormulario.chkART_ESTADO)

                        NombreFormulario.PorArticulo()

                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_PRECIO_MINIMO, dgvDatos, "DLP_PRECIO_MINIMO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_PRECIO_UNITARIO, dgvDatos, "DLP_PRECIO_UNITARIO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDLP_RECARGO_ENVIO, dgvDatos, "DLP_RECARGO_ENVIO")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' TipoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIV_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, "TIV_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, "TIV_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DIAS, dgvDatos, "TIV_DIAS")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIV_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIV_ESTADO"), oOrm), NombreFormulario.ChkTIV_ESTADO)

                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 3 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.PorPersona()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 4 ' Lista de precios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, 1)

                        DescuentoIncrementoTipoVentaPersonasI(6)
                        NombreFormulario.txtART_ID.text = ""
                        NombreFormulario.PorArticulo()

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' Detalle lista de precios - Detalle
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ART_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "DLP_ESTADO") = "NO ACTIVO" Or _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DescuentoIncrementoTipoVentaPersonasI(Comportamiento)
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item("cART_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("ART_DESCRIPCION").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub DescuentoIncrementoTipoVentaPersonasI(ByVal comportamiento)
            Select Case comportamiento
                Case 1, 6 ' Detalle lista de precios
                    If comportamiento = 1 Then
                        NombreFormulario.txtLPR_ID.text = ""
                        NombreFormulario.txtLPR_DESCRIPCION.text = ""
                    End If

                    NombreFormulario.txtART_ID.text = ""
                    NombreFormulario.txtART_DESCRIPCION.text = ""
                    NombreFormulario.txtUM_DESCRIPCION.text = ""
                    NombreFormulario.txtART_FACTOR.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkART_ESTADO)

                    NombreFormulario.txtDLP_PRECIO_MINIMO.text = "0"
                    NombreFormulario.txtDLP_PRECIO_UNITARIO.text = "0"
                    NombreFormulario.txtDLP_RECARGO_ENVIO.text = "0"

                    NombreFormulario.PorArticulo()
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(comportamiento)

                Case 2 ' TipoVenta
                    NombreFormulario.txtTIV_ID.text = ""
                    NombreFormulario.txtTIV_DESCRIPCION.text = ""
                    NombreFormulario.txtTIV_DIAS.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkTIV_ESTADO)
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(comportamiento)

                Case 3 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.PorPersona()
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(comportamiento)
                Case 4 ' Lista de precios
                    NombreFormulario.txtLPR_ID.text = ""
                    NombreFormulario.txtLPR_DESCRIPCION.text = ""
                    NombreFormulario.PorArticulo()
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(comportamiento)
                Case 5 ' Detalle lista de precios - Detalle
                    NombreFormulario.dgvDetalle.Item("cART_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cART_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub
        Private Sub DescuentoIncrementoTipoVentaPersonasO(Optional ByVal vFlagCbo As Boolean = True, _
                                                          Optional ByVal vFlagDgv As Boolean = True)
            Select Case Comportamiento
                Case 5 ' DetalleListaPrecios
                    'OcultarNombresCampos("LPR_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_PRINCIPAL", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ID", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("PER_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("MON_DESCRIPCION", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("MON_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ART_ID", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ART_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("UM_DESCRIPCION", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ART_FACTOR", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ART_INC_IGV", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("ART_ESTADO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DLP_PRECIO_MINIMO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DLP_PRECIO_UNITARIO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DLP_RECARGO_ENVIO", vFlagCbo, vFlagDgv)
                    'OcultarNombresCampos("DLP_ESTADO", vFlagCbo, vFlagDgv)
                    OcultarNombresCampos("LPR_ESTADO", vFlagCbo, vFlagDgv)
            End Select
        End Sub

        Private Sub TipoVenta()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' TipoVenta
                    NombreFormulario.txtTIV_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtTIV_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIV_DIAS, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboTIV_COMPORTAMIENTO, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboTIV_FORMA_VENTA, dgvDatos, 4)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("TIV_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 5), oOrm), NombreFormulario.ChkTIV_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub
        Private Sub TipoVentaI()
            Select Case Comportamiento
            End Select
        End Sub
        Private Sub TipoVentaO()
            Select Case Comportamiento
            End Select
        End Sub

        Private Sub PermisoCuentaCorriente()
            Select Case Comportamiento
                Case Is <= 0 ' Datos PermisoCuentaCorriente
                    NombreFormulario.txtPEU_ID.Enabled = False
                    NombreFormulario.txtUSU_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPEU_ID, dgvDatos, "PEU_ID")
                    NombreFormulario.CodigoId = NombreFormulario.txtPEU_ID.Text
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_ID, dgvDatos, "USU_ID")
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_DESCRIPCION, dgvDatos, "USU_DESCRIPCION")

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUSU_TIPO, dgvDatos, "USU_TIPO")

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("USU_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO"), oOrm), _
                        NombreFormulario.ChkUSU_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PEU_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PEU_ESTADO"), oOrm), _
                        NombreFormulario.ChkPEU_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PCC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PCC_ESTADO"), oOrm), _
                        NombreFormulario.ChkPCC_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PermisoUsuarios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PEU_ESTADO") = "NO ACTIVO"  Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            PermisoCuentaCorrienteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPEU_ID, dgvDatos, "PEU_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_ID, dgvDatos, "USU_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtUSU_DESCRIPCION, dgvDatos, "USU_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboUSU_TIPO, dgvDatos, "USU_TIPO")
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("USU_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "USU_ESTADO"), oOrm), _
                            NombreFormulario.ChkUSU_ESTADO)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PEU_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PEU_ESTADO"), oOrm), _
                            NombreFormulario.ChkPEU_ESTADO)

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            PermisoCuentaCorrienteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        NombreFormulario.dgvDetalle.Item("cCCT_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ID").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cCCT_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_DESCRIPCION").Value.ToString()
                        NombreFormulario.dgvDetalle.Item("cCCT_ESTADO", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = dgvDatos.SelectedRows(0).Cells("CCT_ESTADO").Value.ToString()
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub PermisoCuentaCorrienteI()
            Select Case Comportamiento
                Case 1 ' PermisoUsuario
                    NombreFormulario.txtPEU_ID.Text = ""
                    NombreFormulario.txtUSU_ID.Text = ""
                    NombreFormulario.txtUSU_DESCRIPCION.Text = ""
                    NombreFormulario.cboUSU_TIPO.Text = ""

                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkUSU_ESTADO)
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPEU_ESTADO)
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPCC_ESTADO)
                Case 2 ' CtaCte
                    NombreFormulario.dgvDetalle.Item("cCCT_ID", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cCCT_DESCRIPCION", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
                    NombreFormulario.dgvDetalle.Item("cCCT_ESTADO", NombreFormulario.dgvDetalle.CurrentRow.Index).Value = ""
            End Select
        End Sub

        Private Sub CartaFianza()
            Select Case Comportamiento
                Case Is <= 0 ' CartaFianza
                    NombreFormulario.txtCAF_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCAF_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCAF_TIPO_DOC, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpCAF_FECHA_EMI, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.dtpCAF_FECHA_VEN, dgvDatos, 3)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_DIAS_VEN, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_NUMERO, dgvDatos, 5)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 6)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_MONTO, dgvDatos, 8)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, 9)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, 10)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_NUMERO_PRO, dgvDatos, 11)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_IX_ORDEN_COM, dgvDatos, 12)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboCAF_ESTADO_DOC, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCAF_OBSERVACIONES, dgvDatos, 14)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CAF_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), NombreFormulario.ChkCAF_ESTADO)

                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)

                    If Comportamiento = -1 Then
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CartaFianzaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, 1)
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CartaFianzaI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub CartaFianzaI()
            Select Case Comportamiento
                Case 1 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' Personas
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub

        Private Sub KardexCtaCte()
            Select Case Comportamiento
                Case Is <= 0 ' Kardex
                Case 1 ' Personas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "XX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' CtaCte
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "CCT_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_ID, dgvDatos, "CCT_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCCT_DESCRIPCION, dgvDatos, "CCT_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' PersonasDocumentoIdentidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "XX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "Codigo")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "NOMBRE")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub KardexCtaCteI()
            Select Case Comportamiento
                Case 1, 3 ' Persona
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' CtaCte
                    NombreFormulario.txtCCT_ID.text = ""
                    NombreFormulario.txtCCT_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub

        Private Sub ReporteListaPrecios()
            Select Case Comportamiento
                Case Is <= 0 ' ReporteListaPrecios
                Case 1 ' DetalleListaPrecios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Or
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PER_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ReporteListaPreciosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")
                        ''cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        ''cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                        ''cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")

                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 2 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "PVE_ESTADO") = "NO ACTIVO" Or _
                       cMisProcedimientos.DevolverDatosGrid(dgvDatos, "LPR_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ReporteListaPreciosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, "PVE_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, "PVE_DESCRIPCION")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_ID, dgvDatos, "LPR_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtLPR_DESCRIPCION, dgvDatos, "LPR_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 3 ' Moneda
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "MON_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ReporteListaPreciosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_ID, dgvDatos, "MON_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_SIMBOLO, dgvDatos, "MON_SIMBOLO")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtMON_DESCRIPCION, dgvDatos, "MON_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 4 ' RolPersonaTipoPersona
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "RTP_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ReporteListaPreciosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "PER_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "PER_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 5 ' TipoArticulos
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "TIP_ESTADO") = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            ReporteListaPreciosI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_ID, dgvDatos, "TIP_ID")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtTIP_DESCRIPCION, dgvDatos, "TIP_DESCRIPCION")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
                Case 6 ' PersonasDocumentoIdentidad
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, "ESTADO") = "XX" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            KardexCtaCteI()
                            Me.Close()
                        End If
                    Else
                        vSaltar = False
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_ID, dgvDatos, "Codigo")
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPER_DESCRIPCION, dgvDatos, "NOMBRE")
                        NombreFormulario.Check_Refrescar()
                        NombreFormulario.FiltrarCampos(Comportamiento)
                    End If
            End Select
        End Sub
        Private Sub ReporteListaPreciosI()
            Select Case Comportamiento
                Case 1 ' ListaPreciosArticulos
                    NombreFormulario.txtLPR_ID.text = ""
                    NombreFormulario.txtLPR_DESCRIPCION.text = ""
                    'NombreFormulario.txtMON_ID.text = ""
                    'NombreFormulario.txtMON_SIMBOLO.text = ""
                    'NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 2 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.txtLPR_ID.text = ""
                    NombreFormulario.txtLPR_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 3 ' Moneda
                    NombreFormulario.txtMON_ID.text = ""
                    NombreFormulario.txtMON_SIMBOLO.text = ""
                    NombreFormulario.txtMON_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 4 ' RolPersonaTipoPersona
                    NombreFormulario.txtPER_ID.text = ""
                    NombreFormulario.txtPER_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
                Case 5 ' TipoArticulos
                    NombreFormulario.txtTIP_ID.text = ""
                    NombreFormulario.txtTIP_DESCRIPCION.text = ""
                    NombreFormulario.Check_Refrescar()
                    NombreFormulario.FiltrarCampos(Comportamiento)
            End Select
        End Sub

        ' Activos Fijos
        Private Sub Incidencias()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Incidencias
                    NombreFormulario.txtINC_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtINC_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtINC_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtINC_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.cboINC_TIPO, dgvDatos, 2)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("INC_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), NombreFormulario.ChkINC_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
            End Select
        End Sub
        Private Sub IncidenciasI()
            Select Case Comportamiento
            End Select
        End Sub
        Private Sub IncidenciasO()
            Select Case Comportamiento
            End Select
        End Sub

        Private Sub CuentasActivos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' CuentasActivos
                    NombreFormulario.txtCUA_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUA_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtCUA_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_ACT, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ACT, dgvDatos, 2)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_ACT", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 3), oOrm), NombreFormulario.ChkCUC_ESTADO_ACT)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_DEP, dgvDatos, 4)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_DEP, dgvDatos, 5)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_DEP", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 6), oOrm), NombreFormulario.ChkCUC_ESTADO_DEP)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_PRO, dgvDatos, 7)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_PRO, dgvDatos, 8)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_PRO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 9), oOrm), NombreFormulario.ChkCUC_ESTADO_PRO)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_ACT_ACU, dgvDatos, 10)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ACT_ACU, dgvDatos, 11)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_ACT_ACU", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 12), oOrm), NombreFormulario.ChkCUC_ESTADO_ACT_ACU)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_DEP_ACU, dgvDatos, 13)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_DEP_ACU, dgvDatos, 14)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_DEP_ACU", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 15), oOrm), NombreFormulario.ChkCUC_ESTADO_DEP_ACU)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_RES, dgvDatos, 16)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_RES, dgvDatos, 17)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO_RES", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 18), oOrm), NombreFormulario.ChkCUC_ESTADO_RES)

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUA_TASA_ANUAL, dgvDatos, 19)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUA_MESES, dgvDatos, 20)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 21), oOrm), NombreFormulario.ChkCUA_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_ACT, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ACT, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_ACT)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 2 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_DEP, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_DEP, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_DEP)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 3 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_PRO, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_PRO, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_PRO)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 4 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_ACT_ACU, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_ACT_ACU, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_ACT_ACU)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 5 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_DEP_ACU, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_DEP_ACU, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_DEP_ACU)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
                Case 6 ' CuentasContables
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            CuentasActivosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_ID_RES, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtCUC_DESCRIPCION_RES, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("CUC_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 2), oOrm), NombreFormulario.ChkCUC_ESTADO_RES)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
            End Select
        End Sub
        Private Sub CuentasActivosI()
            Select Case Comportamiento
                Case 1 ' CuentasContables
                    NombreFormulario.txtCUC_ID_ACT.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_ACT.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_ACT)
                Case 2 ' CuentasContables
                    NombreFormulario.txtCUC_ID_DEP.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_DEP.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_DEP)
                Case 3 ' CuentasContables
                    NombreFormulario.txtCUC_ID_PRO.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_PRO.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_PRO)
                Case 4 ' CuentasContables
                    NombreFormulario.txtCUC_ID_ACT_ACU.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_ACT_ACU.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_ACT_ACU)
                Case 5 ' CuentasContables
                    NombreFormulario.txtCUC_ID_DEP_ACU.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_DEP_ACU.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_DEP_ACU)
                Case 6 ' CuentasContables
                    NombreFormulario.txtCUC_ID_RES.text = ""
                    NombreFormulario.txtCUC_DESCRIPCION_RES.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkCUC_ESTADO_RES)
            End Select
        End Sub

        Private Sub Edificios()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Edificios
                    NombreFormulario.txtEDI_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtEDI_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkPVE_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("EDI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17), oOrm), NombreFormulario.ChkEDI_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' PuntoVenta
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            EdificiosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtPVE_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("PVE_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), NombreFormulario.ChkPVE_ESTADO)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
            End Select
        End Sub
        Private Sub EdificiosI()
            Select Case Comportamiento
                Case 1 ' PuntoVenta
                    NombreFormulario.txtPVE_ID.text = ""
                    NombreFormulario.txtPVE_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkPVE_ESTADO)
            End Select
        End Sub

        Private Sub Oficinas()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' Oficinas
                    NombreFormulario.txtOFI_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtOFI_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("EDI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkEDI_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("OFI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), NombreFormulario.ChkOFI_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Edificios
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            OficinasI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtEDI_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("EDI_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 17), oOrm), NombreFormulario.ChkEDI_ESTADO)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
            End Select
        End Sub
        Private Sub OficinasI()
            Select Case Comportamiento
                Case 1 ' Edificios
                    NombreFormulario.txtEDI_ID.text = ""
                    NombreFormulario.txtEDI_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkEDI_ESTADO)
            End Select
        End Sub

        Private Sub DepartamentosAdministrativos()
            vSaltar = False
            Select Case Comportamiento
                Case Is <= 0 ' DepartamentosAdministrativos
                    NombreFormulario.txtDEA_ID.Enabled = False
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEA_ID, dgvDatos, 0)
                    NombreFormulario.CodigoId = NombreFormulario.txtDEA_ID.Text

                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtDEA_DESCRIPCION, dgvDatos, 1)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_ID, dgvDatos, 2)
                    cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_DESCRIPCION, dgvDatos, 3)
                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("OFI_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 4), oOrm), NombreFormulario.ChkOFI_ESTADO)

                    cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("DEA_ESTADO", _
                        cMisProcedimientos.DevolverDatosGrid(dgvDatos, 23), oOrm), NombreFormulario.ChkDEA_ESTADO)

                    NombreFormulario.FiltrarCampos(Comportamiento)
                    NombreFormulario.Check_Refrescar()
                    If Comportamiento = -1 Then
                        NombreFormulario.OrmBusquedaDatos("InicializarDatos")
                        NombreFormulario.pnCuerpo.Enabled = False
                    Else
                        NombreFormulario.InicializarDatos()
                    End If
                Case 1 ' Oficinas
                    If cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20) = "NO ACTIVO" Then
                        MsgBox("Datos no activos", MsgBoxStyle.Exclamation, Me.Text & " - DevolverDatos")
                        If TipoEdicion = 1 Then
                            vSaltar = True
                            Exit Sub
                        Else
                            DepartamentosAdministrativosI()
                            Me.Close()
                        End If
                    Else
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_ID, dgvDatos, 0)
                        cMisProcedimientos.ColocarDatosGrid(NombreFormulario.txtOFI_DESCRIPCION, dgvDatos, 1)
                        cMisProcedimientos.EstablecerValorCheck(DevolverTiposCampos("OFI_ESTADO", _
                            cMisProcedimientos.DevolverDatosGrid(dgvDatos, 20), oOrm), NombreFormulario.ChkOFI_ESTADO)
                        NombreFormulario.FiltrarCampos(Comportamiento)
                        NombreFormulario.Check_Refrescar()
                    End If
            End Select
        End Sub
        Private Sub DepartamentosAdministrativosI()
            Select Case Comportamiento
                Case 1 ' Oficinas
                    NombreFormulario.txtOFI_ID.text = ""
                    NombreFormulario.txtOFI_DESCRIPCION.text = ""
                    NombreFormulario.ColocarValoresDefault(NombreFormulario.ChkOFI_ESTADO)
            End Select
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            If cboBuscar.Text.Trim = "" Then Exit Sub
            vEnTiempoReal = True
            If cboDatoBuscar.Enabled Then Buscar(DatosCboBuscar)
            If txtBuscar.Enabled Then Buscar(txtBuscar.Text)
        End Sub

        Private Sub chkBusquedaTiempoReal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBusquedaTiempoReal.CheckedChanged
            If chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Checked Then
                chkBusquedaTiempoReal.Text = "En tiempo real"
                vEnTiempoReal = True
                btnBuscar.Enabled = False
            End If

            If chkBusquedaTiempoReal.CheckState = Windows.Forms.CheckState.Unchecked Then
                chkBusquedaTiempoReal.Text = "A solicitud"
                vEnTiempoReal = False
                btnBuscar.Enabled = True
            End If
        End Sub

        Private Sub btnRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefrescar.Click
            vDataSourceGrid = True
            Dim sender1 As New System.Object
            Dim e1 As New System.EventArgs
            btnBuscar_Click(sender1, e1)
        End Sub

        '' FormClosing
        Private Sub frm_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
            Handles MyBase.FormClosing
            MyBase.OnClosing(e)
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        'Private Sub txt_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        '    Handles txtBuscarSerie.Enter
        '    SendKeys.Send(Chr(Keys.Tab))
        'End Sub
        Private Sub txtBuscarSerie_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles txtBuscarSerie.KeyUp
            If e.KeyData = Keys.Enter Then
                'SendKeys.Send(Chr(Keys.Tab))
                txtBuscar.Focus()
            End If
        End Sub

        Private Sub btnExportarExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportarExcel.Click
            Dim Her As New Herramientas
            Her.excelExportar(Her.ToTable(dgvDatos, lblTitle.Text), lblTitle.Text)
        End Sub

    End Class
End Namespace
