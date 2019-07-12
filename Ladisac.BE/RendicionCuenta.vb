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
<KnownType(GetType(RendicionCuentaDetalle))>
<KnownType(GetType(DocuMovimiento))>
Partial Public Class RendicionCuenta
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared REC_ID As string = "REC_ID"
				public shared REC_FECHA As string = "REC_FECHA"
				public shared REC_OBSERVACION As string = "REC_OBSERVACION"
				public shared USU_ID As string = "USU_ID"
				public shared REC_FEC_GRAB As string = "REC_FEC_GRAB"
				public shared REC_ESTADO As string = "REC_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property REC_ID() As Integer
        Get
            Return _rEC_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_rEC_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'REC_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _rEC_ID = value
                OnPropertyChanged("REC_ID")
            End If
        End Set
    End Property

    Private _rEC_ID As Integer

    <DataMember()>
    Public Property REC_FECHA() As Nullable(Of Date)
        Get
            Return _rEC_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_rEC_FECHA, value) Then
                _rEC_FECHA = value
                OnPropertyChanged("REC_FECHA")
            End If
        End Set
    End Property

    Private _rEC_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property REC_OBSERVACION() As String
        Get
            Return _rEC_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_rEC_OBSERVACION, value) Then
                _rEC_OBSERVACION = value
                OnPropertyChanged("REC_OBSERVACION")
            End If
        End Set
    End Property

    Private _rEC_OBSERVACION As String

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
    Public Property REC_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _rEC_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_rEC_FEC_GRAB, value) Then
                _rEC_FEC_GRAB = value
                OnPropertyChanged("REC_FEC_GRAB")
            End If
        End Set
    End Property

    Private _rEC_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property REC_ESTADO() As Nullable(Of Boolean)
        Get
            Return _rEC_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_rEC_ESTADO, value) Then
                _rEC_ESTADO = value
                OnPropertyChanged("REC_ESTADO")
            End If
        End Set
    End Property

    Private _rEC_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property RendicionCuentaDetalle() As TrackableCollection(Of RendicionCuentaDetalle)
        Get
            If _rendicionCuentaDetalle Is Nothing Then
                _rendicionCuentaDetalle = New TrackableCollection(Of RendicionCuentaDetalle)
                AddHandler _rendicionCuentaDetalle.CollectionChanged, AddressOf FixupRendicionCuentaDetalle
            End If
            Return _rendicionCuentaDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of RendicionCuentaDetalle))
            If Not Object.ReferenceEquals(_rendicionCuentaDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _rendicionCuentaDetalle IsNot Nothing Then
                    RemoveHandler _rendicionCuentaDetalle.CollectionChanged, AddressOf FixupRendicionCuentaDetalle
                End If
                _rendicionCuentaDetalle = value
                If _rendicionCuentaDetalle IsNot Nothing Then
                    AddHandler _rendicionCuentaDetalle.CollectionChanged, AddressOf FixupRendicionCuentaDetalle
                End If
                OnNavigationPropertyChanged("RendicionCuentaDetalle")
            End If
        End Set
    End Property

    Private _rendicionCuentaDetalle As TrackableCollection(Of RendicionCuentaDetalle)

    <DataMember()>
    Public Property DocuMovimiento() As TrackableCollection(Of DocuMovimiento)
        Get
            If _docuMovimiento Is Nothing Then
                _docuMovimiento = New TrackableCollection(Of DocuMovimiento)
                AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
            End If
            Return _docuMovimiento
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimiento))
            If Not Object.ReferenceEquals(_docuMovimiento, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimiento IsNot Nothing Then
                    RemoveHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                _docuMovimiento = value
                If _docuMovimiento IsNot Nothing Then
                    AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                OnNavigationPropertyChanged("DocuMovimiento")
            End If
        End Set
    End Property

    Private _docuMovimiento As TrackableCollection(Of DocuMovimiento)

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
        RendicionCuentaDetalle.Clear()
        DocuMovimiento.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupRendicionCuentaDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As RendicionCuentaDetalle In e.NewItems
                item.REC_ID = REC_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("RendicionCuentaDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As RendicionCuentaDetalle In e.OldItems
                item.REC_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("RendicionCuentaDetalle", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocuMovimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.NewItems
                item.REC_ID = REC_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.OldItems
                item.REC_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
