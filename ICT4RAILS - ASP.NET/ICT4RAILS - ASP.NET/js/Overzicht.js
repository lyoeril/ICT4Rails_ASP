function EnterEvent(e)
{
    if (e.keyCode == 13)
    {
        __doPostBack('<%=btnBarcode.UniqueID%>', "");
    }
}