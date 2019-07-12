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
Partial Public Class Extrusora
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared EXT_ID As string = "EXT_ID"
				public shared EXT_DESCRIPCION As string = "EXT_DESCRIPCION"
				public shared ENO_ID_EXTRUSORA As string = "ENO_ID_EXTRUSORA"
				public shared USU_ID As string = "USU_ID"
				public shared EXT_FEC_GRAB As string = "EXT_FEC_GRAB"
				public shared EXT_ESTADO As string = "EXT_ESTADO"
				public shared Fac_RendMin As string = "Fac_RendMin"
				public shared Fac_RendSatisf As string = "Fac_RendSatisf"
				public shared Fac_RendSobre As string = "Fac_RendSobre"
		    End Structure
	



    <DataMember()>
    Public Property EXT_ID() As Integer
        Get
            Return _eXT_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_eXT_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'EXT_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _eXT_ID = value
                OnPropertyChanged("EXT_ID")
            End If
        End Set
    End Property

    Private _eXT_ID As Integer

    <DataMember()>
    Public Property EXT_DESCRIPCION() As String
        Get
            Return _eXT_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_eXT_DESCRIPCION, value) Then
                _eXT_DESCRIPCION = value
                OnPropertyChanged("EXT_DESCRIPCION")
            End If
        End Set
    End Property

    Private _eXT_DESCRIPCION As String

    <DataMember()>
    Public Property ENO_ID_EXTRUSORA() As Nullable(Of Integer)
        Get
            Return _eNO_ID_EXTRUSORA
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_eNO_ID_EXTRUSORA, value) Then
                _eNO_ID_EXTRUSORA = value
                OnPropertyChanged("ENO_ID_EXTRUSORA")
            End If
        End Set
    End Property

    Private _eNO_ID_EXTRUSORA As Nullable(Of Integer)

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
    Public Property EXT_FEC_GRAB() As Nullable(Of Date)
        Get
            Return _eXT_FEC_GRAB
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_eXT_FEC_GRAB, value) Then
                _eXT_FEC_GRAB = value
                OnPropertyChanged("EXT_FEC_GRAB")
            End If
        End Set
    End Property

    Private _eXT_FEC_GRAB As Nullable(Of Date)

    <DataMember()>
    Public Property EXT_ESTADO() As Nullable(Of Boolean)
        Get
            Return _eXT_ESTADO
        End Get
        Set(ByVal value As Nullable(Of Boolean))
            If Not Equals(_eXT_ESTADO, value) Then
                _eXT_ESTADO = value
                OnPropertyChanged("EXT_ESTADO")
            End If
        End Set
    End Property

    Private _eXT_ESTADO As Nullable(Of Boolean)

    <DataMember()>
    Public Property Fac_RendMin() As Nullable(Of Decimal)
        Get
            Return _fac_RendMin
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_RendMin, value) Then
                _fac_RendMin = value
                OnPropertyChanged("Fac_RendMin")
            End If
        End Set
    End Property

    Private _fac_RendMin As Nullable(Of Decimal)

    <DataMember()>
    Public Property Fac_RendSatisf() As Nullable(Of Decimal)
        Get
            Return _fac_RendSatisf
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_RendSatisf, value) Then
                _fac_RendSatisf = value
                OnPropertyChanged("Fac_RendSatisf")
            End If
        End Set
    End Property

    Private _fac_RendSatisf As Nullable(Of Decimal)

    <DataMember()>
    Public Property Fac_RendSobre() As Nullable(Of Decimal)
        Get
            Return _fac_RendSobre
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_fac_RendSobre, value) Then
                _fac_RendSobre = value
                OnPropertyChanged("Fac_RendSobre")
            End If
        End Set
    End Property

    Private _fac_RendSobre As Nullable(Of Decimal)

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
    End Sub

#End Region
End Class
