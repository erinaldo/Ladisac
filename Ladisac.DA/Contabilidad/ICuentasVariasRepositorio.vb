﻿Imports Ladisac.BE
Namespace Ladisac.DA
    Public Interface ICuentasVariasRepositorio
        Function GetById(ByVal id As String) As CuentasVarias
        Function Mantenance(ByVal item As CuentasVarias) As Boolean

    End Interface

End Namespace


'Imports Ladisac.BE
'Namespace Ladisac.DA

'    Public Interface IClaseCuentaRepositorio
'        Function GetById(ByVal id As String) As ClaseCuenta
'        Function Mantenance(ByVal item As ClaseCuenta) As Boolean
'    End Interface
'End Namespace