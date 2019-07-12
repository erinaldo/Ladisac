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
<KnownType(GetType(PlanMantto))>
Partial Public Class TipoMantto
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TMO_ID As string = "TMO_ID"
				public shared TMO_DESCRIPCION As string = "TMO_DESCRIPCION"
				public shared USU_ID As string = "USU_ID"
				public shared TMO_FEC_GRAB As string = "TMO_FEC_GRAB"
				public shared TMO_ESTADO As string = "TMO_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property TMO_ID() As Integer
        Get
            Return _tMO_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_tMO_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TMO_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tMO_ID = value
                OnPropertyChanged("TMO_ID")
            End If
        End Set
    End Property

    Private _tMO_ID As Integer

    <DataMember()>
    Public Property TMO_DESCRIPCION() As String
        Get
            Return _tMO_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tMO_DESCRIPCION, value) Then
                _tMO_DESCRIPCION = value
                OnPropertyChanged("TMO_DESCRIPCION")
            End If
        End Set
    End Property

    Private _tMO_DESCRIPCION As String

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
    Public Property TMO_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _tMO_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_tMO_FEC_GRAB, value) Then
                _tMO_FEC_GRAB = value
                OnPropertyChanged("TMO_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tMO_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property TMO_ESTADO() As Nullable(Of Boolean)
        Get
            Return _tMO_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_tMO_ESTADO, value) Then
                _tMO_ESTADO = value
                OnPropertyChanged("TMO_ESTADO")
            End If
        End Set
    End Property

    Private _tMO_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property PlanMantto() As TrackableCollection(Of PlanMantto)
        Get
            If _planMantto Is Nothing Then
                _planMantto = New TrackableCollection(Of PlanMantto)
                AddHandler _planMantto.CollectionChanged, AddressOf FixupPlanMantto
            End If
            Return _planMantto
        End Get
        Set(ByVal value As TrackableCollection(Of PlanMantto))
            If Not Object.ReferenceEquals(_planMantto, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _planMantto IsNot Nothing Then
                    RemoveHandler _planMantto.CollectionChanged, AddressOf FixupPlanMantto
                End If
                _planMantto = value
                If _planMantto IsNot Nothing Then
                    AddHandler _planMantto.CollectionChanged, AddressOf FixupPlanMantto
                End If
                OnNavigationPropertyChanged("PlanMantto")
            End If
        End Set
    End Property

    Private _planMantto As TrackableCollection(Of PlanMantto)

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
        PlanMantto.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPlanMantto(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As PlanMantto In e.NewItems
                item.TipoMantto = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("PlanMantto", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As PlanMantto In e.OldItems
                If ReferenceEquals(item.TipoMantto, Me) Then
                    item.TipoMantto = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("PlanMantto", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
