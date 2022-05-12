/*fluent interface
example like linq or StringBuilder
var list = myCollection
  .Where(...)
  .OrderBy(...)
  .Take(5);

 Stringbuilder sb = new Stringbuilder();
            sb.Append("this").Append(" is").Append(" method chaining");

  return this;          
  */

public class MyClass
{
    private List<MyItem> _Items = new List<MyItem> ();

    public MyClass AddItem(MyItem item)
    {
        if(item!=null)
            _Items.Add(item);

        return this; //trick for method chaining
    }

}