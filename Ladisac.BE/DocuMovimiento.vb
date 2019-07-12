'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios en este archivo pueden ocasionar un comportamiento incorrecto y se perderán si
'     el código se vuelve a generar.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports System.Globalization
Imports System.Runtime.Serialization
Imports System.Runtime.CompilerServices

<DataContract(IsReference:=True)>
<KnownType(GetType(DetalleTipoDocumentos))>
<KnownType(GetType(Moneda))>
<KnownType(GetType(Personas))>
<KnownType(GetType(DocuMovimientoDetalle))>
<KnownType(GetType(OrdenCompra))>
<KnownType(GetType(ControlConteo))>
<KnownType(GetType(Produccion))>
Partial Public Class DocuMovimiento
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DMO_ID As string = "DMO_ID"
				public shared TDO_ID As string = "TDO_ID"
				public shared DTD_ID As string = "DTD_ID"
				public shared DMO_SERIE As string = "DMO_SERIE"
				public shared DMO_NRO As string = "DMO_NRO"
				public shared DMO_FECHA As string = "DMO_FECHA"
				public shared DMO_FECHA_DOCUMENTO As string = "DMO_FECHA_DOCUMENTO"
				public shared ORR_ID As string = "ORR_ID"
				public shared PER_ID_PROVEEDOR As string = "PER_ID_PROVEEDOR"
				public shared MON_ID As string = "MON_ID"
				public shared OCO_ID As string = "OCO_ID"
				public shared DOCU_AFECTA_KARDEX As string = "DOCU_AFECTA_KARDEX"
				public shared SCO_ID As string = "SCO_ID"
				public shared DMO_ASIENTO As string = "DMO_ASIENTO"
				public shared DMO_CIERRE As string = "DMO_CIERRE"
				public shared USU_ID As string = "USU_ID"
				public shared DMO_FEC_GRAB As string = "DMO_FEC_GRAB"
				public shared DMO_ESTADO As string = "DMO_ESTADO"
				public shared CCT_ID As string = "CCT_ID"
				public shared DMO_ID_REF As string = "DMO_ID_REF"
				public shared DRU_ID As string = "DRU_ID"
				public shared CME_ID As string = "CME_ID"
				public shared CPA_ID As string = "CPA_ID"
				public shared TFO_ID As string = "TFO_ID"
				public shared REC_ID As string = "REC_ID"
				public shared DMO_NRO_SERVICIO As string = "DMO_NRO_SERVICIO"
				public shared CCO_ID As string = "CCO_ID"
				public shared OSA_ID As string = "OSA_ID"
				public shared TDO_ID_REF As string = "TDO_ID_REF"
				public shared DTD_ID_REF As string = "DTD_ID_REF"
				public shared CCT_ID_REF As string = "CCT_ID_REF"
				public shared DMO_SERIE_REF As string = "DMO_SERIE_REF"
				public shared DMO_NRO_REF As string = "DMO_NRO_REF"
				public shared CCO_ID_CONTEO As string = "CCO_ID_CONTEO"
				public shared PRO_ID As string = "PRO_ID"
		    End Structure
	



    <DataMember()>
    Public Property DMO_ID() As Integer
        Get
            Return _dMO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dMO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DMO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dMO_ID = value
                OnPropertyChanged("DMO_ID")
            End If
        End Set
    End Property

    Private _dMO_ID As Integer

    <DataMember()>
    Public Property TDO_ID() As String
        Get
            Return _tDO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID, value) Then
                _tDO_ID = value
                OnPropertyChanged("TDO_ID")
            End If
        End Set
    End Property

    Private _tDO_ID As String

    <DataMember()>
    Public Property DTD_ID() As String
        Get
            Return _dTD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID, value) Then
                ChangeTracker.RecordOriginalValue("DTD_ID", _dTD_ID)
                If Not IsDeserializing Then
                    If DetalleTipoDocumentos IsNot Nothing AndAlso Not Equals(DetalleTipoDocumentos.DTD_ID, value) Then
                        DetalleTipoDocumentos = Nothing
                    End If
                End If
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property DMO_SERIE() As String
        Get
            Return _dMO_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMO_SERIE, value) Then
                _dMO_SERIE = value
                OnPropertyChanged("DMO_SERIE")
            End If
        End Set
    End Property

    Private _dMO_SERIE As String

    <DataMember()>
    Public Property DMO_NRO() As String
        Get
            Return _dMO_NRO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMO_NRO, value) Then
                _dMO_NRO = value
                OnPropertyChanged("DMO_NRO")
            End If
        End Set
    End Property

    Private _dMO_NRO As String

    <DataMember()>
    Public Property DMO_FECHA() As Nullable(Of Date)
        Get
            Return _dMO_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dMO_FECHA, value) Then
                _dMO_FECHA = value
                OnPropertyChanged("DMO_FECHA")
            End If
        End Set
    End Property

    Private _dMO_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property DMO_FECHA_DOCUMENTO() As Nullable(Of Date)
        Get
            Return _dMO_FECHA_DOCUMENTO
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dMO_FECHA_DOCUMENTO, value) Then
                _dMO_FECHA_DOCUMENTO = value
                OnPropertyChanged("DMO_FECHA_DOCUMENTO")
            End If
        End Set
    End Property

    Private _dMO_FECHA_DOCUMENTO As Nullable(Of Date)

    <DataMember()>
    Public Property ORR_ID() As Nullable(Of Integer)
        Get
            Return _oRR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRR_ID, value) Then
                ChangeTracker.RecordOriginalValue("ORR_ID", _oRR_ID)
                _oRR_ID = value
                OnPropertyChanged("ORR_ID")
            End If
        End Set
    End Property

    Private _oRR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property PER_ID_PROVEEDOR() As String
        Get
            Return _pER_ID_PROVEEDOR
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_PROVEEDOR, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_PROVEEDOR", _pER_ID_PROVEEDOR)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_PROVEEDOR = value
                OnPropertyChanged("PER_ID_PROVEEDOR")
            End If
        End Set
    End Property

    Private _pER_ID_PROVEEDOR As String

    <DataMember()>
    Public Property MON_ID() As String
        Get
            Return _mON_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID, value) Then
                ChangeTracker.RecordOriginalValue("MON_ID", _mON_ID)
                If Not IsDeserializing Then
                    If Moneda IsNot Nothing AndAlso Not Equals(Moneda.MON_ID, value) Then
                        Moneda = Nothing
                    End If
                End If
                _mON_ID = value
                OnPropertyChanged("MON_ID")
            End If
        End Set
    End Property

    Private _mON_ID As String

    <DataMember()>
    Public Property OCO_ID() As Nullable(Of Integer)
        Get
            Return _oCO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oCO_ID, value) Then
                ChangeTracker.RecordOriginalValue("OCO_ID", _oCO_ID)
                If Not IsDeserializing Then
                    If OrdenCompra IsNot Nothing AndAlso Not Equals(OrdenCompra.OCO_ID, value) Then
                        OrdenCompra = Nothing
                    End If
                End If
                _oCO_ID = value
                OnPropertyChanged("OCO_ID")
            End If
        End Set
    End Property

    Private _oCO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DOCU_AFECTA_KARDEX() As Nullable(Of Boolean)
        Get
            Return _dOCU_AFECTA_KARDEX
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_dOCU_AFECTA_KARDEX, value) Then
                _dOCU_AFECTA_KARDEX = value
                OnPropertyChanged("DOCU_AFECTA_KARDEX")
            End If
        End Set
    End Property

    Private _dOCU_AFECTA_KARDEX As Nullable(Of Boolean)

    <DataMember()>
    Public Property SCO_ID() As Nullable(Of Integer)
        Get
            Return _sCO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_sCO_ID, value) Then
                ChangeTracker.RecordOriginalValue("SCO_ID", _sCO_ID)
                _sCO_ID = value
                OnPropertyChanged("SCO_ID")
            End If
        End Set
    End Property

    Private _sCO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DMO_ASIENTO() As Nullable(Of Boolean)
        Get
            Return _dMO_ASIENTO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_dMO_ASIENTO, value) Then
                _dMO_ASIENTO = value
                OnPropertyChanged("DMO_ASIENTO")
            End If
        End Set
    End Property

    Private _dMO_ASIENTO As Nullable(Of Boolean)

    <DataMember()>
    Public Property DMO_CIERRE() As Nullable(Of Decimal)
        Get
            Return _dMO_CIERRE
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dMO_CIERRE, value) Then
                _dMO_CIERRE = value
                OnPropertyChanged("DMO_CIERRE")
            End If
        End Set
    End Property

    Private _dMO_CIERRE As Nullable(Of Decimal)

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property DMO_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _dMO_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dMO_FEC_GRAB, value) Then
                _dMO_FEC_GRAB = value
                OnPropertyChanged("DMO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dMO_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property DMO_ESTADO() As Nullable(Of Boolean)
        Get
            Return _dMO_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_dMO_ESTADO, value) Then
                _dMO_ESTADO = value
                OnPropertyChanged("DMO_ESTADO")
            End If
        End Set
    End Property

    Private _dMO_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property CCT_ID() As String
        Get
            Return _cCT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID, value) Then
                _cCT_ID = value
                OnPropertyChanged("CCT_ID")
            End If
        End Set
    End Property

    Private _cCT_ID As String

    <DataMember()>
    Public Property DMO_ID_REF() As Nullable(Of Integer)
        Get
            Return _dMO_ID_REF
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dMO_ID_REF, value) Then
                _dMO_ID_REF = value
                OnPropertyChanged("DMO_ID_REF")
            End If
        End Set
    End Property

    Private _dMO_ID_REF As Nullable(Of Integer)

    <DataMember()>
    Public Property DRU_ID() As Nullable(Of Integer)
        Get
            Return _dRU_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRU_ID, value) Then
                ChangeTracker.RecordOriginalValue("DRU_ID", _dRU_ID)
                _dRU_ID = value
                OnPropertyChanged("DRU_ID")
            End If
        End Set
    End Property

    Private _dRU_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property CME_ID() As Nullable(Of Integer)
        Get
            Return _cME_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cME_ID, value) Then
                ChangeTracker.RecordOriginalValue("CME_ID", _cME_ID)
                _cME_ID = value
                OnPropertyChanged("CME_ID")
            End If
        End Set
    End Property

    Private _cME_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property CPA_ID() As Nullable(Of Integer)
        Get
            Return _cPA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cPA_ID, value) Then
                _cPA_ID = value
                OnPropertyChanged("CPA_ID")
            End If
        End Set
    End Property

    Private _cPA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property TFO_ID() As Nullable(Of Integer)
        Get
            Return _tFO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_tFO_ID, value) Then
                ChangeTracker.RecordOriginalValue("TFO_ID", _tFO_ID)
                _tFO_ID = value
                OnPropertyChanged("TFO_ID")
            End If
        End Set
    End Property

    Private _tFO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property REC_ID() As Nullable(Of Integer)
        Get
            Return _rEC_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_rEC_ID, value) Then
                ChangeTracker.RecordOriginalValue("REC_ID", _rEC_ID)
                _rEC_ID = value
                OnPropertyChanged("REC_ID")
            End If
        End Set
    End Property

    Private _rEC_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DMO_NRO_SERVICIO() As String
        Get
            Return _dMO_NRO_SERVICIO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMO_NRO_SERVICIO, value) Then
                _dMO_NRO_SERVICIO = value
                OnPropertyChanged("DMO_NRO_SERVICIO")
            End If
        End Set
    End Property

    Private _dMO_NRO_SERVICIO As String

    <DataMember()>
    Public Property CCO_ID() As Nullable(Of Integer)
        Get
            Return _cCO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cCO_ID, value) Then
                ChangeTracker.RecordOriginalValue("CCO_ID", _cCO_ID)
                _cCO_ID = value
                OnPropertyChanged("CCO_ID")
            End If
        End Set
    End Property

    Private _cCO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OSA_ID() As Nullable(Of Integer)
        Get
            Return _oSA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oSA_ID, value) Then
                ChangeTracker.RecordOriginalValue("OSA_ID", _oSA_ID)
                _oSA_ID = value
                OnPropertyChanged("OSA_ID")
            End If
        End Set
    End Property

    Private _oSA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property TDO_ID_REF() As String
        Get
            Return _tDO_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID_REF, value) Then
                _tDO_ID_REF = value
                OnPropertyChanged("TDO_ID_REF")
            End If
        End Set
    End Property

    Private _tDO_ID_REF As String

    <DataMember()>
    Public Property DTD_ID_REF() As String
        Get
            Return _dTD_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID_REF, value) Then
                ChangeTracker.RecordOriginalValue("DTD_ID_REF", _dTD_ID_REF)
                If Not IsDeserializing Then
                    If DetalleTipoDocumentos1 IsNot Nothing AndAlso Not Equals(DetalleTipoDocumentos1.DTD_ID, value) Then
                        DetalleTipoDocumentos1 = Nothing
                    End If
                End If
                _dTD_ID_REF = value
                OnPropertyChanged("DTD_ID_REF")
            End If
        End Set
    End Property

    Private _dTD_ID_REF As String

    <DataMember()>
    Public Property CCT_ID_REF() As String
        Get
            Return _cCT_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID_REF, value) Then
                _cCT_ID_REF = value
                OnPropertyChanged("CCT_ID_REF")
            End If
        End Set
    End Property

    Private _cCT_ID_REF As String

    <DataMember()>
    Public Property DMO_SERIE_REF() As String
        Get
            Return _dMO_SERIE_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMO_SERIE_REF, value) Then
                _dMO_SERIE_REF = value
                OnPropertyChanged("DMO_SERIE_REF")
            End If
        End Set
    End Property

    Private _dMO_SERIE_REF As String

    <DataMember()>
    Public Property DMO_NRO_REF() As String
        Get
            Return _dMO_NRO_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dMO_NRO_REF, value) Then
                _dMO_NRO_REF = value
                OnPropertyChanged("DMO_NRO_REF")
            End If
        End Set
    End Property

    Private _dMO_NRO_REF As String

    <DataMember()>
    Public Property CCO_ID_CONTEO() As Nullable(Of Integer)
        Get
            Return _cCO_ID_CONTEO
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cCO_ID_CONTEO, value) Then
                ChangeTracker.RecordOriginalValue("CCO_ID_CONTEO", _cCO_ID_CONTEO)
                If Not IsDeserializing Then
                    If ControlConteo IsNot Nothing AndAlso Not Equals(ControlConteo.CCO_ID, value) Then
                        ControlConteo = Nothing
                    End If
                End If
                _cCO_ID_CONTEO = value
                OnPropertyChanged("CCO_ID_CONTEO")
            End If
        End Set
    End Property

    Private _cCO_ID_CONTEO As Nullable(Of Integer)

    <DataMember()>
    Public Property PRO_ID() As Nullable(Of Integer)
        Get
            Return _pRO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pRO_ID, value) Then
                ChangeTracker.RecordOriginalValue("PRO_ID", _pRO_ID)
                If Not IsDeserializing Then
                    If Produccion IsNot Nothing AndAlso Not Equals(Produccion.PRO_ID, value) Then
                        Produccion = Nothing
                    End If
                End If
                _pRO_ID = value
                OnPropertyChanged("PRO_ID")
            End If
        End Set
    End Property

    Private _pRO_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DetalleTipoDocumentos() As DetalleTipoDocumentos
        Get
            Return _detalleTipoDocumentos
        End Get
        Set(ByVal value As DetalleTipoDocumentos)
            If _detalleTipoDocumentos IsNot value Then
                Dim previousValue As DetalleTipoDocumentos = _detalleTipoDocumentos
                _detalleTipoDocumentos = value
                FixupDetalleTipoDocumentos(previousValue)
                OnNavigationPropertyChanged("DetalleTipoDocumentos")
            End If
        End Set
    End Property

    Private _detalleTipoDocumentos As DetalleTipoDocumentos


    <DataMember()>
    Public Property Moneda() As Moneda
        Get
            Return _moneda
        End Get
        Set(ByVal value As Moneda)
            If _moneda IsNot value Then
                Dim previousValue As Moneda = _moneda
                _moneda = value
                FixupMoneda(previousValue)
                OnNavigationPropertyChanged("Moneda")
            End If
        End Set
    End Property

    Private _moneda As Moneda


    <DataMember()>
    Public Property Personas() As Personas
        Get
            Return _personas
        End Get
        Set(ByVal value As Personas)
            If _personas IsNot value Then
                Dim previousValue As Personas = _personas
                _personas = value
                FixupPersonas(previousValue)
                OnNavigationPropertyChanged("Personas")
            End If
        End Set
    End Property

    Private _personas As Personas


    <DataMember()>
    Public Property DocuMovimientoDetalle() As TrackableCollection(Of DocuMovimientoDetalle)
        Get
            If _docuMovimientoDetalle Is Nothing Then
                _docuMovimientoDetalle = New TrackableCollection(Of DocuMovimientoDetalle)
                AddHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
            End If
            Return _docuMovimientoDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimientoDetalle))
            If Not Object.ReferenceEquals(_docuMovimientoDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimientoDetalle IsNot Nothing Then
                    RemoveHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
                End If
                _docuMovimientoDetalle = value
                If _docuMovimientoDetalle IsNot Nothing Then
                    AddHandler _docuMovimientoDetalle.CollectionChanged, AddressOf FixupDocuMovimientoDetalle
                End If
                OnNavigationPropertyChanged("DocuMovimientoDetalle")
            End If
        End Set
    End Property

    Private _docuMovimientoDetalle As TrackableCollection(Of DocuMovimientoDetalle)

    <DataMember()>
    Public Property DetalleTipoDocumentos1() As DetalleTipoDocumentos
        Get
            Return _detalleTipoDocumentos1
        End Get
        Set(ByVal value As DetalleTipoDocumentos)
            If _detalleTipoDocumentos1 IsNot value Then
                Dim previousValue As DetalleTipoDocumentos = _detalleTipoDocumentos1
                _detalleTipoDocumentos1 = value
                FixupDetalleTipoDocumentos1(previousValue)
                OnNavigationPropertyChanged("DetalleTipoDocumentos1")
            End If
        End Set
    End Property

    Private _detalleTipoDocumentos1 As DetalleTipoDocumentos


    <DataMember()>
    Public Property OrdenCompra() As OrdenCompra
        Get
            Return _ordenCompra
        End Get
        Set(ByVal value As OrdenCompra)
            If _ordenCompra IsNot value Then
                Dim previousValue As OrdenCompra = _ordenCompra
                _ordenCompra = value
                FixupOrdenCompra(previousValue)
                OnNavigationPropertyChanged("OrdenCompra")
            End If
        End Set
    End Property

    Private _ordenCompra As OrdenCompra


    <DataMember()>
    Public Property ControlConteo() As ControlConteo
        Get
            Return _controlConteo
        End Get
        Set(ByVal value As ControlConteo)
            If _controlConteo IsNot value Then
                Dim previousValue As ControlConteo = _controlConteo
                _controlConteo = value
                FixupControlConteo(previousValue)
                OnNavigationPropertyChanged("ControlConteo")
            End If
        End Set
    End Property

    Private _controlConteo As ControlConteo


    <DataMember()>
    Public Property Produccion() As Produccion
        Get
            Return _produccion
        End Get
        Set(ByVal value As Produccion)
            If _produccion IsNot value Then
                Dim previousValue As Produccion = _produccion
                _produccion = value
                FixupProduccion(previousValue)
                OnNavigationPropertyChanged("Produccion")
            End If
        End Set
    End Property

    Private _produccion As Produccion


#End Region
#Region "ChangeTracking"

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        If ChangeTracker.State <> ObjectState.Added AndAlso ChangeTracker.State <> ObjectState.Deleted Then
            ChangeTracker.State = ObjectState.Modified
        End If
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Protected Overridable Sub OnNavigationPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
    Private _changeTracker As ObjectChangeTracker

    <DataMember()>
    Public Property ChangeTracker() As ObjectChangeTracker Implements IObjectWithChangeTracker.ChangeTracker
        Get
            If _changeTracker Is Nothing Then
                _changeTracker = New ObjectChangeTracker()
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            Return _changeTracker
        End Get
        Set(ByVal value As ObjectChangeTracker)
            If _changeTracker IsNot Nothing Then
                RemoveHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
            _changeTracker = value
            If _changeTracker IsNot Nothing Then
                AddHandler _changeTracker.ObjectStateChanging, AddressOf HandleObjectStateChanging
            End If
        End Set
    End Property

    Private Sub HandleObjectStateChanging(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.ClearNavigationProperties()
        End If
    End Sub

    Private _isDeserializing As Boolean
    Protected Property IsDeserializing() As Boolean
        Get
            Return _isDeserializing
        End Get
        Private Set(ByVal value As Boolean)
            _isDeserializing = value
        End Set
    End Property

    <OnDeserializing()>
    Public Sub OnDeserializingMethod(ByVal context As StreamingContext)
        IsDeserializing = True
    End Sub

    <OnDeserialized()>
    Public Sub OnDeserializedMethod(ByVal context As StreamingContext)
        IsDeserializing = False
        ChangeTracker.ChangeTrackingEnabled = True
    End Sub

    Protected Overridable Sub ClearNavigationProperties()
        DetalleTipoDocumentos = Nothing
        Moneda = Nothing
        Personas = Nothing
        DocuMovimientoDetalle.Clear()
        DetalleTipoDocumentos1 = Nothing
        OrdenCompra = Nothing
        ControlConteo = Nothing
        Produccion = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDetalleTipoDocumentos(ByVal previousValue As DetalleTipoDocumentos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DocuMovimiento.Contains(Me) Then
            previousValue.DocuMovimiento.Remove(Me)
        End If

        If DetalleTipoDocumentos IsNot Nothing Then
            If Not DetalleTipoDocumentos.DocuMovimiento.Contains(Me) Then
                DetalleTipoDocumentos.DocuMovimiento.Add(Me)
            End If

            DTD_ID = DetalleTipoDocumentos.DTD_ID
        ElseIf Not skipKeys Then
            DTD_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DetalleTipoDocumentos") AndAlso
                ChangeTracker.OriginalValues("DetalleTipoDocumentos") Is DetalleTipoDocumentos Then
                ChangeTracker.OriginalValues.Remove("DetalleTipoDocumentos")
            Else
                ChangeTracker.RecordOriginalValue("DetalleTipoDocumentos", previousValue)
            End If
            If DetalleTipoDocumentos IsNot Nothing AndAlso Not DetalleTipoDocumentos.ChangeTracker.ChangeTrackingEnabled Then
                DetalleTipoDocumentos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupMoneda(ByVal previousValue As Moneda)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DocuMovimiento.Contains(Me) Then
            previousValue.DocuMovimiento.Remove(Me)
        End If

        If Moneda IsNot Nothing Then
            If Not Moneda.DocuMovimiento.Contains(Me) Then
                Moneda.DocuMovimiento.Add(Me)
            End If

            MON_ID = Moneda.MON_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Moneda") AndAlso
                ChangeTracker.OriginalValues("Moneda") Is Moneda Then
                ChangeTracker.OriginalValues.Remove("Moneda")
            Else
                ChangeTracker.RecordOriginalValue("Moneda", previousValue)
            End If
            If Moneda IsNot Nothing AndAlso Not Moneda.ChangeTracker.ChangeTrackingEnabled Then
                Moneda.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_PROVEEDOR = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_PROVEEDOR = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas") AndAlso
                ChangeTracker.OriginalValues("Personas") Is Personas Then
                ChangeTracker.OriginalValues.Remove("Personas")
            Else
                ChangeTracker.RecordOriginalValue("Personas", previousValue)
            End If
            If Personas IsNot Nothing AndAlso Not Personas.ChangeTracker.ChangeTrackingEnabled Then
                Personas.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDetalleTipoDocumentos1(ByVal previousValue As DetalleTipoDocumentos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DocuMovimiento1.Contains(Me) Then
            previousValue.DocuMovimiento1.Remove(Me)
        End If

        If DetalleTipoDocumentos1 IsNot Nothing Then
            If Not DetalleTipoDocumentos1.DocuMovimiento1.Contains(Me) Then
                DetalleTipoDocumentos1.DocuMovimiento1.Add(Me)
            End If

            DTD_ID_REF = DetalleTipoDocumentos1.DTD_ID
        ElseIf Not skipKeys Then
            DTD_ID_REF = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DetalleTipoDocumentos1") AndAlso
                ChangeTracker.OriginalValues("DetalleTipoDocumentos1") Is DetalleTipoDocumentos1 Then
                ChangeTracker.OriginalValues.Remove("DetalleTipoDocumentos1")
            Else
                ChangeTracker.RecordOriginalValue("DetalleTipoDocumentos1", previousValue)
            End If
            If DetalleTipoDocumentos1 IsNot Nothing AndAlso Not DetalleTipoDocumentos1.ChangeTracker.ChangeTrackingEnabled Then
                DetalleTipoDocumentos1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupOrdenCompra(ByVal previousValue As OrdenCompra, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DocuMovimiento.Contains(Me) Then
            previousValue.DocuMovimiento.Remove(Me)
        End If

        If OrdenCompra IsNot Nothing Then
            If Not OrdenCompra.DocuMovimiento.Contains(Me) Then
                OrdenCompra.DocuMovimiento.Add(Me)
            End If

            OCO_ID = OrdenCompra.OCO_ID
        ElseIf Not skipKeys Then
            OCO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("OrdenCompra") AndAlso
                ChangeTracker.OriginalValues("OrdenCompra") Is OrdenCompra Then
                ChangeTracker.OriginalValues.Remove("OrdenCompra")
            Else
                ChangeTracker.RecordOriginalValue("OrdenCompra", previousValue)
            End If
            If OrdenCompra IsNot Nothing AndAlso Not OrdenCompra.ChangeTracker.ChangeTrackingEnabled Then
                OrdenCompra.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupControlConteo(ByVal previousValue As ControlConteo, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If ControlConteo IsNot Nothing Then
            CCO_ID_CONTEO = ControlConteo.CCO_ID
        ElseIf Not skipKeys Then
            CCO_ID_CONTEO = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ControlConteo") AndAlso
                ChangeTracker.OriginalValues("ControlConteo") Is ControlConteo Then
                ChangeTracker.OriginalValues.Remove("ControlConteo")
            Else
                ChangeTracker.RecordOriginalValue("ControlConteo", previousValue)
            End If
            If ControlConteo IsNot Nothing AndAlso Not ControlConteo.ChangeTracker.ChangeTrackingEnabled Then
                ControlConteo.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupProduccion(ByVal previousValue As Produccion, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Produccion IsNot Nothing Then
            PRO_ID = Produccion.PRO_ID
        ElseIf Not skipKeys Then
            PRO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Produccion") AndAlso
                ChangeTracker.OriginalValues("Produccion") Is Produccion Then
                ChangeTracker.OriginalValues.Remove("Produccion")
            Else
                ChangeTracker.RecordOriginalValue("Produccion", previousValue)
            End If
            If Produccion IsNot Nothing AndAlso Not Produccion.ChangeTracker.ChangeTrackingEnabled Then
                Produccion.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDocuMovimientoDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimientoDetalle In e.NewItems
                item.DMO_ID = DMO_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimientoDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimientoDetalle In e.OldItems
                item.DMO_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimientoDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class