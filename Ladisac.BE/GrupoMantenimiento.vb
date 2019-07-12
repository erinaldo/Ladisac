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
<KnownType(GetType(Personas))>
<KnownType(GetType(DetalleGrupoMantenimiento))>
Partial Public Class GrupoMantenimiento
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared prd_Periodo_id As string = "prd_Periodo_id"
				public shared grm_Numero As string = "grm_Numero"
				public shared grm_Fecha As string = "grm_Fecha"
				public shared per_IDResponsable As string = "per_IDResponsable"
				public shared grm_observaciones As string = "grm_observaciones"
				public shared grm_FecGrab As string = "grm_FecGrab"
				public shared Usu_Id As string = "Usu_Id"
		    End Structure
	



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
                _prd_Periodo_id = value
                OnPropertyChanged("prd_Periodo_id")
            End If
        End Set
    End Property

    Private _prd_Periodo_id As String

    <DataMember()>
    Public Property grm_Numero() As String
        Get
            Return _grm_Numero
        End Get
        Set(ByVal value As String)
            If Not Equals(_grm_Numero, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'grm_Numero' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _grm_Numero = value
                OnPropertyChanged("grm_Numero")
            End If
        End Set
    End Property

    Private _grm_Numero As String

    <DataMember()>
    Public Property grm_Fecha() As Date
        Get
            Return _grm_Fecha
        End Get
        Set(ByVal value As Date)
            If Not Equals(_grm_Fecha, value) Then
                _grm_Fecha = value
                OnPropertyChanged("grm_Fecha")
            End If
        End Set
    End Property

    Private _grm_Fecha As Date

    <DataMember()>
    Public Property per_IDResponsable() As String
        Get
            Return _per_IDResponsable
        End Get
        Set(ByVal value As String)
            If Not Equals(_per_IDResponsable, value) Then
                ChangeTracker.RecordOriginalValue("per_IDResponsable", _per_IDResponsable)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _per_IDResponsable = value
                OnPropertyChanged("per_IDResponsable")
            End If
        End Set
    End Property

    Private _per_IDResponsable As String

    <DataMember()>
    Public Property grm_observaciones() As String
        Get
            Return _grm_observaciones
        End Get
        Set(ByVal value As String)
            If Not Equals(_grm_observaciones, value) Then
                _grm_observaciones = value
                OnPropertyChanged("grm_observaciones")
            End If
        End Set
    End Property

    Private _grm_observaciones As String

    <DataMember()>
    Public Property grm_FecGrab() As Nullable(Of Date)
        Get
            Return _grm_FecGrab
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_grm_FecGrab, value) Then
                _grm_FecGrab = value
                OnPropertyChanged("grm_FecGrab")
            End If
        End Set
    End Property

    Private _grm_FecGrab As Nullable(Of Date)

    <DataMember()>
    Public Property Usu_Id() As String
        Get
            Return _usu_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_usu_Id, value) Then
                ChangeTracker.RecordOriginalValue("Usu_Id", _usu_Id)
                _usu_Id = value
                OnPropertyChanged("Usu_Id")
            End If
        End Set
    End Property

    Private _usu_Id As String

#End Region
#Region "Propiedades de navegación"

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


    <DataMember()>
    Public Property DetalleGrupoMantenimiento() As TrackableCollection(Of DetalleGrupoMantenimiento)
        Get
            If _detalleGrupoMantenimiento Is Nothing Then
                _detalleGrupoMantenimiento = New TrackableCollection(Of DetalleGrupoMantenimiento)
                AddHandler _detalleGrupoMantenimiento.CollectionChanged, AddressOf FixupDetalleGrupoMantenimiento
            End If
            Return _detalleGrupoMantenimiento
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleGrupoMantenimiento))
            If Not Object.ReferenceEquals(_detalleGrupoMantenimiento, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleGrupoMantenimiento IsNot Nothing Then
                    RemoveHandler _detalleGrupoMantenimiento.CollectionChanged, AddressOf FixupDetalleGrupoMantenimiento
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleGrupoMantenimiento In _detalleGrupoMantenimiento
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleGrupoMantenimiento = value
                If _detalleGrupoMantenimiento IsNot Nothing Then
                    AddHandler _detalleGrupoMantenimiento.CollectionChanged, AddressOf FixupDetalleGrupoMantenimiento
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleGrupoMantenimiento In _detalleGrupoMantenimiento
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleGrupoMantenimiento")
            End If
        End Set
    End Property

    Private _detalleGrupoMantenimiento As TrackableCollection(Of DetalleGrupoMantenimiento)

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
        Personas = Nothing
        DetalleGrupoMantenimiento.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            per_IDResponsable = Personas.PER_ID
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

    Private Sub FixupDetalleGrupoMantenimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleGrupoMantenimiento In e.NewItems
                item.prd_Periodo_id = prd_Periodo_id
                item.grm_Numero = grm_Numero
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleGrupoMantenimiento", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleGrupoMantenimiento In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleGrupoMantenimiento", item)
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