namespace SmartDealerships.Infrastructure.Extensions;

public static class DateTimeExtensions
{
    public static DateTime? SetKindUtc(this DateTime? dateTime)
    {
        if (dateTime.HasValue)
        {
            return dateTime.Value.SetKindUtc();
        }

        return null;
    }
    public static DateTime SetKindUtc(this DateTime dateTime)
    {
        return dateTime.Kind == DateTimeKind.Utc
            ? dateTime 
            : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}