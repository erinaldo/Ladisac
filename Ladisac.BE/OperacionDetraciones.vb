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
<KnownType(GetType(Usuarios))>
<KnownType(GetType(ProvisionCompras))>
Partial Public Class OperacionDetraciones
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared opd_Oper_Detra_Id As string = "opd_Oper_Detra_Id"
				public shared opd_Descripcion As string = "opd_Descripcion"
				public shared Usu_Id As string = "Usu_Id"
				public shared opd_FecGrab As string = "opd_FecGrab"
		    End Structure
	



    <DataMember()>
    Public Property opd_Oper_Detra_Id() As String
        Get
            Return _opd_Oper_Detra_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_opd_Oper_Detra_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'opd_Oper_Detra_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _opd_Oper_Detra_Id = value
                OnPropertyChanged("opd_Oper_Detra_Id")
            End If
        End Set
    End Property

    Private _opd_Oper_Detra_Id As String

    <DataMember()>
    Public Property opd_Descripcion() As String
        Get
            Return _opd_Descripcion
        End Get
        Set(ByVal value As String)
            If Not Equals(_opd_Descripcion, value) Then
                _opd_Descripcion = value
                OnPropertyChanged("opd_Descripcion")
            End If
        End Set
    End Property

    Private _opd_Descripcion As String

    <DataMember()>
    Public Property Usu_Id() As String
        Get
            Return _usu_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_usu_Id, value) Then
                ChangeTracker.RecordOriginalValue("Usu_Id", _usu_Id)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _usu_Id = value
                OnPropertyChanged("Usu_Id")
            End If
        End Set
    End Property

    Private _usu_Id As String

    <DataMember()>
    Public Property opd_FecGrab() As Date
        Get
            Return _opd_FecGrab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_opd_FecGrab, value) Then
                _opd_FecGrab = value
                OnPropertyChanged("opd_FecGrab")
            End If
        End Set
    End Property

    Private _opd_FecGrab As Date

#End Region
#Region "Propiedades de navegación"

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
        Usuarios = Nothing
        ProvisionCompras.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios)
        If IsDeserializing Then
            Return
        End If

        If Usuarios IsNot Nothing Then
            Usu_Id = Usuarios.USU_ID
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

    Private Sub FixupProvisionCompras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ProvisionCompras In e.NewItems
                item.OperacionDetraciones = Me
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
                If ReferenceEquals(item.OperacionDetraciones, Me) Then
                    item.OperacionDetraciones = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ProvisionCompras", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
