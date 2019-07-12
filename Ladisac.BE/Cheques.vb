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
<KnownType(GetType(CajaCtaCte))>
<KnownType(GetType(MedioPagoTesoreria))>
Partial Public Class Cheques
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CHE_ID As string = "CHE_ID"
				public shared CCC_ID As string = "CCC_ID"
				public shared CHE_INICIO As string = "CHE_INICIO"
				public shared CHE_FIN As string = "CHE_FIN"
				public shared CHE_CORRELATIVO As string = "CHE_CORRELATIVO"
				public shared CHE_TIPO As string = "CHE_TIPO"
				public shared CHE_FORMA_GIRO As string = "CHE_FORMA_GIRO"
				public shared USU_ID As string = "USU_ID"
				public shared CHE_FEC_GRAB As string = "CHE_FEC_GRAB"
				public shared CHE_ESTADO As string = "CHE_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property CHE_ID() As String
        Get
            Return _cHE_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cHE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CHE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cHE_ID = value
                OnPropertyChanged("CHE_ID")
            End If
        End Set
    End Property

    Private _cHE_ID As String

    <DataMember()>
    Public Property CCC_ID() As String
        Get
            Return _cCC_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCC_ID, value) Then
                ChangeTracker.RecordOriginalValue("CCC_ID", _cCC_ID)
                If Not IsDeserializing Then
                    If CajaCtaCte IsNot Nothing AndAlso Not Equals(CajaCtaCte.CCC_ID, value) Then
                        CajaCtaCte = Nothing
                    End If
                End If
                _cCC_ID = value
                OnPropertyChanged("CCC_ID")
            End If
        End Set
    End Property

    Private _cCC_ID As String

    <DataMember()>
    Public Property CHE_INICIO() As Integer
        Get
            Return _cHE_INICIO
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cHE_INICIO, value) Then
                _cHE_INICIO = value
                OnPropertyChanged("CHE_INICIO")
            End If
        End Set
    End Property

    Private _cHE_INICIO As Integer

    <DataMember()>
    Public Property CHE_FIN() As Integer
        Get
            Return _cHE_FIN
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cHE_FIN, value) Then
                _cHE_FIN = value
                OnPropertyChanged("CHE_FIN")
            End If
        End Set
    End Property

    Private _cHE_FIN As Integer

    <DataMember()>
    Public Property CHE_CORRELATIVO() As Integer
        Get
            Return _cHE_CORRELATIVO
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cHE_CORRELATIVO, value) Then
                _cHE_CORRELATIVO = value
                OnPropertyChanged("CHE_CORRELATIVO")
            End If
        End Set
    End Property

    Private _cHE_CORRELATIVO As Integer

    <DataMember()>
    Public Property CHE_TIPO() As Short
        Get
            Return _cHE_TIPO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_cHE_TIPO, value) Then
                _cHE_TIPO = value
                OnPropertyChanged("CHE_TIPO")
            End If
        End Set
    End Property

    Private _cHE_TIPO As Short

    <DataMember()>
    Public Property CHE_FORMA_GIRO() As Short
        Get
            Return _cHE_FORMA_GIRO
        End Get
        Set(ByVal value As Short)
            If Not Equals(_cHE_FORMA_GIRO, value) Then
                _cHE_FORMA_GIRO = value
                OnPropertyChanged("CHE_FORMA_GIRO")
            End If
        End Set
    End Property

    Private _cHE_FORMA_GIRO As Short

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
    Public Property CHE_FEC_GRAB() As Date
        Get
            Return _cHE_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_cHE_FEC_GRAB, value) Then
                _cHE_FEC_GRAB = value
                OnPropertyChanged("CHE_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cHE_FEC_GRAB As Date

    <DataMember()>
    Public Property CHE_ESTADO() As Boolean
        Get
            Return _cHE_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_cHE_ESTADO, value) Then
                _cHE_ESTADO = value
                OnPropertyChanged("CHE_ESTADO")
            End If
        End Set
    End Property

    Private _cHE_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property CajaCtaCte() As CajaCtaCte
        Get
            Return _cajaCtaCte
        End Get
        Set(ByVal value As CajaCtaCte)
            If _cajaCtaCte IsNot value Then
                Dim previousValue As CajaCtaCte = _cajaCtaCte
                _cajaCtaCte = value
                FixupCajaCtaCte(previousValue)
                OnNavigationPropertyChanged("CajaCtaCte")
            End If
        End Set
    End Property

    Private _cajaCtaCte As CajaCtaCte


    <DataMember()>
    Public Property MedioPagoTesoreria() As TrackableCollection(Of MedioPagoTesoreria)
        Get
            If _medioPagoTesoreria Is Nothing Then
                _medioPagoTesoreria = New TrackableCollection(Of MedioPagoTesoreria)
                AddHandler _medioPagoTesoreria.CollectionChanged, AddressOf FixupMedioPagoTesoreria
            End If
            Return _medioPagoTesoreria
        End Get
        Set(ByVal value As TrackableCollection(Of MedioPagoTesoreria))
            If Not Object.ReferenceEquals(_medioPagoTesoreria, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _medioPagoTesoreria IsNot Nothing Then
                    RemoveHandler _medioPagoTesoreria.CollectionChanged, AddressOf FixupMedioPagoTesoreria
                End If
                _medioPagoTesoreria = value
                If _medioPagoTesoreria IsNot Nothing Then
                    AddHandler _medioPagoTesoreria.CollectionChanged, AddressOf FixupMedioPagoTesoreria
                End If
                OnNavigationPropertyChanged("MedioPagoTesoreria")
            End If
        End Set
    End Property

    Private _medioPagoTesoreria As TrackableCollection(Of MedioPagoTesoreria)

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
        CajaCtaCte = Nothing
        MedioPagoTesoreria.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupCajaCtaCte(ByVal previousValue As CajaCtaCte)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Cheques.Contains(Me) Then
            previousValue.Cheques.Remove(Me)
        End If

        If CajaCtaCte IsNot Nothing Then
            If Not CajaCtaCte.Cheques.Contains(Me) Then
                CajaCtaCte.Cheques.Add(Me)
            End If

            CCC_ID = CajaCtaCte.CCC_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CajaCtaCte") AndAlso
                ChangeTracker.OriginalValues("CajaCtaCte") Is CajaCtaCte Then
                ChangeTracker.OriginalValues.Remove("CajaCtaCte")
            Else
                ChangeTracker.RecordOriginalValue("CajaCtaCte", previousValue)
            End If
            If CajaCtaCte IsNot Nothing AndAlso Not CajaCtaCte.ChangeTracker.ChangeTrackingEnabled Then
                CajaCtaCte.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupMedioPagoTesoreria(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As MedioPagoTesoreria In e.NewItems
                item.Cheques = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("MedioPagoTesoreria", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As MedioPagoTesoreria In e.OldItems
                If ReferenceEquals(item.Cheques, Me) Then
                    item.Cheques = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("MedioPagoTesoreria", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
