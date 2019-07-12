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
<KnownType(GetType(Entidad))>
<KnownType(GetType(Mantto))>
Partial Public Class OrdenTrabajoEntidad
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared OTE_ID As string = "OTE_ID"
				public shared OTR_ID As string = "OTR_ID"
				public shared ENO_ID As string = "ENO_ID"
				public shared MTO_ID As string = "MTO_ID"
		    End Structure
	



    <DataMember()>
    Public Property OTE_ID() As Integer
        Get
            Return _oTE_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oTE_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'OTE_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _oTE_ID = value
                OnPropertyChanged("OTE_ID")
            End If
        End Set
    End Property

    Private _oTE_ID As Integer

    <DataMember()>
    Public Property OTR_ID() As Nullable(Of Integer)
        Get
            Return _oTR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oTR_ID, value) Then
                ChangeTracker.RecordOriginalValue("OTR_ID", _oTR_ID)
                _oTR_ID = value
                OnPropertyChanged("OTR_ID")
            End If
        End Set
    End Property

    Private _oTR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ENO_ID() As Nullable(Of Integer)
        Get
            Return _eNO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID, value) Then
                ChangeTracker.RecordOriginalValue("ENO_ID", _eNO_ID)
                If Not IsDeserializing Then
                    If Entidad IsNot Nothing AndAlso Not Equals(Entidad.ENO_ID, value) Then
                        Entidad = Nothing
                    End If
                End If
                _eNO_ID = value
                OnPropertyChanged("ENO_ID")
            End If
        End Set
    End Property

    Private _eNO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property MTO_ID() As Nullable(Of Integer)
        Get
            Return _mTO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_mTO_ID, value) Then
                ChangeTracker.RecordOriginalValue("MTO_ID", _mTO_ID)
                If Not IsDeserializing Then
                    If Mantto IsNot Nothing AndAlso Not Equals(Mantto.MTO_ID, value) Then
                        Mantto = Nothing
                    End If
                End If
                _mTO_ID = value
                OnPropertyChanged("MTO_ID")
            End If
        End Set
    End Property

    Private _mTO_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Entidad() As Entidad
        Get
            Return _entidad
        End Get
        Set(ByVal value As Entidad)
            If _entidad IsNot value Then
                Dim previousValue As Entidad = _entidad
                _entidad = value
                FixupEntidad(previousValue)
                OnNavigationPropertyChanged("Entidad")
            End If
        End Set
    End Property

    Private _entidad As Entidad


    <DataMember()>
    Public Property Mantto() As Mantto
        Get
            Return _mantto
        End Get
        Set(ByVal value As Mantto)
            If _mantto IsNot value Then
                Dim previousValue As Mantto = _mantto
                _mantto = value
                FixupMantto(previousValue)
                OnNavigationPropertyChanged("Mantto")
            End If
        End Set
    End Property

    Private _mantto As Mantto


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
        Entidad = Nothing
        Mantto = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupEntidad(ByVal previousValue As Entidad, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Entidad IsNot Nothing Then
            ENO_ID = Entidad.ENO_ID
        ElseIf Not skipKeys Then
            ENO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Entidad") AndAlso
                ChangeTracker.OriginalValues("Entidad") Is Entidad Then
                ChangeTracker.OriginalValues.Remove("Entidad")
            Else
                ChangeTracker.RecordOriginalValue("Entidad", previousValue)
            End If
            If Entidad IsNot Nothing AndAlso Not Entidad.ChangeTracker.ChangeTrackingEnabled Then
                Entidad.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupMantto(ByVal previousValue As Mantto, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Mantto IsNot Nothing Then
            MTO_ID = Mantto.MTO_ID
        ElseIf Not skipKeys Then
            MTO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Mantto") AndAlso
                ChangeTracker.OriginalValues("Mantto") Is Mantto Then
                ChangeTracker.OriginalValues.Remove("Mantto")
            Else
                ChangeTracker.RecordOriginalValue("Mantto", previousValue)
            End If
            If Mantto IsNot Nothing AndAlso Not Mantto.ChangeTracker.ChangeTrackingEnabled Then
                Mantto.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
