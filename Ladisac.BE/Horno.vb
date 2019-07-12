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
<KnownType(GetType(PuertaHorno))>
Partial Public Class Horno
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared HOR_ID As string = "HOR_ID"
				public shared HOR_DESCRIPCION As string = "HOR_DESCRIPCION"
				public shared HOR_DES_CORTA As string = "HOR_DES_CORTA"
				public shared ENO_ID_HORNO As string = "ENO_ID_HORNO"
				public shared USU_ID As string = "USU_ID"
				public shared HOR_FEC_GRAB As string = "HOR_FEC_GRAB"
				public shared HOR_ESTADO As string = "HOR_ESTADO"
				public shared Fac_CombHornoMin As string = "Fac_CombHornoMin"
				public shared Fac_CombHornoSatisf As string = "Fac_CombHornoSatisf"
				public shared Fac_CombHornoSobre As string = "Fac_CombHornoSobre"
		    End Structure
	



    <DataMember()>
    Public Property HOR_ID() As Integer
        Get
            Return _hOR_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_hOR_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'HOR_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _hOR_ID = value
                OnPropertyChanged("HOR_ID")
            End If
        End Set
    End Property

    Private _hOR_ID As Integer

    <DataMember()>
    Public Property HOR_DESCRIPCION() As String
        Get
            Return _hOR_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_hOR_DESCRIPCION, value) Then
                _hOR_DESCRIPCION = value
                OnPropertyChanged("HOR_DESCRIPCION")
            End If
        End Set
    End Property

    Private _hOR_DESCRIPCION As String

    <DataMember()>
    Public Property HOR_DES_CORTA() As String
        Get
            Return _hOR_DES_CORTA
        End Get
        Set(ByVal value As String)
            If Not Equals(_hOR_DES_CORTA, value) Then
                _hOR_DES_CORTA = value
                OnPropertyChanged("HOR_DES_CORTA")
            End If
        End Set
    End Property

    Private _hOR_DES_CORTA As String

    <DataMember()>
    Public Property ENO_ID_HORNO() As Nullable(Of Integer)
        Get
            Return _eNO_ID_HORNO
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID_HORNO, value) Then
                _eNO_ID_HORNO = value
                OnPropertyChanged("ENO_ID_HORNO")
            End If
        End Set
    End Property

    Private _eNO_ID_HORNO As Nullable(Of Integer)

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
    Public Property HOR_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _hOR_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_hOR_FEC_GRAB, value) Then
                _hOR_FEC_GRAB = value
                OnPropertyChanged("HOR_FEC_GRAB")
            End If
        End Set
    End Property

    Private _hOR_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property HOR_ESTADO() As Nullable(Of Boolean)
        Get
            Return _hOR_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_hOR_ESTADO, value) Then
                _hOR_ESTADO = value
                OnPropertyChanged("HOR_ESTADO")
            End If
        End Set
    End Property

    Private _hOR_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property Fac_CombHornoMin() As Nullable(Of Decimal)
        Get
            Return _fac_CombHornoMin
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_CombHornoMin, value) Then
                _fac_CombHornoMin = value
                OnPropertyChanged("Fac_CombHornoMin")
            End If
        End Set
    End Property

    Private _fac_CombHornoMin As Nullable(Of Decimal)

    <DataMember()>
    Public Property Fac_CombHornoSatisf() As Nullable(Of Decimal)
        Get
            Return _fac_CombHornoSatisf
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_CombHornoSatisf, value) Then
                _fac_CombHornoSatisf = value
                OnPropertyChanged("Fac_CombHornoSatisf")
            End If
        End Set
    End Property

    Private _fac_CombHornoSatisf As Nullable(Of Decimal)

    <DataMember()>
    Public Property Fac_CombHornoSobre() As Nullable(Of Decimal)
        Get
            Return _fac_CombHornoSobre
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_CombHornoSobre, value) Then
                _fac_CombHornoSobre = value
                OnPropertyChanged("Fac_CombHornoSobre")
            End If
        End Set
    End Property

    Private _fac_CombHornoSobre As Nullable(Of Decimal)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property PuertaHorno() As TrackableCollection(Of PuertaHorno)
        Get
            If _puertaHorno Is Nothing Then
                _puertaHorno = New TrackableCollection(Of PuertaHorno)
                AddHandler _puertaHorno.CollectionChanged, AddressOf FixupPuertaHorno
            End If
            Return _puertaHorno
        End Get
        Set(ByVal value As TrackableCollection(Of PuertaHorno))
            If Not Object.ReferenceEquals(_puertaHorno, value) Then
                If ChangeTracker.ChangeTrackingEnabled Then
                    Throw New InvalidOperationException("No se puede establecer el elemento FixupChangeTrackingCollection cuando se ha habilitado ChangeTracking")
                End If
                If _puertaHorno IsNot Nothing Then
                    RemoveHandler _puertaHorno.CollectionChanged, AddressOf FixupPuertaHorno
                End If
                _puertaHorno = value
                If _puertaHorno IsNot Nothing Then
                    AddHandler _puertaHorno.CollectionChanged, AddressOf FixupPuertaHorno
                End If
                OnNavigationPropertyChanged("PuertaHorno")
            End If
        End Set
    End Property

    Private _puertaHorno As TrackableCollection(Of PuertaHorno)

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
        PuertaHorno.Clear()
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPuertaHorno(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs)
        If IsDeserializing Then
            Return
        End If

        If e.NewItems IsNot Nothing Then
            For Each item As PuertaHorno In e.NewItems
                item.HOR_ID = HOR_ID
                If ChangeTracker.ChangeTrackingEnabled Then
                    If Not item.ChangeTracker.ChangeTrackingEnabled Then
                        item.StartTracking()
                    End If
                    ChangeTracker.RecordAdditionToCollectionProperties("PuertaHorno", item)
                End If
            Next
        End If

        If e.OldItems IsNot Nothing Then
            For Each item As PuertaHorno In e.OldItems
                item.HOR_ID = Nothing
                If ChangeTracker.ChangeTrackingEnabled Then
                    ChangeTracker.RecordRemovalFromCollectionProperties("PuertaHorno", item)
                End If
            Next
        End If
    End Sub

#End Region
End Class
