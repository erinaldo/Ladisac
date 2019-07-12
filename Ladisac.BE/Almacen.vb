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
<KnownType(GetType(Distrito))>
<KnownType(GetType(Personas))>
<KnownType(GetType(Inventario))>
<KnownType(GetType(OrdenDespachoDetalle))>
<KnownType(GetType(Cancha))>
<KnownType(GetType(Secadero))>
Partial Public Class Almacen
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared ALM_ID As string = "ALM_ID"
				public shared ALM_ID_PADRE As string = "ALM_ID_PADRE"
				public shared ALM_DESCRIPCION As string = "ALM_DESCRIPCION"
				public shared DIS_ID As string = "DIS_ID"
				public shared ALM_DIRECCION As string = "ALM_DIRECCION"
				public shared ALM_TELEFONOS As string = "ALM_TELEFONOS"
				public shared USU_ID As string = "USU_ID"
				public shared ALM_FEC_GRAB As string = "ALM_FEC_GRAB"
				public shared ALM_ESTADO As string = "ALM_ESTADO"
				public shared PER_ID_RESPONSABLE As string = "PER_ID_RESPONSABLE"
				public shared Almacen1 As string = "Almacen1"
				public shared ENO_ID As string = "ENO_ID"
		    End Structure
	



    <DataMember()>
    Public Property ALM_ID() As Integer
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_aLM_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ALM_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _aLM_ID = value
                OnPropertyChanged("ALM_ID")
            End If
        End Set
    End Property

    Private _aLM_ID As Integer

    <DataMember()>
    Public Property ALM_ID_PADRE() As Nullable(Of Integer)
        Get
            Return _aLM_ID_PADRE
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID_PADRE, value) Then
                _aLM_ID_PADRE = value
                OnPropertyChanged("ALM_ID_PADRE")
            End If
        End Set
    End Property

    Private _aLM_ID_PADRE As Nullable(Of Integer)

    <DataMember()>
    Public Property ALM_DESCRIPCION() As String
        Get
            Return _aLM_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_aLM_DESCRIPCION, value) Then
                _aLM_DESCRIPCION = value
                OnPropertyChanged("ALM_DESCRIPCION")
            End If
        End Set
    End Property

    Private _aLM_DESCRIPCION As String

    <DataMember()>
    Public Property DIS_ID() As String
        Get
            Return _dIS_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dIS_ID, value) Then
                ChangeTracker.RecordOriginalValue("DIS_ID", _dIS_ID)
                If Not IsDeserializing Then
                    If Distrito IsNot Nothing AndAlso Not Equals(Distrito.DIS_ID, value) Then
                        Distrito = Nothing
                    End If
                End If
                _dIS_ID = value
                OnPropertyChanged("DIS_ID")
            End If
        End Set
    End Property

    Private _dIS_ID As String

    <DataMember()>
    Public Property ALM_DIRECCION() As String
        Get
            Return _aLM_DIRECCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_aLM_DIRECCION, value) Then
                _aLM_DIRECCION = value
                OnPropertyChanged("ALM_DIRECCION")
            End If
        End Set
    End Property

    Private _aLM_DIRECCION As String

    <DataMember()>
    Public Property ALM_TELEFONOS() As String
        Get
            Return _aLM_TELEFONOS
        End Get
        Set(ByVal value As String)
            If Not Equals(_aLM_TELEFONOS, value) Then
                _aLM_TELEFONOS = value
                OnPropertyChanged("ALM_TELEFONOS")
            End If
        End Set
    End Property

    Private _aLM_TELEFONOS As String

    <DataMember()>
    Public Property USU_ID() As String
        Get
            Return _uSU_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uSU_ID, value) Then
                ChangeTracker.RecordOriginalValue("USU_ID", _uSU_ID)
                _uSU_ID = value
                OnPropertyChanged("USU_ID")
            End If
        End Set
    End Property

    Private _uSU_ID As String

    <DataMember()>
    Public Property ALM_FEC_GRAB() As Date
        Get
            Return _aLM_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_aLM_FEC_GRAB, value) Then
                _aLM_FEC_GRAB = value
                OnPropertyChanged("ALM_FEC_GRAB")
            End If
        End Set
    End Property

    Private _aLM_FEC_GRAB As Date

    <DataMember()>
    Public Property ALM_ESTADO() As Boolean
        Get
            Return _aLM_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_aLM_ESTADO, value) Then
                _aLM_ESTADO = value
                OnPropertyChanged("ALM_ESTADO")
            End If
        End Set
    End Property

    Private _aLM_ESTADO As Boolean

    <DataMember()>
    Public Property PER_ID_RESPONSABLE() As String
        Get
            Return _pER_ID_RESPONSABLE
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_RESPONSABLE, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_RESPONSABLE", _pER_ID_RESPONSABLE)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_RESPONSABLE = value
                OnPropertyChanged("PER_ID_RESPONSABLE")
            End If
        End Set
    End Property

    Private _pER_ID_RESPONSABLE As String

    <DataMember()>
    Public Property Almacen1() As String
        Get
            Return _almacen1
        End Get
        Set(ByVal value As String)
            If Not Equals(_almacen1, value) Then
                _almacen1 = value
                OnPropertyChanged("Almacen1")
            End If
        End Set
    End Property

    Private _almacen1 As String

    <DataMember()>
    Public Property ENO_ID() As Nullable(Of Integer)
        Get
            Return _eNO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID, value) Then
                _eNO_ID = value
                OnPropertyChanged("ENO_ID")
            End If
        End Set
    End Property

    Private _eNO_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Distrito() As Distrito
        Get
            Return _distrito
        End Get
        Set(ByVal value As Distrito)
            If _distrito IsNot value Then
                Dim previousValue As Distrito = _distrito
                _distrito = value
                FixupDistrito(previousValue)
                OnNavigationPropertyChanged("Distrito")
            End If
        End Set
    End Property

    Private _distrito As Distrito


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
    Public Property Inventario() As TrackableCollection(Of Inventario)
        Get
            If _inventario Is Nothing Then
                _inventario = New TrackableCollection(Of Inventario)
                AddHandler _inventario.CollectionChanged, AddressOf FixupInventario
            End If
            Return _inventario
        End Get
        Set(ByVal value As TrackableCollection(Of Inventario))
            If Not Object.ReferenceEquals(_inventario, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _inventario IsNot Nothing Then
                    RemoveHandler _inventario.CollectionChanged, AddressOf FixupInventario
                End If
                _inventario = value
                If _inventario IsNot Nothing Then
                    AddHandler _inventario.CollectionChanged, AddressOf FixupInventario
                End If
                OnNavigationPropertyChanged("Inventario")
            End If
        End Set
    End Property

    Private _inventario As TrackableCollection(Of Inventario)

    <DataMember()>
    Public Property OrdenDespachoDetalle() As TrackableCollection(Of OrdenDespachoDetalle)
        Get
            If _ordenDespachoDetalle Is Nothing Then
                _ordenDespachoDetalle = New TrackableCollection(Of OrdenDespachoDetalle)
                AddHandler _ordenDespachoDetalle.CollectionChanged, AddressOf FixupOrdenDespachoDetalle
            End If
            Return _ordenDespachoDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of OrdenDespachoDetalle))
            If Not Object.ReferenceEquals(_ordenDespachoDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _ordenDespachoDetalle IsNot Nothing Then
                    RemoveHandler _ordenDespachoDetalle.CollectionChanged, AddressOf FixupOrdenDespachoDetalle
                End If
                _ordenDespachoDetalle = value
                If _ordenDespachoDetalle IsNot Nothing Then
                    AddHandler _ordenDespachoDetalle.CollectionChanged, AddressOf FixupOrdenDespachoDetalle
                End If
                OnNavigationPropertyChanged("OrdenDespachoDetalle")
            End If
        End Set
    End Property

    Private _ordenDespachoDetalle As TrackableCollection(Of OrdenDespachoDetalle)

    <DataMember()>
    Public Property Cancha() As TrackableCollection(Of Cancha)
        Get
            If _cancha Is Nothing Then
                _cancha = New TrackableCollection(Of Cancha)
                AddHandler _cancha.CollectionChanged, AddressOf FixupCancha
            End If
            Return _cancha
        End Get
        Set(ByVal value As TrackableCollection(Of Cancha))
            If Not Object.ReferenceEquals(_cancha, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _cancha IsNot Nothing Then
                    RemoveHandler _cancha.CollectionChanged, AddressOf FixupCancha
                End If
                _cancha = value
                If _cancha IsNot Nothing Then
                    AddHandler _cancha.CollectionChanged, AddressOf FixupCancha
                End If
                OnNavigationPropertyChanged("Cancha")
            End If
        End Set
    End Property

    Private _cancha As TrackableCollection(Of Cancha)

    <DataMember()>
    Public Property Secadero() As TrackableCollection(Of Secadero)
        Get
            If _secadero Is Nothing Then
                _secadero = New TrackableCollection(Of Secadero)
                AddHandler _secadero.CollectionChanged, AddressOf FixupSecadero
            End If
            Return _secadero
        End Get
        Set(ByVal value As TrackableCollection(Of Secadero))
            If Not Object.ReferenceEquals(_secadero, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _secadero IsNot Nothing Then
                    RemoveHandler _secadero.CollectionChanged, AddressOf FixupSecadero
                End If
                _secadero = value
                If _secadero IsNot Nothing Then
                    AddHandler _secadero.CollectionChanged, AddressOf FixupSecadero
                End If
                OnNavigationPropertyChanged("Secadero")
            End If
        End Set
    End Property

    Private _secadero As TrackableCollection(Of Secadero)

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
        Distrito = Nothing
        Personas = Nothing
        Inventario.Clear()
        OrdenDespachoDetalle.Clear()
        Cancha.Clear()
        Secadero.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDistrito(ByVal previousValue As Distrito)
        If IsDeserializing Then
            Return
        End If

        If Distrito IsNot Nothing Then
            DIS_ID = Distrito.DIS_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Distrito") AndAlso
                ChangeTracker.OriginalValues("Distrito") Is Distrito Then
                ChangeTracker.OriginalValues.Remove("Distrito")
            Else
                ChangeTracker.RecordOriginalValue("Distrito", previousValue)
            End If
            If Distrito IsNot Nothing AndAlso Not Distrito.ChangeTracker.ChangeTrackingEnabled Then
                Distrito.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_RESPONSABLE = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_RESPONSABLE = Nothing
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

    Private Sub FixupInventario(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Inventario In e.NewItems
                item.Almacen = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Inventario", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Inventario In e.OldItems
                If ReferenceEquals(item.Almacen, Me) Then
                    item.Almacen = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Inventario", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupOrdenDespachoDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As OrdenDespachoDetalle In e.NewItems
                item.Almacen = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("OrdenDespachoDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As OrdenDespachoDetalle In e.OldItems
                If ReferenceEquals(item.Almacen, Me) Then
                    item.Almacen = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("OrdenDespachoDetalle", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupCancha(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Cancha In e.NewItems
                item.Almacen = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Cancha", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Cancha In e.OldItems
                If ReferenceEquals(item.Almacen, Me) Then
                    item.Almacen = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Cancha", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupSecadero(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Secadero In e.NewItems
                item.Almacen = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Secadero", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Secadero In e.OldItems
                If ReferenceEquals(item.Almacen, Me) Then
                    item.Almacen = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Secadero", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
