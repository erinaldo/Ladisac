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
<KnownType(GetType(Articulos))>
<KnownType(GetType(PlanMantto))>
Partial Public Class SuministroPlanMantto
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared SPM_ID As string = "SPM_ID"
				public shared PMO_ID As string = "PMO_ID"
				public shared ART_ID As string = "ART_ID"
				public shared SPM_CANTIDAD As string = "SPM_CANTIDAD"
		    End Structure
	



    <DataMember()>
    Public Property SPM_ID() As Integer
        Get
            Return _sPM_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_sPM_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'SPM_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _sPM_ID = value
                OnPropertyChanged("SPM_ID")
            End If
        End Set
    End Property

    Private _sPM_ID As Integer

    <DataMember()>
    Public Property PMO_ID() As Nullable(Of Integer)
        Get
            Return _pMO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pMO_ID, value) Then
                ChangeTracker.RecordOriginalValue("PMO_ID", _pMO_ID)
                If Not IsDeserializing Then
                    If PlanMantto IsNot Nothing AndAlso Not Equals(PlanMantto.PMO_ID, value) Then
                        PlanMantto = Nothing
                    End If
                End If
                _pMO_ID = value
                OnPropertyChanged("PMO_ID")
            End If
        End Set
    End Property

    Private _pMO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property ART_ID() As String
        Get
            Return _aRT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_aRT_ID, value) Then
                ChangeTracker.RecordOriginalValue("ART_ID", _aRT_ID)
                If Not IsDeserializing Then
                    If Articulos IsNot Nothing AndAlso Not Equals(Articulos.ART_ID, value) Then
                        Articulos = Nothing
                    End If
                End If
                _aRT_ID = value
                OnPropertyChanged("ART_ID")
            End If
        End Set
    End Property

    Private _aRT_ID As String

    <DataMember()>
    Public Property SPM_CANTIDAD() As Nullable(Of Decimal)
        Get
            Return _sPM_CANTIDAD
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_sPM_CANTIDAD, value) Then
                _sPM_CANTIDAD = value
                OnPropertyChanged("SPM_CANTIDAD")
            End If
        End Set
    End Property

    Private _sPM_CANTIDAD As Nullable(Of Decimal)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Articulos() As Articulos
        Get
            Return _articulos
        End Get
        Set(ByVal value As Articulos)
            If _articulos IsNot value Then
                Dim previousValue As Articulos = _articulos
                _articulos = value
                FixupArticulos(previousValue)
                OnNavigationPropertyChanged("Articulos")
            End If
        End Set
    End Property

    Private _articulos As Articulos


    <DataMember()>
    Public Property PlanMantto() As PlanMantto
        Get
            Return _planMantto
        End Get
        Set(ByVal value As PlanMantto)
            If _planMantto IsNot value Then
                Dim previousValue As PlanMantto = _planMantto
                _planMantto = value
                FixupPlanMantto(previousValue)
                OnNavigationPropertyChanged("PlanMantto")
            End If
        End Set
    End Property

    Private _planMantto As PlanMantto


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
        Articulos = Nothing
        PlanMantto = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupArticulos(ByVal previousValue As Articulos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Articulos IsNot Nothing Then
            ART_ID = Articulos.ART_ID
        ElseIf Not skipKeys Then
            ART_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Articulos") AndAlso
                ChangeTracker.OriginalValues("Articulos") Is Articulos Then
                ChangeTracker.OriginalValues.Remove("Articulos")
            Else
                ChangeTracker.RecordOriginalValue("Articulos", previousValue)
            End If
            If Articulos IsNot Nothing AndAlso Not Articulos.ChangeTracker.ChangeTrackingEnabled Then
                Articulos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupPlanMantto(ByVal previousValue As PlanMantto, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.SuministroPlanMantto.Contains(Me) Then
            previousValue.SuministroPlanMantto.Remove(Me)
        End If

        If PlanMantto IsNot Nothing Then
            If Not PlanMantto.SuministroPlanMantto.Contains(Me) Then
                PlanMantto.SuministroPlanMantto.Add(Me)
            End If

            PMO_ID = PlanMantto.PMO_ID
        ElseIf Not skipKeys Then
            PMO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("PlanMantto") AndAlso
                ChangeTracker.OriginalValues("PlanMantto") Is PlanMantto Then
                ChangeTracker.OriginalValues.Remove("PlanMantto")
            Else
                ChangeTracker.RecordOriginalValue("PlanMantto", previousValue)
            End If
            If PlanMantto IsNot Nothing AndAlso Not PlanMantto.ChangeTracker.ChangeTrackingEnabled Then
                PlanMantto.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class