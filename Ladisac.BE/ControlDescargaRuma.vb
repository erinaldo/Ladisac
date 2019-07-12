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
<KnownType(GetType(ControlDescarga))>
<KnownType(GetType(ControlDescargaRumaDetalle))>
<KnownType(GetType(DocuMovimiento))>
<KnownType(GetType(KardexLote))>
Partial Public Class ControlDescargaRuma
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DRU_ID As string = "DRU_ID"
				public shared DES_ID As string = "DES_ID"
				public shared DRU_FECHA As string = "DRU_FECHA"
				public shared DRU_HI As string = "DRU_HI"
				public shared DRU_HF As string = "DRU_HF"
				public shared USU_ID As string = "USU_ID"
				public shared DRU_FEC_GRAB As string = "DRU_FEC_GRAB"
				public shared DRU_ESTADO As string = "DRU_ESTADO"
				public shared DRU_SERIE As string = "DRU_SERIE"
				public shared DRU_NRO As string = "DRU_NRO"
		    End Structure
	



    <DataMember()>
    Public Property DRU_ID() As Integer
        Get
            Return _dRU_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dRU_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DRU_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dRU_ID = value
                OnPropertyChanged("DRU_ID")
            End If
        End Set
    End Property

    Private _dRU_ID As Integer

    <DataMember()>
    Public Property DES_ID() As Nullable(Of Integer)
        Get
            Return _dES_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dES_ID, value) Then
                ChangeTracker.RecordOriginalValue("DES_ID", _dES_ID)
                If Not IsDeserializing Then
                    If ControlDescarga IsNot Nothing AndAlso Not Equals(ControlDescarga.DES_ID, value) Then
                        ControlDescarga = Nothing
                    End If
                End If
                _dES_ID = value
                OnPropertyChanged("DES_ID")
            End If
        End Set
    End Property

    Private _dES_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DRU_FECHA() As Nullable(Of Date)
        Get
            Return _dRU_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dRU_FECHA, value) Then
                _dRU_FECHA = value
                OnPropertyChanged("DRU_FECHA")
            End If
        End Set
    End Property

    Private _dRU_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property DRU_HI() As Nullable(Of Decimal)
        Get
            Return _dRU_HI
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dRU_HI, value) Then
                _dRU_HI = value
                OnPropertyChanged("DRU_HI")
            End If
        End Set
    End Property

    Private _dRU_HI As Nullable(Of Decimal)

    <DataMember()>
    Public Property DRU_HF() As Nullable(Of Decimal)
        Get
            Return _dRU_HF
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dRU_HF, value) Then
                _dRU_HF = value
                OnPropertyChanged("DRU_HF")
            End If
        End Set
    End Property

    Private _dRU_HF As Nullable(Of Decimal)

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
    Public Property DRU_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _dRU_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_dRU_FEC_GRAB, value) Then
                _dRU_FEC_GRAB = value
                OnPropertyChanged("DRU_FEC_GRAB")
            End If
        End Set
    End Property

    Private _dRU_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property DRU_ESTADO() As Nullable(Of Boolean)
        Get
            Return _dRU_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_dRU_ESTADO, value) Then
                _dRU_ESTADO = value
                OnPropertyChanged("DRU_ESTADO")
            End If
        End Set
    End Property

    Private _dRU_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property DRU_SERIE() As String
        Get
            Return _dRU_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dRU_SERIE, value) Then
                _dRU_SERIE = value
                OnPropertyChanged("DRU_SERIE")
            End If
        End Set
    End Property

    Private _dRU_SERIE As String

    <DataMember()>
    Public Property DRU_NRO() As String
        Get
            Return _dRU_NRO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dRU_NRO, value) Then
                _dRU_NRO = value
                OnPropertyChanged("DRU_NRO")
            End If
        End Set
    End Property

    Private _dRU_NRO As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ControlDescarga() As ControlDescarga
        Get
            Return _controlDescarga
        End Get
        Set(ByVal value As ControlDescarga)
            If _controlDescarga IsNot value Then
                Dim previousValue As ControlDescarga = _controlDescarga
                _controlDescarga = value
                FixupControlDescarga(previousValue)
                OnNavigationPropertyChanged("ControlDescarga")
            End If
        End Set
    End Property

    Private _controlDescarga As ControlDescarga


    <DataMember()>
    Public Property ControlDescargaRumaDetalle() As TrackableCollection(Of ControlDescargaRumaDetalle)
        Get
            If _controlDescargaRumaDetalle Is Nothing Then
                _controlDescargaRumaDetalle = New TrackableCollection(Of ControlDescargaRumaDetalle)
                AddHandler _controlDescargaRumaDetalle.CollectionChanged, AddressOf FixupControlDescargaRumaDetalle
            End If
            Return _controlDescargaRumaDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of ControlDescargaRumaDetalle))
            If Not Object.ReferenceEquals(_controlDescargaRumaDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _controlDescargaRumaDetalle IsNot Nothing Then
                    RemoveHandler _controlDescargaRumaDetalle.CollectionChanged, AddressOf FixupControlDescargaRumaDetalle
                End If
                _controlDescargaRumaDetalle = value
                If _controlDescargaRumaDetalle IsNot Nothing Then
                    AddHandler _controlDescargaRumaDetalle.CollectionChanged, AddressOf FixupControlDescargaRumaDetalle
                End If
                OnNavigationPropertyChanged("ControlDescargaRumaDetalle")
            End If
        End Set
    End Property

    Private _controlDescargaRumaDetalle As TrackableCollection(Of ControlDescargaRumaDetalle)

    <DataMember()>
    Public Property DocuMovimiento() As TrackableCollection(Of DocuMovimiento)
        Get
            If _docuMovimiento Is Nothing Then
                _docuMovimiento = New TrackableCollection(Of DocuMovimiento)
                AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
            End If
            Return _docuMovimiento
        End Get
        Set(ByVal value As TrackableCollection(Of DocuMovimiento))
            If Not Object.ReferenceEquals(_docuMovimiento, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _docuMovimiento IsNot Nothing Then
                    RemoveHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                _docuMovimiento = value
                If _docuMovimiento IsNot Nothing Then
                    AddHandler _docuMovimiento.CollectionChanged, AddressOf FixupDocuMovimiento
                End If
                OnNavigationPropertyChanged("DocuMovimiento")
            End If
        End Set
    End Property

    Private _docuMovimiento As TrackableCollection(Of DocuMovimiento)

    <DataMember()>
    Public Property KardexLote() As TrackableCollection(Of KardexLote)
        Get
            If _kardexLote Is Nothing Then
                _kardexLote = New TrackableCollection(Of KardexLote)
                AddHandler _kardexLote.CollectionChanged, AddressOf FixupKardexLote
            End If
            Return _kardexLote
        End Get
        Set(ByVal value As TrackableCollection(Of KardexLote))
            If Not Object.ReferenceEquals(_kardexLote, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _kardexLote IsNot Nothing Then
                    RemoveHandler _kardexLote.CollectionChanged, AddressOf FixupKardexLote
                End If
                _kardexLote = value
                If _kardexLote IsNot Nothing Then
                    AddHandler _kardexLote.CollectionChanged, AddressOf FixupKardexLote
                End If
                OnNavigationPropertyChanged("KardexLote")
            End If
        End Set
    End Property

    Private _kardexLote As TrackableCollection(Of KardexLote)

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
        ControlDescarga = Nothing
        ControlDescargaRumaDetalle.Clear()
        DocuMovimiento.Clear()
        KardexLote.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupControlDescarga(ByVal previousValue As ControlDescarga, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.ControlDescargaRuma.Contains(Me) Then
            previousValue.ControlDescargaRuma.Remove(Me)
        End If

        If ControlDescarga IsNot Nothing Then
            If Not ControlDescarga.ControlDescargaRuma.Contains(Me) Then
                ControlDescarga.ControlDescargaRuma.Add(Me)
            End If

            DES_ID = ControlDescarga.DES_ID
        ElseIf Not skipKeys Then
            DES_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ControlDescarga") AndAlso
                ChangeTracker.OriginalValues("ControlDescarga") Is ControlDescarga Then
                ChangeTracker.OriginalValues.Remove("ControlDescarga")
            Else
                ChangeTracker.RecordOriginalValue("ControlDescarga", previousValue)
            End If
            If ControlDescarga IsNot Nothing AndAlso Not ControlDescarga.ChangeTracker.ChangeTrackingEnabled Then
                ControlDescarga.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupControlDescargaRumaDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As ControlDescargaRumaDetalle In e.NewItems
                item.DRU_ID = DRU_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("ControlDescargaRumaDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As ControlDescargaRumaDetalle In e.OldItems
                item.DRU_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("ControlDescargaRumaDetalle", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupDocuMovimiento(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.NewItems
                item.DRU_ID = DRU_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As DocuMovimiento In e.OldItems
                item.DRU_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

    Private Sub FixupKardexLote(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As KardexLote In e.NewItems
                item.ControlDescargaRuma = Me
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("KardexLote", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As KardexLote In e.OldItems
                If ReferenceEquals(item.ControlDescargaRuma, Me) Then
                    item.ControlDescargaRuma = Nothing
                End If
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("KardexLote", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
