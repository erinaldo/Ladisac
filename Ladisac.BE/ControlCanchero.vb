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
<KnownType(GetType(ControlCancheroDetalle))>
<KnownType(GetType(Produccion))>
<KnownType(GetType(Personas))>
Partial Public Class ControlCanchero
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CCA_ID As string = "CCA_ID"
				public shared PRO_ID As string = "PRO_ID"
				public shared CCA_TOTAL As string = "CCA_TOTAL"
				public shared CCA_CANTIDAD_TABLA As string = "CCA_CANTIDAD_TABLA"
				public shared CCA_FECHA As string = "CCA_FECHA"
				public shared USU_ID As string = "USU_ID"
				public shared CCA_FEC_GRAB As string = "CCA_FEC_GRAB"
				public shared CCA_ESTADO As string = "CCA_ESTADO"
				public shared PER_ID_OPERADOR As string = "PER_ID_OPERADOR"
		    End Structure
	



    <DataMember()>
    Public Property CCA_ID() As Integer
        Get
            Return _cCA_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cCA_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CCA_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cCA_ID = value
                OnPropertyChanged("CCA_ID")
            End If
        End Set
    End Property

    Private _cCA_ID As Integer

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

    <DataMember()>
    Public Property CCA_TOTAL() As Nullable(Of Integer)
        Get
            Return _cCA_TOTAL
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cCA_TOTAL, value) Then
                _cCA_TOTAL = value
                OnPropertyChanged("CCA_TOTAL")
            End If
        End Set
    End Property

    Private _cCA_TOTAL As Nullable(Of Integer)

    <DataMember()>
    Public Property CCA_CANTIDAD_TABLA() As Nullable(Of Integer)
        Get
            Return _cCA_CANTIDAD_TABLA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cCA_CANTIDAD_TABLA, value) Then
                _cCA_CANTIDAD_TABLA = value
                OnPropertyChanged("CCA_CANTIDAD_TABLA")
            End If
        End Set
    End Property

    Private _cCA_CANTIDAD_TABLA As Nullable(Of Integer)

    <DataMember()>
    Public Property CCA_FECHA() As Nullable(Of Date)
        Get
            Return _cCA_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_cCA_FECHA, value) Then
                _cCA_FECHA = value
                OnPropertyChanged("CCA_FECHA")
            End If
        End Set
    End Property

    Private _cCA_FECHA As Nullable(Of Date)

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
    Public Property CCA_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _cCA_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_cCA_FEC_GRAB, value) Then
                _cCA_FEC_GRAB = value
                OnPropertyChanged("CCA_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cCA_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property CCA_ESTADO() As Nullable(Of Boolean)
        Get
            Return _cCA_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_cCA_ESTADO, value) Then
                _cCA_ESTADO = value
                OnPropertyChanged("CCA_ESTADO")
            End If
        End Set
    End Property

    Private _cCA_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property PER_ID_OPERADOR() As String
        Get
            Return _pER_ID_OPERADOR
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_OPERADOR, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_OPERADOR", _pER_ID_OPERADOR)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_OPERADOR = value
                OnPropertyChanged("PER_ID_OPERADOR")
            End If
        End Set
    End Property

    Private _pER_ID_OPERADOR As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ControlCancheroDetalle() As TrackableCollection(Of ControlCancheroDetalle)
        Get
            If _controlCancheroDetalle Is Nothing Then
                _controlCancheroDetalle = New TrackableCollection(Of ControlCancheroDetalle)
                AddHandler _controlCancheroDetalle.CollectionChanged, AddressOf FixupControlCancheroDetalle
            End If
            Return _controlCancheroDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of ControlCancheroDetalle))
            If Not Object.ReferenceEquals(_controlCancheroDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _controlCancheroDetalle IsNot Nothing Then
                    RemoveHandler _controlCancheroDetalle.CollectionChanged, AddressOf FixupControlCancheroDetalle
                End If
                _controlCancheroDetalle = value
                If _controlCancheroDetalle IsNot Nothing Then
                    AddHandler _controlCancheroDetalle.CollectionChanged, AddressOf FixupControlCancheroDetalle
                End If
                OnNavigationPropertyChanged("ControlCancheroDetalle")
            End If
        End Set
    End Property

    Private _controlCancheroDetalle As TrackableCollection(Of ControlCancheroDetalle)

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
        ControlCancheroDetalle.Clear()
        Produccion = Nothing
        Personas = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

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

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_OPERADOR = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_OPERADOR = Nothing
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

    Private Sub FixupControlCancheroDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ControlCancheroDetalle In e.NewItems
                item.CCA_ID = CCA_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ControlCancheroDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ControlCancheroDetalle In e.OldItems
                item.CCA_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ControlCancheroDetalle", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class