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
<KnownType(GetType(Periodo))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(DetalleGrupoTrabajo))>
Partial Public Class GrupoTrabajo
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared grt_Fecha As string = "grt_Fecha"
				public shared grt_NumeroProd As string = "grt_NumeroProd"
				public shared prd_Periodo_id As string = "prd_Periodo_id"
				public shared grt_observaciones As string = "grt_observaciones"
				public shared Usu_Id As string = "Usu_Id"
				public shared grt_FecGrab As string = "grt_FecGrab"
				public shared grt_EsTareo As string = "grt_EsTareo"
				public shared grt_EsSecaderoQuema As string = "grt_EsSecaderoQuema"
				public shared grt_ResponsableSecaderoQuemas As string = "grt_ResponsableSecaderoQuemas"
				public shared grt_Factor As string = "grt_Factor"
				public shared grt_ClaveAnular As string = "grt_ClaveAnular"
		    End Structure
	



    <DataMember()>
    Public Property grt_Fecha() As Date
        Get
            Return _grt_Fecha
        End Get
        Set(ByVal value As Date)
            If Not Equals(_grt_Fecha, value) Then
                _grt_Fecha = value
                OnPropertyChanged("grt_Fecha")
            End If
        End Set
    End Property

    Private _grt_Fecha As Date

    <DataMember()>
    Public Property grt_NumeroProd() As String
        Get
            Return _grt_NumeroProd
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_NumeroProd, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'grt_NumeroProd' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _grt_NumeroProd = value
                OnPropertyChanged("grt_NumeroProd")
            End If
        End Set
    End Property

    Private _grt_NumeroProd As String

    <DataMember()>
    Public Property prd_Periodo_id() As String
        Get
            Return _prd_Periodo_id
        End Get
        Set(ByVal value As String)
            If Not Equals(_prd_Periodo_id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prd_Periodo_id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If Periodo IsNot Nothing AndAlso Not Equals(Periodo.prd_Periodo_id, value) Then
                        Periodo = Nothing
                    End If
                End If
                _prd_Periodo_id = value
                OnPropertyChanged("prd_Periodo_id")
            End If
        End Set
    End Property

    Private _prd_Periodo_id As String

    <DataMember()>
    Public Property grt_observaciones() As String
        Get
            Return _grt_observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_observaciones, value) Then
                _grt_observaciones = value
                OnPropertyChanged("grt_observaciones")
            End If
        End Set
    End Property

    Private _grt_observaciones As String

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
    Public Property grt_FecGrab() As Date
        Get
            Return _grt_FecGrab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_grt_FecGrab, value) Then
                _grt_FecGrab = value
                OnPropertyChanged("grt_FecGrab")
            End If
        End Set
    End Property

    Private _grt_FecGrab As Date

    <DataMember()>
    Public Property grt_EsTareo() As Boolean
        Get
            Return _grt_EsTareo
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_grt_EsTareo, value) Then
                _grt_EsTareo = value
                OnPropertyChanged("grt_EsTareo")
            End If
        End Set
    End Property

    Private _grt_EsTareo As Boolean

    <DataMember()>
    Public Property grt_EsSecaderoQuema() As String
        Get
            Return _grt_EsSecaderoQuema
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_EsSecaderoQuema, value) Then
                _grt_EsSecaderoQuema = value
                OnPropertyChanged("grt_EsSecaderoQuema")
            End If
        End Set
    End Property

    Private _grt_EsSecaderoQuema As String

    <DataMember()>
    Public Property grt_ResponsableSecaderoQuemas() As String
        Get
            Return _grt_ResponsableSecaderoQuemas
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_ResponsableSecaderoQuemas, value) Then
                _grt_ResponsableSecaderoQuemas = value
                OnPropertyChanged("grt_ResponsableSecaderoQuemas")
            End If
        End Set
    End Property

    Private _grt_ResponsableSecaderoQuemas As String

    <DataMember()>
    Public Property grt_Factor() As Nullable(Of Decimal)
        Get
            Return _grt_Factor
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_grt_Factor, value) Then
                _grt_Factor = value
                OnPropertyChanged("grt_Factor")
            End If
        End Set
    End Property

    Private _grt_Factor As Nullable(Of Decimal)

    <DataMember()>
    Public Property grt_ClaveAnular() As String
        Get
            Return _grt_ClaveAnular
        End Get
        Set(ByVal value As String)
            If Not Equals(_grt_ClaveAnular, value) Then
                _grt_ClaveAnular = value
                OnPropertyChanged("grt_ClaveAnular")
            End If
        End Set
    End Property

    Private _grt_ClaveAnular As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Periodo() As Periodo
        Get
            Return _periodo
        End Get
        Set(ByVal value As Periodo)
            If _periodo IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(prd_Periodo_id, value.prd_Periodo_id) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As Periodo = _periodo
                _periodo = value
                FixupPeriodo(previousValue)
                OnNavigationPropertyChanged("Periodo")
            End If
        End Set
    End Property

    Private _periodo As Periodo


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
    Public Property DetalleGrupoTrabajo() As TrackableCollection(Of DetalleGrupoTrabajo)
        Get
            If _detalleGrupoTrabajo Is Nothing Then
                _detalleGrupoTrabajo = New TrackableCollection(Of DetalleGrupoTrabajo)
                AddHandler _detalleGrupoTrabajo.CollectionChanged, AddressOf FixupDetalleGrupoTrabajo
            End If
            Return _detalleGrupoTrabajo
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleGrupoTrabajo))
            If Not Object.ReferenceEquals(_detalleGrupoTrabajo, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleGrupoTrabajo IsNot Nothing Then
                    RemoveHandler _detalleGrupoTrabajo.CollectionChanged, AddressOf FixupDetalleGrupoTrabajo
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleGrupoTrabajo In _detalleGrupoTrabajo
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleGrupoTrabajo = value
                If _detalleGrupoTrabajo IsNot Nothing Then
                    AddHandler _detalleGrupoTrabajo.CollectionChanged, AddressOf FixupDetalleGrupoTrabajo
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleGrupoTrabajo In _detalleGrupoTrabajo
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleGrupoTrabajo")
            End If
        End Set
    End Property

    Private _detalleGrupoTrabajo As TrackableCollection(Of DetalleGrupoTrabajo)

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

    ' Este tipo de entidad es el extremo dependiente en al menos una asociación que realiza eliminaciones en cascada.
    ' Este controlador de eventos procesará notificaciones que tienen lugar cuando se elimina el extremo principal.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        Periodo = Nothing
        Usuarios = Nothing
        DetalleGrupoTrabajo.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPeriodo(ByVal previousValue As Periodo)
        ' Este es el extremo dependiente en una asociación que realiza eliminaciones en cascada.
        ' Actualizar la escucha de eventos del extremo principal para que se refiera al nuevo extremo dependiente.
        ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
        ' responsable de administrar el controlador de eventos de eliminación en cascada. En el resto de los casos, será el extremo principal el que lo administrará.
        If previousValue IsNot Nothing Then
            RemoveHandler previousValue.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

        If Periodo IsNot Nothing Then
            AddHandler Periodo.ChangeTracker.ObjectStateChanging, AddressOf HandleCascadeDelete
        End If

        If IsDeserializing Then
            Return
        End If

        If Periodo IsNot Nothing Then
            prd_Periodo_id = Periodo.prd_Periodo_id
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Periodo") AndAlso
                ChangeTracker.OriginalValues("Periodo") Is Periodo Then
                ChangeTracker.OriginalValues.Remove("Periodo")
            Else
                ChangeTracker.RecordOriginalValue("Periodo", previousValue)
                ' Este es el extremo dependiente de una asociación de identificación, por lo que se debe eliminar cuando la relación se
                ' elimine. Si el estado actual es agregado, la relación se puede modificar sin eliminar el extremo dependiente.
                ' Esta es una relación unidireccional desde el extremo dependiente al extremo principal por lo que el extremo dependiente es
                ' responsable de administrar en cascada la eliminación. En el resto de los casos, será el extremo principal el que lo administre.
                If previousValue IsNot Nothing AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Me.MarkAsDeleted()
                End If
            End If
            If Periodo IsNot Nothing AndAlso Not Periodo.ChangeTracker.ChangeTrackingEnabled Then
                Periodo.StartTracking()
            End If
        End If
    End Sub

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

    Private Sub FixupDetalleGrupoTrabajo(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleGrupoTrabajo In e.NewItems
                item.prd_Periodo_id = prd_Periodo_id
                item.grt_NumeroProd = grt_NumeroProd
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleGrupoTrabajo", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleGrupoTrabajo In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleGrupoTrabajo", item)
                    ' Eliminar el extremo dependiente de esta asociación de identificación. Si el estado actual es agregado,
                    ' permite que la relación se modifique sin eliminar el elemento dependiente.
                    If item.ChangeTracker.State <> ObjectState.Added Then
                        item.MarkAsDeleted()
                    End If
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Quitar el extremo dependiente anterior de la escucha de eventos.
                RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If
    End Sub

#End Region
End Class