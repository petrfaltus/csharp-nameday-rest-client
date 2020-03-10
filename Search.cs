
namespace NameDayRestClient
{
    static class Search
    {
        private static string lastError = null;

        public static string run(string query)
        {
            lastError = null; // await no errors

            string result = query;

            return result;
        }

        public static string getLastError()
        {
            return lastError;
        }
    }
}
