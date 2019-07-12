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
<KnownType(GetType(Parada))>
Partial Public Class ControlParadaDetalle
    Implements IObjectWithChangeTracker
    Implements INotifyPropertyChanged

#Region "Propiedades primitivas"


	<DataContract()> Partial Public Structure PropertyNames
				public shared DCP_ID As string = "DCP_ID"
				public shared CPA_ID As string = "CPA_ID"
				public shared PAR_ID As string = "PAR_ID"
				public shared DCP_H00 As string = "DCP_H00"
				public shared DCP_H01 As string = "DCP_H01"
				public shared DCP_H02 As string = "DCP_H02"
				public shared DCP_H03 As string = "DCP_H03"
				public shared DCP_H04 As string = "DCP_H04"
				public shared DCP_H05 As string = "DCP_H05"
				public shared DCP_H06 As string = "DCP_H06"
				public shared DCP_H07 As string = "DCP_H07"
				public shared DCP_H08 As string = "DCP_H08"
				public shared DCP_H09 As string = "DCP_H09"
				public shared DCP_H10 As string = "DCP_H10"
				public shared DCP_H11 As string = "DCP_H11"
				public shared DCP_H12 As string = "DCP_H12"
				public shared DCP_H13 As string = "DCP_H13"
				public shared DCP_H14 As string = "DCP_H14"
				public shared DCP_H15 As string = "DCP_H15"
				public shared DCP_H16 As string = "DCP_H16"
				public shared DCP_H17 As string = "DCP_H17"
				public shared DCP_H18 As string = "DCP_H18"
				public shared DCP_H19 As string = "DCP_H19"
				public shared DCP_H20 As string = "DCP_H20"
				public shared DCP_H21 As string = "DCP_H21"
				public shared DCP_H22 As string = "DCP_H22"
				public shared DCP_H23 As string = "DCP_H23"
		    End Structure
	



    <DataMember()>
    Public Property DCP_ID() As Integer
        Get
            Return _dCP_ID
        End Get
        Set(ByVal value As Integer)
            If Not Equals(_dCP_ID, value) Then
                If ChangeTracker.ChangeTrackingEnabled AndAlso ChangeTracker.State <> ObjectState.Added Then
                    Throw New InvalidOperationException("La propiedad 'DCP_ID' forma parte de la clave del objeto y no se puede modificar. Solo se pueden realizar cambios en las propiedades de clave cuando no se realiza un seguimiento del objeto o su estado es Agregado.")
                End If
                _dCP_ID = value
                OnPropertyChanged("DCP_ID")
            End If
        End Set
    End Property

    Private _dCP_ID As Integer

    <DataMember()>
    Public Property CPA_ID() As Nullable(Of Integer)
        Get
            Return _cPA_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_cPA_ID, value) Then
                ChangeTracker.RecordOriginalValue("CPA_ID", _cPA_ID)
                _cPA_ID = value
                OnPropertyChanged("CPA_ID")
            End If
        End Set
    End Property

    Private _cPA_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property PAR_ID() As Nullable(Of Integer)
        Get
            Return _pAR_ID
        End Get
        Set(ByVal value As Nullable(Of Integer))
            If Not Equals(_pAR_ID, value) Then
                ChangeTracker.RecordOriginalValue("PAR_ID", _pAR_ID)
                If Not IsDeserializing Then
                    If Parada IsNot Nothing AndAlso Not Equals(Parada.PAR_ID, value) Then
                        Parada = Nothing
                    End If
                End If
                _pAR_ID = value
                OnPropertyChanged("PAR_ID")
            End If
        End Set
    End Property

    Private _pAR_ID As Nullable(Of Integer)

    <DataMember()>
    Public Property DCP_H00() As Nullable(Of Decimal)
        Get
            Return _dCP_H00
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H00, value) Then
                _dCP_H00 = value
                OnPropertyChanged("DCP_H00")
            End If
        End Set
    End Property

    Private _dCP_H00 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H01() As Nullable(Of Decimal)
        Get
            Return _dCP_H01
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H01, value) Then
                _dCP_H01 = value
                OnPropertyChanged("DCP_H01")
            End If
        End Set
    End Property

    Private _dCP_H01 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H02() As Nullable(Of Decimal)
        Get
            Return _dCP_H02
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H02, value) Then
                _dCP_H02 = value
                OnPropertyChanged("DCP_H02")
            End If
        End Set
    End Property

    Private _dCP_H02 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H03() As Nullable(Of Decimal)
        Get
            Return _dCP_H03
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H03, value) Then
                _dCP_H03 = value
                OnPropertyChanged("DCP_H03")
            End If
        End Set
    End Property

    Private _dCP_H03 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H04() As Nullable(Of Decimal)
        Get
            Return _dCP_H04
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H04, value) Then
                _dCP_H04 = value
                OnPropertyChanged("DCP_H04")
            End If
        End Set
    End Property

    Private _dCP_H04 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H05() As Nullable(Of Decimal)
        Get
            Return _dCP_H05
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H05, value) Then
                _dCP_H05 = value
                OnPropertyChanged("DCP_H05")
            End If
        End Set
    End Property

    Private _dCP_H05 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H06() As Nullable(Of Decimal)
        Get
            Return _dCP_H06
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H06, value) Then
                _dCP_H06 = value
                OnPropertyChanged("DCP_H06")
            End If
        End Set
    End Property

    Private _dCP_H06 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H07() As Nullable(Of Decimal)
        Get
            Return _dCP_H07
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H07, value) Then
                _dCP_H07 = value
                OnPropertyChanged("DCP_H07")
            End If
        End Set
    End Property

    Private _dCP_H07 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H08() As Nullable(Of Decimal)
        Get
            Return _dCP_H08
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H08, value) Then
                _dCP_H08 = value
                OnPropertyChanged("DCP_H08")
            End If
        End Set
    End Property

    Private _dCP_H08 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H09() As Nullable(Of Decimal)
        Get
            Return _dCP_H09
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H09, value) Then
                _dCP_H09 = value
                OnPropertyChanged("DCP_H09")
            End If
        End Set
    End Property

    Private _dCP_H09 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H10() As Nullable(Of Decimal)
        Get
            Return _dCP_H10
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H10, value) Then
                _dCP_H10 = value
                OnPropertyChanged("DCP_H10")
            End If
        End Set
    End Property

    Private _dCP_H10 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H11() As Nullable(Of Decimal)
        Get
            Return _dCP_H11
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H11, value) Then
                _dCP_H11 = value
                OnPropertyChanged("DCP_H11")
            End If
        End Set
    End Property

    Private _dCP_H11 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H12() As Nullable(Of Decimal)
        Get
            Return _dCP_H12
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H12, value) Then
                _dCP_H12 = value
                OnPropertyChanged("DCP_H12")
            End If
        End Set
    End Property

    Private _dCP_H12 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H13() As Nullable(Of Decimal)
        Get
            Return _dCP_H13
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H13, value) Then
                _dCP_H13 = value
                OnPropertyChanged("DCP_H13")
            End If
        End Set
    End Property

    Private _dCP_H13 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H14() As Nullable(Of Decimal)
        Get
            Return _dCP_H14
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H14, value) Then
                _dCP_H14 = value
                OnPropertyChanged("DCP_H14")
            End If
        End Set
    End Property

    Private _dCP_H14 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H15() As Nullable(Of Decimal)
        Get
            Return _dCP_H15
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H15, value) Then
                _dCP_H15 = value
                OnPropertyChanged("DCP_H15")
            End If
        End Set
    End Property

    Private _dCP_H15 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H16() As Nullable(Of Decimal)
        Get
            Return _dCP_H16
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H16, value) Then
                _dCP_H16 = value
                OnPropertyChanged("DCP_H16")
            End If
        End Set
    End Property

    Private _dCP_H16 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H17() As Nullable(Of Decimal)
        Get
            Return _dCP_H17
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H17, value) Then
                _dCP_H17 = value
                OnPropertyChanged("DCP_H17")
            End If
        End Set
    End Property

    Private _dCP_H17 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H18() As Nullable(Of Decimal)
        Get
            Return _dCP_H18
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H18, value) Then
                _dCP_H18 = value
                OnPropertyChanged("DCP_H18")
            End If
        End Set
    End Property

    Private _dCP_H18 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H19() As Nullable(Of Decimal)
        Get
            Return _dCP_H19
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H19, value) Then
                _dCP_H19 = value
                OnPropertyChanged("DCP_H19")
            End If
        End Set
    End Property

    Private _dCP_H19 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H20() As Nullable(Of Decimal)
        Get
            Return _dCP_H20
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H20, value) Then
                _dCP_H20 = value
                OnPropertyChanged("DCP_H20")
            End If
        End Set
    End Property

    Private _dCP_H20 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H21() As Nullable(Of Decimal)
        Get
            Return _dCP_H21
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H21, value) Then
                _dCP_H21 = value
                OnPropertyChanged("DCP_H21")
            End If
        End Set
    End Property

    Private _dCP_H21 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H22() As Nullable(Of Decimal)
        Get
            Return _dCP_H22
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H22, value) Then
                _dCP_H22 = value
                OnPropertyChanged("DCP_H22")
            End If
        End Set
    End Property

    Private _dCP_H22 As Nullable(Of Decimal)

    <DataMember()>
    Public Property DCP_H23() As Nullable(Of Decimal)
        Get
            Return _dCP_H23
        End Get
        Set(ByVal value As Nullable(Of Decimal))
            If Not Equals(_dCP_H23, value) Then
                _dCP_H23 = value
                OnPropertyChanged("DCP_H23")
            End If
        End Set
    End Property

    Private _dCP_H23 As Nullable(Of Decimal)

