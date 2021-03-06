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
<KnownType(GetType(Entidad))>
<KnownType(GetType(Inspeccion))>
<KnownType(GetType(ParametroEntidad))>
<KnownType(GetType(FichaInspeccion))>
Partial Public Class EntidadInspeccion
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared EIN_ID As string = "EIN_ID"
				public shared ENO_ID As string = "ENO_ID"
				public shared INS_ID As string = "INS_ID"
				public shared USU_ID As string = "USU_ID"
				public shared EIN_FEC_GRAB As string = "EIN_FEC_GRAB"
				public shared EIN_ESTADO As string = "EIN_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property EIN_ID() As Integer
        Get
            Return _eIN_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_eIN_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'EIN_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _eIN_ID = value
                OnPropertyChanged("EIN_ID")
            End If
        End Set
    End Property

    Private _eIN_ID As Integer

    <DataMember()>
    Public Property ENO_ID() As Nullable(Of Integer)
        Get
            Return _eNO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID, value) Then
                ChangeTracker.RecordOriginalValue("ENO_ID", _eNO_ID)
                If Not IsDeserializing Then
                    If Entidad IsNot Nothing AndAlso Not Equals(Entidad.ENO_ID, value) Then
                        Entidad = Nothing
                    End If
                End If
                _eNO_ID = value
                OnPropertyChanged("ENO_ID")
            End If
        End Set
    End Property

    Private _eNO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property INS_ID() As Nullable(Of Integer)
        Get
            Return _iNS_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_iNS_ID, value) Then
                ChangeTracker.RecordOriginalValue("INS_ID", _iNS_ID)
                If Not IsDeserializing Then
                    If Inspeccion IsNot Nothing AndAlso Not Equals(Inspeccion.INS_ID, value) Then
                        Inspeccion = Nothing
                    End If
                End If
                _iNS_ID = value
                OnPropertyChanged("INS_ID")
            End If
        End Set
    End Property

    Private _iNS_ID As Nullable(Of Integer)

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
    Public Property EIN_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _eIN_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_eIN_FEC_GRAB, value) Then
                _eIN_FEC_GRAB = value
                OnPropertyChanged("EIN_FEC_GRAB")
            End If
        End Set
    End Property

    Private _eIN_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property EIN_ESTADO() As Nullable(Of Boolean)
        Get
            Return _eIN_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_eIN_ESTADO, value) Then
                _eIN_ESTADO = value
                OnPropertyChanged("EIN_ESTADO")
            End If
        End Set
    End Property

    Private _eIN_ESTADO As Nullable(Of Boolean)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Entidad() As Entidad
        Get
            Return _entidad
        End Get
        Set(ByVal value As Entidad)
            If _entidad IsNot value Then
                Dim previousValue As Entidad = _entidad
                _entidad = value
                FixupEntidad(previousValue)
                OnNavigationPropertyChanged("Entidad")
            End If
        End Set
    End Property

    Private _entidad As Entidad


    <DataMember()>
    Public Property Inspeccion() As Inspeccion
        Get
            Return _inspeccion
        End Get
        Set(ByVal value As Inspeccion)
            If _inspeccion IsNot value Then
                Dim previousValue As Inspeccion = _inspeccion
                _inspeccion = value
                FixupInspeccion(previousValue)
                OnNavigationPropertyChanged("Inspeccion")
            End If
        End Set
    End Property

    Private _inspeccion As Inspeccion


    <DataMember()>
    Public Property ParametroEntidad() As TrackableCollection(Of ParametroEntidad)
        Get
            If _parametroEntidad Is Nothing Then
                _parametroEntidad = New TrackableCollection(Of ParametroEntidad)
                AddHandler _parametroEntidad.CollectionChanged, AddressOf FixupParametroEntidad
            End If
            Return _parametroEntidad
        End Get
        Set(ByVal value As TrackableCollection(Of ParametroEntidad))
            If Not Object.ReferenceEquals(_parametroEntidad, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _parametroEntidad IsNot Nothing Then
                    RemoveHandler _parametroEntidad.CollectionChanged, AddressOf FixupParametroEntidad
                End If
                _parametroEntidad = value
                If _parametroEntidad IsNot Nothing Then
                    AddHandler _parametroEntidad.CollectionChanged, AddressOf FixupParametroEntidad
                End If
                OnNavigationPropertyChanged("ParametroEntidad")
            End If
        End Set
    End Property

    Private _parametroEntidad As TrackableCollection(Of ParametroEntidad)

    <DataMember()>
    Public Property FichaInspeccion() As TrackableCollection(Of FichaInspeccion)
        Get
            If _fichaInspeccion Is Nothing Then
                _fichaInspeccion = New TrackableCollection(Of FichaInspeccion)
                AddHandler _fichaInspeccion.CollectionChanged, AddressOf FixupFichaInspeccion
            End If
            Return _fichaInspeccion
        End Get
        Set(ByVal value As TrackableCollection(Of FichaInspeccion))
            If Not Object.ReferenceEquals(_fichaInspeccion, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _fichaInspeccion IsNot Nothing Then
                    RemoveHandler _fichaInspeccion.CollectionChanged, AddressOf FixupFichaInspeccion
                End If
                _fichaInspeccion = value
                If _fichaInspeccion IsNot Nothing Then
                    AddHandler _fichaInspeccion.CollectionChanged, AddressOf FixupFichaInspeccion
                End If
                OnNavigationPropertyChanged("FichaInspeccion")
            End If
        End Set
    End Property

    Private _fichaInspeccion As TrackableCollection(Of FichaInspeccion)

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
        Entidad = Nothing
        Inspeccion = Nothing
        ParametroEntidad.Clear()
        FichaInspeccion.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupEntidad(ByVal previousValue As Entidad, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Entidad IsNot Nothing Then
            ENO_ID = Entidad.ENO_ID
        ElseIf Not skipKeys Then
            ENO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Entidad") AndAlso
                ChangeTracker.OriginalValues("Entidad") Is Entidad Then
                ChangeTracker.OriginalValues.Remove("Entidad")
            Else
                ChangeTracker.RecordOriginalValue("Entidad", previousValue)
            End If
            If Entidad IsNot Nothing AndAlso Not Entidad.ChangeTracker.ChangeTrackingEnabled Then
                Entidad.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupInspeccion(ByVal previousValue As Inspeccion, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.EntidadInspeccion.Contains(Me) Then
            previousValue.EntidadInspeccion.Remove(Me)
        End If

        If Inspeccion IsNot Nothing Then
            If Not Inspeccion.EntidadInspeccion.Contains(Me) Then
                Inspeccion.EntidadInspeccion.Add(Me)
            End If

            INS_ID = Inspeccion.INS_ID
        ElseIf Not skipKeys Then
            INS_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Inspeccion") AndAlso
                ChangeTracker.OriginalValues("Inspeccion") Is Inspeccion Then
                ChangeTracker.OriginalValues.Remove("Inspeccion")
            Else
                ChangeTracker.RecordOriginalValue("Inspeccion", previousValue)
            End If
            If Inspeccion IsNot Nothing AndAlso Not Inspeccion.ChangeTracker.ChangeTrackingEnabled Then
                Inspeccion.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupParametroEntidad(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ParametroEntidad In e.NewItems
                item.EntidadInspeccion = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ParametroEntidad", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ParametroEntidad In e.OldItems
                If ReferenceEquals(item.EntidadInspeccion, Me) Then
                    item.EntidadInspeccion = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ParametroEntidad", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupFichaInspeccion(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As FichaInspeccion In e.NewItems
                item.EntidadInspeccion = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("FichaInspeccion", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As FichaInspeccion In e.OldItems
                If ReferenceEquals(item.EntidadInspeccion, Me) Then
                    item.EntidadInspeccion = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("FichaInspeccion", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
