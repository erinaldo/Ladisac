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
<KnownType(GetType(ActivosFijos))>
<KnownType(GetType(DepartamentosAdministrativos))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(Personas))>
Partial Public Class Asignaciones
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared ASG_ID As string = "ASG_ID"
				public shared ASG_FECHA As string = "ASG_FECHA"
				public shared ACF_ID As string = "ACF_ID"
				public shared ACF_COR_INCIDENCIA As string = "ACF_COR_INCIDENCIA"
				public shared DEA_ID As string = "DEA_ID"
				public shared PER_ID As string = "PER_ID"
				public shared USU_ID As string = "USU_ID"
				public shared ASG_FEC_GRAB As string = "ASG_FEC_GRAB"
				public shared ASG_ESTADO As string = "ASG_ESTADO"
		    End Structure
	



    <DataMember()>
    Public Property ASG_ID() As String
        Get
            Return _aSG_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aSG_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ASG_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _aSG_ID = value
                OnPropertyChanged("ASG_ID")
            End If
        End Set
    End Property

    Private _aSG_ID As String

    <DataMember()>
    Public Property ASG_FECHA() As Date
        Get
            Return _aSG_FECHA
        End Get
        Set(ByVal value As Date)
            If Not Equals(_aSG_FECHA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ASG_FECHA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _aSG_FECHA = value
                OnPropertyChanged("ASG_FECHA")
            End If
        End Set
    End Property

    Private _aSG_FECHA As Date

    <DataMember()>
    Public Property ACF_ID() As String
        Get
            Return _aCF_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aCF_ID, value) Then
                ChangeTracker.RecordOriginalValue("ACF_ID", _aCF_ID)
                If Not IsDeserializing Then
                    If ActivosFijos IsNot Nothing AndAlso Not Equals(ActivosFijos.ACF_ID, value) Then
                        ActivosFijos = Nothing
                    End If
                End If
                _aCF_ID = value
                OnPropertyChanged("ACF_ID")
            End If
        End Set
    End Property

    Private _aCF_ID As String

    <DataMember()>
    Public Property ACF_COR_INCIDENCIA() As Decimal
        Get
            Return _aCF_COR_INCIDENCIA
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_aCF_COR_INCIDENCIA, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ACF_COR_INCIDENCIA' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                If Not IsDeserializing Then
                    If ActivosFijos IsNot Nothing AndAlso Not Equals(ActivosFijos.ACF_COR_INCIDENCIA, value) Then
                        ActivosFijos = Nothing
                    End If
                End If
                _aCF_COR_INCIDENCIA = value
                OnPropertyChanged("ACF_COR_INCIDENCIA")
            End If
        End Set
    End Property

    Private _aCF_COR_INCIDENCIA As Decimal

    <DataMember()>
    Public Property DEA_ID() As String
        Get
            Return _dEA_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dEA_ID, value) Then
                ChangeTracker.RecordOriginalValue("DEA_ID", _dEA_ID)
                If Not IsDeserializing Then
                    If DepartamentosAdministrativos IsNot Nothing AndAlso Not Equals(DepartamentosAdministrativos.DEA_ID, value) Then
                        DepartamentosAdministrativos = Nothing
                    End If
                End If
                _dEA_ID = value
                OnPropertyChanged("DEA_ID")
            End If
        End Set
    End Property

    Private _dEA_ID As String

    <DataMember()>
    Public Property PER_ID() As String
        Get
            Return _pER_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID, value) Then
                ChangeTracker.RecordOriginalValue("PER_ID", _pER_ID)
                If Not IsDeserializing Then
                    If Personas IsNot Nothing AndAlso Not Equals(Personas.PER_ID, value) Then
                        Personas = Nothing
                    End If
                End If
                _pER_ID = value
                OnPropertyChanged("PER_ID")
            End If
        End Set
    End Property

    Private _pER_ID As String

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
    Public Property ASG_FEC_GRAB() As Date
        Get
            Return _aSG_FEC_GRAB
        End Get
        Set(ByVal value As Date)
            If Not Equals(_aSG_FEC_GRAB, value) Then
                _aSG_FEC_GRAB = value
                OnPropertyChanged("ASG_FEC_GRAB")
            End If
        End Set
    End Property

    Private _aSG_FEC_GRAB As Date

    <DataMember()>
    Public Property ASG_ESTADO() As Boolean
        Get
            Return _aSG_ESTADO
        End Get
        Set(ByVal value As Boolean)
            If Not Equals(_aSG_ESTADO, value) Then
                _aSG_ESTADO = value
                OnPropertyChanged("ASG_ESTADO")
            End If
        End Set
    End Property

    Private _aSG_ESTADO As Boolean

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ActivosFijos() As ActivosFijos
        Get
            Return _activosFijos
        End Get
        Set(ByVal value As ActivosFijos)
            If _activosFijos IsNot value Then
                Dim previousValue As ActivosFijos = _activosFijos
                _activosFijos = value
                FixupActivosFijos(previousValue)
                OnNavigationPropertyChanged("ActivosFijos")
            End If
        End Set
    End Property

    Private _activosFijos As ActivosFijos


    <DataMember()>
    Public Property DepartamentosAdministrativos() As DepartamentosAdministrativos
        Get
            Return _departamentosAdministrativos
        End Get
        Set(ByVal value As DepartamentosAdministrativos)
            If _departamentosAdministrativos IsNot value Then
                Dim previousValue As DepartamentosAdministrativos = _departamentosAdministrativos
                _departamentosAdministrativos = value
                FixupDepartamentosAdministrativos(previousValue)
                OnNavigationPropertyChanged("DepartamentosAdministrativos")
            End If
        End Set
    End Property

    Private _departamentosAdministrativos As DepartamentosAdministrativos


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
        ActivosFijos = Nothing
        DepartamentosAdministrativos = Nothing
        Usuarios = Nothing
        Personas = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupActivosFijos(ByVal previousValue As ActivosFijos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Asignaciones.Contains(Me) Then
            previousValue.Asignaciones.Remove(Me)
        End If

        If ActivosFijos IsNot Nothing Then
            If Not ActivosFijos.Asignaciones.Contains(Me) Then
                ActivosFijos.Asignaciones.Add(Me)
            End If

            ACF_ID = ActivosFijos.ACF_ID
            ACF_COR_INCIDENCIA = ActivosFijos.ACF_COR_INCIDENCIA
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ActivosFijos") AndAlso
                ChangeTracker.OriginalValues("ActivosFijos") Is ActivosFijos Then
                ChangeTracker.OriginalValues.Remove("ActivosFijos")
            Else
                ChangeTracker.RecordOriginalValue("ActivosFijos", previousValue)
            End If
            If ActivosFijos IsNot Nothing AndAlso Not ActivosFijos.ChangeTracker.ChangeTrackingEnabled Then
                ActivosFijos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupDepartamentosAdministrativos(ByVal previousValue As DepartamentosAdministrativos)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Asignaciones.Contains(Me) Then
            previousValue.Asignaciones.Remove(Me)
        End If

        If DepartamentosAdministrativos IsNot Nothing Then
            If Not DepartamentosAdministrativos.Asignaciones.Contains(Me) Then
                DepartamentosAdministrativos.Asignaciones.Add(Me)
            End If

            DEA_ID = DepartamentosAdministrativos.DEA_ID
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("DepartamentosAdministrativos") AndAlso
                ChangeTracker.OriginalValues("DepartamentosAdministrativos") Is DepartamentosAdministrativos Then
                ChangeTracker.OriginalValues.Remove("DepartamentosAdministrativos")
            Else
                ChangeTracker.RecordOriginalValue("DepartamentosAdministrativos", previousValue)
            End If
            If DepartamentosAdministrativos IsNot Nothing AndAlso Not DepartamentosAdministrativos.ChangeTracker.ChangeTrackingEnabled Then
                DepartamentosAdministrativos.StartTracking()
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

    Private Sub FixupPersonas(ByVal previousValue As Personas)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.Asignaciones.Contains(Me) Then
            previousValue.Asignaciones.Remove(Me)
        End If

        If Personas IsNot Nothing Then
            If Not Personas.Asignaciones.Contains(Me) Then
                Personas.Asignaciones.Add(Me)
            End If

            PER_ID = Personas.PER_ID
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

#End Region
End Class