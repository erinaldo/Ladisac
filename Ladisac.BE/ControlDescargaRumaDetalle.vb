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
<KnownType(GetType(ControlCarga))>
Partial Public Class ControlDescargaRumaDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DRD_ID As string = "DRD_ID"
				public shared DRU_ID As string = "DRU_ID"
				public shared CAR_ID As string = "CAR_ID"
				public shared LMA_ID As string = "LMA_ID"
				public shared DRD_TIPO As string = "DRD_TIPO"
				public shared DRD_CANT_NETA As string = "DRD_CANT_NETA"
				public shared DRD_MALOS As string = "DRD_MALOS"
				public shared DRD_ROTOS As string = "DRD_ROTOS"
				public shared DRD_RAJADOS As string = "DRD_RAJADOS"
				public shared DRD_RECOCHADOS As string = "DRD_RECOCHADOS"
				public shared DRD_DOBLADOS As string = "DRD_DOBLADOS"
				public shared DRD_BLANCOS As string = "DRD_BLANCOS"
				public shared DRD_OBSERVACIONES As string = "DRD_OBSERVACIONES"
		    End Structure
	



    <DataMember()>
    Public Property DRD_ID() As Integer
        Get
            Return _dRD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dRD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DRD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dRD_ID = value
                OnPropertyChanged("DRD_ID")
            End If
        End Set
    End Property

    Private _dRD_ID As Integer

    <DataMember()>
    Public Property DRU_ID() As Nullable(Of Integer)
        Get
            Return _dRU_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRU_ID, value) Then
                ChangeTracker.RecordOriginalValue("DRU_ID", _dRU_ID)
                _dRU_ID = value
                OnPropertyChanged("DRU_ID")
            End If
        End Set
    End Property

    Private _dRU_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property CAR_ID() As Nullable(Of Integer)
        Get
            Return _cAR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cAR_ID, value) Then
                ChangeTracker.RecordOriginalValue("CAR_ID", _cAR_ID)
                If Not IsDeserializing Then
                    If ControlCarga IsNot Nothing AndAlso Not Equals(ControlCarga.CAR_ID, value) Then
                        ControlCarga = Nothing
                    End If
                End If
                _cAR_ID = value
                OnPropertyChanged("CAR_ID")
            End If
        End Set
    End Property

    Private _cAR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property LMA_ID() As Nullable(Of Integer)
        Get
            Return _lMA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_lMA_ID, value) Then
                _lMA_ID = value
                OnPropertyChanged("LMA_ID")
            End If
        End Set
    End Property

    Private _lMA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_TIPO() As String
        Get
            Return _dRD_TIPO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dRD_TIPO, value) Then
                _dRD_TIPO = value
                OnPropertyChanged("DRD_TIPO")
            End If
        End Set
    End Property

    Private _dRD_TIPO As String

    <DataMember()>
    Public Property DRD_CANT_NETA() As Nullable(Of Integer)
        Get
            Return _dRD_CANT_NETA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_CANT_NETA, value) Then
                _dRD_CANT_NETA = value
                OnPropertyChanged("DRD_CANT_NETA")
            End If
        End Set
    End Property

    Private _dRD_CANT_NETA As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_MALOS() As Nullable(Of Integer)
        Get
            Return _dRD_MALOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_MALOS, value) Then
                _dRD_MALOS = value
                OnPropertyChanged("DRD_MALOS")
            End If
        End Set
    End Property

    Private _dRD_MALOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_ROTOS() As Nullable(Of Integer)
        Get
            Return _dRD_ROTOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_ROTOS, value) Then
                _dRD_ROTOS = value
                OnPropertyChanged("DRD_ROTOS")
            End If
        End Set
    End Property

    Private _dRD_ROTOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_RAJADOS() As Nullable(Of Integer)
        Get
            Return _dRD_RAJADOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_RAJADOS, value) Then
                _dRD_RAJADOS = value
                OnPropertyChanged("DRD_RAJADOS")
            End If
        End Set
    End Property

    Private _dRD_RAJADOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_RECOCHADOS() As Nullable(Of Integer)
        Get
            Return _dRD_RECOCHADOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_RECOCHADOS, value) Then
                _dRD_RECOCHADOS = value
                OnPropertyChanged("DRD_RECOCHADOS")
            End If
        End Set
    End Property

    Private _dRD_RECOCHADOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_DOBLADOS() As Nullable(Of Integer)
        Get
            Return _dRD_DOBLADOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_DOBLADOS, value) Then
                _dRD_DOBLADOS = value
                OnPropertyChanged("DRD_DOBLADOS")
            End If
        End Set
    End Property

    Private _dRD_DOBLADOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_BLANCOS() As Nullable(Of Integer)
        Get
            Return _dRD_BLANCOS
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_dRD_BLANCOS, value) Then
                _dRD_BLANCOS = value
                OnPropertyChanged("DRD_BLANCOS")
            End If
        End Set
    End Property

    Private _dRD_BLANCOS As Nullable(Of Integer)

    <DataMember()>
    Public Property DRD_OBSERVACIONES() As String
        Get
            Return _dRD_OBSERVACIONES
        End Get
        Set(ByVal value As String)
            If Not Equals(_dRD_OBSERVACIONES, value) Then
                _dRD_OBSERVACIONES = value
                OnPropertyChanged("DRD_OBSERVACIONES")
            End If
        End Set
    End Property

    Private _dRD_OBSERVACIONES As String

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ControlCarga() As ControlCarga
        Get
            Return _controlCarga
        End Get
        Set(ByVal value As ControlCarga)
            If _controlCarga IsNot value Then
                Dim previousValue As ControlCarga = _controlCarga
                _controlCarga = value
                FixupControlCarga(previousValue)
                OnNavigationPropertyChanged("ControlCarga")
            End If
        End Set
    End Property

    Private _controlCarga As ControlCarga


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
        ControlCarga = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupControlCarga(ByVal previousValue As ControlCarga, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If ControlCarga IsNot Nothing Then
            CAR_ID = ControlCarga.CAR_ID
        ElseIf Not skipKeys Then
            CAR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ControlCarga") AndAlso
                ChangeTracker.OriginalValues("ControlCarga") Is ControlCarga Then
                ChangeTracker.OriginalValues.Remove("ControlCarga")
            Else
                ChangeTracker.RecordOriginalValue("ControlCarga", previousValue)
            End If
            If ControlCarga IsNot Nothing AndAlso Not ControlCarga.ChangeTracker.ChangeTrackingEnabled Then
                ControlCarga.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
