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
<KnownType(GetType(Area))>
<KnownType(GetType(RegistroEquipo))>
<KnownType(GetType(Tarea))>
<KnownType(GetType(Cancha))>
Partial Public Class RegistroEquipoDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared RED_ID As string = "RED_ID"
				public shared REQ_ID As string = "REQ_ID"
				public shared ARE_ID As string = "ARE_ID"
				public shared TAR_ID As string = "TAR_ID"
				public shared RED_HI As string = "RED_HI"
				public shared RED_HF As string = "RED_HF"
				public shared RED_HOROI As string = "RED_HOROI"
				public shared RED_HOROF As string = "RED_HOROF"
				public shared RED_OBSERVACION As string = "RED_OBSERVACION"
				public shared CAN_ID As string = "CAN_ID"
		    End Structure
	



    <DataMember()>
    Public Property RED_ID() As Integer
        Get
            Return _rED_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_rED_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'RED_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _rED_ID = value
                OnPropertyChanged("RED_ID")
            End If
        End Set
    End Property

    Private _rED_ID As Integer

    <DataMember()>
    Public Property REQ_ID() As Nullable(Of Integer)
        Get
            Return _rEQ_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_rEQ_ID, value) Then
                ChangeTracker.RecordOriginalValue("REQ_ID", _rEQ_ID)
                If Not IsDeserializing Then
                    If RegistroEquipo IsNot Nothing AndAlso Not Equals(RegistroEquipo.REQ_ID, value) Then
                        RegistroEquipo = Nothing
                    End If
                End If
                _rEQ_ID = value
                OnPropertyChanged("REQ_ID")
            End If
        End Set
    End Property

    Private _rEQ_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ARE_ID() As Nullable(Of Integer)
        Get
            Return _aRE_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aRE_ID, value) Then
                ChangeTracker.RecordOriginalValue("ARE_ID", _aRE_ID)
                If Not IsDeserializing Then
                    If Area IsNot Nothing AndAlso Not Equals(Area.ARE_ID, value) Then
                        Area = Nothing
                    End If
                End If
                _aRE_ID = value
                OnPropertyChanged("ARE_ID")
            End If
        End Set
    End Property

    Private _aRE_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property TAR_ID() As Nullable(Of Integer)
        Get
            Return _tAR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_tAR_ID, value) Then
                ChangeTracker.RecordOriginalValue("TAR_ID", _tAR_ID)
                If Not IsDeserializing Then
                    If Tarea IsNot Nothing AndAlso Not Equals(Tarea.TAR_ID, value) Then
                        Tarea = Nothing
                    End If
                End If
                _tAR_ID = value
                OnPropertyChanged("TAR_ID")
            End If
        End Set
    End Property

    Private _tAR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property RED_HI() As Nullable(Of Decimal)
        Get
            Return _rED_HI
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_rED_HI, value) Then
                _rED_HI = value
                OnPropertyChanged("RED_HI")
            End If
        End Set
    End Property

    Private _rED_HI As Nullable(Of Decimal)

    <DataMember()>
    Public Property RED_HF() As Nullable(Of Decimal)
        Get
            Return _rED_HF
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_rED_HF, value) Then
                _rED_HF = value
                OnPropertyChanged("RED_HF")
            End If
        End Set
    End Property

    Private _rED_HF As Nullable(Of Decimal)

    <DataMember()>
    Public Property RED_HOROI() As Nullable(Of Decimal)
        Get
            Return _rED_HOROI
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_rED_HOROI, value) Then
                _rED_HOROI = value
                OnPropertyChanged("RED_HOROI")
            End If
        End Set
    End Property

    Private _rED_HOROI As Nullable(Of Decimal)

    <DataMember()>
    Public Property RED_HOROF() As Nullable(Of Decimal)
        Get
            Return _rED_HOROF
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_rED_HOROF, value) Then
                _rED_HOROF = value
                OnPropertyChanged("RED_HOROF")
            End If
        End Set
    End Property

    Private _rED_HOROF As Nullable(Of Decimal)

    <DataMember()>
    Public Property RED_OBSERVACION() As String
        Get
            Return _rED_OBSERVACION
        End Get
        Set(ByVal value As String)
            If Not Equals(_rED_OBSERVACION, value) Then
                _rED_OBSERVACION = value
                OnPropertyChanged("RED_OBSERVACION")
            End If
        End Set
    End Property

    Private _rED_OBSERVACION As String

    <DataMember()>
    Public Property CAN_ID() As Nullable(Of Integer)
        Get
            Return _cAN_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cAN_ID, value) Then
                ChangeTracker.RecordOriginalValue("CAN_ID", _cAN_ID)
                If Not IsDeserializing Then
                    If Cancha IsNot Nothing AndAlso Not Equals(Cancha.CAN_ID, value) Then
                        Cancha = Nothing
                    End If
                End If
                _cAN_ID = value
                OnPropertyChanged("CAN_ID")
            End If
        End Set
    End Property

    Private _cAN_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Area() As Area
        Get
            Return _area
        End Get
        Set(ByVal value As Area)
            If _area IsNot value Then
                Dim previousValue As Area = _area
                _area = value
                FixupArea(previousValue)
                OnNavigationPropertyChanged("Area")
            End If
        End Set
    End Property

    Private _area As Area


    <DataMember()>
    Public Property RegistroEquipo() As RegistroEquipo
        Get
            Return _registroEquipo
        End Get
        Set(ByVal value As RegistroEquipo)
            If _registroEquipo IsNot value Then
                Dim previousValue As RegistroEquipo = _registroEquipo
                _registroEquipo = value
                FixupRegistroEquipo(previousValue)
                OnNavigationPropertyChanged("RegistroEquipo")
            End If
        End Set
    End Property

    Private _registroEquipo As RegistroEquipo


    <DataMember()>
    Public Property Tarea() As Tarea
        Get
            Return _tarea
        End Get
        Set(ByVal value As Tarea)
            If _tarea IsNot value Then
                Dim previousValue As Tarea = _tarea
                _tarea = value
                FixupTarea(previousValue)
                OnNavigationPropertyChanged("Tarea")
            End If
        End Set
    End Property

    Private _tarea As Tarea


    <DataMember()>
    Public Property Cancha() As Cancha
        Get
            Return _cancha
        End Get
        Set(ByVal value As Cancha)
            If _cancha IsNot value Then
                Dim previousValue As Cancha = _cancha
                _cancha = value
                FixupCancha(previousValue)
                OnNavigationPropertyChanged("Cancha")
            End If
        End Set
    End Property

    Private _cancha As Cancha


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
        Area = Nothing
        RegistroEquipo = Nothing
        Tarea = Nothing
        Cancha = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArea(ByVal previousValue As Area, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RegistroEquipoDetalle.Contains(Me) Then
            previousValue.RegistroEquipoDetalle.Remove(Me)
        End If

        If Area IsNot Nothing Then
            If Not Area.RegistroEquipoDetalle.Contains(Me) Then
                Area.RegistroEquipoDetalle.Add(Me)
            End If

            ARE_ID = Area.ARE_ID
        ElseIf Not skipKeys Then
            ARE_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Area") AndAlso
                ChangeTracker.OriginalValues("Area") Is Area Then
                ChangeTracker.OriginalValues.Remove("Area")
            Else
                ChangeTracker.RecordOriginalValue("Area", previousValue)
            End If
            If Area IsNot Nothing AndAlso Not Area.ChangeTracker.ChangeTrackingEnabled Then
                Area.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupRegistroEquipo(ByVal previousValue As RegistroEquipo, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RegistroEquipoDetalle.Contains(Me) Then
            previousValue.RegistroEquipoDetalle.Remove(Me)
        End If

        If RegistroEquipo IsNot Nothing Then
            If Not RegistroEquipo.RegistroEquipoDetalle.Contains(Me) Then
                RegistroEquipo.RegistroEquipoDetalle.Add(Me)
            End If

            REQ_ID = RegistroEquipo.REQ_ID
        ElseIf Not skipKeys Then
            REQ_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("RegistroEquipo") AndAlso
                ChangeTracker.OriginalValues("RegistroEquipo") Is RegistroEquipo Then
                ChangeTracker.OriginalValues.Remove("RegistroEquipo")
            Else
                ChangeTracker.RecordOriginalValue("RegistroEquipo", previousValue)
            End If
            If RegistroEquipo IsNot Nothing AndAlso Not RegistroEquipo.ChangeTracker.ChangeTrackingEnabled Then
                RegistroEquipo.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupTarea(ByVal previousValue As Tarea, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RegistroEquipoDetalle.Contains(Me) Then
            previousValue.RegistroEquipoDetalle.Remove(Me)
        End If

        If Tarea IsNot Nothing Then
            If Not Tarea.RegistroEquipoDetalle.Contains(Me) Then
                Tarea.RegistroEquipoDetalle.Add(Me)
            End If

            TAR_ID = Tarea.TAR_ID
        ElseIf Not skipKeys Then
            TAR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Tarea") AndAlso
                ChangeTracker.OriginalValues("Tarea") Is Tarea Then
                ChangeTracker.OriginalValues.Remove("Tarea")
            Else
                ChangeTracker.RecordOriginalValue("Tarea", previousValue)
            End If
            If Tarea IsNot Nothing AndAlso Not Tarea.ChangeTracker.ChangeTrackingEnabled Then
                Tarea.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupCancha(ByVal previousValue As Cancha, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.RegistroEquipoDetalle.Contains(Me) Then
            previousValue.RegistroEquipoDetalle.Remove(Me)
        End If

        If Cancha IsNot Nothing Then
            If Not Cancha.RegistroEquipoDetalle.Contains(Me) Then
                Cancha.RegistroEquipoDetalle.Add(Me)
            End If

            CAN_ID = Cancha.CAN_ID
        ElseIf Not skipKeys Then
            CAN_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Cancha") AndAlso
                ChangeTracker.OriginalValues("Cancha") Is Cancha Then
                ChangeTracker.OriginalValues.Remove("Cancha")
            Else
                ChangeTracker.RecordOriginalValue("Cancha", previousValue)
            End If
            If Cancha IsNot Nothing AndAlso Not Cancha.ChangeTracker.ChangeTrackingEnabled Then
                Cancha.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
