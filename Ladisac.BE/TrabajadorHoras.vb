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
<KnownType(GetType(DetalleTrabajadorHoras))>
<KnownType(GetType(PlanillasComedorHoras))>
Partial Public Class TrabajadorHoras
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared tit_TipoTrab_Id As string = "tit_TipoTrab_Id"
				public shared trh_Numero As string = "trh_Numero"
				public shared trh_descripcion As string = "trh_descripcion"
				public shared trh_FechaDesde As string = "trh_FechaDesde"
				public shared trh_FechaHasta As string = "trh_FechaHasta"
				public shared trh_BloquearFechas As string = "trh_BloquearFechas"
				public shared trh_EsImportadoProduc As string = "trh_EsImportadoProduc"
				public shared trh_EsImportadoExcel As string = "trh_EsImportadoExcel"
				public shared pla_SeriePlaniRef As string = "pla_SeriePlaniRef"
				public shared pla_NumeroRef As string = "pla_NumeroRef"
				public shared tdo_IdRef As string = "tdo_IdRef"
		    End Structure
	



    <DataMember()>
    Public Property tit_TipoTrab_Id() As String
        Get
            Return _tit_TipoTrab_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_tit_TipoTrab_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'tit_TipoTrab_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tit_TipoTrab_Id = value
                OnPropertyChanged("tit_TipoTrab_Id")
            End If
        End Set
    End Property

    Private _tit_TipoTrab_Id As String

    <DataMember()>
    Public Property trh_Numero() As String
        Get
            Return _trh_Numero
        End Get
        Set(ByVal value As String)
            If Not Equals(_trh_Numero, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'trh_Numero' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _trh_Numero = value
                OnPropertyChanged("trh_Numero")
            End If
        End Set
    End Property

    Private _trh_Numero As String

    <DataMember()>
    Public Property trh_descripcion() As String
        Get
            Return _trh_descripcion
        End Get
        Set(ByVal value As String)
            If Not Equals(_trh_descripcion, value) Then
                _trh_descripcion = value
                OnPropertyChanged("trh_descripcion")
            End If
        End Set
    End Property

    Private _trh_descripcion As String

    <DataMember()>
    Public Property trh_FechaDesde() As Date
        Get
            Return _trh_FechaDesde
        End Get
        Set(ByVal value As Date)
            If Not Equals(_trh_FechaDesde, value) Then
                _trh_FechaDesde = value
                OnPropertyChanged("trh_FechaDesde")
            End If
        End Set
    End Property

    Private _trh_FechaDesde As Date

    <DataMember()>
    Public Property trh_FechaHasta() As Date
        Get
            Return _trh_FechaHasta
        End Get
        Set(ByVal value As Date)
            If Not Equals(_trh_FechaHasta, value) Then
                _trh_FechaHasta = value
                OnPropertyChanged("trh_FechaHasta")
            End If
        End Set
    End Property

    Private _trh_FechaHasta As Date

    <DataMember()>
    Public Property trh_BloquearFechas() As Boolean
        Get
            Return _trh_BloquearFechas
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_trh_BloquearFechas, value) Then
                _trh_BloquearFechas = value
                OnPropertyChanged("trh_BloquearFechas")
            End If
        End Set
    End Property

    Private _trh_BloquearFechas As Boolean

    <DataMember()>
    Public Property trh_EsImportadoProduc() As Nullable(Of Boolean)
        Get
            Return _trh_EsImportadoProduc
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_trh_EsImportadoProduc, value) Then
                _trh_EsImportadoProduc = value
                OnPropertyChanged("trh_EsImportadoProduc")
            End If
        End Set
    End Property

    Private _trh_EsImportadoProduc As Nullable(Of Boolean)

    <DataMember()>
    Public Property trh_EsImportadoExcel() As Nullable(Of Boolean)
        Get
            Return _trh_EsImportadoExcel
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_trh_EsImportadoExcel, value) Then
                _trh_EsImportadoExcel = value
                OnPropertyChanged("trh_EsImportadoExcel")
            End If
        End Set
    End Property

    Private _trh_EsImportadoExcel As Nullable(Of Boolean)

    <DataMember()>
    Public Property pla_SeriePlaniRef() As String
        Get
            Return _pla_SeriePlaniRef
        End Get
        Set(ByVal value As String)
            If Not Equals(_pla_SeriePlaniRef, value) Then
                ChangeTracker.RecordOriginalValue("pla_SeriePlaniRef", _pla_SeriePlaniRef)
                _pla_SeriePlaniRef = value
                OnPropertyChanged("pla_SeriePlaniRef")
            End If
        End Set
    End Property

    Private _pla_SeriePlaniRef As String

    <DataMember()>
    Public Property pla_NumeroRef() As String
        Get
            Return _pla_NumeroRef
        End Get
        Set(ByVal value As String)
            If Not Equals(_pla_NumeroRef, value) Then
                ChangeTracker.RecordOriginalValue("pla_NumeroRef", _pla_NumeroRef)
                _pla_NumeroRef = value
                OnPropertyChanged("pla_NumeroRef")
            End If
        End Set
    End Property

    Private _pla_NumeroRef As String

    <DataMember()>
    Public Property tdo_IdRef() As String
        Get
            Return _tdo_IdRef
        End Get
        Set(ByVal value As String)
            If Not Equals(_tdo_IdRef, value) Then
                ChangeTracker.RecordOriginalValue("tdo_IdRef", _tdo_IdRef)
                _tdo_IdRef = value
                OnPropertyChanged("tdo_IdRef")
            End If
        End Set
    End Property

    Private _tdo_IdRef As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property DetalleTrabajadorHoras() As TrackableCollection(Of DetalleTrabajadorHoras)
        Get
            If _detalleTrabajadorHoras Is Nothing Then
                _detalleTrabajadorHoras = New TrackableCollection(Of DetalleTrabajadorHoras)
                AddHandler _detalleTrabajadorHoras.CollectionChanged, AddressOf FixupDetalleTrabajadorHoras
            End If
            Return _detalleTrabajadorHoras
        End Get
        Set(ByVal value As TrackableCollection(Of DetalleTrabajadorHoras))
            If Not Object.ReferenceEquals(_detalleTrabajadorHoras, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _detalleTrabajadorHoras IsNot Nothing Then
                    RemoveHandler _detalleTrabajadorHoras.CollectionChanged, AddressOf FixupDetalleTrabajadorHoras
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Quitar el controlador de eventos de la eliminación en cascada para aquellas entidades de la colección actual.
                    For Each item As DetalleTrabajadorHoras In _detalleTrabajadorHoras
                        RemoveHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                _detalleTrabajadorHoras = value
                If _detalleTrabajadorHoras IsNot Nothing Then
                    AddHandler _detalleTrabajadorHoras.CollectionChanged, AddressOf FixupDetalleTrabajadorHoras
                    ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                    ' Agrega el controlador de eventos de eliminación en cascada para aquellas entidades que ya se encuentran en la nueva colección.
                    For Each item As DetalleTrabajadorHoras In _detalleTrabajadorHoras
                        AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
                    Next
                End If
                OnNavigationPropertyChanged("DetalleTrabajadorHoras")
            End If
        End Set
    End Property

    Private _detalleTrabajadorHoras As TrackableCollection(Of DetalleTrabajadorHoras)

    <DataMember()>
    Public Property PlanillasComedorHoras() As TrackableCollection(Of PlanillasComedorHoras)
        Get
            If _planillasComedorHoras Is Nothing Then
                _planillasComedorHoras = New TrackableCollection(Of PlanillasComedorHoras)
                AddHandler _planillasComedorHoras.CollectionChanged, AddressOf FixupPlanillasComedorHoras
            End If
            Return _planillasComedorHoras
        End Get
        Set(ByVal value As TrackableCollection(Of PlanillasComedorHoras))
            If Not Object.ReferenceEquals(_planillasComedorHoras, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _planillasComedorHoras IsNot Nothing Then
                    RemoveHandler _planillasComedorHoras.CollectionChanged, AddressOf FixupPlanillasComedorHoras
                End If
                _planillasComedorHoras = value
                If _planillasComedorHoras IsNot Nothing Then
                    AddHandler _planillasComedorHoras.CollectionChanged, AddressOf FixupPlanillasComedorHoras
                End If
                OnNavigationPropertyChanged("PlanillasComedorHoras")
            End If
        End Set
    End Property

    Private _planillasComedorHoras As TrackableCollection(Of PlanillasComedorHoras)

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
        DetalleTrabajadorHoras.Clear()
        PlanillasComedorHoras.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupDetalleTrabajadorHoras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DetalleTrabajadorHoras In e.NewItems
                item.tit_TipoTrab_Id = tit_TipoTrab_Id
                item.trh_Numero = trh_Numero
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DetalleTrabajadorHoras", item)
                End If
                ' Este es el extremo principal en una asociación que realiza eliminaciones en cascada.
                ' Actualizar la escucha de eventos para que se refiera al nuevo extremo dependiente.
                AddHandler ChangeTracker.ObjectStateChanging, AddressOf item.HandleCascadeDelete
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DetalleTrabajadorHoras In e.OldItems
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DetalleTrabajadorHoras", item)
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

    Private Sub FixupPlanillasComedorHoras(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As PlanillasComedorHoras In e.NewItems
                item.TrabajadorHoras = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("PlanillasComedorHoras", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As PlanillasComedorHoras In e.OldItems
                If ReferenceEquals(item.TrabajadorHoras, Me) Then
                    item.TrabajadorHoras = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("PlanillasComedorHoras", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class