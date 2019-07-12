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
<KnownType(GetType(SolicitudSoporte))>
Partial Public Class SolicitudSoporteDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared SSD_ID As string = "SSD_ID"
				public shared SOS_ID As string = "SOS_ID"
				public shared SSD_MENSAJE As string = "SSD_MENSAJE"
				public shared SSD_FECHA As string = "SSD_FECHA"
		    End Structure
	



    <DataMember()>
    Public Property SSD_ID() As Integer
        Get
            Return _sSD_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_sSD_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'SSD_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _sSD_ID = value
                OnPropertyChanged("SSD_ID")
            End If
        End Set
    End Property

    Private _sSD_ID As Integer

    <DataMember()>
    Public Property SOS_ID() As Nullable(Of Integer)
        Get
            Return _sOS_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_sOS_ID, value) Then
                ChangeTracker.RecordOriginalValue("SOS_ID", _sOS_ID)
                If Not IsDeserializing Then
                    If SolicitudSoporte IsNot Nothing AndAlso Not Equals(SolicitudSoporte.SOS_ID, value) Then
                        SolicitudSoporte = Nothing
                    End If
                End If
                _sOS_ID = value
                OnPropertyChanged("SOS_ID")
            End If
        End Set
    End Property

    Private _sOS_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property SSD_MENSAJE() As String
        Get
            Return _sSD_MENSAJE
        End Get
        Set(ByVal value As String)
            If Not Equals(_sSD_MENSAJE, value) Then
                _sSD_MENSAJE = value
                OnPropertyChanged("SSD_MENSAJE")
            End If
        End Set
    End Property

    Private _sSD_MENSAJE As String

    <DataMember()>
    Public Property SSD_FECHA() As Nullable(Of Date)
        Get
            Return _sSD_FECHA
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_sSD_FECHA, value) Then
                _sSD_FECHA = value
                OnPropertyChanged("SSD_FECHA")
            End If
        End Set
    End Property

    Private _sSD_FECHA As Nullable(Of Date)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property SolicitudSoporte() As SolicitudSoporte
        Get
            Return _solicitudSoporte
        End Get
        Set(ByVal value As SolicitudSoporte)
            If _solicitudSoporte IsNot value Then
                Dim previousValue As SolicitudSoporte = _solicitudSoporte
                _solicitudSoporte = value
                FixupSolicitudSoporte(previousValue)
                OnNavigationPropertyChanged("SolicitudSoporte")
            End If
        End Set
    End Property

    Private _solicitudSoporte As SolicitudSoporte


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
        SolicitudSoporte = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupSolicitudSoporte(ByVal previousValue As SolicitudSoporte, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.SolicitudSoporteDetalle.Contains(Me) Then
            previousValue.SolicitudSoporteDetalle.Remove(Me)
        End If

        If SolicitudSoporte IsNot Nothing Then
            If Not SolicitudSoporte.SolicitudSoporteDetalle.Contains(Me) Then
                SolicitudSoporte.SolicitudSoporteDetalle.Add(Me)
            End If

            SOS_ID = SolicitudSoporte.SOS_ID
        ElseIf Not skipKeys Then
            SOS_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("SolicitudSoporte") AndAlso
                ChangeTracker.OriginalValues("SolicitudSoporte") Is SolicitudSoporte Then
                ChangeTracker.OriginalValues.Remove("SolicitudSoporte")
            Else
                ChangeTracker.RecordOriginalValue("SolicitudSoporte", previousValue)
            End If
            If SolicitudSoporte IsNot Nothing AndAlso Not SolicitudSoporte.ChangeTracker.ChangeTrackingEnabled Then
                SolicitudSoporte.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class