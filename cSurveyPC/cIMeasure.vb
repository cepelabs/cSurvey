Imports cSurveyPC.cSurvey
Public Interface cIMeasure
    Property DataFormat As cSegment.DataFormatEnum
    Property DistanceType As cSegment.DistanceTypeEnum
    Property BearingType As cSegment.BearingTypeEnum
    Property InclinationType As cSegment.InclinationTypeEnum
    Property BearingDirection As cSegment.MeasureDirectionEnum
    Property InclinationDirection As cSegment.MeasureDirectionEnum
    Property DepthType As cSegment.DepthTypeEnum

    Property Grade As String

    Property NordType() As cSegment.NordTypeEnum
    Property DeclinationEnabled As Boolean   'specifica se usare l'indicazione di declinazione manuale
    Property Declination As Single          'declinazione manuale valida in caso di nord magnetico

    Property SideMeasuresType() As cSegment.SideMeasuresTypeEnum
    Property SideMeasuresReferTo() As cSegment.SideMeasuresReferToEnum

    Property VThreshold As Single
    Property VThresholdEnabled As Boolean
End Interface
