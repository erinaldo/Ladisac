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
<KnownType(GetType(OrdenCompra))>
Partial Public Class OrdenCompraCuotas
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared OCC_ID As string = "OCC_ID"
				public shared OCO_ID As string = "OCO_ID"
				public shared OCC_NUMERO As string = "OCC_NUMERO"
				public shared OCC_DESCRIPCION As string = "OCC_DESCRIPCION"
				public shared OCC_FECHA_VENCIMIENTO As string = "OCC_FECHA_VENCIMIENTO"
				public shared OCC_MONTO As string = "OCC_MONTO"
		    End Structure
	



    <DataMember()>
    Public Property OCC_ID() As Integer
        Get
            Return _oCC_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_oCC_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'OCC_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _oCC_ID = value
                OnPropertyChanged("OCC_ID")
            End If
        End Set
    End Property

    Private _oCC_ID As Integer

    <DataMember()>
    Public Property OCO_ID() As Nullable(Of Integer)
        Get
            Return _oCO_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oCO_ID, value) Then
                ChangeTracker.RecordOriginalValue("OCO_ID", _oCO_ID)
                If Not IsDeserializing Then
                    If OrdenCompra IsNot Nothing AndAlso Not Equals(OrdenCompra.OCO_ID, value) Then
                        OrdenCompra = Nothing
                    End If
                End If
                _oCO_ID = value
                OnPropertyChanged("OCO_ID")
            End If
        End Set
    End Property

    Private _oCO_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OCC_NUMERO() As Nullable(Of Integer)
        Get
            Return _oCC_NUMERO
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oCC_NUMERO, value) Then
                _oCC_NUMERO = value
                OnPropertyChanged("OCC_NUMERO")
            End If
        End Set
    End Property

    Private _oCC_NUMERO As Nullable(Of Integer)

    <DataMember()>
    Public Property OCC_DESCRIPCION() As String
        Get
            Return _oCC_DESCRIPCION
        End Get
        Set(ByVal value As String)
            If Not Equals(_oCC_DESCRIPCION, value) Then
                _oCC_DESCRIPCION = value
                OnPropertyChanged("OCC_DESCRIPCION")
            End If
        End Set
    End Property

    Private _oCC_DESCRIPCION As String

    <DataMember()>
    Public Property OCC_FECHA_VENCIMIENTO() As Nullable(Of Date)
        Get
            Return _oCC_FECHA_VENCIMIENTO
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_oCC_FECHA_VENCIMIENTO, value) Then
                _oCC_FECHA_VENCIMIENTO = value
                OnPropertyChanged("OCC_FECHA_VENCIMIENTO")
            End If
        End Set
    End Property

    Private _oCC_FECHA_VENCIMIENTO As Nullable(Of Date)

    <DataMember()>
    Public Property OCC_MONTO() As Nullable(Of Decimal)
        Get
            Return _oCC_MONTO
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_oCC_MONTO, value) Then
                _oCC_MONTO = value
                OnPropertyChanged("OCC_MONTO")
            End If
        End Set
    End Property

    Private _oCC_MONTO As Nullable(Of Decimal)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property OrdenCompra() As OrdenCompra
        Get
            Return _ordenCompra
        End Get
        Set(ByVal value As OrdenCompra)
            If _ordenCompra IsNot value Then
                Dim previousValue As OrdenCompra = _ordenCompra
                _ordenCompra = value
                FixupOrdenCompra(previousValue)
                OnNavigationPropertyChanged("OrdenCompra")
            End If
        End Set
    End Property

    Private _ordenCompra As OrdenCompra


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
        OrdenCompra = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupOrdenCompra(ByVal previousValue As OrdenCompra, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.OrdenCompraCuotas.Contains(Me) Then
            previousValue.OrdenCompraCuotas.Remove(Me)
        End If

        If OrdenCompra IsNot Nothing Then
            If Not OrdenCompra.OrdenCompraCuotas.Contains(Me) Then
                OrdenCompra.OrdenCompraCuotas.Add(Me)
            End If

            OCO_ID = OrdenCompra.OCO_ID
        ElseIf Not skipKeys Then
            OCO_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("OrdenCompra") AndAlso
                ChangeTracker.OriginalValues("OrdenCompra") Is OrdenCompra Then
                ChangeTracker.OriginalValues.Remove("OrdenCompra")
            Else
                ChangeTracker.RecordOriginalValue("OrdenCompra", previousValue)
            End If
            If OrdenCompra IsNot Nothing AndAlso Not OrdenCompra.ChangeTracker.ChangeTrackingEnabled Then
                OrdenCompra.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
