﻿Imports Microsoft.Practices.Prism.Modularity
Imports Microsoft.Practices.Unity

Namespace Ladisac.Logistica

    Public Class ModuleIni
        Implements IModule

        <Dependency()> _
        Public Property ContainerService As IUnityContainer

        Public Sub Initialize() Implements Microsoft.Practices.Prism.Modularity.IModule.Initialize
            RegistrarDA()
            RegistrarBL()
            RegistrarComponentes()
        End Sub

        Public Sub RegistrarDA()
            ContainerService.RegisterType(Of DA.IAlmacenRepositorio, DA.AlmacenRepositorio)()
            ContainerService.RegisterType(Of DA.IArticuloRepositorio, DA.ArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.IDistritoRepositorio, DA.DistritoRepositorio)()
            ContainerService.RegisterType(Of DA.IGrupoLineasRepositorio, DA.GrupoLineasRepositorio)()
            ContainerService.RegisterType(Of DA.IModeloArticuloRepositorio, DA.ModeloArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.IMarcaArticuloRepositorio, DA.MarcaArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.IUnidadMedidaRepositorio, DA.UnidadMedidaRepositorio)()
            ContainerService.RegisterType(Of DA.IPersonaRepositorio, DA.PersonaRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenTrabajoRepositorio, DA.OrdenTrabajoRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenRequerimientoRepositorio, DA.OrdenRequerimientoRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenRequerimientoDetalleRepositorio, DA.OrdenRequerimientoDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenCompraRepositorio, DA.OrdenCompraRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenCompraDetalleRepositorio, DA.OrdenCompraDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.ISalidaCombustibleRepositorio, DA.SalidaCombustibleRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoDocumentoRepositorio, DA.TipoDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleTipoDocumentoRepositorio, DA.DetalleTipoDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.IUnidadesTransporteRepositorio, DA.UnidadesTransporteRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoVentaRepositorio, DA.TipoVentaRepositorio)()
            ContainerService.RegisterType(Of DA.IHerramientasRepositorio, DA.HerramientasRepositorio)()
            ContainerService.RegisterType(Of DA.IDocuMovimientoRepositorio, DA.DocuMovimientoRepositorio)()
            ContainerService.RegisterType(Of DA.IDocuMovimientoDetalleRepositorio, DA.DocuMovimientoDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IArticuloAlmacenRepositorio, DA.ArticuloAlmacenRepositorio)()
            ContainerService.RegisterType(Of DA.IKardexRepositorio, DA.kardexRepositorio)()
            ContainerService.RegisterType(Of DA.ITipoArticuloRepositorio, DA.TipoArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.IFamiliaArticuloRepositorio, DA.FamiliaArticuloRepositorio)()
            ContainerService.RegisterType(Of DA.ILineaFamiliaRepositorio, DA.LineaFamiliaRepositorio)()
            ContainerService.RegisterType(Of DA.IEntidadRepositorio, DA.EntidadRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenSalidaRepositorio, DA.OrdensalidaRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenSalidaDetalleRepositorio, DA.OrdenSalidaDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IDotacionRepositorio, DA.DotacionRepositorio)()
            ContainerService.RegisterType(Of DA.IUbicacionAlmacenRepositorio, DA.UbicacionAlmacenRepositorio)()
            ContainerService.RegisterType(Of DA.IGuiaRemisionRepositorio, DA.GuiaRemisionRepositorio)()
            ContainerService.RegisterType(Of DA.IGuiaRemisionDetalleRepositorio, DA.GuiaRemisionDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IProcesoCompraRepositorio, DA.ProcesoCompraRepositorio)()
            ContainerService.RegisterType(Of DA.IProcesoCompraDetalleRepositorio, DA.ProcesoCompraDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IDetalleConsolidadoRepositorio, DA.DetalleConsolidadoRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudCompraRepositorio, DA.SolicitudCompraRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudCompraDetalleRepositorio, DA.SolicitudCompraDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.ITransformacionRepositorio, DA.TransformacionRepositorio)()
            ContainerService.RegisterType(Of DA.ITransformacionDetalleRepositorio, DA.TransformacionDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IRendicionCuentaRepositorio, DA.RendicionCuentaRepositorio)()
            ContainerService.RegisterType(Of DA.IRendicionCuentaDetalleRepositorio, DA.RendicionCuentaDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IParametroRepositorio, DA.ParametroRepositorio)()
            ContainerService.RegisterType(Of DA.IInventarioRepositorio, DA.InventarioRepositorio)()
            ContainerService.RegisterType(Of DA.IControlGrifoRepositorio, DA.ControlGrifoRepositorio)()
            ContainerService.RegisterType(Of DA.IRubroRepositorio, DA.RubroRepositorio)()
            ContainerService.RegisterType(Of DA.ICuadroComparativoRepositorio, DA.CuadroComparativoRepositorio)()
            ContainerService.RegisterType(Of DA.ICierreAlmacenRepositorio, DA.CierreAlmacenRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenServicioRepositorio, DA.OrdenServicioRepositorio)()
            ContainerService.RegisterType(Of DA.IOrdenServicioDetalleRepositorio, DA.OrdenServicioDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudSoporteRepositorio, DA.SolicitudSoporteRepositorio)()
            ContainerService.RegisterType(Of DA.ISolicitudSoporteDetalleRepositorio, DA.SolicitudSoporteDetalleRepositorio)()
            ContainerService.RegisterType(Of DA.IRecepcionDocumentoRepositorio, DA.RecepcionDocumentoRepositorio)()
            ContainerService.RegisterType(Of DA.IRendicionGastosRepositorio, DA.RendicionGastosRepositorio)()
            ContainerService.RegisterType(Of DA.ICuentaRendirRepositorio, DA.CuentaRendirRepositorio)()
        End Sub

        Public Sub RegistrarBL()
            ContainerService.RegisterType(Of BL.IBCAlmacen, BL.BCAlmacen)()
            ContainerService.RegisterType(Of BL.IBCArticulo, BL.BCArticulo)()
            ContainerService.RegisterType(Of BL.IBCDistrito, BL.BCDistrito)()
            ContainerService.RegisterType(Of BL.IBCGrupoLineas, BL.BCGrupoLineas)()
            ContainerService.RegisterType(Of BL.IBCModeloArticulo, BL.BCModeloArticulo)()
            ContainerService.RegisterType(Of BL.IBCMarcaArticulo, BL.BCMarcaArticulo)()
            ContainerService.RegisterType(Of BL.IBCUnidadMedida, BL.BCUnidadMedida)()
            ContainerService.RegisterType(Of BL.IBCPersona, BL.BCPersona)()
            ContainerService.RegisterType(Of BL.IBCOrdenTrabajo, BL.BCOrdenTrabajo)()
            ContainerService.RegisterType(Of BL.IBCOrdenRequerimiento, BL.BCOrdenRequerimiento)()
            ContainerService.RegisterType(Of BL.IBCOrdenCompra, BL.BCOrdencompra)()
            ContainerService.RegisterType(Of BL.IBCSalidaCombustible, BL.BCSalidaCombustible)()
            ContainerService.RegisterType(Of BL.IBCTipoDocumento, BL.BCTipoDocumento)()
            ContainerService.RegisterType(Of BL.IBCUnidadesTransporte, BL.BCUnidadesTransporte)()
            ContainerService.RegisterType(Of BL.IBCTipoVenta, BL.BCTipoVenta)()
            ContainerService.RegisterType(Of BL.IBCHerramientas, Ladisac.BL.BCHerramientas)()
            ContainerService.RegisterType(Of BL.IBCDocuMovimiento, BL.BCDocuMovimiento)()
            ContainerService.RegisterType(Of BL.IBCArticuloAlmacen, BL.BCArticuloAlmacen)()
            ContainerService.RegisterType(Of BL.IBCKardex, BL.BCKardex)()
            ContainerService.RegisterType(Of BL.IBCTipoArticulo, BL.BCTipoArticulo)()
            ContainerService.RegisterType(Of BL.IBCFamiliaArticulo, BL.BCFamiliaArticulo)()
            ContainerService.RegisterType(Of BL.IBCLineaFamilia, BL.BCLineaFamilia)()
            ContainerService.RegisterType(Of BL.IBCEntidad, BL.BCEntidad)()
            ContainerService.RegisterType(Of BL.IBCOrdenSalida, BL.BCOrdenSalida)()
            ContainerService.RegisterType(Of BL.IBCDotacion, BL.BCDotacion)()
            ContainerService.RegisterType(Of BL.IBCUbicacionAlmacen, BL.BCUbicacionAlmacen)()
            ContainerService.RegisterType(Of BL.IBCGuiaRemision, BL.BCGuiaRemision)()
            ContainerService.RegisterType(Of BL.IBCProcesoCompra, BL.BCProcesoCompra)()
            ContainerService.RegisterType(Of BL.IBCSolicitudCompra, BL.BCSolicitudCompra)()
            ContainerService.RegisterType(Of BL.IBCTransformacion, BL.BCTransformacion)()
            ContainerService.RegisterType(Of BL.IBCRendicionCuenta, BL.BCRendicionCuenta)()
            ContainerService.RegisterType(Of BL.IBCParametro, BL.BCParametro)()
            ContainerService.RegisterType(Of BL.IBCInventario, BL.BCInventario)()
            ContainerService.RegisterType(Of BL.IBCControlGrifo, BL.BCControlgrifo)()
            ContainerService.RegisterType(Of BL.IBCRubro, BL.BCRubro)()
            ContainerService.RegisterType(Of BL.IBCCuadroComparativo, BL.BCCuadroComparativo)()
            ContainerService.RegisterType(Of BL.IBCCierreAlmacen, BL.BCCierreAlmacen)()
            ContainerService.RegisterType(Of BL.IBCOrdenServicio, BL.BCOrdenServicio)()
            ContainerService.RegisterType(Of BL.IBCSolicitudSoporte, BL.BCSolicitudSoporte)()
            ContainerService.RegisterType(Of BL.IBCRecepcionDocumento, BL.BCRecepcionDocumento)()
            ContainerService.RegisterType(Of BL.IBCRendicionGastos, BL.BCRendicionGastos)()
            ContainerService.RegisterType(Of BL.IBCCuentaRendir, BL.BCCuentaRendir)()
        End Sub

        Private Sub RegistrarComponentes()
            ContainerService.RegisterType(Of Ladisac.Logistica.ModuleController) _
                (New Microsoft.Practices.Unity.ContainerControlledLifetimeManager)

            Dim controlller = ContainerService.Resolve(Of Ladisac.Logistica.ModuleController)()
            controlller.run()
        End Sub
    End Class

End Namespace
