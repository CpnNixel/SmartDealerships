namespace SmartDealerships.DataAccess.Extensions;

public static class CollectionExtensions
{
    public static void AddRange<T>(this ICollection<T> destination,
        IEnumerable<T> source)
    {
        if (source.Count() == 1)
        {
            destination.Add(source.First());
            return;
        }
        
        foreach (T item in source)
        {
            destination.Add(item);
        }
    }
}