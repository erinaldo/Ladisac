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
<KnownType(GetType(UnidadesTransporte))>
<KnownType(GetType(Entidad))>
<KnownType(GetType(PlanCargaDescargaHorno))>
Partial Public Class CargaDescargaTransporte
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared CDT_ID As string = "CDT_ID"
				public shared CDH_ID As string = "CDH_ID"
				public shared PER_ID_EMPRESA As string = "PER_ID_EMPRESA"
				public shared UNT_ID As string = "UNT_ID"
				public shared CDT_ORIGEN_DESTINO As string = "CDT_ORIGEN_DESTINO"
				public shared ENO_ID_ORIDES As string = "ENO_ID_ORIDES"
				public shared CDT_HI As string = "CDT_HI"
				public shared CDT_HF As string = "CDT_HF"
				public shared CDT_TIPO As string = "CDT_TIPO"
				public shared CDT_FEC_GRAB As string = "CDT_FEC_GRAB"
				public shared CDT_NRO_MALE As string = "CDT_NRO_MALE"
		    End Structure
	



    <DataMember()>
    Public Property CDT_ID() As Integer
        Get
            Return _cDT_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cDT_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'CDT_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _cDT_ID = value
                OnPropertyChanged("CDT_ID")
            End If
        End Set
    End Property

    Private _cDT_ID As Integer

    <DataMember()>
    Public Property CDH_ID() As Integer
        Get
            Return _cDH_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_cDH_ID, value) Then
                ChangeTracker.RecordOriginalValue("CDH_ID", _cDH_ID)
                If Not IsDeserializing Then
                    If PlanCargaDescargaHorno IsNot Nothing AndAlso Not Equals(PlanCargaDescargaHorno.CDH_ID, value) Then
                        PlanCargaDescargaHorno = Nothing
                    End If
                End If
                _cDH_ID = value
                OnPropertyChanged("CDH_ID")
            End If
        End Set
    End Property

    Private _cDH_ID As Integer

    <DataMember()>
    Public Property PER_ID_EMPRESA() As String
        Get
            Return _pER_ID_EMPRESA
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_EMPRESA, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID_EMPRESA", _pER_ID_EMPRESA)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID_EMPRESA = value
                OnPropertyChanged("PER_ID_EMPRESA")
            End If
        End Set
    End Property

    Private _pER_ID_EMPRESA As String

    <DataMember()>
    Public Property UNT_ID() As String
        Get
            Return _uNT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_uNT_ID, value) Then
                ChangeTracker.RecordOriginalValue("UNT_ID", _uNT_ID)
                If Not IsDeserializing Then
                    If UnidadesTransporte IsNot Nothing AndAlso Not Equals(UnidadesTransporte.UNT_ID, value) Then
                        UnidadesTransporte = Nothing
                    End If
                End If
                _uNT_ID = value
                OnPropertyChanged("UNT_ID")
            End If
        End Set
    End Property

    Private _uNT_ID As String

    <DataMember()>
    Public Property CDT_ORIGEN_DESTINO() As String
        Get
            Return _cDT_ORIGEN_DESTINO
        End Get
        Set(ByVal value As String)
            If Not Equals(_cDT_ORIGEN_DESTINO, value) Then
                _cDT_ORIGEN_DESTINO = value
                OnPropertyChanged("CDT_ORIGEN_DESTINO")
            End If
        End Set
    End Property

    Private _cDT_ORIGEN_DESTINO As String

    <DataMember()>
    Public Property ENO_ID_ORIDES() As Integer
        Get
            Return _eNO_ID_ORIDES
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_eNO_ID_ORIDES, value) Then
                ChangeTracker.RecordOriginalValue("ENO_ID_ORIDES", _eNO_ID_ORIDES)
                If Not IsDeserializing Then
                    If Entidad IsNot Nothing AndAlso Not Equals(Entidad.ENO_ID, value) Then
                        Entidad = Nothing
                    End If
                End If
                _eNO_ID_ORIDES = value
                OnPropertyChanged("ENO_ID_ORIDES")
            End If
        End Set
    End Property

    Private _eNO_ID_ORIDES As Integer

    <DataMember()>
    Public Property CDT_HI() As Decimal
        Get
            Return _cDT_HI
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_cDT_HI, value) Then
                _cDT_HI = value
                OnPropertyChanged("CDT_HI")
            End If
        End Set
    End Property

    Private _cDT_HI As Decimal

    <DataMember()>
    Public Property CDT_HF() As Decimal
        Get
            Return _cDT_HF
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_cDT_HF, value) Then
                _cDT_HF = value
                OnPropertyChanged("CDT_HF")
            End If
        End Set
    End Property

    Private _cDT_HF As Decimal

    <DataMember()>
    Public Property CDT_TIPO() As String
        Get
            Return _cDT_TIPO
        End Get
        Set(ByVal value As String)
            If Not Equals(_cDT_TIPO, value) Then
                _cDT_TIPO = value
                OnPropertyChanged("CDT_TIPO")
            End If
        End Set
    End Property

    Private _cDT_TIPO As String

    <DataMember()>
    Public Property CDT_FEC_GRAB() As Date
        Get
            Return _cDT_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_cDT_FEC_GRAB, value) Then
                _cDT_FEC_GRAB = value
                OnPropertyChanged("CDT_FEC_GRAB")
            End If
        End Set
    End Property

    Private _cDT_FEC_GRAB As Date

    <DataMember()>
    Public Property CDT_NRO_MALE() As String
        Get
            Return _cDT_NRO_MALE
        End Get
        Set(ByVal value As String)
            If Not Equals(_cDT_NRO_MALE, value) Then
                _cDT_NRO_MALE = value
                OnPropertyChanged("CDT_NRO_MALE")
            End If
        End Set
    End Property

    Private _cDT_NRO_MALE As String

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
    Public Property UnidadesTransporte() As UnidadesTransporte
        Get
            Return _unidadesTransporte
        End Get
        Set(ByVal value As UnidadesTransporte)
            If _unidadesTransporte IsNot value Then
                Dim previousValue As UnidadesTransporte = _unidadesTransporte
                _unidadesTransporte = value
                FixupUnidadesTransporte(previousValue)
                OnNavigationPropertyChanged("UnidadesTransporte")
            End If
        End Set
    End Property

    Private _unidadesTransporte As UnidadesTransporte


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
    Public Property PlanCargaDescargaHorno() As PlanCargaDescargaHorno
        Get
            Return _planCargaDescargaHorno
        End Get
        Set(ByVal value As PlanCargaDescargaHorno)
            If _planCargaDescargaHorno IsNot value Then
                Dim previousValue As PlanCargaDescargaHorno = _planCargaDescargaHorno
                _planCargaDescargaHorno = value
                FixupPlanCargaDescargaHorno(previousValue)
                OnNavigationPropertyChanged("PlanCargaDescargaHorno")
            End If
        End Set
    End Property

    Private _planCargaDescargaHorno As PlanCargaDescargaHorno


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
        UnidadesTransporte = Nothing
        Entidad = Nothing
        PlanCargaDescargaHorno = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.CargaDescargaTransporte.Contains(Me) Then
            previousValue.CargaDescargaTransporte.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.CargaDescargaTransporte.Contains(Me) Then
                Personas.CargaDescargaTransporte.Add(Me)
            End If

            PER_ID_EMPRESA = Personas.PER_ID
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

    Private Sub FixupUnidadesTransporte(ByVal previousValue As UnidadesTransporte)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.CargaDescargaTransporte.Contains(Me) Then
            previousValue.CargaDescargaTransporte.Remove(Me)
        End If

        If UnidadesTransporte IsNot Nothing Then
            If Not UnidadesTransporte.CargaDescargaTransporte.Contains(Me) Then
                UnidadesTransporte.CargaDescargaTransporte.Add(Me)
            End If

            UNT_ID = UnidadesTransporte.UNT_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("UnidadesTransporte") AndAlso
                ChangeTracker.OriginalValues("UnidadesTransporte") Is UnidadesTransporte Then
                ChangeTracker.OriginalValues.Remove("UnidadesTransporte")
            Else
                ChangeTracker.RecordOriginalValue("UnidadesTransporte", previousValue)
            End If
            If UnidadesTransporte IsNot Nothing AndAlso Not UnidadesTransporte.ChangeTracker.ChangeTrackingEnabled Then
                UnidadesTransporte.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupEntidad(ByVal previousValue As Entidad)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.CargaDescargaTransporte.Contains(Me) Then
            previousValue.CargaDescargaTransporte.Remove(Me)
        End If

        If Entidad IsNot Nothing Then
            If Not Entidad.CargaDescargaTransporte.Contains(Me) Then
                Entidad.CargaDescargaTransporte.Add(Me)
            End If

            ENO_ID_ORIDES = Entidad.ENO_ID
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

    Private Sub FixupPlanCargaDescargaHorno(ByVal previousValue As PlanCargaDescargaHorno)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.CargaDescargaTransporte.Contains(Me) Then
            previousValue.CargaDescargaTransporte.Remove(Me)
        End If

        If PlanCargaDescargaHorno IsNot Nothing Then
            If Not PlanCargaDescargaHorno.CargaDescargaTransporte.Contains(Me) Then
                PlanCargaDescargaHorno.CargaDescargaTransporte.Add(Me)
            End If

            CDH_ID = PlanCargaDescargaHorno.CDH_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("PlanCargaDescargaHorno") AndAlso
                ChangeTracker.OriginalValues("PlanCargaDescargaHorno") Is PlanCargaDescargaHorno Then
                ChangeTracker.OriginalValues.Remove("PlanCargaDescargaHorno")
            Else
                ChangeTracker.RecordOriginalValue("PlanCargaDescargaHorno", previousValue)
            End If
            If PlanCargaDescargaHorno IsNot Nothing AndAlso Not PlanCargaDescargaHorno.ChangeTracker.ChangeTrackingEnabled Then
                PlanCargaDescargaHorno.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
