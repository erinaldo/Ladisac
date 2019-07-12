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
<KnownType(GetType(LibrosContables))>
<KnownType(GetType(Periodo))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(DetalleAsientosManuales))>
Partial Public Class AsientosManuales
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared lib_Id As string = "lib_Id"
				public shared prd_Periodo_id As string = "prd_Periodo_id"
				public shared asm_NumeroVoucher As string = "asm_NumeroVoucher"
				public shared asm_Glosa As string = "asm_Glosa"
				public shared asm_Fecha As string = "asm_Fecha"
				public shared Usu_Id As string = "Usu_Id"
				public shared asm_FecGrab As string = "asm_FecGrab"
		    End Structure
	



    <DataMember()>
    Public Property lib_Id() As String
        Get
            Return _lib_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_lib_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'lib_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If LibrosContables IsNot Nothing AndAlso Not Equals(LibrosContables.lib_Id, value) Then
                        LibrosContables = Nothing
                    End If
                End If
                _lib_Id = value
                OnPropertyChanged("lib_Id")
            End If
        End Set
    End Property

    Private _lib_Id As String

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
    Public Property asm_NumeroVoucher() As String
        Get
            Return _asm_NumeroVoucher
        End Get
        Set(ByVal value As String)
            If Not Equals(_asm_NumeroVoucher, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'asm_NumeroVoucher' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _asm_NumeroVoucher = value
                OnPropertyChanged("asm_NumeroVoucher")
            End If
        End Set
    End Property

    Private _asm_NumeroVoucher As String

    <DataMember()>
    Public Property asm_Glosa() As String
        Get
            Return _asm_Glosa
        End Get
        Set(ByVal value As String)
            If Not Equals(_asm_Glosa, value) Then
                _asm_Glosa = value
                OnPropertyChanged("asm_Glosa")
            End If
        End Set
    End Property

    Private _asm_Glosa As String

    <DataMember()>
    Public Property asm_Fecha() As Date
        Get
            Return _asm_Fecha
        End Get
        Set(ByVal value As Date)
            If Not Equals(_asm_Fecha, value) Then
                _asm_Fecha = value
                OnPropertyChanged("asm_Fecha")
            End If
        End Set
    End Property

    Private _asm_Fecha As Date

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
    Public Property asm_FecGrab() As Date
        Get
            Return _asm_FecGrab
        End Get
        Set(ByVal value As Date)
            If Not Equals(_asm_FecGrab, value) Then
                _asm_FecGrab = value
                OnPropertyChanged("asm_FecGrab")
            End If
        End Set
    End Property

    Private _asm_FecGrab As Date

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property LibrosContables() As LibrosContables
        Get
            Return _librosContables
        End Get
        Set(ByVal value As LibrosContables)
            If _librosContables IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(lib_Id, value.lib_Id) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As LibrosContables = _librosContables
                _librosContables = value
                FixupLibrosContables(previousValue)
                OnNavigationPropertyChanged("LibrosContables")
            End If
        End Set
    End Property

    Private _librosContables As LibrosContables


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
    Public Property DetalleAsientosManuales() As TrackableCollection(Of DetalleAsientosManuales)
        Get
            If _detalleAsientosManuales Is Nothing Then
                _detalleAsientosManuales = New TrackableCollection(Of DetalleAsientosManuales)
                AddHandler _detalleAsientosManuales.CollectionChanged, AddressOf FixupDetalleAsientosManuales
            End If
            Return _detalleAsientosManuales
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleAsientosManuales))
            If Not Object.ReferenceEquals(_detalleAsientosManuales, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleAsientosManuales IsNot Nothing Then
                    RemoveHandler _detalleAsientosManuales.CollectionChanged, AddressOf FixupDetalleAsientosManuales
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleAsientosManuales In _detalleAsientosManuales
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleAsientosManuales = value
                If _detalleAsientosManuales IsNot Nothing Then
                    AddHandler _detalleAsientosManuales.CollectionChanged, AddressOf FixupDetalleAsientosManuales
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleAsientosManuales In _detalleAsientosManuales
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleAsientosManuales")
            End If
        End Set
    End Property

    Private _detalleAsientosManuales As TrackableCollection(Of DetalleAsientosManuales)

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
        LibrosContables = Nothing
        Periodo = Nothing
        Usuarios = Nothing
        DetalleAsientosManuales.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupLibrosContables(ByVal previousValue As LibrosContables)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.AsientosManuales.Contains(Me) Then
            previousValue.AsientosManuales.Remove(Me)
        End If

        If LibrosContables IsNot Nothing Then
            If Not LibrosContables.AsientosManuales.Contains(Me) Then
                LibrosContables.AsientosManuales.Add(Me)
            End If

            lib_Id = LibrosContables.lib_Id
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("LibrosContables") AndAlso
                ChangeTracker.OriginalValues("LibrosContables") Is LibrosContables Then
                ChangeTracker.OriginalValues.Remove("LibrosContables")
            Else
                ChangeTracker.RecordOriginalValue("LibrosContables", previousValue)
            End If
            If LibrosContables IsNot Nothing AndAlso Not LibrosContables.ChangeTracker.ChangeTrackingEnabled Then
                LibrosContables.StartTracking()
            End If
        End If
    End Sub

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

    Private Sub FixupDetalleAsientosManuales(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleAsientosManuales In e.NewItems
                item.lib_Id = lib_Id
                item.prd_Periodo_id = prd_Periodo_id
                item.asm_NumeroVoucher = asm_NumeroVoucher
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleAsientosManuales", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleAsientosManuales In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleAsientosManuales", item)
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
