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
<KnownType(GetType(DocPersonas))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Documentos))>
<KnownType(GetType(Despachos))>
Partial Public Class TipoDocPersonas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared TDP_ID As string = "TDP_ID"
				public shared TDP_DESCRIPCION As string = "TDP_DESCRIPCION"
				public shared TDP_LONGITUD As string = "TDP_LONGITUD"
				public shared TDP_COD_SUNAT As string = "TDP_COD_SUNAT"
				public shared USU_ID As string = "USU_ID"
				public shared TDP_FEC_GRAB As string = "TDP_FEC_GRAB"
				public shared TDP_ESTADO As string = "TDP_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property TDP_ID() As String
        Get
            Return _tDP_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TDP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tDP_ID = value
                OnPropertyChanged("TDP_ID")
            End If
        End Set
    End Property

    Private _tDP_ID As String

    <DataMember()>
    Public Property TDP_DESCRIPCION() As String
        Get
            Return _tDP_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDP_DESCRIPCION, value) Then
                _tDP_DESCRIPCION = value
                OnPropertyChanged("TDP_DESCRIPCION")
            End If
        End Set
    End Property

    Private _tDP_DESCRIPCION As String

    <DataMember()>
    Public Property TDP_LONGITUD() As Decimal
        Get
            Return _tDP_LONGITUD
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_tDP_LONGITUD, value) Then
                _tDP_LONGITUD = value
                OnPropertyChanged("TDP_LONGITUD")
            End If
        End Set
    End Property

    Private _tDP_LONGITUD As Decimal

    <DataMember()>
    Public Property TDP_COD_SUNAT() As String
        Get
            Return _tDP_COD_SUNAT
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDP_COD_SUNAT, value) Then
                _tDP_COD_SUNAT = value
                OnPropertyChanged("TDP_COD_SUNAT")
            End If
        End Set
    End Property

    Private _tDP_COD_SUNAT As String

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
    Public Property TDP_FEC_GRAB() As Date
        Get
            Return _tDP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_tDP_FEC_GRAB, value) Then
                _tDP_FEC_GRAB = value
                OnPropertyChanged("TDP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _tDP_FEC_GRAB As Date

    <DataMember()>
    Public Property TDP_ESTADO() As Boolean
        Get
            Return _tDP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_tDP_ESTADO, value) Then
                _tDP_ESTADO = value
                OnPropertyChanged("TDP_ESTADO")
            End If
        End Set
    End Property

    Private _tDP_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DocPersonas() As TrackableCollection(Of DocPersonas)
        Get
            If _docPersonas Is Nothing Then
                _docPersonas = New TrackableCollection(Of DocPersonas)
                AddHandler _docPersonas.CollectionChanged, AddressOf FixupDocPersonas
            End If
            Return _docPersonas
        End Get
        Set(ByVal value As TrackableCollection(Of DocPersonas))
            If Not Object.ReferenceEquals(_docPersonas, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docPersonas IsNot Nothing Then
                    RemoveHandler _docPersonas.CollectionChanged, AddressOf FixupDocPersonas
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DocPersonas In _docPersonas
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _docPersonas = value
                If _docPersonas IsNot Nothing Then
                    AddHandler _docPersonas.CollectionChanged, AddressOf FixupDocPersonas
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DocPersonas In _docPersonas
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DocPersonas")
            End If
        End Set
    End Property

    Private _docPersonas As TrackableCollection(Of DocPersonas)

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
    Public Property Documentos() As TrackableCollection(Of Documentos)
        Get
            If _documentos Is Nothing Then
                _documentos = New TrackableCollection(Of Documentos)
                AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
            End If
            Return _documentos
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos IsNot Nothing Then
                    RemoveHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                _documentos = value
                If _documentos IsNot Nothing Then
                    AddHandler _documentos.CollectionChanged, AddressOf FixupDocumentos
                End If
                OnNavigationPropertyChanged("Documentos")
            End If
        End Set
    End Property

    Private _documentos As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Documentos1() As TrackableCollection(Of Documentos)
        Get
            If _documentos1 Is Nothing Then
                _documentos1 = New TrackableCollection(Of Documentos)
                AddHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
            End If
            Return _documentos1
        End Get
        Set(ByVal value As TrackableCollection(Of Documentos))
            If Not Object.ReferenceEquals(_documentos1, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _documentos1 IsNot Nothing Then
                    RemoveHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
                End If
                _documentos1 = value
                If _documentos1 IsNot Nothing Then
                    AddHandler _documentos1.CollectionChanged, AddressOf FixupDocumentos1
                End If
                OnNavigationPropertyChanged("Documentos1")
            End If
        End Set
    End Property

    Private _documentos1 As TrackableCollection(Of Documentos)

    <DataMember()>
    Public Property Despachos() As TrackableCollection(Of Despachos)
        Get
            If _despachos Is Nothing Then
                _despachos = New TrackableCollection(Of Despachos)
                AddHandler _despachos.CollectionChanged, AddressOf FixupDespachos
            End If
            Return _despachos
        End Get
        Set(ByVal value As TrackableCollection(Of Despachos))
            If Not Object.ReferenceEquals(_despachos, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _despachos IsNot Nothing Then
                    RemoveHandler _despachos.CollectionChanged, AddressOf FixupDespachos
                End If
                _despachos = value
                If _despachos IsNot Nothing Then
                    AddHandler _despachos.CollectionChanged, AddressOf FixupDespachos
                End If
                OnNavigationPropertyChanged("Despachos")
            End If
        End Set
    End Property

    Private _despachos As TrackableCollection(Of Despachos)

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
        DocPersonas.Clear()
        Usuarios = Nothing
        Documentos.Clear()
        Documentos1.Clear()
        Despachos.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

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

    Private Sub FixupDocPersonas(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocPersonas In e.NewItems
                item.TipoDocPersonas = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocPersonas", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocPersonas In e.OldItems
                If ReferenceEquals(item.TipoDocPersonas, Me) Then
                    item.TipoDocPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocPersonas", item)
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

    Private Sub FixupDocumentos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.TipoDocPersonas = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.TipoDocPersonas, Me) Then
                    item.TipoDocPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocumentos1(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Documentos In e.NewItems
                item.TipoDocPersonas1 = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Documentos1", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Documentos In e.OldItems
                If ReferenceEquals(item.TipoDocPersonas1, Me) Then
                    item.TipoDocPersonas1 = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Documentos1", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDespachos(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As Despachos In e.NewItems
                item.TipoDocPersonas = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("Despachos", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As Despachos In e.OldItems
                If ReferenceEquals(item.TipoDocPersonas, Me) Then
                    item.TipoDocPersonas = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("Despachos", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
