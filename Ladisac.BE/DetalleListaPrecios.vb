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
<KnownType(GetType(DescuentoIncrementoTipoVentaPersonas))>
<KnownType(GetType(Articulos))>
<KnownType(GetType(ListaPreciosArticulos))>
<KnownType(GetType(Usuarios))>
Partial Public Class DetalleListaPrecios
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared LPR_ID As string = "LPR_ID"
				public shared ART_ID As string = "ART_ID"
				public shared DLP_PRECIO_MINIMO As string = "DLP_PRECIO_MINIMO"
				public shared DLP_PRECIO_UNITARIO As string = "DLP_PRECIO_UNITARIO"
				public shared DLP_RECARGO_ENVIO As string = "DLP_RECARGO_ENVIO"
				public shared USU_ID As string = "USU_ID"
				public shared DLP_FEC_GRAB As string = "DLP_FEC_GRAB"
				public shared DLP_ESTADO As string = "DLP_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property LPR_ID() As String
        Get
            Return _lPR_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_lPR_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'LPR_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If ListaPreciosArticulos IsNot Nothing AndAlso Not Equals(ListaPreciosArticulos.LPR_ID, value) Then
                        ListaPreciosArticulos = Nothing
                    End If
                End If
                _lPR_ID = value
                OnPropertyChanged("LPR_ID")
            End If
        End Set
    End Property

    Private _lPR_ID As String

    <DataMember()>
    Public Property ART_ID() As String
        Get
            Return _aRT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ART_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If Articulos IsNot Nothing AndAlso Not Equals(Articulos.ART_ID, value) Then
                        Articulos = Nothing
                    End If
                End If
                _aRT_ID = value
                OnPropertyChanged("ART_ID")
            End If
        End Set
    End Property

    Private _aRT_ID As String

    <DataMember()>
    Public Property DLP_PRECIO_MINIMO() As Decimal
        Get
            Return _dLP_PRECIO_MINIMO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_dLP_PRECIO_MINIMO, value) Then
                _dLP_PRECIO_MINIMO = value
                OnPropertyChanged("DLP_PRECIO_MINIMO")
            End If
        End Set
    End Property

    Private _dLP_PRECIO_MINIMO As Decimal

    <DataMember()>
    Public Property DLP_PRECIO_UNITARIO() As Nullable(Of Decimal)
        Get
            Return _dLP_PRECIO_UNITARIO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dLP_PRECIO_UNITARIO, value) Then
                _dLP_PRECIO_UNITARIO = value
                OnPropertyChanged("DLP_PRECIO_UNITARIO")
            End If
        End Set
    End Property

    Private _dLP_PRECIO_UNITARIO As Nullable(Of Decimal)

    <DataMember()>
    Public Property DLP_RECARGO_ENVIO() As Nullable(Of Decimal)
        Get
            Return _dLP_RECARGO_ENVIO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dLP_RECARGO_ENVIO, value) Then
                _dLP_RECARGO_ENVIO = value
                OnPropertyChanged("DLP_RECARGO_ENVIO")
            End If
        End Set
    End Property

    Private _dLP_RECARGO_ENVIO As Nullable(Of Decimal)

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
    Public Property DLP_FEC_GRAB() As Date
        Get
            Return _dLP_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dLP_FEC_GRAB, value) Then
                _dLP_FEC_GRAB = value
                OnPropertyChanged("DLP_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dLP_FEC_GRAB As Date

    <DataMember()>
    Public Property DLP_ESTADO() As Boolean
        Get
            Return _dLP_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_dLP_ESTADO, value) Then
                _dLP_ESTADO = value
                OnPropertyChanged("DLP_ESTADO")
            End If
        End Set
    End Property

    Private _dLP_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DescuentoIncrementoTipoVentaPersonas() As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)
        Get
            If _descuentoIncrementoTipoVentaPersonas Is Nothing Then
                _descuentoIncrementoTipoVentaPersonas = New TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)
                AddHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
            End If
            Return _descuentoIncrementoTipoVentaPersonas
        End Get
        Set(ByVal value As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas))
            If Not Object.ReferenceEquals(_descuentoIncrementoTipoVentaPersonas, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _descuentoIncrementoTipoVentaPersonas IsNot Nothing Then
                    RemoveHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
                End If
                _descuentoIncrementoTipoVentaPersonas = value
                If _descuentoIncrementoTipoVentaPersonas IsNot Nothing Then
                    AddHandler _descuentoIncrementoTipoVentaPersonas.CollectionChanged, AddressOf FixupDescuentoIncrementoTipoVentaPersonas
                End If
                OnNavigationPropertyChanged("DescuentoIncrementoTipoVentaPersonas")
            End If
        End Set
    End Property

    Private _descuentoIncrementoTipoVentaPersonas As TrackableCollection(Of DescuentoIncrementoTipoVentaPersonas)

    <DataMember()>
    Public Property Articulos() As Articulos
        Get
            Return _articulos
        End Get
        Set(ByVal value As Articulos)
            If _articulos IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(ART_ID, value.ART_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As Articulos = _articulos
                _articulos = value
                FixupArticulos(previousValue)
                OnNavigationPropertyChanged("Articulos")
            End If
        End Set
    End Property

    Private _articulos As Articulos


    <DataMember()>
    Public Property ListaPreciosArticulos() As ListaPreciosArticulos
        Get
            Return _listaPreciosArticulos
        End Get
        Set(ByVal value As ListaPreciosArticulos)
            If _listaPreciosArticulos IsNot value Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added AndAlso value IsNot Nothing Then
                    ' Este es el extremo dependiente de una relación de identificación por lo que el extremo principal no se puede cambiar si ya está establecido;
                    ' de lo contrario, solo se puede establecer en una entidad con una clave primaria que tenga el mismo valor que la clave externa del extremo dependiente.
                    If Not Equals(LPR_ID, value.LPR_ID) Then
                        Throw New InvalidOperationException("El extremo principal de una relación de identificación solo se puede modificar cuando el extremo dependiente se encuentra en el estado agregado.")
                    End If
                End If
                Dim previousValue As ListaPreciosArticulos = _listaPreciosArticulos
                _listaPreciosArticulos = value
                FixupListaPreciosArticulos(previousValue)
                OnNavigationPropertyChanged("ListaPreciosArticulos")
            End If
        End Set
    End Property

    Private _listaPreciosArticulos As ListaPreciosArticulos


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
        DescuentoIncrementoTipoVentaPersonas.Clear()
        Articulos = Nothing
        ListaPreciosArticulos = Nothing
        Usuarios = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleListaPrecios.Contains(Me) Then
            previousValue.DetalleListaPrecios.Remove(Me)
        End If

        If Articulos IsNot Nothing Then
            If Not Articulos.DetalleListaPrecios.Contains(Me) Then
                Articulos.DetalleListaPrecios.Add(Me)
            End If

            ART_ID = Articulos.ART_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Articulos") AndAlso
                ChangeTracker.OriginalValues("Articulos") Is Articulos Then
                ChangeTracker.OriginalValues.Remove("Articulos")
            Else
                ChangeTracker.RecordOriginalValue("Articulos", previousValue)
            End If
            If Articulos IsNot Nothing AndAlso Not Articulos.ChangeTracker.ChangeTrackingEnabled Then
                Articulos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupListaPreciosArticulos(ByVal previousValue As ListaPreciosArticulos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleListaPrecios.Contains(Me) Then
            previousValue.DetalleListaPrecios.Remove(Me)
        End If

        If ListaPreciosArticulos IsNot Nothing Then
            If Not ListaPreciosArticulos.DetalleListaPrecios.Contains(Me) Then
                ListaPreciosArticulos.DetalleListaPrecios.Add(Me)
            End If

            LPR_ID = ListaPreciosArticulos.LPR_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ListaPreciosArticulos") AndAlso
                ChangeTracker.OriginalValues("ListaPreciosArticulos") Is ListaPreciosArticulos Then
                ChangeTracker.OriginalValues.Remove("ListaPreciosArticulos")
            Else
                ChangeTracker.RecordOriginalValue("ListaPreciosArticulos", previousValue)
            End If
            If ListaPreciosArticulos IsNot Nothing AndAlso Not ListaPreciosArticulos.ChangeTracker.ChangeTrackingEnabled Then
                ListaPreciosArticulos.StartTracking()
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

    Private Sub FixupDescuentoIncrementoTipoVentaPersonas(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DescuentoIncrementoTipoVentaPersonas In e.NewItems
                item.DetalleListaPrecios = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DescuentoIncrementoTipoVentaPersonas", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DescuentoIncrementoTipoVentaPersonas In e.OldItems
                If ReferenceEquals(item.DetalleListaPrecios, Me) Then
                    item.DetalleListaPrecios = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DescuentoIncrementoTipoVentaPersonas", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
