# How to suspend the PING sound when perform the Tab operation in DataGrid(SfDataGrid)?

## About the sample

This example illustrates how to suspend the PING sound when perform the Tab operation in DataGrid(SfDataGrid)?

SfDataGrid doesn’t have direct support to disable this sound, which occurs when pressing Tab key on the TextBox. It is the behavior of the default TextBox. However, you can disable this by enabling the SuppressKeyPress property within the KeyDown event of the TextBox. In SfDataGrid cells this can be achieved by creating custom renderer. 

```C#
this.sfDataGrid.CellRenderers["TextBox"] = new GridTextBoxCellRendererExt(); 
 
class GridTextBoxCellRendererExt : GridTextBoxCellRenderer 
{ 
    protected override void OnInitializeEditElement(DataColumnBase column, Syncfusion.WinForms.GridCommon.ScrollAxis.RowColumnIndex rowColumnIndex, TextBox uiElement) 
    { 
        base.OnInitializeEditElement(column, rowColumnIndex, uiElement); 
        uiElement.KeyDown += uiElement_KeyDown; 
    } 
 
    protected override void OnUnwireEditUIElement(TextBox uiElement) 
    { 
        base.OnUnwireEditUIElement(uiElement); 
        uiElement.KeyDown -= uiElement_KeyDown; 
    } 
 
    void uiElement_KeyDown(object sender, KeyEventArgs e) 
    { 
        if (e.KeyCode == Keys.Tab) 
            e.SuppressKeyPress = true; 
    } 
} 
```

### Requirements to run the demo
Visual Studio 2015 and above versions
