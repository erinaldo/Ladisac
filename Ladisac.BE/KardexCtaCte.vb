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
Partial Public Class KardexCtaCte
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DOC_FECHA_EMI_REF As string = "DOC_FECHA_EMI_REF"
				public shared DOC_FECHA_VEN_REF As string = "DOC_FECHA_VEN_REF"
				public shared CUC_ID_REF As string = "CUC_ID_REF"
				public shared CCO_ID_REF As string = "CCO_ID_REF"
				public shared CCC_ID_REF As string = "CCC_ID_REF"
				public shared CCT_ID_REF As string = "CCT_ID_REF"
				public shared TDO_ID_REF As string = "TDO_ID_REF"
				public shared DTD_ID_REF As string = "DTD_ID_REF"
				public shared DOC_SERIE_REF As string = "DOC_SERIE_REF"
				public shared DOC_NUMERO_REF As string = "DOC_NUMERO_REF"
				public shared ITEM_REF As string = "ITEM_REF"
				public shared MON_ID_CCC As string = "MON_ID_CCC"
				public shared CCC_ID As string = "CCC_ID"
				public shared CCT_ID As string = "CCT_ID"
				public shared TDO_ID As string = "TDO_ID"
				public shared DTD_ID As string = "DTD_ID"
				public shared DOC_SERIE As string = "DOC_SERIE"
				public shared DOC_NUMERO As string = "DOC_NUMERO"
				public shared ITEM As string = "ITEM"
				public shared MON_ID As string = "MON_ID"
				public shared PER_ID_CLI As string = "PER_ID_CLI"
				public shared CARGO As string = "CARGO"
				public shared ABONO As string = "ABONO"
				public shared DTE_CONTRAVALOR_DOC As string = "DTE_CONTRAVALOR_DOC"
				public shared MPT_MEDIO_PAGO As string = "MPT_MEDIO_PAGO"
				public shared MPT_NUMERO_MEDIO As string = "MPT_NUMERO_MEDIO"
				public shared PER_ID_BAN As string = "PER_ID_BAN"
				public shared DOCUMENTO As string = "DOCUMENTO"
				public shared PERIODO_ID As string = "PERIODO_ID"
				public shared TIPO As string = "TIPO"
				public shared OBSERVACIONES As string = "OBSERVACIONES"
		    End Structure
	



    <DataMember()>
    Public Property DOC_FECHA_EMI_REF() As Date
        Get
            Return _dOC_FECHA_EMI_REF
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dOC_FECHA_EMI_REF, value) Then
                _dOC_FECHA_EMI_REF = value
                OnPropertyChanged("DOC_FECHA_EMI_REF")
            End If
        End Set
    End Property

    Private _dOC_FECHA_EMI_REF As Date

    <DataMember()>
    Public Property DOC_FECHA_VEN_REF() As Date
        Get
            Return _dOC_FECHA_VEN_REF
        End Get
        Set(ByVal value As Date)
            If Not Equals(_dOC_FECHA_VEN_REF, value) Then
                _dOC_FECHA_VEN_REF = value
                OnPropertyChanged("DOC_FECHA_VEN_REF")
            End If
        End Set
    End Property

    Private _dOC_FECHA_VEN_REF As Date

    <DataMember()>
    Public Property CUC_ID_REF() As String
        Get
            Return _cUC_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_cUC_ID_REF, value) Then
                _cUC_ID_REF = value
                OnPropertyChanged("CUC_ID_REF")
            End If
        End Set
    End Property

    Private _cUC_ID_REF As String

    <DataMember()>
    Public Property CCO_ID_REF() As String
        Get
            Return _cCO_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCO_ID_REF, value) Then
                _cCO_ID_REF = value
                OnPropertyChanged("CCO_ID_REF")
            End If
        End Set
    End Property

    Private _cCO_ID_REF As String

    <DataMember()>
    Public Property CCC_ID_REF() As String
        Get
            Return _cCC_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCC_ID_REF, value) Then
                _cCC_ID_REF = value
                OnPropertyChanged("CCC_ID_REF")
            End If
        End Set
    End Property

    Private _cCC_ID_REF As String

    <DataMember()>
    Public Property CCT_ID_REF() As String
        Get
            Return _cCT_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID_REF, value) Then
                _cCT_ID_REF = value
                OnPropertyChanged("CCT_ID_REF")
            End If
        End Set
    End Property

    Private _cCT_ID_REF As String

    <DataMember()>
    Public Property TDO_ID_REF() As String
        Get
            Return _tDO_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID_REF, value) Then
                _tDO_ID_REF = value
                OnPropertyChanged("TDO_ID_REF")
            End If
        End Set
    End Property

    Private _tDO_ID_REF As String

    <DataMember()>
    Public Property DTD_ID_REF() As String
        Get
            Return _dTD_ID_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID_REF, value) Then
                _dTD_ID_REF = value
                OnPropertyChanged("DTD_ID_REF")
            End If
        End Set
    End Property

    Private _dTD_ID_REF As String

    <DataMember()>
    Public Property DOC_SERIE_REF() As String
        Get
            Return _dOC_SERIE_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOC_SERIE_REF, value) Then
                _dOC_SERIE_REF = value
                OnPropertyChanged("DOC_SERIE_REF")
            End If
        End Set
    End Property

    Private _dOC_SERIE_REF As String

    <DataMember()>
    Public Property DOC_NUMERO_REF() As String
        Get
            Return _dOC_NUMERO_REF
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOC_NUMERO_REF, value) Then
                _dOC_NUMERO_REF = value
                OnPropertyChanged("DOC_NUMERO_REF")
            End If
        End Set
    End Property

    Private _dOC_NUMERO_REF As String

    <DataMember()>
    Public Property ITEM_REF() As Decimal
        Get
            Return _iTEM_REF
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_iTEM_REF, value) Then
                _iTEM_REF = value
                OnPropertyChanged("ITEM_REF")
            End If
        End Set
    End Property

    Private _iTEM_REF As Decimal

    <DataMember()>
    Public Property MON_ID_CCC() As String
        Get
            Return _mON_ID_CCC
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID_CCC, value) Then
                _mON_ID_CCC = value
                OnPropertyChanged("MON_ID_CCC")
            End If
        End Set
    End Property

    Private _mON_ID_CCC As String

    <DataMember()>
    Public Property CCC_ID() As String
        Get
            Return _cCC_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCC_ID, value) Then
                _cCC_ID = value
                OnPropertyChanged("CCC_ID")
            End If
        End Set
    End Property

    Private _cCC_ID As String

    <DataMember()>
    Public Property CCT_ID() As String
        Get
            Return _cCT_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_cCT_ID, value) Then
                _cCT_ID = value
                OnPropertyChanged("CCT_ID")
            End If
        End Set
    End Property

    Private _cCT_ID As String

    <DataMember()>
    Public Property TDO_ID() As String
        Get
            Return _tDO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_tDO_ID, value) Then
                _tDO_ID = value
                OnPropertyChanged("TDO_ID")
            End If
        End Set
    End Property

    Private _tDO_ID As String

    <DataMember()>
    Public Property DTD_ID() As String
        Get
            Return _dTD_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_dTD_ID, value) Then
                _dTD_ID = value
                OnPropertyChanged("DTD_ID")
            End If
        End Set
    End Property

    Private _dTD_ID As String

    <DataMember()>
    Public Property DOC_SERIE() As String
        Get
            Return _dOC_SERIE
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOC_SERIE, value) Then
                _dOC_SERIE = value
                OnPropertyChanged("DOC_SERIE")
            End If
        End Set
    End Property

    Private _dOC_SERIE As String

    <DataMember()>
    Public Property DOC_NUMERO() As String
        Get
            Return _dOC_NUMERO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOC_NUMERO, value) Then
                _dOC_NUMERO = value
                OnPropertyChanged("DOC_NUMERO")
            End If
        End Set
    End Property

    Private _dOC_NUMERO As String

    <DataMember()>
    Public Property ITEM() As Decimal
        Get
            Return _iTEM
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_iTEM, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'ITEM' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _iTEM = value
                OnPropertyChanged("ITEM")
            End If
        End Set
    End Property

    Private _iTEM As Decimal

    <DataMember()>
    Public Property MON_ID() As String
        Get
            Return _mON_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_mON_ID, value) Then
                _mON_ID = value
                OnPropertyChanged("MON_ID")
            End If
        End Set
    End Property

    Private _mON_ID As String

    <DataMember()>
    Public Property PER_ID_CLI() As String
        Get
            Return _pER_ID_CLI
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_CLI, value) Then
                _pER_ID_CLI = value
                OnPropertyChanged("PER_ID_CLI")
            End If
        End Set
    End Property

    Private _pER_ID_CLI As String

    <DataMember()>
    Public Property CARGO() As Decimal
        Get
            Return _cARGO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_cARGO, value) Then
                _cARGO = value
                OnPropertyChanged("CARGO")
            End If
        End Set
    End Property

    Private _cARGO As Decimal

    <DataMember()>
    Public Property ABONO() As Decimal
        Get
            Return _aBONO
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_aBONO, value) Then
                _aBONO = value
                OnPropertyChanged("ABONO")
            End If
        End Set
    End Property

    Private _aBONO As Decimal

    <DataMember()>
    Public Property DTE_CONTRAVALOR_DOC() As Decimal
        Get
            Return _dTE_CONTRAVALOR_DOC
        End Get
        Set(ByVal value As Decimal)
            If Not Equals(_dTE_CONTRAVALOR_DOC, value) Then
                _dTE_CONTRAVALOR_DOC = value
                OnPropertyChanged("DTE_CONTRAVALOR_DOC")
            End If
        End Set
    End Property

    Private _dTE_CONTRAVALOR_DOC As Decimal

    <DataMember()>
    Public Property MPT_MEDIO_PAGO() As Nullable(Of Short)
        Get
            Return _mPT_MEDIO_PAGO
        End Get
        Set(ByVal value As Nullable(Of Short))
            If Not Equals(_mPT_MEDIO_PAGO, value) Then
                _mPT_MEDIO_PAGO = value
                OnPropertyChanged("MPT_MEDIO_PAGO")
            End If
        End Set
    End Property

    Private _mPT_MEDIO_PAGO As Nullable(Of Short)

    <DataMember()>
    Public Property MPT_NUMERO_MEDIO() As String
        Get
            Return _mPT_NUMERO_MEDIO
        End Get
        Set(ByVal value As String)
            If Not Equals(_mPT_NUMERO_MEDIO, value) Then
                _mPT_NUMERO_MEDIO = value
                OnPropertyChanged("MPT_NUMERO_MEDIO")
            End If
        End Set
    End Property

    Private _mPT_NUMERO_MEDIO As String

    <DataMember()>
    Public Property PER_ID_BAN() As String
        Get
            Return _pER_ID_BAN
        End Get
        Set(ByVal value As String)
            If Not Equals(_pER_ID_BAN, value) Then
                _pER_ID_BAN = value
                OnPropertyChanged("PER_ID_BAN")
            End If
        End Set
    End Property

    Private _pER_ID_BAN As String

    <DataMember()>
    Public Property DOCUMENTO() As String
        Get
            Return _dOCUMENTO
        End Get
        Set(ByVal value As String)
            If Not Equals(_dOCUMENTO, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DOCUMENTO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dOCUMENTO = value
                OnPropertyChanged("DOCUMENTO")
            End If
        End Set
    End Property

    Private _dOCUMENTO As String

    <DataMember()>
    Public Property PERIODO_ID() As String
        Get
            Return _pERIODO_ID
        End Get
        Set(ByVal value As String)
            If Not Equals(_pERIODO_ID, value) Then
                _pERIODO_ID = value
                OnPropertyChanged("PERIODO_ID")
            End If
        End Set
    End Property

    Private _pERIODO_ID As String

    <DataMember()>
    Public Property TIPO() As String
        Get
            Return _tIPO
        End Get
        Set(ByVal value As String)
            If Not Equals(_tIPO, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'TIPO' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _tIPO = value
                OnPropertyChanged("TIPO")
            End If
        End Set
    End Property

    Private _tIPO As String

    <DataMember()>
    Public Property OBSERVACIONES() As String
        Get
            Return _oBSERVACIONES
        End Get
        Set(ByVal value As String)
            If Not Equals(_oBSERVACIONES, value) Then
                _oBSERVACIONES = value
                OnPropertyChanged("OBSERVACIONES")
            End If
        End Set
    End Property

    Private _oBSERVACIONES As String

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