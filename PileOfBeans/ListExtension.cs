using System.Collections.Generic;

/// <summary>
/// ListExtension extends list functionality 
/// </summary>
static class ListExtension
{
    public static T PopAt<T>(this List<T> list, int index)
    {
        T result = list[index];
        list.RemoveAt(index);
        return result;
    }

    public static T Pop<T>(this List<T> list)
    {
        return list.PopAt(0); ;
    }
}