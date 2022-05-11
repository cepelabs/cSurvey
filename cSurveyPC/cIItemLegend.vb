Namespace cSurvey.Design.Items
    Public Interface cIItemLegend
        Inherits cIItemText

        ReadOnly Property Items As List(Of cItemLegend.cLegendItem)

        <Flags> Enum AutoFillFlagsEnum
            None = 0
            AllowDuplicatedNames = 1
        End Enum

        Sub AutoFill(Append As Boolean, Flag As AutoFillFlagsEnum)
        Sub AddItemRange(Items As List(Of cItem), Type As cItemLegend.cLegendItem.ItemTypeEnum)
        Function AddItem(Item As cItem) As cItemLegend.cLegendItem
        Function AddItem(Item As cItem, Type As cItemLegend.cLegendItem.ItemTypeEnum, Text As String) As cItemLegend.cLegendItem
        Function ValidateItem(Item As cItem) As Boolean

        Property ItemHPadding As Single
        Property ItemVPadding As Single
        Property ItemWidth As Single
        Property ItemHeight As Single

        Property ItemScale As Single

        Enum ItemAlignmentEnum
            Left = 0
            Right = 1
        End Enum

        Enum FlowDirectionEnum
            Vertical = 0
            Horizontal = 1
        End Enum

        Property ItemAlignment As ItemAlignmentEnum
        Property FlowDirection As FlowDirectionEnum
        Property MaxItems As Integer
    End Interface
End Namespace