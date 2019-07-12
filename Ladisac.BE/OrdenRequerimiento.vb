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
<KnownType(GetType(OrdenRequerimientoDetalle))>
<KnownType(GetType(DocuMovimiento))>
Partial Public Class OrdenRequerimiento
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared ORR_ID As string = "ORR_ID"
				public shared ORR_FECHA As string = "ORR_FECHA"
				public shared ORR_FEC_MAX_ENTREGA As string = "ORR_FEC_MAX_ENTREGA"
				public shared ORR_IMPORTANCIA As string = "ORR_IMPORTANCIA"
				public shared PER_ID_SOLICITADO As string = "PER_ID_SOLICITADO"
				public shared PER_ID_AUTORIZADO As string = "PER_ID_AUTORIZADO"
				public shared USU_ID As string = "USU_ID"
				public shared ORR_FEC_GRAB As string = "ORR_FEC_GRAB"
				public shared ORR_ESTADO As string = "ORR_ESTADO"
				public shared ORR_FEC_RECIBIDO As string = "ORR_FEC_RECIBIDO"
				public shared ORR_CERRADA As string = "ORR_CERRADA"
		    End Structure
	



    <DataMember()>
    Public Property ORR_ID() As Integer
        Get
            Return _oRR_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oRR_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ORR_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _oRR_ID = value
                OnPropertyChanged("ORR_ID")
            End If
        End Set
    End Property

    Private _oRR_ID As Integer

    <DataMember()>
    Public Property ORR_FECHA() As Nullable(Of Date)
        Get
            Return _oRR_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oRR_FECHA, value) Then
                _oRR_FECHA = value
                OnPropertyChanged("ORR_FECHA")
            End If
        End Set
    End Property

    Private _oRR_FECHA As Nullable(Of Date)

    <DataMember()>
    Public Property ORR_FEC_MAX_ENTREGA() As Nullable(Of Date)
        Get
            Return _oRR_FEC_MAX_ENTREGA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oRR_FEC_MAX_ENTREGA, value) Then
                _oRR_FEC_MAX_ENTREGA = value
                OnPropertyChanged("ORR_FEC_MAX_ENTREGA")
            End If
        End Set
    End Property

    Private _oRR_FEC_MAX_ENTREGA As Nullable(Of Date)

    <DataMember()>
    Public Property ORR_IMPORTANCIA() As Nullable(Of Integer)
        Get
            Return _oRR_IMPORTANCIA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oRR_IMPORTANCIA, value) Then
                _oRR_IMPORTANCIA = value
                OnPropertyChanged("ORR_IMPORTANCIA")
            End If
        End Set
    End Property

    Private _oRR_IMPORTANCIA As Nullable(Of Integer)

    <DataMember()>
    Public Property PER_ID_SOLICITADO() As String
        Get
            Return _pER_ID_SOLICITADO
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_SOLICITADO, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_SOLICITADO", _pER_ID_SOLICITADO)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_SOLICITADO = value
                OnPropertyChanged("PER_ID_SOLICITADO")
            End If
        End Set
    End Property

    Private _pER_ID_SOLICITADO As String

    <DataMember()>
    Public Property PER_ID_AUTORIZADO() As String
        Get
            Return _pER_ID_AUTORIZADO
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_AUTORIZADO, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_AUTORIZADO", _pER_ID_AUTORIZADO)
                If Not IsDeserializing Then
                    If Personas1 IsNot Nothing AndAlso Not Equals(Personas1.PER_ID, value) Then
                        Personas1 = Nothing
                    End If
                End If
                _pER_ID_AUTORIZADO = value
                OnPropertyChanged("PER_ID_AUTORIZADO")
            End If
        End Set
    End Property

    Private _pER_ID_AUTORIZADO As String

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
    Public Property ORR_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _oRR_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oRR_FEC_GRAB, value) Then
                _oRR_FEC_GRAB = value
                OnPropertyChanged("ORR_FEC_GRAB")
            End If
        End Set
    End Property

    Private _oRR_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property ORR_ESTADO() As Nullable(Of Boolean)
        Get
            Return _oRR_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_oRR_ESTADO, value) Then
                _oRR_ESTADO = value
                OnPropertyChanged("ORR_ESTADO")
            End If
        End Set
    End Property

    Private _oRR_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property ORR_FEC_RECIBIDO() As Nullable(Of Date)
        Get
            Return _oRR_FEC_RECIBIDO
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oRR_FEC_RECIBIDO, value) Then
                _oRR_FEC_RECIBIDO = value
                OnPropertyChanged("ORR_FEC_RECIBIDO")
            End If
        End Set
    End Property

    Private _oRR_FEC_RECIBIDO As Nullable(Of Date)

    <DataMember()>
    Public Property ORR_CERRADA() As Integer
        Get
            Return _oRR_CERRADA
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oRR_CERRADA, value) Then
                _oRR_CERRADA = value
                OnPropertyChanged("ORR_CERRADA")
            End If
        End Set
    End Property

    Private _oRR_CERRADA As Integer

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
    Public Property Personas1() As Personas
        Get
            Return _personas1
        End Get
        Set(ByVal value As Personas)
            If _personas1 IsNot value Then
                Dim previousValue As Personas = _personas1
                _personas1 = value
                FixupPersonas1(previousValue)
                OnNavigationPropertyChanged("Personas1")
            End If
        End Set
    End Property

    Private _personas1 As Personas


    <DataMember()>
    Public Property OrdenRequerimientoDetalle() As TrackableCollection(Of OrdenRequerimientoDetalle)
        Get
            If _ordenRequerimientoDetalle Is Nothing Then
                _ordenRequerimientoDetalle = New TrackableCollection(Of OrdenRequerimientoDetalle)
                AddHandler _ordenRequerimientoDetalle.CollectionChanged, AddressOf FixupOrdenRequerimientoDetalle
            End If
            Return _ordenRequerimientoDetalle
        End Get
        Set(ByVal value As TrackableCollection(Of OrdenRequerimientoDetalle))
            If Not Object.ReferenceEquals(_ordenRequerimientoDetalle, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _ordenRequerimientoDetalle IsNot Nothing Then
                    RemoveHandler _ordenRequerimientoDetalle.CollectionChanged, AddressOf FixupOrdenRequerimientoDetalle
                End If
                _ordenRequerimientoDetalle = value
                If _ordenRequerimientoDetalle IsNot Nothing Then
                    AddHandler _ordenRequerimientoDetalle.CollectionChanged, AddressOf FixupOrdenRequerimientoDetalle
                End If
                OnNavigationPropertyChanged("OrdenRequerimientoDetalle")
            End If
        End Set
    End Property

    Private _ordenRequerimientoDetalle As TrackableCollection(Of OrdenRequerimientoDetalle)

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
        Personas = Nothing
        Personas1 = Nothing
        OrdenRequerimientoDetalle.Clear()
        DocuMovimiento.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas IsNot Nothing Then
            PER_ID_SOLICITADO = Personas.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_SOLICITADO = Nothing
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

    Private Sub FixupPersonas1(ByVal previousValue As Personas, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Personas1 IsNot Nothing Then
            PER_ID_AUTORIZADO = Personas1.PER_ID
        ElseIf Not skipKeys Then
            PER_ID_AUTORIZADO = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Personas1") AndAlso
                ChangeTracker.OriginalValues("Personas1") Is Personas1 Then
                ChangeTracker.OriginalValues.Remove("Personas1")
            Else
                ChangeTracker.RecordOriginalValue("Personas1", previousValue)
            End If
            If Personas1 IsNot Nothing AndAlso Not Personas1.ChangeTracker.ChangeTrackingEnabled Then
                Personas1.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupOrdenRequerimientoDetalle(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As OrdenRequerimientoDetalle In e.NewItems
                item.ORR_ID = ORR_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("OrdenRequerimientoDetalle", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As OrdenRequerimientoDetalle In e.OldItems
                item.ORR_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("OrdenRequerimientoDetalle", item)
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
                item.ORR_ID = ORR_ID
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
                item.ORR_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("DocuMovimiento", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
