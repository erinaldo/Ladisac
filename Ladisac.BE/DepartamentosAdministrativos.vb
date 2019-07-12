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
<KnownType(GetType(Asignaciones))>
<KnownType(GetType(Oficinas))>
<KnownType(GetType(Usuarios))>
Partial Public Class DepartamentosAdministrativos
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DEA_ID As string = "DEA_ID"
				public shared DEA_DESCRIPCION As string = "DEA_DESCRIPCION"
				public shared OFI_ID As string = "OFI_ID"
				public shared USU_ID As string = "USU_ID"
				public shared DEA_FEC_GRAB As string = "DEA_FEC_GRAB"
				public shared DEA_ESTADO As string = "DEA_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property DEA_ID() As String
        Get
            Return _dEA_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEA_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DEA_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dEA_ID = value
                OnPropertyChanged("DEA_ID")
            End If
        End Set
    End Property

    Private _dEA_ID As String

    <DataMember()>
    Public Property DEA_DESCRIPCION() As String
        Get
            Return _dEA_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEA_DESCRIPCION, value) Then
                _dEA_DESCRIPCION = value
                OnPropertyChanged("DEA_DESCRIPCION")
            End If
        End Set
    End Property

    Private _dEA_DESCRIPCION As String

    <DataMember()>
    Public Property OFI_ID() As String
        Get
            Return _oFI_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_oFI_ID, value) Then
                ChangeTracker.RecordOriginalValue("OFI_ID", _oFI_ID)
                If Not IsDeserializing Then
                    If Oficinas IsNot Nothing AndAlso Not Equals(Oficinas.OFI_ID, value) Then
                        Oficinas = Nothing
                    End If
                End If
                _oFI_ID = value
                OnPropertyChanged("OFI_ID")
            End If
        End Set
    End Property

    Private _oFI_ID As String

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
    Public Property DEA_FEC_GRAB() As Date
        Get
            Return _dEA_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dEA_FEC_GRAB, value) Then
                _dEA_FEC_GRAB = value
                OnPropertyChanged("DEA_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dEA_FEC_GRAB As Date

    <DataMember()>
    Public Property DEA_ESTADO() As Boolean
        Get
            Return _dEA_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dEA_ESTADO, value) Then
                _dEA_ESTADO = value
                OnPropertyChanged("DEA_ESTADO")
            End If
        End Set
    End Property

    Private _dEA_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Asignaciones() As TrackableCollection(Of Asignaciones)
        Get
            If _asignaciones Is Nothing Then
                _asignaciones = New TrackableCollection(Of Asignaciones)
                AddHandler _asignaciones.CollectionChanged, AddressOf FixupAsignaciones
            End If
            Return _asignaciones
        End Get
        Set(ByVal value As TrackableCollection(Of Asignaciones))
            If Not Object.ReferenceEquals(_asignaciones, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _asignaciones IsNot Nothing Then
                    RemoveHandler _asignaciones.CollectionChanged, AddressOf FixupAsignaciones
                End If
                _asignaciones = value
                If _asignaciones IsNot Nothing Then
                    AddHandler _asignaciones.CollectionChanged, AddressOf FixupAsignaciones
                End If
                OnNavigationPropertyChanged("Asignaciones")
            End If
        End Set
    End Property

    Private _asignaciones As TrackableCollection(Of Asignaciones)

    <DataMember()>
    Public Property Oficinas() As Oficinas
        Get
            Return _oficinas
        End Get
        Set(ByVal value As Oficinas)
            If _oficinas IsNot value Then
                Dim previousValue As Oficinas = _oficinas
                _oficinas = value
                FixupOficinas(previousValue)
                OnNavigationPropertyChanged("Oficinas")
            End If
        End Set
    End Property

    Private _oficinas As Oficinas


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
        Asignaciones.Clear()
        Oficinas = Nothing
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupOficinas(ByVal previousValue As Oficinas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DepartamentosAdministrativos.Contains(Me) Then
            previousValue.DepartamentosAdministrativos.Remove(Me)
        End If

        If Oficinas IsNot Nothing Then
            If Not Oficinas.DepartamentosAdministrativos.Contains(Me) Then
                Oficinas.DepartamentosAdministrativos.Add(Me)
            End If

            OFI_ID = Oficinas.OFI_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Oficinas") AndAlso
                ChangeTracker.OriginalValues("Oficinas") Is Oficinas Then
                ChangeTracker.OriginalValues.Remove("Oficinas")
            Else
                ChangeTracker.RecordOriginalValue("Oficinas", previousValue)
            End If
            If Oficinas IsNot Nothing AndAlso Not Oficinas.ChangeTracker.ChangeTrackingEnabled Then
                Oficinas.StartTracking()
            End If
        End If
    End Sub

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

    Private Sub FixupAsignaciones(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Asignaciones In e.NewItems
                item.DepartamentosAdministrativos = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Asignaciones", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Asignaciones In e.OldItems
                If ReferenceEquals(item.DepartamentosAdministrativos, Me) Then
                    item.DepartamentosAdministrativos = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Asignaciones", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class