namespace Ecom.Services.CouponAPI.Helpers
{
    public static class NullChecking
    {
        public static bool IsNull<T>(this T obj) where T : class
            => obj == null;
    }
}
