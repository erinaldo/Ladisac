Imports Ladisac.BENamespace Ladisac.BL    Public Interface IBCSeriesDatosUsuarios        Function Mantenimiento(ByVal Item As SeriesDatosUsuarios) As Short        Function DeleteRegistro(ByVal item As SeriesDatosUsuarios, ByVal cDAU_ID As String, _                                                                   ByVal cPVE_ID As String, _                                                                   ByVal cTDO_ID As String, _                                                                   ByVal cCTD_COR_SERIE As String) As Short    End InterfaceEnd Namespace