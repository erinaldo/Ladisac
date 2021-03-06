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
<KnownType(GetType(ClaseCuenta))>
<KnownType(GetType(Almacen))>
<KnownType(GetType(CentroCostos))>
<KnownType(GetType(Usuarios))>
<KnownType(GetType(CuentasContables))>
Partial Public Class DetalleProvisionCompras
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared prd_Periodo_id As string = "prd_Periodo_id"
				public shared prc_Voucher As string = "prc_Voucher"
				public shared lib_Id As string = "lib_Id"
				public shared prd_Item As string = "prd_Item"
				public shared prd_Importe As string = "prd_Importe"
				public shared cuc_Id As string = "cuc_Id"
				public shared cco_Id As string = "cco_Id"
				public shared prd_Glosa As string = "prd_Glosa"
				public shared cls_Id As string = "cls_Id"
				public shared Usu_Id As string = "Usu_Id"
				public shared prd_FecGrab As string = "prd_FecGrab"
				public shared ALM_ID As string = "ALM_ID"
				public shared OTR_ID As string = "OTR_ID"
		    End Structure
	



    <DataMember()>
    Public Property prd_Periodo_id() As String
        Get
            Return _prd_Periodo_id
        End Get
        Set(ByVal value As String)
            If Not Equals(_prd_Periodo_id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prd_Periodo_id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prd_Periodo_id = value
                OnPropertyChanged("prd_Periodo_id")
            End If
        End Set
    End Property

    Private _prd_Periodo_id As String

    <DataMember()>
    Public Property prc_Voucher() As String
        Get
            Return _prc_Voucher
        End Get
        Set(ByVal value As String)
            If Not Equals(_prc_Voucher, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prc_Voucher' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prc_Voucher = value
                OnPropertyChanged("prc_Voucher")
            End If
        End Set
    End Property

    Private _prc_Voucher As String

    <DataMember()>
    Public Property lib_Id() As String
        Get
            Return _lib_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_lib_Id, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'lib_Id' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _lib_Id = value
                OnPropertyChanged("lib_Id")
            End If
        End Set
    End Property

    Private _lib_Id As String

    <DataMember()>
    Public Property prd_Item() As String
        Get
            Return _prd_Item
        End Get
        Set(ByVal value As String)
            If Not Equals(_prd_Item, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'prd_Item' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _prd_Item = value
                OnPropertyChanged("prd_Item")
            End If
        End Set
    End Property

    Private _prd_Item As String

    <DataMember()>
    Public Property prd_Importe() As Nullable(Of Decimal)
        Get
            Return _prd_Importe
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_prd_Importe, value) Then
                _prd_Importe = value
                OnPropertyChanged("prd_Importe")
            End If
        End Set
    End Property

    Private _prd_Importe As Nullable(Of Decimal)

    <DataMember()>
    Public Property cuc_Id() As String
        Get
            Return _cuc_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_cuc_Id, value) Then
                ChangeTracker.RecordOriginalValue("cuc_Id", _cuc_Id)
                If Not IsDeserializing Then
                    If CuentasContables IsNot Nothing AndAlso Not Equals(CuentasContables.CUC_ID, value) Then
                        CuentasContables = Nothing
                    End If
                End If
                _cuc_Id = value
                OnPropertyChanged("cuc_Id")
            End If
        End Set
    End Property

    Private _cuc_Id As String

    <DataMember()>
    Public Property cco_Id() As String
        Get
            Return _cco_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_cco_Id, value) Then
                ChangeTracker.RecordOriginalValue("cco_Id", _cco_Id)
                If Not IsDeserializing Then
                    If CentroCostos IsNot Nothing AndAlso Not Equals(CentroCostos.CCO_ID, value) Then
                        CentroCostos = Nothing
                    End If
                End If
                _cco_Id = value
                OnPropertyChanged("cco_Id")
            End If
        End Set
    End Property

    Private _cco_Id As String

    <DataMember()>
    Public Property prd_Glosa() As String
        Get
            Return _prd_Glosa
        End Get
        Set(ByVal value As String)
            If Not Equals(_prd_Glosa, value) Then
                _prd_Glosa = value
                OnPropertyChanged("prd_Glosa")
            End If
        End Set
    End Property

    Private _prd_Glosa As String

    <DataMember()>
    Public Property cls_Id() As String
        Get
            Return _cls_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_cls_Id, value) Then
                ChangeTracker.RecordOriginalValue("cls_Id", _cls_Id)
                If Not IsDeserializing Then
                    If ClaseCuenta IsNot Nothing AndAlso Not Equals(ClaseCuenta.cls_Id, value) Then
                        ClaseCuenta = Nothing
                    End If
                End If
                _cls_Id = value
                OnPropertyChanged("cls_Id")
            End If
        End Set
    End Property

    Private _cls_Id As String

    <DataMember()>
    Public Property Usu_Id() As String
        Get
            Return _usu_Id
        End Get
        Set(ByVal value As String)
            If Not Equals(_usu_Id, value) Then
                ChangeTracker.RecordOriginalValue("Usu_Id", _usu_Id)
                If Not IsDeserializing Then
                    If Usuarios IsNot Nothing AndAlso Not Equals(Usuarios.USU_ID, value) Then
                        Usuarios = Nothing
                    End If
                End If
                _usu_Id = value
                OnPropertyChanged("Usu_Id")
            End If
        End Set
    End Property

    Private _usu_Id As String

    <DataMember()>
    Public Property prd_FecGrab() As Nullable(Of Date)
        Get
            Return _prd_FecGrab
        End Get
        Set(ByVal value As Nullable(Of Date))
            If Not Equals(_prd_FecGrab, value) Then
                _prd_FecGrab = value
                OnPropertyChanged("prd_FecGrab")
            End If
        End Set
    End Property

    Private _prd_FecGrab As Nullable(Of Date)

    <DataMember()>
    Public Property ALM_ID() As Nullable(Of Integer)
        Get
            Return _aLM_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_aLM_ID, value) Then
                ChangeTracker.RecordOriginalValue("ALM_ID", _aLM_ID)
                If Not IsDeserializing Then
                    If Almacen IsNot Nothing AndAlso Not Equals(Almacen.ALM_ID, value) Then
                        Almacen = Nothing
                    End If
                End If
                _aLM_ID = value
                OnPropertyChanged("ALM_ID")
            End If
        End Set
    End Property

    Private _aLM_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property OTR_ID() As Nullable(Of Integer)
        Get
            Return _oTR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_oTR_ID, value) Then
                _oTR_ID = value
                OnPropertyChanged("OTR_ID")
            End If
        End Set
    End Property

    Private _oTR_ID As Nullable(Of Integer)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property ClaseCuenta() As ClaseCuenta
        Get
            Return _claseCuenta
        End Get
        Set(ByVal value As ClaseCuenta)
            If _claseCuenta IsNot value Then
                Dim previousValue As ClaseCuenta = _claseCuenta
                _claseCuenta = value
                FixupClaseCuenta(previousValue)
                OnNavigationPropertyChanged("ClaseCuenta")
            End If
        End Set
    End Property

    Private _claseCuenta As ClaseCuenta


    <DataMember()>
    Public Property Almacen() As Almacen
        Get
            Return _almacen
        End Get
        Set(ByVal value As Almacen)
            If _almacen IsNot value Then
                Dim previousValue As Almacen = _almacen
                _almacen = value
                FixupAlmacen(previousValue)
                OnNavigationPropertyChanged("Almacen")
            End If
        End Set
    End Property

    Private _almacen As Almacen


    <DataMember()>
    Public Property CentroCostos() As CentroCostos
        Get
            Return _centroCostos
        End Get
        Set(ByVal value As CentroCostos)
            If _centroCostos IsNot value Then
                Dim previousValue As CentroCostos = _centroCostos
                _centroCostos = value
                FixupCentroCostos(previousValue)
                OnNavigationPropertyChanged("CentroCostos")
            End If
        End Set
    End Property

    Private _centroCostos As CentroCostos


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
    Public Property CuentasContables() As CuentasContables
        Get
            Return _cuentasContables
        End Get
        Set(ByVal value As CuentasContables)
            If _cuentasContables IsNot value Then
                Dim previousValue As CuentasContables = _cuentasContables
                _cuentasContables = value
                FixupCuentasContables(previousValue)
                OnNavigationPropertyChanged("CuentasContables")
            End If
        End Set
    End Property

    Private _cuentasContables As CuentasContables


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

    ' Este tipo de entidad es el extremo dependiente en al menos una asociación que realiza eliminaciones en cascada.
    ' Este controlador de eventos procesará notificaciones que tienen lugar cuando se elimina el extremo principal.
    Friend Sub HandleCascadeDelete(ByVal sender As Object, ByVal e As ObjectStateChangingEventArgs)
        If e.NewState = ObjectState.Deleted Then
            Me.MarkAsDeleted()
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
        ClaseCuenta = Nothing
        Almacen = Nothing
        CentroCostos = Nothing
        Usuarios = Nothing
        CuentasContables = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupClaseCuenta(ByVal previousValue As ClaseCuenta, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleProvisionCompras.Contains(Me) Then
            previousValue.DetalleProvisionCompras.Remove(Me)
        End If

        If ClaseCuenta IsNot Nothing Then
            If Not ClaseCuenta.DetalleProvisionCompras.Contains(Me) Then
                ClaseCuenta.DetalleProvisionCompras.Add(Me)
            End If

            cls_Id = ClaseCuenta.cls_Id
        ElseIf Not skipKeys Then
            cls_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("ClaseCuenta") AndAlso
                ChangeTracker.OriginalValues("ClaseCuenta") Is ClaseCuenta Then
                ChangeTracker.OriginalValues.Remove("ClaseCuenta")
            Else
                ChangeTracker.RecordOriginalValue("ClaseCuenta", previousValue)
            End If
            If ClaseCuenta IsNot Nothing AndAlso Not ClaseCuenta.ChangeTracker.ChangeTrackingEnabled Then
                ClaseCuenta.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupAlmacen(ByVal previousValue As Almacen, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Almacen IsNot Nothing Then
            ALM_ID = Almacen.ALM_ID
        ElseIf Not skipKeys Then
            ALM_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Almacen") AndAlso
                ChangeTracker.OriginalValues("Almacen") Is Almacen Then
                ChangeTracker.OriginalValues.Remove("Almacen")
            Else
                ChangeTracker.RecordOriginalValue("Almacen", previousValue)
            End If
            If Almacen IsNot Nothing AndAlso Not Almacen.ChangeTracker.ChangeTrackingEnabled Then
                Almacen.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupCentroCostos(ByVal previousValue As CentroCostos, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleProvisionCompras.Contains(Me) Then
            previousValue.DetalleProvisionCompras.Remove(Me)
        End If

        If CentroCostos IsNot Nothing Then
            If Not CentroCostos.DetalleProvisionCompras.Contains(Me) Then
                CentroCostos.DetalleProvisionCompras.Add(Me)
            End If

            cco_Id = CentroCostos.CCO_ID
        ElseIf Not skipKeys Then
            cco_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CentroCostos") AndAlso
                ChangeTracker.OriginalValues("CentroCostos") Is CentroCostos Then
                ChangeTracker.OriginalValues.Remove("CentroCostos")
            Else
                ChangeTracker.RecordOriginalValue("CentroCostos", previousValue)
            End If
            If CentroCostos IsNot Nothing AndAlso Not CentroCostos.ChangeTracker.ChangeTrackingEnabled Then
                CentroCostos.StartTracking()
            End If
        End If
    End Sub

    Private Sub FixupUsuarios(ByVal previousValue As Usuarios, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleProvisionCompras.Contains(Me) Then
            previousValue.DetalleProvisionCompras.Remove(Me)
        End If

        If Usuarios IsNot Nothing Then
            If Not Usuarios.DetalleProvisionCompras.Contains(Me) Then
                Usuarios.DetalleProvisionCompras.Add(Me)
            End If

            Usu_Id = Usuarios.USU_ID
        ElseIf Not skipKeys Then
            Usu_Id = Nothing
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

    Private Sub FixupCuentasContables(ByVal previousValue As CuentasContables, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If previousValue IsNot Nothing AndAlso previousValue.DetalleProvisionCompras.Contains(Me) Then
            previousValue.DetalleProvisionCompras.Remove(Me)
        End If

        If CuentasContables IsNot Nothing Then
            If Not CuentasContables.DetalleProvisionCompras.Contains(Me) Then
                CuentasContables.DetalleProvisionCompras.Add(Me)
            End If

            cuc_Id = CuentasContables.CUC_ID
        ElseIf Not skipKeys Then
            cuc_Id = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("CuentasContables") AndAlso
                ChangeTracker.OriginalValues("CuentasContables") Is CuentasContables Then
                ChangeTracker.OriginalValues.Remove("CuentasContables")
            Else
                ChangeTracker.RecordOriginalValue("CuentasContables", previousValue)
            End If
            If CuentasContables IsNot Nothing AndAlso Not CuentasContables.ChangeTracker.ChangeTrackingEnabled Then
                CuentasContables.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