#End Region
#Region "Propiedades de navegación"

    <DataMember()>
    Public Property Parada() As Parada
        Get
            Return _parada
        End Get
        Set(ByVal value As Parada)
            If _parada IsNot value Then
                Dim previousValue As Parada = _parada
                _parada = value
                FixupParada(previousValue)
                OnNavigationPropertyChanged("Parada")
            End If
        End Set
    End Property

    Private _parada As Parada


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
        Parada = Nothing
    End Sub

#End Region
#Region "Corrección de asociación"

    Private Sub FixupParada(ByVal previousValue As Parada, Optional ByVal skipKeys As Boolean = False)
        If IsDeserializing Then
            Return
        End If

        If Parada IsNot Nothing Then
            PAR_ID = Parada.PAR_ID
        ElseIf Not skipKeys Then
            PAR_ID = Nothing
        End If
        If ChangeTracker.ChangeTrackingEnabled Then
            If ChangeTracker.OriginalValues.ContainsKey("Parada") AndAlso
                ChangeTracker.OriginalValues("Parada") Is Parada Then
                ChangeTracker.OriginalValues.Remove("Parada")
            Else
                ChangeTracker.RecordOriginalValue("Parada", previousValue)
            End If
            If Parada IsNot Nothing AndAlso Not Parada.ChangeTracker.ChangeTrackingEnabled Then
                Parada.StartTracking()
            End If
        End If
    End Sub

#End Region
End Class
