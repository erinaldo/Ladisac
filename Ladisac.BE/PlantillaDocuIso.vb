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
<KnownType(GetType(DocuIso))>
Partial Public Class PlantillaDocuIso
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared PDI_ID As string = "PDI_ID"
				public shared PDI_ADJUNTO As string = "PDI_ADJUNTO"
				public shared PDI_NOMBRE As string = "PDI_NOMBRE"
				public shared USU_ID As string = "USU_ID"
				public shared PDI_FEC_GRAB As string = "PDI_FEC_GRAB"
				public shared PDI_ESTADO As string = "PDI_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property PDI_ID() As Integer
        Get
            Return _pDI_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_pDI_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'PDI_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _pDI_ID = value
                OnPropertyChanged("PDI_ID")
            End If
        End Set
    End Property

    Private _pDI_ID As Integer

    <DataMember()>
    Public Property PDI_ADJUNTO() As Byte()
        Get
            Return _pDI_ADJUNTO
        End Get
        Set(ByVal value As Byte())
            If _pDI_ADJUNTO IsNot value Then
                _pDI_ADJUNTO = value
                OnPropertyChanged("PDI_ADJUNTO")
            End If
        End Set
    End Property

    Private _pDI_ADJUNTO As Byte()

    <DataMember()>
    Public Property PDI_NOMBRE() As String
        Get
            Return _pDI_NOMBRE
        End Get
        Set(ByVal value As String)
            If Not Equals(_pDI_NOMBRE, value) Then
                _pDI_NOMBRE = value
                OnPropertyChanged("PDI_NOMBRE")
            End If
        End Set
    End Property

    Private _pDI_NOMBRE As String

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
    Public Property PDI_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _pDI_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_pDI_FEC_GRAB, value) Then
                _pDI_FEC_GRAB = value
                OnPropertyChanged("PDI_FEC_GRAB")
            End If
        End Set
    End Property

    Private _pDI_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property PDI_ESTADO() As Nullable(Of Boolean)
        Get
            Return _pDI_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_pDI_ESTADO, value) Then
                _pDI_ESTADO = value
                OnPropertyChanged("PDI_ESTADO")
            End If
        End Set
    End Property

    Private _pDI_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DocuIso() As TrackableCollection(Of DocuIso)
        Get
            If _docuIso Is Nothing Then
                _docuIso = New TrackableCollection(Of DocuIso)
                AddHandler _docuIso.CollectionChanged, AddressOf FixupDocuIso
            End If
            Return _docuIso
        End Get
        Set(ByVal value As TrackableCollection(Of DocuIso))
            If Not Object.ReferenceEquals(_docuIso, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuIso IsNot Nothing Then
                    RemoveHandler _docuIso.CollectionChanged, AddressOf FixupDocuIso
                End If
                _docuIso = value
                If _docuIso IsNot Nothing Then
                    AddHandler _docuIso.CollectionChanged, AddressOf FixupDocuIso
                End If
                OnNavigationPropertyChanged("DocuIso")
            End If
        End Set
    End Property

    Private _docuIso As TrackableCollection(Of DocuIso)

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
        DocuIso.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDocuIso(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuIso In e.NewItems
                item.PlantillaDocuIso = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuIso", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuIso In e.OldItems
                If ReferenceEquals(item.PlantillaDocuIso, Me) Then
                    item.PlantillaDocuIso = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuIso", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
