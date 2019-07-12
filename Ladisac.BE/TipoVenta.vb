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
<KnownType(GetType(DescuentoIncrementoTipoVentaPersonas))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(SolicitudCompra))>
<KnownType(GetType(Documentos))>
<KnownType(GetType(ProvisionCompras))>
<KnownType(GetType(OrdenServicio))>
<KnownType(GetType(OrdenCompra))>
Partial Public Class TipoVenta
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TIV_ID As string = "TIV_ID"
				public shared TIV_DESCRIPCION As string = "TIV_DESCRIPCION"
				public shared TIV_DIAS As string = "TIV_DIAS"
				public shared TIV_COMPORTAMIENTO As string = "TIV_COMPORTAMIENTO"
				public shared TIV_FORMA_VENTA As string = "TIV_FORMA_VENTA"
				public shared USU_ID As string = "USU_ID"
				public shared TIV_FEC_GRAB As string = "TIV_FEC_GRAB"
				public shared TIV_ESTADO As string = "TIV_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property TIV_ID() As String
        Get
            Return _tIV_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIV_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TIV_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tIV_ID = value
                OnPropertyChanged("TIV_ID")
            End If
        End Set
    End Property

    Private _tIV_ID As String

    <DataMember()>
    Public Property TIV_DESCRIPCION() As String
        Get
            Return _tIV_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIV_DESCRIPCION, value) Then
                _tIV_DESCRIPCION = value
                OnPropertyChanged("TIV_DESCRIPCION")
            End If
        End Set
    End Property

    Private _tIV_DESCRIPCION As String

    <DataMember()>
    Public Property TIV_DIAS() As Short
        Get
            Return _tIV_DIAS
        End Get
        Set(ByVal value As Short)
            If Not Equals(_tIV_DIAS, value) Then
                _tIV_DIAS = value
                OnPropertyChanged("TIV_DIAS")
            End If
        End Set
    End Property

    Private _tIV_DIAS As Short

    <DataMember()>
    Public Property TIV_COMPORTAMIENTO() As Short
        Get
            Return _tIV_COMPORTAMIENTO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_tIV_COMPORTAMIENTO, value) Then
                _tIV_COMPORTAMIENTO = value
                OnPropertyChanged("TIV_COMPORTAMIENTO")
            End If
        End Set
    End Property

    Private _tIV_COMPORTAMIENTO As Short

    <DataMember()>
    Public Property TIV_FORMA_VENTA() As Short
        Get
            Return _tIV_FORMA_VENTA
        End Get
        Set(ByVal value As Short)
            If Not Equals(_tIV_FORMA_VENTA, value) Then
                _tIV_FORMA_VENTA = value
                OnPropertyChanged("TIV_FORMA_VENTA")
            End If
        End Set
    End Property

    Private _tIV_FORMA_VENTA As Short

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                ChangeTracker.RecordOriginalValue("USU_ID", _uSU_ID)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property TIV_FEC_GRAB() As Date
        Get
            Return _tIV_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_tIV_FEC_GRAB, value) Then
                _tIV_FEC_GRAB = value
                OnPropertyChanged("TIV_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tIV_FEC_GRAB As Date

    <DataMember()>
    Public Property TIV_ESTADO() As Boolean
        Get
            Return _tIV_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tIV_ESTADO, value) Then
                _tIV_ESTADO = value
                OnPropertyChanged("TIV_ESTADO")
            End If
        End Set
    End Property

    Private _tIV_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DescuentoIncrementoTipoVentaPersonas() As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)
        Get
            If _descuentoIncrementoTipoVentaPersonas Is Nothing Then
                _descuentoIncrementoTipoVentaPersonas = New TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)
                AddHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
            End If
            Return _descuentoIncrementoTipoVentaPersonas
        End Get
        Set(ByVal value As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas))
            If Not Object.ReferenceEquals(_descuentoIncrementoTipoVentaPersonas, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _descuentoIncrementoTipoVentaPersonas IsNot Nothing Then
                    RemoveHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
                End If
                _descuentoIncrementoTipoVentaPersonas = value
                If _descuentoIncrementoTipoVentaPersonas IsNot Nothing Then
                    AddHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
                End If
                OnNavigationPropertyChanged("DescuentoIncrementoTipoVentaPersonas")
            End If
        End Set
    End Property

    Private _descuentoIncrementoTipoVentaPersonas As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)

    <DataMember()>
    Public Property Usuarios() As Usuarios
        Get
            Return _usuarios
        End Get
        Set(ByVal value As Usuarios)
            If _usuarios IsNot value Then
                Dim previousValue As Usuarios = _usuarios
                _usuarios = value
                FixupUsuarios(previousValue)
                OnNavigationPropertyChanged("Usuarios")
            End If
        End Set
    End Property

    Private _usuarios As Usuarios


    <DataMember()>
    Public Property SolicitudCompra() As TrackableCollection(Of SolicitudCompra)
        Get
            If _solicitudCompra Is Nothing Then
                _solicitudCompra = New TrackableCollection(Of SolicitudCompra)
                AddHandler _solicitudCompra.CollectionChanged, AddressOf FixupSolicitudCompra
            End If
            Return _solicitudCompra
        End Get
        Set(ByVal value As TrackableCollection(Of SolicitudCompra))
            If Not Object.ReferenceEquals(_solicitudCompra, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _solicitudCompra IsNot Nothing Then
                    RemoveHandler _solicitudCompra.CollectionChanged, AddressOf FixupSolicitudCompra
                End If
                _solicitudCompra = value
                If _solicitudCompra IsNot Nothing Then
                    AddHandler _solicitudCompra.CollectionChanged, AddressOf FixupSolicitudCompra
                End If
                OnNavigationPropertyChanged("SolicitudCompra")
            End If
        End Set
    End Property

    Private _solicitudCompra As TrackableCollection(Of SolicitudCompra)

    <DataMember()>
    Public Property Documentos() As TrackableCollection(Of Documentos)
        Get
            If _documentos Is Nothing Then
                _documentos = New TrackableCollection(Of Documentos)
                AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
            End If
            Return _documentos
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos IsNot Nothing Then
                    RemoveHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                _documentos = value
                If _documentos IsNot Nothing Then
                    AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                OnNavigationPropertyChanged("Documentos")
            End If
        End Set
    End Property

    Private _documentos As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property ProvisionCompras() As TrackableCollection(Of ProvisionCompras)
        Get
            If _provisionCompras Is Nothing Then
                _provisionCompras = New TrackableCollection(Of ProvisionCompras)
                AddHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
            End If
            Return _provisionCompras
        End Get
        Set(ByVal value As TrackableCollection(Of ProvisionCompras))
            If Not Object.ReferenceEquals(_provisionCompras, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _provisionCompras IsNot Nothing Then
                    RemoveHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
                End If
                _provisionCompras = value
                If _provisionCompras IsNot Nothing Then
                    AddHandler _provisionCompras.CollectionChanged, AddressOf FixupProvisionCompras
                End If
                OnNavigationPropertyChanged("ProvisionCompras")
            End If
        End Set
    End Property

    Private _provisionCompras As TrackableCollection(Of ProvisionCompras)

    <DataMember()>
    Public Property OrdenServicio() As TrackableCollection(Of OrdenServicio)
        Get
            If _ordenServicio Is Nothing Then
                _ordenServicio = New TrackableCollection(Of OrdenServicio)
                AddHandler _ordenServicio.CollectionChanged, AddressOf FixupOrdenServicio
            End If
            Return _ordenServicio
        End Get
        Set(ByVal value As TrackableCollection(Of OrdenServicio))
            If Not Object.ReferenceEquals(_ordenServicio, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _ordenServicio IsNot Nothing Then
                    RemoveHandler _ordenServicio.CollectionChanged, AddressOf FixupOrdenServicio
                End If
                _ordenServicio = value
                If _ordenServicio IsNot Nothing Then
                    AddHandler _ordenServicio.CollectionChanged, AddressOf FixupOrdenServicio
                End If
                OnNavigationPropertyChanged("OrdenServicio")
            End If
        End Set
    End Property

    Private _ordenServicio As TrackableCollection(Of OrdenServicio)

    <DataMember()>
    Public Property OrdenCompra() As TrackableCollection(Of OrdenCompra)
        Get
            If _ordenCompra Is Nothing Then
                _ordenCompra = New TrackableCollection(Of OrdenCompra)
                AddHandler _ordenCompra.CollectionChanged, AddressOf FixupOrdenCompra
            End If
            Return _ordenCompra
        End Get
        Set(ByVal value As TrackableCollection(Of OrdenCompra))
            If Not Object.ReferenceEquals(_ordenCompra, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _ordenCompra IsNot Nothing Then
                    RemoveHandler _ordenCompra.CollectionChanged, AddressOf FixupOrdenCompra
                End If
                _ordenCompra = value
                If _ordenCompra IsNot Nothing Then
                    AddHandler _ordenCompra.CollectionChanged, AddressOf FixupOrdenCompra
                End If
                OnNavigationPropertyChanged("OrdenCompra")
            End If
        End Set
    End Property

    Private _ordenCompra As TrackableCollection(Of OrdenCompra)

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
        DescuentoIncrementoTipoVentaPersonas.Clear()
        Usuarios = Nothing
        SolicitudCompra.Clear()
        Documentos.Clear()
        ProvisionCompras.Clear()
        OrdenServicio.Clear()
        OrdenCompra.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            USU_ID = Usuarios.USU_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Usuarios") AndAlso
                ChangeTracker.OriginalValues("Usuarios") Is Usuarios Then
                ChangeTracker.OriginalValues.Remove("Usuarios")
            Else
                ChangeTracker.RecordOriginalValue("Usuarios", previousValue)
            End If
            If Usuarios IsNot Nothing AndAlso Not Usuarios.ChangeTracker.ChangeTrackingEnabled Then
                Usuarios.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDescuentoIncrementoTipoVentaPersonas(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DescuentoIncrementoTipoVentaPersonas In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DescuentoIncrementoTipoVentaPersonas", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DescuentoIncrementoTipoVentaPersonas In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DescuentoIncrementoTipoVentaPersonas", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupSolicitudCompra(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As SolicitudCompra In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("SolicitudCompra", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As SolicitudCompra In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("SolicitudCompra", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupProvisionCompras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ProvisionCompras In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ProvisionCompras", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ProvisionCompras In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ProvisionCompras", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupOrdenServicio(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As OrdenServicio In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("OrdenServicio", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As OrdenServicio In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("OrdenServicio", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupOrdenCompra(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As OrdenCompra In e.NewItems
                item.TipoVenta = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("OrdenCompra", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As OrdenCompra In e.OldItems
                If ReferenceEquals(item.TipoVenta, Me) Then
                    item.TipoVenta = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("OrdenCompra", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
